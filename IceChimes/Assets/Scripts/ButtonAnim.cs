using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonAnim : MonoBehaviour
{

    [SerializeField] Animator animator;
    public Button button;
    public int btnNmb;
    private bool show = false;
   
    void Start()
    {
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(setPressed);
    }

    void setPressed()
    {
        show = true;       
    }



    void Update()
    {
        if (show)
        {

            if (btnNmb == 0)
            {
                animator.SetBool("settingIn", true);
                animator.SetBool("settingOut", false);
            }
            else if (btnNmb == 1)
            {
                animator.SetBool("charIn", true);
                animator.SetBool("charOut", false);
            }

            else if (btnNmb == 2)
            {
                animator.SetBool("playIn", true);
                animator.SetBool("playOut", false);
            }

            else if (btnNmb == 3)
            {
                animator.SetBool("shopIn", true);
                animator.SetBool("shopOut", false);
            }
            else if (btnNmb == 4)
            {
                animator.SetBool("stageIn", true);
                animator.SetBool("stageOut", false);
            }

            else if (btnNmb == 5)
            {
                animator.SetBool("randomIn", true);
                animator.SetBool("randomOut", false);
            }

            else if (btnNmb == 6)
            {
                animator.SetBool("infIn", true);
                animator.SetBool("infOut", false);
            }
            else if (btnNmb == 7)
            {
                animator.SetBool("scale", true);
                animator.SetBool("unscale", false);
            }

            show = false;
        }
    }
}
