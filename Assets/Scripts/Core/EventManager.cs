using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    //--Matchables--
    //Create Randomized Matchable
    public event Action<SpriteRenderer, Vector3> onCreateRandomizedMatchable;
    public void CreateRandomizedMatchable(SpriteRenderer matchableSprite, Vector3 worldPosition) => onCreateRandomizedMatchable?.Invoke(matchableSprite, worldPosition);
    //Set Matchable Size
    public event Action<GameObject, float> onSetMatchableSize;
    public void SetMatchableSize(GameObject matchableSprite, float gridSize) => onSetMatchableSize?.Invoke(matchableSprite, gridSize);
}
