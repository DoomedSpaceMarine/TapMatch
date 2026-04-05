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

    //--INPUT HANDLER--
    //Can player tap
    public event Action<bool> onCanPlayerTap;
    public void CanPlayerTap(bool enabled) => onCanPlayerTap?.Invoke(enabled);
}
