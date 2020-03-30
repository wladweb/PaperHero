using UnityEngine;

public class FlipHandler : MonoBehaviour
{
    private bool _isFacingRight;
    private Player _player;

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
    }

    public float GetDirection()
    {
        if (_player == null) return 0;

        bool currentDirection = transform.position.x <= _player.transform.position.x;

        if (_isFacingRight != currentDirection)
        {
            Flip();
        }

        return currentDirection ? 1 : -1;
    }

    public void ChangeDirection(bool currentDirection)
    {
        if (currentDirection != _isFacingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
