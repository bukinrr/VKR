using System;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    [SerializeField] private UiManager uiManager;
    [SerializeField] private LevelWindow _levelWindow;
    [SerializeField] private SwitchWeapon _switchWeapon;
    LevelSystem _levelSystem;

    public event EventHandler OnCoinChanged;
    public event EventHandler OnWaveChanged;

    private int _coin;
    private int _wave;

    public int Coin
    {
        get => _coin;
        internal set => _coin = value;
    }

    public int Wave
    {
        get => _wave;
        internal set => _wave = value;
    }

    private void Awake()
    {
        _levelSystem = new LevelSystem();
        _levelWindow.SetLevelSystem(_levelSystem);
        _switchWeapon.SetLevelSystem(_levelSystem);
    }

    public void AddCoins(int coinsValue)
    {
        Coin += coinsValue;
        UpdateCoins();
    }

    public bool ReduceCoins(int coinsValue)
    {
        if (_coin - coinsValue >= 0)
        {
            _coin -= coinsValue;
            UpdateCoins();
            return true;
        }

        return false;
    }

    public void AddExperinceR(int expValue)
    {
        _levelSystem.AddExperience(expValue);
    }

    public void AddWave(int wave)
    {
        _wave += wave;
        UpdateWave();
    }

    private void UpdateCoins()
    {
        if (OnCoinChanged != null)
        {
            OnCoinChanged(this, EventArgs.Empty);
        }
    }

    private void UpdateWave()
    {
        if (OnWaveChanged != null)
        {
            OnWaveChanged(this, EventArgs.Empty);
        }
    }
}