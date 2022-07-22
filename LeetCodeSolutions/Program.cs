using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSolutions
{
    public class Program
    {
        static void Main(string[] args)
        {

            //we assume nums not null&&target > 0
            //time Complexity: O(n^2) Space complexity: O(1)
            int[] TwoSumV1(int[] nums, int target)
            {
                int numsLength = nums.Length;
                for (int i = 0; i < numsLength; i++)
                {
                    for (int j = i + 1; j < numsLength; j++)
                    {
                        if (nums[i] + nums[j] == target)
                        {
                            return new int[] { i, j };

                        }
                    }

                }
                return Array.Empty<int>();
            }
            //time Complexity: O(n) Space complexity: O(n)
            int[] TwoSumV2(int[] nums, int target)
            {
                int numsLength = nums.Length;
                Dictionary<int, int> dictionaryNums = new Dictionary<int, int>();

                for (int i = 0; i < numsLength; i++)
                {
                    int numberOne = nums[i];
                    int numberTwo = target - numberOne;
                    if (dictionaryNums.TryGetValue(numberTwo, out int index))
                    {
                        return new[] { index, i };
                    }
                    dictionaryNums[numberOne] = i;
                }
                return Array.Empty<int>();
            }









            #region functionCalls   
            #region TwoSum
            //int[] nums1 = { 3, 2, 4, 15 };
            //int target1 = 6;
            //Console.WriteLine(TwoSumV1(nums1, target1));
            //Console.WriteLine(TwoSumV2(nums1, target1));
            #endregion


            #endregion

















            Console.ReadKey();
        }
    }
}
