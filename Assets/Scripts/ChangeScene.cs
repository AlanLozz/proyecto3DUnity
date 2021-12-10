using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string scene;
    void Start(){}

    public void Change()
    {
        SceneManager.LoadScene(scene);
    }

    void Update(){}
}
