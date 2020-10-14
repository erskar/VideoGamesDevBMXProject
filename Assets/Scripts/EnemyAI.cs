using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.paused == false && RestartButton.playerDied == false)
        {
            speed += Time.deltaTime;

            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            if (speed == 4)
            {
                speed = 4;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            speed += 4;
        }
    }
}
