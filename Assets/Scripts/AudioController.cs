using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource bikeTreadSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.paused == false && RestartButton.playerDied == false)
        {

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                bikeTreadSound.Play();
            }

            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                bikeTreadSound.Stop();
            }
        }
    }
}
