using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{

    public Texture2D cursorTexture;

    private CursorMode cursorMode = CursorMode.Auto;
    private Vector2 hotSpot = Vector2.zero;
    private bool isChanged;

    void Start()
    {
        hotSpot = new Vector2(cursorTexture.width / 2, cursorTexture.height / 2);
        isChanged = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isChanged) ResetTexture();
            else SetTexture();
        }
    }

    public void SetTexture()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        isChanged = true;
    }

    public void ResetTexture()
    {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
        isChanged = false;
    }
}
