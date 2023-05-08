using UnityEngine;

public class PlayerController : Character
{
    [SerializeField] private GameObject BulletPrefab;

    private Transform _target;

    private float _attackTime;
    private float _lastAttackTime;

    private RangeWeapon _rangeWeapon;

    void Start()
    {
        Init();
    }

    void Update()
    {
        _rangeWeapon.LaunchShoot();
        DestroyPlayer();
    }

    protected override void Init()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rangeWeapon = GetComponentInChildren<RangeWeapon>();
    }

    protected void DestroyPlayer()
    {
        if (Health <= 0)
        {
            Debug.Log("Объект должен быть уничтожен");
            Destroy(gameObject);
        }
    }
}