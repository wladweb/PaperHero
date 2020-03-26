using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    public GameObject Player;
    private Vector3 _offset;

    void Start()
    {
        _offset = transform.position - Player.transform.position;
    }

    void LateUpdate()
    {
        transform.position = Player.transform.position + _offset;
    }
}
