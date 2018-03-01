﻿using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using MavLink4Net.CodeGenerator.Core.Params;
using MavLink4Net.CodeGenerator.Core.Translations;
using MavLink4Net.MessageDefinitions;
using MavLink4Net.MessageDefinitions.Data;
using MavLink4Net.MessageDefinitions.Mappers;
using Microsoft.CSharp;

namespace MavLink4Net.CodeGenerator.Core
{
    public class GeneratorHelper
    {
        private static TranslationResult LoadMavLink(string messageDefinitionPath)
        {
            MessageDefinitions.Data.MavLink mavLink = DataProvider.LoadMavLink(messageDefinitionPath);

            DefaultTranslation dTranslation = new DefaultTranslation(EnumValuePrefixRemovalStrategy.RemoveLongestCommonString);

            Translator translator = new Translator(dTranslation, dTranslation, dTranslation, dTranslation, dTranslation);
            TranslationResult translationResult = translator.Translate(mavLink);
            return translationResult;
        }

        public static void GenerateFiles(string messageDefinitionPath, string outputPath, string language)
        {
            TranslationResult result = LoadMavLink(messageDefinitionPath);
            GenerateFiles(messageDefinitionPath, outputPath, language, result);
        }

        public static void GenerateFiles(string messageDefinitionPath, string outputPath, string language, TranslationResult result)
        {
            GenerateFiles(messageDefinitionPath, outputPath, language, result.MavLink, result.TranslationMap);
        }

        public static void GenerateFiles(string messageDefinitionPath, string outputPath, string language, MavLink mavLink, TranslationMap translationMap)
        {
            String messagesPath = Path.Combine(outputPath, ConstantHelper.MessagesFolderName);
            string serializationOutputPath = Path.Combine(outputPath, ConstantHelper.MessagesSerializationFolderName);
            string messagesCommonPath = Path.Combine(messagesPath, ConstantHelper.CommonName);
            string serializerCommonOutputPath = Path.Combine(serializationOutputPath, ConstantHelper.CommonName);

            TypeInfo messageBaseClassTypeInfo = TypeInfoHelper.GetMessageTypeInfo();
            TypeInfo messageTypeEnumTypeInfo = TypeInfoHelper.GetMavMessageTypeTypeInfo();
            TypeInfo serializerInterfaceTypeInfo = TypeInfoHelper.GetSerializerInterfaceTypeInfo();
            TypeInfo serializerFactoryClassTypeInfo = TypeInfoHelper.GetSerializerFactoryTypeInfo();

            CodeGeneratorOptions options = new CodeGeneratorOptions() { BracingStyle = "C" };
            CodeDomProvider codeProvider = CreateCodeDomProvider(language);

            GenerateMessageTypeEnum(codeProvider, options, messageTypeEnumTypeInfo, messagesPath, mavLink.Messages, translationMap);

            GenerateEnumFiles(codeProvider, options, messagesCommonPath, mavLink.Enums, translationMap);

            GenerateMessageClassFiles(codeProvider, options, messagesCommonPath, messageBaseClassTypeInfo, messageTypeEnumTypeInfo, mavLink.Messages, translationMap);

            GenerateSerializerClassFiles(codeProvider, options, serializerCommonOutputPath, mavLink.Messages, serializerInterfaceTypeInfo, messageBaseClassTypeInfo);

            GenerateSerializerFactory(codeProvider, options, serializerFactoryClassTypeInfo, mavLink.Messages, serializationOutputPath, messageTypeEnumTypeInfo, serializerInterfaceTypeInfo);
        }

        private static CodeDomProvider CreateCodeDomProvider(string language)
        {
            //TODO: A compléter (Prise en charge VB.Net)
            return new CSharpCodeProvider();
        }

        #region MessageType

        private static void GenerateMessageTypeEnum(CodeDomProvider codeProvider, CodeGeneratorOptions options, TypeInfo messageTypeEnumTypeInfo, string outputPath, IEnumerable<Message> messages, TranslationMap translationMap)
        {
            MessageTypeEnumGenerationParams typeEnumGenerationParams = new MessageTypeEnumGenerationParams();
            string messageTypeEnumFilename = TypeInfoHelper.GetFilename(messageTypeEnumTypeInfo);
            typeEnumGenerationParams.OutputFilePath = Path.Combine(outputPath, messageTypeEnumFilename);
            typeEnumGenerationParams.TypeInfo = messageTypeEnumTypeInfo;

            GenerateMessageTypeEnum(codeProvider, options, typeEnumGenerationParams, messages, translationMap);
        }

