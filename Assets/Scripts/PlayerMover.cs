using UnityEngine;

[RequireComponent (typeof(CharacterController))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private InputReader _input;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _speed;

    private CharacterController _controller;
    private float _groundCheckDistance = 3f;
    private float _nearGroundVelocity = -1f;
    private Vector3 _velocity;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        _input.Moved += Move;
    }

    private void FixedUpdate()
    {
        ApplyGravity();
    }

    private void OnDisable()
    {
        _input.Moved -= Move;
    }

    private void Move(Vector2 direction)
    {
        Vector3 movement = transform.forward * direction.y + transform.right * direction.x;
        _controller.Move(movement * _speed * Time.deltaTime);
    }

    private void ApplyGravity()
    {
        if (Physics.CapsuleCast(
            transform.position + Vector3.up, 
            transform.position, 
            _controller.radius, 
            Vector3.down, 
            _groundCheckDistance, 
            _groundLayer))
        {
            _velocity.y = _nearGroundVelocity;
            Debug.Log("Ground");
        }
        else
        {
            _velocity.y += Physics.gravity.y * Time.fixedDeltaTime;
            Debug.Log("Not Ground");
        }

        _controller.Move(_velocity);
    }
}
