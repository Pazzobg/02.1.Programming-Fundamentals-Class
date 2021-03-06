﻿namespace _04.PokemonEvolution
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Pokemon
    {
        public string Name { get; set; }

        public string EvoType { get; set; }

        public int EvoIndex { get; set; }

        public bool NameAlreadyPrinted { get; set; }
    }

    public class PokemonEvolution
    {
        public static void Main()
        {
            var allPokemons = new List<Pokemon>();
            var pokeNames = new HashSet<string>();

            string[] input = Console.ReadLine().Split(" ->".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "wubbalubbadubdub")
            {
                if (input.Length == 1)
                {
                    string nameToPrintStats = input[0];

                    if (allPokemons.Any(x => x.Name == nameToPrintStats))
                    {
                        Console.WriteLine($"# {nameToPrintStats}");

                        foreach (var member in allPokemons.Where(x => x.Name == nameToPrintStats))
                        {
                            Console.WriteLine($"{member.EvoType} <-> {member.EvoIndex}");
                        }
                    }

                    input = Console.ReadLine().Split(" ->".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    continue;
                }

                string name = input[0];
                string type = input[1];
                int index = int.Parse(input[2]);

                var currentPokemon = new Pokemon
                {
                    Name = name,
                    EvoType = type,
                    EvoIndex = index,
                    NameAlreadyPrinted = false
                };

                allPokemons.Add(currentPokemon);
                pokeNames.Add(name);

                input = Console.ReadLine().Split(" ->".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var name in pokeNames)
            {
                Console.WriteLine($"# {name}");

                foreach (var member in allPokemons.Where(x => x.Name == name).OrderByDescending(x => x.EvoIndex))
                {
                    Console.WriteLine($"{member.EvoType} <-> {member.EvoIndex}");
                }
            }
        }
    }
}
