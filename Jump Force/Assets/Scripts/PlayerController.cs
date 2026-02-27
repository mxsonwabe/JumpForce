using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
  private bool isGrounded;
  private Rigidbody playerRb;
  private InputAction jumpAction;
  [SerializeField] private float inputForce;
  [SerializeField] private float gravityMod;
  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    playerRb = GetComponent<Rigidbody>();
    jumpAction = InputSystem.actions.FindAction("Jump");
    if (jumpAction == null)
    {
      Debug.LogError("Jump Action Asset NOT set.", this);
      enabled = false;
      return;
    }
    isGrounded = true;
    Physics.gravity *= gravityMod;
  }

  // Update is called once per frame
  void Update()
  {
    if (jumpAction.WasPressedThisFrame() && isGrounded)
    {
      playerRb.AddForce(Vector3.up * 10, ForceMode.Impulse);
      isGrounded = false;
    }
  }

  private void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.CompareTag("Ground"))
    {
      Debug.Log("OnCollision w/ Ground !!");
      isGrounded = true;
    }
    if (collision.gameObject.CompareTag("Obstacle"))
    {
      Debug.Log("Collision with Obstacle");
      Destroy(gameObject);
    }
  }
}
