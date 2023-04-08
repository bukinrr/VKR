using UnityEngine;

public class PlayerController : Character
{
    [SerializeField] private GameObject BulletPrefab;
    private GameObject tmpBullet;
    private float _attackTime;
    private float _lastAttackTime;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _attackTime = GetTotalAttackSpeed();
    }

    void Update()
    {
        CanAttack();
        DestroyPlayer();
    }

    private void CanAttack()
    {
        if (Time.time - _lastAttackTime >= _attackTime)
        {
            LaunchBullets();
            _lastAttackTime = Time.time;
        }
    }

    private void LaunchBullets()
    {
        foreach (var enemy in FindObjectsOfType<Enemy>())
        {
            tmpBullet = Instantiate(BulletPrefab, transform.position + Vector3.up, Quaternion.identity);
            tmpBullet.GetComponent<Bullet>().Fire(enemy.transform);
        }
    }

    protected void DestroyPlayer()
    {
        if (Health == 0)
            Destroy(gameObject);
    }
}