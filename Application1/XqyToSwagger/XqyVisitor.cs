using System;

namespace XqyToSwagger
{
    public class XqyVisitor : XqyBaseVisitor<string>
    {
        public override string VisitGetVerb(XqyParser.GetVerbContext context)
        {
            Console.WriteLine("GET Verb used...");
            return base.VisitGetVerb(context);
        }

        public override string VisitPostVerb(XqyParser.PostVerbContext context)
        {
            Console.WriteLine("POST Verb used...");
            return base.VisitPostVerb(context);
        }

        public override string VisitPutVerb(XqyParser.PutVerbContext context)
        {
            Console.WriteLine("PUT Verb used...");
            return base.VisitPutVerb(context);
        }

        public override string VisitUrlInBraces(XqyParser.UrlInBracesContext context)
        {
            return base.VisitUrlInBraces(context);
        }

        public override string VisitUrlPath(XqyParser.UrlPathContext context)
        {
            Console.WriteLine("getting url path... {0}", context.children[0].ToString());
            return base.VisitUrlPath(context);
        }

        public override string VisitQuotes(XqyParser.QuotesContext context)
        {
            return Visit(context.expr());
        }

    }
}