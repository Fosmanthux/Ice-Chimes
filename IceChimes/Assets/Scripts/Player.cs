using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
<<<<<<< HEAD
    //public int finalScore = 0;

=======
>>>>>>> 1b81b433b531ac5ad21e862ad9ff51eb16d7c37b
    public float Xincrement;
    public float speed;
    public float leftBoarder;
    public float rightBoarder;
    
    public float jumpHight;

    private bool isGrounded = true;

    private Vector3 pos;
    private Rigidbody rgbd;

    void Start()
    {
        rgbd = GetComponent<Rigidbody>();
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, pos, speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.x > leftBoarder)
        {
            pos = new Vector3(transform.position.x - Xincrement, transform.position.y, transform.position.z);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && transform.position.x < rightBoarder)
        {
            pos = new Vector3(transform.position.x + Xincrement, transform.position.y, transform.position.z);
        }
        else if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Debug.Log(Input.inputString);
            rgbd.velocity += new Vector3(0, jumpHight, 0);
        }    
    }

<<<<<<< HEAD
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
=======
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
    
    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = false;
>>>>>>> 1b81b433b531ac5ad21e862ad9ff51eb16d7c37b
        }
    }
}
