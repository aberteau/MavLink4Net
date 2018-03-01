using System;
using System.Collections.Generic;
using System.Text;

namespace MavLink4Net.CodeGenerator.Core
{
    public class ConstantHelper
    {
        public const String MessagesFolderName = "Messages";

        public const String CommonName = "Common";

        public const String MessagesSerializationFolderName = "Messages.Serialization";

        public class Namespaces
        {
            public const String Root = "MavLink4Net";
            public static String Root_Messages => NamespaceHelper.GetNamespace(Root, "Messages");
            public static String Root_Messages_Common => NamespaceHelper.GetNamespace(Root_Messages, "Common");
            public static String Root_Messages_Serialization => NamespaceHelper.GetNamespace(Root_Messages, "Serialization");
            public static String Root_Messages_Serialization_Common => NamespaceHelper.GetNamespace(Root_Messages_Serialization, "Common");
        }

        
    }
}
