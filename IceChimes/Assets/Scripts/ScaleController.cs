using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleController : MonoBehaviour
{
    public float newScale;
    void Update()
    {
        if (Screen.width < Screen.height)
        {
            this.transform.localScale = new Vector3(newScale, newScale, newScale);
        }

        else if (Screen.width > Screen.height)
        {
        
            this.transform.localScale = new Vector3(1, 1, 1);

        }

    }
}
