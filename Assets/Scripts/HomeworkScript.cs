using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeworkScript : MonoBehaviour
{
    private const int TIME_MULTIPLYER = 20;
    [SerializeField] private bool isEnabled;
    [SerializeField] private RotationAxis rotationAxis;
    [SerializeField] public int _seed;
    private GameObject _cube;
    
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

    [Flags]
    public enum RotationAxis
    {
        X = 0,
        Y = 1,
        Z = 2
    }

    void Start()
    {
        _cube = GameObject.Find("Cube");
        RunHomeworkTask();
    }

    void Update()
    {
        if (isEnabled)
        {
            RunRotation();
        }
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

    private void RunRotation()
    {
        switch (rotationAxis)
        {
            case RotationAxis.X:
            {
                _cube.transform.Rotate(CalculateRotationSpeed(), 0, 0);
                break;
            }
            case RotationAxis.Y:
            {
                _cube.transform.Rotate(0, CalculateRotationSpeed(), 0);
                break;
            }
            case RotationAxis.Z:
            {
                _cube.transform.Rotate(0, 0, CalculateRotationSpeed());
                break;
            }
        }
    }

    private float CalculateRotationSpeed()
    {
        return TIME_MULTIPLYER * Time.deltaTime;
    } 
    
    [ContextMenu("TestFunc")]
    void TestFunc()
    {
        Debug.Log("isEnabled: " + isEnabled);
    }
}