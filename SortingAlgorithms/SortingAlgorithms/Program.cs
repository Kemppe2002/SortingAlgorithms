using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SortingAlgorithms
{
    class Program
    {
        static void RandomList(List<int> myList, int size) //Takes a list and list size and adds random numbers in all spaces
        {
            Random random1 = new Random();
            for (int i = 0; i < size; i++)
            {
                myList.Add(random1.Next(1000000)); //Randomizes numbers from 1 to 1 000 000
            }
        }

        static void BubbleSort(List<int> myList) //BubbleSort algorithm
        {
            var timer = new Stopwatch(); //Creates a timer
            timer.Start();

            for (int i = 0; i < myList.Count; i++) //Counts the number of times the list is gone through
            {
                for (int j = 0; j < myList.Count-1; j++) //Walks through all numbers in the list
                {
                    if (myList[j] > myList[j + 1]) //If two numbers are in the wrong order, swap the numbers
                    {
                        int temp = myList[j];
                        myList[j] = myList[j + 1];
                        myList[j + 1] = temp;
                    }
                }
            }
            timer.Stop(); //Stops timer, prints out result and resets timer
            Console.WriteLine(myList.Count + " elements: " + timer.Elapsed.TotalMilliseconds + " ms");
        }

        static void SelectionSort(List<int> myList) //SelectionSort algorithm
        {
            var timer = new Stopwatch();
            timer.Start();

            for (int i = 0; i < myList.Count - 1; i++) //Walks through the list
            {
                for (int j = i+1; j < myList.Count; j++) //Walks through all elements after the first one
                {
                    if (myList[j] < myList[i]) //If an element is smaller than the first one then swap place
                    {
                        int temp = myList[i];
                        myList[i] = myList[j];
                        myList[j] = temp;
                    }
                }
            }

            timer.Stop();
            Console.WriteLine(myList.Count + " elements: " + timer.Elapsed.TotalMilliseconds + " ms");
        }

        static List<int> MergeSort(List<int> myList) //MergeSort algorithm part 1 (divide)
        {
            var timer = new Stopwatch();
            timer.Start();

            if (myList.Count < 2) return myList; //Stops fully divided lists from reentering code

            var list_1 = new List<int>(); //Creates two new lists and a marker for the middle of the main list
            var list_2 = new List<int>();
            int middle = myList.Count / 2;

            for (int i = 0; i < middle; i++) // Divides the list into the two new lists
            {
                list_1.Add(myList[i]);
            }
            for (int i = middle; i < myList.Count; i++)
            {
                list_2.Add(myList[i]);
            }

            list_1 = MergeSort(list_1); //Loops the algorithm until all lists contain one element then sends to the merging algorithm
            list_2 = MergeSort(list_2);
            return Merge(list_1, list_2);
        }

        static List<int> Merge(List<int> list_1, List<int> list_2) //MergeSort algorithm part 2 (merge)
        {
            var sorted = new List<int>();
            while (list_1.Count > 0 || list_2.Count > 0) //Loops the algorithm until both lists are merged to one
            {
                if (list_1.Count > 0 && list_2.Count > 0) //If both lists contain more than 0 elements
                {
                    if (list_1.First() > list_2.First()) //Decide which list's first element is lower
                    {
                        sorted.Add(list_2.First()); //Add the lowest element to the completed list and remove from the temporary list
                        list_2.Remove(list_2.First());
                    }
                    else
                    {
                        sorted.Add(list_1.First());
                        list_1.Remove(list_1.First());
                    }
                }
                else if (list_1.Count > 0) //If only one list contain more than 0 elements
                {
                    sorted.Add(list_1.First()); //Add first (lowest) element to the completed list
                    list_1.Remove(list_1.First());
                }
                else
                {
                    sorted.Add(list_2.First());
                    list_2.Remove(list_2.First());
                }
            }
            return sorted;
        }

        static List<int> QuickSort(List<int> myList) //Quicksort algorithm
        {
            if (myList.Count < 2) return myList; //Stops fully divided lists from reentering code

            int pivotIndex = myList.Count / 2; //Creates two integers by reading the index and value of the middle element in the list
            int pivotValue = myList[pivotIndex];

            var list_1 = new List<int>(); //Creates two lists
            var list_2 = new List<int>();

            for (int i=0; i<myList.Count; i++) //Divides the list into the new lists, one with all of the lowest and one with all of the highest elements
            {
                if (i == pivotIndex) continue;
                if (myList[i] <= pivotValue) list_1.Add(myList[i]);
                else list_2.Add(myList[i]);
            }

            var sorted = QuickSort(list_1); //Loops the code until a list contains 1 element, therefore adds first half of the original list to the sorted list in the right order
            sorted.Add(pivotValue); //Adds the middle element to the sorted list
            sorted.AddRange(QuickSort(list_2)); //Loop the code until a list contains 1 element, therfore adds second half of the original list to the sorted list in the right order
            return sorted;
        }

        static void Sort(List<int> myList) //Sort function
        {
            var timer = new Stopwatch();
            timer.Start();
            myList.Sort();
            timer.Stop();
            Console.WriteLine(myList.Count + " elements: " + timer.Elapsed.TotalMilliseconds + " ms");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Bubblesort");
            var list1a = new List<int>(); //Creates a list
            RandomList(list1a, 10000); //Adds random numbers to the list
            BubbleSort(list1a); //Calls the bubblesort function

            var list2a = new List<int>();
            RandomList(list2a, 20000);
            BubbleSort(list2a);

            var list3a = new List<int>();
            RandomList(list3a, 40000);
            BubbleSort(list3a);

            var list4a = new List<int>();
            RandomList(list4a, 80000);
            BubbleSort(list4a);

            //
            //

            Console.WriteLine("\nSelectionsort");
            var list1b = new List<int>();
            RandomList(list1b, 10000);
            SelectionSort(list1b);


            var list2b = new List<int>();
            RandomList(list2b, 20000);
            SelectionSort(list2b);

            var list3b = new List<int>();
            RandomList(list3b, 40000);
            SelectionSort(list3b);

            var list4b = new List<int>();
            RandomList(list4b, 80000);
            SelectionSort(list4b);

            //
            //

            Console.WriteLine("\nMergeSort");
            var list1c = new List<int>();
            RandomList(list1c, 10000);
            var timer = new Stopwatch();
            timer.Start();
            MergeSort(list1c);
            timer.Stop();
            Console.WriteLine(list1c.Count + " elements: " + timer.Elapsed.TotalMilliseconds + " ms");
            timer.Restart();

            var list2c = new List<int>();
            RandomList(list2c, 20000);
            timer.Start();
            MergeSort(list2c);
            timer.Stop();
            Console.WriteLine(list2c.Count + " elements: " + timer.Elapsed.TotalMilliseconds + " ms");
            timer.Restart();

            var list3c = new List<int>();
            RandomList(list3c, 40000);
            timer.Start();
            MergeSort(list3c);
            timer.Stop();
            Console.WriteLine(list3c.Count + " elements: " + timer.Elapsed.TotalMilliseconds + " ms");
            timer.Restart();

            var list4c = new List<int>();
            RandomList(list4c, 80000);
            timer.Start();
            MergeSort(list4c);
            timer.Stop();
            Console.WriteLine(list4c.Count + " elements: " + timer.Elapsed.TotalMilliseconds + " ms");
            timer.Restart();

            //
            //

            Console.WriteLine("\nQuickSort");
            var list1d = new List<int>();
            RandomList(list1d, 10000);
            timer.Start();
            QuickSort(list1d);
            timer.Stop();
            Console.WriteLine(list1d.Count + " elements: " + timer.Elapsed.TotalMilliseconds);
            timer.Restart();

            var list2d = new List<int>();
            RandomList(list2d, 20000);
            timer.Start();
            QuickSort(list2d);
            timer.Stop();
            Console.WriteLine(list2d.Count + " elements: " + timer.Elapsed.TotalMilliseconds);
            timer.Restart();

            var list3d = new List<int>();
            RandomList(list3d, 40000);
            timer.Start();
            QuickSort(list3d);
            timer.Stop();
            Console.WriteLine(list3d.Count + " elements: " + timer.Elapsed.TotalMilliseconds);
            timer.Restart();

            var list4d = new List<int>();
            RandomList(list4d, 80000);
            timer.Start();
            QuickSort(list4d);
            timer.Stop();
            Console.WriteLine(list4d.Count + " elements: " + timer.Elapsed.TotalMilliseconds);
            timer.Restart();

            //
            //

            Console.WriteLine("\nSort");
            var list1e = new List<int>();
            RandomList(list1e, 10000);
            list1e.Sort();
            Sort(list1e);

            var list2e = new List<int>();
            RandomList(list2e, 20000);
            list2e.Sort();
            Sort(list2e);

            var list3e = new List<int>();
            RandomList(list3e, 40000);
            list3e.Sort();
            Sort(list3e);

            var list4e = new List<int>();
            RandomList(list4e, 80000);
            list4e.Sort();
            Sort(list4e);
        }
    }
}
