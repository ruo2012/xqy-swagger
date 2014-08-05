using System;
using System.IO;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace XqyToSwagger
{
    static class Program
    {
        static void Main(string[] args)
        {
            var filePath = @"episodeview.xqy";
            var inputStream = new FileStream(filePath, FileMode.Open);
            var input = new AntlrInputStream(inputStream);
            var lexer = new XqyLexer(input);
            var tokens = new CommonTokenStream(lexer);
            var parser = new XqyParser(tokens);
            IParseTree tree = parser.prog();
            Console.WriteLine(tree.ToStringTree(parser));
            var visitor = new XqyVisitor();
            Console.WriteLine(visitor.Visit(tree));
        }
    }
}
