using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSetter : MonoBehaviour
{
    public int songNmb;
    public Menu menu;
   
    void start(){
        menu = new Menu();
    }

    public void setLvl()
    {
     Menu.instance.setLevel(songNmb);
    }
}
