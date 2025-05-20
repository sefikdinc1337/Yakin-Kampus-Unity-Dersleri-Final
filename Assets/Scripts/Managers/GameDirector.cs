using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public EnemyManager enemyManager;
    public LevelManager levelManager;
    public Player player;

    private void Start()
    {
        RestartLevel();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();

        }
    }

    private void RestartLevel()
    {
        levelManager.RestartLevel();
        enemyManager.RestartEnemyManager();
        player.RestartPlayer();
    }

    public void LevelCompleted()
    {
        enemyManager.StopEnemies();
    }
}
