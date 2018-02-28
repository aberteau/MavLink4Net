using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MavLink4Net.MessageDefinitions.Data;
using MavLink4Net.MessageDefinitions.Data.Extensions;

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

            AddWritePropertyStatements(codeMemberMethod, message, writerParamName, messageVariableName);

            return codeMemberMethod;
        }

        private static void AddWritePropertyStatements(CodeMemberMethod codeMemberMethod, Message message, string writerParamName, string messageVariableName)
        {
            IEnumerable<MessageField> orderedMessageFields = message.Fields.OrderForSerialization().ToList();

            foreach (MessageField messageField in orderedMessageFields)
            {
                CodePropertyReferenceExpression propertyExpression =
                    new CodePropertyReferenceExpression(new CodeVariableReferenceExpression(messageVariableName),
                        messageField.Name);

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
                    for (int i = 0; i < messageField.Type.ArrayLength; i++)
                    {
                        CodeArrayIndexerExpression codeArrayIndexerExpression =
                            new CodeArrayIndexerExpression(propertyExpression, new CodePrimitiveExpression(i));

                        CodeMethodInvokeExpression writeInvoke =
                            new CodeMethodInvokeExpression(
                                new CodeVariableReferenceExpression(writerParamName), "Write", codeArrayIndexerExpression);

                        codeMemberMethod.Statements.Add(writeInvoke);
                    }
                }
            }
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
    }
}
