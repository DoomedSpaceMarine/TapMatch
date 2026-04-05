using Unity.VisualScripting;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private InitGrid _initGrid;
    [SerializeField] private EventManager _eventManager;

    void Update()
    {
        if (InputManager.Instance.TapActionTriggered)
        {
           _eventManager.RemoveMatchable(_initGrid.grid.GetMatchableFromGrid(GetMouseWorldPosition()));
        }
    }

    //Get Mouse Position in World with Z = 0f
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
