using UnityEngine;

public class DraggableRotation : MonoBehaviour
{
    private const float SENSITIVITY = 0.3F;
    private Vector3 _mouseReference;
    private Vector3 _mouseOffset;
    private Vector3 _rotation;
    private bool _isRotating;
     
    void Start ()
    {
        _rotation = Vector3.zero;
    }
     
    void Update()
    {
        if(_isRotating)
        {
            _mouseOffset = (Input.mousePosition - _mouseReference);
            _rotation.y = -_mouseOffset.x * SENSITIVITY;
            _rotation.x = -_mouseOffset.y * SENSITIVITY;
            transform.Rotate(_rotation);
            _mouseReference = Input.mousePosition;
        }
    }
     
    void OnMouseDown()
    {
        _isRotating = true;
        _mouseReference = Input.mousePosition;
    }
     
    void OnMouseUp()
    {
        _isRotating = false;
    }
}