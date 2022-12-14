using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameHandler : MonoBehaviour {

        public static int playerStat;


        public static bool GameisPaused = false;
        public GameObject pauseMenuUI;
        public AudioMixer mixer;
        public static float volumeLevel = 1.0f;
        private Slider sliderVolumeCtrl;

        void Awake (){
                SetLevel (volumeLevel);
                GameObject sliderTemp = GameObject.FindWithTag("PauseMenuSlider");
                if (sliderTemp != null){
                        sliderVolumeCtrl = sliderTemp.GetComponent<Slider>();
                        sliderVolumeCtrl.value = volumeLevel;
                }
        }

        void Start (){
                pauseMenuUI.SetActive(false);
                GameisPaused = false;
        }

        void Update (){
                if (Input.GetKeyDown(KeyCode.Escape)){
                        if (GameisPaused){
                                Resume();
                        }
                        else{
                                Pause();
                        }
                }
        }

        void Pause(){
                pauseMenuUI.SetActive(true);
                Time.timeScale = 0f;
                GameisPaused = true;
        }

        public void Resume(){
                pauseMenuUI.SetActive(false);
                Time.timeScale = 1f;
                GameisPaused = false;
        }

        public void SetLevel (float sliderValue){
                mixer.SetFloat("MusicVolume", Mathf.Log10 (sliderValue) * 20);
                volumeLevel = sliderValue;
        }
        
        public void RestartGame(){
            Time.timeScale = 1f;
            // Add commands to zero-out any scores or other stats before restarting
            Scene scene = SceneManager.GetActiveScene(); 
            SceneManager.LoadScene(scene.name);
            // SceneManager.LoadScene("StartScreen");
        }

        public void Credits(){
            Time.timeScale = 1f;
            SceneManager.LoadScene("Credits");
        }

        public void QuitGame(){
              #if UNITY_EDITOR
              UnityEditor.EditorApplication.isPlaying = false;
              #else
              Application.Quit();
              #endif
          }
    }