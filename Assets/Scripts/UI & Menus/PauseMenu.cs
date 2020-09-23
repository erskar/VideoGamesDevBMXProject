using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private Button mainMenuButton;

    [SerializeField]
    private Button resumeButton;

    [SerializeField]
    private Text pauseMenuText;

    public static bool paused = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = true;
            mainMenuButton.gameObject.SetActive(true);
            resumeButton.gameObject.SetActive(true);
            pauseMenuText.gameObject.SetActive(true);
        }
    }
}
