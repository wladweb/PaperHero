using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    public GameObject Player;
    private Vector3 _offset;

    void Start()
    {
        if (Player != null)
            _offset = transform.position - Player.transform.position;
    }

    void Update()
    {
        if (Player != null)
            transform.position = Player.transform.position + _offset;
    }
}
