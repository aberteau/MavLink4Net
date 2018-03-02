using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using MavLink4Net.MessageDefinitions.Data;
using MavLink4Net.MessageDefinitions.Mappers;

namespace MavLink4Net.CodeGenerator.Core
{
    class MessageGeneratorHelper
    {
        public static CodeCompileUnit CreateCodeCompileUnit(TypeInfo typeInfo, Message message, TypeInfo messageBaseClassTypeInfo, TypeInfo messageTypeEnumTypeInfo, IDictionary<MessageDefinitions.Data.Enum, TypeInfo> typeInfoByEnum)
        {
            // Generate the container unit
            CodeCompileUnit codeCompileUnit = new CodeCompileUnit();

            CodeNamespace globalNamespace = new CodeNamespace(String.Empty);
            codeCompileUnit.Namespaces.Add(globalNamespace);

            // using
            globalNamespace.Imports.Add(new CodeNamespaceImport("System"));
            globalNamespace.Imports.Add(new CodeNamespaceImport("System.ComponentModel"));
            globalNamespace.Imports.Add(new CodeNamespaceImport("MavLink4Net.Messages.Metadata"));

            // Generate the namespace
            CodeNamespace codeNamespace = new CodeNamespace(typeInfo.Namespace);
            codeCompileUnit.Namespaces.Add(codeNamespace);

            string messageTypeEnumValue = NamespaceHelper.GetFullname(messageTypeEnumTypeInfo.FullName, message.Name);

            // Declare the class
            CodeTypeDeclaration classDeclaration = ToCodeTypeDeclaration(typeInfo, message, messageBaseClassTypeInfo, messageTypeEnumValue, typeInfoByEnum);

            // Add class to the namespace
            codeNamespace.Types.Add(classDeclaration);

            return codeCompileUnit;
        }

        private static CodeTypeDeclaration ToCodeTypeDeclaration(TypeInfo typeInfo, MessageDefinitions.Data.Message message, TypeInfo messageBaseClassTypeInfo, string messageTypeEnumValue, IDictionary<MessageDefinitions.Data.Enum, TypeInfo> typeInfoByEnum)
        {
            CodeTypeDeclaration codeTypeDeclaration = new CodeTypeDeclaration()
            {
                Name = typeInfo.Name,
                IsClass = true
            };

            // Add metadata attribute
            CodeAttributeDeclaration metadataAttributeDeclaration = CreateMessageMetadataAttributeDeclaration(messageTypeEnumValue, message.XmlDefinition.Name, message.Description);
            codeTypeDeclaration.CustomAttributes.Add(metadataAttributeDeclaration);

            codeTypeDeclaration.BaseTypes.Add(messageBaseClassTypeInfo.FullName);
            AddConstructor(codeTypeDeclaration, messageTypeEnumValue, message.CrcExtra);

            // Add summary comments
            CodeCommentStatement[] summaryCommentStatements = CodeCommentStatementHelper.GetSummaryCodeCommentStatements(message.Description);
            codeTypeDeclaration.Comments.AddRange(summaryCommentStatements);

            if (message.IsNameTransformed)
            {
                CodeCommentStatement[] remarksCommentStatements = CodeCommentStatementHelper.GetRemarksCodeCommentStatements(message.XmlDefinition.Name);
                codeTypeDeclaration.Comments.AddRange(remarksCommentStatements);
            }

            // Add fields
            foreach (MessageField messageField in message.Fields)
            {
                CodeMemberField codeMemberField = ToCodeMemberField(messageField, typeInfoByEnum);
                codeTypeDeclaration.Members.Add(codeMemberField);
            }

            // Add properties
            foreach (MessageField messageField in message.Fields)
            {
                CodeMemberProperty codeMemberProperty = ToCodeMemberProperty(messageField, typeInfoByEnum);
                codeTypeDeclaration.Members.Add(codeMemberProperty);
            }

            return codeTypeDeclaration;
        }

        private static CodeAttributeDeclaration CreateMessageMetadataAttributeDeclaration(string messageTypeEnumValue, string name, string description)
        {
            CodeAttributeDeclaration codeAttributeDeclaration = new CodeAttributeDeclaration("MessageMetadata",
                new CodeAttributeArgument("Type", new CodeArgumentReferenceExpression(messageTypeEnumValue)),
                new CodeAttributeArgument("Name", new CodePrimitiveExpression(name)),
                new CodeAttributeArgument("Description", new CodePrimitiveExpression(description)));
            return codeAttributeDeclaration;
        }

