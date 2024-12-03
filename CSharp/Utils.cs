namespace CSharp
{
    internal static class Utils
    {
        public static int GetCorrectIntNumber(string welcomeMessage, int min, int max)
        {
            int value;
            while (true)
            {
                Console.Write(welcomeMessage);
                string? input = Console.ReadLine();
                if (int.TryParse(input, out value))
                {
                    if (value >= min && value <= max)
                    {
                        return value;
                    }
                    else
                    {
                        Console.WriteLine($"**Число должно находиться в диапазоне {min}..{max}, пожалуйста, повторите");
                    }
                }
                else
                {
                    Console.WriteLine("**Неверное ввод, пожалуйста, повторите");
                }
            }
        }

        public static string GetCorrectString(string welcomeMessage)
        {
            string str;
            while (true) {
                Console.Write(welcomeMessage);
                str = Console.ReadLine()!;
                if (string.IsNullOrEmpty(str))
                {
                    Console.WriteLine("**Неверное ввод, пожалуйста, повторите");
                }
                else
                {
                    break;
                }
            };

            return str;
        }
    }
}
