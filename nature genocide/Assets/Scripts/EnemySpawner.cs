using System;
using System.Collections;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _spawnPositions;
    [SerializeField] private GameObject[] _meteoriteSpawnPositions;

    [SerializeField] private GameObject[] _enemyPrefab;
    [SerializeField] private GameObject _meteorite;
    [SerializeField] private int _numberOfEnemiesToSpawn;

    [SerializeField] private float _timeToStartWave;
    private bool _isCountingDown = true;
    public float _waveSpawnTimer = 0f;

    private float _difficultyTimer = 0f;
    private float _meteoriteTimer = 0f;
    [SerializeField] private float _timeForMeteoriteSpawn = 30f;

    [SerializeField] private float _timeToIncreaseDifficulty;

    [SerializeField] private float _timeBetweenSpawns = 0.2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_waveSpawnTimer > _timeToStartWave)
        {
            _isCountingDown = false;
            _waveSpawnTimer = 0f;
            
            StartCoroutine(SpawnWave());
        }

        else if (_isCountingDown == true)
        {
            _waveSpawnTimer += Time.deltaTime;
        }

        if (_difficultyTimer < _timeToIncreaseDifficulty)
        {
            _difficultyTimer += Time.deltaTime;
        }

        else
        {
            _difficultyTimer = 0f;
            ChangeDiffculty();
        }

        if (_meteoriteTimer < _timeForMeteoriteSpawn)
        {
            _meteoriteTimer += Time.deltaTime;
        }

        else

        {
            _meteoriteTimer = 0f;

            System.Random rnd = new System.Random();
            int spawnIndex = rnd.Next(0, _meteoriteSpawnPositions.Length);

            Instantiate(_meteorite, _meteoriteSpawnPositions[spawnIndex].transform.position, Quaternion.identity);
        }
    }

    private void ChangeDiffculty()
    {
        if (_timeBetweenSpawns > 0.5f)
        {
            _timeBetweenSpawns -= 0.1f;
        }

        if (_numberOfEnemiesToSpawn < 100)
        {
            _numberOfEnemiesToSpawn += 5;
        }        
    }

    private IEnumerator SpawnWave()
    {
        for (int i = 0; i < _numberOfEnemiesToSpawn; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(_timeBetweenSpawns);
        } 

        _isCountingDown = true;
    }

    private void SpawnEnemy()
    {
        int enemyIndex;
        System.Random rnd = new System.Random();
        enemyIndex = rnd.Next(0, _enemyPrefab.Length -1);

        int spawnPositionIndex;
        spawnPositionIndex = rnd.Next(0, _spawnPositions.Length - 1);

        // Check if spawnPosition is active
        for (bool spawnIsActive = false; spawnIsActive == true;)
        {
            _spawnPositions[spawnPositionIndex].TryGetComponent<SpawnPoint>(out SpawnPoint spawnPointScript);

            if (spawnPointScript.canSpawn == true) 
            { 
                spawnIsActive = true;
            }

            else
            {
                spawnPositionIndex = rnd.Next(0, _spawnPositions.Length - 1);
            }
        }

        Instantiate(_enemyPrefab[enemyIndex], _spawnPositions[spawnPositionIndex].transform.position, Quaternion.identity);
    }
}