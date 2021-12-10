using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
  private Rigidbody playerRb;
  public float jumpForce = 30f;
  public float gravityModifier = 9.1f;
  public bool isOnGround = true;
  public bool gameOver = false;
  private Animator playerAnim;
  public ParticleSystem explosionParticle;
  public ParticleSystem dirtParticle;
  public AudioClip jumpSound;
  public AudioClip crashSound;
  private AudioSource playerAudio;
  public int points = 0;
  public TextMeshProUGUI PointsText;
  private AudioSource groundAudio;
  public GameObject gameOverMenu;
  public GameObject pauseMenu;
  private bool existScore = false;
  // Start is called before the first frame update
  void Start()
  {
    gameOver = false;
    playerRb = GetComponent<Rigidbody>();
    Physics.gravity *= gravityModifier;
    playerAnim = GetComponent<Animator>();
    playerAudio = GetComponent<AudioSource>();
    PointsText = GameObject.Find("Puntos").GetComponent<TextMeshProUGUI>();
    groundAudio = GameObject.Find("Main Camera").GetComponent<AudioSource>();
    gameOverMenu.SetActive(false);

  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Space) && isOnGround && gameOver == false)
    {
      playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
      isOnGround = false;
      playerAnim.SetTrigger("Jump_trig");
      dirtParticle.Stop();
      playerAudio.PlayOneShot(jumpSound, 1.0f);
    }
    if (Time.timeScale == 0)
    {
      pauseMenu.SetActive(true);
    }
    else
    {
      pauseMenu.SetActive(false);
    }
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.CompareTag("Point"))
    {
      points++;
      PointsText.text = points.ToString("0 puntos");
      Destroy(other.gameObject);
    }
  }
  private void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.CompareTag("Ground"))
    {
      isOnGround = true;
      dirtParticle.Play();
    }
    else if (collision.gameObject.CompareTag("Obstacle"))
    {
      gameOver = true;
      playerAnim.SetBool("Death_b", true);
      playerAnim.SetInteger("DeathType_int", 1);
      explosionParticle.Play();
      dirtParticle.Stop();
      playerAudio.PlayOneShot(crashSound, 1.0f);
      groundAudio.Stop();
      gameOverMenu.SetActive(true);
      if (existScore)
      {
        if (PlayerPrefs.GetInt("Score") < points)
        {
          PlayerPrefs.SetInt("Score", points);
        }
      }
    }
  }
  public void restartGame()
  {
    SceneManager.LoadScene("Game");
  }
}
