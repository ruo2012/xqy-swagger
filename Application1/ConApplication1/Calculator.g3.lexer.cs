using System;
using Antlr.Runtime;

namespace ConApplication1
{
    partial class CalculatorLexer
    {
        public override void ReportError(RecognitionException e)
        {
            base.ReportError(e);
            Console.WriteLine("Error in lexer at line " + e.Line + ":" + e.CharPositionInLine);
        }
    }
}
