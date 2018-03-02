using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using MavLink4Net.MessageDefinitions.Data;

namespace MavLink4Net.CodeGenerator.Core
{
    class EnumGeneratorHelper
    {
        public static CodeCompileUnit CreateCodeCompileUnit(TypeInfo typeInfo, MessageDefinitions.Data.Enum enumeration)
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

            if (enumeration.IsNameTransformed)
            {
                // Add remarks comments
                CodeCommentStatement[] remarksCommentStatements = CodeCommentStatementHelper.GetRemarksCodeCommentStatements(enumeration.XmlDefinition.Name);
                codeTypeDeclaration.Comments.AddRange(remarksCommentStatements);
            }

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
            CodeMemberField field = new CodeMemberField();
            field.Name = enumEntry.Name;

            if (enumEntry.Value.HasValue)
                field.InitExpression = new CodePrimitiveExpression(enumEntry.Value);

            string[] lines = GetSummaryCommentLines(enumEntry);

            // Add summary comments
            CodeCommentStatement[] summaryCommentStatements = CodeCommentStatementHelper.GetSummaryCodeCommentStatements(lines);
            field.Comments.AddRange(summaryCommentStatements);

            if (enumEntry.IsNameTransformed)
            {
                // Add remarks comments
                CodeCommentStatement[] remarksCommentStatements = CodeCommentStatementHelper.GetRemarksCodeCommentStatements(enumEntry.XmlDefinition.Name);
                field.Comments.AddRange(remarksCommentStatements);
            }

            // Add description attribute
            CodeAttributeDeclaration descriptionAttributeDeclaration = CreateDescriptionAttributeDeclaration(enumEntry);
            field.CustomAttributes.Add(descriptionAttributeDeclaration);
            return field;
        }

        private static string[] GetSummaryCommentLines(EnumEntry enumEntry)
        {
            IList<String> lines = new List<String>() { enumEntry.Description };

            foreach (EnumEntryParameter entryParameter in enumEntry.Parameters)
                lines.Add($"Mission Param #{entryParameter.Index} : {entryParameter.Description}");

            return lines.ToArray();
        }

        private static CodeAttributeDeclaration CreateDescriptionAttributeDeclaration(EnumEntry enumEntry)
        {
            CodeAttributeDeclaration codeAttributeDeclaration = new CodeAttributeDeclaration("Description", new CodeAttributeArgument(new CodePrimitiveExpression(enumEntry.Description)));
            return codeAttributeDeclaration;
        }
    }
}
