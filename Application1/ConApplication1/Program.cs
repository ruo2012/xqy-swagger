using System;
using Antlr.Runtime;

namespace ConApplication1
{
    static class Program
    {
        static void Main(string[] args)
        {
            var inputStream = Console.OpenStandardInput();
            var input = new ANTLRInputStream(inputStream);
            var lexer = new CalculatorLexer(input);
            var tokens = new CommonTokenStream(lexer);
            var parser = new CalculatorParser(tokens);
            int answer = parser.addSubExpr();
            Console.WriteLine("Answer = {0}", answer);

        }
    }
}
