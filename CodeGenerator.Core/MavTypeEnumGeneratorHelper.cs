using System;
using System.CodeDom;
using System.Collections.Generic;
using MavLink4Net.CodeGenerator.Core.Translations;

namespace MavLink4Net.CodeGenerator.Core
{
    class MavTypeEnumGeneratorHelper
    {
        public static CodeCompileUnit CreateCodeCompileUnit(TypeInfo typeInfo, IEnumerable<MessageDefinitions.Data.Message> messages, TranslationMap translationMap)
        {
            CodeCompileUnit codeCompileUnit = new CodeCompileUnit();

            CodeNamespace globalNamespace = new CodeNamespace(String.Empty);
            codeCompileUnit.Namespaces.Add(globalNamespace);

            // using
            globalNamespace.Imports.Add(new CodeNamespaceImport("System"));
            globalNamespace.Imports.Add(new CodeNamespaceImport("System.ComponentModel"));

            // Generate the namespace
            CodeNamespace codeNamespace = new CodeNamespace(typeInfo.Namespace);
            codeCompileUnit.Namespaces.Add(codeNamespace);

            CodeTypeDeclaration enumTypeDeclaration = ToCodeTypeDeclaration(typeInfo.Name, messages, translationMap);

            // Add enum to the namespace
            codeNamespace.Types.Add(enumTypeDeclaration);

            return codeCompileUnit;
        }

        private static CodeTypeDeclaration ToCodeTypeDeclaration(string enumName, IEnumerable<MessageDefinitions.Data.Message> messages, TranslationMap translationMap)
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
                CodeMemberField field = ToCodeMemberField(message, translationMap);
                codeTypeDeclaration.Members.Add(field);
            }

            return codeTypeDeclaration;
        }

        private static CodeMemberField ToCodeMemberField(MessageDefinitions.Data.Message message, TranslationMap translationMap)
        {
            CodeMemberField field = new CodeMemberField
            {
                Name = message.Name,
                InitExpression = new CodePrimitiveExpression(message.Id)
            };

            // Add summary comments
            CodeCommentStatement[] summaryCommentStatements = CodeCommentStatementHelper.GetSummaryCodeCommentStatements(message.Description);
            field.Comments.AddRange(summaryCommentStatements);

            if (translationMap?.MessageMap != null && translationMap.MessageMap.ContainsKey(message))
            {
                // Add remarks comments
                string originalName = translationMap.MessageMap[message].Name;
                CodeCommentStatement[] remarksCommentStatements = CodeCommentStatementHelper.GetRemarksCodeCommentStatements(originalName);
                field.Comments.AddRange(remarksCommentStatements);
            }

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
