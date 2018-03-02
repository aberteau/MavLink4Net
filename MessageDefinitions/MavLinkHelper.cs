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
            DefaultTransformation transformation = new DefaultTransformation(EnumValuePrefixRemovalStrategy.RemoveLongestCommonString);
            MavLink1MessageFilter messageFilter = new MavLink1MessageFilter();
            DataProvider dataProvider = new DataProvider(false, transformation, transformation, transformation, transformation, messageFilter);
            Data.MavLink mavLink = dataProvider.LoadMavLink(messageDefinitionPath);
            return mavLink;
        }

    }
}
