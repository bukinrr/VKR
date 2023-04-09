using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeWeapon : Weapon
{
    protected enum FireMode
    {
        None,
        SingleFireMode,
        BurstFireMode,
        FullAutoFireMode
    }

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float attackRange;
    [SerializeField] private int countBullet;
    [SerializeField] protected FireMode RangeFireMode;
    [SerializeField] private Transform bulletSpawnPoint;

    private int _currentAmmo;
    public float reloadTime = 2f;

    private float _attackTime;
    private float _lastAttackTime;


    private int CountBullet
    {
        get => countBullet;
        set => countBullet = Mathf.Clamp(value, 0, 500);
    }

    private void Start()
    {
        AttackType = RangeType.Range;
        _attackTime = GetTotalAttackSpeed();
    }

    public void LaunchShoot()
    {
        var target = FindTarget();
        Shoot(target);
    }

    protected override GameObject FindTarget()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, attackRange);

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Enemy"))
                return hitCollider.gameObject;
        }

        return null;

        //       ПОИСК БЛИЖАЙШЕГО
        // Collider[] hitColliders = new Collider[10];
        // int numColliders = Physics.OverlapSphereNonAlloc(transform.position, attackRange, hitColliders);
        //
        // float closestDistance = Mathf.Infinity;
        // GameObject closestEnemy = null;
        //
        // for (int i = 0; i < numColliders; i++)
        // {
        //     if (hitColliders[i].CompareTag("Enemy"))
        //     {
        //         float distance = Vector3.Distance(transform.position, hitColliders[i].transform.position);
        //         if (distance < closestDistance)
        //         {
        //             closestDistance = distance;
        //             closestEnemy = hitColliders[i].gameObject;
        //         }
        //     }
        // }
        // Debug.Log(closestEnemy);
        // return closestEnemy;
    }

    protected override bool CanAttack(GameObject target)
    {
        return bulletPrefab && bulletSpawnPoint && target &&
               Time.time - _lastAttackTime >= _attackTime;
    }

    protected void Shoot(GameObject target)
    {
        if (CanAttack(target))
        {
            _lastAttackTime = Time.time;
            Vector3 direction = (target.transform.position + Vector3.up - bulletSpawnPoint.position).normalized;
            
            var transformPlayer = GetComponentInParent<PlayerController>().gameObject;
            transformPlayer.transform.LookAt(target.transform);
            
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);

            bullet.transform.forward = direction;

            bullet.GetComponent<Bullet>().Launch();
        }
    }

    protected void Reload()
    {
    }
}