using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace HW_25
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь до сборки");
            string pathToAssembly = Console.ReadLine();
            Console.WriteLine("Введите название Бд");
            string databaseName = Console.ReadLine();
            string assemblyLine = $"Create Database{databaseName}";
            Assembly firstAssembly = Assembly.LoadFrom(pathToAssembly);
            foreach (Type type in firstAssembly.GetTypes())
            {
                if (type.IsAbstract)
                {
                    continue;
                }

                foreach (MemberInfo memberinfo in type.GetMembers())//C:\Useдрей\source\repos\HW_25\HW_25\HW_25.csproj
                {
                    var info = memberinfo as PropertyInfo;
                    string bufType = $"{info.PropertyType.Name}";
                    string bufName = info.Name;

                    var dictionary = new Dictionary<string, string>
                    {
                        { "Int32", "int" },
                        { "String", "nvarchar(Max)" },
                        {"Boolean","bit" },
                        {"Int64","int" },
                        {"Double","float" },
                        {"Char","char" },
                        {"DateTime","datetime" },
                        {"id","identity Primary key" },
                    };

                }
                assemblyLine = assemblyLine.Remove(assemblyLine.Length - 1);
                assemblyLine += "\n;\n\n";
            }
            using(var stream = new FileStream("E:\\2.sql",FileMode.OpenOrCreate))
            {
                var bytes = Encoding.UTF8.GetBytes(assemblyLine);
                stream.Write(bytes, 0, bytes.Length);
            }
            Console.WriteLine(assemblyLine);
        }
    }
}
