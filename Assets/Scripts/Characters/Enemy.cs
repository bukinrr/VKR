using UnityEngine;

public class Enemy : Character
{
    [SerializeField] private GameObject player;
    private PlayerController _playerController;

    [SerializeField] private GameObject managers;
    private ResourceManager _resourceManager;

    [SerializeField] private float attackDistance = 2f;
    [SerializeField] private float lastAttackTime;
    private float _attackTime;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _resourceManager = managers.GetComponent<ResourceManager>();
        _playerController = player.GetComponent<PlayerController>();
        //_attackTime = GetTotalAttackSpeed();
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
        if (distance <= attackDistance && Time.time - lastAttackTime >= _attackTime)
        {
            lastAttackTime = Time.time;
            //Attack();
        }
    }

    // private void Attack()
    // {
    //     _playerController.GetDamage(Damage);
    //     Debug.Log($"Enemy наносит урон существу{player.gameObject.name}, у него осталось {_playerController.Health}");
    // }

    private void MovementEnemy()
    {
        var playerPosition = player.gameObject.transform.position;
        transform.LookAt(playerPosition);
        // transform.position = Vector3.MoveTowards(transform.position, playerPosition,
        //     Speed * Time.deltaTime);
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