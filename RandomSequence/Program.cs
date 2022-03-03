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

            List<int> upToSixteen = ListMethods.MakeNonRepeatingRandomListFromSequentialInts(16);
            List<string> fourCats = ListMethods.ConvertList(upToSixteen, "This should not appear in return",
                4, "One", 4, "Two", 4, "Three", 4, "Four");
            Console.WriteLine(ListMethods.MakeBigStringFromStringListSB(fourCats, 4));
            Console.WriteLine();


            List<int> upToNinetySix = ListMethods.MakeNonRepeatingRandomListFromSequentialInts(96);
            List<int> firstHalf = upToNinetySix.GetRange(0, 48);
            List<int> secondHalf = upToNinetySix.GetRange(48, 48);
            List<string> sixColors = ListMethods.ConvertList(firstHalf, "This should not appear in return",
                16, "Yellow", 16, "Red", 16, "Green", 16, "BLUE", 16, "BROWN", 16, "Purple");
            Console.WriteLine(ListMethods.MakeBigStringFromStringListSB(sixColors, 6));

            List<string> sixColorsAgain = ListMethods.ConvertList(secondHalf, "This should not appear in return",
                16, "Yellow", 16, "Red", 16, "Green", 16, "BLUE", 16, "BROWN", 16, "Purple");
            Console.WriteLine(ListMethods.MakeBigStringFromStringListSB(sixColorsAgain, 6));
            var histo96 = ListMethods.GetHistogram(sixColors, sixColorsAgain);
            ListMethods.PrintHistogram(histo96);
        }
    }
}
