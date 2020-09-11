using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    class Program
    {
        static void HeapifyCreate()
        {
            Console.WriteLine("\n\nHeapify: \n");

            MaxHeap heapify = new MaxHeap();

            int[] A = { 5, 10, 30, 20, 35, 40, 15 };
            Console.WriteLine("Size of A = {0}", A.Length);


            heapify.Heapify(A, A.Length);
            DisplayHeap(A);

            int[] B = { 5, 10, 30, 20 };
            Console.WriteLine("Size of B = {0}", B.Length);

            heapify.Heapify(B, B.Length);
            DisplayHeap(B);
        }
        static void Main(string[] args)
        {
            MaxHeap heap = new MaxHeap();
            MaxHeap maxHeap = new MaxHeap();
            var a = new int[] { 45, 35, 15, 30, 10, 12, 6, 5, 20, 50 };
            DisplayHeap(a);
            Console.WriteLine("Inplace Insert");
            heap.InsertInplace(a, 9); //insert 50 at index 9
            DisplayHeap(a);

            Console.WriteLine("Create Heap");
            int[] b = { 10, 20, 30, 25, 5, 40, 35 };

            /*
            List<int> arrList = new List<int>();
            maxHeap.CreateHeap(arrList, b, b.Length);
            DisplayHeap(arrList);*/

            Console.WriteLine("Inplace Insert");
            maxHeap.CreateHeap(b, b.Length);
            DisplayHeap(b);

            //DELETE FROM HEAP
            
            Console.WriteLine("Delete:\n");

            MaxHeap mh = new MaxHeap();
            int[] b1 = {10, 20, 30,25, 5, 40, 35 }; //output: 40,25,35,10,5,20,30
            for (int i = 0; i < b1.Length; i++) //heap size=7 here
            {
                mh.InsertInplace(b1, i);
            }
            DisplayHeap(b1);
            
            for (int i = b1.Length; i > 0; i--)
            {
                Console.Write("{0}\t", maxHeap.Delete(b1, i));
                
            }
            Console.WriteLine("\n");
            DisplayHeap(b1);

            HeapifyCreate();

            Console.ReadKey();
        }

        static void DisplayHeap(int[] arr)
        {
            foreach (var a in arr)
                Console.Write("{0}\t", a);
            Console.WriteLine("\n");
        }
        static void DisplayHeap(List<int> arr)
        {
            foreach (var a in arr)
                Console.Write("{0}\t", a);
            Console.WriteLine("\n");
        }
    }
}
