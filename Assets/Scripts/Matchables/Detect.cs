using UnityEngine;

public class Detect : MonoBehaviour
{
    private EventManager _eventManager;

    private MatchableManager _matchableManager;

    private void OnEnable()
    {
        _eventManager = FindFirstObjectByType<EventManager>();
        _matchableManager = FindFirstObjectByType<MatchableManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
            if (collision.gameObject.CompareTag(_matchableManager.searchTag))
            {
                _eventManager.AddConnectedMatchableToList(collision.gameObject);
                Debug.Log("hit");
            }
        
    }

}
