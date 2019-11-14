using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Janken
{
    class Program
    {
        public static string[] jankenAA = { "ぐー", "ちょき", "ぱー" };

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("最初はグー、じゃんけん…");
                int pjank = Player();
                int cpjank= Cpu();
                Judge(pjank,cpjank);
            }
        }
        public static int Player()
        {
            string janken = null;
            bool loopFlg = true;
            while (loopFlg)
            {
                janken = Console.ReadLine();

                if (!(janken.Equals("0") || janken.Equals("1") || janken.Equals("2")))
                {
                    Console.WriteLine("0か1か2で入れてください。");
                    loopFlg = true;
                }
                else
                {
                    loopFlg = false;
                }
            }
            int jank = int.Parse(janken);
            Display(0,jank);
            return jank;
        }

        public static int Cpu()
        {
            int randomInt = Janken();
            Display(1,randomInt);
            return randomInt;
        }

        public static void Display(int isPlayer,int jank)
        {
            if (isPlayer == 0)
            {
                Console.Write("あなたは、");
            }
            else
            {
                Console.Write("コンピューターは、");
            }
            Console.WriteLine(jankenAA[jank]);
        }

        public static Random rand = new Random();

        public static int Janken()
        {
            int jank = rand.Next(3);
            return jank;
        }

        public static void Judge(int player, int cpu)
        {
            if ((player == 0 && cpu == 1) || (player == 1 && cpu == 2) || (player == 3 && cpu == 0))
            {
                Console.WriteLine("プレイヤーが勝ち");
            }
            else if ((cpu == 0 && player == 1) || (cpu == 1 && player == 2) || (cpu == 3 && player == 0))
            {
                Console.WriteLine("CPUが勝ち");
            }
            else
            {
                Console.WriteLine("あいこ");
            }
            Console.ReadKey(true);
        }
    }
}
