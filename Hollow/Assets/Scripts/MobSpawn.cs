using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MobSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject meleeMob;
    [SerializeField]
    private GameObject rangedMob;
    [SerializeField]
    private GameObject bossMob;
    [SerializeField]
    private float minSpawnTime;
    [SerializeField]
    private float maxSpawnTime;
    [SerializeField]
    private float numMobs;
    [SerializeField]
    private Camera managedCamera;

    private float timeUntilSpawn;
    private float timeUntilRangedSpawn = 20.0f;
    private float Timer;
    private float bossTimer = 0.0f;
    private bool bossSpawn = false;

    void Start()
    {
        setRandomSpawnTime();
    }
    
    void Update()
    {
        Timer += Time.deltaTime;
        bossTimer += Time.deltaTime;
        timeUntilSpawn -= Time.deltaTime;
        if (timeUntilSpawn <= 0)
        {
            for (int i=0; i< numMobs; i++)
            {
                int randSide = Random.Range(0, 4);
                Vector3 spawnLocation;
                if(randSide == 0)
                {
                    // Spawn from left side.
                    spawnLocation = managedCamera.ViewportToWorldPoint(new Vector3(0, Random.Range(0.0f, 1.0f), managedCamera.nearClipPlane));
                }
                else if(randSide == 1)
                {
                    // Spawn from right side.
                    spawnLocation = managedCamera.ViewportToWorldPoint(new Vector3(1, Random.Range(0.0f, 1.0f), managedCamera.nearClipPlane));
                }else if (randSide == 2)
                {
                    // Spawn from bottom side.
                    spawnLocation = managedCamera.ViewportToWorldPoint(new Vector3(Random.Range(0.0f, 1.0f), 0, managedCamera.nearClipPlane));
                }
                else 
                {
                    // Spawn from top side.
                    spawnLocation = managedCamera.ViewportToWorldPoint(new Vector3(Random.Range(0.0f, 1.0f), 1, managedCamera.nearClipPlane));
                }

                // Check to see if spawning on valid NavMesh. If not finds the closest valid area to spawn.
                NavMeshHit hit;
                UnityEngine.AI.NavMesh.SamplePosition(spawnLocation, out hit, Mathf.Infinity, UnityEngine.AI.NavMesh.AllAreas);
                spawnLocation = hit.position;
                spawnLocation.z = 0;
                if (Timer >= timeUntilRangedSpawn)
                {
                    // Random chance to spawn ranged mobs.
                    int randMob = Random.Range(0, 3);
                    if (randMob == 0)
                    {
                        Instantiate(this.rangedMob, spawnLocation, Quaternion.identity);
                    }
                    else
                    {
                        if (Timer >= 120.0f)
                        {
                            Instantiate(this.bossMob, spawnLocation, Quaternion.identity);
                        }
                        else
                        {
                            Instantiate(this.meleeMob, spawnLocation, Quaternion.identity);
                        }
                    }
                }
                else
                {
                    Instantiate(this.meleeMob, spawnLocation, Quaternion.identity);
                }
                // Spawn boss type mob.
                if (bossTimer >= 90.0f)
                {
                    AudioManager.instance.PlaySoundEffects("BossGrunt");
                    Instantiate(this.bossMob, spawnLocation, Quaternion.identity);
                    bossTimer = 0.0f;
                }
            }
            setRandomSpawnTime();
        }
    }

    void setRandomSpawnTime()
    {
        timeUntilSpawn = Random.Range(minSpawnTime, maxSpawnTime);
    }
}