using UnityEngine;

public class MatchableManager : MonoBehaviour
{
    private EventManager _eventManager;

    [SerializeField] private MatchableTypesSO matchableTypesSO;

    private void OnEnable()
    {
        _eventManager = FindFirstObjectByType<EventManager>();

        _eventManager.onSetMatchableSize += SetMatchableSize;
        _eventManager.onCreateRandomizedMatchable += RandomizeMatchable;
        _eventManager.onRemoveMatchable += RemoveMatchables;
    }
    private void OnDisable()
    {
        _eventManager.onSetMatchableSize -= SetMatchableSize;
        _eventManager.onCreateRandomizedMatchable -= RandomizeMatchable;
        _eventManager.onRemoveMatchable -= RemoveMatchables;
    }
    private void SetMatchableSize(GameObject matchableSprite, float gridSize)
    {
        matchableSprite.transform.localScale = new Vector2(gridSize, gridSize);
    }

    private void RandomizeMatchable(GameObject matchableObject)
    {
        int randomType = Random.Range(0, matchableTypesSO.matchableTypes.Count);
        matchableObject.GetComponent<SpriteRenderer>().color = matchableTypesSO.matchableTypes[randomType].matchableColor;
        matchableObject.gameObject.tag = matchableTypesSO.matchableTypes[randomType].matchableName;
    }

    private void RemoveMatchables(GameObject matchableObject)
    {
        Destroy(matchableObject);
    }
}
