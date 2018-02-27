using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;
using Microsoft.CSharp;

namespace MavLink4Net.CodeGenerator.Core
{
    public class GeneratorHelper
    {
        public static void Generate(string language, string outputPath)
        {
            CodeGeneratorOptions options = new CodeGeneratorOptions() { BracingStyle = "C" };
            CodeDomProvider codeProvider = CreateCodeDomProvider(language);
            
            GenerateMessageClassFile(outputPath, "Heartbeat", options, codeProvider);
        }

        private static CodeDomProvider CreateCodeDomProvider(string language)
        {
            //TODO: A compléter (Prise en charge VB.Net)
            return new CSharpCodeProvider();
        }

        private static void GenerateMessageClassFile(string folderPath, String messageClassName, CodeGeneratorOptions options, CodeDomProvider codeProvider)
        {
            string filename = $"{messageClassName}.cs";
            String filePath = Path.Combine(folderPath, filename);
            CodeCompileUnit unit = MessageGeneratorHelper.CreateCodeCompileUnit(messageClassName);
            codeProvider.GenerateCodeFromCompileUnit(unit, options, filePath);
        }


    }
}
