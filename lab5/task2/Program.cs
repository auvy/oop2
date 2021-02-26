using System;
using System.Linq;
using System.Collections.Generic;

namespace task2 {

    class Program {
        static void Main() {

            List<User> users = new List<User>(){new User("Vasya", Gender.male, 24, new List<Hobby> {Hobby.music, Hobby.movies}, "Kyiv"), 
                            new User("Petr", Gender.bruh, 19, new List<Hobby> {Hobby.games, Hobby.sport}, "Lviv"),
                            new User("Lola", Gender.female, 28, new List<Hobby> {Hobby.programming, Hobby.sleeping, Hobby.sport}, "Petesburg"),
                            new User("Racket", Gender.male, 31, new List<Hobby> {}, "New Haven"),
                            new User("Jawbreaker", Gender.female, 20, new List<Hobby> {Hobby.dancing, Hobby.movies}, "Sanctuary"),
            };

            Database db = new Database(users);

            Website site = new Website();

            CommandAdd adding = new CommandAdd(new User("Eleanor", Gender.female, 67, new List<Hobby> {Hobby.movies, Hobby.dancing}, "Rogery"));
            adding.SetReceiver(db);
            site.SetCommand(adding);
            site.Run();

            db.PrintDatabase();

            Console.WriteLine();

            CommandSearch searching = new CommandSearch("", 40, Gender.bruh, new List<Hobby> {}, "", "Harold");
            searching.SetReceiver(db);
            site.SetCommand(searching);
            site.Run();

        }
    }

    enum Gender
    {
        male, female, bruh
    }

    enum Hobby
    {
        music, dancing, sport, programming, sleeping, movies, games
    }

    class User
    {
        public string name;
        public Gender gender;
        public int age;
        public List<Hobby> hobbies;
        public string city;
        public List<string> interested;
        public User(string name, Gender gender, int age, List<Hobby> hobbies, string city)
        {
            this.name = name;
            this.gender = gender;
            this.age = age;
            this.hobbies = hobbies;
            this.city = city;
            this.interested = new List<string>();
        }
    }

    class Database
    {
        protected List<User> _user;
        public Database(List<User> users)
        {
            this._user = users;
        }

        public List<User> SearchByFilter(string name, int age, Gender gender, List<Hobby> hobbies, string city, string username)
        {
            List<User> found = new List<User>();
            foreach(User u in _user)
            {
                if(u.name == name || u.gender == gender || u.city == city || u.hobbies.Any(hobbies.Contains) || Math.Abs(u.age - age) < 5) 
                {
                    u.interested.Add(username);
                    Console.WriteLine($"{u.name} was notified that {username} found them.");
                    found.Add(u);
                }
            }
            foreach(User u in found)
            {
                Console.WriteLine($"[{u.name}], age of {u.age} {u.gender} from {u.city}.");
            }
            return found;
        }

        public List<User> InsertUser(User user)
        {
            _user.Add(user);
            Console.WriteLine($"Added {user.name} to database.");
            return _user;
        }

        public void PrintDatabase()
        {
            foreach(User u in _user)
            {
                Console.WriteLine($"[{u.name}], age of {u.age} {u.gender} from {u.city}");
            }
        }
    }

    abstract class Command
    {
        public abstract void Execute();
        public abstract void Undo();

    }


    class CommandSearch : Command
    {   
        public string name;
        public int age;
        public Gender gender;
        public List<Hobby> hobbies;
        public string city;
        public string interested;


        Database receiver; //database
        public void SetReceiver(Database d)
        {
            receiver = d;
        }

        public CommandSearch(string name, int age, Gender gender, List<Hobby> hobbi, string cite, string username)
        {
            this.name = name;
            this.age = age;
            this.gender = gender;
            this.hobbies = hobbi;
            this.city = cite;
            this.interested = username;
        }

        public override void Execute()
        {
            receiver.SearchByFilter(name, age, gender, hobbies, city, interested);
        }
        public override void Undo()
        {
            Console.WriteLine("Tough luck, fella");
        }
    }

    class CommandAdd : Command
    {
        public User user;

        Database receiver; //database
        public void SetReceiver(Database d)
        {
            receiver = d;
        }

        public CommandAdd(User user)
        {
            this.user = user;
        }

        public override void Execute()
        {
            receiver.InsertUser(user);
        }
        public override void Undo()
        {
            Console.WriteLine("Tough luck, fella");
        }
    }

    class Website
    {
        Command command;
        public void SetCommand(Command c)
        {
            command = c;
        }
        public void Run()
        {
            command.Execute();
        }
        public void Stop()
        {
            command.Undo();
        }

    }




}
