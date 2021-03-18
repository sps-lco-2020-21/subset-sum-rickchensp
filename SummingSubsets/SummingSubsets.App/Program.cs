using BinaryTreeEx.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace SummingSubsets.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rd = new Random();
            List<int> list = new List<int> { 10, 5, 17, 1, 2, 57 };
            for(int i = 0; i< 10; ++i)  //randomly generate the list
            {
                list.Add(rd.Next(100));
            }
            
            int target = 10980;

            (bool successful , List<int> sublist) = StackApproach(list, target);

            if (successful)
            {
                foreach (int num in sublist)
                {
                    Console.Write($"{num} ");
                }
            }

            else
            {
                Console.WriteLine("no sublist found");
            }
            Console.ReadKey();

        }  

        static (bool, List<int>) StackApproach(List<int> list, int target) //only works for short lists
        {
            Stack<List<int>> sublists = new Stack<List<int>>();
            List<int> sublist = new List<int> { };

            foreach (int num in list)
            {
                sublists.Push(new List<int> { num });
            }

            bool successful = false;
            while (sublists.Count > 0)
            {
                sublist = sublists.Pop();
                if(sublist.Sum() == target)
                {
                    successful = true;
                    break;
                }
                else if(sublist.Sum() > target)
                    continue;
                else
                {
                    foreach(int num in list)
                    {
                        if(!sublist.Contains(num))
                        {
                            List<int> pushingList = sublist.Select(x => x).ToList();
                            pushingList.Add(num);
                            sublists.Push(pushingList);
                        }
                    }
                }
            }
            return (successful, sublist);
        }

        static (List<int>, bool) BinaryTreeApproach(List<int> list, int target)
        {
            list.Sort();
            int sum = 0;
            bool successful = false;
            List<int> sublist = new List<int> { };
            BinaryTree tree = new BinaryTree(0);
            int i = 0;
            while(true)
            {
                if(sum == target)
                {
                    successful = true;
                    break;
                }
            }

            return (sublist, successful);
        }
    }
}

