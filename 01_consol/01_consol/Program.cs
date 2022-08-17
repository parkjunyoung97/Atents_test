using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _01_consol
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sumResult = Sum(10, 20);
            Console.WriteLine(sumResult);

            string name = "너굴맨";
            int level = 2;
            int hp = 10;
            int maxHP = 20;
            float exp = 0.1f;
            float maxExp = 1.0f;

            status_user(name, level, hp, maxHP, exp, maxExp);


            Console.ReadKey();
        }
        static int Sum(int a, int b) // 함수의 구성요소 : 이름,리턴타입,파라메터(매개변수),함수바디
        {
            int result = a + b;
            return result;
        }

        static void status_user(string name, int level, int hp, int maxHP, float exp, float maxExp)
        {
            Console.WriteLine($"아이디 : {name}");
            Console.WriteLine($"레벨 : {level}");
            Console.WriteLine($"HP : {hp}");
            Console.WriteLine($"maxHP : {maxHP}");
            Console.WriteLine($"현재 경험치 : {exp}");
            Console.WriteLine($"레벨업까지 필요 경험치 : {maxExp-exp}");
        }

        static void Test()
        {
            Console.WriteLine("PARK JUN YOUNG"); // 실습1 : 자기 이름 출력해보기 
            //string str = Console.ReadLine();  // 입력
            //Console.WriteLine(str);           // 출력

            /*int level_real;
            int hp_real;
            float exp_real;

            Console.Write("이름을 입력하세요 : ");
            String name = Console.ReadLine();
            Console.Write("레벨을 입력하세요 : ");
            string level = Console.ReadLine();
            Console.Write("hp를 입력하세요 : ");
            string hp = Console.ReadLine();
            Console.Write("exp를 입력하세요 : ");
            string exp = Console.ReadLine();

            int.TryParse(level, out level_real);
            int.TryParse(hp, out hp_real);
            float.TryParse(exp, out exp_real);


            Console.WriteLine($"{name}의 레벨은 {level_real}이고 HP는 {hp_real}이고 exp는 {exp_real * 100:F2}% 다.");*/

            // 제어문 ---------------------------------------------

            /*float exp = 0.5454f;
            float exp2;
            Console.WriteLine("경험치를 추가합니다.");
            Console.Write("추가할 경험치 : ");
            string tamp = Console.ReadLine();
            float.TryParse(tamp, out exp2);

            //실습 : exp에 있는 값과 추가로 입력받은 경험치의 합이 1이 넘어가면 레벨업 출력 1미만이면 현재경험치 출력
            if (exp + exp2 >= 1)
            {
                Console.WriteLine("레벨업");
            }
            else
            {
                Console.WriteLine($"{(exp*100) + (exp2*100)}%");
            }
            */

            //실습 : EXP가 1을 넘어 레벨업을 할때까지 계속 추가 경험치를 입력하도록 하는 코드

            /*float exp = 0.5454f;
            float exp2;
            float total_exp = exp;
;
            while (true)
            {
                Console.WriteLine("경험치를 추가합니다.");
                Console.Write("추가할 경험치 : ");
                string tamp = Console.ReadLine();
                float.TryParse(tamp, out exp2);

                total_exp += exp2;
                if(total_exp > 1.0)
                {
                    Console.WriteLine("레벨업");
                    Console.WriteLine($"현재 경험치 : {total_exp-1:f3}");
                    break;
                }
                Console.WriteLine($"현재 경험치 : {total_exp:f3}");
            }*/


            //Console.ReadKey();
        }
    }
}
