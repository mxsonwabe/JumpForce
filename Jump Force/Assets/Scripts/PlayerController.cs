using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
  public bool gameOver;
  private bool isGrounded;
  private Rigidbody playerRb;
  private Animator playerAnim;
  private InputAction jumpAction;
  private AudioSource audioSource;
  [SerializeField] private float inputForce;
  [SerializeField] private float gravityMod;
  [SerializeField] private ParticleSystem explosionParticle;
  [SerializeField] private ParticleSystem dirtParticle;
  [SerializeField] private AudioClip jumpClip;
  [SerializeField] private AudioClip deathClip;
  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    gameOver = false;
    playerRb = GetComponent<Rigidbody>();
    playerAnim = GetComponent<Animator>();
    audioSource = GetComponent<AudioSource>();
    if (!audioSource)
    {
      Debug.LogError("Audio Source System Error.", this);
      enabled = false;
      return;
    }
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
      {
        audioSource.PlayOneShot(jumpClip, 1.0f);
        dirtParticle.Play();
      }
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
      audioSource.PlayOneShot(deathClip, 1.0f);
      //Time.timeScale = 0f;
    }
  }
}
