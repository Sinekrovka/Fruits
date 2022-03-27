using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    public static MainController Inst;
   

    private bool clickSelectTrue;

    private void Awake()
    {
        Inst = this;
    }

    public void SetClickSelect(bool x)
    {
        clickSelectTrue = x;
    }

    public bool GetClickSelect => clickSelectTrue;
}
