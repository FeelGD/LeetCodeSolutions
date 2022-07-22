using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSolutions
{
    //Definition for singly-linked list.
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
    public class Solutions
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



            ListNode AddTwoNumbers(ListNode l1, ListNode l2)
            {
                ListNode head = new ListNode();
                var pointer = head;
                int curval = 0;
                while (l1 != null || l2 != null)
                {
                    curval = (l1 == null ? 0 : l1.val) + (l2 == null ? 0 : l2.val) + curval;
                    pointer.next = new ListNode(curval % 10);
                    pointer = pointer.next;
                    // overflow decimal, like 12, we keep 1 for the next loop
                    curval = curval / 10;
                    // if next l1/l2 is not null, go to the next node
                    l1 = l1?.next;
                    l2 = l2?.next;
                }
                // if there is overflow left, add a node
                if (curval != 0)
                {
                    pointer.next = new ListNode(curval);
                }
                return head.next;
            }



            #region functionCalls   
            #region TwoSum
            //int[] nums1 = { 3, 2, 4, 15 };
            //int target1 = 6;
            //Console.WriteLine(TwoSumV1(nums1, target1));
            //Console.WriteLine(TwoSumV2(nums1, target1));
            #endregion
            #region AddTwoNumbers
        #endregion


            #endregion

















            Console.ReadKey();
        }
}
}
