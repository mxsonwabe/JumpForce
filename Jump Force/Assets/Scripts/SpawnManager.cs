using UnityEngine;

public class SpawnManager : MonoBehaviour
{
  [SerializeField] GameObject obstaclePrefab;
  private Vector3 spawnPosition;
  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    spawnPosition = new Vector3(25, 0, 0);
    Instantiate(obstaclePrefab, spawnPosition, obstaclePrefab.transform.rotation);
  }

  // Update is called once per frame
  void Update()
  {
  }
}
