namespace MyBubbleSortProj;

public class MyBubbleSort<T> where T : IComparable<T>
{
    public void Sort(T[] items)
    {
        bool swapped;
        do
        {
            swapped = false;
            for (int i = 1; i < items.Length; i++)
            {
                if ((items[i - 1].CompareTo(items[i]) > 0))
                {
                    Swap(items, i - 1, i);
                    swapped = true;
                }
            }
        } while (swapped != false);
    }
    private void Swap(T[] items, int i, int j)
    {
        T temp = items[i];
        items[i] = items[j];
        items[j] = temp;
    }

}
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBubbleSortProj;

public class MyInsertionSort<T> where T : IComparable<T>
{
    public void Sort(T[] items)
    {
        if (items == null || items.Length < 2) return;

        for (int i = 1; i < items.Length; i++)
        {
            T key = items[i]; 
            int j = i - 1;

            while (j >= 0 && items[j].CompareTo(key) > 0)
            {
                items[j + 1] = items[j]; 
                j = j - 1;
            }

            items[j + 1] = key;
        }
    }
}
using System;

namespace MyBubbleSortProj;

public class MyMergeSort<T> where T : IComparable<T>
{
    public void Sort(T[] items)
    {
        if (items == null || items.Length < 2) return;
        MergeSort(items, 0, items.Length - 1);
    }

    private void MergeSort(T[] items, int left, int right)
    {
        if (left < right)
        {
            int mid = left + (right - left) / 2;

            MergeSort(items, left, mid);
            MergeSort(items, mid + 1, right);

            Merge(items, left, mid, right);
        }
    }

    private void Merge(T[] items, int left, int mid, int right)
    {
        int length = right - left + 1;
        T[] temp = new T[length];

        int i = left;     
        int j = mid + 1;  
        int k = 0;  

        while (i <= mid && j <= right)
        {
            if (items[i].CompareTo(items[j]) <= 0)
            {
                temp[k] = items[i];
                i++;
            }
            else
            {
                temp[k] = items[j];
                j++;
            }
            k++;
        }


        while (i <= mid)
        {
            temp[k] = items[i];
            i++;
            k++;
        }

        while (j <= right)
        {
            temp[k] = items[j];
            j++;
            k++;
        }

        for (k = 0; k < length; k++)
        {
            items[left + k] = temp[k];
        }
    }
}
namespace MyBubbleSortProj;

public class MyQuickSort<T> where T : IComparable<T>
{
    public void Sort(T[] items)
    {
        if (items == null || items.Length < 2) return;
        QuickSort(items, 0, items.Length - 1);
    }

    private void QuickSort(T[] items, int left, int right)
    {
        if (left < right)
        {
            int pivotIndex = Partition(items, left, right);


            QuickSort(items, left, pivotIndex - 1);
            QuickSort(items, pivotIndex + 1, right);
        }
    }

    private int Partition(T[] items, int left, int right)
    {
    
        T pivot = items[right];
        int i = left - 1;

        for (int j = left; j < right; j++)
        {
            if (items[j].CompareTo(pivot) < 0)
            {
                i++;
                Swap(items, i, j);
            }
        }

        Swap(items, i + 1, right);
        return i + 1;
    }

    private void Swap(T[] items, int index1, int index2)
    {
        T temp = items[index1];
        items[index1] = items[index2];
        items[index2] = temp;
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBubbleSortProj;

public class MySelectionSort<T> where T : IComparable<T>
{
    public void Sort(T[] items)
    {
        for (int i = 0; i < items.Length - 1; i++)
        {
            int minIndex = i;

            for (int j = i + 1; j < items.Length; j++)
            {
                if (items[j].CompareTo(items[minIndex]) < 0)
                {
                    minIndex = j; 
                }
            }

            if (minIndex != i)
            {
                T temp = items[i];
                items[i] = items[minIndex];
                items[minIndex] = temp;
            }
        }
    }
}