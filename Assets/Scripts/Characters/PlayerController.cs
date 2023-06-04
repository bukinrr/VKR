using System;
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
        _rangeWeapon.LaunchShoot();
        DestroyPlayer();
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