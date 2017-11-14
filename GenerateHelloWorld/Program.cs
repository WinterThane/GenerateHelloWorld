using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;
using System.Text;

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
            CodeNamespace progNamespace = BuildProgram();
            var compilerOptions = new CodeGeneratorOptions()
            {
                IndentString = "    ",
                BracingStyle = "C",
                BlankLinesBetweenMembers = false
            };
            var codeText = new StringBuilder();
            using (var codeWriter = new StringWriter(codeText))
            {
                CodeDomProvider.CreateProvider("C#").GenerateCodeFromNamespace(progNamespace, codeWriter, compilerOptions);
            };
            var script = codeText.ToString();

            Console.WriteLine(script);
            Console.ReadLine();
        }
    }
}
