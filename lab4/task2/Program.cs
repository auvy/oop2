using System;

namespace task2 {
    class Program {
        static void Main() {

            Clothing[] basket = {new Clothing("Trousers", FabricType.synthetic, false, true), 
                                 new Clothing("Sweater", FabricType.wool, false, true),
                                 new Clothing("Jeans", FabricType.denim, false, true),
                                 new Clothing("Blouse", FabricType.silk, false, true),
                                 new Clothing("T-shirt", FabricType.cotton, false, true)};

            CottonMode washstuff = new CottonMode();

            washstuff.WashingTemplate(basket);
        }
    }

    enum FabricType
    {
        wool, denim, silk, cotton, synthetic
    }

    class Clothing
    {
        public string name;
        public FabricType fabric;
        public bool cleanness;
        public bool wearable;
        
        public Clothing(string name, FabricType fabric, bool cleanness, bool state)
        {
            this.name = name;
            this.fabric = fabric;
            this.cleanness = cleanness;
            this.wearable = state;
        }
    }


    abstract class WashingMachine
    {
        public void WashingTemplate(Clothing[] clothes)
        {
            this.Loading(clothes);
            this.AddingPowder();
            Console.WriteLine("Washing your clothes now...");
            this.Washing(clothes);
            this.Spin(clothes);
            this.Unloading(clothes);
        }

        protected void Loading(Clothing[] clothes){
            Console.WriteLine("Loading your clothes: ");
            
            foreach (Clothing cloth in clothes)
            {
                Console.WriteLine($"{cloth.name}: of {cloth.fabric}, clean: {cloth.cleanness}, wearable: {cloth.wearable}");
            }
        }
        protected void AddingPowder(){
            Console.WriteLine("Adding washing powder...");
        }

        protected void Unloading(Clothing[] clothes){
            Console.WriteLine("Your clothes are ready! Result: ");
            foreach (Clothing cloth in clothes)
            {
                Console.WriteLine($"{cloth.name}: of {cloth.fabric}, clean: {cloth.cleanness}, wearable: {cloth.wearable}");
            }
        }

        protected abstract void Washing(Clothing[] clothes);
        protected abstract void Spin(Clothing[] clothes);
    }
    

    class CottonMode : WashingMachine
    {
        protected override void Washing(Clothing[] clothes){
            foreach (Clothing cloth in clothes)
            {
                cloth.cleanness = true;
            }
        }
        protected override void Spin(Clothing[] clothes){
            Console.WriteLine("Spin intensity: maximum...");
            foreach (Clothing cloth in clothes)
            {
                if(cloth.fabric != FabricType.cotton)
                {
                    cloth.wearable = false;
                }
            }
        }
    }

    class SynthMode : WashingMachine
    {
        protected override void Washing(Clothing[] clothes){
            foreach (Clothing cloth in clothes)
            {
                if(cloth.fabric == FabricType.silk || cloth.fabric == FabricType.wool || cloth.fabric == FabricType.synthetic)
                {
                    cloth.cleanness = true;
                }
            }
        }
        protected override void Spin(Clothing[] clothes){
            Console.WriteLine("Spin intensity: minumum...");
            foreach (Clothing cloth in clothes)
            {
                if(cloth.fabric == FabricType.wool)
                {
                    cloth.wearable = false;
                }
            }
        }
    }


    class SportMode : WashingMachine
    {
        protected override void Washing(Clothing[] clothes){
            foreach (Clothing cloth in clothes)
            {
                if(cloth.fabric == FabricType.silk || cloth.fabric == FabricType.wool || cloth.fabric == FabricType.synthetic)
                {
                    cloth.cleanness = true;
                }
            }
        }
        protected override void Spin(Clothing[] clothes){
            Console.WriteLine("Spin intensity: moderate...");
            foreach (Clothing cloth in clothes)
            {
                if(cloth.fabric == FabricType.wool || cloth.fabric == FabricType.silk)
                {
                    cloth.wearable = false;
                }
            }
        }
    }

    class DenimMode : WashingMachine
    {
        protected override void Washing(Clothing[] clothes){
            foreach (Clothing cloth in clothes)
            {
                cloth.cleanness = true;
            }
        }
        protected override void Spin(Clothing[] clothes){
            Console.WriteLine("Spin intensity: moderate...");
            foreach (Clothing cloth in clothes)
            {
                if(cloth.fabric == FabricType.silk || cloth.fabric == FabricType.wool || cloth.fabric == FabricType.synthetic)
                {
                    cloth.wearable = false;
                }
            }
        }
    }

    class WoolMode : WashingMachine
    {
        protected override void Washing(Clothing[] clothes){
            foreach (Clothing cloth in clothes)
            {
                if(cloth.fabric == FabricType.silk || cloth.fabric == FabricType.wool || cloth.fabric == FabricType.synthetic)
                {
                    cloth.cleanness = true;
                }
            }
        }
        protected override void Spin(Clothing[] clothes){
            Console.WriteLine("Spin intensity: minumum...");
        }
    }



}
