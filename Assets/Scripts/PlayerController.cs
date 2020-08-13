using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float speed;

    private int currentLane = 1; // 0 = left lane, 1 = middle lane, 2 = right lane
    private float spaceBetweenLanes = 3.5f; // space between two lanes
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        LaneSwitching();
    }

    void PlayerMovement()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 playerMovement = new Vector3(hor, 0f, ver).normalized * speed * Time.deltaTime;
        transform.Translate(playerMovement, Space.Self);
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
}