using UnityEngine;

public class CoinsHolder : MonoBehaviour
{
    private Coin[] _coins;

    private void Awake()
    {
        _coins = gameObject.GetComponentsInChildren<Coin>();
    }

    public void OnCoinCollected()
    {
        foreach (Coin onecoin in _coins)
        {
           if (onecoin.isActiveAndEnabled) 
                return;
        }

        Debug.Log("All Coins collected!");
    }
}
