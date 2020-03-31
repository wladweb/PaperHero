using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    private Vector3 _offset;

    public GameObject Player;

    private void Start()
    {
        if (Player != null)
            _offset = transform.position - Player.transform.position;
    }

    private void Update()
    {
        if (Player != null)
            transform.position = Player.transform.position + _offset;
    }
}
