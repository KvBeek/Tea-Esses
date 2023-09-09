using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackReload : ControllerBase
{
    Image reloadUIImage = null;
    float imageFill = 1;

    [SerializeField] float attackFillSpeed = 0.1f;

    public bool reload { get; private set; }  = false;

    protected override void Start()
    {
        // Get UI image for reloading
        reloadUIImage = transform.GetChild(1).GetComponent<Image>();
    }

    public void ReloadAttackUI(float pAttackFillSpeed)
    {
        // Stop execution when reloading
        if (reload) return;
        attackFillSpeed = pAttackFillSpeed;
        reload = true;
        imageFill = 0;
    }

    private void Update()
    {
        // when reloading and reload image is not filled, fill image further
        if (reload && imageFill < 1)
        {
            imageFill += Time.fixedDeltaTime * attackFillSpeed;
            reloadUIImage.fillAmount = imageFill;
        }
        // set reload to false when reload image is full
        else {  reload = false; }
    }

}
