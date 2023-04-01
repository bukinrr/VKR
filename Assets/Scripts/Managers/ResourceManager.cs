using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    private int _coin = 0;

    public int Coin
    {
        get => _coin;
        private set => _coin = value;
    }

    public delegate void CoinChangeDelegate(int value);

    public event CoinChangeDelegate OnCoinChange;


    void Start()
    {
    }

    void Update()
    {
    }

    public void AddCoins(int coinsValue)
    {
        Debug.Log($"coins = {_coin}");
        _coin = coinsValue;
        OnCoinChange?.Invoke(_coin);
    }
}