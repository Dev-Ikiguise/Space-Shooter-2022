using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipSpawner : MonoBehaviour
{
    public static EnemyShipSpawner Instance;

    public List<EnemyShip> enemyShipPrefabs;
    public Transform spawnPoint;
    public Transform spawnPivot;

    [HideInInspector] public int currentWave;
    [HideInInspector] public int startingNumberOfShips;

    private void Awake()
    {
        Instance = this;

        currentWave = 1;
        HUD.Instance.DisplayWave(currentWave);

        startingNumberOfShips = FindObjectsOfType<EnemyShip>().Length;

    }

    public void SpawnEnemyShips()
    {
        int enemyShipsToSpawn = startingNumberOfShips + currentWave;

        for (int i = 0; i < enemyShipsToSpawn; i++)
        {
            int rand = Random.Range(0, enemyShipPrefabs.Count);
            float zRotation = Random.Range(0, 360);

            spawnPivot.eulerAngles = new Vector3(0, 0, zRotation);
            Instantiate(enemyShipPrefabs[rand], spawnPoint.position, transform.rotation, null);
        }
    }

    public void CountEnemyShips()
    {
        int numberOfEnemyShips = FindObjectsOfType<EnemyShip>().Length;

        print(numberOfEnemyShips);

        if (numberOfEnemyShips == 1)
        {
            currentWave += 1;
            HUD.Instance.DisplayWave(currentWave);
            SpawnEnemyShips();
        }
    }
}
