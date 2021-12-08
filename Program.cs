using System;
using System.Collections.Generic;
using System.Linq;

namespace ExDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Dictionary<string, string> dic = new Dictionary<string, string>();

            // 값 추가
            dic.Add("빨강", "red");
            dic.Add("파랑", "blue");

            // element 수
            Console.WriteLine("Dictionary 수 : {0}", dic.Count);

            // key 체크
            if (dic.ContainsKey("빨강"))
            {
                Console.WriteLine("빨강이 있음");
            }
                
            foreach (var key in dic.Keys)
            {
                Console.WriteLine("{0} 은 영어로 {1} 입니다.", key, dic[key]);
            }

            // 이미 있는 값 변경.
            dic["파랑"] = "BLUE";

            // red 가 한글로 뭔지 찾기 ( Value 로 Key 찾기 )
            string red_to_kor = dic.Where(w => w.Value == "red").Select(s => s.Key).FirstOrDefault();
            Console.WriteLine("red 는 한글로 {0} 입니다.", red_to_kor);

            Dictionary<int, Person> dicPerson = new Dictionary<int, Person>();
            dicPerson.Add(1001, new Person(1001, "홍길동", 36));
            dicPerson.Add(1002, new Person(1002, "임꺽정", 26));
            dicPerson.Add(1003, new Person(1003, "프랑캔", 36));

            // personNumber 1001 의 name 
            Console.WriteLine("personNumber 1001 의 name : {0} {1} {2}", dicPerson[1001].personNumber, dicPerson[1001].name, dicPerson[1001].age);

            // 임꺽정의 나이
            int age = dicPerson.Where(w => w.Value.name == "임꺽정").Select(s => s.Value.age).FirstOrDefault();
            var age1 = dicPerson.GetValueOrDefault(1003, null);

            // Dictionary key, Value : Person class
            Console.WriteLine("임꺽정의 나이 : {0}", age);
            Console.WriteLine("1031 : {0}", age1.name);

            // 36세 모두 찾기.
            foreach (Person p in dicPerson.Where(w => w.Value.age == 36).Select(s => s.Value))
            {
                Console.WriteLine("{0}세. 이름 : {1} ", p.age, p.name);
            }
        }
    }

    public class Person
    {
        public int personNumber;
        public string name;
        public int age;

        public Person(int personNumber, string name, int age)
        {
            this.personNumber = personNumber;
            this.name = name;
            this.age = age;
        }
    }
    /*
    public class ProdRiskCfg : ILongId, IDaily, IProdNm
    {
        public long Id { get; set; }
        [Column(TypeName = "Date")]
        public DateTime d { get; set; }
        public string prodId { get; set; }
        public double maxDmaRto { get; set; } // % 상장주식수 대비 .
        public double maxBrkRto { get; set; }
        public double maxCumRto { get; set; }
        public double volCumRto { get; set; } // 거래량 대비
        [NotMapped]
        public string prodNm { get; set; }
    }
    */
}
