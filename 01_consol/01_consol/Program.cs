using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace _01_consol
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int player_act=0;  // 행동 키입력
            int player_act2 = 0; // 스킬 키입력
            Human h1 = new Human(); //Human 클래스 Player h1 생성
            Orc h2 = new Orc(); // Orc 클래스 h2 생성

            h1.TestPrintStatus();
            h2.TestPrintStatus();

            while (true) // 무한루프 
            {
                Console.WriteLine();
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("행동을 결정하세요!");
                Console.WriteLine("1. 일반공격 2. 방어 3. 스킬");
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine();
                string key_press = Console.ReadLine(); // string으로 숫자를 입력 받는다
                int.TryParse(key_press, out player_act); // string으로 입력받은 숫자를 int형으로 변환

                if (player_act == 1)  // 일반공격
                {
                    h1.Attack(h2); // Player가 Orc 공격
                    h2.Attack(h1); // Orc가 Player 공격
                    h1.TestPrintStatus(); // Player 상태
                    h2.TestPrintStatus(); // Orc 상태
                }
                else if (player_act == 2) // 방어
                {
                    h1.Defense();
                    Console.WriteLine($"플레이어가 오크의 공격을 방어했습니다. ( 3턴 )");
                }
                else if (player_act == 3) // 스킬 목록 
                {
                    Console.WriteLine();
                    Console.WriteLine("--------------- 스킬 목록 ---------------");
                    Console.WriteLine("1. 파이어볼");
                    Console.WriteLine("-----------------------------------------");
                    Console.WriteLine();
                    string key_press2 = Console.ReadLine();  // 스킬 키입력
                    int.TryParse(key_press2, out player_act2); // int형 변환
                    if(player_act2 == 1) // 파이어볼 선택
                    {
                        h1.fire_ball(h2); // Player가 파이어볼 공격
                        h2.Attack(h1); // Orc가 Player 공격
                        h1.TestPrintStatus(); // Player 상태
                        h2.TestPrintStatus(); // Orc 상태
                    } 
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다 스킬 사용이 종료됩니다");
                    }

                }
                else
                {
                    Console.WriteLine("잘못된 키입력입니다 다시 입력하세요!");
                }

                if (h1.HP <= 0) // Player의 hp가 0이하일때
                {
                    Console.WriteLine($"--------{h1.Name} 사망--------");
                    break; // 무한루프 break

                }
                else if (h2.HP <= 0) // Orc의 hp가 0이하일때
                {
                    Console.WriteLine($"--------{h2.Name} 사망--------");
                    break; // 무한루프 break
                }
            }


            Console.ReadKey(); // 키입력 대기
        }

    }
}
