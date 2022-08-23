using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_consol
{
    public class Orc : Character // Character클래스 상속
    {
        int madness = 0; // 광기를 저장한 변수
        int maxMadness = 100;

        public Orc() // 생성자 
        {
            name = "오크"; // name = 오크 고정
        }

        public override void TestPrintStatus() // 광기가 추가된 상태창
        {
            Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
            Console.WriteLine($"┃ 이름\t:오크");
            Console.WriteLine($"┃ HP\t:{hp,4} / {maxHP,4}");
            Console.WriteLine($"┃ 힘\t:{strenth,2}");
            Console.WriteLine($"┃ 민첩\t:{dexterity,2}");
            Console.WriteLine($"┃ 지능\t:{intellegence,2}");
            Console.WriteLine($"┃ 광기\t:{madness,4} / {maxMadness,4}");
            Console.WriteLine("┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");

        }
        public  override void TakeDamage(int damage) // Character의 TakeDamage함수 재정의
        {
            if (madness == 100) // 광기 100
            {
                hp -= (damage + 5); // 받는피해 5 감소
            }
            else
            {
                hp -= damage; // 광기가 100이아니면 데미지는 그대로
                Madness_Skill(); // 광기가 쌓이는 함수
            }
            Console.WriteLine($"{name}이 {damage}만큼의 피해를 입었습니다.");
        }

        public override void Attack(Character target) // 재정의한 Attack함수
        {
            int damage = strenth;

            
            if (madness >= 100) // 광기100 이상이면 데미지 5덜받는다
            {
                damage = (damage + 5);
                target.TakeDamage(damage);
                Console.WriteLine("광분 상태라서 데미지가5 증가 됩니다.");
                Console.WriteLine($"{name}가 {target.Name}에게 {damage}만큼 피해를 입혔습니다.(공격력 : {damage} )");
            }
            else
            {
                target.TakeDamage(damage);
                Console.WriteLine($"{name}가 {target.Name}에게 {damage}만큼 피해를 입혔습니다.(공격력 : {damage})");

            }
        }

        public void Madness_Skill() // hp가 깎이면 그와동시에 광기 게이지 깎인 hp만큼 증가
        {
            if (madness < 100)
            {
                madness = (maxHP-hp);
            }
            else
            {
                madness = 100;
            }
        }


    }


}



/*1. Orc 클래스 완성하기
    1.1 오크만의 변수 추가하기
    1.2 오크만의 함수 추가하기
2. Human 클래스 수정하기
    2.1 스킬 함수 만들기
3. 입력에 따라 행동하는 player 만들기
    3.1 공격 스킬 방어 3개중 하나를 입력받아서 그대로 행동하게 만들기
4. player와 enemy가 싸우게 만들기 */
