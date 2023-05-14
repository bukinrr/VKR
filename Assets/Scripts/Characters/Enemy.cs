using System;
using UnityEngine;

public class Enemy : Character
{
    [SerializeField] protected GameObject player;

    [SerializeField] private GameObject managers;
    private ResourceManager _resourceManager;

    private MeleeWeapon _meleeWeapon;
    private float _attackTime;

    [SerializeField] private int coinPerDeath;

    void Start()
    {
        Init();
    }

    void Update()
    {
        //MovementEnemy();
        DestroyEnemy();
        _meleeWeapon.EnemyAttack(player);
    }
    

    protected override void Init()
    {
        Rigidbody = GetComponent<Rigidbody>();
        _resourceManager = managers.GetComponent<ResourceManager>();
        _meleeWeapon = GetComponent<MeleeWeapon>();
    }

    // private void MovementEnemy()
    // {
    //     var playerPosition = player.transform.position;
    //     transform.LookAt(playerPosition);
    //     Vector3 direction = (playerPosition - transform.position).normalized;
    //     Rigidbody.AddForceAtPosition(direction * Speed, playerPosition);
    // }

    private void DestroyEnemy()
    {
        if (Health <= 0)
        {
            _resourceManager.AddCoins(coinPerDeath);
            Destroy(gameObject);
        }
    }
}