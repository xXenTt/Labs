using System.Timers;

namespace Labs
{
    internal class Task8_1
    {
        private static void Main(string[] args)
        {
            string path = Environment.CurrentDirectory + "\\Subtitles.txt";
            var fileStrings = File.ReadAllLines(path);

            SubtitleConverter converter = new SubtitleConverter();
            var subtitles = converter.GetConvertedSubtitles(fileStrings);
            SubtitleDisplay display = new SubtitleDisplay(subtitles);

            display.Start();

            Console.ReadLine();
            {
                    internal class Screen
        {
            public Subtitle[] Subs;

            public static int CurrSecond = 0;

            public void Start()
            {
                System.Timers.Timer timer = new System.Timers.Timer(1000);

                timer.Elapsed += OneSecond;

                timer.AutoReset = true;

                timer.Enabled = true;
            }
            public void OneSecond(Object obj, ElapsedEventArgs e)
            {
                foreach (var subtitle in Subs)
                {
                    if (subtitle.SubtitleStart == CurrSecond) WriteSub(subtitle);
                    else if (subtitle.SubtitleEnd == CurrSecond) RemoveSub(subtitle);
                }
                CurrSecond++;
            }
            private void WriteSub(Subtitle subtitle)
            {
                SetPlace(subtitle);
                Console.Write(subtitle.SubtitleText);

            }
            private void SetPlace(Subtitle subtitle)
            {
                switch (subtitle.DisplaySide)
                {
                    case "Right":
                        Console.SetCursorPosition(RightPos(subtitle)[0], RightPos(subtitle)[1]);

                        break;
                    case "Left":
                        Console.SetCursorPosition(LeftPos(subtitle)[0], LeftPos(subtitle)[1]);

                        break;
                    case "Bottom":
                        Console.SetCursorPosition(BottomPos(subtitle)[0], BottomPos(subtitle)[1]);

                        break;
                    case "Top":
                        Console.SetCursorPosition(TopPos(subtitle)[0], TopPos(subtitle)[1]);

                        break;
                    default:

                        break;
                }
            }

            private void RemoveSub(Subtitle subtitle)
            {
                SetPlace(subtitle);
                for (int i = 0; i < subtitle.SubtitleText.Length; i++)
                    Console.Write(" ");
            }

            private int[] RightPos(Subtitle sub)
            {
                int centerX = Console.WindowWidth - (sub.SubtitleText.Length);
                int centerY = (Console.WindowHeight / 2) - (sub.SubtitleText.Length) + 1;

                return new int[] { centerX, centerY };
            }

            private int[] LeftPos(Subtitle sub)
            {
                int centerX = sub.SubtitleText.Length;
                int centerY = (Console.WindowHeight / 2) - (sub.SubtitleText.Length);

                return new int[] { centerX, centerY };
            }

            private int[] BottomPos(Subtitle sub)
            {
                int centerX = (Console.WindowWidth / 2) - (sub.SubtitleText.Length / 2);
                int centerY = Console.WindowHeight - 2;

                return new int[] { centerX, centerY };
            }

            private int[] TopPos(Subtitle sub)
            {
                int centerX = (Console.WindowWidth / 2) - (sub.SubtitleText.Length / 2);
                int centerY = 1;

                return new int[] { centerX, centerY };
            }

            public Screen(Subtitle[] subtitles)
            {
                this.Subs = subtitles;
                {
                       class SubtileWork
            {
                private Subtitle[] subs;
                public Subtitle[] ConvertSubs(string[] subtitles)
                {
                    subs = new Subtitle[subtitles.Length];
                    for (int i = 0; i < subtitles.Length; i++)
                    {
                        subs[i] = ParseTextToSub(subtitles[i]);
                    }
                    return subs;
                }
                public Subtitle ParseTextToSub(string text)
                {
                    string[] parts = text.Split(" ");

                    double start = Convert.ToDouble(parts[0].Split(":")[0]) * 60 + Convert.ToDouble(parts[0].Split(":")[1]);

                    double ending = Convert.ToDouble(parts[2].Split(":")[0]) * 60 + Convert.ToDouble(parts[2].Split(":")[1]);

                    string screenSide = "";

                    string consoleColor = "";

                    string subTxt = "";

                    if (parts[3].StartsWith("["))
                    {
                        screenSide = parts[3].Substring(1, parts[3].Length - 2);

                        consoleColor = parts[4].Substring(0, parts[4].Length - 1);

                        for (int i = 5; i < parts.Length; i++)
                            subTxt += parts[i];
                        return new Subtitle(start, ending, screenSide, consoleColor, subTxt);
                    }
                    for (int i = 3; i < parts.Length; i++)
                        subTxt += parts[i] + " ";



                    return new Subtitle(start, ending, screenSide, consoleColor, subTxt);
                }
            }

            class Subtitle
            {
                public double SubtitleStart { get; set; }
                public double SubtitleEnd { get; set; }
                public string DisplaySide { get; set; }
                public string SubtitleColor { get; set; }
                public string SubtitleText { get; set; }

                public Subtitle(double start, double endTime, string screenSide, string consoleColor, string text)
                {
                    SubtitleStart = start;
                    SubtitleEnd = endTime;
                    DisplaySide = screenSide;
                    SubtitleColor = consoleColor;
                    SubtitleText = text;

                    if (DisplaySide == "")
                    {
                        DisplaySide = "Bottom";
                    }

                    if (SubtitleColor == "")
                    {
                        SubtitleColor = "White";
                    }
                }
            }
        }
    }
}
