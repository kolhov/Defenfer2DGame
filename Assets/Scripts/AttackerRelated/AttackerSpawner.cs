using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{

    [SerializeField] private Attacker[] enemyType;
    [SerializeField] private int numberOfEnemy;
    [SerializeField] private float minSpawnDelay = 1f;
    [SerializeField] private float maxSpawnDelay = 5f;
    private bool spawn = true;
    
    IEnumerator Start()
    {
        while (spawn)
        {
            FindObjectOfType<LevelController>().AttackerSpawned();
            yield return new WaitForSeconds(UnityEngine.Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }

    private void SpawnAttacker()
    {
        var enemyToSpawn = enemyType[Random.Range(0, enemyType.Length)] as Attacker;
        Spawn(enemyToSpawn);
    }

    void Spawn(Attacker enemyToSpawn)
    {
        var newAttacker = Instantiate
            (enemyToSpawn, transform.position,transform.rotation) as Attacker;
        newAttacker.transform.parent = transform;
    }

    public void StopSpawning()
    {
        spawn = false;
    }

}
