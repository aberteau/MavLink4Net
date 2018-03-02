using System;
using System.Collections.Generic;
using MavLink4Net.MessageDefinitions.Data;
using MavLink4Net.MessageDefinitions.Tests.Data;
using MavLink4Net.MessageDefinitions.Transformations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MavLink4Net.MessageDefinitions.Tests
{
    [TestClass]
    public class DataProviderTests
    {
        private static MavLink LoadMavLink()
        {
            //string definitionFilePath = @"F:\UserData\Amael\OneDrive\Projets\MavLink4Net\message_definitions\0.9\common.xml";
            string definitionFilePath = @"F:\UserData\Amael\OneDrive\Projets\MavLink4Net\message_definitions\1.0\common.xml";

            MavLink1MessageFilter messageFilter = new MavLink1MessageFilter();

            DataProvider dataProvider = new DataProvider(false, null, null, null, null, messageFilter);
            MavLink mavLink = dataProvider.GetMavLink(definitionFilePath);

            return mavLink;
        }

        [TestMethod]
        public void AreNameValid()
        {
            MavLink mavLink = LoadMavLink();

            IDictionary<uint, MessageInfo> messageInfoById = DefinitionDataHelper.GetMessageInfoById();

            foreach (Message message in mavLink.Messages)
            {
                uint messageId = (uint)message.Id;
                MessageInfo messageInfo = messageInfoById.ContainsKey(messageId) ? messageInfoById[messageId] : null;

                if (messageInfo != null)
                    Assert.AreEqual(messageInfo.Name, message.Name);
            }
        }

        [TestMethod]
        public void AreCrcValid()
        {
            MavLink mavLink = LoadMavLink();

            IDictionary<uint, MessageInfo> messageInfoById = DefinitionDataHelper.GetMessageInfoById();

            IDictionary<Message, byte> errorDictionary = new Dictionary<Message, byte>();

            foreach (Message message in mavLink.Messages)
            {
                uint messageId = (uint)message.Id;
                MessageInfo messageInfo = messageInfoById.ContainsKey(messageId) ? messageInfoById[messageId] : null;

                if (messageInfo != null)
                {
                    Assert.AreEqual(messageInfo.Crc, message.CrcExtra);

                    if (messageInfo.Crc != message.CrcExtra)
                        errorDictionary.Add(message, messageInfo.Crc);
                }
            }

            Console.WriteLine("Name \t| Expected \t| Computed");
            foreach (var kvp in errorDictionary)
            {
                Console.WriteLine($"{kvp.Key.Name} \t| {kvp.Value} \t| {kvp.Key.CrcExtra}");
            }
        }
    }
}
