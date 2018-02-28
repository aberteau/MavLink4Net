using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MavLink4Net.MessageDefinitions;
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

            CodeMemberMethod deserializeCodeMemberMethod = CreateDeserializeCodeMemberMethod(messageBaseClassName, message);
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
            string commonNamespace = "MavLink4Net.Messages.Common";
            string messageClassFullName = NamespaceHelper.GetFullname(commonNamespace, messageClassName);

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
                        Type type = SystemTypeHelper.GetType(messageField.Type.PrimitiveType);
                        CodeCastExpression castExpression = new CodeCastExpression(type, propertyExpression);

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

        private static CodeMemberMethod CreateDeserializeCodeMemberMethod(string messageBaseClassName, Message message)
        {
            string readerParamName = "reader";
            string messageVariableName = "message";

            string messageClassName = GeneratorHelper.GetMessageClassName(message);
            string ns = "MavLink4Net.Messages.Common";
            string messageClassFullName = NamespaceHelper.GetFullname(ns, messageClassName);

            CodeMemberMethod codeMemberMethod = new CodeMemberMethod();
            codeMemberMethod.Attributes = MemberAttributes.Public | MemberAttributes.Final;
            codeMemberMethod.Name = "Deserialize";
            codeMemberMethod.ReturnType = new CodeTypeReference(messageBaseClassName);
            codeMemberMethod.Parameters.Add(new CodeParameterDeclarationExpression(typeof(BinaryReader), readerParamName));

            CodeTypeReference classTypeReference = new CodeTypeReference(messageClassFullName);
            codeMemberMethod.Statements.Add(new CodeVariableDeclarationStatement(
                classTypeReference, messageVariableName,
                new CodeObjectCreateExpression(classTypeReference)));

            AddReadPropertyStatements(codeMemberMethod, message, readerParamName, messageVariableName, ns);

            codeMemberMethod.Statements.Add(new CodeMethodReturnStatement(new CodeVariableReferenceExpression(messageVariableName)));

            return codeMemberMethod;
        }

        private static void AddReadPropertyStatements(CodeMemberMethod codeMemberMethod, Message message, string readerParamName, string messageVariableName, string ns)
        {
            IEnumerable<MessageField> orderedMessageFields = message.Fields.OrderForSerialization().ToList();

            foreach (MessageField messageField in orderedMessageFields)
            {
                CodePropertyReferenceExpression propertyExpression =
                    new CodePropertyReferenceExpression(new CodeVariableReferenceExpression(messageVariableName),
                        messageField.Name);

                String readMethodName = GetReadMethodName(messageField.Type.PrimitiveType);

                if (!messageField.Type.IsArray)
                {
                    if (messageField.Type.IsEnum)
                    {
                        var codeMethodInvokeExpression = new CodeMethodInvokeExpression(new CodeVariableReferenceExpression(readerParamName), readMethodName);

                        string enumFullname = NamespaceHelper.GetFullname(ns, messageField.Type.Enum.Name);
                        CodeAssignStatement propertyAssignStatement = new CodeAssignStatement(propertyExpression,
                            new CodeCastExpression(enumFullname, codeMethodInvokeExpression));

                        codeMemberMethod.Statements.Add(propertyAssignStatement);
                    }
                    else
                    {
                        CodeAssignStatement propertyAssignStatement = new CodeAssignStatement(propertyExpression,
                            new CodeMethodInvokeExpression(
                                new CodeVariableReferenceExpression(readerParamName), readMethodName));

                        codeMemberMethod.Statements.Add(propertyAssignStatement);
                    }
                }
                else
                {
                    for (int i = 0; i < messageField.Type.ArrayLength; i++)
                    {
                        CodeArrayIndexerExpression codeArrayIndexerExpression =
                            new CodeArrayIndexerExpression(propertyExpression, new CodePrimitiveExpression(i));

                        CodeAssignStatement propertyAssignStatement = new CodeAssignStatement(codeArrayIndexerExpression,
                            new CodeMethodInvokeExpression(
                                new CodeVariableReferenceExpression(readerParamName), readMethodName));

                        codeMemberMethod.Statements.Add(propertyAssignStatement);
                    }
                }
            }
        }

        private static string GetReadMethodName(MessageFieldPrimitiveType t)
        {
            switch (t)
            {
                case MessageFieldPrimitiveType.Float32: return "ReadSingle";
                case MessageFieldPrimitiveType.Int8: return "ReadSByte";
                case MessageFieldPrimitiveType.UInt8: return "ReadByte";
                case MessageFieldPrimitiveType.Int16: return "ReadInt16";
                case MessageFieldPrimitiveType.UInt16: return "ReadUInt16";
                case MessageFieldPrimitiveType.Int32: return "ReadInt32";
                case MessageFieldPrimitiveType.UInt32: return "ReadUInt32";
                case MessageFieldPrimitiveType.Int64: return "ReadInt64";
                case MessageFieldPrimitiveType.UInt64: return "ReadUInt64";
                case MessageFieldPrimitiveType.Char: return "ReadChar";
                case MessageFieldPrimitiveType.Double: return "ReadDouble";
                default:
                    return null;
            }
        }
    }
}
