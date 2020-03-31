using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _velocityX = .7f;
    [SerializeField] private float _directionX;

    private Rigidbody2D _bulletRigidBody;

    public float DirectionX 
    {
        get
        {
            return _directionX;
        }
        set
        {
            _directionX = value;
        }
    }

    private void Start()
    {
        _bulletRigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _bulletRigidBody.velocity = new Vector2(_velocityX * _directionX, 0);
        Destroy(gameObject, 4f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.TryGetComponent<Bullet>(out Bullet bullet))
        {
            Destroy(gameObject);
        }
    }
}
