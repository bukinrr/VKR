using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform _target;

    private  float _speed = 10f;
    private  float _aliveTimer = 5f;

    private bool _homing;

    void Update()
    {
        if (_homing && _target != null)
        {
            Vector3 moveDirection = (_target.transform.position - transform.position).normalized;
            transform.position += moveDirection * _speed * Time.deltaTime;
            transform.LookAt(_target);
        }
    }

    internal void Fire(Transform newTarget)
    {
        _target = newTarget;
        _homing = true;
        Destroy(gameObject, _aliveTimer);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            Enemy targetEnemyComponent = collision.gameObject.GetComponent<Enemy>();
            targetEnemyComponent.GetDamage(1);
            Destroy(gameObject);
        }
    }
}