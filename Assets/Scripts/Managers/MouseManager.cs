using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MouseManager : MonoBehaviour
{
    // SingleTon
    public static MouseManager Instance;
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
