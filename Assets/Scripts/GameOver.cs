using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private Text gameOverText;

    [SerializeField]
    private Button restartButton;

    [SerializeField]
    private Button mainMenuButton;

    // Start is called before the first frame update
    void Start()
    {
        gameOverText = GameObject.Find("GameOver").GetComponent<Text>();
        restartButton = GameObject.Find("RestartButton").GetComponent<Button>();
        mainMenuButton = GameObject.Find("QuitButton").GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            gameObject.SetActive(false);
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            mainMenuButton.gameObject.SetActive(true);
        }
    }
}
