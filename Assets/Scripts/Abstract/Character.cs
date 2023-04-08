using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int damage;
    [SerializeField] private float speed;
    [SerializeField] private float armor;

    [SerializeField] private float boostAtackSpeed;
    private const float BaseAttackTime = 2f;
    private const float NormalAttackSpeed = 100f;
    private const float AttackSpeedCoefficient = 0.01f;

    protected Rigidbody _rigidbody;

    public int Health
    {
        get => health;
        protected set => Mathf.Clamp(value, 0, 10);
    }

    public int Damage
    {
        get => damage;
        protected set => damage = Mathf.Clamp(value, 0, 1000);
    }

    public float AttackSpeed
    {
        get => boostAtackSpeed;
        protected set => boostAtackSpeed = Mathf.Clamp(value, -80, 600);
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

    public void GetDamage(int damage)
    {
        Health -= Mathf.Clamp(damage, 0, 1000);
        // Debug.Log($"Наношу урон существу: {gameObject.name}  в количестве {damage}, У существа осталось {health} хп");
    }

    public void IncreaseDamage(object sender, int amount)
    {
        Damage += amount;
    }

    public void ReduceDamage(object sender, int amount)
    {
        Damage -= amount;
    }

    public void IncreaseAttackSpeed(object sender, int amount)
    {
        AttackSpeed -= amount;
    }

    public void ReduceAttackSpeed(object sender, int amount)
    {
        AttackSpeed -= amount;
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

    protected float GetTotalAttackSpeed()
    {
        var attackPerSecond = (NormalAttackSpeed + boostAtackSpeed) * AttackSpeedCoefficient / BaseAttackTime;
        var attackTime = 1 / attackPerSecond;
        return attackTime;
    }
}