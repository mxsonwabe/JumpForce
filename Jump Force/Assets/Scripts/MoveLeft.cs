using UnityEngine;

public class MoveLeft : MonoBehaviour
{
  [SerializeField] private float speed;
  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    speed = 15.0f;
  }

  // Update is called once per frame
  void Update()
  {
    transform.Translate(Vector3.left * speed * Time.deltaTime);
  }
}
