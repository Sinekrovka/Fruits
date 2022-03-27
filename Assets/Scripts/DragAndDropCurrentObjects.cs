using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDropCurrentObjects : MonoBehaviour
{
    private void OnMouseDrag()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        transform.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag(transform.tag))
        {
            MainController.Inst.SetClickSelect(true);
            MovingPoints.Inst.SetSelect(transform, other.transform);
        }
        else
        {
            MainController.Inst.SetClickSelect(false);
            MovingPoints.Inst.SetSelect(null, null);
        }
    }
}
