using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subarray_Sum_Equals_K
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = new int[] { -1, -1, 1, 0, 0 }; // 1 ,2 ,1, 1, 2, 1
            int k = 0;
            Console.WriteLine(SubarraySum_Improved(nums, k));

        }
        // bruteforce with o(n2)
        static int SubarraySum(int[] nums, int k)
        {
            int length = nums.Length;
            int count = 0;
            for (int i = 0; i < length; i++)
            {
                if (nums[i] == k) count++;
                int sum = nums[i];
                for (int j = i + 1; j < length; j++)
                {
                    sum += nums[j];
                    if (sum == k) count++;
                }
            }
            return count;
        }

        // Improved O(n) using dictionary and O(n) extra space
        static int SubarraySum_Improved(int[] nums, int k)
        {
            int length = nums.Length;
            int count = 0;
            Dictionary<int, int> hash = new Dictionary<int, int>();
            int sum = 0;
            for (int i = 0; i < length; i++)
            {
                sum += nums[i];
                if (sum == k) count++;
                int difference = sum - k;
                if (hash.ContainsKey(difference)) count += hash[difference];
                if (!hash.ContainsKey(sum))
                    hash.Add(sum, 1);
                else
                    hash[sum]++;
            }
            return count;
        }
    }
}
