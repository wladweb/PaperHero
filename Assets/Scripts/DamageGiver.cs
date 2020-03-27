using UnityEngine;

public class DamageGiver : MonoBehaviour
{
    [SerializeField] private float _damage = 10;

    public float GetDamage()
    {
        return _damage;
    }
}
