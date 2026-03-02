using UnityEngine;

public class SpawnManager : MonoBehaviour
{
  private Vector3 spawnPosition;
  private float startDelay, spawnFreq;
  PlayerController playerController;
  [SerializeField] GameObject obstaclePrefab;
  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    startDelay = 2.5f;
    spawnFreq = 1.5f;
    spawnPosition = new Vector3(30, 0, 0);
    playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    InvokeRepeating(nameof(SpawnObstacle), startDelay, spawnFreq);
  }

  // Update is called once per frame
  void Update()
  {
  }

  void SpawnObstacle()
  {
    if (!playerController.gameOver)
      Instantiate(obstaclePrefab, spawnPosition, obstaclePrefab.transform.rotation);
  }
}
