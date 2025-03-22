using UnityEngine;

public class TargetFollower : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset;

    [SerializeField] private float _rotationSpeed = 5f;
    [SerializeField] private float _minVerticalAngle = -80f;
    [SerializeField] private float _maxVerticalAngle = 80f;

    private float _rotationX = 0f;

    private const string _mouseXAxisName = "Mouse X";
    private const string _mouseYAxisName = "Mouse Y";

    private void LateUpdate()
    {
        transform.position = _target.transform.position + _offset;

        CameraMove();
    }

    private void CameraMove()
    {
        if (Input.GetMouseButton(1))
        {
            float mouseX = Input.GetAxis(_mouseXAxisName) * _rotationSpeed;
            float mouseY = Input.GetAxis(_mouseYAxisName) * _rotationSpeed;

            transform.Rotate(Vector3.up, mouseX, Space.World);

            _rotationX -= mouseY;
            _rotationX = Mathf.Clamp(_rotationX, _minVerticalAngle, _maxVerticalAngle);

            transform.localEulerAngles = new Vector3(_rotationX, transform.localEulerAngles.y, 0);
        }
    }
}
