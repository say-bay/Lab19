using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab19
{
    class Computer
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Processor { get; set; }
        public double Frequency { get; set; }
        public int Memory { get; set; }
        public double HDD { get; set; }
        public int Video { get; set; }
        public int Price { get; set; }
        public int Avail { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Computer> listComputer = new List<Computer>()
            {
                new Computer() { Id = 1, Brand = "Dell", Processor = "Intel", Frequency = 3.8, Memory = 32, HDD = 2, Video = 8, Price = 1000, Avail = 31 },
                new Computer() { Id = 2, Brand = "Lenovo", Processor = "AMD", Frequency = 3.8, Memory = 16, HDD = 1, Video = 4, Price = 800, Avail = 3 },
                new Computer() { Id = 3, Brand = "HP", Processor = "AMD", Frequency = 3.8, Memory = 16, HDD = 1.5, Video = 6, Price = 750, Avail = 19 },
                new Computer() { Id = 4, Brand = "Asus", Processor = "AMD", Frequency = 4.2, Memory = 32, HDD = 4, Video = 8, Price = 1100, Avail = 52 },
                new Computer() { Id = 5, Brand = "Lenovo", Processor = "Intel", Frequency = 2.8, Memory = 8, HDD = 1, Video = 2, Price = 500, Avail = 11 },
                new Computer() { Id = 6, Brand = "HP", Processor = "Intel", Frequency = 3.9, Memory = 64, HDD = 16, Video = 16, Price = 2000, Avail = 3 },
                new Computer() { Id = 7, Brand = "Dell", Processor = "AMD", Frequency = 3.2, Memory = 8, HDD = 1, Video = 4, Price = 700, Avail = 18 }
            };
            Console.WriteLine("Введите название процессора");
            string proc = Console.ReadLine();
            var selectedComputerA = from computer in listComputer
                                    where computer.Processor == proc
                                    select computer;
            foreach (Computer computer in selectedComputerA)
                Console.WriteLine($"{computer.Id} - {computer.Processor}");
            Console.WriteLine("Введите минимальный объем ОЗУ");
            int mem = Convert.ToInt32(Console.ReadLine());
            var selectedComputerB = from computer in listComputer
                                    where computer.Memory >= mem
                                    select computer;
            foreach (Computer computer in selectedComputerB)
                Console.WriteLine($"{computer.Id} - {computer.Memory}");
            Console.WriteLine("Стоимость по возрастанию:");
            var sortedComputerC = from computer in listComputer
                                  orderby computer.Price
                                  select computer;
            foreach (Computer computer in sortedComputerC)
                Console.WriteLine($"{computer.Id} - {computer.Price}");
            Console.WriteLine("Группировка по типу процессора:");
            var groupedComputerD = from computer in listComputer
                                   group computer by computer.Processor;
            foreach (IGrouping<string, Computer> g in groupedComputerD)
            {
                Console.WriteLine(g.Key);
                foreach (var t in g)
                    Console.WriteLine(t.Id);
            }
            Console.WriteLine("Наиболее дорогой:");
            int max = listComputer.Max(computer => computer.Price);
            var maxComputerE = from computer in listComputer
                               where computer.Price == max
                               select computer;
            foreach (Computer computer in maxComputerE)
                Console.WriteLine($"{computer.Id} - {computer.Price}");
            Console.WriteLine("Наиболее дешевый:");
            int min = listComputer.Min(computer => computer.Price);
            var minComputerE = from computer in listComputer
                               where computer.Price == min
                               select computer;
            foreach (Computer computer in minComputerE)
                Console.WriteLine($"{computer.Id} - {computer.Price}");
            Console.WriteLine("Не менее 30 штук:");
            var selectedComputerF = from computer in listComputer
                                    where computer.Avail >= 30
                                    select computer;
            foreach (Computer computer in selectedComputerF)
                Console.WriteLine($"{computer.Id} - {computer.Avail}");

            Console.ReadKey();
        }
    }
}
