using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField] private GameObject coinText;

    private TextMeshProUGUI _coinText;

    private void Awake()
    {
        _coinText = coinText.GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        
        
    }

    void Update()
    {
    }

    public void ChangeCoinValue(int value)
    {
        if (_coinText != null)
        {
            Debug.Log("Метод ChangeCoinValue выполнен");
            _coinText.text = $"{value}";
        }   
    }
}