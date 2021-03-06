﻿namespace _07.TakeSkipRope
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TakeSkipRope
    {
        public static void Main()
        {
            var input = Console.ReadLine().ToCharArray();

            var numsList = input
                .Where(c => char.IsDigit(c))
                .Select(x => int.Parse(x.ToString()))
                .ToList();

            var nonNumbers = input
                .Where(c => !char.IsDigit(c))
                .ToList();

            // Below code is equivalent of LINQ methods above if we just create 2 empty numsList<int> and nonNumbers<char> lists
            //foreach (var character in input)
            //{
            //    if (char.IsDigit(character))
            //    {
            //        numsList.Add(int.Parse(character.ToString()));
            //    }
            //    else
            //    {
            //        nonNumbers.Add(character);
            //    }
            //}

            var takeList = new List<int>();
            var skipList = new List<int>();

            for (int i = 0; i < numsList.Count; i++)
            {
                if (i % 2 == 0)
                {
                    takeList.Add(numsList[i]);
                }
                else
                {
                    skipList.Add(numsList[i]);
                }
            }

            var resultList = new List<char>();
            int numsToSkip = 0;

            for (int i = 0; i < takeList.Count; i++)
            {
                int numsToTake = takeList[i];

                resultList.AddRange(nonNumbers
                    .Skip(numsToSkip)
                    .Take(numsToTake));

                numsToSkip += skipList[i] + numsToTake;
            }

            Console.WriteLine(string.Join(string.Empty, resultList));
        }
    }
}