        private static void GenerateMessageTypeEnum(CodeDomProvider codeProvider, CodeGeneratorOptions options, MessageTypeEnumGenerationParams typeEnumGenerationParams, IEnumerable<Message> messages, TranslationMap translationMap)
        {
            CodeCompileUnit unit = MavTypeEnumGeneratorHelper.CreateCodeCompileUnit(typeEnumGenerationParams.TypeInfo, messages, translationMap);
            codeProvider.GenerateCodeFromCompileUnit(unit, options, typeEnumGenerationParams.OutputFilePath);
        }

        #endregion

        #region Message

        private static void GenerateMessageClassFiles(CodeDomProvider codeProvider, CodeGeneratorOptions options, string outputPath, TypeInfo messageBaseClassTypeInfo, TypeInfo messageTypeEnumTypeInfo, IEnumerable<Message> messages, TranslationMap translationMap)
        {
            MessageGenerationParams messageGenerationParams = new MessageGenerationParams();
            messageGenerationParams.OutputPath = outputPath;
            messageGenerationParams.BaseClassTypeInfo = messageBaseClassTypeInfo;
            messageGenerationParams.MessageTypeEnumTypeInfo = messageTypeEnumTypeInfo;
            messageGenerationParams.Namespace = ConstantHelper.Namespaces.Root_Messages_Common;

            GenerateMessageClassFiles(codeProvider, options, messageGenerationParams, messages, translationMap);
        }

        private static void GenerateMessageClassFiles(CodeDomProvider codeProvider, CodeGeneratorOptions options, MessageGenerationParams pParams, IEnumerable<Message> messages, TranslationMap translationMap)
        {
            foreach (MessageDefinitions.Data.Message message in messages)
            {
                GenerateMessageClassFile(pParams, message, options, codeProvider, translationMap);
            }
        }

        private static void GenerateMessageClassFile(MessageGenerationParams pParams, MessageDefinitions.Data.Message message, CodeGeneratorOptions options, CodeDomProvider codeProvider, TranslationMap translationMap)
        {
            TypeInfo typeInfo = TypeInfoHelper.GetTypeInfo(pParams.Namespace, message);
            string filename = TypeInfoHelper.GetFilename(typeInfo);
            String filePath = Path.Combine(pParams.OutputPath, filename);
            CodeCompileUnit unit = MessageGeneratorHelper.CreateCodeCompileUnit(typeInfo, message, pParams.BaseClassTypeInfo, pParams.MessageTypeEnumTypeInfo, translationMap);
            codeProvider.GenerateCodeFromCompileUnit(unit, options, filePath);
        }

        #endregion

        #region Enum

        private static void GenerateEnumFiles(CodeDomProvider codeProvider, CodeGeneratorOptions options, string outputPath, IEnumerable<MessageDefinitions.Data.Enum> enums, TranslationMap translationMap)
        {
            EnumGenerationParams enumGenerationParams = new EnumGenerationParams();
            enumGenerationParams.OutputPath = outputPath;
            enumGenerationParams.Namespace = ConstantHelper.Namespaces.Root_Messages_Common;

            GenerateEnumFiles(codeProvider, options, enumGenerationParams, enums, translationMap);
        }

        private static void GenerateEnumFiles(CodeDomProvider codeProvider, CodeGeneratorOptions options, EnumGenerationParams pParams, IEnumerable<MessageDefinitions.Data.Enum> enums, TranslationMap translationMap)
        {
            foreach (MessageDefinitions.Data.Enum enumeration in enums)
            {
                GenerateEnumFile(pParams, enumeration, options, codeProvider, translationMap);
            }
        }

        private static void GenerateEnumFile(EnumGenerationParams pParams, MessageDefinitions.Data.Enum enumeration, CodeGeneratorOptions options, CodeDomProvider codeProvider, TranslationMap translationMap)
        {
            string enumerationName = enumeration.Name;

            TypeInfo typeInfo = new TypeInfo()
            {
                Name = enumerationName,
                Namespace = pParams.Namespace
            };

            string filename = TypeInfoHelper.GetFilename(typeInfo);
            String filePath = Path.Combine(pParams.OutputPath, filename);
            CodeCompileUnit unit = EnumGeneratorHelper.CreateCodeCompileUnit(typeInfo, enumeration, translationMap);
            codeProvider.GenerateCodeFromCompileUnit(unit, options, filePath);
        }

