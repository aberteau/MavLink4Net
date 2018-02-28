using System;
using System.CodeDom;
using System.IO;
using System.Linq;
using MavLink4Net.MessageDefinitions;
using MavLink4Net.MessageDefinitions.Data;

namespace MavLink4Net.CodeGenerator.Core
{
    class SerializerGeneratorHelper
    {
        public static CodeCompileUnit CreateCodeCompileUnit(MessageDefinitions.Data.Message message, string className, string ns, string interfaceName, string messageBaseClassName)
        {
            // Generate the container unit
            CodeCompileUnit codeCompileUnit = new CodeCompileUnit();

            CodeNamespace globalNamespace = new CodeNamespace(String.Empty);
            codeCompileUnit.Namespaces.Add(globalNamespace);

            // using
            globalNamespace.Imports.Add(new CodeNamespaceImport("System"));
            globalNamespace.Imports.Add(new CodeNamespaceImport("System.ComponentModel"));

            // Generate the namespace
            CodeNamespace codeNamespace = new CodeNamespace(ns);
            codeCompileUnit.Namespaces.Add(codeNamespace);

            // Declare the class
            CodeTypeDeclaration classDeclaration = ToCodeTypeDeclaration(message, className, interfaceName, messageBaseClassName);

            // Add class to the namespace
            codeNamespace.Types.Add(classDeclaration);

            return codeCompileUnit;
        }

        private static CodeTypeDeclaration ToCodeTypeDeclaration(MessageDefinitions.Data.Message message, string className, string interfaceName, string messageBaseClassName)
        {
            CodeTypeDeclaration codeTypeDeclaration = new CodeTypeDeclaration()
            {
                Name = className,
                IsClass = true
            };

            codeTypeDeclaration.BaseTypes.Add(interfaceName);

            CodeMemberMethod serializeCodeMemberMethod = CreateSerializeCodeMemberMethod(messageBaseClassName, message);
            codeTypeDeclaration.Members.Add(serializeCodeMemberMethod);

            CodeMemberMethod deserializeCodeMemberMethod = CreateDeserializeCodeMemberMethod(messageBaseClassName);
            codeTypeDeclaration.Members.Add(deserializeCodeMemberMethod);

            return codeTypeDeclaration;
        }

        private static CodeMemberMethod CreateSerializeCodeMemberMethod(string messageBaseClassName, Message message)
        {
            string writerParamName = "writer";
            string messageParamName = "message";

            CodeMemberMethod codeMemberMethod = new CodeMemberMethod();
            codeMemberMethod.Attributes = MemberAttributes.Public | MemberAttributes.Final;
            codeMemberMethod.Name = "Serialize";

            codeMemberMethod.Parameters.Add(new CodeParameterDeclarationExpression(typeof(BinaryWriter), writerParamName));
            codeMemberMethod.Parameters.Add(new CodeParameterDeclarationExpression(messageBaseClassName, messageParamName));

            string messageClassName = GeneratorHelper.GetMessageClassName(message);
            string messageClassFullName = $"MavLink4Net.Messages.Common.{messageClassName}";

            string messageVariableName = "tMessage";
            
            codeMemberMethod.Statements.Add(new CodeVariableDeclarationStatement(
                new CodeTypeReference(messageClassFullName), messageVariableName,
                new CodeSnippetExpression($"{messageParamName} as {messageClassFullName}")));

            foreach (MessageField messageField in message.Fields)
            {
                CodePropertyReferenceExpression propertyExpression = new CodePropertyReferenceExpression(new CodeVariableReferenceExpression(messageVariableName), messageField.Name);

                if (!messageField.Type.IsArray)
                {
                    if (messageField.Type.IsEnum)
                    {
                        CodeCastExpression castExpression = new CodeCastExpression(typeof(byte), propertyExpression);

                        CodeMethodInvokeExpression writeInvoke =
                            new CodeMethodInvokeExpression(
                                new CodeVariableReferenceExpression(writerParamName), "Write", castExpression);

                        codeMemberMethod.Statements.Add(writeInvoke);
                    }
                    else
                    {
                        CodeMethodInvokeExpression writeInvoke =
                            new CodeMethodInvokeExpression(
                                new CodeVariableReferenceExpression(writerParamName), "Write", propertyExpression);

                        codeMemberMethod.Statements.Add(writeInvoke);
                    }
                }
                else
                {
                    for (int i = 0; i < messageField.Type.ArraySize; i++)
                    {
                        CodeArrayIndexerExpression codeArrayIndexerExpression = new CodeArrayIndexerExpression(propertyExpression, new CodePrimitiveExpression(i));

                        CodeMethodInvokeExpression writeInvoke =
                            new CodeMethodInvokeExpression(
                                new CodeVariableReferenceExpression(writerParamName), "Write", codeArrayIndexerExpression);

                        codeMemberMethod.Statements.Add(writeInvoke);
                    }
                }
            }

            return codeMemberMethod;
        }

