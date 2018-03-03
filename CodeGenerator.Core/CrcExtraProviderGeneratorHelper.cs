using System;
using System.CodeDom;
using System.Collections.Generic;
using MavLink4Net.MessageDefinitions.Data;

namespace MavLink4Net.CodeGenerator.Core
{
    class CrcExtraProviderGeneratorHelper
    {
        public static CodeCompileUnit CreateCodeCompileUnit(TypeInfo typeInfo, IEnumerable<Message> messages, TypeInfo messageTypeEnumTypeInfo)
        {
            CodeCompileUnit codeCompileUnit = new CodeCompileUnit();

            CodeNamespace globalNamespace = new CodeNamespace(String.Empty);
            codeCompileUnit.Namespaces.Add(globalNamespace);

            globalNamespace.Imports.Add(new CodeNamespaceImport("System"));

            // Generate the namespace
            CodeNamespace codeNamespace = new CodeNamespace(typeInfo.Namespace);
            codeCompileUnit.Namespaces.Add(codeNamespace);
            
            // Declare the class
            CodeTypeDeclaration classDeclaration = ToCodeTypeDeclaration(typeInfo, messages, messageTypeEnumTypeInfo);

            // Add class to the namespace
            codeNamespace.Types.Add(classDeclaration);

            return codeCompileUnit;
        }

        private static CodeTypeDeclaration ToCodeTypeDeclaration(TypeInfo typeInfo, IEnumerable<Message> messages, TypeInfo messageTypeEnumTypeInfo)
        {
            CodeTypeDeclaration codeTypeDeclaration = new CodeTypeDeclaration()
            {
                Name = typeInfo.Name,
                IsClass = true
            };

            CodeMemberMethod createSerializerCodeMemberMethod = CreateGetCrcExtraCodeMemberMethod(messages, messageTypeEnumTypeInfo);
            codeTypeDeclaration.Members.Add(createSerializerCodeMemberMethod);

            return codeTypeDeclaration;
        }

        private static CodeMemberMethod CreateGetCrcExtraCodeMemberMethod(IEnumerable<Message> messages, TypeInfo messageTypeEnumTypeInfo)
        {
            string mavTypeParamName = "mavType";

            CodeMemberMethod codeMemberMethod = new CodeMemberMethod();
            codeMemberMethod.Attributes = MemberAttributes.Public | MemberAttributes.Final | MemberAttributes.Static;
            codeMemberMethod.Name = "GetCrcExtra";
            codeMemberMethod.ReturnType = new CodeTypeReference(typeof(byte));
            codeMemberMethod.Parameters.Add(new CodeParameterDeclarationExpression(messageTypeEnumTypeInfo.FullName, mavTypeParamName));

            foreach (Message message in messages)
            {
                CodeBinaryOperatorExpression equalsExpression = new CodeBinaryOperatorExpression(
                    new CodeVariableReferenceExpression(mavTypeParamName),
                    CodeBinaryOperatorType.IdentityEquality,
                    new CodeTypeReferenceExpression(NamespaceHelper.GetFullname(messageTypeEnumTypeInfo.FullName, message.Name)));

                CodeConditionStatement conditionalStatement = new CodeConditionStatement(
                    equalsExpression,
                    new CodeMethodReturnStatement(new CodePrimitiveExpression(message.CrcExtra)));

                codeMemberMethod.Statements.Add(conditionalStatement);
            }

            CodeStatement returnNullCodeStatement = new CodeMethodReturnStatement(new CodeSnippetExpression("Byte.MinValue"));
            codeMemberMethod.Statements.Add(returnNullCodeStatement);

            return codeMemberMethod;
        }
    }
}
