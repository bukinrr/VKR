using UnityEngine;

public class PlayerController : Character
{
    [SerializeField] private GameObject BulletPrefab;
    private GameObject tmpBullet;

    private Transform _target;
    private float _attackRange = 20f;


    private float _attackTime;
    private float _lastAttackTime;

    private RangeWeapon _rangeWeapon;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rangeWeapon = GetComponentInChildren<RangeWeapon>();
    }

    void Update()
    {
        _rangeWeapon.LaunchShoot();
        // CanAttack();
        // DestroyPlayer();
    }

    private void FindTarget()
    {
        if (_target == null)
        {
            RaycastHit[] hits = Physics.SphereCastAll(transform.position, _attackRange, Vector3.up);

            foreach (RaycastHit hit in hits)
            {
                Enemy enemy = hit.collider.GetComponent<Enemy>();
                if (enemy != null)
                {
                    _target = enemy.transform;
                    break;
                }
            }
        }
        else
        {
            Vector3 direction = _target.position - transform.position;
            transform.rotation = Quaternion.LookRotation(direction);

            GameObject bullet = Instantiate(BulletPrefab, transform.position + Vector3.up,
                Quaternion.LookRotation(direction));
            
            //Bullet bu
        }
    }

    private void CanAttack()
    {
        if (Time.time - _lastAttackTime >= _attackTime)
        {
            //LaunchBullets();
            _lastAttackTime = Time.time;
        }
    }

    // private void LaunchBullets()
    // {
    //     foreach (var enemy in FindObjectsOfType<Enemy>())
    //     {
    //         tmpBullet = Instantiate(BulletPrefab, transform.position + Vector3.up, Quaternion.identity);
    //         tmpBullet.GetComponent<Bullet>().Fire(enemy.transform);
    //     }
    // }

    protected void DestroyPlayer()
    {
        if (Health == 0)
            Destroy(gameObject);
    }
}