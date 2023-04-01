using UnityEngine;

public class Enemy : Character
{
    [SerializeField] private GameObject player;

    [SerializeField] private GameObject managers;
    private ResourceManager _resourceManager;

    [SerializeField] private float attackDistance = 2f;
    [SerializeField] private float attackInterval = 2f;
    [SerializeField] private float lastAttackTime = 0;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _resourceManager = managers.GetComponent<ResourceManager>();
    }

    void Update()
    {
        MovementEnemy();
        DestroyEnemy();
        AttackDistance();
    }

    private void AttackDistance()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance <= attackDistance && Time.time - lastAttackTime >= attackInterval)
        {
            lastAttackTime = Time.time;
            Attack();
        }
    }

    private void Attack()
    {
        player.GetComponent<Player>().GetDamage(Damage);
        Debug.Log($"Enemy наносит урон существу{player.gameObject.name}");
    }

    private void MovementEnemy()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        _rigidbody.AddForceAtPosition(direction * Speed, player.transform.position);
    }

    private void DestroyEnemy()
    {
        if (Health == 0)
        {
            _resourceManager.AddCoins(10);
            Destroy(gameObject);
            // Debug.Log($"У объекта {gameObject.name} закончилось здоровье, поэтому он уничтожен ");
        }
    }
}