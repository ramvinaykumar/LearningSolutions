using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinWire.Console.BubbleSort
{
    public static class SortingProgram
    {
        public static int[] BubbleSort_ForLoop(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        // Swap elements if they are in the wrong order
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
            return arr;
        }

        public static int[] BubbleSort_WhileLoop(int[] arr)
        {
            int[] newarr = new int[arr.Length];
            int iterate = 0;
            int iterateCount = 0;
            int temp = 0;
            while ((iterate < arr.Length - 1) && (iterateCount != arr.Length))
            {
                if (arr[iterate] > arr[iterate + 1])
                {
                    temp = arr[iterate + 1];
                    arr[iterate + 1] = arr[iterate];
                    arr[iterate] = temp;
                }
                iterate++;

                if (iterate == arr.Length - 1)
                {
                    iterate = 0;
                    iterateCount++;
                }
            }
            return arr;
        }
    }
}
