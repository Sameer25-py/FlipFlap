using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using DefaultNamespace;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> obstacles;

    public  float     ObstacleMoveSpeed      = 5f;
    private Coroutine _spawnObstaclesRoutine = null;


    private void OnEnable()
    {
        Player.PlayerTouchObstacle += StopSpawningObstacles;
    }

    private void OnDisable()
    {
        Player.PlayerTouchObstacle -= StopSpawningObstacles;
    }

    private IEnumerator SpawnObstaclesRoutine()
    {
        while (true)
        {
            GameObject randomObstacle = obstacles[Random.Range(0, obstacles.Count)];
            randomObstacle.transform.position = new Vector3(5f, randomObstacle.transform.position.y, 0f);
            randomObstacle.GetComponent<Obstacle>()
                .speed = ObstacleMoveSpeed;
            randomObstacle.SetActive(true);
            yield return new WaitForSeconds(2f);
        }
    }

    public void ResetObstacles()
    {
        foreach (GameObject obs in obstacles)
        {
            obs.SetActive(false);
            obs.transform.position = new Vector3(5f, obs.transform.position.y, 0f);
        }
    }

    public void StopSpawningObstacles()
    {
        if (_spawnObstaclesRoutine != null)
        {
            StopCoroutine(_spawnObstaclesRoutine);
        }

        _spawnObstaclesRoutine = null;
        ResetObstacles();
    }

    public void StartSpawningObstacles()
    {
        if (_spawnObstaclesRoutine != null)
        {
            StopCoroutine(_spawnObstaclesRoutine);
        }

        _spawnObstaclesRoutine = StartCoroutine(SpawnObstaclesRoutine());
    }
}