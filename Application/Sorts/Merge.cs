﻿using System;
using System.Collections.Generic;

namespace Application.Sorts
{
    public static class Merge
    {
        public static IList<T> MergeSort<T>(this IList<T> array, Func<T, T, bool> comparingFunction)
        {
            return SortAndMerge<T>(array, 0, array.Count - 1, comparingFunction);
        }

        public static IList<int> MergeSort(this IList<int> array)
        {
            return array.MergeSort<int>((a, b) => a < b);
        }

        private static IList<T> SortAndMerge<T>(IList<T> array, int start, int end, Func<T, T, bool> comparingFunction)
        {
            if (start < end)
            {
                int middle = start + (end - start) / 2;

                SortAndMerge<T>(array, start, middle, comparingFunction);
                SortAndMerge<T>(array, middle + 1, end, comparingFunction);

                MergeArray<T>(array, start, middle, end, comparingFunction);
            }

            return array;
        }

        private static void MergeArray<T>(IList<T> array, int start, int middle, int end, Func<T, T, bool> comparingFunction)
        {
            int sizeL = middle - start + 1;
            int sizeR = end - middle;

            T[] L = new T[sizeL];
            T[] R = new T[sizeR];

            for (int h = 0; h < sizeL; h++)
                L[h] = array[start + h];
            for (int h = 0; h < sizeR; h++)
                R[h] = array[middle + h + 1];

            int i = 0, j = 0, k = start;

            while (i < sizeL && j < sizeR)
            {
                if (comparingFunction(L[i], R[j]))
                {
                    array[k] = L[i];
                    i++;
                }
                else
                {
                    array[k] = R[j];
                    j++;
                }
                k++;
            }

            while (i < sizeL)
            {
                array[k] = L[i];
                i++;
                k++;
            }

            while (j < sizeR)
            {
                array[k] = R[j];
                j++;
                k++;
            }
        }
    }
}
