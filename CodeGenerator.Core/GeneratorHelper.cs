using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using MavLink4Net.CodeGenerator.Core.Params;
using MavLink4Net.MessageDefinitions;
using MavLink4Net.MessageDefinitions.Data;
using Microsoft.CSharp;

namespace MavLink4Net.CodeGenerator.Core
{
    public class GeneratorHelper
    {
        public static void GenerateFiles(string messageDefinitionPath, string outputPath, string language)
        {
            MessageDefinitions.Data.MavLink result = MavLinkHelper.LoadMavLink(messageDefinitionPath);
            GenerateFiles(messageDefinitionPath, outputPath, language, result);
        }

        public static void GenerateFiles(string messageDefinitionPath, string outputPath, string language, MessageDefinitions.Data.MavLink mavLink)
        {
            String messagesPath = Path.Combine(outputPath, ConstantHelper.MessagesFolderName);
            System.IO.Directory.CreateDirectory(messagesPath);

            string serializationOutputPath = Path.Combine(outputPath, ConstantHelper.MessagesSerializationFolderName);
            System.IO.Directory.CreateDirectory(serializationOutputPath);

            string messagesCommonPath = Path.Combine(messagesPath, ConstantHelper.CommonName);
            System.IO.Directory.CreateDirectory(messagesCommonPath);

            string serializerCommonOutputPath = Path.Combine(serializationOutputPath, ConstantHelper.CommonName);
            System.IO.Directory.CreateDirectory(serializerCommonOutputPath);

            TypeInfo messageBaseClassTypeInfo = TypeInfoHelper.GetMessageTypeInfo();
            TypeInfo messageTypeEnumTypeInfo = TypeInfoHelper.GetMavMessageTypeTypeInfo();
            TypeInfo serializerInterfaceTypeInfo = TypeInfoHelper.GetSerializerInterfaceTypeInfo();
            TypeInfo serializerFactoryClassTypeInfo = TypeInfoHelper.GetSerializerFactoryTypeInfo();

            CodeGeneratorOptions options = new CodeGeneratorOptions() { BracingStyle = "C" };
            CodeDomProvider codeProvider = CreateCodeDomProvider(language);

            GenerateMessageTypeEnum(codeProvider, options, messageTypeEnumTypeInfo, messagesPath, mavLink.Messages);

            GenerateEnumFiles(codeProvider, options, messagesCommonPath, mavLink.Enums);

            GenerateMessageClassFiles(codeProvider, options, messagesCommonPath, messageBaseClassTypeInfo, messageTypeEnumTypeInfo, mavLink.Messages, mavLink.EnumByXmlName);

            GenerateSerializerClassFiles(codeProvider, options, serializerCommonOutputPath, mavLink.Messages, serializerInterfaceTypeInfo, messageBaseClassTypeInfo);

            GenerateSerializerFactory(codeProvider, options, serializerFactoryClassTypeInfo, mavLink.Messages, serializationOutputPath, messageTypeEnumTypeInfo, serializerInterfaceTypeInfo);
        }

        private static CodeDomProvider CreateCodeDomProvider(string language)
        {
            //TODO: A compléter (Prise en charge VB.Net)
            return new CSharpCodeProvider();
        }

        #region MessageType

        private static void GenerateMessageTypeEnum(CodeDomProvider codeProvider, CodeGeneratorOptions options, TypeInfo messageTypeEnumTypeInfo, string outputPath, IEnumerable<Message> messages)
        {
            MessageTypeEnumGenerationParams typeEnumGenerationParams = new MessageTypeEnumGenerationParams();
            string messageTypeEnumFilename = TypeInfoHelper.GetFilename(messageTypeEnumTypeInfo);
            typeEnumGenerationParams.OutputFilePath = Path.Combine(outputPath, messageTypeEnumFilename);
            typeEnumGenerationParams.TypeInfo = messageTypeEnumTypeInfo;

            GenerateMessageTypeEnum(codeProvider, options, typeEnumGenerationParams, messages);
        }

