using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsCoupler : MonoBehaviour
{
    public PlayerEventHandler playerEventHandler { get; private set; }

    void Start()
    {
        playerEventHandler = FindObjectOfType<PlayerEventHandler>();
    }

}
