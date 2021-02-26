using System;
using System.Collections.Generic;
using System.Linq;

namespace lab1
{
    class MainApp
    {
        static void Main()
        {
            Composite course = new Composite("MAIN COURSE");

            Composite stream1 = new Composite("Song of the Moth");
            Composite stream2 = new Composite("Yesterday's Yearning");
            
            course.Add(stream1);
            course.Add(stream2);

            Composite group1 = new Composite("SS-12");
            Composite group2 = new Composite("ZX-34");

            stream1.Add(group1);
            stream1.Add(group2);

            Composite group3 = new Composite("sigma568");
            Composite group4 = new Composite("aurek201");
            Composite group5 = new Composite("theta032");

            stream2.Add(group3);
            stream2.Add(group4);
            stream2.Add(group5);

            Disciple fedr = new Disciple("Fedr");
            Disciple petr = new Disciple("Petr");

            Disciple sinombre = new Disciple("S.I. Nombre");
            Disciple rob = new Disciple("Rob Swire");
            Disciple simon = new Disciple("Simon Candela");

            Disciple bralor = new Disciple("Vod Bralor");
            Disciple rodney = new Disciple("Rodney Armstrong");
            Disciple chang = new Disciple("Liu Chang");
            Disciple lowball = new Disciple("Lowball");

            Disciple rozzie = new Disciple("Roze Satin");
            Disciple izax = new Disciple("Izax the Destroyer");

            Disciple carbon = new Disciple("Carbon fiber reinforced polymer");
            Disciple fives = new Disciple("5s");
            Disciple flamingo = new Disciple("Donnie Flamingo");

            group1.Add(fedr);
            group1.Add(petr);

            group2.Add(sinombre);
            group2.Add(rob);
            group2.Add(simon);

            group3.Add(bralor);
            group3.Add(rodney);
            group3.Add(chang);
            group3.Add(lowball);

            group4.Add(rozzie);
            group4.Add(izax);

            group5.Add(carbon);
            group5.Add(fives);
            group5.Add(flamingo);

            // group5.GetMarksInfo();
            // group5.Display(2);

            // flamingo.Display(1);


            course.GetMarksInfo();
            course.Display(4);


        }
    }
    abstract class MarkHoarder
    {
        protected string name;
        protected List<int> _marks = new List<int> ();
        // Constructor
        public MarkHoarder(string name)
        {
            this.name = name;
        }
        public abstract void Add(MarkHoarder c);
        public abstract void Remove(MarkHoarder c);
        public abstract List<int> GetMarksInfo();
        public abstract void Display(int depth);

        public double GetAverage()
        {
            return this._marks.Average();
        }
    }

  
    class Composite : MarkHoarder
    {
        
        private List<MarkHoarder> _children = new List<MarkHoarder>();
        // Constructor
        public Composite(string name) : base(name)
        {
            this._marks.Clear();
        }
        public override void Add(MarkHoarder component)
        {
            _children.Add(component);
        }
        public override void Remove(MarkHoarder component)
        {
            _children.Remove(component);
        }
        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name + "; Marks: " +
            String.Join(", ", this._marks) + $"; [{this.GetAverage()}]");

            foreach (MarkHoarder component in _children)
                component.Display(depth + 1);
        }
        public override List<int> GetMarksInfo()
        {
            this._marks.Clear();
            foreach (MarkHoarder component in _children)
                this._marks.AddRange(component.GetMarksInfo());
            return this._marks;
        }
    }


    class Disciple : MarkHoarder
    {
        public Disciple(string name) : base(name)
        {
            Random rnd = new Random();
            this._marks.Add(rnd.Next(101));
            this._marks.Add(rnd.Next(101));
        }
        public override void Add(MarkHoarder c)
        {
            Console.WriteLine("Impossible operation");
        }
        public override void Remove(MarkHoarder c)
        {
            Console.WriteLine("Impossible operation");
        }
        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + $"-{this.name}, Marks: " + String.Join(", ", this._marks) + $"; [{this.GetAverage()}]");
        }
        public override List<int> GetMarksInfo()
        {
            return this._marks;
        }
    }
}