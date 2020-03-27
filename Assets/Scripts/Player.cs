using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour, IVulnerable
{
    private Animator _animator;
    private Jumper _jumper;
    private Mover _mover;
    private float _currentDirection = 1;
    [SerializeField] private float _health;

    [SerializeField] private UnityEvent TookDamage = new UnityEvent();
    [SerializeField] private UnityEvent Death = new UnityEvent();

    public void TakeDamage(float damage)
    {
        _health -= damage;
        TookDamage.Invoke();

        if (_health <= 0) Death.Invoke();
    }

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

    public void InstantKill()
    {
        Death.Invoke();
    }

    public void TakeDamageHandler()
    {
        _animator.SetTrigger("Damage");
    }

    public void DeathHandler()
    {
        _animator.SetTrigger("Death");
        Destroy(gameObject, 3f);
    }
}
