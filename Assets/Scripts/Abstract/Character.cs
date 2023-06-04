using System;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private float maxHealth;
    [SerializeField] private float speed;
    [SerializeField] private float armor;
    protected Rigidbody Rigidbody;
    private float _currentHealthAsPercentage;

    public event Action<float> HealthChanged;

    public float Health
    {
        get => health;
        protected set => health = Mathf.Clamp(value, 0, maxHealth);
    }

    public float MaxHealth => maxHealth;

    public float Armor
    {
        get => armor;
        protected set => armor = Mathf.Clamp(value, 0, 100);
    }

    public float Speed
    {
        get => speed;
        protected set => speed = Mathf.Clamp(value, 0, 1700);
    }

    public void GetDamage(object sender, float damage)
    {
        Health -= damage;
        _currentHealthAsPercentage = GetCurrentHealthAsPercentage();
        HealthChanged?.Invoke(_currentHealthAsPercentage);
    }

    public float GetCurrentHealthAsPercentage()
    {
        return health / maxHealth;
    }

    protected abstract void Init();

    public void IncreaseCurrentHealth(object sender, float amount)
    {
        Health += amount;
    }

    public void IncreaseMaxHealth(object sender, float amount)
    {
        maxHealth += Mathf.Clamp(amount, 0, 200);
    }

    public void ReduceHealth(object sender, float amount)
    {
        Health -= amount;
    }

    public void IncreaseSpeed(object sender, float amount)
    {
        Speed += amount;
    }

    public void ReduceSpeed(object sender, float amount)
    {
        Speed -= amount;
    }

    public void IncreaseArmor(object sender, float amount)
    {
        Armor += amount;
    }

    public void ReduceArmor(object sender, float amount)
    {
        Armor -= amount;
    }
}