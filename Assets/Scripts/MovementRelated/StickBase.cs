using UnityEngine;

public class ControllerBase : MonoBehaviour
{
    [SerializeReference] protected PlayerInputManager playerInputManager = null;

    protected virtual void Awake()
    {
        playerInputManager = new PlayerInputManager();
    }

    protected virtual void Start(){}
    protected virtual void Update(){}

    private void OnEnable()
    {
        playerInputManager.Player.Enable();
    }

    private void OnDisable()
    {
        playerInputManager.Player.Disable();
    }
}
