namespace HTMLRenderer
{
    using System;
    using System.CodeDom.Compiler;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using HTMLRenderer.Contracts;
    using Microsoft.CSharp;

    public class HTMLRendererCommandExecutor
    {
        static void Main()
        {
            //string csharpCode = ReadInputCSharpCode();
            //CompileAndRun(csharpCode);

            IElementFactory htmlFactory = new HTMLElementFactory();
            IElement html = htmlFactory.CreateElement("html");
            html.TextContent = "I am a text content in the HTML tag";
            Console.WriteLine(html);
            IElement h1 = htmlFactory.CreateElement("h1", "Welcome!");
            Console.WriteLine(h1);
            html.AddElement(h1);
            Console.WriteLine(html);
            IElementFactory f = new HTMLElementFactory();
            IElement p = f.CreateElement("p");
            Console.WriteLine(p);
            ITable table = htmlFactory.CreateTable(3, 2);
            table[0, 0] = htmlFactory.CreateElement("b", "First Name");
            table[0, 1] = htmlFactory.CreateElement("b", "Last Name");
            table[1, 0] = htmlFactory.CreateElement(null, "Svetlin");
            table[1, 1] = htmlFactory.CreateElement(null, "Nakov");
            table[2, 0] = htmlFactory.CreateElement(null, "George");
            table[2, 1] = htmlFactory.CreateElement(null, "Georgiev");
            Console.WriteLine(table);
            p.AddElement(table);
            IElement br = htmlFactory.CreateElement("br", null);
            p.AddElement(br);
            p.AddElement(htmlFactory.CreateElement("div", "I am DIV"));
            Console.WriteLine(p);
            html.AddElement(p);
            IElement div = htmlFactory.CreateElement("div",
              "(c) Nakov & Joro @ <Telerik Software Academy>");
            Console.WriteLine(div);
            html.AddElement(div);
            ITable innerTable = htmlFactory.CreateTable(2, 2);
            innerTable[0, 0] = htmlFactory.CreateElement(null, "cell00");
            innerTable[0, 1] = htmlFactory.CreateElement("p", "cell01");
            innerTable[1, 0] = htmlFactory.CreateElement("br");
            innerTable[1, 1] = htmlFactory.CreateElement("hr", null);
            Console.WriteLine(innerTable);
            ITable outerTable = htmlFactory.CreateTable(2, 3);
            outerTable[0, 0] = htmlFactory.CreateElement(null, "out00");
            outerTable[0, 1] = htmlFactory.CreateElement("p", "out01");
            outerTable[0, 2] = innerTable;
            outerTable[1, 0] = htmlFactory.CreateElement("b", "out10");
            outerTable[1, 1] = innerTable;
            outerTable[1, 2] = innerTable;
            Console.WriteLine(outerTable);
            table[1, 0] = innerTable;
            table[1, 1] = outerTable;
            html.AddElement(outerTable);
            html.AddElement(outerTable);
            html.AddElement(outerTable);
            html.AddElement(htmlFactory.CreateElement("div", "footer"));
            Console.WriteLine(html);
        }

        private static string ReadInputCSharpCode()
        {
            StringBuilder result = new StringBuilder();
            string line;
            while ((line = Console.ReadLine()) != "")
            {
                result.AppendLine(line);
            }
            return result.ToString();
        }

        static void CompileAndRun(string csharpCode)
        {
            // Prepare a C# program for compilation
            string[] csharpClass =
            {
                @"using System;
                  using HTMLRenderer;

                  public class RuntimeCompiledClass
                  {
                     public static void Main()
                     {"
                        + csharpCode + @"
                     }
                  }"
            };

            // Compile the C# program
            CompilerParameters compilerParams = new CompilerParameters();
            compilerParams.GenerateInMemory = true;
            compilerParams.TempFiles = new TempFileCollection(".");
            compilerParams.ReferencedAssemblies.Add("System.dll");
            compilerParams.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);
            CSharpCodeProvider csharpProvider = new CSharpCodeProvider();
            CompilerResults compile = csharpProvider.CompileAssemblyFromSource(
                compilerParams, csharpClass);

            // Check for compilation errors
            if (compile.Errors.HasErrors)
            {
                string errorMsg = "Compilation error: ";
                foreach (CompilerError ce in compile.Errors)
                {
                    errorMsg += "\r\n" + ce.ToString();
                }
                throw new Exception(errorMsg);
            }

            // Invoke the Main() method of the compiled class
            Assembly assembly = compile.CompiledAssembly;
            Module module = assembly.GetModules()[0];
            Type type = module.GetType("RuntimeCompiledClass");
            MethodInfo methInfo = type.GetMethod("Main");
            methInfo.Invoke(null, null);
        }
    }
}
