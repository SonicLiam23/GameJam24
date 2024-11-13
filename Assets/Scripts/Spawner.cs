using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject PlainPlatform, Obstacle, Encounter;

    [SerializeField]
    int PlatformsToSpawn, AmountOfObstacles;
    float PlatformLength;
    List<GameObject> PlatformsPool;
    // Update is called once per frame

    private void Start()
    {
        PlatformsPool = new List<GameObject>();
        PlatformLength = PlainPlatform.transform.localScale.z;
        Random.InitState(System.DateTime.Now.Millisecond);

        SpawnPlatforms();
    }
    void Update()
    {
        //need some if statement here so they don't keep spawning

    }

    void GeneratePool()
    {
        // spawns them wayyy off screen
        for (int i = 0; i < PlatformsToSpawn; i++)
        {
            PlatformsPool.Add(Instantiate(PlainPlatform, Vector3.up * i * 100, Quaternion.identity));
        }
        List<int> indexes = new List<int>();
        int ind;
        for (int i = 0; i < AmountOfObstacles; i++) 
        {
            do
            {
                ind = Random.Range(0, PlatformsToSpawn);
            } while (indexes.Contains(ind));
            // obstacles can never spawn together
            indexes.Add(ind);
            indexes.Add(ind + 1);
            indexes.Add(ind - 1);
            
            Object.Destroy(PlatformsPool[ind]);
            PlatformsPool[ind] = Instantiate(Obstacle, Vector3.up * ind * 100, Quaternion.identity);
        }

        PlatformsPool.Add(Instantiate(Encounter, Vector3.up * (PlatformsToSpawn + 1) * 100, Quaternion.identity));
    }

    public void SpawnPlatforms()
    {
        GeneratePool();

        Vector3 Position = transform.position;
        // + 1 for the encounter tile at the end
        for (int i = 0; i < PlatformsToSpawn + 1; i++)
        {
            Position.z += PlatformLength;
            transform.position = Position;

            PlatformsPool[i].gameObject.transform.position = Position;
        }
    }
}
