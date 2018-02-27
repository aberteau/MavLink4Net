using System;
using System.CodeDom;
using System.Collections.Generic;

namespace MavLink4Net.CodeGenerator.Core
{
    class MavTypeEnumGeneratorHelper
    {
        public static CodeCompileUnit CreateCodeCompileUnit(string enumName, IEnumerable<MessageDefinitions.Data.Message> messages, string ns)
        {
            CodeCompileUnit codeCompileUnit = new CodeCompileUnit();

            CodeNamespace globalNamespace = new CodeNamespace(String.Empty);
            codeCompileUnit.Namespaces.Add(globalNamespace);

            // using
            globalNamespace.Imports.Add(new CodeNamespaceImport("System"));
            globalNamespace.Imports.Add(new CodeNamespaceImport("System.ComponentModel"));

            // Generate the namespace
            CodeNamespace codeNamespace = new CodeNamespace(ns);
            codeCompileUnit.Namespaces.Add(codeNamespace);

            CodeTypeDeclaration enumTypeDeclaration = ToCodeTypeDeclaration(enumName, messages);

            // Add enum to the namespace
            codeNamespace.Types.Add(enumTypeDeclaration);

            return codeCompileUnit;
        }

        private static CodeTypeDeclaration ToCodeTypeDeclaration(string enumName, IEnumerable<MessageDefinitions.Data.Message> messages)
        {
            CodeTypeDeclaration codeTypeDeclaration = new CodeTypeDeclaration()
            {
                Name = enumName,
                IsEnum = true
            };

            codeTypeDeclaration.BaseTypes.Add(typeof(byte));

            // Add values
            foreach (MessageDefinitions.Data.Message message in messages)
            {
                CodeMemberField field = ToCodeMemberField(message);
                codeTypeDeclaration.Members.Add(field);
            }

            return codeTypeDeclaration;
        }

        private static CodeMemberField ToCodeMemberField(MessageDefinitions.Data.Message message)
        {
            CodeMemberField field = new CodeMemberField
            {
                Name = message.Name,
                InitExpression = new CodePrimitiveExpression(message.Id)
            };

            // Add summary comments
            CodeCommentStatement[] summaryCommentStatements = CodeCommentStatementHelper.GetSummaryCodeCommentStatements(message.Description);
            field.Comments.AddRange(summaryCommentStatements);

            // Add remarks comments
            CodeCommentStatement[] remarksCommentStatements = CodeCommentStatementHelper.GetRemarksCodeCommentStatements(message.OriginalName);
            field.Comments.AddRange(remarksCommentStatements);

            // Add description attribute
            CodeAttributeDeclaration descriptionAttributeDeclaration = CreateDescriptionAttributeDeclaration(message);
            field.CustomAttributes.Add(descriptionAttributeDeclaration);
            return field;
        }

        private static CodeAttributeDeclaration CreateDescriptionAttributeDeclaration(MessageDefinitions.Data.Message message)
        {
            CodeAttributeDeclaration codeAttributeDeclaration = new CodeAttributeDeclaration("Description", new CodeAttributeArgument(new CodePrimitiveExpression(message.Description)));
            return codeAttributeDeclaration;
        }
    }
}
