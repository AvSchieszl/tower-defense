using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f,120f)]
    [SerializeField] float secondsBetweenSpawns = 2f;
    [SerializeField] EnemyMovement enemyPrefab = default;
    [SerializeField] Transform enemiesParent;
    [SerializeField] Text score;
    private int enemyCount = 0;

    void Start()
    {
        StartCoroutine(RepeatedlySpawnEnemy());
    }

    IEnumerator RepeatedlySpawnEnemy() 
    {
        while (true)
        {
            AddScore();
            var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            newEnemy.transform.parent = enemiesParent;
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }

    private void AddScore()
    {
        enemyCount++;
        score.text = enemyCount.ToString();
    }
}
