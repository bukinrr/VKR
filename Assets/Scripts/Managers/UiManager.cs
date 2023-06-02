using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    //MONEY COIN TEXT
    [SerializeField] private TMP_Text coinTMPText;
    //WAVE TEXT
    [SerializeField] private TMP_Text waveTMPText;
    //PISTOL AMMO
    [SerializeField] private TMP_Text pistolAmmoText;
    [SerializeField] private RangeWeapon pistolWeapon;
    //RIFLE AMMO
    [SerializeField] private TMP_Text rifleAmmoText;
    [SerializeField] private RangeWeapon rifleWeapon;
    //AUTO AMMO
    [SerializeField] private TMP_Text autoAmmoText;
    [SerializeField] private RangeWeapon autoWeapon;


    // TIMERBAR
    [SerializeField] private Image timerBar;
    [SerializeField] public float matTime;
    private float _timeLeft;
    private bool _isTimerRunning;

    private ResourceManager _resourceManager;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _resourceManager = GetComponent<ResourceManager>();
        _resourceManager.OnCoinChanged += OnCoinChanged;
        _resourceManager.OnWaveChanged += OnWaveChanged;

        pistolWeapon.OnAmmoChanged += OnPistolAmmoChanged;
        rifleWeapon.OnAmmoChanged += OnRifleAmmoChanged;
        autoWeapon.OnAmmoChanged += OnAutoAmmoChanged;
        
        coinTMPText.text = _resourceManager.Coin.ToString();
        _timeLeft = matTime;
    }

    private void OnCoinChanged(object sender, System.EventArgs e)
    {
        ChangeCoin(_resourceManager.Coin);
    }
    private void OnWaveChanged(object sender, System.EventArgs e)
    {
        ChangeWave(_resourceManager.Wave);
    }
    private void OnPistolAmmoChanged(object sender, System.EventArgs e)
    {
        ChangePistolAmmo(pistolWeapon.CurrentAmmoString);
    }
    private void OnRifleAmmoChanged(object sender, System.EventArgs e)
    {
        ChangeRifleAmmo(rifleWeapon.CurrentAmmoString);
    }
    private void OnAutoAmmoChanged(object sender, System.EventArgs e)
    {
        ChangeAutomatAmmo(autoWeapon.CurrentAmmoString);
    }
    private void ChangeCoin(int value)
    {
        coinTMPText.text = value.ToString();
    }

    private void ChangeWave(int value)
    {
        waveTMPText.text = value.ToString();
    }
    private void ChangePistolAmmo(string pistolAmmoValue)
    {
        pistolAmmoText.text = pistolAmmoValue;
    }
    private void ChangeRifleAmmo(string rifleAmmoValue)
    {
        rifleAmmoText.text = rifleAmmoValue;
    }
    private void ChangeAutomatAmmo(string autoAmmoValue)
    {
        autoAmmoText.text = autoAmmoValue;
    }
    
    private void Update()
    {
        TimerRound();
    }

    private void TimerRound()
    {
        if (_timeLeft > 0)
        {
            _timeLeft -= Time.deltaTime;
            timerBar.fillAmount = _timeLeft / matTime;
        }
        else
        {
            StopTimer();
        }
    }

    public void StartTimer()
    {
        _isTimerRunning = true;
    }

    public void StopTimer()
    {
        _isTimerRunning = false;
    }

    public void ResetTimer()
    {
        _timeLeft = matTime;
        timerBar.fillAmount = 1f;
        _isTimerRunning = false;
    }

    public void CallTimerRound()
    {
        TimerRound();
    }
}