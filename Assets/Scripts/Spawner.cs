using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _asteroidPrefab = new GameObject[6];

    private Vector2 _secondsBetweenSpawnMinMax = new Vector2(0.05f, 1f);
    private float _nextSpawnTime;
    private Vector2 _screenHalfSizeWorldUnits;


    void Start()
    {
        _screenHalfSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }


    void Update()
    {
        if (Time.time > _nextSpawnTime)
        {
            AsteroidSpawn();
        }
    }
    public void SetDifficuylty()
    {
        Difficulty.SetDifficulty(180);
        Debug.Log("Seconds to max speed" + 180);
    }
    private void AsteroidSpawn()
    {
        float secondsBetweenSpawn = Mathf.Lerp(_secondsBetweenSpawnMinMax.y, _secondsBetweenSpawnMinMax.x, Difficulty.GetDifficultyPercent());
        _nextSpawnTime = Time.time + secondsBetweenSpawn;

        Vector2 spawnPosition = new Vector2(Random.Range(-_screenHalfSizeWorldUnits.x, _screenHalfSizeWorldUnits.x), _screenHalfSizeWorldUnits.y );
        GameObject newAsteroid = (GameObject)Instantiate(_asteroidPrefab[Random.Range(0, _asteroidPrefab.Length)], spawnPosition, Quaternion.identity);
    }
}
