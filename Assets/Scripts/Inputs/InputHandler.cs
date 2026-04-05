using Unity.VisualScripting;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private InitGrid _initGrid;
    private EventManager _eventManager;

    private bool canTap = true;

    private void OnEnable()
    {
        _eventManager = FindFirstObjectByType<EventManager>();
        _initGrid = FindFirstObjectByType<InitGrid>();

        _eventManager.onCanPlayerTap += CanPlayerTap;
    }

    private void OnDisable()
    {
        _eventManager.onCanPlayerTap -= CanPlayerTap;
    }

    void Update()
    {
        if (canTap && InputManager.Instance.TapActionTriggered)
        {
            CanPlayerTap(false);
           _eventManager.RemoveMatchable(_initGrid.grid.GetMatchableFromGrid(GetMouseWorldPosition()));
        }
    }

    private void CanPlayerTap(bool enabled)
    {
        canTap = enabled;
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
