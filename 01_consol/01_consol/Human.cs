using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_consol
{
    internal class Human : Character // Character 클래스 상속
    {
        int mp = 100; // 마나
        int maxMP = 100; // 총 마나
        const int DefenseCount = 3; // 방어 턴
        public int remainsDefenseCount = 0; // 방어 턴 계산함수
        public Human()
        {
            
        }

        protected override void GenerateStatus() // Human 내에서 수정되어 사용할 계산 함수
        {
            base.GenerateStatus(); // 베이스는 Character에 GenrateStatus를 사용한다
            maxMP = rand.Next() % 100; // mp를 0~100 값까지 랜덤하게 배정
            mp = maxMP; // 현재마나 = 최대마나
        }

        public override void TestPrintStatus() // mp가 추가된 상태창
        {
            Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
            Console.WriteLine($"┃ 이름\t:{name}");
            Console.WriteLine($"┃ HP\t:{hp,4} / {maxHP,4}");
            Console.WriteLine($"┃ MP\t:{mp,4} / {maxMP,4}");
            Console.WriteLine($"┃ 힘\t:{strenth,2}");
            Console.WriteLine($"┃ 민첩\t:{dexterity,2}");
            Console.WriteLine($"┃ 지능\t:{intellegence,2}");
            Console.WriteLine("┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");

        }

        public override void Attack(Character target) // Human에서 재정의할 Attack 함수
        {
            int damage = strenth;

            if(rand.NextDouble() < 0.3f) // 30%의 확률로 크리티컬히트(2배데미지)
            {
                damage *= 2;
                Console.WriteLine("크리티컬 히트!!");
            }
            target.TakeDamage(damage); // Character함수에 TakeDamage함수사용 -> 상속받아서 사용가능
            Console.WriteLine($"{name}가 {target.Name}에게 {damage}만큼 피해를 입혔습니다.(공격력 : {damage})");
        }

        public void fire_ball(Character target) // 파이어볼 함수
        {
            int damage_fiare_ball = (intellegence + 5) * 3; // (지능+5)x3의 데미지
            if(mp >= 20)
            {
                target.TakeDamage(damage_fiare_ball); // Character함수에 TakeDamage함수사용 -> 상속받아서 사용가능
                mp -= 20;
                Console.WriteLine("☆★☆★☆★ player가 mp 20을 사용해서 파이어볼스킬 사용 ☆★☆★☆★");
            }
            else 
            {
                Console.WriteLine("파이어볼을 사용하기엔 mp가 부족합니다( 파이어볼 -> 20mp 소모 )");
            }
        }

        public void Defense() // 방어함수
        {
            Console.WriteLine($"3턴간 받는 데미지 반감");
            remainsDefenseCount += DefenseCount; // 방어를 선택하게 된다면 방어턴이 +3이 된다.
        }

        public override void TakeDamage(int damage)
        {
            if (remainsDefenseCount > 0)
            {
                Console.WriteLine($"방어 발동! 받는 데미지가 절반 감소합니다. ( {remainsDefenseCount}턴 )");
                remainsDefenseCount--; // 방어턴 1씩 감소
                damage = damage >> 1; // 비트연산자 1칸 오른쪽으로 이동하면 절반이 줄어든다 대신
            }
            base.TakeDamage(damage);
        }


    }
}
