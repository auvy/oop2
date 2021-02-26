using System;

namespace lab2
{
    class Program1
    {
        static void Main()
        {
            RemoteBanking BankingCheck = new RemoteBanking();

            Client one = new Client() { name = "Richaaaaaaard", service_on = true };
            Client two = new Client() { name = "Robeeeeeeeert", service_on = false };

            BankingCheck.Check_Service(one);
            BankingCheck.Check_Service(two);
        }
    }

    class Client
    {
        public string name;
        public bool service_on;
    }

    abstract class AbstBank
    {
        public abstract void Check_Service(Client m);
    }

    class Bank : AbstBank
    {
        public override void Check_Service(Client m)
        {
            Console.WriteLine($"{m.name}, Successful authorization. You may proceed.");
        }
    }

    class RemoteBanking : AbstBank
    {
        Bank Bank = new Bank();
        public override void Check_Service(Client m)
        {
            if (!m.service_on)
                Bank.Check_Service(m);
            else
                Console.WriteLine($"{m.name}, You need to activate the service. Access denied.");
        }
    }
}
