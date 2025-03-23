using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Coin>(out var coin))
        {
            CollectCoin(coin);
        }
    }

    private void CollectCoin(Coin coin)
    {
        _wallet.AddCoins(coin.Value);
        coin.Collect();
    }
}
