using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  void Start(){  }

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Escape))
    {
      togglePause();
    }
  }

  public void togglePause()
  {
    if (Time.timeScale == 1)
    {
      Time.timeScale = 0;
    }
    else
    {
      Time.timeScale = 1;
    }
  }
}
