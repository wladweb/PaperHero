using UnityEngine;

public class AlCoinsCollectedTrigger : MonoBehaviour
{
    private Coin[] _coins;

    private void OnEnable()
    {
        _coins = gameObject.GetComponentsInChildren<Coin>();

        foreach (Coin coin in _coins)
        {
            coin.Collected += OnCoinCollected;
        }
    }

    private void OnDisable()
    {
        foreach (Coin coin in _coins)
        {
            coin.Collected -= OnCoinCollected;
        }
    }

    private void OnCoinCollected()
    {
        foreach (Coin coin in _coins)
        {
           if (coin.isActiveAndEnabled) return;
        }

        Debug.Log("All Coins collected!");
    }
}
