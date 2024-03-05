using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject miniPrefab;
    [SerializeField]
    private float minSpawnTime;
    [SerializeField]
    private float maxSpawnTime;
    private float timeUntilSpawn;

    void Awake()
    {
        setRandomSpawnTime();
    }
    // Spawn Pikimini on right click down.
    void Update()
    {
        /*
        if (Input.GetButtonDown("Fire2"))
        {
            Instantiate(this.miniPrefab, this.gameObject.transform.position, Quaternion.identity);
        }*/
        timeUntilSpawn -= Time.deltaTime;
        if (timeUntilSpawn <= 0)
        {
            Instantiate(this.miniPrefab, this.gameObject.transform.position, Quaternion.identity);
            setRandomSpawnTime();
        }
    }

    void setRandomSpawnTime()
    {
        timeUntilSpawn = Random.Range(minSpawnTime, maxSpawnTime);
    }
}