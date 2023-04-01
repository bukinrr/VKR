using UnityEngine;

public class Player : Character
{
    [SerializeField] private GameObject BulletPrefab;
    private GameObject tmpBullet;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            LaunchBullets();
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
}