using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
  public bool gameOver;
  private bool isGrounded;
  private Rigidbody playerRb;
  private Animator playerAnim;
  private InputAction jumpAction;
  [SerializeField] private float inputForce;
  [SerializeField] private float gravityMod;
  //public ParticleSystem particleSystem;
  [SerializeField] private ParticleSystem explosionParticle;
  [SerializeField] private ParticleSystem dirtParticle;
  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    gameOver = false;
    playerRb = GetComponent<Rigidbody>();
    playerAnim = GetComponent<Animator>();
    //particleSystem = GetComponent<ParticleSystem>();
    //if (!particleSystem)
    //{
    //  Debug.LogError("Particle System Error.", this);
    //  enabled = false;
    //  return;
    //}
    if (!playerAnim || !playerRb)
    {
      Debug.LogError("!playerAnim || !playerRb", this);
      enabled = false;
      return;
    }
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
      playerRb.AddForce(Vector3.up * inputForce, ForceMode.Impulse);
      isGrounded = false;
      playerAnim.SetTrigger("Jump_trig");
      dirtParticle.Stop();
    }
  }

  private void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.CompareTag("Ground"))
    {
      Debug.Log("OnCollision w/ Ground !!");
      isGrounded = true;
      if (!gameOver)
        dirtParticle.Play();
    }
    if (collision.gameObject.CompareTag("Obstacle"))
    {
      Debug.Log("Collision with Obstacle");
      //Destroy(gameObject);
      dirtParticle.Stop();
      playerAnim.SetBool("Death_b", true);
      playerAnim.SetInteger("DeathType_int", 1);
      gameOver = true;
      explosionParticle.Play();
      //Time.timeScale = 0f;
    }
  }
}
