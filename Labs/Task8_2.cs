namespace Labs
{
    internal class Task8_2
    {
        private static void Main(string[] args)
        {
            List<string> annagramms = new List<string> { "code", "doce", "doce", "eoj", "joe" };

            Console.WriteLine("Убираем анаграммы!");

            Console.WriteLine("Before:");
            DisplayList(annagramms);

            RemoveAnnagramms(annagramms);

            Console.WriteLine("After:");

            DisplayList(annagramms);

        }

        private static void DisplayList(List<string> lines)
        {
            foreach (var i in lines)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("========================================");
        }

        private static void RemoveAnnagramms(List<string> list)
        {
            list.Sort();

            for (int x = 0; x < list.Count; x++)
            {
                for (int y = x + 1; y < list.Count; y++)
                {
                    if (IsAnnagram(list[x], list[y]))
                    {
                        list[y] = " ";
                    }
                }

                if (list[x] == " ")
                {
                    list.Remove(list[x]);
                }
            }
        }

        private static bool IsAnnagram(string first, string second)
        {
            var t1 = first.ToCharArray();

            var t2 = second.ToCharArray();

            Array.Sort(t1);

            Array.Sort(t2);

            bool isAnnagramm = t2.SequenceEqual(t1);

            return isAnnagramm;
        }
    }
}
