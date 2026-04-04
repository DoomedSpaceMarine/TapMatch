using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    //--Matchables--
    //Create Randomized Matchable
    public event Action<SpriteRenderer> onCreateRandomizedMatchable;
    public void CreateRandomizedMatchable(SpriteRenderer matchableSprite) => onCreateRandomizedMatchable?.Invoke(matchableSprite);
    //Set Matchable Size
    public event Action<GameObject, float> onSetMatchableSize;
    public void SetMatchableSize(GameObject matchableSprite, float gridSize) => onSetMatchableSize?.Invoke(matchableSprite, gridSize);
}
