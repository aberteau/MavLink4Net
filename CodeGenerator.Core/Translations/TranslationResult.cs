using System;
using System.Collections.Generic;
using System.Text;
using MavLink4Net.MessageDefinitions.Data;

namespace MavLink4Net.CodeGenerator.Core.Translations
{
    public class TranslationResult
    {
        public MavLink MavLink { get; set; }

        public TranslationMap TranslationMap { get; set; }
    }
}
