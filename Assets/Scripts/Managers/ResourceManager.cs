using System;
using Unity.VisualScripting;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    private int _coin = 0;
    [SerializeField] private UiManager uiManager;

    public int Coin
    {
        get => _coin;
        private set => _coin = value;
    }

    public delegate void CoinChangeDelegate(int value);

    public event CoinChangeDelegate OnCoinChange;

    private void Awake()
    {
        if (uiManager != null)
        {
            OnCoinChange += uiManager.ChangeCoinValue;
        }
        else
        {
            Debug.LogError("ResourceManager: uiManager is null!");
        }
    }

    public void AddCoins(int coinsValue)
    {
        _coin += coinsValue;
        Debug.Log($"coins = {_coin}");
        if (OnCoinChange == null)
        {
            //Debug.Log("Пожрал говна");
        }

        OnCoinChange?.Invoke(_coin);
    }
}