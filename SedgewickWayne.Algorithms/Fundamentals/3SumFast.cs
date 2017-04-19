
namespace SedgewickWayne.Algorithms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class ThreeSumFast
    {

        static bool containsDuplicates(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] == array[i - 1])
                {
                    return true;
                }
            }
            return false;
        }


        public static int Count(int[] a)
        {
            int num = a.Length;
            Array.Sort(a);

            if (containsDuplicates(a))
                throw new ArgumentException("array contains duplicate integers");
            
            int count = 0;
            for (int i = 0; i < num; i++)
            {
                for (int j = i + 1; j < num; j++)
                {
                    int value = -(a[i] + a[j]);

                    if (Array.BinarySearch(a, value) > j)
                        count++;                    
                }
            }
            return count;
        }

    }
}
