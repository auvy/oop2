using System;
using System.Collections.Generic;

namespace lab2
{
    class Program1
    {
        static void Main()
        {
            Student roflan = new Student("Rofel", 20, 34.5);
            Student meman = new Student("Meme", 20, 41.5);
            Student stepan = new Student("Stepan", 912, 0.5);

            Student bravado = new Student("Bravado", 12, 13.5);
            Student ventura = new Student("Ventura", 31, 100.5);
            Student robinson = new Student("Robinson", 42, 51.5);
            Student smiles = new Student("Smiles", 32, 98.5);

            List<Student> mmx2 = new List<Student>(new Student[]{roflan, meman, stepan});
            List<Student> baddest = new List<Student>(new Student[]{bravado, ventura, robinson, smiles });

            Dictionary<string, List<Student>> allGroups = new Dictionary<string, List<Student>>();

            allGroups.Add("mmx2", mmx2);
            allGroups.Add("bad_batch", baddest);

            OldDeanery old = new OldDeanery();
            old.Print(mmx2);
            old.Print(baddest);

            NewDeanery newer = new NewDeanery(allGroups);

            newer.Print("bad_batch");
        }
    }

    class Student
    {
        public string name;
        public int age;
        public double average;

        public Student(string name, int age, double average)
        {
            this.name = name;
            this.age = age;
            this.average = average;
        }
    }
    
    class OldDeanery
    {
        public void Print(List<Student> students)
        {
            Console.WriteLine("> OLD DEANERY FUNCTIONAL");
            foreach (Student s in students)
                Console.WriteLine($"STUDENT: {s.name}, {s.age}, AV: {s.average}");
        }
    }


    class NewDeanery : OldDeanery
    {
        protected Dictionary<string, List<Student>> _allGroups;

        public NewDeanery(Dictionary<string, List<Student>> groups)
        {
            this._allGroups = groups;
        }

        public void Print(string key)
        {
            Console.WriteLine("DEANERY VERSION: 2.0");
            if(this._allGroups.ContainsKey(key))
            {
                Print(this._allGroups[key]);
            }
            else Console.WriteLine("Wrong key, soz");
        }
    }
}