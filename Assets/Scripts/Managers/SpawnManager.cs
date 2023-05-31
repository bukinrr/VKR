using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    enum GatesMove
    {
        Up,
        Down
    }

    [Header("Список врагов")] [SerializeField]
    private GameObject[] lvl1;

    [SerializeField] private GameObject[] lvl2;
    [SerializeField] private GameObject[] lvl3;
    [SerializeField] private GameObject[] lvl4;
    [SerializeField] private GameObject[] lvl5;

    [SerializeField] private GameObject[] gates;

    private UiManager _uiManager;
    private WaitForSeconds timeEntryEnemies = new WaitForSeconds(2f);

    private int waveNumber;
    private int countEnemy;

    private void Awake()
    {
        _uiManager = GetComponent<UiManager>();
    }

    void Update()
    {
        CountEnemy();
        NewWaveRound();
    }

    private void NewWaveRound()
    {
        countEnemy = FindObjectsOfType<Enemy>().Length;

        if (countEnemy == 0)
        {
            StartCoroutine(UpAndDownGates());
        }
    }

    private void UIAndEffects()
    {
    }

    private IEnumerator UpAndDownGates()
    {
        ChangePositionGate(gatesMove: GatesMove.Up);

        yield return timeEntryEnemies;
        
        ChangePositionGate(gatesMove: GatesMove.Down);
        
        yield return this;
        SpawnEnemyWave(1);
    }

    private void ChangePositionGate(GatesMove gatesMove)
    {
        foreach (var gate in gates)
        {
            Vector3 startPosition = gate.transform.position;
            Vector3 endPosition;
            float timeRelease;
            if (gatesMove == GatesMove.Up)
            {
                endPosition = gate.transform.position + Vector3.up * 2;
                timeRelease = 2;
                gate.SetActive(false);
            }
            else
            {
                endPosition = gate.transform.position + Vector3.down * 2;
                timeRelease = 0.5f;
                gate.SetActive(true);
            }

            Vector3.Lerp(startPosition, endPosition, timeRelease);
        }
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