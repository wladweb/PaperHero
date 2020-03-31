using UnityEngine;

public class AgressiveEnvironment : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<DamageTaker>(out DamageTaker _victim))
        {
            _victim.Die();
        }
    }
}
