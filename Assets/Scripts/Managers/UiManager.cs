using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField] public TMP_Text coinTMPText;

    [SerializeField] private Image timerBar;
    [SerializeField] public float matTime;
    private float timeLeft;
    private ResourceManager _resourceManager;

    private void Awake()
    {
        _resourceManager = GetComponent<ResourceManager>();
        coinTMPText.text = _resourceManager.Coin.ToString();
        timeLeft = matTime;

    }

    private void Update()
    {
        TimerRound();
    }
    
    public void ChangeCoin(int value)
    {
        coinTMPText.text = value.ToString();
    }

    private void TimerRound()
    {
        if (timeLeft > 0 )
        {
            timeLeft -= Time.deltaTime;
            timerBar.fillAmount = timeLeft / matTime;
        }
    }

    public void CallTimerRound()
    {
        TimerRound();
    }

    
    
}