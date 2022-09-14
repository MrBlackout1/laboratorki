using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2
{
    public class Address
    {
        public int Index { get; set; } = 08005;
        public string Country { get; set; } = "Ukraine";
        public string City { get; set; } = "Cherkassy";
        public string Street { get; set; } = "Narbutivska";
        public int House { get; set; } = 5;
        public int Apartment { get; set; } = 146;
        public void Print()
        {
            Console.WriteLine($"Index: {Index}");
            Console.WriteLine($"Country: {Country}");
            Console.WriteLine($"City: {City}");
            Console.WriteLine($"Street: {Street}");
            Console.WriteLine($"House: {House}");
            Console.WriteLine($"Apartment: {Apartment}");
        }
    }
    public class Converter
    {
        public static Currency USD { get; set; } = new Currency();
        public static Currency EUR { get; set; } = new Currency();
        public static Currency RUB { get; set; } = new Currency();
        public Converter()
        { }

        public Converter(double usd, double eur, double rub)
        {
            USD.Rate = usd;
            EUR.Rate = eur;
            RUB.Rate = rub;
        }
        public double UahTo(double uah, Currency cur) => uah / cur.Rate;
        public double GetUah(double money, Currency cur) => money * cur.Rate;
    }
    public class Currency
    {
        public double Rate { get; set; }
    }
    public enum Positions
    {
        TeamLead = 100,
        Middle = 60,
        Junior = 30
    }

    public class Employee : Persona
    {
        public Positions Position { get; set; } = Positions.Junior;
        public double Experience { get; set; } = 1;
        public double CountOfTax { get; set; } = 18;
        public double Tax { get; set; }
        public double Payment { get; set; }
        public Employee(string name, string lastName) : base(name, lastName)
        {

        }
        public double GetPayment()
        {
            Payment = Position.GetHashCode() * (Experience * 0.2) * 100;
            Tax = Payment * (CountOfTax / 100);
            return Payment;
        }
        public void GetPositionValue(string p) => Position = (Positions)Enum.Parse(typeof(Positions), p);
    }
    public class Persona
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public Persona(string name, string lastName)
        {
            Name = name;
            LastName = lastName;
        }
    }
    class Program
    {
        static void UahTo(Converter converter)
        {
            Console.Write("Input amount of uah: ");
            double uah = Convert.ToDouble(Console.ReadLine());
            Console.Write("Input currency: ");
            string selectedCur = Console.ReadLine();
            Currency selected;
            switch (selectedCur.ToLower())
            {
                case "usd":
                    {
                        Console.WriteLine($"result: {converter.UahTo(uah, Converter.USD) }");
                        break;
                    }
                case "eur":
                    {
                        Console.WriteLine($"result: {converter.UahTo(uah, Converter.EUR) }");
                        break;
                    }
                case "rub":
                    {
                        Console.WriteLine($"result: {converter.UahTo(uah, Converter.RUB) }");
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Incorrect currency");
                        break;
                    }
            }
            Console.ReadKey();
        }

        static void ToUah(Converter converter)
        {
            Console.Write("Input amount of money: ");
            double money = Convert.ToDouble(Console.ReadLine());
            Console.Write("Input currency: ");
            string selectedCur = Console.ReadLine();
            Currency selected;
            switch (selectedCur.ToLower())
            {
                case "usd":
                    {
                        Console.WriteLine($"result: {converter.GetUah(money, Converter.USD) }");
                        break;
                    }
                case "eur":
                    {
                        Console.WriteLine($"result: {converter.GetUah(money, Converter.EUR) }");
                        break;
                    }
                case "rub":
                    {
                        Console.WriteLine($"result: {converter.GetUah(money, Converter.RUB) }");
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Incorrect currency");
                        break;
                    }
            }
            Console.ReadKey();
        }
    }
    public class User
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public int Age { get; set; }
        public readonly DateTime FillingDate = DateTime.Now;
        public void Print()
        {
            Console.WriteLine($"Name: {Name} {LastName}");
            Console.WriteLine($"Login: {Login}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine($"FillingDate: {FillingDate}");
        }
    }

}