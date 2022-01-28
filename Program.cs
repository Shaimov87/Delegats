using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegats
{
    class Program
    {
        public delegate int RectangleDel(int a, int b);
        public class Rectangle
        {
            public static int S(int a,int b)
            {
                return a * b;
            }

            public static int P(int a,int b)
            {
                return (a + b) * 2;
            }
        }
        static int Sub(int a,int b)
        {
            return a - b;
        }
        static void MakeOperations(RectangleDel all_metods)
        {
            Console.WriteLine("Please, enter a");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please, enter b");
            int b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Result operation {all_metods(a,b)}");
        }
        static void MakeComplexOperation(RectangleDel all_metods)
        {
            Console.WriteLine("Please, enter a");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please, enter b");
            int b = Convert.ToInt32(Console.ReadLine());
            foreach (RectangleDel operation in all_metods.GetInvocationList())
            {
                Console.WriteLine($"Result operation {operation(a, b)}");
            }
        }
        static void Main(string[] args)
        {
            RectangleDel s_rectangle = new RectangleDel(Rectangle.S);
            Console.WriteLine(s_rectangle(2, 5));

            RectangleDel operations = Rectangle.S;
            operations += Rectangle.P;

            RectangleDel all_metods = Sub;
            all_metods += Rectangle.S;
            all_metods += Rectangle.P;

            MakeOperations(all_metods);
            MakeComplexOperation(all_metods);
        }
        
    }
}
