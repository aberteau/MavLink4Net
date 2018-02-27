using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MavLink4Net.CodeGenerator.Core
{
    class CodeCommentStatementHelper
    {
        public static CodeCommentStatement[] GetXmlCodeCommentStatements(String elementName, String line)
        {
            CodeCommentStatement[] statements = GetXmlCodeCommentStatements(elementName, new[] { line });
            return statements;
        }

        public static CodeCommentStatement[] GetXmlCodeCommentStatements(String elementName, String[] lines)
        {
            IList<CodeCommentStatement> statements = new List<CodeCommentStatement>();
            statements.Add(new CodeCommentStatement($"<{elementName}>", true));

            foreach (string line in lines)
                statements.Add(new CodeCommentStatement(line, true));

            statements.Add(new CodeCommentStatement($"</{elementName}>", true));
            return statements.ToArray();
        }

        public static CodeCommentStatement[] GetSummaryCodeCommentStatements(String line)
        {
            CodeCommentStatement[] statements = GetSummaryCodeCommentStatements(new[] { line });
            return statements;
        }

        public static CodeCommentStatement[] GetSummaryCodeCommentStatements(String[] lines)
        {
            CodeCommentStatement[] statements = GetXmlCodeCommentStatements("summary", lines);
            return statements;
        }

        public static CodeCommentStatement[] GetRemarksCodeCommentStatements(string line)
        {
            CodeCommentStatement[] statements = GetXmlCodeCommentStatements("remarks", line);
            return statements;
        }
    }
}
