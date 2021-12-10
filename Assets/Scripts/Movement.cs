using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
  public int speed = 30;
  public float worldLimit = -15f;
  public string movementType;
  private PlayerController playerController;
  // Start is called before the first frame update
  void Start()
  {
    playerController = GameObject.Find("Punk").GetComponent<PlayerController>();
  }

  // Update is called once per frame
  void Update()
  {
    if (playerController.gameOver == false)
    {
      switch (movementType)
      {
        case "forward":
          transform.Translate(Vector3.forward * Time.deltaTime * speed);
          break;
        case "backward":
          transform.Translate(Vector3.back * Time.deltaTime * speed);
          break;
        case "left":
          transform.Translate(Vector3.left * Time.deltaTime * speed);
          break;
        case "right":
          transform.Translate(Vector3.right * Time.deltaTime * speed);
          break;
        default:
          transform.Translate(Vector3.forward * Time.deltaTime * speed);
          break;
      }
    }
    if (transform.position.x < worldLimit && gameObject.CompareTag("Obstacle"))
    { Destroy(gameObject); }
    if (transform.position.x < worldLimit && gameObject.CompareTag("Point"))
    { Destroy(gameObject); }
  }
}
