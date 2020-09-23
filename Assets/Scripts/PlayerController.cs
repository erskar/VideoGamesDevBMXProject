using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float speed;

    [SerializeField]
    private Text countdownText;

    private int currentLane = 1; // 0 = left lane, 1 = middle lane, 2 = right lane
    private float spaceBetweenLanes = 3.5f; // space between two lanes
    
    // Start is called before the first frame update
    void Start()
    {
        RestartButton.playerDied = true;

        if (RestartButton.playerDied == true)
        {
            StartCoroutine(CountdownWait());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.paused == false && RestartButton.playerDied == false)
        {
            PlayerMovement();
            LaneSwitching();
        } 
    }

    void PlayerMovement()
    {
            float hor = Input.GetAxis("Horizontal");
            float ver = Input.GetAxis("Vertical");
            Vector3 playerMovement = new Vector3(hor, 0f, ver).normalized * speed * Time.deltaTime;
            transform.Translate(playerMovement, Space.Self);

            if (Input.GetKey(KeyCode.UpArrow))
            {
                speed += Time.deltaTime * 10;
                
                if (speed >= 45)
                {
                    speed = 45;
                }
            }
            else
            {
                if (speed > 0)
                {
                    speed -= Time.deltaTime * 20;
                }
            }
    }

    void LaneSwitching()
    {
        // gets the key inputs for which lane the player should be in

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                currentLane++;
                if (currentLane == 3)
                {
                    currentLane = 2;
                }
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                currentLane--;
                if (currentLane == -1)
                {
                    currentLane = 0;
                }
            }

            // calculate where the player should be 

            Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

            if (currentLane == 0)
            {
                targetPosition += Vector3.left * spaceBetweenLanes;
            }
            else

            if (currentLane == 2)
            {
                targetPosition += Vector3.right * spaceBetweenLanes;
            }

            transform.position = Vector3.Lerp(transform.position, targetPosition, 10 * Time.deltaTime);
    }

    public IEnumerator CountdownWait()
    {
        if (PauseMenu.paused == false)
        {
            countdownText.text = 3.ToString();
            yield return new WaitForSeconds(1);
            countdownText.text = 2.ToString();
            yield return new WaitForSeconds(1);
            countdownText.text = 1.ToString();
            yield return new WaitForSeconds(1);
            countdownText.text = "Go!".ToString();
            yield return new WaitForSeconds(1);
            countdownText.gameObject.SetActive(false);
            RestartButton.playerDied = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            speed -= 15;
        }
    }
}