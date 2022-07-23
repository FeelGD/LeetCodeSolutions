﻿using System;
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
                    //overflow decimal, like 12, we keep 1 for the next loop
                    curval = curval / 10;
                    //if next l1/l2 is not null, go to the next node
                    l1 = l1?.next;
                    l2 = l2?.next;
                }
                //if there is overflow left, add a node
                if (curval != 0)
                {
                    pointer.next = new ListNode(curval);
                }
                return head.next;
            }

            void SetZeroes(int[][] matrix)
            {

                var row = matrix.Length;
                var column = matrix[0].Length;

                var rowSet = new HashSet<int>();
                var columnSet = new HashSet<int>();

                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < column; j++)
                    {
                        if (matrix[i][j] == 0)
                        {
                            rowSet.Add(i);
                            columnSet.Add(j);
                        }
                    }
                }

                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < column; j++)
                        if (rowSet.Contains(i) || columnSet.Contains(j))
                        {
                            matrix[i][j] = 0;

                        }
                }
            }

            int NumJewelsInStones(string jewels, string stones)
            {
                var jewelsSet = new HashSet<char>();
                var jewChars = jewels.ToCharArray();
                var stonesChars = stones.ToCharArray();
                var counter = 0;
                var jLength = jewChars.Length;
                var sLength = stonesChars.Length;
                //foreach (var item in jewChars)
                //{
                //    jewelsSet.Add(item);
                //}
                for (int i = 0; i < jLength; i++)
                {
                    jewelsSet.Add(jewChars[i]);
                }
                //foreach (var item in stonesChars)
                //{
                //    if (jewelsSet.Contains(item))
                //    {
                //        counter++;
                //    }
                //}
                for (int i = 0; i < sLength; i++)
                {
                    if (jewelsSet.Contains(stonesChars[i]))
                    {
                        counter++;
                    }
                }

                return counter;
            }

            int NumUniqueEmails(string[] emails)
            {
                var counter = 0;
                var emailsSet = new HashSet<string>();
                foreach (var email in emails)
                {
                    var spitted = email.Split('@');
                    var prefix = spitted[0];
                    var suffix = spitted[1];
                    if (prefix.Contains("+"))
                    {
                        prefix = prefix.Split('+')[0];
                    }
                    if (prefix.Contains("."))
                    {
                        prefix = prefix.Replace(".", "");
                    }
                    if (!emailsSet.Contains(prefix + "@" + suffix))
                    {
                        emailsSet.Add(prefix + "@" + suffix);
                        counter++;
                    }

                }


                return counter;
            }


            bool ContainsDuplicate(int[] nums)
            {
                var numsSet = new HashSet<int>();
                var numLength = nums.Length;
                //foreach(int num in nums){
                //    if(numsSet.Contains(num))
                //    {
                //        return true;
                //    }
                //    numsSet.Add(num);
                //}
                for (int i = 0; i < numLength; i++)
                {
                    if (numsSet.Contains(nums[i]))
                    {
                        return true;
                    }
                    numsSet.Add(nums[i]);
                }
                return false;
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
            #region NumJewelsInStones
            //var jawels1 = "aA";
            //var stones1 = "aAaAbbbb"; 
            //Console.WriteLine(NumJewelsInStones(jawels1, stones1));
            #endregion
            #region NumUniqueEmails
            //string[] emails1 = { "test.email+alex@leetcode.com", "test.email.leet+alex@code.com" };
            //Console.WriteLine(NumUniqueEmails(emails1));
            #endregion
            #region ContainsDuplicate
            int[] nums1 = { 1, 2, 1, 1 };
            Console.WriteLine(ContainsDuplicate(nums1));
            #endregion

            #endregion

















            Console.ReadKey();
        }
    }
}
