using System.Collections.Generic;
using UnityEngine;

public class MatchableManager : MonoBehaviour
{
    //Core Managers
    private EventManager _eventManager;

    //List of different types of matchables
    [SerializeField] private List<Matchable> matchables = new List<Matchable>();

    private void OnEnable()
    {
        _eventManager = FindFirstObjectByType<EventManager>();
        _eventManager.onCreateRandomizedMatchable += CreateRandomizedMatchable;
        _eventManager.onSetMatchableSize += SetMatchableSize;
    }

    private void OnDisable()
    {
        _eventManager.onCreateRandomizedMatchable -= CreateRandomizedMatchable;
        _eventManager.onSetMatchableSize -= SetMatchableSize;
    }

    private void CreateRandomizedMatchable(SpriteRenderer matchableSprite)
    {
        int randomizedMatchable = Random.Range(0, matchables.Count);
        matchableSprite.color = matchables[randomizedMatchable].matchableColor;
    }

    private void SetMatchableSize(GameObject matchable, float gridSize)
    {
        matchable.transform.localScale = new Vector2(gridSize, gridSize);
    }
}
