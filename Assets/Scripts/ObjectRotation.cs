using System;
using UnityEngine;
using UnityEngine.UI;

public class ObjectRotation : MonoBehaviour
{
    private const int TIME_MULTIPLYER = 20;
    [SerializeField] private Text rotationEnabledTextField;
    [SerializeField] private GameObject rotatedObject;
    private bool isEnabled;
    private RotationAxis rotationAxis;

    [Flags]
    public enum RotationAxis
    {
        X = 0,
        Y = 1,
        Z = 2
    }
    void Start()
    {
        setRotationTextFieldText();
    }
    void Update()
    {
        if (isEnabled)
        {
            RunRotation();
        }
    }

    public void ToggleRotationEnabled()
    {
        isEnabled = !isEnabled;
        setRotationTextFieldText();
    }

    private void setRotationTextFieldText()
    {
        string text;
        if (isEnabled)
        {
            text = "Cube rotation is: On";
        }
        else
        {
            text = "Cube rotation is: Off";
        }

        rotationEnabledTextField.text = text;
    }

    private void RunRotation()
    {
        switch (rotationAxis)
        {
            case RotationAxis.X:
            {
                rotatedObject.transform.Rotate(CalculateRotationSpeed(), 0, 0);
                break;
            }
            case RotationAxis.Y:
            {
                rotatedObject.transform.Rotate(0, CalculateRotationSpeed(), 0);
                break;
            }
            case RotationAxis.Z:
            {
                rotatedObject.transform.Rotate(0, 0, CalculateRotationSpeed());
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
