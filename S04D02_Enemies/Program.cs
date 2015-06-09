using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S04D02_Enemies
{
    class Program
    {
        static void Main(string[] args)
        {
            Enemy[] enemies = new Enemy[2];
            enemies[0] = new Vampire("Vamp", 1, 1, 0);
            enemies[1] = new Programming("c#", 2, 3, "c#");

            for (int i = 0; i < enemies.Length; i++)
            {
                Console.WriteLine(enemies[i]);
            }
        }
    }
}
