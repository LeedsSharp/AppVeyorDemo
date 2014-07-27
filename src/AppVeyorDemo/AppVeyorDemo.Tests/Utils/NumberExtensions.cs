namespace AppVeyorDemo.Tests.Utils
{
    using System;

    public static class NumberExtensions
    {
        public static bool IsPrime(this int number)
        {
            var boundary = Math.Floor(Math.Sqrt(number));

            if (number == 1) return false;
            if (number == 2) return true;

            for (var i = 2; i <= boundary; ++i)
            {
                if (number % i == 0) return false;
            }

            return true;
        }
    }
}
