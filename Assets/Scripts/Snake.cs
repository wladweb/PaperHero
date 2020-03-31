using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Snake : MonoBehaviour
{
    [SerializeField] private float _leftWalkLength = 2;
    [SerializeField] private float _rightWalkLength = 2;

    private Animator _animator;
    private FlipHandler _flipHandler;
    private Mover _mover;
    private Vector3 _startPosition;
    private float _speed;

    private enum SnakeStatus { Idle, Atack }
    private enum IdleDirection { Left = -1, Right = 1 }

    private IdleDirection _currentIdelDirection = IdleDirection.Left;
    private SnakeStatus _currentStatus = SnakeStatus.Idle;

    private void Awake()
    {
        _startPosition = transform.position;
        _flipHandler = GetComponent<FlipHandler>();
        _animator = GetComponent<Animator>();
        _mover = GetComponent<Mover>();
    }

    private void Update()
    {
        if (_currentStatus == SnakeStatus.Idle)
        {
            Idle(out _speed);
        }
        else if (_currentStatus == SnakeStatus.Atack)
        {
            Atack(out _speed);
        }

        _animator.SetFloat("Speed", _speed);
    }

    private void Atack(out float movementMagnitude)
    {
        float direction = _flipHandler.GetDirection();
        _mover.Move(direction, out movementMagnitude);
    }

    private void Idle(out float movementMagnitude)
    {
        if (transform.position.x < _startPosition.x - _leftWalkLength)
        {
            _currentIdelDirection = IdleDirection.Right;
            _flipHandler.ChangeDirection(true);
        }
        else if (transform.position.x > _startPosition.x + _rightWalkLength)
        {
            _currentIdelDirection = IdleDirection.Left;
            _flipHandler.ChangeDirection(false);
        }
        
        _mover.Move((float) _currentIdelDirection, out movementMagnitude);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<Mushroom>(out Mushroom behavior))
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), behavior.GetComponent<Collider2D>());
        }
        else if (collision.collider.TryGetComponent<Player>(out Player player))
        {
            _animator.SetTrigger("Atack");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _currentStatus = SnakeStatus.Atack;
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
}
