using System;
using System.CodeDom;

namespace GenerateHelloWorld
{
    class Program
    {
        static CodeNamespace BuildProgram()
        {
            var nameSpc = new CodeNamespace("GeneratedWorld");
            var systemImport = new CodeNamespaceImport("System");
            nameSpc.Imports.Add(systemImport);
            var programClass = new CodeTypeDeclaration("Program");
            nameSpc.Types.Add(programClass);
            var methodMain = new CodeMemberMethod
            {
                Attributes = MemberAttributes.Static,
                Name = "Main"
            };
            methodMain.Statements.Add(new CodeMethodInvokeExpression(new CodeSnippetExpression("Console"), "WriteLine", new CodePrimitiveExpression("Hello generated world!")));
            programClass.Members.Add(methodMain);

            return nameSpc;
        }

        static void Main(string[] args)
        {


            Console.ReadLine();
        }
    }
}
