using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Cronometro : MonoBehaviour
{
  public TextMeshProUGUI UiText;
  public PlayerController player;
  public double time = 0;
  // Start is called before the first frame update
  void Start()
  {
      player = GameObject.Find("Punk").GetComponent<PlayerController>();
  }

  // Update is called once per frame
  void Update()
  {
    if (!player.gameOver)
    {
      time += (Time.deltaTime * 10);
      UiText.text = time.ToString("0 mts");
    }
  }
}
