using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_consol
{
    public class Character
    {
        protected int hp = 100;
        protected int maxHP = 100;
        protected int strenth = 10;
        protected int dexterity = 5;
        protected int intellegence = 7;
        protected string name;
        public string Name => name;

        protected string[] nameArray = { "너굴맨","개굴맨", "C#어렵넹", "파이썬이행복했다", "구해줘" };

        protected Random rand;
        bool isDead = false;
        public bool IsDead => isDead;


        public int HP
        {
            get
            {
                return hp;
            }

            private set
            {
                hp = value;
                if(hp>maxHP)
                {
                    hp = maxHP;
                }
                if(hp<=0)
                {
                    Console.WriteLine($"{name}사망");
                    isDead = true;
                }
            }
        }

        private void Dead()
        {
            Console.WriteLine($"{name}이 사망");
            isDead = true;
        }
        public Character()
        {
            rand = new Random(DateTime.Now.Millisecond);
            int randomNumber = rand.Next(0,4);

            name = nameArray[randomNumber];

            GenerateStatus();
        }

        public Character(string newName)
        {
            rand = new Random(DateTime.Now.Millisecond);

            name = newName;
            GenerateStatus();
        }

        public virtual void Attack(Character target)
        {
            int damage = strenth;
            target.TakeDamage(damage);
            Console.WriteLine($"{name}이 {target.name}에게 {damage}만큼 피해를 입혔습니다.(공격력 : {damage})");

        }
        public virtual void TakeDamage(int damage)
        {
            HP -= damage;
            Console.WriteLine($"{name}이 {damage}만큼의 피해를 입었습니다.");
        }

        public virtual void TestPrintStatus()
        {
            Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
            Console.WriteLine($"┃ 이름\t:\t{name}");
            Console.WriteLine($"┃ HP\t:\t{hp,4} / {maxHP,4}");
            Console.WriteLine($"┃ 힘\t:\t{strenth,2}");
            Console.WriteLine($"┃ 민첩\t:\t{dexterity,2}");
            Console.WriteLine($"┃ 지능\t:\t{intellegence,2}");
            Console.WriteLine("┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");

        }

        protected virtual void GenerateStatus()
        {

            maxHP = rand.Next(100, 201);    // 100에서 200 중에 랜덤으로 선택
            hp = maxHP;

            strenth = rand.Next(20) + 1;    // 1~20 사이를 랜덤하게 선택
            dexterity = rand.Next(20) + 1;  // 1~20 사이를 랜덤하게 선택
            intellegence = rand.Next(20) + 1;  // 1~20 사이를 랜덤하게 선택
        }

    }
}
