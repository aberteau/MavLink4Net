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
        public static CodeCompileUnit CreateCodeCompileUnit(TypeInfo typeInfo, Message message, TypeInfo serializerInterfaceTypeInfo, TypeInfo messageBaseClassTypeInfo, String messagesNamespace)
        {
            // Generate the container unit
            CodeCompileUnit codeCompileUnit = new CodeCompileUnit();

            CodeNamespace globalNamespace = new CodeNamespace(String.Empty);
            codeCompileUnit.Namespaces.Add(globalNamespace);

            // Generate the namespace
            CodeNamespace codeNamespace = new CodeNamespace(typeInfo.Namespace);
            codeCompileUnit.Namespaces.Add(codeNamespace);

            // Declare the class
            CodeTypeDeclaration classDeclaration = ToCodeTypeDeclaration(message, typeInfo.Name, serializerInterfaceTypeInfo, messageBaseClassTypeInfo, messagesNamespace);

            // Add class to the namespace
            codeNamespace.Types.Add(classDeclaration);

            return codeCompileUnit;
        }

        private static CodeTypeDeclaration ToCodeTypeDeclaration(MessageDefinitions.Data.Message message, string className, TypeInfo serializerInterfaceTypeInfo, TypeInfo messageBaseClassTypeInfo, String messagesNamespace)
        {
            CodeTypeDeclaration codeTypeDeclaration = new CodeTypeDeclaration()
            {
                Name = className,
                IsClass = true
            };

            codeTypeDeclaration.BaseTypes.Add(serializerInterfaceTypeInfo.FullName);

            CodeMemberMethod serializeCodeMemberMethod = CreateSerializeCodeMemberMethod(messageBaseClassTypeInfo, message, messagesNamespace);
            codeTypeDeclaration.Members.Add(serializeCodeMemberMethod);

            CodeMemberMethod deserializeCodeMemberMethod = CreateDeserializeCodeMemberMethod(messageBaseClassTypeInfo, message);
            codeTypeDeclaration.Members.Add(deserializeCodeMemberMethod);

            return codeTypeDeclaration;
        }

        private static CodeMemberMethod CreateSerializeCodeMemberMethod(TypeInfo messageBaseClass, Message message, string messagesNamespace)
        {
            string writerParamName = "writer";
            string messageParamName = "message";

            CodeMemberMethod codeMemberMethod = new CodeMemberMethod();
            codeMemberMethod.Attributes = MemberAttributes.Public | MemberAttributes.Final;
            codeMemberMethod.Name = "Serialize";

            codeMemberMethod.Parameters.Add(new CodeParameterDeclarationExpression(typeof(BinaryWriter), writerParamName));
            codeMemberMethod.Parameters.Add(new CodeParameterDeclarationExpression(messageBaseClass.FullName, messageParamName));

            string messageVariableName = "tMessage";

            TypeInfo messageTypeInfo = TypeInfoHelper.GetTypeInfo(messagesNamespace, message);

            codeMemberMethod.Statements.Add(new CodeVariableDeclarationStatement(
                new CodeTypeReference(messageTypeInfo.FullName), messageVariableName,
                new CodeSnippetExpression($"{messageParamName} as {messageTypeInfo.FullName}")));

            AddWritePropertyStatements(codeMemberMethod, message, writerParamName, messageVariableName);

            return codeMemberMethod;
        }

        #region WriteCodeStatements

        private static void AddWritePropertyStatements(CodeMemberMethod codeMemberMethod, Message message, string writerParamName, string messageVariableName)
        {
            IEnumerable<MessageField> orderedMessageFields = message.Fields.OrderForSerialization().ToList();

            foreach (MessageField messageField in orderedMessageFields)
            {
                CodePropertyReferenceExpression propertyExpression =
                    new CodePropertyReferenceExpression(new CodeVariableReferenceExpression(messageVariableName),
                        messageField.Name);

                switch (messageField.Type.FieldType)
                {
                    case FieldType.Array:
                        AddArrayWriteCodeStatements(codeMemberMethod.Statements, writerParamName, messageField.Type, propertyExpression);
                        break;
                    case FieldType.Enum:
                        AddEnumWriteCodeStatements(codeMemberMethod.Statements, writerParamName, messageField.Type, propertyExpression);
                        break;
                    default:
                        AddPrimitiveWriteCodeStatements(codeMemberMethod.Statements, writerParamName, propertyExpression);
                        break;
                }
            }
        }

        private static void AddEnumWriteCodeStatements(CodeStatementCollection statements, string writerParamName, MessageFieldType fieldType, CodePropertyReferenceExpression propertyExpression)
        {
            Type type = SystemTypeHelper.GetType(fieldType.DataType);
            CodeCastExpression castExpression = new CodeCastExpression(type, propertyExpression);

            CodeMethodInvokeExpression writeInvoke =
                new CodeMethodInvokeExpression(
                    new CodeVariableReferenceExpression(writerParamName), "Write", castExpression);

            statements.Add(writeInvoke);
        }

        private static void AddArrayWriteCodeStatements(CodeStatementCollection statements, string writerParamName, MessageFieldType type, CodePropertyReferenceExpression propertyExpression)
        {
            for (int i = 0; i < type.ArrayLength; i++)
            {
                CodeArrayIndexerExpression codeArrayIndexerExpression =
                    new CodeArrayIndexerExpression(propertyExpression, new CodePrimitiveExpression(i));

                CodeMethodInvokeExpression writeInvoke =
                    new CodeMethodInvokeExpression(
                        new CodeVariableReferenceExpression(writerParamName), "Write", codeArrayIndexerExpression);

                statements.Add(writeInvoke);
            }
        }

        private static void AddPrimitiveWriteCodeStatements(CodeStatementCollection statements, string writerParamName, CodePropertyReferenceExpression propertyExpression)
        {
            CodeMethodInvokeExpression writeInvoke =
                new CodeMethodInvokeExpression(
                    new CodeVariableReferenceExpression(writerParamName), "Write", propertyExpression);

            statements.Add(writeInvoke);
        }

        #endregion

        private static CodeMemberMethod CreateDeserializeCodeMemberMethod(TypeInfo messageBaseClass, Message message)
        {
            string readerParamName = "reader";
            string messageVariableName = "message";

            string ns = "MavLink4Net.Messages.Common";
            TypeInfo typeInfo = TypeInfoHelper.GetTypeInfo(ns, message);

            CodeMemberMethod codeMemberMethod = new CodeMemberMethod();
            codeMemberMethod.Attributes = MemberAttributes.Public | MemberAttributes.Final;
            codeMemberMethod.Name = "Deserialize";
            codeMemberMethod.ReturnType = new CodeTypeReference(messageBaseClass.FullName);
            codeMemberMethod.Parameters.Add(new CodeParameterDeclarationExpression(typeof(BinaryReader), readerParamName));

            CodeTypeReference classTypeReference = new CodeTypeReference(typeInfo.FullName);
            codeMemberMethod.Statements.Add(new CodeVariableDeclarationStatement(
                classTypeReference, messageVariableName,
                new CodeObjectCreateExpression(classTypeReference)));

            AddReadPropertyStatements(codeMemberMethod, message, readerParamName, messageVariableName, ns);

            codeMemberMethod.Statements.Add(new CodeMethodReturnStatement(new CodeVariableReferenceExpression(messageVariableName)));

            return codeMemberMethod;
        }

        #region ReadCodeStatements

        private static void AddReadPropertyStatements(CodeMemberMethod codeMemberMethod, Message message, string readerParamName, string messageVariableName, string ns)
        {
            IEnumerable<MessageField> orderedMessageFields = message.Fields.OrderForSerialization().ToList();

            foreach (MessageField messageField in orderedMessageFields)
            {
                CodePropertyReferenceExpression propertyExpression =
                    new CodePropertyReferenceExpression(
                        new CodeVariableReferenceExpression(messageVariableName),
                        messageField.Name);

                switch (messageField.Type.FieldType)
                {
                    case FieldType.Array:
                        AddArrayReadCodeStatements(codeMemberMethod.Statements, readerParamName, messageField, propertyExpression);
                        break;
                    case FieldType.Enum:
                        string enumFullname = NamespaceHelper.GetFullname(ns, messageField.Type.Enum.Name);
                        AddEnumReadCodeStatements(codeMemberMethod.Statements, readerParamName, messageField.Type, propertyExpression, enumFullname);
                        break;
                    default:
                        AddPrimitiveReadCodeStatements(codeMemberMethod.Statements, readerParamName, messageField, propertyExpression);
                        break;
                }
            }
        }

        private static string GetReadMethodName(MessageFieldDataType dataType)
        {
            switch (dataType)
            {
                case MessageFieldDataType.Float32: return "ReadSingle";
                case MessageFieldDataType.Int8: return "ReadSByte";
                case MessageFieldDataType.UInt8: return "ReadByte";
                case MessageFieldDataType.Int16: return "ReadInt16";
                case MessageFieldDataType.UInt16: return "ReadUInt16";
                case MessageFieldDataType.Int32: return "ReadInt32";
                case MessageFieldDataType.UInt32: return "ReadUInt32";
                case MessageFieldDataType.Int64: return "ReadInt64";
                case MessageFieldDataType.UInt64: return "ReadUInt64";
                case MessageFieldDataType.Char: return "ReadChar";
                case MessageFieldDataType.Double: return "ReadDouble";
                default:
                    return null;
            }
        }

        private static void AddPrimitiveReadCodeStatements(CodeStatementCollection codeStatementCollection, string readerParamName, MessageField messageField, CodePropertyReferenceExpression propertyExpression)
        {
            String readMethodName = GetReadMethodName(messageField.Type.DataType);
            CodeAssignStatement propertyAssignStatement = new CodeAssignStatement(propertyExpression,
                new CodeMethodInvokeExpression(
                    new CodeVariableReferenceExpression(readerParamName), readMethodName));

            codeStatementCollection.Add(propertyAssignStatement);
        }

        private static void AddArrayReadCodeStatements(CodeStatementCollection codeStatementCollection, string readerParamName, MessageField messageField, CodePropertyReferenceExpression propertyExpression)
        {
            String readMethodName = GetReadMethodName(messageField.Type.DataType);
            for (int i = 0; i < messageField.Type.ArrayLength; i++)
            {
                CodeArrayIndexerExpression codeArrayIndexerExpression =
                    new CodeArrayIndexerExpression(propertyExpression, new CodePrimitiveExpression(i));

                CodeAssignStatement propertyAssignStatement = new CodeAssignStatement(codeArrayIndexerExpression,
                    new CodeMethodInvokeExpression(
                        new CodeVariableReferenceExpression(readerParamName), readMethodName));

                codeStatementCollection.Add(propertyAssignStatement);
            }
        }

        private static void AddEnumReadCodeStatements(CodeStatementCollection codeStatementCollection, string readerParamName, MessageFieldType type, CodePropertyReferenceExpression propertyExpression, string enumFullname)
        {
            String readMethodName = GetReadMethodName(type.DataType);

            var codeMethodInvokeExpression = new CodeMethodInvokeExpression(new CodeVariableReferenceExpression(readerParamName), readMethodName);

            CodeAssignStatement propertyAssignStatement = new CodeAssignStatement(propertyExpression,
                new CodeCastExpression(enumFullname, codeMethodInvokeExpression));

            codeStatementCollection.Add(propertyAssignStatement);
        }

        #endregion
    }
}
