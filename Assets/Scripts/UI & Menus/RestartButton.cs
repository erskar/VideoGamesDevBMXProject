using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public static bool playerDied;

    public void Restart()
    {
        SceneManager.LoadScene("MainScene");
        playerDied = true;
    }
}