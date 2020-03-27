using UnityEngine;

public class Jumper : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private bool _isLanded;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    public void Jump(bool isJump)
    {
        if (isJump && _isLanded)
        {
            _rigidBody.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlatformComponent>(out PlatformComponent platformComponent))
        {
            _isLanded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlatformComponent>(out PlatformComponent platformComponent))
        {
            _isLanded = false;
        }
    }
}
