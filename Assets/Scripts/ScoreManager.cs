using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
  private bool existScore = false;
  private int score = 0;
  public TextMeshProUGUI scoreText;
  void Start()
  {
    existScore = PlayerPrefs.HasKey("Score");
    if (existScore)
    {
      score = PlayerPrefs.GetInt("Score");
      Debug.Log("Score: " + score);
    }
    scoreText = GameObject.Find("PuntajeEstadistica").GetComponent<TextMeshProUGUI>();
    scoreText.text = "Mejor puntaje: " + score;
  }

  // Update is called once per frame
  void Update()
  {
    scoreText.text = "Mejor puntaje: " + score;
  }
}
