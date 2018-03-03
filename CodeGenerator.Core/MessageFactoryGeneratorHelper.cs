using System;
using System.CodeDom;
using System.Collections.Generic;
using MavLink4Net.MessageDefinitions.Data;

namespace MavLink4Net.CodeGenerator.Core
{
    class MessageFactoryGeneratorHelper
    {
        public static CodeCompileUnit CreateCodeCompileUnit(TypeInfo typeInfo, IEnumerable<Message> messages, string messagesNamespace, TypeInfo messageTypeEnumTypeInfo, TypeInfo messageInterfaceTypeInfo)
        {
            CodeCompileUnit codeCompileUnit = new CodeCompileUnit();

            CodeNamespace globalNamespace = new CodeNamespace(String.Empty);
            codeCompileUnit.Namespaces.Add(globalNamespace);

            // Generate the namespace
            CodeNamespace codeNamespace = new CodeNamespace(typeInfo.Namespace);
            codeCompileUnit.Namespaces.Add(codeNamespace);
            
            // Declare the class
            CodeTypeDeclaration classDeclaration = ToCodeTypeDeclaration(typeInfo, messages, messagesNamespace, messageTypeEnumTypeInfo, messageInterfaceTypeInfo);

            // Add class to the namespace
            codeNamespace.Types.Add(classDeclaration);

            return codeCompileUnit;
        }

        private static CodeTypeDeclaration ToCodeTypeDeclaration(TypeInfo typeInfo, IEnumerable<Message> messages, string messagesNamespace, TypeInfo messageTypeEnumTypeInfo, TypeInfo messageInterfaceTypeInfo)
        {
            CodeTypeDeclaration codeTypeDeclaration = new CodeTypeDeclaration()
            {
                Name = typeInfo.Name,
                IsClass = true
            };

            CodeMemberMethod createSerializerCodeMemberMethod = CreateCreateMessageCodeMemberMethod(messages, messagesNamespace, messageTypeEnumTypeInfo, messageInterfaceTypeInfo);
            codeTypeDeclaration.Members.Add(createSerializerCodeMemberMethod);

            return codeTypeDeclaration;
        }

        private static CodeMemberMethod CreateCreateMessageCodeMemberMethod(IEnumerable<Message> messages, string messagesNamespace, TypeInfo messageTypeEnumTypeInfo, TypeInfo messageInterfaceTypeInfo)
        {
            string mavTypeParamName = "mavType";

            CodeMemberMethod codeMemberMethod = new CodeMemberMethod();
            codeMemberMethod.Attributes = MemberAttributes.Public | MemberAttributes.Final | MemberAttributes.Static;
            codeMemberMethod.Name = "CreateMessage";
            codeMemberMethod.ReturnType = new CodeTypeReference(messageInterfaceTypeInfo.Name);
            codeMemberMethod.Parameters.Add(new CodeParameterDeclarationExpression(messageTypeEnumTypeInfo.FullName, mavTypeParamName));

            foreach (Message message in messages)
            {
                string messageClassName = NameHelper.GetMessageClassName(message);
                string messageClassFullname = NamespaceHelper.GetFullname(messagesNamespace, messageClassName);

                CodeBinaryOperatorExpression equalsExpression = new CodeBinaryOperatorExpression(
                    new CodeVariableReferenceExpression(mavTypeParamName),
                    CodeBinaryOperatorType.IdentityEquality,
                    new CodeTypeReferenceExpression(NamespaceHelper.GetFullname(messageTypeEnumTypeInfo.FullName, message.Name)));

                CodeConditionStatement conditionalStatement = new CodeConditionStatement(
                    equalsExpression,
                    new CodeMethodReturnStatement(new CodeObjectCreateExpression(messageClassFullname)));

                codeMemberMethod.Statements.Add(conditionalStatement);
            }

            CodeStatement returnNullCodeStatement = new CodeMethodReturnStatement(new CodeSnippetExpression("null"));
            codeMemberMethod.Statements.Add(returnNullCodeStatement);

            return codeMemberMethod;
        }
    }
}
