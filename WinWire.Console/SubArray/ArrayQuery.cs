using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinWire.Console.SubArray
{
    public static class ArrayQuery
    {
        public static int MaxSubArray(int[] nums)
        {
            if (nums.Length == 0) return 0;

            int maxSoFar = nums[0];
            int maxEndingHere = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                maxEndingHere = Math.Max(nums[i], maxEndingHere + nums[i]);
                maxSoFar = Math.Max(maxSoFar, maxEndingHere);
            }

            return maxSoFar;
        }
    }
}
