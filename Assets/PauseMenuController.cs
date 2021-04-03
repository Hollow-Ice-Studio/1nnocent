using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace innocent {
    public class PauseMenuController : MonoBehaviour
    {
        [SerializeField] GameObject PauseHud, ConfirmRestartHud, ConfirmReturnMainScreenHud;
        [SerializeField] KeyCode Key = KeyCode.P;
        [SerializeField] string MainMenuSceneName = "MainScreen";
        [SerializeField] AudioSource interactionAudioSource;
        void Update()
        {
            if (Input.GetKeyDown(Key))
            {
                if (Time.timeScale > 0)
                    Pause();
                else
                    UnPause();
                ConfirmRestartHud.SetActive(false);
            }
        }

        public void Pause()
        {
            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            PauseHud.SetActive(true);
        }
        public void UnPause()
        {
            Time.timeScale = 1;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            PauseHud.SetActive(false);
        }
        public void tryRestartScene()
        {
            ConfirmRestartHud.SetActive(true);
        }
        public void cancelRestartScene()
        {
            ConfirmRestartHud.SetActive(false);
        }
        public void tryReturnMainScreenScene()
        {
            ConfirmReturnMainScreenHud.SetActive(true);
        }
        public void cancelMainScreenScene()
        {
            ConfirmReturnMainScreenHud.SetActive(false);
        }
        public void restartScene()
        {
            UnPause();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        public void returnToMainMenu()
        {
            UnPause();
            SceneManager.LoadScene(MainMenuSceneName);
        }
        public void PlayInteractionSound()
        {
            interactionAudioSource.Play();
        }
    }
}