using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using MavLink4Net.MessageDefinitions.Data;
using Microsoft.CSharp;

namespace MavLink4Net.CodeGenerator.Core
{
    public class GeneratorHelper
    {
        private const string MessageBaseClassName = "Message";
        private const string CommonName = "Common";
        private const string MavTypeEnumName = "MavType";

        public static void Generate(MavLink mavLink, string language, string outputPath, string ns)
        {
            CodeGeneratorOptions options = new CodeGeneratorOptions() { BracingStyle = "C" };
            CodeDomProvider codeProvider = CreateCodeDomProvider(language);

            GenerateMavTypeEnum(outputPath, mavLink.Messages, options, codeProvider, ns, MavTypeEnumName);

            string commonNamespace = NamespaceHelper.GetNamespace(ns, CommonName);
            string commonPath = Path.Combine(outputPath, CommonName);

            GenerateEnumFiles(commonPath, mavLink.Enums, options, codeProvider, commonNamespace);

            string messageBaseClassFullName = NamespaceHelper.GetFullname(ns, MessageBaseClassName);
            string messageTypeEnumFullName = NamespaceHelper.GetFullname(ns, MavTypeEnumName);
            GenerateMessageClassFiles(commonPath, mavLink.Messages, options, codeProvider, commonNamespace, messageBaseClassFullName, messageTypeEnumFullName);

            string serializerOutputPath = @"F:\Developpement\MavLink4Net\Messages.Serialization\Common";
            string serializationCommonNamespace = "MavLink4Net.Messages.Serialization.Common";
            string serializerInterfaceName = "MavLink4Net.Messages.Serialization.IMessageSerializer";
            GenerateSerializerClassFiles(serializerOutputPath, mavLink.Messages, options, codeProvider, serializationCommonNamespace, serializerInterfaceName, messageBaseClassFullName);
        }

        private static CodeDomProvider CreateCodeDomProvider(string language)
        {
            //TODO: A compléter (Prise en charge VB.Net)
            return new CSharpCodeProvider();
        }

        #region MavType

        private static void GenerateMavTypeEnum(string outputPath, IEnumerable<Message> messages, CodeGeneratorOptions options, CodeDomProvider codeProvider, string ns, string messageTypeEnumFullName)
        {
            string filename = $"{messageTypeEnumFullName}.cs";
            String filePath = Path.Combine(outputPath, filename);
            CodeCompileUnit unit = MavTypeEnumGeneratorHelper.CreateCodeCompileUnit(messageTypeEnumFullName, messages, ns);
            codeProvider.GenerateCodeFromCompileUnit(unit, options, filePath);
        }

        #endregion

        #region Message

        private static void GenerateMessageClassFiles(string folderPath, IEnumerable<Message> messages, CodeGeneratorOptions options, CodeDomProvider codeProvider, string ns, string baseClassName, string messageTypeEnumFullName)
        {
            foreach (MessageDefinitions.Data.Message message in messages)
            {
                string messageTypeEnumValue = NamespaceHelper.GetFullname(messageTypeEnumFullName, message.Name);
                GenerateMessageClassFile(folderPath, message, options, codeProvider, ns, baseClassName, messageTypeEnumValue);
            }
        }

        private static void GenerateMessageClassFile(string folderPath, MessageDefinitions.Data.Message message, CodeGeneratorOptions options, CodeDomProvider codeProvider, string ns, string baseClassName, string messageTypeEnumValue)
        {
            string messageName = GetMessageClassName(message);
            string filename = $"{messageName}.cs";
            String filePath = Path.Combine(folderPath, filename);
            CodeCompileUnit unit = MessageGeneratorHelper.CreateCodeCompileUnit(message, messageName, ns, baseClassName, messageTypeEnumValue);
            codeProvider.GenerateCodeFromCompileUnit(unit, options, filePath);
        }

        public static string GetMessageClassName(MessageDefinitions.Data.Message message)
        {
            string messageClassName = $"{message.Name}Message";
            return messageClassName;
        }

        #endregion

        #region Enum

        private static void GenerateEnumFiles(string folderPath, IEnumerable<MessageDefinitions.Data.Enum> enums, CodeGeneratorOptions options, CodeDomProvider codeProvider, string ns)
        {
            foreach (MessageDefinitions.Data.Enum enumeration in enums)
            {
                GenerateEnumFile(folderPath, enumeration, options, codeProvider, ns);
            }
        }

        private static void GenerateEnumFile(string folderPath, MessageDefinitions.Data.Enum enumeration, CodeGeneratorOptions options, CodeDomProvider codeProvider, string ns)
        {
            string enumerationName = enumeration.Name;
            string filename = $"{enumerationName}.cs";
            String filePath = Path.Combine(folderPath, filename);
            CodeCompileUnit unit = EnumGeneratorHelper.CreateCodeCompileUnit(enumeration, ns);
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
            string serializerClassName = GetSerializerClassName(message);
            string filename = $"{serializerClassName}.cs";
            String filePath = Path.Combine(folderPath, filename);
            CodeCompileUnit unit = SerializerGeneratorHelper.CreateCodeCompileUnit(message, serializerClassName, ns, baseClassName, messageBaseClassName);
            codeProvider.GenerateCodeFromCompileUnit(unit, options, filePath);
        }

        private static string GetSerializerClassName(Message message)
        {
            string messageName = GetMessageClassName(message);
            string serializerClassName = $"{messageName}Serializer";
            return serializerClassName;
        }

        #endregion
    }
}
