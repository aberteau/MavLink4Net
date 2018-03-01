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
        public static void Generate(MavLink mavLink, string language, string messageTypeOutputPath, TypeInfo messageTypeTypeInfo, string serializerFactoryOutputPath, TypeInfo serializerInterfaceTypeInfo, TypeInfo serializerFactoryClassTypeInfo, string messagesCommonNamespace, string messagesOutputPath, TypeInfo messageBaseClassTypeInfo, TypeInfo messageTypeEnumTypeInfo, string serializersOutputPath, string serializationCommonNamespace, TranslationMap translationMap = null)
        {
            CodeGeneratorOptions options = new CodeGeneratorOptions() { BracingStyle = "C" };
            CodeDomProvider codeProvider = CreateCodeDomProvider(language);

            GenerateMessageTypeEnum(codeProvider, options, messageTypeTypeInfo, messageTypeOutputPath, mavLink.Messages, translationMap);

            GenerateEnumFiles(messagesOutputPath, mavLink.Enums, options, codeProvider, messagesCommonNamespace, translationMap);

            GenerateMessageClassFiles(messagesOutputPath, mavLink.Messages, options, codeProvider, messagesCommonNamespace, messageBaseClassTypeInfo, messageTypeEnumTypeInfo, translationMap);

            GenerateSerializerClassFiles(serializersOutputPath, mavLink.Messages, options, codeProvider, serializationCommonNamespace, serializerInterfaceTypeInfo, messageBaseClassTypeInfo, messagesCommonNamespace);

            GenerateSerializerFactory(serializerFactoryOutputPath, mavLink.Messages, options, codeProvider, serializerFactoryClassTypeInfo, serializationCommonNamespace, messageTypeEnumTypeInfo, serializerInterfaceTypeInfo);
        }

        private static CodeDomProvider CreateCodeDomProvider(string language)
        {
            //TODO: A compléter (Prise en charge VB.Net)
            return new CSharpCodeProvider();
        }

        #region MessageType

        private static void GenerateMessageTypeEnum(CodeDomProvider codeProvider, CodeGeneratorOptions options, TypeInfo typeInfo, string outputPath, IEnumerable<Message> messages, TranslationMap translationMap)
        {
            string filename = TypeInfoHelper.GetFilename(typeInfo);
            String filePath = Path.Combine(outputPath, filename);
            CodeCompileUnit unit = MavTypeEnumGeneratorHelper.CreateCodeCompileUnit(typeInfo, messages, translationMap);
            codeProvider.GenerateCodeFromCompileUnit(unit, options, filePath);
        }

        #endregion

        #region Message

        private static void GenerateMessageClassFiles(string folderPath, IEnumerable<Message> messages, CodeGeneratorOptions options, CodeDomProvider codeProvider, string ns, TypeInfo messageBaseClassName, TypeInfo messageTypeEnumTypeInfo, TranslationMap translationMap)
        {
            foreach (MessageDefinitions.Data.Message message in messages)
            {
                GenerateMessageClassFile(folderPath, message, options, codeProvider, ns, messageBaseClassName, messageTypeEnumTypeInfo, translationMap);
            }
        }

        private static void GenerateMessageClassFile(string folderPath, MessageDefinitions.Data.Message message, CodeGeneratorOptions options, CodeDomProvider codeProvider, string ns, TypeInfo messageBaseClassTypeInfo, TypeInfo messageTypeEnumTypeInfo, TranslationMap translationMap)
        {
            TypeInfo typeInfo = TypeInfoHelper.GetTypeInfo(ns, message);
            string filename = TypeInfoHelper.GetFilename(typeInfo);
            String filePath = Path.Combine(folderPath, filename);
            CodeCompileUnit unit = MessageGeneratorHelper.CreateCodeCompileUnit(typeInfo, message, messageBaseClassTypeInfo, messageTypeEnumTypeInfo, translationMap);
            codeProvider.GenerateCodeFromCompileUnit(unit, options, filePath);
        }

        #endregion

        #region Enum

        private static void GenerateEnumFiles(string folderPath, IEnumerable<MessageDefinitions.Data.Enum> enums, CodeGeneratorOptions options, CodeDomProvider codeProvider, string ns, TranslationMap translationMap)
        {
            foreach (MessageDefinitions.Data.Enum enumeration in enums)
            {
                MessageDefinitions.Data.Enum originalEnum = null;
                if (translationMap != null && translationMap.EnumMap.ContainsKey(enumeration))
                    originalEnum = translationMap.EnumMap[enumeration];

                GenerateEnumFile(folderPath, enumeration, options, codeProvider, ns, translationMap);
            }
        }

        private static void GenerateEnumFile(string folderPath, MessageDefinitions.Data.Enum enumeration, CodeGeneratorOptions options, CodeDomProvider codeProvider, string ns, TranslationMap translationMap)
        {
            string enumerationName = enumeration.Name;

            TypeInfo typeInfo = new TypeInfo()
            {
                Name = enumerationName,
                Namespace = ns
            };

            string filename = TypeInfoHelper.GetFilename(typeInfo);
            String filePath = Path.Combine(folderPath, filename);
            CodeCompileUnit unit = EnumGeneratorHelper.CreateCodeCompileUnit(typeInfo, enumeration, translationMap);
            codeProvider.GenerateCodeFromCompileUnit(unit, options, filePath);
        }

        #endregion

        #region Serializer

        private static void GenerateSerializerClassFiles(string folderPath, IEnumerable<MessageDefinitions.Data.Message> messages, CodeGeneratorOptions options, CodeDomProvider codeProvider, string ns, TypeInfo serializerInterfaceTypeInfo, TypeInfo messageBaseClassName, String messagesNamespace)
        {
            foreach (MessageDefinitions.Data.Message message in messages)
            {
                GenerateSerializerClassFile(folderPath, message, options, codeProvider, ns, serializerInterfaceTypeInfo, messageBaseClassName, messagesNamespace);
            }
        }

        private static void GenerateSerializerClassFile(string folderPath, Message message, CodeGeneratorOptions options, CodeDomProvider codeProvider, string ns, TypeInfo serializerInterfaceTypeInfo, TypeInfo messageBaseClassTypeInfo, String messagesNamespace)
        {
            string serializerClassName = NameHelper.GetSerializerClassName(message);

            TypeInfo typeInfo = new TypeInfo()
            {
                Name = serializerClassName,
                Namespace = ns
            };

            string filename = TypeInfoHelper.GetFilename(typeInfo);
            String filePath = Path.Combine(folderPath, filename);
            CodeCompileUnit unit = SerializerGeneratorHelper.CreateCodeCompileUnit(typeInfo, message, serializerInterfaceTypeInfo, messageBaseClassTypeInfo, messagesNamespace);
            codeProvider.GenerateCodeFromCompileUnit(unit, options, filePath);
        }

        #endregion

        #region SerializerFactory

        private static void GenerateSerializerFactory(string outputPath, IEnumerable<Message> messages, CodeGeneratorOptions options, CodeDomProvider codeProvider, TypeInfo serializerFactoryClassTypeInfo, string serializerNamespace, TypeInfo messageTypeEnumTypeInfo, TypeInfo serializerInterfaceTypeInfo)
        {
            string filename = TypeInfoHelper.GetFilename(serializerFactoryClassTypeInfo);
            String filePath = Path.Combine(outputPath, filename);
            CodeCompileUnit unit = SerializerFactoryGeneratorHelper.CreateCodeCompileUnit(serializerFactoryClassTypeInfo, messages, serializerNamespace, messageTypeEnumTypeInfo, serializerInterfaceTypeInfo);
            codeProvider.GenerateCodeFromCompileUnit(unit, options, filePath);
        }

        #endregion
    }
}
