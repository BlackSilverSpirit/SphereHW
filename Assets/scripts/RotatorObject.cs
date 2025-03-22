using UnityEngine;

public class RotatorObject : MonoBehaviour
{
    [SerializeField] private bool _rotateX = false;
    [SerializeField] private bool _rotateY = true;
    [SerializeField] private bool _rotateZ = false;

    [SerializeField] private float _rotateSpeed = 50;

    private int _firstSide = 1;
    private int _secondSide = -1;
    private int _currentSide;

    private void Awake()
    {
        _currentSide = DetermineRotateSide();
    }

    private int DetermineRotateSide()
    {
        int chance = Random.Range(0, 2);

        return chance == 0 ? _firstSide : _secondSide;
    }

    private void Update()
    {
        Vector3 rotation = Vector3.zero;

        if (_rotateX) rotation.x = 1;
        if (_rotateY) rotation.y = 1;
        if (_rotateZ) rotation.z = 1;

        transform.Rotate(rotation * _currentSide * _rotateSpeed * Time.deltaTime);
    }
}
