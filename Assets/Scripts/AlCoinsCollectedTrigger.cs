using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlCoinsCollectedTrigger : MonoBehaviour
{
    private Coin[] _coins;

    private void OnEnable()
    {
        _coins = gameObject.GetComponentsInChildren<Coin>();

        foreach (Coin coin in _coins)
        {
            coin.Collected += OnAllCoinsCollected;
        }
    }

    private void OnDisable()
    {
        foreach (Coin coin in _coins)
        {
            coin.Collected -= OnAllCoinsCollected;
        }
    }

    private void OnAllCoinsCollected()
    {
        Debug.Log("All coins collected!");
    }
}
