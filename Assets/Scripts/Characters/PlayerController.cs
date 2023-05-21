using UnityEngine;

public class PlayerController : Character
{
    private RangeWeapon _rangeWeapon;

    void Start()
    {
        Init();
    }

    void Update()
    {
        DestroyPlayer();
        _rangeWeapon.LaunchShoot();
    }

    protected override void Init()
    {
        Rigidbody = GetComponent<Rigidbody>();
        _rangeWeapon = GetComponentInChildren<RangeWeapon>();
    }

    private void DestroyPlayer()
    {
        if (Health <= 0)
            Destroy(gameObject);
    }
}