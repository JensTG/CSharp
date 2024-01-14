namespace ProjectEuler
{
    public static class Funcs
    {
        public static bool IsPalindrome(long p)
        {
            bool palindrome = true;
            return palindrome;
        }

        public static bool IsPrime(long p)
        {
            bool prime = true;
            for (int i = 2; i < p; i++)
            {
                if (p % i == 0)
                {
                    prime = false;
                    break;
                }
            }
            return prime;
        }
    }
}