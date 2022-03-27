using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private void Update()
    {
        bool x = Input.GetMouseButtonUp(0);
        if ( x && MainController.Inst.GetClickSelect)
        {
            MovingPoints.Inst.SetInChildren();
        }

        if (x && !MainController.Inst.GetClickSelect)
        {
            MovingPoints.Inst.ReturnOnStartPoint();
        }
    }
}
