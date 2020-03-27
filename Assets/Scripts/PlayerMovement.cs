using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator _animator;
    private Jumper _jumper;
    private Mover _mover;
    private float _currentDirection = 1;
    private float _animationDirection;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _jumper = GetComponent<Jumper>();
        _mover = GetComponent<Mover>();
    }

    void Update()
    {
        float direction = Input.GetAxisRaw("Horizontal");

        _mover.Move(direction, out float movementMagnitude);

        if (direction == 0)
        {
            direction = _currentDirection;
        }
        else 
        {
            _currentDirection = direction;
        }

        _animator.SetFloat("Direction", direction);
        _animator.SetFloat("Speed", movementMagnitude);

        if (Input.GetButtonDown("Jump"))
        {
            _jumper.Jump(true);
            _animator.ResetTrigger("Land");
            _animator.SetTrigger("Jump");
        }
        else if (Input.GetButtonUp("Jump"))
        {
            _animator.ResetTrigger("Jump");
            _animator.SetTrigger("Land");
        }
    }
}
