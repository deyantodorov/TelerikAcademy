namespace SoftwareAcademy
{
    using System;
    using System.CodeDom.Compiler;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using Microsoft.CSharp;
    using SoftwareAcademy.Contracts;

    public class SoftwareAcademyCommandExecutor
    {
        static void Main()
        {
            //string csharpCode = ReadInputCSharpCode();
            //CompileAndRun(csharpCode);

            //CourseFactory factory = new CourseFactory();
            //ITeacher nakov = factory.CreateTeacher("Nakov");
            //Console.WriteLine(nakov);

            //CourseFactory factory = new CourseFactory();
            //ITeacher nakov = factory.CreateTeacher("Nakov");
            //Console.WriteLine("Hello, " + nakov.Name + "!");

            //CourseFactory factory = new CourseFactory();
            //ITeacher nakov = factory.CreateTeacher("Nakov");
            //nakov.Name = "Svetlin Nakov";
            //Console.WriteLine(nakov);

            //CourseFactory f = new CourseFactory();
            //ICourse c = f.CreateLocalCourse("Java", null, "Big Hall");
            //Console.WriteLine(c);

            //CourseFactory f = new CourseFactory();
            //ICourse c = f.CreateLocalCourse("Java", f.CreateTeacher("Joro"), "Big Hall");
            //Console.WriteLine(c);

            //CourseFactory f = new CourseFactory();
            //ITeacher joro = f.CreateTeacher("Joro");
            //ICourse c = f.CreateLocalCourse("PHP", joro, "Enterprise");
            //c.AddTopic("Intro PHP");
            //Console.WriteLine(c);

            //CourseFactory f = new CourseFactory();
            //ITeacher joro = f.CreateTeacher("Joro");
            //ICourse php = f.CreateLocalCourse("PHP", joro, "Enterprise");
            //php.AddTopic("Intro PHP");
            //php.AddTopic("PHP Core");
            //php.AddTopic("PHP Advanced Topics");
            //php.AddTopic("PHP Exam");
            //Console.WriteLine(php);
            //ICourse cpp = f.CreateOffsiteCourse("C++", joro, "Ultimate");
            //Console.WriteLine(cpp);
            //Console.WriteLine(joro);

            //CourseFactory f = new CourseFactory();
            //ITeacher joro = f.CreateTeacher("Joro");
            //ICourse php = f.CreateLocalCourse("PHP", joro, "Enterprise");
            //php.AddTopic("Intro PHP");
            //php.AddTopic("PHP Core");
            //php.AddTopic("PHP Advanced Topics");
            //php.AddTopic("PHP Exam");
            //Console.WriteLine(php);
            //ICourse cpp = f.CreateOffsiteCourse("C++", joro, "Ultimate");
            //cpp.AddTopic("Intro C++");
            //cpp.AddTopic("C++ Core");
            //cpp.AddTopic("C++ Advanced Topics");
            //cpp.AddTopic("C++ Exam");
            //Console.WriteLine(cpp);
            //Console.WriteLine(joro);
            //joro.AddCourse(cpp);
            //joro.AddCourse(php);
            //Console.WriteLine(joro);

            //CourseFactory f = new CourseFactory();
            //ITeacher joro = f.CreateTeacher("Joro");
            //ICourse php = f.CreateLocalCourse("PHP", joro, "Enterprise");
            //php.AddTopic("Intro PHP");
            //php.AddTopic("PHP Core");
            //php.AddTopic("PHP Advanced Topics");
            //php.AddTopic("PHP Exam");
            //Console.WriteLine(php);
            //ICourse cpp = f.CreateOffsiteCourse("C++", joro, "Ultimate");
            //cpp.AddTopic("Intro C++");
            //cpp.AddTopic("C++ Core");
            //cpp.AddTopic("C++ Advanced Topics");
            //cpp.AddTopic("C++ Exam");
            //Console.WriteLine(cpp);
            //Console.WriteLine(joro);
            //joro.AddCourse(cpp);
            //joro.AddCourse(php);
            //Console.WriteLine(joro);

            CourseFactory f = new CourseFactory();
            ITeacher joro = f.CreateTeacher("Joro");
            ILocalCourse php = f.CreateLocalCourse("PHP", joro, "Enterprise");
            php.AddTopic("Intro PHP");
            php.AddTopic("PHP Core");
            php.AddTopic("PHP Advanced Topics");
            php.AddTopic("PHP Exam");
            Console.WriteLine(php);
            CourseFactory f2 = new CourseFactory();
            IOffsiteCourse cpp = f2.CreateOffsiteCourse("C++", null, "Ultimate");
            cpp.AddTopic("Intro C++");
            cpp.AddTopic("C++ Core");
            cpp.AddTopic("C++ Advanced Topics");
            cpp.AddTopic("C++ Exam");
            Console.WriteLine(cpp);
            joro.AddCourse(cpp);
            joro.AddCourse(php);
            joro.AddCourse(cpp);
            Console.WriteLine(joro);

            //CourseFactory f = new CourseFactory();
            //ITeacher joro = f.CreateTeacher("Joro");
            //Console.WriteLine(joro);
            //joro.Name = "George";
            //Console.WriteLine(joro);
            //ILocalCourse php = f.CreateLocalCourse("PHP", joro, "Enterprise");
            //Console.WriteLine(php);
            //php.AddTopic("Intro PHP");
            //php.AddTopic("PHP Core");
            //php.AddTopic("PHP Advanced Topics");
            //php.AddTopic("PHP Exam");
            //Console.WriteLine(php);
            //IOffsiteCourse cpp = (new CourseFactory()).CreateOffsiteCourse("C++", joro, "Ultimate");
            //Console.WriteLine(cpp);
            //cpp.AddTopic("Intro C++");
            //cpp.AddTopic("C++ Core");
            //cpp.AddTopic("C++ Advanced Topics");
            //cpp.AddTopic("C++ Exam");
            //Console.WriteLine(cpp);
            //joro.AddCourse(cpp);
            //Console.WriteLine(joro);
            //joro.AddCourse(php);
            //joro.AddCourse(cpp);
            //Console.WriteLine(joro);
            //CourseFactory factory = new CourseFactory();
            //ITeacher nakov = factory.CreateTeacher("Nakov");
            //Console.WriteLine(nakov);
            //nakov.Name = "Svetlin Nakov";
            //Console.WriteLine(nakov);
            //ILocalCourse oop = factory.CreateLocalCourse("OOP", null, "Light");
            //Console.WriteLine(oop);
            //oop.Teacher = nakov;
            //Console.WriteLine(oop);
            //oop.AddTopic("Using Classes and Objects");
            //oop.AddTopic("Defining Classes");
            //oop.AddTopic("OOP Principles");
            //oop.AddTopic("Teamwork");
            //oop.AddTopic("Exam Preparation");
            //Console.WriteLine(oop);
            //ICourse html = factory.CreateOffsiteCourse("HTML", nakov, "Plovdiv");
            //html.AddTopic("Using Classes and Objects");
            //Console.WriteLine(html);
            //html.AddTopic("Defining Classes");
            //html.AddTopic("OOP Principles");
            //Console.WriteLine(html);
            //html.AddTopic("Teamwork");
            //html.AddTopic("Exam Preparation");
            //Console.WriteLine(html);
            //nakov.AddCourse(oop);
            //nakov.AddCourse(html);
            //Console.WriteLine(nakov);
            //oop.Name = "Object-Oriented Programming";
            //(oop as ILocalCourse).Lab = "Enterprise";
            //oop.Teacher = factory.CreateTeacher("George Georgiev");
            //oop.AddTopic("Practical Exam");
            //Console.WriteLine(oop);
            //html.Name = "HTML Basics";
            //(html as IOffsiteCourse).Town = "Varna";
            //html.Teacher = oop.Teacher;
            //html.AddTopic("Practical Exam");
            //Console.WriteLine(html);
            //ICourse css = factory.CreateLocalCourse("CSS", null, "Ultimate");
            //Console.WriteLine(css);
            //for (int i = 0; i < 2; i++)
            //{
            //    joro.AddCourse(oop);
            //    joro.AddCourse(oop);
            //    joro.AddCourse(css);
            //}
            //Console.WriteLine(joro);
            //php.Name = "PHP Avdanced Course";
            //ILocalCourse localPhp = (ILocalCourse)php;
            //localPhp.Lab = "The Very Big Lab";
            //php.Teacher = nakov;
            //php.AddTopic("Final PHP Topic");
            //Console.WriteLine(php);
            //html.Name = "PHP Avdanced Course";
            //IOffsiteCourse offsiteHtml = (IOffsiteCourse)html;
            //offsiteHtml.Town = "The Very Big Lab";
            //html.Teacher = null;
            //html.AddTopic("Final HTML Topic");
            //Console.WriteLine(html.ToString());
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
                  using SoftwareAcademy;

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
