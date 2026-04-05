using System.Collections;
using UnityEngine;

public class MatchableDetector : MonoBehaviour
{
    private EventManager _eventManager;

    [SerializeField] private GameObject leftDetector;
    [SerializeField] private GameObject rightDetector;
    [SerializeField] private GameObject upDetector;
    [SerializeField] private GameObject downDetector;

    private void Start()
    {
        _eventManager = FindFirstObjectByType<EventManager>();
    }

    public void DetectAdjacentMatchables()
    {
        leftDetector.SetActive(true);
        rightDetector.SetActive(true);
        upDetector.SetActive(true);
        downDetector.SetActive(true);
    }
}
