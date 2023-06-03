using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speedBullet;
    [SerializeField] public float maxDistance;

    private float _damage;

    private float distanceTraveled;

    public float SpeedBullet
    {
        get => speedBullet;
        set => speedBullet = value;
    }
    public void Launch(float damage)
    {
        _damage = damage;
        GetComponent<Rigidbody>().velocity = transform.forward * speedBullet;
    }


    private void Update()
    {
        DestroyBullet();
    }

    private void DestroyBullet()
    {
        distanceTraveled += speedBullet * Time.deltaTime;
        if (distanceTraveled >= maxDistance)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            Enemy targetEnemyComponent = collision.gameObject.GetComponent<Enemy>();
            targetEnemyComponent.GetDamage(this, _damage);
            Destroy(gameObject);
        }
    }

    public void IncreaseSpeedBullet(object sender,float value)
    {
        speedBullet += value;
    }
    public void ReduceSpeedBullet(object sender,float value)
    {
        speedBullet -= value;
    }

    // Самонаводка
    // private Transform _target;
    //
    // public float direction;
    //
    // private  float _speed = 10f;
    // private  float _aliveTimer = 5f;
    //
    // private bool _homing;
    //
    // void Update()
    // {
    //     if (_homing && _target != null)
    //     {
    //         Vector3 moveDirection = (_target.transform.position - transform.position).normalized;
    //         transform.position += moveDirection * _speed * Time.deltaTime;
    //         transform.LookAt(_target);
    //     }
    // }
    //
    // internal void Fire(Transform newTarget)
    // {
    //     _target = newTarget;
    //     _homing = true;
    //     Destroy(gameObject, _aliveTimer);
    // }
    //
    // private void OnCollisionEnter(Collision collision)
    // {
    //     if (collision.transform.CompareTag("Enemy"))
    //     {
    //         Enemy targetEnemyComponent = collision.gameObject.GetComponent<Enemy>();
    //         targetEnemyComponent.GetDamage(1);
    //         Destroy(gameObject);
    //     }
    // }
}