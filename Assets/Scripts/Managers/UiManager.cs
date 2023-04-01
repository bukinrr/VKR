using System;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] private GameObject managers;

    private TextMeshPro _coinText;

    private void Awake()
    {
    }

    void Start()
    {
        var resourceManager = managers.GetComponent<ResourceManager>();
        resourceManager.OnCoinChange += ChangeCoinValue;
        _coinText = GetComponent<TextMeshPro>();
    }

    void Update()
    {
    }

    public void ChangeCoinValue(int value)
    {
        Debug.Log("Метод ChangeCoinValue выполнен");
        _coinText.text = $"{value}";
        _coinText.text = "value";
    }
}