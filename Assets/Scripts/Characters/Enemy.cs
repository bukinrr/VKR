using UnityEngine;

public class Enemy : Character
{
    [SerializeField] protected GameObject player;

    [SerializeField] private GameObject managers;
    private ResourceManager _resourceManager;
    private MeleeWeapon _meleeWeapon;

    [SerializeField] private int coinPerDeath;

    void Start()
    {
        Init();
    }

    void Update()
    {
        DestroyEnemy();
        _meleeWeapon.EnemyAttack(player);
    }
    

    protected override void Init()
    {
        Rigidbody = GetComponent<Rigidbody>();
        _resourceManager = managers.GetComponent<ResourceManager>();
        _meleeWeapon = GetComponent<MeleeWeapon>();
    }

    private void DestroyEnemy()
    {
        if (Health <= 0)
        {
            _resourceManager.AddCoins(coinPerDeath);
            Destroy(gameObject);
        }
    }
}