        private static void AddConstructor(CodeTypeDeclaration codeTypeDeclaration, string messageTypeEnumValue, byte crc)
        {
            // Declare the constructor
            CodeConstructor constructor = new CodeConstructor();
            constructor.Attributes = MemberAttributes.Public | MemberAttributes.Final;

            constructor.BaseConstructorArgs.Add(new CodeArgumentReferenceExpression(messageTypeEnumValue));
            constructor.BaseConstructorArgs.Add(new CodePrimitiveExpression(crc));

            codeTypeDeclaration.Members.Add(constructor);
        }

        private static CodeMemberField ToCodeMemberField(MessageField messageField, IDictionary<MessageDefinitions.Data.Enum, TypeInfo> typeInfoByEnum)
        {
            CodeMemberField codeMemberField = new CodeMemberField();
            codeMemberField.Attributes = MemberAttributes.Private;
            codeMemberField.Name = GetFieldName(messageField.Name);

            // Type
            Type type = SystemTypeHelper.GetType(messageField.Type.DataType);

            CodeTypeReference codeTypeReference = GetCodeTypeReference(messageField.Type, type, typeInfoByEnum);
            codeMemberField.Type = codeTypeReference;

            if (messageField.Type.FieldType == FieldType.Array)
            {
                CodeArrayCreateExpression arrayCreateExpression = new CodeArrayCreateExpression(type, messageField.Type.ArrayLength);
                codeMemberField.InitExpression = arrayCreateExpression;
            }
                
            // Add summary comments
            CodeCommentStatement[] summaryCommentStatements = CodeCommentStatementHelper.GetSummaryCodeCommentStatements(messageField.Text);
            codeMemberField.Comments.AddRange(summaryCommentStatements);

            CodeCommentStatement[] remarksCommentStatements = CodeCommentStatementHelper.GetRemarksCodeCommentStatements(messageField.XmlDefinition.Name);
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

        private static CodeTypeReference GetCodeTypeReference(MessageFieldType fieldType, Type type, IDictionary<MessageDefinitions.Data.Enum, TypeInfo> typeInfoByEnum)
        {
            if (fieldType.FieldType == FieldType.Enum)
            {
                TypeInfo enumTypeInfo = typeInfoByEnum[fieldType.Enum];
                return new CodeTypeReference(enumTypeInfo.FullName);
            }

            CodeTypeReference codeTypeReference = new CodeTypeReference(type);

            if (fieldType.FieldType == FieldType.Array)
                codeTypeReference.ArrayRank = 1;

            return codeTypeReference;
        }

        private static CodeMemberProperty ToCodeMemberProperty(MessageField messageField, IDictionary<MessageDefinitions.Data.Enum, TypeInfo> typeInfoByEnum)
        {
            CodeMemberProperty codeMemberProperty = new CodeMemberProperty();
            codeMemberProperty.Attributes = MemberAttributes.Public | MemberAttributes.Final;
            codeMemberProperty.Name = messageField.Name;
            codeMemberProperty.HasGet = true;

            // Add metadata attribute
            String rawType = GetRawType(messageField);
            CodeAttributeDeclaration metadataAttributeDeclaration = CreateMessageFieldMetadataAttributeDeclaration(messageField.XmlDefinition.Name, rawType, messageField.Units, messageField.Display, messageField.Text);
            codeMemberProperty.CustomAttributes.Add(metadataAttributeDeclaration);

            // Type
            Type type = SystemTypeHelper.GetType(messageField.Type.DataType);
            CodeTypeReference codeTypeReference = GetCodeTypeReference(messageField.Type, type, typeInfoByEnum);
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

        private static string GetRawType(MessageField messageField)
        {
            if (messageField.Type.FieldType == FieldType.Enum)
            {
                string rawType = TypeHelper.ToEnumRawType(messageField);
                return rawType;
            }

            return messageField.XmlDefinition.Type;
        }

        private static CodeAttributeDeclaration CreateMessageFieldMetadataAttributeDeclaration(string name, string type, string units, string display, string description)
        {
            CodeAttributeDeclaration codeAttributeDeclaration = new CodeAttributeDeclaration("MessageFieldMetadata");

            codeAttributeDeclaration.Arguments.Add(new CodeAttributeArgument("Name", new CodePrimitiveExpression(name)));
            codeAttributeDeclaration.Arguments.Add(new CodeAttributeArgument("Type", new CodePrimitiveExpression(type)));

            if (!String.IsNullOrWhiteSpace(units))
                codeAttributeDeclaration.Arguments.Add(new CodeAttributeArgument("Units", new CodePrimitiveExpression(units)));

            if (!String.IsNullOrWhiteSpace(display))
                codeAttributeDeclaration.Arguments.Add(new CodeAttributeArgument("Display", new CodePrimitiveExpression(display)));

            if (!String.IsNullOrWhiteSpace(description))
                codeAttributeDeclaration.Arguments.Add(new CodeAttributeArgument("Description", new CodePrimitiveExpression(description)));

            return codeAttributeDeclaration;
        }
    }
}
