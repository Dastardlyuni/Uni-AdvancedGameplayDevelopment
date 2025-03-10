using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    public bool gameIsPaused;
    public CharacterController controller;
    public GameObject PauseScreenUI;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Paused Pressed");
            gameIsPaused = !gameIsPaused;
            PauseGame();       
        }

    }
    public void PauseGame()
    {
        if (gameIsPaused == true)
        {
            Debug.Log("Paused");
            PauseScreenUI.SetActive(true);
            controller.enabled = false;
            Time.timeScale = 0;
            Camera.main.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Unpaused");
            PauseScreenUI.SetActive(false);
            controller.enabled = true;
            Time.timeScale = 1;
            Camera.main.gameObject.SetActive(false);
        }
    }

    public void QuitGame()
    {
        SceneManager.LoadScene(0);
    }
}
