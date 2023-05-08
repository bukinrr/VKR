using System;
using UnityEngine;

public class MeleeWeapon : Weapon
{
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private float lastAttackTime;
    private float _attackTime;

    private void Awake()
    {
        AttackType = RangeType.Melee;
    }

    private void Start()
    {
        Init();
    }

    protected override void Init()
    {
        _attackTime = GetTotalAttackSpeed();
    }

    protected override GameObject FindTarget()
    {
        throw new NotImplementedException();
    }

    public void EnemyAttack(GameObject target)
    {
        if (CanAttack(target))
        {
            Attack(target);
        }
    }

    protected override bool CanAttack(GameObject target)
    {
        float distance = Vector3.Distance(transform.position, target.transform.position);
        if (distance <= attackRange && Time.time - lastAttackTime >= _attackTime)
        {
            lastAttackTime = Time.time;
            return true;
        }
        else
        {
            return false;
        }
    }

    private void Attack(GameObject target)
    {
        var _playerController = target.GetComponent<PlayerController>();
        _playerController.GetDamage(this, Damage);
        Debug.Log($"Enemy наносит урон существу{target.gameObject.name}, у него осталось {_playerController.Health}");
    }
}