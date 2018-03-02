using System;
using System.Collections.Generic;
using System.Text;
using MavLink4Net.MessageDefinitions.Transformations;

namespace MavLink4Net.MessageDefinitions
{
    public class MavLinkHelper
    {
        public static Data.MavLink LoadMavLink(string messageDefinitionPath)
        {
            DefaultTransformation dTranslation = new DefaultTransformation(EnumValuePrefixRemovalStrategy.RemoveLongestCommonString);
            DataProvider dataProvider = new DataProvider(dTranslation, dTranslation, dTranslation, dTranslation, dTranslation);
            Data.MavLink mavLink = dataProvider.LoadMavLink(messageDefinitionPath);
            return mavLink;
        }

    }
}
