using System;
using UnityEngine;

public class PlayerEventHandler : MonoBehaviour
{
    public event Action lightAttack;
    public void LightAttack() => lightAttack?.Invoke();

}
