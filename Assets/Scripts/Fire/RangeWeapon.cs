using System.Collections;
using UnityEngine;

public class RangeWeapon : Weapon
{
    protected enum FireMode
    {
        None,
        SingleFireMode,
        BurstFireMode,
        FullAutoFireMode,
        ShotgunMode
    }

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float attackRange;
    [SerializeField] private float reloadTime;
    [SerializeField] private int maxCountBulletInMagazine;
    [SerializeField] private int maxMaxCountBullet;
    [SerializeField] protected FireMode RangeFireMode;
    [SerializeField] private Transform bulletSpawnPoint;

    private int _currentAmmoInMagazine;

    private float _attackTime;
    private float _lastAttackTime;
    private bool _reload = false;


    private int MaxCountBullet
    {
        get => maxMaxCountBullet;
        set => maxMaxCountBullet = Mathf.Clamp(value, 0, 500);
    }

    private void Start()
    {
        Init();
    }

    protected override void Init()
    {
        AttackType = RangeType.Range;
        _attackTime = GetTotalAttackSpeed();
        _currentAmmoInMagazine = maxCountBulletInMagazine;
    }

    public void LaunchShoot()
    {
        var target = FindTarget();
        Shoot(target);
    }


    protected override GameObject FindTarget()
    {
        //Первый кто попадет в радиус(не обязательно ближаший к игроку)
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, attackRange);

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Enemy"))
                return hitCollider.gameObject;
        }

        return null;

        //ПОИСК БЛИЖАЙШЕГО
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
        //
        // return closestEnemy;
    }

    protected override bool CanAttack(GameObject target)
    {
        var elapsedTime = (Time.time - _lastAttackTime) >= _attackTime;
        return bulletPrefab && bulletSpawnPoint && target && elapsedTime
               && _currentAmmoInMagazine > 0 && _reload == false;
    }

    protected void Shoot(GameObject target)
    {
        CanReload();
        if (CanAttack(target))
        {
            _lastAttackTime = Time.time;
            Vector3 direction = (target.transform.position + Vector3.up - bulletSpawnPoint.position).normalized;

            var transformPlayer = GetComponentInParent<PlayerController>().gameObject;
            transformPlayer.transform.LookAt(target.transform);

            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);

            bullet.transform.forward = direction;

            bullet.GetComponent<Bullet>().Launch(Damage);
            _currentAmmoInMagazine -= 1;
        }
    }

    protected void CanReload()
    {
        if (_currentAmmoInMagazine <= 0)
            StartCoroutine(ReloadMagazine());
    }

    private IEnumerator ReloadMagazine()
    {
        if (_currentAmmoInMagazine >= maxCountBulletInMagazine)
            yield break;

        _reload = true;
        _currentAmmoInMagazine += maxCountBulletInMagazine;
        yield return new WaitForSeconds(reloadTime);
        _reload = false;
    }
}