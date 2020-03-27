using UnityEngine;

public class DamageTaker : MonoBehaviour
{
    [SerializeField] private float _health = 100;
    private DamageGiver _damageGiver;
    private IVulnerable _victim;

    private void Awake()
    {
        _victim = GetComponent<IVulnerable>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<DamageGiver>(out _damageGiver))
        {
            HandleDamage();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<DamageGiver>(out _damageGiver))
        { 
            HandleDamage();
        }
    }

    private void HandleDamage()
    {
        Debug.Log(_damageGiver);
        _health -= _damageGiver.GetDamage();
        _victim.TakeDamage();

        if (_health <= 0)
            _victim.Die();
    }
}
