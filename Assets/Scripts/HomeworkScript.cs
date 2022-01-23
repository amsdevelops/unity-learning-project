using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeworkScript : MonoBehaviour
{
    [SerializeField] public int _seed;
    
    public struct HomeworkValues
    {
        public HomeworkValues(bool createArray, int arrayLength, int seed)
        {
            CreateArray = createArray;
            ArrayLength = arrayLength;
            Seed = seed;
        }

        public bool CreateArray;
        public int ArrayLength;
        public int Seed;
    }

    void Start()
    {
        RunHomeworkTask();
    }

    private void RunHomeworkTask()
    {
        var values = new HomeworkValues(true, 10, _seed);
        if (values.CreateArray) fillArrayWithSquares(values.Seed, out values.ArrayLength);
    }

    private void fillArrayWithSquares(int seed, out int lenght)
    {
        lenght = 10;
        int[] array = new int[lenght];

        for (int i = 0; i < array.Length; i++)
        {
            try
            {
                array[i] = square(ref seed);
                Debug.Log(array[i]);
            }
            catch (OverflowException e)
            {
                Debug.LogError(e);
            }
        }
    }

    private int square(ref int value)
    {
        return value *= value;
    }
}