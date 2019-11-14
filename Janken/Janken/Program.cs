using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Janken
{
    public class Program
    {
        public static string[] jankenAA = { "ぐー", "ちょき", "ぱー" };

        public static void Main(string[] args)
        {
            Console.WriteLine("※説明：最初に何回じゃんけんをするか回数を入力する。\nその後、回数分の自分の出すじゃんけん数値を入れる。\nグー＝0、チョキ＝1、パー＝2");
            try
            {
                int n = int.Parse(Console.ReadLine());

                int[] jankMe = new int[n];

                for (int i = 0; i < n; i++)
                {
                    string jankme = Console.ReadLine();
                    if (!(jankme.Equals("0") || jankme.Equals("1") || jankme.Equals("2")))
                    {
                        Console.WriteLine("じゃんけん番号じゃないです");
                        i -= 1;
                        continue;
                    }
                    jankMe[i] = int.Parse(jankme);
                }

                for (int j = 0; j < n; j++)
                {
                    //Console.Clear();
                    Console.WriteLine("最初はグー、じゃんけん…");
                    int pjank = Player(jankMe[j]);
                    int cpjank = Cpu();
                    Judge(pjank, cpjank);
                }
                Statistics(judgeList);
                Console.ReadKey(true);

            }
            catch (Exception e)
            {
                string m = e.Message;
                Console.WriteLine(m);
                Console.ReadKey(true);
            }
        }
        /// <summary>
        /// プレイヤー
        /// </summary>
        /// <returns>じゃんけん番号</returns>
        public static int Player(int jankMeNow)
        {
            string janken = null;
            bool loopFlg = true;

            //while (loopFlg)
            //{
            //janken = Console.ReadLine();
            janken = jankMeNow.ToString();
            if (!(janken.Equals("0") || janken.Equals("1") || janken.Equals("2")))
            {
                Console.WriteLine("0か1か2で入れてください。");
                loopFlg = true;
            }
            else
            {
                loopFlg = false;
            }
            //}
            int jank = int.Parse(janken);
            Display(0, jank);
            return jank;
        }

        /// <summary>
        /// CPU
        /// </summary>
        /// <returns>じゃんけん番号</returns>
        public static int Cpu()
        {
            int randomInt = Janken();
            Display(1, randomInt);
            return randomInt;
        }

        /// <summary>
        /// 画面への表示
        /// </summary>
        /// <param name="isPlayer"></param>
        /// <param name="jank"></param>
        public static void Display(int isPlayer, int jank)
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

        /// <summary>
        /// ランダム関数
        /// </summary>
        public static Random rand = new Random();

        /// <summary>
        /// CPUがランダムで出すじゃんけんの関数
        /// </summary>
        /// <returns>ランダムで出した数</returns>
        public static int Janken()
        {
            int jank = rand.Next(3);
            return jank;
        }

        /// <summary>
        /// ジャッジ
        /// </summary>
        /// <param name="player"></param>
        /// <param name="cpu"></param>
        
        public static List<int> judgeList = new List<int>();

        public static void Judge(int player, int cpu)
        {
            int judge = 0;

            if ((player == 0 && cpu == 1) || (player == 1 && cpu == 2) || (player == 2 && cpu == 0))
            {
                Console.WriteLine("プレイヤーが勝ち");
                judge = 0;
            }
            else if ((cpu == 0 && player == 1) || (cpu == 1 && player == 2) || (cpu == 2 && player == 0))
            {
                Console.WriteLine("CPUが勝ち");
                judge = 1;
            }
            else
            {
                Console.WriteLine("あいこ");
                judge = 2;
            }
            judgeList.Add(judge);
            Console.Write("\n");
        }
        public static void Statistics(List<int> jlist)
        {
            int playerWin = jlist.Where(j=>j==0).Count();
            int cpuWin = jlist.Where(j=>j==1).Count();
            int draw = jlist.Where(j => j == 2).Count();
            Console.WriteLine(string.Format("プレイヤーの勝利数:{0}\nCPUの勝利数:{1}\nあいこ数:{2}", playerWin,cpuWin,draw));
        }
    }
}
