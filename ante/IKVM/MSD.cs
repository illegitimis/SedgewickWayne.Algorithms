using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SedgewickWayne.Algorithms.AnteRoom
{

    public class MSD
    {
        private const int R = 256;
        private const int CUTOFF = 15;
        //[Modifiers(Modifiers.Static | Modifiers.Final | Modifiers.Synthetic)]
        internal static bool s_assertionsDisabled;




        private static void sort(string[] array, int num, int num2, int num3, string[] array2)
        {
            if (num2 <= num + 15)
            {
                MSD.insertion(array, num, num2, num3);
                return;
            }
            int[] array3 = new int[258];
            for (int i = num; i <= num2; i++)
            {
                int num4 = MSD.charAt(array[i], num3);
                int[] arg_33_0 = array3;
                int num5 = num4 + 2;
                int[] array4 = arg_33_0;
                array4[num5]++;
            }
            for (int i = 0; i < 257; i++)
            {
                int[] arg_54_0 = array3;
                int num5 = i + 1;
                int[] array4 = arg_54_0;
                array4[num5] += array3[i];
            }
            for (int i = num; i <= num2; i++)
            {
                int num4 = MSD.charAt(array[i], num3);
                int[] arg_7F_0 = array3;
                int num5 = num4 + 1;
                int[] array4 = arg_7F_0;
                int[] arg_8B_0 = array4;
                int arg_89_0 = num5;
                num5 = array4[num5];
                int num6 = arg_89_0;
                array4 = arg_8B_0;
                int arg_99_1 = num5;
                array4[num6] = num5 + 1;
                array2[arg_99_1] = array[i];
            }
            for (int i = num; i <= num2; i++)
            {
                array[i] = array2[i - num];
            }
            for (int i = 0; i < 256; i++)
            {
                MSD.sort(array, num + array3[i], num + array3[i + 1] - 1, num3 + 1, array2);
            }
        }


        private static void insertion(string[] array, int num, int num2, int num3)
        {
            for (int i = num; i <= num2; i++)
            {
                int num4 = i;
                while (num4 > num && MSD.less(array[num4], array[num4 - 1], num3))
                {
                    MSD.exch(array, num4, num4 - 1);
                    num4 += -1;
                }
            }
        }


        private static int charAt(string @this, int num)
        {
            if (!MSD.s_assertionsDisabled && (num < 0 || num > java.lang.String.instancehelper_length(@this)))
            {

                throw new AssertionError();
            }
            if (num == java.lang.String.instancehelper_length(@this))
            {
                return -1;
            }
            return (int)java.lang.String.instancehelper_charAt(@this, num);
        }


        private static bool less(string @this, string this2, int num)
        {
            if (!MSD.s_assertionsDisabled && !java.lang.String.instancehelper_equals(java.lang.String.instancehelper_substring(@this, 0, num), java.lang.String.instancehelper_substring(this2, 0, num)))
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

        private static void exch(string[] array, int num, int num2)
        {
            string text = array[num];
            array[num] = array[num2];
            array[num2] = text;
        }


        public static void sort(string[] strarr)
        {
            int num = strarr.Length;
            string[] array = new string[num];
            MSD.sort(strarr, 0, num - 1, 0, array);
        }


        public MSD()
        {
        }


        /**/
        public static void main(string[] strarr)
        {
            string[] array = StdIn.readAllStrings();
            int num = array.Length;
            MSD.sort(array);
            for (int i = 0; i < num; i++)
            {
                StdOut.println(array[i]);
            }
        }

        static MSD()
        {
            MSD.s_assertionsDisabled = !ClassLiteral<MSD>.Value.desiredAssertionStatus();
        }
    }
}
