using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour {

    public bool active;

    private Vector3 mOffset;
    private float mZCoord;
    private float Y;

    void Start()
    {
        active = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            StartDrag();
        else if (active)
            Reposition();
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private void CenterCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.lockState = CursorLockMode.None;
    }

    private void StartDrag()
    {
        CenterCursor();
        active = !active;

        //Vector3 newPosition = GetMouseWorldPos();
        //newPosition.y = transform.position.y;
        //transform.position = newPosition;

        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMouseWorldPos();
    }

    private void Reposition()
    {
        Vector3 newPosition = GetMouseWorldPos() + mOffset;
        newPosition.y = transform.position.y;
        transform.position = newPosition;
    }

    void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMouseWorldPos();
    }

    void OnMouseDrag()
    {
        Y = transform.position.y;
        Vector3 newPosition = GetMouseWorldPos() + mOffset;
        newPosition.y = Y;
        transform.position = newPosition;
    }
}
