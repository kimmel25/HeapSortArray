using System;

namespace HeapSortArray
{
    public class HeapSort
    {
        public static void Sort<T>(T[] arr) where T : IComparable<T>
        {
            int n = arr.Length;

            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(arr, n, i);
            }

            for (int i = n - 1; i >= 0; i--)
            {
                Swap(ref arr[0], ref arr[i]);
                Heapify(arr, i, 0);
            }
        }

        private static void Heapify<T>(T[] arr, int n, int i) where T : IComparable<T>
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            if (left < n && arr[left].CompareTo(arr[largest]) > 0)
            {
                largest = left;
            }

            if (right < n && arr[right].CompareTo(arr[largest]) > 0)
            {
                largest = right;
            }

            if (largest != i)
            {
                Swap(ref arr[i], ref arr[largest]);
                Heapify(arr, n, largest);
            }
        }

        public static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        public static void PrintArray<T>(T[] arr)
        {
            foreach (T item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        public static void Main(string[] args)
        {
            int[] arr = { 12, 11, 13, 5, 6, 7 };
            Console.WriteLine("Original :");
            PrintArray(arr);

            Sort(arr);

            Console.WriteLine("Sorted :");
            PrintArray(arr);
        }
    }
}
