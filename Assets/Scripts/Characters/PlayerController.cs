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
        DestroyPlayer();
        _rangeWeapon.LaunchShoot();
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
            Debug.Log("У игрока 0 хп");
            Destroy(gameObject);
        }
    }
}