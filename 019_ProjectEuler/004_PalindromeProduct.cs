namespace ProjectEuler
{
    using static Funcs;
    using static System.Console;
    class PalindromeProduct
    {
        static void Main()
        {
            long largest = 0;

            for (int i = 1; i < 1000; i++)
            {
                for (int j = 1; j < 1000; j++)
                {
                    if (IsPalindrome((i * j).ToString())) largest = (i * j) > largest ? (i * j) : largest;
                }
            }

            WriteLine("Largest palindrome: {0}", largest);
        }
    }
}