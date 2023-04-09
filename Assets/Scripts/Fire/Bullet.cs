using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speedBullet;
    [SerializeField] public float maxDistance;

    private float distanceTraveled = 0f;

    public void Launch()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speedBullet;
    }

    private void Update()
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
            Debug.Log($"Хп до удара {targetEnemyComponent.Health}");
            targetEnemyComponent.GetDamage(this, 2);
            Debug.Log($"Хп после удара {targetEnemyComponent.Health}");
            Destroy(gameObject);
        }
    }


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