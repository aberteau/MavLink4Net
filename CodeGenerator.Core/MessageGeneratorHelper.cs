using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Text;

namespace MavLink4Net.CodeGenerator.Core
{
    class MessageGeneratorHelper
    {
        public static CodeCompileUnit CreateCodeCompileUnit(string messageClassName)
        {
            // Generate the container unit
            CodeCompileUnit codeCompileUnit = new CodeCompileUnit();

            // Generate the namespace
            CodeNamespace ns = new CodeNamespace("MavLink4Net.Messages");

            // Add the required imports
            ns.Imports.Add(new CodeNamespaceImport("System"));
            ns.Imports.Add(new CodeNamespaceImport("System.Xml.Serialization"));

            codeCompileUnit.Namespaces.Add(ns);

            // Declare the class
            CodeTypeDeclaration classDeclaration = new CodeTypeDeclaration()
            {
                Name = messageClassName,
                IsClass = true
            };

            // Add class to the namespace
            ns.Types.Add(classDeclaration);
            return codeCompileUnit;
        }
    }
}
