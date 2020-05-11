using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionController : MonoBehaviour
{
    public float widthTimes16, heightTimes16;
    public float widthTimes9, heightTimes9;

    void Update()
    {
        if (Screen.width > Screen.height)
        {
            this.transform.position = new Vector2(Screen.width * widthTimes16, Screen.height * heightTimes16);
        }

       else if (Screen.width < Screen.height)
        {
            this.transform.position = new Vector2(Screen.width * widthTimes9, Screen.height * heightTimes9);

        }

    }
}
