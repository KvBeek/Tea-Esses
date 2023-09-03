using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideChildren : MonoBehaviour
{
    void Start()
    {
        foreach(Transform child in transform)
            child.gameObject.SetActive(false);
    }
}
