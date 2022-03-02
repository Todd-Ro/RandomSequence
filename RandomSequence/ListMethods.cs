using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace RandomSequence
{
    public class ListMethods
    {
        public static int NumberOfSortedTermsBelowInArray(int[] toAddTo, int toAdd, int highestIndexToConsider)
        {
            //highestIndexToConsider is exclusive; indices below it will be considered
            int len = toAddTo.Length;
            int lowerLimit = 0;
            int upperLimit = Math.Min(len, highestIndexToConsider);
            int range = upperLimit;
            int comparisonMidpoint;
            while(range > 0)
            {
                comparisonMidpoint = lowerLimit + range / 2;
                if (toAdd > toAddTo[comparisonMidpoint])
                {
                    lowerLimit = comparisonMidpoint + 1;
                }
                else
                {
                    upperLimit = comparisonMidpoint;
                }
                range = upperLimit - lowerLimit;
            }
            return lowerLimit;
        }

        public static int NumberOfSortedTermsBelowInArray(int[] toAddTo, int toAdd)
        {
            return NumberOfSortedTermsBelowInArray(toAddTo, toAdd, toAddTo.Length);
        }


        public static int NumberOfSortedTermsBelowInList(List<int> toAddTo, int toAdd)
        {
            int[] sortedArr = toAddTo.ToArray();
            return NumberOfSortedTermsBelowInArray(sortedArr, toAdd);
        }

        public static void AddIntToSortedList(List<int> toAddTo, int toAdd)
        {
            int targetIndex = NumberOfSortedTermsBelowInList(toAddTo, toAdd);
            toAddTo.Insert(targetIndex, toAdd);
        }

        public static int[] MakeSequentialArray(int upperBound, int lowerBound = 0, int increment = 1)
        {
            /*Serves a similar function to Linq's Enumerable.Range. 
             * Uses exclusive upper bound and inclusive lower bound.
             */
            if(increment < 1)
            {
                return null;
            }

            int[] ret = new int[(upperBound - lowerBound) / increment];
            int placed = 0;
            int current = lowerBound;

            if(ret.Length > 0)
            {
                while(current < upperBound)
                {
                    ret[placed] = current;
                    current += increment;
                    placed++;
                }
            }

            return ret;
        }

        public static List<int> MakeNonRepeatingRandomListFromArray(int listLength, int[] sourceArray)
        {
            /*Generates a non-repeating randomly drawn list of integers of length listLength
             * from the elements of an array that is assumed to be sorted.
             * Repetition is possible if the requested listLength is greater than the array length.
             */
            List<int> ret = new List<int>();
            int added = 0;
            while(added < listLength)
            {
                List<int> unusedInts = new List<int>(sourceArray);
                int toAddThisCycle = Math.Min(listLength - added, sourceArray.Length);
                int remainingToAddThisCycle = toAddThisCycle;
                while(remainingToAddThisCycle > 0)
                {
                    int rando = RandomNumberGenerator.GetInt32(remainingToAddThisCycle);
                    ret.Add(unusedInts[rando]);
                    unusedInts.RemoveAt(rando);
                    remainingToAddThisCycle--;
                }
                added += toAddThisCycle;
            }
            return ret;
        }

        public static List<int> MakeNonRepeatingRandomListFromSequentialInts(int listLength, int upperBound, int lowerBound = 0, int increment = 1)
        {
            int[] requestedRange = MakeSequentialArray(upperBound, lowerBound, increment);
            return MakeNonRepeatingRandomListFromArray(listLength, requestedRange);
        }

        public static List<int> MakeNonRepeatingRandomListFromSequentialInts(int upperBoundAsReturnListLength)
        {
            return MakeNonRepeatingRandomListFromSequentialInts(upperBoundAsReturnListLength, upperBoundAsReturnListLength);
        }


        public static string MakeBigStringFromListSB(List<int> input,
                int itemsPerLine)
        {
            string newLin = Environment.NewLine;
            var intsPerLine = input.Select((i, index) => (Integer: i, Index: index))
                .GroupBy(x => x.Index / itemsPerLine, x => x.Integer.ToString())
                .Select(g => string.Join(", ", g) + ",");
            string result = $"[{string.Join(newLin, intsPerLine).TrimEnd(',')}]" + newLin;
            return result;
        }
    }
}
