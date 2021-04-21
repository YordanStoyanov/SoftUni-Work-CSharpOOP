﻿namespace AnimalFarm
{
    using System;
    using AnimalFarm.Models;
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            Chicken chicken = new Chicken(name, age);
            Console.WriteLine(
                $"Chicken {chicken.Name} (age {chicken.Age}) can produce {chicken.CalculateProductPerDay()} eggs per day.");
        }
    }
}
