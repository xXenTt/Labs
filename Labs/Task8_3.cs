namespace Labs
{
    internal class Task8_3
    {
        private static void Main(string[] args)
        {
            List<string> annagramms = new List<string> { "code", "doce", "doce", "framer", "frame", "frmae", "frame", "eoj", "joe" };
            GetListWithoutAnnagramms(annagramms);

            foreach (var i in annagramms)
            {
                Console.WriteLine(i);
            }
        }

        private static void GetListWithoutAnnagramms(List<string> annagramms)
        {
            annagramms.Sort();

            for (int i = 0; i < annagramms.Count; i++)
            {
                for (int j = i + 1; j < annagramms.Count; j++)
                    if (IsAnnagram(annagramms[i], annagramms[j]))
                        annagramms[j] = " ";
                if (annagramms[i] == " ")
                    annagramms.Remove(annagramms[i]);
            }
        }

        public static bool IsAnnagram(string one, string two)
        {
            var t1 = one.ToCharArray();
            var t2 = two.ToCharArray();

            Array.Sort(t1);
            Array.Sort(t2);
            return t2.SequenceEqual(t1);
        }
    }
}
