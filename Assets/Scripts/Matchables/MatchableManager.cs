using NUnit.Framework;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MatchableManager : MonoBehaviour
{
    private EventManager _eventManager;

    [SerializeField] private MatchableTypesSO matchableTypesSO;

    [SerializeField] private List<GameObject> connectedMatchables = new List<GameObject>();

    public string searchTag;

    private void OnEnable()
    {
        _eventManager = FindFirstObjectByType<EventManager>();

        _eventManager.onSetMatchableSize += SetMatchableSize;
        _eventManager.onCreateRandomizedMatchable += RandomizeMatchable;
        _eventManager.onRemoveMatchable += RemoveMatchables;
        _eventManager.onAddConnectedMatchableToList += AddConnectedMatchableToList;
    }
    private void OnDisable()
    {
        _eventManager.onSetMatchableSize -= SetMatchableSize;
        _eventManager.onCreateRandomizedMatchable -= RandomizeMatchable;
        _eventManager.onRemoveMatchable -= RemoveMatchables;
        _eventManager.onAddConnectedMatchableToList -= AddConnectedMatchableToList;
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
        connectedMatchables.Add(matchableObject);
        CheckAdjacentMatchables();
        
    }

    private void CheckAdjacentMatchables()
    {
        searchTag = connectedMatchables[0].tag;
        connectedMatchables[0].GetComponent<MatchableDetector>().DetectAdjacentMatchables();
        StartCoroutine(CheckAgain());

        
    }

    private void AddConnectedMatchableToList(GameObject matchable)
    {
        if (!connectedMatchables.Contains(matchable))
        {
            connectedMatchables.Add(matchable);
        }
        
    }

    private IEnumerator CheckAgain()
    {
        yield return new WaitForSeconds(0.15f);
        for (int i = 0; i < connectedMatchables.Count; i++)
        {
            connectedMatchables[i].GetComponent<MatchableDetector>().DetectAdjacentMatchables();
        }
    }
}
