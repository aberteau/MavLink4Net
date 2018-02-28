using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MavLink4Net.MessageDefinitions;
using MavLink4Net.MessageDefinitions.Data;
using MavLink4Net.MessageDefinitions.Mappers;

namespace MavLink4Net.CodeGenerator.Core
{
    class MessageGeneratorHelper
    {
        public static CodeCompileUnit CreateCodeCompileUnit(MessageDefinitions.Data.Message message, string className, string ns, string baseClassName, string messageIdValue)
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
            CodeTypeDeclaration classDeclaration = ToCodeTypeDeclaration(message, className, baseClassName, messageIdValue);

            // Add class to the namespace
            codeNamespace.Types.Add(classDeclaration);

            return codeCompileUnit;
        }

        private static CodeTypeDeclaration ToCodeTypeDeclaration(MessageDefinitions.Data.Message message, string className, string baseClassName, string messageIdValue)
        {
            CodeTypeDeclaration codeTypeDeclaration = new CodeTypeDeclaration()
            {
                Name = className,
                IsClass = true
            };

            codeTypeDeclaration.BaseTypes.Add(baseClassName);

            AddConstructor(codeTypeDeclaration, messageIdValue);

            // Add summary comments
            CodeCommentStatement[] summaryCommentStatements = CodeCommentStatementHelper.GetSummaryCodeCommentStatements(message.Description);
            codeTypeDeclaration.Comments.AddRange(summaryCommentStatements);

            // Add remarks comments
            CodeCommentStatement[] remarksCommentStatements = CodeCommentStatementHelper.GetRemarksCodeCommentStatements(message.OriginalName);
            codeTypeDeclaration.Comments.AddRange(remarksCommentStatements);

            // Add fields
            foreach (MessageField messageField in message.Fields)
            {
                CodeMemberField codeMemberField = ToCodeMemberField(messageField);
                codeTypeDeclaration.Members.Add(codeMemberField);
            }

            // Add properties
            foreach (MessageField messageField in message.Fields)
            {
                CodeMemberProperty codeMemberProperty = ToCodeMemberProperty(messageField);
                codeTypeDeclaration.Members.Add(codeMemberProperty);
            }

            return codeTypeDeclaration;
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
            Type type = SystemTypeHelper.GetType(messageField.Type.PrimitiveType);
            CodeTypeReference codeTypeReference = GetCodeTypeReference(messageField.Type, type);
            codeMemberField.Type = codeTypeReference;

            if (messageField.Type.IsArray)
            {
                CodeArrayCreateExpression arrayCreateExpression = new CodeArrayCreateExpression(type, messageField.Type.ArrayLength);
                codeMemberField.InitExpression = arrayCreateExpression;
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
            CodeTypeReference codeTypeReference = GetCodeTypeReference(fieldType, SystemTypeHelper.GetType(fieldType.PrimitiveType));
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
