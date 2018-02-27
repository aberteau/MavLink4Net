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

            string commonNamespace = $"{ns}.{CommonName}";
            string commonPath = Path.Combine(outputPath, CommonName);

            GenerateEnumFiles(commonPath, mavLink.Enums, options, codeProvider, commonNamespace);

            string baseClassFullName = $"{ns}.{MessageBaseClassName}";
            string messageTypeEnumFullName = $"{ns}.{MavTypeEnumName}";
            GenerateMessageClassFiles(commonPath, mavLink.Messages, options, codeProvider, commonNamespace, baseClassFullName, messageTypeEnumFullName);
        }

        private static void GenerateMavTypeEnum(string outputPath, IEnumerable<Message> messages, CodeGeneratorOptions options, CodeDomProvider codeProvider, string ns, string messageTypeEnumFullName)
        {
            string filename = $"{messageTypeEnumFullName}.cs";
            String filePath = Path.Combine(outputPath, filename);
            CodeCompileUnit unit = MavTypeEnumGeneratorHelper.CreateCodeCompileUnit(messageTypeEnumFullName, messages, ns);
            codeProvider.GenerateCodeFromCompileUnit(unit, options, filePath);
        }

        private static CodeDomProvider CreateCodeDomProvider(string language)
        {
            //TODO: A compléter (Prise en charge VB.Net)
            return new CSharpCodeProvider();
        }

        private static void GenerateMessageClassFiles(string folderPath, IEnumerable<MessageDefinitions.Data.Message> messages, CodeGeneratorOptions options, CodeDomProvider codeProvider, string ns, string baseClassName, string messageTypeEnumFullName)
        {
            foreach (MessageDefinitions.Data.Message message in messages)
            {
                string messageTypeEnumValue = $"{messageTypeEnumFullName}.{message.Name}";
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

        private static string GetMessageClassName(Message message)
        {
            string messageClassName = $"{message.Name}Message";
            return messageClassName;
        }

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

    }
}
