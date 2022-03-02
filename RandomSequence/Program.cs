using System;
using System.Collections.Generic;

namespace RandomSequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> upToFortyFive = ListMethods.MakeNonRepeatingRandomListFromSequentialInts(45);
            Console.WriteLine(ListMethods.MakeBigStringFromIntListSB(upToFortyFive, 4));
            List<string> labeledNumbers = ListMethods.ConvertList(upToFortyFive, "This should not appear in return",
                13, "Yellow", 11, "Red", 9, "BLACK", 7, "Green", 5, "BLUE");
            Console.WriteLine(ListMethods.MakeBigStringFromStringListSB(labeledNumbers, 5));

        }
    }
}
