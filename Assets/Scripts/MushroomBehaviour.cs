using UnityEngine;

public class MushroomBehaviour : MonoBehaviour
{
    private bool _isGrown;
    private FlipHandler _flipHandler;
    private Animator _animator;
    private Player _player;
    private Shooter _shooter;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _shooter = GetComponent<Shooter>();
        _flipHandler = GetComponent<FlipHandler>();
    }

    private void Update()
    {
        if (_isGrown)
        {
            float direction = _flipHandler.GetDirection();
            _shooter.Shoot(direction);
        }
    }

    public void TakeDamageHandler()
    {
        _animator.SetTrigger("Damage");
    }

    public void DeathHandler()
    {
        _animator.SetTrigger("Die");
        Destroy(gameObject, 1.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            if (_isGrown == false)
            {
                _animator.SetTrigger("Grow");
                _isGrown = true;
                
                Transform activator = transform.GetChild(0);
                activator.gameObject.SetActive(false);
            }
        }
    }
}
