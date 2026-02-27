using UnityEngine;

public class SpawnManager : MonoBehaviour
{
  [SerializeField] GameObject obstaclePrefab;
  private Vector3 spawnPosition;
  private float startDelay, spawnFreq;
  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    startDelay = 2.0f;
    spawnFreq = 1.5f;
    spawnPosition = new Vector3(30, 0, 0);
    InvokeRepeating(nameof(SpawnObstacle), startDelay, spawnFreq);
  }

  // Update is called once per frame
  void Update()
  {
  }

  void SpawnObstacle()
  {
    Instantiate(obstaclePrefab, spawnPosition, obstaclePrefab.transform.rotation);
  }
}
