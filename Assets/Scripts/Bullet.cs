using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D _bulletRigidBody;
    [SerializeField] private float _velocityX = .7f;
    public float DirectoinX;

    void Start()
    {
        _bulletRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _bulletRigidBody.velocity = new Vector2(_velocityX * DirectoinX, 0);
        Destroy(gameObject, 4f);
    }
}
