using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class menu_script : MonoBehaviour { //IPointerEnterHandler, IPointerExitHandler {
    public GameObject resumeButton;
    public GameObject quitButton;
    public GameObject startButton;
    public GameObject pauseButton;
    public GameObject levelButton;
    public GameObject settingButton;

    
    //for Hovering
    public Button button;
    public Color wantedColor;
    private Color originalColor;
    private ColorBlock cb;
    
    
    // bool gameOver = false;
    
    //variables for shaking
    // Vector2 startingPos;
    // Vector2 shakePos;
    // float speed = 1.0f;
    // float amount = 1.0f;
    // bool isHovering = true;
    

   void start() {
       cb = button.colors;
       originalColor = cb.selectedColor;
       resumeButton.SetActive(false);
       quitButton.SetActive(false);
       startButton.SetActive(false);
       SceneManager.LoadScene("StartScreen");
   }
   
   void Update()
   {
       
   }
   
   public void changeWhenHover()
   {
       cb.selectedColor = wantedColor;
       button.colors = cb;
       // cd.selectedColor;
   }
   
   public void changeWhenLeaves()
   {
       cb.selectedColor = originalColor;
       button.colors = cb;
   }
   // public void Awake() {
   //     startingPos.x = startButton.transform.position.x;
   //     startingPos.y = startButton.transform.position.y;
   // }
   // 
   // public void Update() 
   // {
   //     if (isHovering == true) {
   //         shakePos = new Vector2( (Mathf.Sin(Time.time * speed) * amount), (Mathf.Sin(Time.time * speed) * amount));            
   //         startButton.transform.position = startingPos + shakePos;
   //         // transform.position = startingPos + Mathf.Sin(Time.time * speed) * amount;
   //         // transform.position.y = startingPos + Mathf.Sin(Time.time * speed) * amount;
   //     }
   // 
   // }
   
   // public void OnPointerEnter(PointerEventData eventData)
   // {
   //     //needs boundary or image for it to detect, need to make new script that can be applied to individual buttons, that script contains pointer enter/exit, awake/update
   //     Debug.Log("I made it to on pointer enter");
   //     isHovering = true;
   // }
   // 
   // public void OnPointerExit(PointerEventData eventData)
   // {
   //     Debug.Log("I made it to on pointer exit");
   //     isHovering = false;
   // }
   
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

 