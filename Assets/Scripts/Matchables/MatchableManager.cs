using UnityEngine;

public class MatchableManager : MonoBehaviour
{
    private EventManager _eventManager;

    private void OnEnable()
    {
        _eventManager = FindFirstObjectByType<EventManager>();

        _eventManager.onSetMatchableSize += SetMatchableSize;
    }
    private void OnDisable()
    {
        _eventManager.onSetMatchableSize -= SetMatchableSize;
    }
    private void SetMatchableSize(GameObject matchableSprite, float gridSize)
    {
        matchableSprite.transform.localScale = new Vector2(gridSize, gridSize);
    }
}
