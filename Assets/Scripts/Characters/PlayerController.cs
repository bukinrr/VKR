using UnityEngine;

public class PlayerController : Character
{
    private Transform _target;

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
        Rigidbody = GetComponent<Rigidbody>();
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