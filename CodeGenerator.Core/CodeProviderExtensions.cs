using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.CSharp;

namespace MavLink4Net.CodeGenerator.Core
{
    static class CodeProviderExtensions
    {
        public static void GenerateCodeFromCompileUnit(this CodeDomProvider codeProvider, CodeCompileUnit codeCompileUnit, CodeGeneratorOptions options, string outFilePath)
        {
            using (var outFile = File.Open(outFilePath, FileMode.Create))
            using (var fileWriter = new StreamWriter(outFile))
            using (var indentedTextWriter = new IndentedTextWriter(fileWriter, "    "))
            {
                codeProvider.GenerateCodeFromCompileUnit(codeCompileUnit, indentedTextWriter, options);
            }
        }
    }
}
