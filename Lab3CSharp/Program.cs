using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Lab3");
            Console.WriteLine("Виберiть завдання:");
            Console.WriteLine("1. Завдання 1 - розв'язок задачi з трапецiями");
            Console.WriteLine("2. Завдання 2 - iєрархiя класiв");
            Console.WriteLine("3. Вихiд");
            Console.WriteLine("");
            Console.Write("Виберiть завдання --> ");
            

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Неправильний ввiд. Будь ласка, введiть номер завдання.");
                continue;
            }
            Console.Clear();

            switch (choice)
            {
                case 1:
                    Task1();
                    break;
                case 2:
                    Task2();
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Неправильний вибiр. Будь ласка, виберiть номер завдання зi списку.");
                    break;
            }
            Console.WriteLine("\nНатиснiть будь-яку кнопку для продовження...");
            Console.ReadKey(); // Чекає натискання будь-якої кнопки
        }
    }

    static void Task1()
    {
        Trapeze[] trapezes = {
            new Trapeze(3, 6, 4, 1),
            new Trapeze(5, 8, 6, 2),
            new Trapeze(2, 4, 3, 1),
            new Trapeze(6, 10, 5, 2),
            new Trapeze(5, 5, 5, 5)
        };

        foreach (var trapeze in trapezes)
        {
            Console.WriteLine("iнформацiя про трапецiю:");
            trapeze.ShowLengths();
            Console.WriteLine($"Площа: {trapeze.CalculateArea()}");
            Console.WriteLine($"Периметр: {trapeze.CalculatePerimeter()}");
            Console.WriteLine($"Чи є квадратом: {trapeze.IsSquare}");
            Console.WriteLine();
        }
    }

    static void Task2()
    {
        Worker[] workers = {
            new Official("Офiцiант", "iванов", 35, "Червоний"),
            new Personal("Секретар", "Петрова", 28, "Жовтий"),
            new Engineer("iнженер", "Сидоров", 45, "Зелений", "Будiвництво"),
            new Worker("Робiтник", "Дмитрiєнко", 40, "Синiй")
        };

        // Сортування за прiзвищем
        Array.Sort(workers, (x, y) => string.Compare(x.LastName, y.LastName));

        foreach (var worker in workers)
        {
            worker.Show();
            Console.WriteLine();
        }
    }
}

class Trapeze
{
    public int A { get; set; }
    public int B { get; set; }
    public int H { get; set; }
    public int Color { get; }

    public Trapeze(int a, int b, int h, int color)
    {
        A = a;
        B = b;
        H = h;
        Color = color;
    }

    public void ShowLengths()
    {
        Console.WriteLine($"Основи: {A} i {B}, Висота: {H}");
    }

    public int CalculatePerimeter()
    {
        return A + B + 2 * H;
    }

    public double CalculateArea()
    {
        return (A + B) * H / 2.0;
    }

    public bool IsSquare
    {
        get
        {
            return A == B;
        }
    }
}

class Worker
{
    public string Position { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string Color { get; }

    public Worker(string position, string lastName, int age, string color)
    {
        Position = position;
        LastName = lastName;
        Age = age;
        Color = color;
    }

    public virtual void Show()
    {
        Console.WriteLine($"Посада: {Position}, Прiзвище: {LastName}, Вiк: {Age}, Колiр: {Color}");
    }
}

class Official : Worker
{
    public Official(string position, string lastName, int age, string color)
        : base(position, lastName, age, color)
    {
    }
}

class Personal : Worker
{
    public Personal(string position, string lastName, int age, string color)
        : base(position, lastName, age, color)
    {
    }
}

class Engineer : Worker
{
    public string Specialty { get; set; }

    public Engineer(string position, string lastName, int age, string color, string specialty)
        : base(position, lastName, age, color)
    {
        Specialty = specialty;
    }

    public override void Show()
    {
        base.Show();
        Console.WriteLine($"Спецiальнiсть: {Specialty}");
    }
}
