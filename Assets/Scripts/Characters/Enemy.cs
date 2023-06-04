using UnityEngine;

public class Enemy : Character
{
    [SerializeField] protected GameObject player;
    [SerializeField] private int coinPerDeath;
    [SerializeField] private int experiencePerDeath;

    private MeleeWeapon _meleeWeapon;
    private ResourceManager _resourceManager;

    void Start()
    {
        Init();
    }
    protected override void Init()
    {
        _meleeWeapon = GetComponent<MeleeWeapon>();
        Rigidbody = GetComponent<Rigidbody>();
        _resourceManager = FindObjectOfType<ResourceManager>();
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
            _resourceManager.AddCoins(coinPerDeath);
            _resourceManager.AddExperinceR(experiencePerDeath);
            Destroy(gameObject);
        }
    }

    public void DestroyEnemySpawnManager()
    {
        Destroy(gameObject);
    }
}