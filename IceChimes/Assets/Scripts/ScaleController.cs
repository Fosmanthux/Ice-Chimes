using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScaleController : MonoBehaviour
{
    //public float newScale;
    public GameObject other;
    void Update()
    {
            /*  if (Screen.width > Screen.height)
              {
                  this.transform.localScale = new Vector3(newScale, newScale, newScale);
              }

              else if (Screen.width < Screen.height)
              {

                  this.transform.localScale = new Vector3(1, 1, 1);

              }*/
            if (Menu.isfox)
        {   this.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
            other.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
        }
        else
        {
            other.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
            this.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
        }
    }
}
