using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapTimer : MonoBehaviour
{
    [SerializeField]
    private float timer = 0;

    [SerializeField]
    private Text timerText;

    [SerializeField]
    private Text personalBestText;

    [SerializeField] 
    private float storedTime;

    [SerializeField]
    private bool initialPB;

    GameObject player;

    PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        initialPB = false;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (PauseMenu.paused == false && RestartButton.playerDied == false)
        {
            timer += Time.deltaTime;
            UpdateTimerUI();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Finish")
        {
            if (timer < storedTime)
            {
                personalBestText.text = timer.ToString();
                Debug.Log("Time is less than previous time");
            }
            storedTime = timer;
            if (initialPB == false)
            {
                personalBestText.text = storedTime.ToString();
            }
            initialPB = true;
            timer = 0;
        }
    }

    public void UpdateTimerUI()
    {
        if (timerText != null)
        {
            timerText.text = timer.ToString();
        }
    }
}