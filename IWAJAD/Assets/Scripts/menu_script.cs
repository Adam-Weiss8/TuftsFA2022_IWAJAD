using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menu_script : MonoBehaviour {
    public GameObject resumeButton;
    public GameObject quitButton;
    public GameObject startButton;
    // bool gameOver = false;

   void start() {
       resumeButton.SetActive(false);
       quitButton.SetActive(false);
       startButton.SetActive(false);
       SceneManager.LoadScene("StartScreen");
   }
   
   public void loadFirstLevel() {
       startButton.SetActive(true);
       SceneManager.LoadScene("SampleScene");
   }


  public void loadMainMenuFunc() {
       SceneManager.LoadScene("MainMenu");
   }

  public void resumeButtonFunc() {
       resumeButton.SetActive(true);
       SceneManager.LoadScene("SampleScene");
   }

  public void quitButtonFunc() {
       quitButton.SetActive(true);
       // gameOver = true;
       SceneManager.LoadScene("StartScreen");
       // #if UNITY_EDITOR 
       //     UnityEditor.EditorApplication.isPlaying = false;
       //     #else 
       //     Application.Quit();
       //     #endif
      
   }
    
}

 