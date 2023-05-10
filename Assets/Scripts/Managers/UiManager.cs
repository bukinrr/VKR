using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    //[SerializeField] private GameObject coinText;

    [SerializeField] private TMP_Text _coinText;
    private int coin;

    [SerializeField] private Image timerBar;
    [SerializeField] public float matTime;
    private float timeLeft;

    private void Start()
    {
        timeLeft = matTime;
    }

    private void Awake()
    {
        //_coinText = coinText.GetComponent<TMP_Text>();
    }

    private void Update()
    {
        TimerRound();
        _coinText.text = $"{coin}";
        //ChangeCoin(coin);
    }

    private void TimerRound()
    {
        if (timeLeft > 0 )
        {
            timeLeft -= Time.deltaTime;
            timerBar.fillAmount = timeLeft / matTime;
        }
        else
        {
            
        }
    }

    public void ChangeCoin(int value)
    {
        coin = value;
        Debug.Log(coin);
        //_coinText.text = $"{coin}";
    }

    public void ChangeCoinValue(int value)
    {
        Debug.Log("Метод ChangeCoinValue выполнен");
        _coinText.text = value.ToString();
        // if (_coinText != null)
        // {
        //     
        // }   
    }
}