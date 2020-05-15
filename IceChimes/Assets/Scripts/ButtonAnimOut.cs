using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAnimOut : MonoBehaviour
{
    [SerializeField] Animator animator;
    public  Button button;
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
            animator.SetBool("out", true);
            animator.SetBool("show", false);

            remove = false;
        }
       

    }
}