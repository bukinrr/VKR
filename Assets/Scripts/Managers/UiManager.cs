using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] private GameObject coinText;

    private TextMeshProUGUI _coinText;

    private void Awake()
    {
        _coinText = coinText.GetComponent<TextMeshProUGUI>();
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