using System;
using System.Collections.Generic;

namespace RandomSequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> upToFortyFive = ListMethods.MakeNonRepeatingRandomListFromSequentialInts(45);
            Console.WriteLine(ListMethods.MakeBigStringFromListSB(upToFortyFive, 4));
        }
    }
}
