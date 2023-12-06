using System.Diagnostics.CodeAnalysis;

namespace Opgaver {
    public static class Basic {
        public static void Opgave1() {
            Console.WriteLine("Hello: Jens Graversen");
        }
        public static void Opgave2() {
            int x = 2;
            int y = 3;
            Console.WriteLine("x = {0}\ny = {1}\nx * y = {1}", x, y, x * y);
        }
        public static void Opgave3() {
            int x = 4;
            int y = 2;
            Console.WriteLine("x = {0}\ny = {1}\nx / y = {1}", x, y, x / y);
        }
        public static void Opgave4() {
            int a = -1 + 4 * 6;
            int b = ( 35+ 5 ) % 7;
            int c = 14 + -4 * 6 / 11;
            int d = 2 + 15 / 6 * 1 - 7 % 2;
            Console.WriteLine("-1 + 4 * 6 = {0}\n" +
                "( 35+ 5 ) % 7 = {1}\n"+ 
                "14 + -4 * 6 / 11 = {2}\n" +
                "2 + 15 / 6 * 1 - 7 % 2 = {3}\n", a, b, c, d
                );
        }
        public static void Opgave5() {
            Console.WriteLine("Please input the first number:");
            string? x = Console.ReadLine();
            Console.WriteLine("Please input the second number");
            string? y = Console.ReadLine();
            Console.WriteLine("Inputs: {0} and {1}", x, y);
            string z = x;
            x = y;
            y = z;
            Console.WriteLine("Swapped: {0} and {1}", x, y);
        }
        public static void Opgave6() {
            Console.WriteLine("Please input 2 numbers:");
            int x = Int32.Parse(Console.ReadLine());
            int y = Int32.Parse(Console.ReadLine());
            int z = Int32.Parse(Console.ReadLine());
            Console.WriteLine($"");
        }
        public static void Opgave7() {
            Console.WriteLine("Please input 2 numbers:");
            int x = Int32.Parse(Console.ReadLine());
            int y = Int32.Parse(Console.ReadLine());
            Console.WriteLine($"25 + 4 = {x + y}\n"+
                $"{x} - {y} = {x - y}\n"+
                $"{x} * {y} = {x * y}\n"+
                $"{x} / {y} = {x / y}\n"+
                $"{x} % {y} = {x % y}\n"
            );
        }
        public static void Opgave8() {
            Console.Write("Please input a number: ");
            int x = Int32.Parse(Console.ReadLine());
            for(int i = 1; i < 11; i++) {
                Console.WriteLine($"{x} * {i} = {x*i}");
            }
        }
        public static void Opgave9() {
            Console.WriteLine("Please input 4 numbers:");
            int[] x = new int[4];
            x[0] = Int32.Parse(Console.ReadLine());
            x[1] = Int32.Parse(Console.ReadLine());
            x[2] = Int32.Parse(Console.ReadLine());
            x[3] = Int32.Parse(Console.ReadLine());
            int sum = 0;
            foreach(int y in x) {
                sum += y;
            }
            float mean = sum/4;
            Console.WriteLine("Mean: {0}", mean);
        }
        public static void Opgave10() {
            Console.WriteLine("Please input 3 numbers:");
            int[] x = new int[4];
            x[0] = Int32.Parse(Console.ReadLine());
            x[1] = Int32.Parse(Console.ReadLine());
            x[2] = Int32.Parse(Console.ReadLine());
            Console.WriteLine($"({x[0]} + {x[1]}) * {x[2]} = {(x[0]+x[1])*x[2]}");
            Console.WriteLine($"{x[0]} * {x[1]} + {x[1]} * {x[2]} = {x[0] * x[1] + x[1] * x[2]}");
        }
        public static void Opgave11() {
            Console.WriteLine("How old are you?");
            if(Int32.Parse(Console.ReadLine()) < 40) {
                Console.ForegroundColor = ConsoleColor.Green;
                string doubt = File.ReadAllText("C:\\VSC_PRO_B\\CSharp\\013_Basics\\doubt.txt");
                Console.WriteLine(doubt);
                Console.ResetColor();
                return;
            }
            Console.WriteLine("Seems reasonable");
        }
        public static void Opgave12() {
            
        }
        public static void Opgave13() {
            
        }
        public static void Opgave14() {
            
        }
    }
    public static class DataTypes {

    }
}