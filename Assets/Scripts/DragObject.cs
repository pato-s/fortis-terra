using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{


    private float positionZCoord;
    private float MouseDragY;
    private float tempMouseX = 0f;
    private float tempMouseY = 0f;
    private float positionX = 0f;
    private float positionZ = 0f;
    private Grid grid;
    private bool isBuilding;
    private GameObject Part;

    void Awake()
    {
        isBuilding = false;
    }
    void Start()
    {
        grid = FindObjectOfType<Grid>();
        positionX = transform.position.x;
        positionZ = transform.position.z;
        tempMouseX = transform.position.x;
        tempMouseY = transform.position.z;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isBuilding) EndDrag();
            else StartDrag();
        }
        else if (isBuilding)
            Reposition();
    }

    private Vector3 GetNewPosition()
    {
        if (tempMouseX != Input.GetAxis("Mouse X"))
            tempMouseX = positionX + (Input.GetAxis("Mouse X") * CursorManager.Instance.MouseSensitivity * 0.1f);
        if (positionX != tempMouseX) positionX = tempMouseX;

        if (tempMouseY != Input.GetAxis("Mouse Y"))
            tempMouseY = positionZ + (Input.GetAxis("Mouse Y") * CursorManager.Instance.MouseSensitivity * 0.1f);
        if (positionZ != tempMouseY) positionZ = tempMouseY;

        Vector3 mousePoint = new Vector3(positionX, 0f, positionZ);
        return mousePoint;
    }

    private void StartDrag()
    {
        Part = PartsManager.Instance.GetPart();
        isBuilding = !isBuilding;
    }

    private void EndDrag()
    {
        Destroy(Part.gameObject);
        PartsManager.Instance.GetPartHolo().transform.SetParent(null);
        
        Part = PartsManager.Instance.GetPart();
    }

    private void Reposition()
    {
        Vector3 newPosition = GetNewPosition();
        newPosition = grid.GetNearestPointOnGrid(newPosition);
        newPosition.y = transform.position.y;
        transform.position = newPosition;
    }
}
