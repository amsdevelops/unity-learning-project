
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SetTextFromInputField : MonoBehaviour
{
    [SerializeField] private Text textField;
    [SerializeField] private Text inputField;
    
    public void SetTextFromInput()
    {
        string text = inputField.text;
        textField.text = text;
    }
}
