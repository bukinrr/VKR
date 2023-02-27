using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject Enemy;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1, 3);
    }

    void Update()
    {
    }

    private void SpawnEnemy()
    {
        Instantiate(Enemy.transform, new Vector3(20, 0.5f, 20), Quaternion.identity);
    }
}