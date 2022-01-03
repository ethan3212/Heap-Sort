using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace HeapSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] testArray = { 1, 0, 2, 9, 3, 8, 4, 7, 5, 6 };
            int N = testArray.Length;

            // display unsorted list
            WriteLine("Unsorted: ");

            foreach (int i in testArray)
            {
                Write(i + " ");
            }

            WriteLine();

            // call sort routine        
            HeapSort(testArray, N-1);
            //FixHeap(testArray, testArray[0], 7, N);

            // display sorted list
            WriteLine("Sorted: ");
            foreach (int i in testArray)
            {
                Write(i + " ");
            }

            WriteLine();
            ReadLine();
        }

        static void HeapSort(int[] list, int N)
        // list: the elements to be put into order
        // N the number of elements in the list
        {
            for (int i = (N/2); i >= 0; i--)
            {
                FixHeap(list, i, list[i], N);
            }   // end for

            for (int i = (N-1); i >= 0; i--)
            {
                Swap(list, (i + 1), 0);
                FixHeap(list, 0, list[0], i);
            }   // end for

        }   // end HeapSort

        static void FixHeap(int[] list, int root, int key, int bound)
        // list: the list/heap being sorted
        // root: the index of the root of the heap
        // key: the key value that needs to be reinserted in the heap
        // bound the upper limit (index) on the heap
        {
            int vacant = root;

            while ((2 * vacant) <= bound)
            {
                int largerChild = 2 * vacant;

                // find the larger of the two children
                if ((largerChild < bound) && (list[largerChild + 1] > list[largerChild]))
                {
                    largerChild = largerChild + 1;
                }   // end if

                // does the key belong above the child?
                if (key >= list[largerChild])
                {
                    // yes, stop looping
                    break;
                }   // end if

                else
                {
                    // no, move the larger child up
                    list[vacant] = list[largerChild];
                    vacant = largerChild;
                }   // end else

            }   // end while

            list[vacant] = key;
        }   // end FixHeap

        static void Swap(int[] list, int i, int j)
        {
            int temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }   // end Swap
    }
}
