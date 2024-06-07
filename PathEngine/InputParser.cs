using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

// InputParser
// Because this class is simply a collection of helper functions,
// it is suitable to declare as static.
namespace TowerDefence.PathEngine
{
    static class InputParser
    {
        // Parse an integer from string to an integer
        // E.g. "3" -> 3
        public static int parse_int(string str)
        {
            int x;
            if (!int.TryParse(str, out x)) // Thanks Daniel :)
                Console.WriteLine("Couldn't parse '" + str + "' to int");
            return x;
        }

        // Parse sequnce of comma-separated integers from string to an array of integers
        // E.g. "1, 2, 3, 4, 5, 6" -> { 1, 2, 3, 4, 5, 6 }
        public static int[] parse_ints(string str)
        {
            string[] strings = str.Split(',');
            int[] ints = new int[strings.Length];

            for (int i = 0; i < strings.Length; i++)
            {
                ints[i] = parse_int(strings[i]);
            }
            return ints;
        }

        // Parse string of 2x comma-separated integers from string to a Vector2
        // E.g. "1, 5" -> Vector2(1, 5)
        public static Vector2 parse_Vector2(string line)
        {
            int[] ints = parse_ints(line);
            return new Vector2(ints[0], ints[1]);
        }
    }
}

