using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsSpawner : MonoBehaviour
{
  public GameObject[] PointsPrefabs;
  private Vector3 spawnPos = new Vector3(25, 0, 0);
  private float startDelay = 2;
  private float repeatRate = 1;
  private PlayerController playerControllerScript;
  // Start is called before the first frame update
  void Start()
  {
    startDelay = Random.Range(0.8f, 2.0f);
    InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    playerControllerScript = GameObject.Find("Punk").GetComponent<PlayerController>();
  }
  void SpawnObstacle()
  {
    if (playerControllerScript.gameOver == false)
    {
      int obstaclePointIndex = Random.Range(3, 6);
      Instantiate(PointsPrefabs[0], new Vector3(25, obstaclePointIndex, 0), PointsPrefabs[0].transform.rotation);
    }
  }

  // Update is called once per frame
  void Update()
  { }
}
