using UnityEngine;

public class ControllerBase : MonoBehaviour
{
    public PlayerInputManager playerInputManager { get; private set; } = null;

    private void Awake()
    {
        playerInputManager = new PlayerInputManager();
    }

    private void OnEnable()
    {
        playerInputManager.Player.Enable();
    }

    private void OnDisable()
    {
        playerInputManager.Player.Disable();
    }
}
