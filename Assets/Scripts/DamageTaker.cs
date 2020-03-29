using UnityEngine;
using UnityEngine.Events;

public class DamageTaker : MonoBehaviour
{
    [SerializeField] private float _health = 100;
    private DamageGiver _damageGiver;
    private IVulnerable _victim;

    public UnityEvent TookDamage;
    public UnityEvent Death;

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
        /*
        if (collision.TryGetComponent<Bullet>(out Bullet bullet))
        {
            Destroy(bullet.gameObject);
        }
        */
    }

    private void HandleDamage()
    {
        _health -= _damageGiver.GetDamage();
        TookDamage.Invoke();

        if (_health <= 0)
            Death.Invoke();
    }

    public void Die()
    {
        Death.Invoke();
    }
}
