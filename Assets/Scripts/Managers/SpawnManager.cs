using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Список врагов")] [SerializeField]
    private GameObject[] lvl1;

    [SerializeField] private GameObject[] lvl2;
    [SerializeField] private GameObject[] lvl3;
    [SerializeField] private GameObject[] lvl4;
    [SerializeField] private GameObject[] lvl5;

    private int waveNumber;
    private int countEnemy;

    void Update()
    {
        CountEnemy();
    }

    private void CountEnemy()
    {
        countEnemy = FindObjectsOfType<Enemy>().Length;
        // if (countEnemy == 0)
        // {
        //     waveNumber++;
        //     SpawnEnemyWave(waveNumber);
        // }
        if (countEnemy == 0)
        {
            SpawnEnemyWave(1);
        }
    }

    private void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            if (waveNumber == 0)
            {
                Instantiate(lvl1[Random.Range(0, lvl1.Length)], EnemyPositon(), Quaternion.identity);
            }
            else if (waveNumber == 1)
            {
                Instantiate(lvl2[Random.Range(0, lvl1.Length)], EnemyPositon(), Quaternion.identity);
            }
            else if (waveNumber == 2)
            {
                Instantiate(lvl3[Random.Range(0, lvl1.Length)], EnemyPositon(), Quaternion.identity);
            }
            else if (waveNumber == 3)
            {
                Instantiate(lvl4[Random.Range(0, lvl1.Length)], EnemyPositon(), Quaternion.identity);
            }

        }
    }

    private Vector3 EnemyPositon()
    {
        float minBorder = 15;
        float maxBorder = 21f;
        float rndX = Random.Range(minBorder, maxBorder);
        float rndZ = Random.Range(minBorder, maxBorder);
        float rndXMinus = -Random.Range(minBorder, maxBorder);
        float rndZMinus = -Random.Range(minBorder, maxBorder);

        return new Vector3(Random.Range(rndXMinus, rndX), 0, Random.Range(rndZMinus, rndZ));
    }
}