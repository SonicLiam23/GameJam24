using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;

    [SerializeField]
    private GameObject player;

    private float playerPositionY;
    // Update is called once per frame

    private void Start()
    {
        player = GameObject.Find("Player");
        playerPositionY = player.transform.position.y;
    }
    void Update()
    {
        //need some if statement here so they don't keep spawning

        Vector3 spawnPosition = new Vector3(0, 10, Random.Range(playerPositionY + 100, playerPositionY + 400));
        Instantiate(prefab, spawnPosition, Quaternion.identity);


        
    }
}
