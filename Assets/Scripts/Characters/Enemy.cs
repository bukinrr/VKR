using UnityEngine;

public class Enemy : Character
{
    [SerializeField] protected GameObject player;
    [SerializeField] private int coinPerDeath;
    
    private MeleeWeapon _meleeWeapon;
    private ResourceManager resourceManager;

    void Start()
    {
        Init();
    }
    protected override void Init()
    {
        _meleeWeapon = GetComponent<MeleeWeapon>();
        Rigidbody = GetComponent<Rigidbody>();
        resourceManager = FindObjectOfType<ResourceManager>();
    }
    void Update()
    {
        DestroyEnemy();
       _meleeWeapon.EnemyAttack(player);
    }

    private void DestroyEnemy()
    {
        if (Health <= 0)
        {
            resourceManager.AddCoins(coinPerDeath);
            Destroy(gameObject);
        }
    }
}