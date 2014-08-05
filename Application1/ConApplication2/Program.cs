using System;
using System.IO;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace ConApplication2
{
    static class Program
    {
        static void Main(string[] args)
        {
            var inputStream = new StreamReader(Console.OpenStandardInput());
            var input = new AntlrInputStream(inputStream.ReadToEnd());
            var lexer = new CalculatorLexer(input);
            var tokens = new CommonTokenStream(lexer);
            var parser = new CalculatorParser(tokens);
            IParseTree tree = parser.prog();
            Console.WriteLine(tree.ToStringTree(parser));
            var visitor = new CalculatorVisitor();
            Console.WriteLine(visitor.Visit(tree));
        }
    }
}
