using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{

    public static CursorManager Instance;
    public Texture2D cursorHide;
    public float MouseSensitivity = 1f;
    public Transform CursorPosition;

    private CursorMode cursorMode = CursorMode.Auto;
    private Vector2 hotSpot = Vector2.zero;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        hotSpot = new Vector2(cursorHide.width / 2, cursorHide.height / 2);
    }

    public void ResetTexture()
    {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }

    public void HideCursor() {
        Cursor.SetCursor(cursorHide, hotSpot, cursorMode);
    }
}
