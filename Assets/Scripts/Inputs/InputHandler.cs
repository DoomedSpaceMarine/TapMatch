using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private GridInitializer _gridInitializer;
    void Update()
    {
        if (InputManager.Instance.TapActionTriggered)
        {
            _gridInitializer.grid.grid.GetGridObject(GetMouseWorldPosition());
         
        }
    }

    public static Vector3 GetMouseWorldPosition()
    {
        Vector3 vec = GetMousePositionWithZ(Input.mousePosition, Camera.main);
        vec.z = 0f;
        return vec;
    }

    public static Vector3 GetMousePositionWithZ(Vector3 screenPosition, Camera worldCamera)
    {
        Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
        return worldPosition;
    }
}
