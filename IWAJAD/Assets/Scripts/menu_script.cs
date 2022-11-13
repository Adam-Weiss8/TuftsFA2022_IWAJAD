using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menu_script : MonoBehaviour {
    public GameObject resumeButton;
    public GameObject quitButton;
    // bool gameOver = false;

   void start() {
       resumeButton.SetActive(false);
       quitButton.SetActive(false);
   }


  public void loadMainMenuFunc() {
       SceneManager.LoadScene("MainMenu");
   }

  public void resumeButtonFunc() {
       resumeButton.SetActive(true);
       SceneManager.LoadScene("SampleScene");
   }

  public void quitButtonFunc() {
       // quitButton.SetActive(true);
       // gameOver = true;
       //load scence
       #if UNITY_EDITOR 
           UnityEditor.EditorApplication.isPlaying = false;
           #else 
           Application.Quit();
           #endif
       
      
   }
    
}

 