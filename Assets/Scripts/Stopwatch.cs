using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stopwatch : MonoBehaviour
{
    [SerializeField]
    private GameObject stopwatch;

    [SerializeField]
    private Text trialModeDistanceText;

    [SerializeField]
    private Text trialModeDistanceCount;

    [SerializeField]
    private Text bestTrialModeDistanceText;

    [SerializeField]
    private Text bestTrialModeDistanceCount;

    [SerializeField]
    private Text trialModeTimeLimitText;

    [SerializeField]
    private Text trialModeTimeLimitCount;

    [SerializeField]
    private float distance;

    [SerializeField]
    private float timeLimit;

    [SerializeField]
    private float storedDistance;

    [SerializeField]
    private bool initialPB;

    [SerializeField]
    private bool stopwatchTimeUp = false;

    [SerializeField]
    private bool stopwatchCollided = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.paused == false)
        {
            if (stopwatchTimeUp == false && stopwatchCollided == true)
            {
                StopwatchTimeLimit();

                if (timeLimit <= 0)
                {
                    stopwatchCollided = false;
                    stopwatchTimeUp = false;
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (PauseMenu.paused == false)
        {
            if (collision.gameObject.tag == "Stopwatch" && stopwatchCollided == false)
            {
                timeLimit = 20f;
                collision.gameObject.SetActive(false);
                trialModeDistanceText.gameObject.SetActive(true);
                trialModeDistanceCount.gameObject.SetActive(true);
                trialModeTimeLimitText.gameObject.SetActive(true);
                trialModeTimeLimitCount.gameObject.SetActive(true);
                bestTrialModeDistanceText.gameObject.SetActive(false);
                bestTrialModeDistanceCount.gameObject.SetActive(false);
                stopwatchCollided = true;
            }
        }   
    }

    public void StopwatchTimeLimit()
    {
        if (timeLimit > 0)
        {
            timeLimit -= Time.deltaTime;
            UpdateTimeLimitUI();
            Debug.Log(timeLimit);
        }

        if (Input.GetKey(KeyCode.UpArrow) && timeLimit > 0)
        {
            distance += Time.deltaTime;
            UpdateDistanceUI();
        }

        if (timeLimit <= 0)
        {
            if (distance > storedDistance)
            {
                bestTrialModeDistanceCount.text = distance.ToString();
                Debug.Log("Distance is less than previous distance");
                storedDistance = distance;
            } 
            if (initialPB == false)
            {
                bestTrialModeDistanceCount.text = storedDistance.ToString();
            }
            initialPB = true;
            distance = 0;

            stopwatchTimeUp = true;

            trialModeDistanceText.gameObject.SetActive(false);
            trialModeDistanceCount.gameObject.SetActive(false);
            trialModeTimeLimitText.gameObject.SetActive(false);
            trialModeTimeLimitCount.gameObject.SetActive(false);
            bestTrialModeDistanceText.gameObject.SetActive(true);
            bestTrialModeDistanceCount.gameObject.SetActive(true);
        }
    }

    public void UpdateTimeLimitUI()
    {
        if (trialModeTimeLimitCount != null)
        {
            trialModeTimeLimitCount.text = timeLimit.ToString();
        }
    }

    public void UpdateDistanceUI()
    {
        if (trialModeDistanceCount != null)
        {
            trialModeDistanceCount.text = distance.ToString();
        }
    }
}