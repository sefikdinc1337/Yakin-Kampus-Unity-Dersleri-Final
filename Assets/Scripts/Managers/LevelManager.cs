using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject door;
    public GameObject collectablePrefab;
    public List<GameObject> collectables;

    public void RestartLevel()
    {
        DeactivateDoor();
        RandomizeDoorPosition();
        DeleteCollectables();
        GenerateCollectables();
    }

    private void DeleteCollectables()
    {
        foreach (GameObject c in collectables)
        {
            Destroy(c);
        }
        collectables.Clear();

    }

    private void GenerateCollectables()
    {
        var newCollectable = Instantiate(collectablePrefab);
        newCollectable.transform.position = new Vector3(Random.Range(-4, 4), 0, 9.5f);
        collectables.Add(newCollectable);
    }

    private void RandomizeDoorPosition()
    {
        var pos = door.transform.position;
        pos.x = Random.Range(-2.8f, 2.8f);
        door.transform.position = pos;
    }

    private void DeactivateDoor()
    {
        door.SetActive(false);
    }

    public void AppleCollected()
    {
        door.SetActive(true);
    }
}
