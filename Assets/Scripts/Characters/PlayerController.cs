using UnityEngine;

public class PlayerController : Character
{
    [SerializeField] private GameObject BulletPrefab;
    private GameObject tmpBullet;

    private Transform _target;
    private float _attackRange = 20f;


    private float _attackTime;
    private float _lastAttackTime;

    private RangeWeapon _rangeWeapon;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rangeWeapon = GetComponentInChildren<RangeWeapon>();
    }

    void Update()
    {
        _rangeWeapon.LaunchShoot();
        // DestroyPlayer();
    }

    protected void DestroyPlayer()
    {
        if (Health == 0)
            Destroy(gameObject);
    }
}