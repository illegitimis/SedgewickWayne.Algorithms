using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SedgewickWayne.Algorithms.AnteRoom
{

    public class Quick3string
    {
        private const int CUTOFF = 15;
        //[Modifiers(Modifiers.Static | Modifiers.Final | Modifiers.Synthetic)]
        internal static bool s_assertionsDisabled;




        private static void sort(string[] array, int num, int num2, int num3)
        {
            if (num2 <= num + 15)
            {
                Quick3string.insertion(array, num, num2, num3);
                return;
            }
            int num4 = num;
            int num5 = num2;
            int num6 = Quick3string.charAt(array[num], num3);
            int i = num + 1;
            while (i <= num5)
            {
                int num7 = Quick3string.charAt(array[i], num3);
                if (num7 < num6)
                {
                    int arg_47_1 = num4;
                    num4++;
                    int arg_47_2 = i;
                    i++;
                    Quick3string.exch(array, arg_47_1, arg_47_2);
                }
                else if (num7 > num6)
                {
                    int arg_5A_1 = i;
                    int arg_5A_2 = num5;
                    num5 += -1;
                    Quick3string.exch(array, arg_5A_1, arg_5A_2);
                }
                else
                {
                    i++;
                }
            }
            Quick3string.sort(array, num, num4 - 1, num3);
            if (num6 >= 0)
            {
                Quick3string.sort(array, num4, num5, num3 + 1);
            }
            Quick3string.sort(array, num5 + 1, num2, num3);
        }


        private static bool isSorted(string[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                if (java.lang.String.instancehelper_compareTo(array[i], array[i - 1]) < 0)
                {
                    return false;
                }
            }
            return true;
        }


        private static void insertion(string[] array, int num, int num2, int num3)
        {
            for (int i = num; i <= num2; i++)
            {
                int num4 = i;
                while (num4 > num && Quick3string.less(array[num4], array[num4 - 1], num3))
                {
                    Quick3string.exch(array, num4, num4 - 1);
                    num4 += -1;
                }
            }
        }


        private static int charAt(string @this, int num)
        {
            if (!Quick3string.s_assertionsDisabled && (num < 0 || num > java.lang.String.instancehelper_length(@this)))
            {

                throw new AssertionError();
            }
            if (num == java.lang.String.instancehelper_length(@this))
            {
                return -1;
            }
            return (int)java.lang.String.instancehelper_charAt(@this, num);
        }

        private static void exch(string[] array, int num, int num2)
        {
            string text = array[num];
            array[num] = array[num2];
            array[num2] = text;
        }


        private static bool less(string @this, string this2, int num)
        {
            if (!Quick3string.s_assertionsDisabled && !java.lang.String.instancehelper_equals(java.lang.String.instancehelper_substring(@this, 0, num), java.lang.String.instancehelper_substring(this2, 0, num)))
            {

                throw new AssertionError();
            }
            for (int i = num; i < java.lang.Math.min(java.lang.String.instancehelper_length(@this), java.lang.String.instancehelper_length(this2)); i++)
            {
                if (java.lang.String.instancehelper_charAt(@this, i) < java.lang.String.instancehelper_charAt(this2, i))
                {
                    return true;
                }
                if (java.lang.String.instancehelper_charAt(@this, i) > java.lang.String.instancehelper_charAt(this2, i))
                {
                    return false;
                }
            }
            return java.lang.String.instancehelper_length(@this) < java.lang.String.instancehelper_length(this2);
        }


        public static void sort(string[] strarr)
        {
            StdRandom.shuffle(strarr);
            Quick3string.sort(strarr, 0, strarr.Length - 1, 0);
            if (!Quick3string.s_assertionsDisabled && !Quick3string.isSorted(strarr))
            {

                throw new AssertionError();
            }
        }


        public Quick3string()
        {
        }


        /**/
        public static void main(string[] strarr)
        {
            string[] array = StdIn.readAllStrings();
            int num = array.Length;
            Quick3string.sort(array);
            for (int i = 0; i < num; i++)
            {
                StdOut.println(array[i]);
            }
        }

        static Quick3string()
        {
            Quick3string.s_assertionsDisabled = !ClassLiteral<Quick3string>.Value.desiredAssertionStatus();
        }
    }


}
