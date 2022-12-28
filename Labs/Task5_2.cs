namespace Labs
{
    internal class Task5_2
    {
        static void Main(string[] args)
        {
            string numb = "-12k45";

            Console.WriteLine(GetSum(GetClearNumber(numb)));
        }

        static bool IsCorrect(string input)
        {
            var arrayOfChar = input.ToCharArray();

            if (arrayOfChar[0] == '-' || Char.IsDigit(arrayOfChar[0]))
            {
                for (int i = 1; i < arrayOfChar.Length; i++)
                {
                    if (!Char.IsDigit(arrayOfChar[i]))
                    {
                        Console.WriteLine("Number is not in a correct form.");
                        return false;
                    }
                }
            }

            return true;
        }

        static int ToInt(string text)
        {
            int result = 0;
            for (int i = 0; i < text.Length; i++)
            {
                result += ((int)text[text.Length - i - 1] - 48) * (int)Math.Pow(10, i);
            }

            return result;
        }

        static int GetClearNumber(string number)
        {
            if (IsCorrect(number))
            {
                if (number.StartsWith("-"))
                {
                    return ToInt(number.Substring(1));
                }
                else
                {
                    return ToInt(number);
                }
            }

            return 0;
        }

        static int GetSum(int value)
        {
            int result = 0;

            result += value % 10;
            value /= 10;

            if (value > 0)
            {
                result += GetSum(value);
            }

            return result;
        }
    }
}
