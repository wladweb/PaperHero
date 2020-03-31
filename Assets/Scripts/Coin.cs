using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    [SerializeField] private UnityEvent _collected = new UnityEvent();
    [SerializeField] private AudioClip _collectSound;

    public event UnityAction Collected 
    {
        add => _collected.AddListener(value);
        remove => _collected.RemoveListener(value);
    }

    public void CollectHandler()
    {
        AudioSource.PlayClipAtPoint(_collectSound, transform.position);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _collected.Invoke();
        }
    }
}

