using System;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    protected enum RangeType
    {
        None,
        Melee,
        Range
    }

    [SerializeField] private float boostAtackSpeed;
    private const float BaseAttackTime = 2f;
    private const float NormalAttackSpeed = 100f;
    private const float AttackSpeedCoefficient = 0.01f;

    [SerializeField] private int damage;
    protected RangeType AttackType = RangeType.None;

    public float AttackSpeed
    {
        get => boostAtackSpeed;
        protected set => boostAtackSpeed = Mathf.Clamp(value, -80, 600);
    }

    public int Damage
    {
        get => damage;
        private set => damage = Mathf.Clamp(value, 0, Int32.MaxValue);
    }

    public void IncreaseAttackSpeed(object sender, int amount)
    {
        AttackSpeed -= amount;
    }

    public void ReduceAttackSpeed(object sender, int amount)
    {
        AttackSpeed -= amount;
    }

    public void IncreaseDamage(object sender, int amount)
    {
        Damage += amount;
    }

    public void ReduceDamage(object sender, int amount)
    {
        Damage -= amount;
    }

    protected float GetTotalAttackSpeed()
    {
        var attackPerSecond = (NormalAttackSpeed + boostAtackSpeed) * AttackSpeedCoefficient / BaseAttackTime;
        var attackTime = 1 / attackPerSecond;
        return attackTime;
    }

    protected abstract void Init();
    protected abstract GameObject FindTarget();
    protected abstract bool CanAttack(GameObject target);
}