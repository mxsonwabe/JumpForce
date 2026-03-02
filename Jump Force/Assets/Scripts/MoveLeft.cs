using System.Runtime.CompilerServices;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
  private float leftBound;
  PlayerController playerController;
  [SerializeField] private float speed;
  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    speed = 15.0f;
    leftBound = -15f;
    playerController = GameObject.Find("Player").GetComponent<PlayerController>();
  }

  // Update is called once per frame
  void Update()
  {
    if (!playerController.gameOver)
      transform.Translate(Vector3.left * speed * Time.deltaTime);
    if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
    {
     Destroy(gameObject);
    }
  }
}
