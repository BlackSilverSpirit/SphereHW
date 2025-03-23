using UnityEngine;

public class Wallet : MonoBehaviour
{
    private int _coins;
    public int Coins => _coins;

    public void AddCoins(int amount)
    {
        _coins += amount;
    }

    public void ResetCoins()
    {
        _coins = 0;
    }
}
