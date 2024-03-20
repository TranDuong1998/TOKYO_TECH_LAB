internal class Program
{
    static void Main(string[] args)
    {
        do
        {
            Console.WriteLine("1. Test Diablo");
            Console.WriteLine("2. Test Giao huu bong da");
            Console.WriteLine("3. Test Can bang ngoac");
            Console.WriteLine("4. Esit");
            int choose = InputNumber("Choose the Test number");

            switch (choose)
            {
                case 1:
                    int m, d, k, c;
                    do
                    {
                        m = InputNumber("Input number of boss");

                        if (m <= 0 || m > 1000)
                        {
                            Console.WriteLine("Invalid.");
                        }

                    } while (m <= 0 || m > 1000);
                    do
                    {
                        d = InputNumber("Input durability of sword");

                        if (d <= 0 || d > 1000)
                        {
                            Console.WriteLine("Invalid.");
                        }

                    } while (d <= 0 || d > 1000);
                    do
                    {
                        k = InputNumber("Input durability decreases");
                        if (k <= 0 || k > 1000)
                        {
                            Console.WriteLine("Invalid.");
                        }

                    } while (k <= 0 || k > 1000);
                    do
                    {
                        c = InputNumber("Input restoring gold");
                        if (c <= 0 || c > 1000)
                        {
                            Console.WriteLine("Invalid.");
                        }

                    } while (c <= 0 || c > 1000);

                    Diablo(m, d, k, c);

                    break;
                case 2:
                    int testCase, x, y;
                    do
                    {
                        testCase = InputNumber("Input number of test case");
                        if (testCase <= 0 || testCase > 100)
                        {
                            Console.WriteLine("Invalid Test Case.");
                        }

                    } while (testCase <= 0 || testCase > 100);

                    string[] test = new string[testCase];

                    for (int i = 0; i < test.Length; i++)
                    {
                        test[i] = Console.ReadLine();
                    }

                    for (int i = 0; i < test.Length; i++)
                    {
                        string[] s = test[i].Split(' ');
                        x = int.Parse(s[0]);
                        y = int.Parse(s[1]);
                        if ((x >= 0 && y >= 0) || (x <= 10 && y <= 10))
                            Console.WriteLine(TinhSoCachGhiBan(x, y));
                    }

                    break;
                case 3:
                    int n;
                    do
                    {
                        n = InputNumber("Input number of test case");
                        if (n <= 0 || n > 100)
                        {
                            Console.WriteLine("Invalid Test Case.");
                        }

                    } while (n <= 0 || n > 100);

                    string[] str = new string[n];

                    for (int i = 0; i < str.Length; i++)
                    {
                        str[i] = Console.ReadLine();
                    }

                    Console.WriteLine("Result:");
                    for (int i = 0; i < str.Length; i++)
                    {
                        if (CanBangNgoac(str[i]))
                            Console.WriteLine("true");
                        else
                            Console.WriteLine("false");
                    }
                    break;
                case 4:
                    Console.WriteLine("Exit!");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Please input number from 1 -> 4!");
                    break;
            }

        } while (true);
    }

    public static int InputNumber(string mess)
    {
        do
        {
            Console.Write(mess + ": ");
            var number = Console.ReadLine();
            if (int.TryParse(number, out int num))
            {
                return num;
            }
            else
            {
                Console.WriteLine("Invalid number!");
            }
        } while (true);
    }

    static bool CanBangNgoac(string str)
    {
        if (str.Length > 100000)
            return false;

        List<char> chars = new List<char>();

        if (str.Length == 0)
        {
            return true;
        }
        foreach (char c in str)
        {
            if (c == '(' || c == '[' || c == '{')
            {
                chars.Add(c);
            }
            else if (c == ')' || c == ']' || c == '}')
            {
                if (chars.Count == 0)
                    return false;

                char top = chars[chars.Count - 1];
                if ((c == ')' && top != '(') || (c == ']' && top != '[') || (c == '}' && top != '{'))
                    return false;
                else
                    chars.Remove(top);
            }
        }
        return chars.Count == 0;
    }

    static void Diablo(int boss, int durability, int decreases, int gold)
    {
        int killed = 0;
        int d = durability;
        int goldNeeded = 0;

        while (killed < boss)
        {
            if (d <= 0)
            {
                Console.WriteLine("-1");
                return;
            }

            killed++;
            d -= decreases;

            if (d == 1)
            {
                goldNeeded += gold;
                d = durability;
            }
        }

        Console.WriteLine(goldNeeded);

    }

    static long TinhSoCachGhiBan(int x, int y)
    {
        if (x == 0 && y == 0)
            return 1;

        if (x < 0 || y < 0)
            return 0;

        return TinhSoCachGhiBan(x - 1, y) + TinhSoCachGhiBan(x, y - 1);
    }
}