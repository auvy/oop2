using System;
using System.Collections.Generic;

namespace lab1
{
    class Program1
    {
        static void Main(string[] args)
        {
            UsualUser nox = new UsualUser("Nox", new DateTime(2011, 6, 10), "I really am the best!", 3);

            AdminUser thanaton = new AdminUser("Thanaton", new DateTime(1980, 3, 3), "Tradition. Principles. History.", -6);

            VIPUser marr = new VIPUser("Marr", new DateTime(1964, 7, 7), "Victory is in our grasp, let us reach!", 54234);

            Info info = new Info(nox);
            info.GetInfo();

            info = new Info(thanaton);
            info.GetInfo();

            info = new Info(marr);
            info.GetInfo();
        }
    }

    class Info
    {
        private AbstractUser user;

        public Info(AbstractUser u)
        {
            this.user = u;
        }

        public void GetInfo()
        {
            this.user.getInfo();
        }
    }

    abstract class AbstractUser
    {
        //usual, admin, vip
        
        protected string username { get; set; }
        //everyone
        protected DateTime registered { get; set; }
        //usual only
        protected string motto { get; set; }
        //everyone
        protected int karma { get; set; }
        //usual and admin
        public AbstractUser(string uname, DateTime reg, string mtt, int krm)
        {
            username = uname;
            registered = reg;
            motto = mtt;
            karma = krm;
        }

        public abstract void getInfo();
    }
    class UsualUser : AbstractUser
    {
        public UsualUser(string uname, DateTime reg, string mtt, int krm) : base(uname, reg, mtt, krm){}
        public override void getInfo()
        {
            Console.WriteLine($"Name: {username};\n Date: {registered.ToString("MMMM dd, yyyy")};\n Motto: {motto}\n Karma: {karma}");
        }
    }
    class AdminUser : AbstractUser
    {
        public AdminUser(string uname, DateTime reg, string mtt, int krm) : base(uname, reg, mtt, krm){}
        public override void getInfo()
        {
            Console.WriteLine($"Name: {username};\n Motto: {motto}\n Karma: {karma}");
        }
    }
    class VIPUser : AbstractUser
    {
        public VIPUser(string uname, DateTime reg, string mtt, int krm) : base(uname, reg, mtt, krm){}
        public override void getInfo()
        {
            Console.WriteLine($"Name: {username};\n Motto: {motto}");
        }
    }
}