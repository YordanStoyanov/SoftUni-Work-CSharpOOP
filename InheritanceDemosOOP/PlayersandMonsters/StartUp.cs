using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main()
        {
            string username = Console.ReadLine();
            int level = int.Parse(Console.ReadLine());
            Hero hero = new Hero(username, level);
            Console.WriteLine(hero);
        }
    }
}
