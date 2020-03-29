using UnityEngine;

public class AgressiveEnvironmentComponent : MonoBehaviour
{
    private DamageTaker _victim;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<DamageTaker>(out _victim))
        {
            _victim.Die();
        }
    }
}
