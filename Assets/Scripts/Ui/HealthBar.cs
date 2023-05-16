using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image healthBarFilling;

    [SerializeField] private Character character;

    private Camera _camera;

    private void Awake()
    {
        OnHealthChanged(character.GetCurrentHealthAsPercentage());  
        character.HealthChanged += OnHealthChanged;
        _camera = Camera.main;
    }

    private void OnDestroy()
    {
        Debug.Log("OnDestroy сработал");
        character.HealthChanged -= OnHealthChanged;
    }

    public void OnHealthChanged(float valueAsPercantage)
    {
        Debug.Log($"Percantage = {valueAsPercantage}");
        healthBarFilling.fillAmount = valueAsPercantage;
    }

    private void LateUpdate()
    {
        var cmTrPosition = _camera.transform.position;
        var direction = new Vector3(transform.position.x, cmTrPosition.y, cmTrPosition.z);
        transform.LookAt(direction);
        transform.Rotate(0, 180, 0);
    }
}