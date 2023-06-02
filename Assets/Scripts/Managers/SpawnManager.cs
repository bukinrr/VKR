using System.Collections;
using UnityEngine;

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
    private ResourceManager _resourceManager;
    private WaitForSeconds _timeEntryEnemies = new WaitForSeconds(2f);

    private Vector3 _leftPosition = new Vector3(-21, 0, 1.5f);
    private Vector3 _mainPosition = new Vector3(-0.7f, 0, 21f);
    private Vector3 _rightPosition = new Vector3(20, 0, 1.5f);
    private Vector3[] _enemyPositions;

    private int _countEnemy;
    private bool _isCreateWave;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _uiManager = GetComponent<UiManager>();
        _resourceManager = GetComponent<ResourceManager>();
        _enemyPositions = new Vector3[] { _leftPosition, _mainPosition, _rightPosition };
    }

    void Update()
    {
        //NeedCreateWave();
        NewWaveRound();
    }

    // private bool NeedCreateWave()
    // {
    //     if (_countEnemy == 0 && _isCreateWave== false) 
    //     {
    //         
    //     }
    // }

    private void NewWaveRound()
    {
        _countEnemy = FindObjectsOfType<Enemy>().Length;

        if (_countEnemy == 0 && _isCreateWave == false)
        {
            _isCreateWave = true;
            _resourceManager.AddWave(1);
            //StartCoroutine(UpAndDownGates());
            SpawnEnemyWave();
            _uiManager.ResetTimer();
            Debug.Log($"Создается волна под номером: {_resourceManager.Wave}");
        }
    }

    private IEnumerator UpAndDownGates()
    {
        ChangePositionGate(gatesMove: GatesMove.Up);

        yield return _timeEntryEnemies;

        ChangePositionGate(gatesMove: GatesMove.Down);
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

            gate.transform.position = Vector3.Lerp(startPosition, endPosition, timeRelease);
        }
    }

    private GameObject[] GetNumberEnemyPrefabList(int numberWave)
    {
        switch (numberWave % 10)
        {
            case 1:
                return lvl1;
            case 2:
                return lvl2;
            case 3:
                return lvl3;
            case 4:
                return lvl4;
            case 5:
                return lvl5;
            case 6:
                return lvl1;
            case 7:
                return lvl2;
            case 8:
                return lvl3;
            case 9:
                return lvl4;
            case 0:
                return lvl5;
        }

        return null;
    }

    private void SpawnEnemyWave()
    {
        //var listEnemyWave = GetNumberEnemyPrefabList(_waveNumber);
        var listEnemyWave = GetNumberEnemyPrefabList(_resourceManager.Wave);

        int positionIndex = 0;

        foreach (var enemy  in listEnemyWave)
        {
            Vector3 uniqueSpawnPosition = GetUniqueSpawnPosition(_enemyPositions, ref positionIndex);
            Instantiate(enemy, EnemyPositon(), Quaternion.identity);
        }


        // foreach (var enemyObject in listEnemyWave)
        // {
        //     Vector3 uniqueSpawnPosition = GetUniqueSpawnPosition(_enemyPositions, ref positionIndex);
        //     Instantiate(enemyObject, uniqueSpawnPosition, Quaternion.identity);
        // }

        _isCreateWave = false;
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

    private Vector3 GetUniqueSpawnPosition(Vector3[] positions, ref int currentIndex)
    {
        Vector3 spawnPosition = positions[currentIndex];

        currentIndex++;
        // if (currentIndex >= positions.Length)
        // {
        //     currentIndex = 0;
        // }

        return spawnPosition;
    }
}