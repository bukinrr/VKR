using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int damage;
    [SerializeField] private float speed;
    [SerializeField] private float armor;
    protected Rigidbody _rigidbody;

    protected int Health
    {
        get => health;
        set => health = Mathf.Clamp(value, 0, 10);
    }

    protected int Damage
    {
        get => damage;
        set => damage = Mathf.Clamp(value, 0, 1000);
    }

    protected float Armor
    {
        get => armor;
        set => armor = Mathf.Clamp(value, 0, 1000);
    }

    protected float Speed
    {
        get => speed;
        set => speed = value;
    }

    void Start()
    {
    }

    // public void ChangeHealth(int health)
    // {
    //     Mathf.Clamp(health, 0, 10);
    // }
    //
    // public void ChangerArmor(float armor)
    // {
    //     Mathf.Clamp(armor, 0, 1000);
    // }
    //
    // public void ChangeDamage(int damage)
    // {
    //     Mathf.Clamp(damage, 0, 1000);
    // }

    public void GetDamage(int damage)
    {
        health = Mathf.Clamp(health - damage, 0, health);
        // Debug.Log($"Наношу урон существу: {gameObject.name}  в количестве {damage}, У существа осталось {health} хп");
    }
}