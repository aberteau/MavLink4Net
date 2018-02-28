using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using MavLink4Net.CodeGenerator.Core.Translations;
using MavLink4Net.MessageDefinitions.Data;
using Microsoft.CSharp;

namespace MavLink4Net.CodeGenerator.Core
{
    public class GeneratorHelper
    {
        public static void Generate(MavLink mavLink, string language, string outputPath, string ns, string messageBaseClassName, string commonName, string mavMessageTypeEnumName, string serializationNamespace, string serializationOutputPath, string serializerInterfaceName, string serializerFactoryClassName, MavLinkTranslationMap translationMap = null)
        {
            CodeGeneratorOptions options = new CodeGeneratorOptions() { BracingStyle = "C" };
            CodeDomProvider codeProvider = CreateCodeDomProvider(language);

            GenerateMessageTypeEnum(outputPath, mavLink.Messages, options, codeProvider, ns, mavMessageTypeEnumName, translationMap);

            string commonNamespace = NamespaceHelper.GetNamespace(ns, commonName);
            string commonPath = Path.Combine(outputPath, commonName);

            GenerateEnumFiles(commonPath, mavLink.Enums, options, codeProvider, commonNamespace, translationMap);

            string messageBaseClassFullName = NamespaceHelper.GetFullname(ns, messageBaseClassName);
            string messageTypeEnumFullName = NamespaceHelper.GetFullname(ns, mavMessageTypeEnumName);
            GenerateMessageClassFiles(commonPath, mavLink.Messages, options, codeProvider, commonNamespace, messageBaseClassFullName, messageTypeEnumFullName, translationMap);

            string serializerCommonOutputPath = Path.Combine(serializationOutputPath, commonName);
            string serializationCommonNamespace = NamespaceHelper.GetNamespace(serializationNamespace, commonName);

            string serializerInterfaceFullname = NamespaceHelper.GetFullname(serializationNamespace, serializerInterfaceName);
            GenerateSerializerClassFiles(serializerCommonOutputPath, mavLink.Messages, options, codeProvider, serializationCommonNamespace, serializerInterfaceFullname, messageBaseClassFullName);

            GenerateSerializerFactory(serializationOutputPath, mavLink.Messages, options, codeProvider, serializationNamespace, serializerFactoryClassName, serializationCommonNamespace, messageTypeEnumFullName, serializerInterfaceName);
        }

        private static CodeDomProvider CreateCodeDomProvider(string language)
        {
            //TODO: A compléter (Prise en charge VB.Net)
            return new CSharpCodeProvider();
        }

        #region MessageType

        private static void GenerateMessageTypeEnum(string outputPath, IEnumerable<Message> messages, CodeGeneratorOptions options, CodeDomProvider codeProvider, string ns, string className, MavLinkTranslationMap translationMap)
        {
            string filename = $"{className}.cs";
            String filePath = Path.Combine(outputPath, filename);
            CodeCompileUnit unit = MavTypeEnumGeneratorHelper.CreateCodeCompileUnit(className, messages, ns, translationMap);
            codeProvider.GenerateCodeFromCompileUnit(unit, options, filePath);
        }

        #endregion

        #region Message

        private static void GenerateMessageClassFiles(string folderPath, IEnumerable<Message> messages, CodeGeneratorOptions options, CodeDomProvider codeProvider, string ns, string baseClassName, string messageTypeEnumFullName, MavLinkTranslationMap translationMap)
        {
            foreach (MessageDefinitions.Data.Message message in messages)
            {
                string messageTypeEnumValue = NamespaceHelper.GetFullname(messageTypeEnumFullName, message.Name);
                GenerateMessageClassFile(folderPath, message, options, codeProvider, ns, baseClassName, messageTypeEnumValue, translationMap);
            }
        }

        private static void GenerateMessageClassFile(string folderPath, MessageDefinitions.Data.Message message, CodeGeneratorOptions options, CodeDomProvider codeProvider, string ns, string baseClassName, string messageTypeEnumValue, MavLinkTranslationMap translationMap)
        {
            string messageName = NameHelper.GetMessageClassName(message);
            string filename = $"{messageName}.cs";
            String filePath = Path.Combine(folderPath, filename);
            CodeCompileUnit unit = MessageGeneratorHelper.CreateCodeCompileUnit(message, messageName, ns, baseClassName, messageTypeEnumValue, translationMap);
            codeProvider.GenerateCodeFromCompileUnit(unit, options, filePath);
        }

        #endregion

        #region Enum

        private static void GenerateEnumFiles(string folderPath, IEnumerable<MessageDefinitions.Data.Enum> enums, CodeGeneratorOptions options, CodeDomProvider codeProvider, string ns, MavLinkTranslationMap translationMap)
        {
            foreach (MessageDefinitions.Data.Enum enumeration in enums)
            {
                MessageDefinitions.Data.Enum originalEnum = null;
                if (translationMap != null && translationMap.EnumMap.ContainsKey(enumeration))
                    originalEnum = translationMap.EnumMap[enumeration];

                GenerateEnumFile(folderPath, enumeration, options, codeProvider, ns, translationMap);
            }
        }

        private static void GenerateEnumFile(string folderPath, MessageDefinitions.Data.Enum enumeration, CodeGeneratorOptions options, CodeDomProvider codeProvider, string ns, MavLinkTranslationMap translationMap)
        {
            string enumerationName = enumeration.Name;
            string filename = $"{enumerationName}.cs";
            String filePath = Path.Combine(folderPath, filename);
            CodeCompileUnit unit = EnumGeneratorHelper.CreateCodeCompileUnit(enumeration, ns, translationMap);
            codeProvider.GenerateCodeFromCompileUnit(unit, options, filePath);
        }

        #endregion

        #region Serializer

        private static void GenerateSerializerClassFiles(string folderPath, IEnumerable<MessageDefinitions.Data.Message> messages, CodeGeneratorOptions options, CodeDomProvider codeProvider, string ns, string interfaceName, string messageBaseClassName)
        {
            foreach (MessageDefinitions.Data.Message message in messages)
            {
                GenerateSerializerClassFile(folderPath, message, options, codeProvider, ns, interfaceName, messageBaseClassName);
            }
        }

        private static void GenerateSerializerClassFile(string folderPath, Message message, CodeGeneratorOptions options, CodeDomProvider codeProvider, string ns, string baseClassName, string messageBaseClassName)
        {
            string serializerClassName = NameHelper.GetSerializerClassName(message);
            string filename = $"{serializerClassName}.cs";
            String filePath = Path.Combine(folderPath, filename);
            CodeCompileUnit unit = SerializerGeneratorHelper.CreateCodeCompileUnit(message, serializerClassName, ns, baseClassName, messageBaseClassName);
            codeProvider.GenerateCodeFromCompileUnit(unit, options, filePath);
        }

        #endregion

        #region SerializerFactory

        private static void GenerateSerializerFactory(string outputPath, IEnumerable<Message> messages, CodeGeneratorOptions options, CodeDomProvider codeProvider, string ns, string className, string serializerNamespace, string messageTypeEnumFullName, string serializerInterfaceName)
        {
            string filename = $"{className}.cs";
            String filePath = Path.Combine(outputPath, filename);
            CodeCompileUnit unit = SerializerFactoryGeneratorHelper.CreateCodeCompileUnit(className, messages, ns, serializerNamespace, messageTypeEnumFullName, serializerInterfaceName);
            codeProvider.GenerateCodeFromCompileUnit(unit, options, filePath);
        }

        #endregion
    }
}