        #endregion

        #region Serializer

        private static void GenerateSerializerClassFiles(CodeDomProvider codeProvider, CodeGeneratorOptions options, string outputPath, IEnumerable<Message> messages, TypeInfo serializerInterfaceTypeInfo, TypeInfo messageBaseClassTypeInfo)
        {
            SerializerGenerationParams serializerGenerationParams = new SerializerGenerationParams();
            serializerGenerationParams.OutputPath = outputPath;
            serializerGenerationParams.Namespace = ConstantHelper.Namespaces.Root_Messages_Serialization_Common;
            serializerGenerationParams.MessagesNamespace = ConstantHelper.Namespaces.Root_Messages_Common;
            serializerGenerationParams.BaseClassTypeInfo = messageBaseClassTypeInfo;
            serializerGenerationParams.SerializerInterfaceTypeInfo = serializerInterfaceTypeInfo;

            GenerateSerializerClassFiles(codeProvider, options, serializerGenerationParams, messages);
        }

        private static void GenerateSerializerClassFiles(CodeDomProvider codeProvider, CodeGeneratorOptions options, SerializerGenerationParams pParams, IEnumerable<Message> messages)
        {
            foreach (MessageDefinitions.Data.Message message in messages)
            {
                GenerateSerializerClassFile(pParams, message, options, codeProvider);
            }
        }

        private static void GenerateSerializerClassFile(SerializerGenerationParams pParams, Message message, CodeGeneratorOptions options, CodeDomProvider codeProvider)
        {
            string serializerClassName = NameHelper.GetSerializerClassName(message);

            TypeInfo typeInfo = new TypeInfo()
            {
                Name = serializerClassName,
                Namespace = pParams.Namespace
            };

            string filename = TypeInfoHelper.GetFilename(typeInfo);
            String filePath = Path.Combine(pParams.OutputPath, filename);
            CodeCompileUnit unit = SerializerGeneratorHelper.CreateCodeCompileUnit(typeInfo, message, pParams.SerializerInterfaceTypeInfo, pParams.BaseClassTypeInfo, pParams.MessagesNamespace);
            codeProvider.GenerateCodeFromCompileUnit(unit, options, filePath);
        }

        #endregion

        #region SerializerFactory

        private static void GenerateSerializerFactory(CodeDomProvider codeProvider, CodeGeneratorOptions options, TypeInfo serializerFactoryClassTypeInfo, IEnumerable<Message> messages, string outputPath, TypeInfo messageTypeEnumTypeInfo, TypeInfo serializerInterfaceTypeInfo)
        {
            SerializerFactoryGenerationParams serializerFactoryGenerationParams = new SerializerFactoryGenerationParams();
            string factoryFilename = TypeInfoHelper.GetFilename(serializerFactoryClassTypeInfo);
            serializerFactoryGenerationParams.OutputFilePath = Path.Combine(outputPath, factoryFilename);
            serializerFactoryGenerationParams.TypeInfo = serializerFactoryClassTypeInfo;
            serializerFactoryGenerationParams.SerializerNamespace = ConstantHelper.Namespaces.Root_Messages_Serialization_Common;
            serializerFactoryGenerationParams.MessageTypeEnumTypeInfo = messageTypeEnumTypeInfo;
            serializerFactoryGenerationParams.SerializerInterfaceTypeInfo = serializerInterfaceTypeInfo;

            GenerateSerializerFactory(codeProvider, options, serializerFactoryGenerationParams, messages);
        }

        private static void GenerateSerializerFactory(CodeDomProvider codeProvider, CodeGeneratorOptions options, SerializerFactoryGenerationParams pParams, IEnumerable<Message> messages)
        {
            CodeCompileUnit unit = SerializerFactoryGeneratorHelper.CreateCodeCompileUnit(pParams.TypeInfo, messages, pParams.SerializerNamespace, pParams.MessageTypeEnumTypeInfo, pParams.SerializerInterfaceTypeInfo);
            codeProvider.GenerateCodeFromCompileUnit(unit, options, pParams.OutputFilePath);
        }

        #endregion
    }
}
