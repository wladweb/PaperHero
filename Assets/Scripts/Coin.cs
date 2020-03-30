using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    [SerializeField] private UnityEvent _collected = new UnityEvent();

    public event UnityAction Collected 
    {
        add => _collected.AddListener(value);
        remove => _collected.RemoveListener(value);
    }

    public void CollectHandler()
    {
        Debug.Log("Collected");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _collected.Invoke();
        Destroy(gameObject);
    }
}

