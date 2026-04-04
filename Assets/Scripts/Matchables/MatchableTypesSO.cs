using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MatchableTypesSO", menuName = "Scriptable Objects/MatchableTypesSO")]
public class MatchableTypesSO : ScriptableObject
{
    public List<Matchable> matchableTypes = new List<Matchable>();
}
