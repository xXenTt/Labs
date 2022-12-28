namespace Labs
{
    internal class Task5_4
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            if (IsStringCorrect(input))
            {
                var array = ParseToArray(input);
                var changedArray = GetChangedArray(array);

                foreach (var item in changedArray)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("Original array:");

                foreach (var item in array)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("Work is finished.");
            }
            else
            {
                Console.WriteLine("Your input is invalid, try again later.");
            }
        }

        private static bool IsStringCorrect(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (!Char.IsDigit(input[i]) && input[i] != ' ' && input[i] != ',' && input[i] != '-')
                {
                    return false;
                }
            }

            return true;
        }

        private static double[] ParseToArray(string input)
        {
            string[] strings = input.Split(" ");
            double[] parsedArray = new double[strings.Length];

            for (int i = 0; i < strings.Length; i++)
            {
                parsedArray[i] = double.Parse(strings[i]);
            }

            return parsedArray;
        }

        private static double[] GetChangedArray(double[] array)
        {
            double[] changedArray = new double[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                if (IsNumberInteger(array[i]) && IsNumberPositive(array[i])) changedArray[i] = GetFactorial(array[i]);
                else if (IsNumberInteger(array[i]) && !IsNumberPositive(array[i])) changedArray[i] = array[i];
                else changedArray[i] = GetRoundedPartOfDouble(array[i]);
            }

            return changedArray;
        }

        private static double GetFactorial(double n)
        {
            if (n == 1) return 1;

            return n * GetFactorial(n - 1);
        }

        private static double GetRoundedPartOfDouble(double number)
        {
            number = Math.Round(number, 2);

            string[] parts = (number.ToString()).Split(',');

            return double.Parse(parts[1]);
        }

        private static bool IsNumberInteger(double number)
        {
            return number == (int)number;
        }

        private static bool IsNumberPositive(double number)
        {
            return number > 0;
        }
    }
}