        private static void GenerateMessageTypeEnum(CodeDomProvider codeProvider, CodeGeneratorOptions options, MessageTypeEnumGenerationParams typeEnumGenerationParams, IEnumerable<Message> messages)
        {
            CodeCompileUnit unit = MavTypeEnumGeneratorHelper.CreateCodeCompileUnit(typeEnumGenerationParams.TypeInfo, messages);
            codeProvider.GenerateCodeFromCompileUnit(unit, options, typeEnumGenerationParams.OutputFilePath);
        }

        #endregion

        #region Message

        private static void GenerateMessageClassFiles(CodeDomProvider codeProvider, CodeGeneratorOptions options, string outputPath, TypeInfo messageBaseClassTypeInfo, TypeInfo messageTypeEnumTypeInfo, IEnumerable<Message> messages, IDictionary<String, MessageDefinitions.Data.Enum> enumByXmlEnum)
        {
            MessageGenerationParams messageGenerationParams = new MessageGenerationParams();
            messageGenerationParams.OutputPath = outputPath;
            messageGenerationParams.BaseClassTypeInfo = messageBaseClassTypeInfo;
            messageGenerationParams.MessageTypeEnumTypeInfo = messageTypeEnumTypeInfo;
            messageGenerationParams.Namespace = ConstantHelper.Namespaces.Root_Messages_Common;

            GenerateMessageClassFiles(codeProvider, options, messageGenerationParams, messages, enumByXmlEnum);
        }

        private static void GenerateMessageClassFiles(CodeDomProvider codeProvider, CodeGeneratorOptions options, MessageGenerationParams pParams, IEnumerable<Message> messages, IDictionary<String, MessageDefinitions.Data.Enum> enumByXmlEnum)
        {
            foreach (MessageDefinitions.Data.Message message in messages)
            {
                GenerateMessageClassFile(pParams, message, options, codeProvider, enumByXmlEnum);
            }
        }

        private static void GenerateMessageClassFile(MessageGenerationParams pParams, MessageDefinitions.Data.Message message, CodeGeneratorOptions options, CodeDomProvider codeProvider, IDictionary<String, MessageDefinitions.Data.Enum> enumByXmlEnum)
        {
            TypeInfo typeInfo = TypeInfoHelper.GetTypeInfo(pParams.Namespace, message);
            string filename = TypeInfoHelper.GetFilename(typeInfo);
            String filePath = Path.Combine(pParams.OutputPath, filename);
            CodeCompileUnit unit = MessageGeneratorHelper.CreateCodeCompileUnit(typeInfo, message, pParams.BaseClassTypeInfo, pParams.MessageTypeEnumTypeInfo, enumByXmlEnum);
            codeProvider.GenerateCodeFromCompileUnit(unit, options, filePath);
        }

        #endregion

        #region Enum

        private static void GenerateEnumFiles(CodeDomProvider codeProvider, CodeGeneratorOptions options, string outputPath, IEnumerable<MessageDefinitions.Data.Enum> enums)
        {
            EnumGenerationParams enumGenerationParams = new EnumGenerationParams();
            enumGenerationParams.OutputPath = outputPath;
            enumGenerationParams.Namespace = ConstantHelper.Namespaces.Root_Messages_Common;

            GenerateEnumFiles(codeProvider, options, enumGenerationParams, enums);
        }

        private static void GenerateEnumFiles(CodeDomProvider codeProvider, CodeGeneratorOptions options, EnumGenerationParams pParams, IEnumerable<MessageDefinitions.Data.Enum> enums)
        {
            foreach (MessageDefinitions.Data.Enum enumeration in enums)
            {
                GenerateEnumFile(pParams, enumeration, options, codeProvider);
            }
        }

        private static void GenerateEnumFile(EnumGenerationParams pParams, MessageDefinitions.Data.Enum enumeration, CodeGeneratorOptions options, CodeDomProvider codeProvider)
        {
            string enumerationName = enumeration.Name;

            TypeInfo typeInfo = new TypeInfo()
            {
                Name = enumerationName,
                Namespace = pParams.Namespace
            };

            string filename = TypeInfoHelper.GetFilename(typeInfo);
            String filePath = Path.Combine(pParams.OutputPath, filename);
            CodeCompileUnit unit = EnumGeneratorHelper.CreateCodeCompileUnit(typeInfo, enumeration);
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
