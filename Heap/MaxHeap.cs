using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    /// <summary>
    /// Max heap is that type of heap which is
    ///     a complete Binary tree
    ///     and parent node is greater than the child nodes
    /// </summary>
    public class MaxHeap
    {
        public void CreateHeap(int[] arr, int n)
        {
            for (int i = 0; i < n; i++)
            {
                InsertInplace(arr, i);
            }
        }
        //Insert into Heap
        /// <summary>
        /// Basic Idea about parent and child index
        /// if a Node is at Index i,
        ///               left child will be at (2*i)
        ///               right child will be at (2*i + 1)
        ///               
        /// if index of left or right child is known,
        ///             parent will be at i/2 (take floor value)
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public void InsertInplace(int[] arr, int insertIndex)  //following the algorithm provided in the book. time complexity: O(log(n))
        {
            int currentIndex = insertIndex;
            int temp = arr[insertIndex]; //store in the temporary value.

            while (currentIndex > 0)
            {
                int tempIndex = currentIndex % 2 == 0 ? (currentIndex / 2) - 1 : currentIndex / 2;
                if (temp > arr[tempIndex])
                {
                    arr[currentIndex] = arr[tempIndex]; //copy the value to the parent index
                    currentIndex = tempIndex; //update parent index
                }
                else
                    break;
            } 
            arr[currentIndex] = temp;

        }
        public void CreateHeap(List<int> arrList, int[] arr, int n)
        {
            // O(n log n)
            for (int i = 0; i < n; i++)
            {
                Insert(arrList, arr[i]);
            }
        }
        public void Insert(List<int> arrList, int key)
        {
            // Insert key at the end
            int i = arrList.Count;
            arrList.Add(key);

            // Rearrange elements: O(log n)
            while (i > 0 && key > arrList[i / 2])
            {
                arrList[i] = arrList[i / 2];
                i = i / 2;
            }
            arrList[i] = key;
        }

        public int Delete(int[] arr, int heapSize)
        {
            ///<summary>
            ///if array index starts from 1 to n.... left Child will be at 2i and Right child will be at 2i+1
            ///if array index starts from 0 to n-1.... left Child will be at 2i+1 and Right child will be at 2i+2
            ///</summary>
            
            int valueToDelete = arr[0]; // we can only delete the first value from HEAP
            int x = arr[heapSize - 1]; //lookup the last value in the heap

            arr[0] = x; //set last value to the first one and see if any child is greater than it or not because it is a MaxHeap
           // arr[heapSize - 1] = valueToDelete;

            int i = 0; // i starts from the 1st index:: this is for Parent Node
            int j = 2*i + 1; // and j should point to the LEFT Child 

            

            while (j <= heapSize - 2) //we have removed one element so heapSize-1 - 1.
            {
                if (arr[j + 1] > arr[j]) //arr[j+1] = RIGHT Child, arr[j] = LEFT Child
                    j = j + 1; //point to the Right Child

                if (arr[i] < arr[j]) //A[i]=Parent and now j points either left or right child. Swap if parent is less than child
                {
                    //Swapping
                    int temp = arr[i]; 
                    arr[i] = arr[j];
                    arr[j] = temp;

                    //adjust nodes
                    i = j; //now parent node moves to the child position
                    j = 2 * j + 1; //and child moves to its Left child
                }
                else
                    break;
            }

            return valueToDelete;
        }


        public void Heapify(int[] arr, int n) //O(N): better than normal heap creation which was taking O(nLogn)
        {
            //Heapify- starts with leaf node and move towards root unlike normal insert where it starts from root

            // # of leaf elements: (n+1)/2, index of last leaf element's parent = (n/2)-1
            for (int i = (n / 2) - 1; i >= 0; i--)
            {

                int j = 2 * i + 1;  // Left child for current i

                while (j < n - 1)
                {
                    // Compare left and right children of current i
                    if (arr[j] < arr[j + 1])
                    {
                        j = j + 1;
                    }

                    // Compare parent and largest child
                    if (arr[i] < arr[j])
                    {
                        //swap(arr, i, j);
                        int temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;

                        i = j;
                        j = 2 * i + 1;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
}
