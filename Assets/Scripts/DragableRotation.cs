using UnityEngine;

public class DragableRotation : MonoBehaviour
{
    private const float MOUSE_SPEED_MODIFIER = 0.3F;
    private Vector3 _rotation;
    private Vector3 _mouseReference;
    private Vector3 _mouseOffset;
    private bool _isRotating;

    void Start()
    {
        _rotation = Vector3.zero;
    }

    void Update()
    {
        if (_isRotating)
        {
            _mouseOffset = (Input.mousePosition - _mouseReference);
            _rotation.x = -_mouseOffset.y * MOUSE_SPEED_MODIFIER;
            _rotation.y = _mouseOffset.x * MOUSE_SPEED_MODIFIER;
            transform.Rotate(_rotation);
            _mouseReference = Input.mousePosition;
        }
    }

    void OnMouseDown()
    {
        _isRotating = true;
        _mouseReference = Input.mousePosition;
    }

    private void OnMouseUp()
    {
        _isRotating = false;
    }
}
