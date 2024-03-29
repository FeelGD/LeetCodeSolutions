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
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
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

            ListNode GetIntersectionNode(ListNode headA, ListNode headB)
            {

                var aSet = new HashSet<ListNode>();

                while (headA != null)
                {
                    aSet.Add(headA);
                    headA = headA.next;
                }
                while (headB != null)
                {
                    if (aSet.Contains(headB))
                    {
                        return headB;
                    }
                    headB = headB.next;
                }
                return null;

            }

            int Oklid(int num1, int num2)
            {
                if (num2 == 0)
                {
                    return num1;
                }
                return Oklid(num2, num1 % num2);
            }

            IList<int> PrimeFactors(int n)
            {
                var primes = new List<int>();
                for (int i = 2; i <= Math.Sqrt(n); i++)
                {
                    while (n % i == 0)
                    {
                        n /= i;
                        primes.Add(i);
                    }
                }
                if (n != 1)
                {
                    primes.Add(n);
                }
                return primes;
            }

            int FibonacciNth(int n)
            {
                if (n == 0) return 0;
                if (n == 1) return 1;

                var current = 1;
                var previous = 1;
                var counter = n - 1;
                while (counter > 0)
                {
                    current = current + previous;
                    previous = current - previous;
                    counter--;
                }
                return current;
            }

            bool IsPowerOfTwo(int n)
            {
                if (n < 1)
                {
                    return false;
                }

                while (n != 1)
                {
                    if (n % 2 != 0)
                    {
                        return false;
                    }
                    n /= 2;

                }
                return true;
            }
            bool IsPowerOfTwoBitWise(int n)
            {

                if (n < 1)
                {
                    return false;
                }
                return (n & (n - 1)) == 0;


            }

            bool IsSameTree(TreeNode p, TreeNode q)
            {

                if (p == null && q == null) return true;
                if (p == null || q == null) return false;
                if (p.val != q.val) return false;
                return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
            }

            int SumOfLeftLeaves(TreeNode root)
            {
                if (root == null)
                {
                    return 0;
                }
                else if (root.left != null && root.left.left == null && root.left.right == null)
                {
                    return root.left.val + SumOfLeftLeaves(root.right);
                }

                else
                {
                    return SumOfLeftLeaves(root.left) + SumOfLeftLeaves(root.right);
                }
            }

            TreeNode InvertTree(TreeNode root)
            {
                if (root == null)
                {
                    return null;
                }
                var rightSubTree = InvertTree(root.right);
                var leftSubTree = InvertTree(root.left);

                root.right = leftSubTree;
                root.left = rightSubTree;

                return root;
            }

            TreeNode MergeTrees(TreeNode root1, TreeNode root2)
            {
                if (root1 == null) return root2;
                if (root2 == null) return root1;
                root1.val += root2.val;

                root1.left = MergeTrees(root1.left, root2.left);
                root1.right = MergeTrees(root1.right, root2.right);

                return root1;

            }
            
            string Translate(string morseToEnglish, string textToTranslate)
            {
                Dictionary<string, string> morseCodes = new Dictionary<string, string>
            {
                { "A", ".-" },
                { "B", "-..." },
                { "C", "-.-." },
                { "D", "-.." },
                { "E", "." },
                { "F", "..-." },
                { "G", "--." },
                { "H", "...." },
                { "I", ".." },
                { "J", ".---" },
                { "K", "-.-" },
                { "L", ".-.." },
                { "M", "--" },
                { "N", "-." },
                { "O", "---" },
                { "P", ".--." },
                { "Q", "--.-" },
                { "R", ".-." },
                { "S", "..." },
                { "T", "-" },
                { "U", "..-" },
                { "V", "...-" },
                { "W", ".--" },
                { "X", "-..-" },
                { "Y", "-.--" },
                { "Z", "--.." },
                { "1", ".----" },
                { "2", "..---" },
                { "3", "...--" },
                { "4", "....-" },
                { "5", "....." },
                { "6", "-...." },
                { "7", "--..." },
                { "8", "---.." },
                { "9", "----." },
                { "0", "-----" },
                { ".", ".-.-.-" }
            };

                if (morseToEnglish == "true")
                {
                    string[] words = textToTranslate.Split(new string[] { "   " }, StringSplitOptions.None);
                    string translatedText = "";

                    foreach (string word in words)
                    {
                        string[] letters = word.Split(' ');
                        foreach (string letter in letters)
                        {

                            if (!morseCodes.ContainsValue(letter))
                            {
                                if (!letter.Equals("."))
                                {
                                    return "Invalid Morse Code Or Spacing";
                                }
                            }


                            foreach (KeyValuePair<string, string> code in morseCodes)
                            {
                                if (code.Value == letter)
                                {
                                    translatedText += code.Key;
                                    break;
                                }
                            }
                        }
                        translatedText += " ";
                    }

                    return translatedText.TrimEnd();
                }
                else
                {
                    textToTranslate = textToTranslate.ToUpper();
                    string translatedText = "";

                    foreach (char letter in textToTranslate)
                    {
                        if (letter == ' ')
                        {
                            translatedText += "   ";
                        }
                        else
                        {
                            if (!morseCodes.ContainsKey(letter.ToString()))
                            {
                                return "Invalid Morse Code Or Spacing";
                            }
                            translatedText += morseCodes[letter.ToString()] + " ";
                        }
                    }

                    return translatedText.TrimEnd();
                }
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
            //int[] nums1 = { 1, 2, 1, 1 };
            //Console.WriteLine(ContainsDuplicate(nums1));
            #endregion

            #endregion



            Console.WriteLine(Translate("false", "The wizard quickly jinxed the gnomes before they vaporized."));





























            Console.ReadKey();
        }
    }
}
