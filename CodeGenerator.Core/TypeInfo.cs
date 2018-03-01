using System;

namespace MavLink4Net.CodeGenerator.Core
{
    public class TypeInfo
    {
        public String Namespace { get; set; }

        public String Name { get; set; }

        public String FullName => $"{Namespace}.{Name}";
    }
}