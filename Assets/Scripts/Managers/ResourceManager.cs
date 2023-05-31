using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    private int _coin;
    [SerializeField] private UiManager uiManager;

    public int Coin
    {
        get => _coin;
        internal set => _coin = value;
    }

    public void AddCoins(int coinsValue)
    {
        Coin += coinsValue;
        uiManager.ChangeCoin(Coin);
    }
}