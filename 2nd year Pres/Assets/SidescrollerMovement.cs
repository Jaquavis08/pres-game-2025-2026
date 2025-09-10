using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class SidescrollerMovement : MonoBehaviour
{
    private Rigidbody _rb2d;

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpHeight;

    private Vector3 _movement;

    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _rb2d.maxLinearVelocity = _movement.x;
    }

    public void Move(InputAction.CallbackContext ctx)
    {
        _movement = new(ctx.ReadValue<Vector3>().x * _speed, 0);
    }

    public void Jump(InputAction.CallbackContext ctx)
    {
        if (ctx.ReadValue<float>() != 1)
            return;
     
        _rb2d.maxLinearVelocity = _jumpHeight;
    }
}