        private static CodeMemberMethod CreateDeserializeCodeMemberMethod(string messageBaseClassName)
        {
            CodeMemberMethod codeMemberMethod = new CodeMemberMethod();
            codeMemberMethod.Attributes = MemberAttributes.Public | MemberAttributes.Final;
            codeMemberMethod.Name = "Deserialize";
            codeMemberMethod.ReturnType = new CodeTypeReference(messageBaseClassName);
            codeMemberMethod.Parameters.Add(new CodeParameterDeclarationExpression(typeof(BinaryReader), "reader"));

            //TODO

            return codeMemberMethod;
        }

        private static void AddConstructor(CodeTypeDeclaration codeTypeDeclaration, string messageIdValue)
        {
            // Declare the constructor
            CodeConstructor constructor = new CodeConstructor();
            constructor.Attributes = MemberAttributes.Public | MemberAttributes.Final;

            constructor.BaseConstructorArgs.Add(new CodeArgumentReferenceExpression(messageIdValue));

            codeTypeDeclaration.Members.Add(constructor);
        }

        private static CodeMemberField ToCodeMemberField(MessageField messageField)
        {
            CodeMemberField codeMemberField = new CodeMemberField();
            codeMemberField.Attributes = MemberAttributes.Private;
            codeMemberField.Name = GetFieldName(messageField.Name);

            // Type
            Type type = MessageFieldPrimitiveTypeHelper.GetCSharpType(messageField.Type.PrimitiveType);
            CodeTypeReference codeTypeReference = GetCodeTypeReference(messageField.Type, type);
            codeMemberField.Type = codeTypeReference;

            if (messageField.Type.IsArray)
            {
                
                CodeArrayCreateExpression ca1 = new CodeArrayCreateExpression(type, messageField.Type.ArraySize);
                codeMemberField.InitExpression = ca1;
            }
                
            // Add summary comments
            CodeCommentStatement[] summaryCommentStatements = CodeCommentStatementHelper.GetSummaryCodeCommentStatements(messageField.Text);
            codeMemberField.Comments.AddRange(summaryCommentStatements);

            // Add remarks comments
            CodeCommentStatement[] remarksCommentStatements = CodeCommentStatementHelper.GetRemarksCodeCommentStatements(messageField.OriginalName);
            codeMemberField.Comments.AddRange(remarksCommentStatements);


            return codeMemberField;
        }

        public static string GetFieldName(string word)
        {
            if (String.IsNullOrWhiteSpace(word))
                return null;

            String firstChar = word.First().ToString().ToLower();
            String otherChars = word.Substring(1);

            string pascalStyleWord = $"_{firstChar}{otherChars}";
            return pascalStyleWord;
        }

        private static CodeTypeReference GetCodeTypeReference(MessageFieldType fieldType, Type type)
        {
            if (fieldType.IsEnum)
            {
                return new CodeTypeReference(fieldType.Enum);
            }

            CodeTypeReference codeTypeReference = new CodeTypeReference(type);

            if (fieldType.IsArray)
                codeTypeReference.ArrayRank = 1;

            return codeTypeReference;
        }

        private static CodeMemberProperty ToCodeMemberProperty(MessageField messageField)
        {
            CodeMemberProperty codeMemberProperty = new CodeMemberProperty();
            codeMemberProperty.Attributes = MemberAttributes.Public | MemberAttributes.Final;
            codeMemberProperty.Name = messageField.Name;
            codeMemberProperty.HasGet = true;
            
            // Type
            MessageFieldType fieldType = messageField.Type;
            CodeTypeReference codeTypeReference = GetCodeTypeReference(fieldType, MessageFieldPrimitiveTypeHelper.GetCSharpType(fieldType.PrimitiveType));
            codeMemberProperty.Type = codeTypeReference;

            string fieldName = GetFieldName(messageField.Name);

            // Getter
            codeMemberProperty.GetStatements.Add(new CodeMethodReturnStatement(
                new CodeFieldReferenceExpression(
                    new CodeThisReferenceExpression(), fieldName)));

            // Setter
            codeMemberProperty.SetStatements.Add(new CodeAssignStatement(
                new CodeFieldReferenceExpression(
                    new CodeThisReferenceExpression(), fieldName), new CodePropertySetValueReferenceExpression()));

            // Add summary comments
            CodeCommentStatement[] summaryCommentStatements = CodeCommentStatementHelper.GetSummaryCodeCommentStatements(messageField.Text);
            codeMemberProperty.Comments.AddRange(summaryCommentStatements);

            return codeMemberProperty;
        }
    }
}
