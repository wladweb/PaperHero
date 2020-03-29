using UnityEngine;

public class MushroomBehaviour : MonoBehaviour
{
    private bool _isGrown;
    private bool _isFacingRight;
    private Animator _animator;
    private Player _player;
    private Shooter _shooter;

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
        _animator = GetComponent<Animator>();
        _shooter = GetComponent<Shooter>();
    }

    private void Update()
    {
        if (_isGrown && _player != null)
        {
            bool currentDirection = transform.position.x <= _player.transform.position.x;

            float shootDirection = currentDirection ? 1 : -1;

            _shooter.Shoot(shootDirection);

            if (_isFacingRight != currentDirection)
            {
                Flip();
            }
        }
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
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
