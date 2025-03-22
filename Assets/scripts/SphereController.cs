using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class SphereController : MonoBehaviour
{

    private Rigidbody _rigidbody;

    [SerializeField] private float _moveSpeed = 10f;
    [SerializeField] private float _jumpForce = 5f;

    private KeyCode JumpKey = KeyCode.Space;

    private const string _horizontalAxisName = "Horizontal";
    private const string _verticalAxisName = "Vertical";

    private bool _isGrounded;

    void Awake()
    {
        GetRigidbodyOnAwake();
    }

    void Update()
    {
        if (CheckPermissionJump())
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        ProcessMovement();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
            //Debug.Log("Ground contact");
        }
    }

    void Jump()
    {
        _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        _isGrounded = false;
    }

    private bool CheckPermissionJump()
    {
        return Input.GetKeyDown(JumpKey) && _isGrounded;
    }

    private void ProcessMovement()
    {
        float moveHorizontal = Input.GetAxis(_horizontalAxisName);
        float moveVertical = Input.GetAxis(_verticalAxisName);

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        _rigidbody.AddForce(movement * _moveSpeed);
    }

    private void GetRigidbodyOnAwake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        if (_rigidbody == null)
        {
            Debug.LogError("Rigidbody нету.");
        }
    }

    public void OffObject()
    {
        gameObject.SetActive(false);
    }

    public void ActiveObject(Vector3 newPosition)
    {
        transform.position = newPosition;

        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;

        transform.rotation = Quaternion.identity;

        gameObject.SetActive(true);
    }
}
