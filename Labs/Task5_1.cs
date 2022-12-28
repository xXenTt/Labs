namespace Labs
{
    internal class Task5_1
    {
        public static void Run()
        {
            string previousInput = "0";
            for (; ; )
            {
                string input = Console.ReadLine();

                if (input == "") continue;
                else if (input == "q") break;

                if (int.TryParse(input, out int result)) Console.WriteLine((char)result);
                if (Convert.ToDouble(input) == Convert.ToDouble(previousInput)) break;

                previousInput = input;
            }

        }
    }
}
