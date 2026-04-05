using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    //--MATCHABLES--
    //Create Randomized Matchable
    public event Action<GameObject> onCreateRandomizedMatchable;
    public void CreateRandomizedMatchable(GameObject matchableObject) => onCreateRandomizedMatchable?.Invoke(matchableObject);
    //Set Matchable Size
    public event Action<GameObject, float> onSetMatchableSize;
    public void SetMatchableSize(GameObject matchableObject, float gridSize) => onSetMatchableSize?.Invoke(matchableObject, gridSize);
    //Remove Matchable
    public event Action<GameObject> onRemoveMatchable;
    public void RemoveMatchable(GameObject matchableObject) => onRemoveMatchable?.Invoke(matchableObject);
    //Add Connected Matchable to List
    public event Action<GameObject> onAddConnectedMatchableToList;
    public void AddConnectedMatchableToList(GameObject matchableObject) => onAddConnectedMatchableToList?.Invoke(matchableObject);
    //Set Matchable Search Tag
    public event Action<string> onSetMatchableSearchTag;
    public void SetMatchableSearchTag(string searchTag) => onSetMatchableSearchTag?.Invoke(searchTag);

    //--INPUT HANDLER--
    //Can player tap
    public event Action<bool> onCanPlayerTap;
    public void CanPlayerTap(bool enabled) => onCanPlayerTap?.Invoke(enabled);
}
