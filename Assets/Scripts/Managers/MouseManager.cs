using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MouseManager : MonoBehaviour
{
    // SingleTon
    public static MouseManager Instance;

    // cursors
    public Texture2D point, doorway, attack, target, arrow;

    // Hit info for raycast
    RaycastHit hitInfo;
    // Create an event action
    public event Action<Vector3> OnMouseClicked;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    void Update()
    {
        SetCursorTexure();
        MouseControl();
    }

    /// <summary>
    /// set cursor texture
    /// </summary>
    void SetCursorTexure()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hitInfo))
        {
            // TODO: change mouse texure
            switch (hitInfo.collider.gameObject.tag)
            {
                case "Ground":
                    Cursor.SetCursor(target, new Vector2(16, 16), CursorMode.Auto);
                    break;
                case "Enemy":
                    Cursor.SetCursor(attack, new Vector2(16, 16), CursorMode.Auto);
                    break;
                default:
                    break;
            }
        }
    }

    /// <summary>
    /// Control the mouse event and then action in unison.
    /// </summary>
    void MouseControl()
    {
        if (Input.GetMouseButtonDown(0) && hitInfo.collider != null)
        {
            // When click the Ground, invoke the mouse and get the Vector3 position.
            if (hitInfo.collider.gameObject.CompareTag("Ground"))
            {
                OnMouseClicked?.Invoke(hitInfo.point);
            }
        }
    }
}
