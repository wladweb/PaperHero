using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour, IVulnerable
{
    private Animator _animator;
    private Jumper _jumper;
    private Mover _mover;
    private Shooter _shooter;
    private float _currentDirection = 1;
    private float _animDirection;

    public UnityEvent TookDamage = new UnityEvent();
    public UnityEvent Death = new UnityEvent();

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _jumper = GetComponent<Jumper>();
        _mover = GetComponent<Mover>();
        _shooter = GetComponent<Shooter>();
    }

    void Update()
    {
        Move();
        Jump();
        Shoot();
    }

    private void Shoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            _shooter.Shoot(_animDirection);
        }
    }

    private void Move()
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
        
        _animDirection = direction;

        _animator.SetFloat("Direction", direction);
        _animator.SetFloat("Speed", movementMagnitude);
    }

    private void Jump()
    {
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

    public void TakeDamageHandler()
    {
        _animator.SetTrigger("Damage");
    }

    public void DeathHandler()
    {
        _animator.SetTrigger("Death");
        Destroy(gameObject, 1f);
    }

    public void TakeDamage()
    {
        TookDamage.Invoke();
    }

    public void Die()
    {
        Death.Invoke();
    }
}
