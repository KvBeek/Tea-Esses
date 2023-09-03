using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Restart : ControllerBase
{
    [SerializeField] InputActionReference button;

    void Update()
    {
        if (playerInputManager.FindAction(button.name).IsPressed())
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
