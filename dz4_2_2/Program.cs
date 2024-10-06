using System;
using System.Collections.Generic;

abstract class Worker
{
    public string Name;
    public string Position;
    public string WorkDay;

    public Worker()
    {
        WorkDay = "";
    }

    public void Call()
    {
        Console.WriteLine(Name + " дзвонить.");
        WorkDay += "Дзвінок ";
    }

    public void WriteCode()
    {
        Console.WriteLine(Name + " пише код.");
        WorkDay += "Код ";
    }

    public void Relax()
    {
        Console.WriteLine(Name + " відпочиває.");
        WorkDay += "Відпочинок ";
    }

    public abstract void FillWorkDay();
}

class Developer : Worker
{
    public Developer(string name)
    {
        Name = name;
        Position = "Розробник";
    }

    public override void FillWorkDay()
    {
        WriteCode();
        Call();
        Relax();
        WriteCode();
    }
}

class Manager : Worker
{
    private Random random = new Random();
    public Manager(string name) 
    {
        Name = name;
        Position = "Менеджер";
    }

    public override void FillWorkDay()
    {
        int callsBeforeRelax = random.Next(1, 10);
        int callsAfterRelax = random.Next(1, 5);

        for (int i = 0; i < callsBeforeRelax; i++)
        {
            Call();
        }

        Relax();

        for (int i = 0; i < callsAfterRelax; i++)
        {
            Call();
        }
    }
}

class Team
{
    public string TeamName;
    private List<Worker> workers = new List<Worker>();

    public Team(string teamName)
    {
        TeamName = teamName;
    }

    public void AddWorker(Worker worker)
    {
        workers.Add(worker);
    }

    public void ShowTeamInfo()
    {
        Console.WriteLine("Команда: " + TeamName);
        foreach (var worker in workers)
        {
            Console.WriteLine(worker.Name + " - " + worker.Position);
        }
    }

    public void ShowDetailedInfo()
    {
        Console.WriteLine("Команда: " + TeamName);
        foreach (var worker in workers)
        {
            Console.WriteLine(worker.Name + " - " + worker.Position + " - Робочий день: " + worker.WorkDay);
        }
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Введiть назву команди:");
        string teamName = Console.ReadLine();
        Team team = new Team(teamName);

        while (true)
        {
            Console.WriteLine("Введiть iм'я спiвробiтника (або '0' для отримання iнформацii та виходу):");
            string workerName = Console.ReadLine();

            if (workerName.ToLower() == "0")
                break;

            Console.WriteLine("Виберiть позицiю: 1 - Розробник, 2 - Менеджер");
            int positionChoice = int.Parse(Console.ReadLine());

            Worker worker;
            if (positionChoice == 1)
            {
                worker = new Developer(workerName);
            }
            else if (positionChoice == 2)
            {
                worker = new Manager(workerName);
            }
            else
            {
                Console.WriteLine("Невiрний вибiр позицii, спробуйте ще раз.");
                continue;
            }

            team.AddWorker(worker);
        }

        // Виводимо інформацію про команду
        Console.WriteLine("\nIнформацiя про команду:");
        team.ShowTeamInfo();

        // Детальна інформація про команду
        Console.WriteLine("\nДетальна iнформація про команду:");
        team.ShowDetailedInfo();

        Console.ReadKey();
    }
}