using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgressiveEnvironmentComponent : MonoBehaviour
{
    private IVulnerable _victim;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<IVulnerable>(out IVulnerable _victim))
        {
            _victim.Die();
        }
    }
}
