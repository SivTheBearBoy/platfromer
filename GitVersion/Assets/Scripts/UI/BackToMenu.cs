using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{

    public void LoadFirstScene()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void update(){
    if (Input.GetKeyDown (KeyCode.M)){
      LoadFirstScene();
      }
    }
    
    
}
