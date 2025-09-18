using System;
using System.Collections.Generic;
using HorseHarvester;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the location of the fruits: EJ (C4:+,C7:*,E3:-,E1:*,H4:*)");
        var entryFruit = Console.ReadLine();
        var board = new Board();

        foreach (var pair in entryFruit.Split(','))
        {
            var parts = pair.Split(':');
            if (parts.Length == 2 && !string.IsNullOrWhiteSpace(parts[0]) && !string.IsNullOrWhiteSpace(parts[1]))
                board.AddFruit(parts[0].Trim(), parts[1].Trim()[0]);
        }

        Console.WriteLine("Enter the initial position of the horse:");
        var start = Console.ReadLine();
        var horse = new Horse(start.Trim());

        Console.WriteLine("Enter the horse's movements:");
        var movementsInput = Console.ReadLine();
        var movements = movementsInput.Split(',');

        List<char> collectedFruits = new();

        foreach (var move in movements)
        {
            if (horse.Move(move.Trim()))
            {
                var fruit = board.PickFruit(horse.CurrentPosition);
                if (fruit.HasValue)
                    collectedFruits.Add(fruit.Value);
            }
        }

        Console.WriteLine("The fruits collected are: " + string.Join(" ", collectedFruits));
    }
}