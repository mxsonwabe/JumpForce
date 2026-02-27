using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
  private Vector3 startPos;
  private float midPoint;
  BoxCollider boxCollider;
  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    boxCollider = GetComponent<BoxCollider>();
    midPoint = boxCollider.size.x / 2;
    startPos = transform.position;
  }

  // Update is called once per frame
  void Update()
  {
    if (transform.position.x < (startPos.x - midPoint))
    {
      transform.position = startPos;
    }
  }
}
