using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackReload : ControllerBase
{

    Image reloadUIImage = null;
    float imageFill = 1;

    float attackFillSpeed = 0.1f;

    public bool reload { get; private set; }  = false;

    private void Start()
    {
        reloadUIImage = transform.GetChild(1).GetComponent<Image>();
    }

    public void ReloadAttackUI(float pAttackFillSpeed)
    {
        if (reload) return;
        attackFillSpeed = pAttackFillSpeed;
        reload = true;
        imageFill = 0;
    }

    private void Update()
    {
        if (reload && imageFill < 1)
        {
            imageFill += Time.deltaTime * attackFillSpeed;
            reloadUIImage.fillAmount = imageFill;
        }
        else {  reload = false; }
    }

}
