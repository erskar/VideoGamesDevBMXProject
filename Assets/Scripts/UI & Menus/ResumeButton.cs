using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResumeButton : MonoBehaviour
{
    [SerializeField]
    private Button mainMenuButton;

    [SerializeField]
    private Button resumeButton;

    [SerializeField]
    private Text pauseMenuText;

    public void Resume()
    {
        PauseMenu.paused = false;
        mainMenuButton.gameObject.SetActive(false);
        resumeButton.gameObject.SetActive(false);
        pauseMenuText.gameObject.SetActive(false);
    }
}
