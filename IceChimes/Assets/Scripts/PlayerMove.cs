using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
   public float Xincrement;
    public float speed;
    public float leftBoarder;
    public float rightBoarder;
    
    public float jumpHight;

    private bool isGrounded = true;

    private Vector3 pos;
    private Rigidbody rgbd;

    public GameObject bear, fox;

    void Start()
    {
        rgbd = GetComponent<Rigidbody>();
    }

    void Update()
    {

        if (Menu.isfox){
            fox.SetActive(true);
            bear.SetActive(false);
        }

        else if (Menu.isbear){
            bear.SetActive(true);
            fox.SetActive(false);
        }

        transform.position = Vector3.MoveTowards(transform.position, pos, speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.x > leftBoarder && transform.position.y ==0 || transform.position.x > leftBoarder && MobileInput.Instance.SwipeLeft && transform.position.y == 0) // bug when going right or left while being in a jump
        {
            pos = new Vector3(transform.position.x - Xincrement, transform.position.y, transform.position.z);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && transform.position.x < rightBoarder && transform.position.y == 0 || transform.position.x < rightBoarder && MobileInput.Instance.SwipeRight && transform.position.y == 0)
        {
            pos = new Vector3(transform.position.x + Xincrement, transform.position.y, transform.position.z);
        }
        else if (Input.GetKeyDown(KeyCode.Space) && isGrounded || isGrounded && MobileInput.Instance.SwipeUp)
        {

            rgbd.velocity += new Vector3(0, jumpHight, 0);
        }  
    }


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
        }
    }



}
