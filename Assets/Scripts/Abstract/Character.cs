using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

public abstract class Character : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private float speed;
    [SerializeField] private float armor;
    protected Rigidbody _rigidbody;

    public int Health
    {
        get => health;
        private set => health = Mathf.Clamp(value, 0, 10);
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
        Health -= Mathf.Clamp(damage, 0, 1000);
        Debug.Log(Health -= Mathf.Clamp(damage, 0, 1000));
        Debug.Log($"Сущетсво {sender} нанесло урон существу {gameObject} в количестве {damage}");
    }

    protected abstract void Init();

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