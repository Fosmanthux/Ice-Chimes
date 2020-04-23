using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //public int finalScore = 0;

    public float Xincrement;
    public float speed;
    public float leftBoarder;
    public float rightBoarder;
    
    public float jumpHight = 2f;

    private bool isGrounded;

    private Vector3 pos;

    void Start()
    {

    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, pos, speed * Time.deltaTime);

        if (transform.position.y == 0)
            {
                isGrounded = true;
            }
            else isGrounded = false;

        if (Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.x > leftBoarder)
        {
            pos = new Vector3(transform.position.x - Xincrement, transform.position.y, transform.position.z);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && transform.position.x < rightBoarder)
        {
            pos = new Vector3(transform.position.x + Xincrement, transform.position.y, transform.position.z);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < jumpHight)
        {
            pos = new Vector3(transform.position.x, transform.position.y + jumpHight, transform.position.z);
        }    
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
        }
    }
}
