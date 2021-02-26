using System;

namespace task2 {
    class Program {
        static void Main() {
            int rad;
            Console.Write("Enter Radius :");
            rad = int.Parse(Console.ReadLine());

            FigureForge redforge = new ConcreteForgeRed();
            AbstractFigure reccyred = redforge.CreateRectangle(rad);
            AbstractFigure circyred = redforge.CreateCircle(rad);

            reccyred.printFigure();
            circyred.printFigure();


            Console.Write("Enter another radius :");
            rad = int.Parse(Console.ReadLine());

            FigureForge blueforge = new ConcreteForgeBlue();
            AbstractFigure reccyblue = blueforge.CreateRectangle(rad);
            AbstractFigure circyblue = blueforge.CreateCircle(rad);

            reccyblue.printFigure();
            circyblue.printFigure();
        }
    }

    abstract class FigureForge
    {
        public abstract AbstractFigure CreateCircle(int radius);
        public abstract AbstractFigure CreateRectangle(int side);
    }
    class ConcreteForgeRed: FigureForge
    {
        public override AbstractFigure CreateCircle(int radius)
        {
            return new CircleRed(radius);
        }
            
        public override AbstractFigure CreateRectangle(int side)   
        {
            return new RectangleRed(side); 
        }
    }
    class ConcreteForgeBlue: FigureForge
    {
        public override AbstractFigure CreateCircle(int radius)
        {
            return new CircleBlue(radius);
        }
            
        public override AbstractFigure CreateRectangle(int side)
        {
            return new RectangleBlue(side);
        }
    }
 



    abstract class AbstractFigure
    {
        public abstract void printFigure();
    }
                

    class CircleRed: AbstractFigure
    {
        int radius;

        public CircleRed(int radius){
            this.radius = radius;
        }

        public override void printFigure(){
            Console.ForegroundColor = ConsoleColor.Red;
            int radius = this.radius;

            double thickness = 0.4;
            double rIn = radius - thickness, rOut = radius + thickness;
            
            Console.WriteLine();
            for (double y = radius; y >= -radius; --y){
                for (double x = -radius; x < rOut; x += 0.5){
                    double value = x * x + y * y;
                    if (value >= rIn * rIn && value <= rOut * rOut) Console.Write("*");
                    else Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }
        
    class RectangleRed: AbstractFigure   
    {
        int side;
        public RectangleRed(int side){
            this.side = side;
        }

        public override void printFigure(){
            Console.ForegroundColor = ConsoleColor.Red;
            int radius = this.side;

            Console.WriteLine();
            for (int i = 1; i <= radius*2; i++){
                for (int j = 1; j <= radius*2; j++){
                    if ((i == 1 || i == radius*2) || (j == 1 || j == radius*2)) Console.Write("*");
                    else Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }
    
    class CircleBlue: AbstractFigure
    {
        int radius;

        public CircleBlue(int radius){
            this.radius = radius;
        }

        public override void printFigure(){
            Console.ForegroundColor = ConsoleColor.Blue;
            int radius = this.radius;

            double thickness = 0.4;
            double rIn = radius - thickness, rOut = radius + thickness;
            
            Console.WriteLine();
            for (double y = radius; y >= -radius; --y){
                for (double x = -radius; x < rOut; x += 0.5){
                    double value = x * x + y * y;
                    if (value >= rIn * rIn && value <= rOut * rOut) Console.Write("#");
                    else Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }
                    
    class RectangleBlue: AbstractFigure      
    {
        int side;

        public RectangleBlue(int side){
            this.side = side;
        }

        public override void printFigure(){
            Console.ForegroundColor = ConsoleColor.Blue;
            int radius = this.side;

            Console.WriteLine();
            for (int i = 1; i <= radius*2; i++){
                for (int j = 1; j <= radius*2; j++){
                    if ((i == 1 || i == radius*2) || (j == 1 || j == radius*2)) Console.Write("#");
                    else Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }      
             















}
