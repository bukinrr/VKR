using System;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int maxHealth;
    [SerializeField] private float speed;
    [SerializeField] private float armor;
    protected Rigidbody Rigidbody;
    private float _currentHealthAsPercentage;

    public event Action<float> HealthChanged;

    public int Health
    {
        get => health;
        private set { health = Mathf.Clamp(value, 0, maxHealth); }
    }

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

    public void GetDamage(object sender, int damage)
    {
        Health -= damage;
        _currentHealthAsPercentage = GetCurrentHealthAsPercantage();
        HealthChanged?.Invoke(_currentHealthAsPercentage);
    }

    public float GetCurrentHealthAsPercantage()
    {
        _currentHealthAsPercentage = (float) health / maxHealth;
        return _currentHealthAsPercentage;
    }

    protected abstract void Init();

    public void IncreaseHealth(object sender, int amount)
    {
        Health += amount;
    }

    public void ReduceHealth(object sender, int amount)
    {
        Health -= amount;
    }

    public void IncreaseSpeed(object sender, int amount)
    {
        Speed += amount;
    }

    public void ReduceSpeed(object sender, int amount)
    {
        Speed -= amount;
    }

    public void IncreaseArmor(object sender, int amount)
    {
        Armor += amount;
    }

    public void ReduceArmor(object sender, int amount)
    {
        Armor -= amount;
    }
}