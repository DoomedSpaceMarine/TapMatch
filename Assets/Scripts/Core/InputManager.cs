using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    [Header("Input Action Asset")]
    [SerializeField] private InputActionAsset inputActions;

    private InputAction tapAction;

    public bool TapActionTriggered { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        SetupInputActions();
    }

    private void SetupInputActions()
    {
        var playerMap = inputActions.FindActionMap("Player");

        tapAction = playerMap.FindAction("TapMatchable");

        tapAction.Enable();
    }

    private void Update()
    {
        TapActionTriggered = tapAction.WasPerformedThisFrame();
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }
    private void OnDisable()
    {
        tapAction?.Disable();
    }
}
