using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;

    public void Move(float direction, out float movementMagnitude)
    {
        Vector3 _movement = new Vector3(direction * _speed, 0, 0);
        movementMagnitude = _movement.sqrMagnitude;
        transform.position += _movement * Time.deltaTime;
    }
}
