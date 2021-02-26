using System;

namespace task2 {
    class Program
    {
        static void Main(string[] args)
        {
            Family family = new Family(false, false, false, false, true);
            
            BreadHandler mom = new HandlerMother();
            BreadHandler dad = new HandlerFather();
            BreadHandler sis = new HandlerDaughter();
            BreadHandler bruh = new HandlerSon();
            BreadHandler dog = new HandlerDog();

            mom.Successor = dad;
            dad.Successor = sis;
            sis.Successor = bruh;
            bruh.Successor = dog;
    
            mom.BuyBread(family);
        }
    }
    
    class Family
    {
        public bool availabilityMother;
        public bool availabilityFather;
        public bool availabilityDaughter;
        public bool availabilitySon;
        public bool availabilityDog;
        public Family(bool mother, bool father, bool daughter, bool son, bool dog)
        {
            availabilityMother = mother;
            availabilityFather = father;
            availabilityDaughter = daughter;
            availabilitySon = son;
            availabilityDog = dog;
        }
    }

    abstract class BreadHandler
    {
        public BreadHandler Successor;
        public abstract void BuyBread(Family Family);
    }
    
    class HandlerMother : BreadHandler
    {
        public override void BuyBread(Family Family)
        {
            if (Family.availabilityMother == true)
                Console.WriteLine("Mother bought the best bread available.");
            else if (Successor != null){
                    Console.WriteLine("Mother wasn't able to buy bread. Redirecting...");
                    Successor.BuyBread(Family);
                }
            else if (Successor == null)
                Console.WriteLine("No one was there to buy the bread.");

        }
    }
    
    class HandlerFather : BreadHandler
    {
        public override void BuyBread(Family Family)
        {
            if (Family.availabilityFather == true)
                Console.WriteLine("Father bought bread that you've never seen before.");
            else if (Successor != null){
                    Console.WriteLine("Father wasn't able to buy bread. Redirecting...");
                    Successor.BuyBread(Family);
                }
            else if (Successor == null)
                Console.WriteLine("No one was there to buy the bread.");
        }
    }
    class HandlerDaughter : BreadHandler
    {
        public override void BuyBread(Family Family)
        {
            if (Family.availabilityDaughter == true)
                Console.WriteLine("Daughter bought the exact bread needed.");
            else if (Successor != null){
                    Console.WriteLine("Daughter wasn't able to buy bread. Redirecting...");
                    Successor.BuyBread(Family);
                }
            else if (Successor == null)
                Console.WriteLine("No one was there to buy the bread.");
        }
    }

    class HandlerSon : BreadHandler
    {
        public override void BuyBread(Family Family)
        {
            if (Family.availabilitySon == true)
                Console.WriteLine("Son bought bread, but wasted an hour doing so.");
            else if (Successor != null){
                    Console.WriteLine("Son wasn't able to buy bread. Redirecting...");
                    Successor.BuyBread(Family);
                }
            else if (Successor == null)
                Console.WriteLine("No one was there to buy the bread.");
        }
    }
    class HandlerDog : BreadHandler
    {
        public override void BuyBread(Family Family)
        {
            if (Family.availabilityDog == true)
                Console.WriteLine("Dog brought a stick. Good boy!");
            else if (Successor != null){
                    Console.WriteLine("Dog wasn't able to buy bread. Redirecting...");
                    Successor.BuyBread(Family);
                }
            else if (Successor == null)
                Console.WriteLine("No one was there to buy the bread.");
        }
    }

}
