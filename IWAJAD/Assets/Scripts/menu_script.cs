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
        Time.timeScale = 1f;
       startButton.SetActive(true);
       SceneManager.LoadScene("Level 1R");
   }


  public void loadMainMenuFunc() {
    Time.timeScale = 1f;
       SceneManager.LoadScene("MainMenu");
   }

  public void resumeButtonFunc() {
       resumeButton.SetActive(true);
       SceneManager.LoadScene("SampleScene");
   }

   public void loadCreditsFunc() {
        Time.timeScale = 1f;
       SceneManager.LoadScene("Credits");
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

 