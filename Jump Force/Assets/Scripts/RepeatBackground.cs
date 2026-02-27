using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
  private Vector3 startPos;
  private Vector3 midPoint;
  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    midPoint = transform.position;
    startPos = transform.position - midPoint;
  }

  // Update is called once per frame
  void Update()
  {
    if (transform.position.x < startPos.x)
    {
      transform.position = midPoint;
    }
  }
}
