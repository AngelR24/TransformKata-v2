using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Class1
    {
        public static string Transform(string word, string todo)
        {
            List<string> x = todo.Split('-', '>').Where(y => y != string.Empty).ToList();

            string ret = word;
            if (String.IsNullOrEmpty(word))
            {
                return word;
            }
            foreach (var item in x)
            {
                if (item.Equals("lower"))
                {
                    ret = Lower(ret);
                }
                if (item.Equals("pack"))
                {
                    ret = Pack(ret);
                }
                if (item.Equals("upper"))
                {
                    ret = Upper(ret);
                }
                if (item.Equals("pascal"))
                {
                    ret = Pascal(ret);
                }
                if (item.Equals("camel"))
                {
                    ret = CamelCase(ret);
                }

            }
            
            return ret;
        }

        public static string Upper(string word)
        {
            return word.ToUpper();
        }

        public static string CamelCase(string word)
        {
            
            return string.Join(" ",word.Split(' ').Select(w => FirstLetterToUpper(w)));
        }

        public static string Pascal(string word)
        {
            if (word.Equals("")) return word;
            bool prevCharSeparador = false;
            char[] characters = word.ToCharArray();

            
            if (word[0] == ' ')
            {
                prevCharSeparador = true;
            }
            else
            {
                characters[0] = Char.ToUpper(characters[0]);
            }

            for (int i = 1; i < word.Length; i++)
            {
                if (word[i] == ' ')
                {
                    prevCharSeparador = true;
                }
                else if(prevCharSeparador)
                {
                    characters[i] = Char.ToUpper(characters[i]);
                    prevCharSeparador = false;
                }
                else
                {
                    characters[i] = Char.ToLower(characters[i]);
                    prevCharSeparador = false;
                }


            }

                //string[] spaces = word.Split(' ')
        //                      .Select(w =>Lower(w))
        //                      .Select(lw => FirstLetterToUpper(lw))
        //                      .ToArray();
        //return string.Join(" ", spaces);
        string x = new string(characters);
        Console.WriteLine(x);
        return x;
    }

        public static string FirstLetterToUpper(string word)
        {
            if (word.Equals("") )
            {
                return word;
            }
            return char.ToUpper(word[0]) + word.Substring(1);
        }

        public static string Lower(string word)
        {
            return word.ToLower();
        }

        public static string Pack(string word)
        {
            return word.Replace(" ", "");
        }
        public static void Main(String[] args)
        {
            string x = string.Empty;
            string y = Transform(x,"pascal");
            Console.WriteLine("Caso 1A: " + (y == string.Empty));


            x = " ";
            y = Transform(x, "pascal");
            Console.WriteLine("Caso 2A: " + (y == " "));

            x = "a";
            y = Transform(x, "pascal");
            Console.WriteLine("Caso 3A: " + (y == "A"));

            x = " a";
            y = Transform(x, "pascal");
            Console.WriteLine("Caso 4A: " + (y == " A"));

            x = "a ";
            y = Transform(x, "pascal");
            Console.WriteLine("Caso 5A: " + (y == "A "));

            x = "a b";
            y = Transform(x, "pascal");
            Console.WriteLine("Caso 6A: " + (y == "A B"));

            x = "  a  b  ";
            y = Transform(x, "pascal");
            Console.WriteLine("Caso 7A: " + (y == "  A  B  "));

            x = "palabra palabra";
            y = Transform(x, "pascal");
            Console.WriteLine("Caso 8A: " + (y == "Palabra Palabra"));

            x = "@**palabra **palabra";
            y = Transform(x, "pascal");
            Console.WriteLine("Caso 9A: " + (y == "@**palabra **palabra"));

            x = "   palabra    c   xd   ";
            y = Transform(x, "pascal");
            Console.WriteLine("Caso 10A: " + (y == "   Palabra    C   Xd   "));

            ////////////
            Console.WriteLine();
            x = "A A A b";
            y = Transform(x, "upper->pack->pascal");
            Console.WriteLine(y);
            Console.WriteLine("Caso 1B: " + (y == "Aaab"));
            x = "    Hola   Mundo";
            y = Transform(x, "pack->pascal");
            Console.WriteLine(y);
            Console.WriteLine("Caso 2A: " + (y == "Holamundo"));
            x = "SALuDO";
            y = Transform(x, "upper->pascal");
            Console.WriteLine(y);
            Console.WriteLine("Caso 2B: " + (y == "Saludo"));
            x = "Esto Es Una Oracion";
            y = Transform(x, "camel->pack->lower");
            Console.WriteLine(y);
            Console.WriteLine("Caso 3A: " + (y == "estoesunaoracion"));
            x = "esto  es  una  oracion";
            y = Transform(x, "camel->lower");
            Console.WriteLine(y);
            Console.WriteLine("Caso 3A: " + (y == x));

            x = "esto es una oracion";
            y = Transform(x, "camel");
            Console.WriteLine(y);
            Console.WriteLine("Caso 3A: " + (y == "Esto Es Una Oracion"));
            Console.ReadKey();
        }
    }
}