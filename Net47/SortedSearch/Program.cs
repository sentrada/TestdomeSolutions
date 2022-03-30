/* Implement function CountNumbers that accepts a sorted array of unique integers and, efficiently with respect to
*  time used, counts the number of array elements that are less than the parameter lessThan.
*  For example, SortedSearch.CountNumbers(new int[] { 1, 3, 5, 7 }, 4) should return 2 because there are two array
*  elements less than 4.*/
using System;
using System.Collections.Generic;

namespace SortedSearch
{
    

    public class SortedSearch
    {
        public static int CountNumbers(int[] sortedArray, int lessThan)
        {
            var comparer = Comparer<int>.Default;
            var totalCount = sortedArray.Length - 1;
            
            var min = 0;
            var max = 0 + totalCount;
            while (min <= max)
            {
                var mid = min + (max - min >> 1);
                var compareResult = comparer.Compare(sortedArray[mid], lessThan);
                if (compareResult == 0)
                    return mid;
                if (compareResult < 0)
                {
                    if (mid < totalCount - 1 && comparer.Compare(sortedArray[mid + 1], lessThan) >= 0)
                        return mid + 1;
                    
                    min = mid + 1;
                }
                else
                {
                    if (mid >= 1 && comparer.Compare(sortedArray[mid - 1], lessThan) < 0)
                        return mid;
                    max = mid - 1;
                }

            }
            return min;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine(SortedSearch.CountNumbers(new int[] { 1, 3, 5, 7 }, 4));
        }
    }
}