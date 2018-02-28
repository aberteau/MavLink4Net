using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MavLink4Net.CodeGenerator.Core
{
    class NamespaceHelper
    {
        public static String Combine(String[] s)
        {
            string ns = String.Join(".", s);
            return ns;
        }

        public static String Combine(String s1, String s2)
        {
            string[] strArray = new[] { s1, s2 };
            string ns = Combine(strArray);
            return ns;
        }

        public static String GetNamespace(String s1, String s2)
        {
            string ns = Combine(s1, s2);
            return ns;
        }

        public static String GetFullname(String s1, String s2)
        {
            string ns = Combine(s1, s2);
            return ns;
        }
    }
}
