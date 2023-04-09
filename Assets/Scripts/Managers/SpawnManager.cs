using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Список врагов")] [SerializeField]
    private GameObject[] arrayEnemy;

    private int waveNumber;
    private int countEnemy;

    void Start()
    {
    }

    void Update()
    {
        CountEnemy();
    }

    private void CountEnemy()
    {
        countEnemy = FindObjectsOfType<Enemy>().Length;
        if (countEnemy == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
        }
    }

    private void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(arrayEnemy[Random.Range(0, arrayEnemy.Length)], EnemyPositon(), Quaternion.identity);
        }
    }

    private Vector3 EnemyPositon()
    {
        int minBorder = 10;
        int maxBorder = 24;
        float rndX = Random.Range(minBorder, maxBorder);
        float rndZ = Random.Range(minBorder, maxBorder);
        float rndXMinus = -Random.Range(minBorder, maxBorder);
        float rndZMinus = -Random.Range(minBorder, maxBorder);

        return new Vector3(Random.Range(rndXMinus, rndX), 0, Random.Range(rndZMinus, rndZ));
    }
}