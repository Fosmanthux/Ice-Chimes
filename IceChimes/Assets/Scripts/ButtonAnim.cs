using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAnim : MonoBehaviour
{

    [SerializeField] Animator animator;
    public Button button;
    private bool show = false;

    void Start()
    {
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(setPressed);
    }

    void setPressed()
    {
        show = true;

        Debug.Log("show");
       
    }

    void Update()
    {

        if (show)
        {
            animator.SetBool("show", true);
            Debug.Log("show2");
            animator.SetBool("out", false);
            show = false;
        }
    }
}
