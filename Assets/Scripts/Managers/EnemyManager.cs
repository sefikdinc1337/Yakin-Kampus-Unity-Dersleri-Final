using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Player player;
    public Enemy enemyPrefab;
    public List<Enemy> enemies;

    


    public Vector2 enemyCount;

    public void RestartEnemyManager()
    {
        DeleteEnemies();
        GenerateEnemies();
    }

    private void DeleteEnemies()
    {
        foreach (Enemy e in enemies)
        {
            Destroy(e.gameObject);
        }
        enemies.Clear();
    }

    private void GenerateEnemies()
    {
        var randomEnemyCount = UnityEngine.Random.Range(enemyCount.x, enemyCount.y);
        for (int i = 0; i < randomEnemyCount; i++)
        {
            var enemyXPos = 0f;
            enemyXPos = UnityEngine.Random.Range(-2, 2);
            var newEnemy = Instantiate(enemyPrefab);
            newEnemy.transform.position = new Vector3(enemyXPos, 0, -4.5f + i*3);
            enemies.Add(newEnemy);
            newEnemy.StartEnemy(player);
        }
        
    }

    

    public void StopEnemies()
    {
        foreach (Enemy enemy in enemies)
        {
            enemy.Stop();
        }
    }
}
