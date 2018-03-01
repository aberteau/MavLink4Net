using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using MavLink4Net.CodeGenerator.Core.Translations;
using MavLink4Net.MessageDefinitions.Data;

namespace MavLink4Net.CodeGenerator.Core
{
    class SerializerFactoryGeneratorHelper
    {
        public static CodeCompileUnit CreateCodeCompileUnit(TypeInfo typeInfo, IEnumerable<Message> messages, string serializersNamespace, TypeInfo messageTypeEnumTypeInfo, TypeInfo serializerInterfaceTypeInfo)
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
            
            // Declare the class
            CodeTypeDeclaration classDeclaration = ToCodeTypeDeclaration(typeInfo, messages, serializersNamespace, messageTypeEnumTypeInfo, serializerInterfaceTypeInfo);

            // Add class to the namespace
            codeNamespace.Types.Add(classDeclaration);

            return codeCompileUnit;
        }

        private static CodeTypeDeclaration ToCodeTypeDeclaration(TypeInfo typeInfo, IEnumerable<Message> messages, string serializersNamespace, TypeInfo messageTypeEnumTypeInfo, TypeInfo serializerInterfaceTypeInfo)
        {
            CodeTypeDeclaration codeTypeDeclaration = new CodeTypeDeclaration()
            {
                Name = typeInfo.Name,
                IsClass = true
            };

            CodeMemberMethod createSerializerCodeMemberMethod = CreateSerializeCodeMemberMethod(messages, serializersNamespace, messageTypeEnumTypeInfo, serializerInterfaceTypeInfo);
            codeTypeDeclaration.Members.Add(createSerializerCodeMemberMethod);

            return codeTypeDeclaration;
        }

        private static CodeMemberMethod CreateSerializeCodeMemberMethod(IEnumerable<Message> messages, string serializersNamespace, TypeInfo messageTypeEnumTypeInfo, TypeInfo serializerInterfaceTypeInfo)
        {
            string mavTypeParamName = "mavType";

            CodeMemberMethod codeMemberMethod = new CodeMemberMethod();
            codeMemberMethod.Attributes = MemberAttributes.Public | MemberAttributes.Final | MemberAttributes.Static;
            codeMemberMethod.Name = "CreateSerializer";
            codeMemberMethod.ReturnType = new CodeTypeReference(serializerInterfaceTypeInfo.Name);
            codeMemberMethod.Parameters.Add(new CodeParameterDeclarationExpression(messageTypeEnumTypeInfo.FullName, mavTypeParamName));

            foreach (Message message in messages)
            {
                string serializerClassName = NameHelper.GetSerializerClassName(message);
                string serializerClassFullname = NamespaceHelper.GetFullname(serializersNamespace, serializerClassName);

                CodeBinaryOperatorExpression equalsExpression = new CodeBinaryOperatorExpression(
                    new CodeVariableReferenceExpression(mavTypeParamName),
                    CodeBinaryOperatorType.IdentityEquality,
                    new CodeTypeReferenceExpression(NamespaceHelper.GetFullname(messageTypeEnumTypeInfo.FullName, message.Name)));

                CodeConditionStatement conditionalStatement = new CodeConditionStatement(
                    equalsExpression,
                    new CodeMethodReturnStatement(new CodeObjectCreateExpression(serializerClassFullname)));

                codeMemberMethod.Statements.Add(conditionalStatement);
            }

            CodeStatement returnNullCodeStatement = new CodeMethodReturnStatement(new CodeSnippetExpression("null"));
            codeMemberMethod.Statements.Add(returnNullCodeStatement);

            return codeMemberMethod;
        }
    }
}
