using System;
using System.CodeDom;
using System.Collections.Generic;
using MavLink4Net.MessageDefinitions.Data;

namespace MavLink4Net.CodeGenerator.Core
{
    class EnumGeneratorHelper
    {
        public static CodeCompileUnit CreateCodeCompileUnit(MessageDefinitions.Data.Enum enumeration, string ns)
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

            CodeTypeDeclaration enumTypeDeclaration = ToCodeTypeDeclaration(enumeration);

            // Add enum to the namespace
            codeNamespace.Types.Add(enumTypeDeclaration);

            return codeCompileUnit;
        }

        private static CodeTypeDeclaration ToCodeTypeDeclaration(MessageDefinitions.Data.Enum enumeration)
        {
            CodeTypeDeclaration codeTypeDeclaration = new CodeTypeDeclaration()
            {
                Name = enumeration.Name,
                IsEnum = true
            };

            // Add summary comments
            CodeCommentStatement[] summaryCommentStatements = CodeCommentStatementHelper.GetSummaryCodeCommentStatements(enumeration.Description);
            codeTypeDeclaration.Comments.AddRange(summaryCommentStatements);

            // Add remarks comments
            CodeCommentStatement[] remarksCommentStatements = CodeCommentStatementHelper.GetRemarksCodeCommentStatements(enumeration.OriginalName);
            codeTypeDeclaration.Comments.AddRange(remarksCommentStatements);

            // Add values
            foreach (EnumEntry enumEntry in enumeration.Entries)
            {
                CodeMemberField field = ToCodeMemberField(enumEntry);
                codeTypeDeclaration.Members.Add(field);
            }

            return codeTypeDeclaration;
        }

        private static CodeMemberField ToCodeMemberField(EnumEntry enumEntry)
        {
            CodeMemberField field = new CodeMemberField
            {
                Name = enumEntry.Name,
                InitExpression = new CodePrimitiveExpression(enumEntry.Value)
            };

            // Add summary comments
            CodeCommentStatement[] summaryCommentStatements = CodeCommentStatementHelper.GetSummaryCodeCommentStatements(enumEntry.Description);
            field.Comments.AddRange(summaryCommentStatements);

            // Add remarks comments
            CodeCommentStatement[] remarksCommentStatements = CodeCommentStatementHelper.GetRemarksCodeCommentStatements(enumEntry.OriginalName);
            field.Comments.AddRange(remarksCommentStatements);

            // Add description attribute
            CodeAttributeDeclaration descriptionAttributeDeclaration = CreateDescriptionAttributeDeclaration(enumEntry);
            field.CustomAttributes.Add(descriptionAttributeDeclaration);
            return field;
        }

        private static CodeAttributeDeclaration CreateDescriptionAttributeDeclaration(EnumEntry enumEntry)
        {
            CodeAttributeDeclaration codeAttributeDeclaration = new CodeAttributeDeclaration("Description", new CodeAttributeArgument(new CodePrimitiveExpression(enumEntry.Description)));
            return codeAttributeDeclaration;
        }
    }
}
