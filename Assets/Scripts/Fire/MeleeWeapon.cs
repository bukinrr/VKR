using System;
using System.Collections;
using UnityEngine;

public class MeleeWeapon : Weapon
{
    [SerializeField] private float attackRange;
    private bool _canAttack = true;
    private WaitForSeconds _attackTime;

    private Animator _animator;

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
        _attackTime = new WaitForSeconds(GetTotalAttackSpeed());
        _animator = GetComponent<Animator>();
    }

    protected override GameObject FindTarget()
    {
        throw new NotImplementedException();
    }

    public void EnemyAttack(GameObject target)
    {
        if (CanAttack(target))
        {
            StartCoroutine(IECanAttack(target));
        }
    }

    protected override bool CanAttack(GameObject target)
    {
        float distance = Vector3.Distance(transform.position, target.transform.position);
        if (_canAttack && distance <= attackRange)
            return true;

        return false;
    }

    private IEnumerator IECanAttack(GameObject target)
    {
        Attack(target);
        _canAttack = false;
        Debug.Log("Атака");
        yield return _attackTime;
        _canAttack = true;
        _animator.SetBool("AttackBool", false);
    }

    private void Attack(GameObject target)
    {
        var playerController = target.GetComponent<PlayerController>();
        playerController.GetDamage(this, Damage);
        _animator.SetBool("AttackBool", true);
    }
}