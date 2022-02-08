using System;
using UnityEngine;
using Random = System.Random;

public class AlgorythmsTest : MonoBehaviour
{
    int[] CreateArray(int length)
    {
        var random = new Random();
        var result = new int[length];
        for (int i = 0; i < length; i++)
        {
            result[i] = random.Next();
        }
        return result;
    }
    
    [ContextMenu("SortByMaxWithMerge")]
    void SortByMaxWithMerge()
    {
        var array = CreateArray(100);
        var startTime = Time.realtimeSinceStartup;
        MergeSort(array);
        var endTime = Time.realtimeSinceStartup;
        Debug.Log("Sort took time: " + (endTime - startTime));
    }

    [ContextMenu("FindMinNumberIndexNumber")]
    void FindMinNumberIndexNumber()
    {
        var array = CreateArray(1000);
        var startTime = Time.realtimeSinceStartup;
        var minIndex = IndexOfMin(array);
        var endTime = Time.realtimeSinceStartup;
        Debug.Log("Min index is: " + minIndex + " Search took time: " + (endTime - startTime));
    }
    
    private int IndexOfMin(int[] array) 
    {
        int indexMin = 0;
        var min = array[0];
        for (int i = 1; i < array.Length; ++i)
        {
            if (array[i].CompareTo(min) < 0)
            {
                min = array[i];
                indexMin = i;
            }
        }

        return indexMin;
    }
    private void Merge(int[] array, int lowIndex, int middleIndex, int highIndex)
    {
        var left = lowIndex;
        var right = middleIndex + 1;
        var tempArray = new int[highIndex - lowIndex + 1];
        var index = 0;

        while ((left <= middleIndex) && (right <= highIndex))
        {
            if (array[left] < array[right])
            {
                tempArray[index] = array[left];
                left++;
            }
            else
            {
                tempArray[index] = array[right];
                right++;
            }

            index++;
        }

        for (var i = left; i <= middleIndex; i++)
        {
            tempArray[index] = array[i];
            index++;
        }

        for (var i = right; i <= highIndex; i++)
        {
            tempArray[index] = array[i];
            index++;
        }

        for (var i = 0; i < tempArray.Length; i++)
        {
            array[lowIndex + i] = tempArray[i];
        }
    }
    
    private int[] MergeSort(int[] array, int lowIndex, int highIndex)
    {
        if (lowIndex < highIndex)
        {
            var middleIndex = (lowIndex + highIndex) / 2;
            MergeSort(array, lowIndex, middleIndex);
            MergeSort(array, middleIndex + 1, highIndex);
            Merge(array, lowIndex, middleIndex, highIndex);
        }

        return array;
    }
    
    private int[] MergeSort(int[] array)
    {
        return MergeSort(array, 0, array.Length - 1);
    }

}
