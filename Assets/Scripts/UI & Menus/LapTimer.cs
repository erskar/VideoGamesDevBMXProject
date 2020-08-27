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

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer++;
        UpdateTimerUI();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Finish")
        {
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