using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAnimOut : MonoBehaviour
{
    [SerializeField] Animator animator;
    public  Button button;
    public int btnNmb;
    private bool remove;

    void Start()
    {
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(setPressed);
    }

    void setPressed()
    {
            remove = true;
    }

    void Update()
    {
        if (remove)
        {
            if (btnNmb == 0)
            {
                animator.SetBool("settingOut", true);
                animator.SetBool("settingIn", false);
            }

            else if (btnNmb == 1){
                animator.SetBool("playOut", true);
                animator.SetBool("shopOut", true);
                animator.SetBool("playIn", false);
                animator.SetBool("shopIn", false);
            }
            else if (btnNmb == 2)
            {
                animator.SetBool("charOut", true);
                animator.SetBool("shopOut", true);
                animator.SetBool("charIn", false);
                animator.SetBool("shopIn", false);
            }
            else if (btnNmb == 3)
            {
                animator.SetBool("charOut", true);
                animator.SetBool("playOut", true);
                animator.SetBool("charIn", false);
                animator.SetBool("playIn", false);
            }
            else if (btnNmb == 4)
            {
                animator.SetBool("stageOut", true);
                animator.SetBool("stageIn", false);
            }
            else if (btnNmb == 5)
            {
                animator.SetBool("randomOut", true);
                animator.SetBool("randomIn", false);
            }
            else if (btnNmb == 6)
            {
                animator.SetBool("infOut", true);
                animator.SetBool("infIn", false);
            }
            else if (btnNmb == 7)
            {
                animator.SetBool("unscale", true);
                animator.SetBool("scale", false);
            }
            remove = false;
        }
       

    }
}