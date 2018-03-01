using System;
using System.IO;
using System.Reflection;
using MavLink4Net.CodeGenerator.Core;
using NDesk.Options;

namespace MavLink4Net.CodeGenerator.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool helpFlag = false;
            String language = null;
            String outputPath = null;
            String messageDefinitionPath = null;

            OptionSet optionSet = new OptionSet() {
                { "lang=", "the {LANGUAGE} of generated code [default: CSharp]", v => language = v },
                { "defPath=", "the {PATH} of Message Definitions files.", v => messageDefinitionPath = v },
                { "outputPath=", "the {PATH} of output files.", v => outputPath = v },
                { "h|help",  "show this message and exit", v => helpFlag = v != null },
            };

            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            string applicationName = Path.GetFileName(codeBase);

            try
            {
                optionSet.Parse(args);

                if (String.IsNullOrWhiteSpace(messageDefinitionPath))
                    throw new Exception("defPath must be provided");

                if (String.IsNullOrWhiteSpace(outputPath))
                    throw new Exception("outputPath must be provided");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine($"Use '{applicationName} --help' for more information.");
                return;
            }

            if (helpFlag)
            {
                ShowHelp(applicationName, optionSet);
                return;
            }

            Console.WriteLine($"The files will be generated in folder '{outputPath}'");
            Console.WriteLine("Press [Enter] key to generate files");
            Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine($"Generating files in folder '{outputPath}' ...");

            GeneratorHelper.GenerateFiles(messageDefinitionPath, outputPath, language);

            Console.WriteLine();
            Console.WriteLine($"Generation succeeded in folder '{outputPath}'");
            Console.WriteLine("Press [Enter] key to quit...");
            Console.ReadLine();
        }

        static void ShowHelp(string applicationName, OptionSet p)
        {
            Console.WriteLine($"Usage: '{applicationName}' [OPTIONS]");
            Console.WriteLine();
            Console.WriteLine("Options:");
            p.WriteOptionDescriptions(Console.Out);
        }
    }
}
