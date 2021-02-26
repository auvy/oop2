using System;

namespace task2 {
    class Program {
        static void Main() {

            Room room  = new Room("Big room", -4, 0.7);
            Console.WriteLine($"[{room.name}] temp: {room.temperature}; humid: {room.humidity}");

            Conditioner condi = new Conditioner(new IonisingStrategy());

            condi.CorrectClimate(room);

            condi.ChangeStrat(new HeatingStrategy());
            
            condi.CorrectClimate(room);

            condi.ChangeStrat(new DryStrategy());
            
            condi.CorrectClimate(room);

        }
    }

    public class Room{
        public string name;
        public int temperature;
        public double humidity;
        public Room(string name, int temp, double hum)
        {
            this.name = name;
            this.temperature = temp;
            this.humidity = hum;
        }
    }


    public interface ClimateControl
    {
        void Algorithm(Room _room);
    }
    
    public class CoolingStrategy : ClimateControl
    {
        public void Algorithm(Room _room){
            Console.WriteLine($"Air in {_room.name} is being cooled down...");
            if(_room.temperature > 17) _room.temperature = 17;
        }
    }
    
    public class HeatingStrategy : ClimateControl
    {
        public void Algorithm(Room _room){
            Console.WriteLine($"Air in {_room.name} is being heated up...");
            if(_room.temperature < 10) _room.temperature = 20;
        }
    }

    public class DryStrategy : ClimateControl
    {
        public void Algorithm(Room _room){
            Console.WriteLine($"Drying all air in {_room.name}...");
            if(_room.humidity > 0.5) _room.humidity = 0.36;
        }
    }

    public class HumidStrategy : ClimateControl
    {
        public void Algorithm(Room _room){
            Console.WriteLine($"Humidifying all air in {_room.name}...");
            if(_room.humidity < 0.2) _room.humidity = 0.4;
        }
    }
    
    public class IonisingStrategy : ClimateControl
    {
        public void Algorithm(Room _room){
            Console.WriteLine($"Air in {_room.name} is being filtered and ionised...");
            if(_room.temperature > 17) _room.temperature = 17;
            else if(_room.temperature < -5) _room.temperature = 20;
        }
    }

    public class Conditioner
    {
        public ClimateControl localStrategy;
    
        public Conditioner(ClimateControl _control)
        {
            localStrategy = _control;
        }

        public void ChangeStrat(ClimateControl _control)
        {
            localStrategy = _control;
        }
    
        public void CorrectClimate(Room _room)
        {
            Console.WriteLine("Applying strategy...");
            localStrategy.Algorithm(_room);
            Console.WriteLine($"[{_room.name}] temp: {_room.temperature}; humid: {_room.humidity}");
        }
    }

}
