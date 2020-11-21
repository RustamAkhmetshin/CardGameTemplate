using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDropComponent : MonoBehaviour
{
    private float _zAxis;
    private Vector3 _clickOffset;
    private Vector3 _oldPosition;

    private void Start()
    {
        _zAxis = 0;
        _clickOffset = Vector3.zero;
    }

    public void OnMouseDown()
    {
        _oldPosition = transform.position;
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _clickOffset = transform.position - (new Vector3(mousePosition.x, mousePosition.y, _zAxis));
    }

    public void OnMouseUp()
    {
        transform.position = _oldPosition;
    }

    void OnMouseDrag()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 tempVec = new Vector3((mousePosition.x + _clickOffset.x), (mousePosition.y + _clickOffset.y), _zAxis);
        transform.position = tempVec;
    }
}
