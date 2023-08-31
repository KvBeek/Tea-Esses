using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSwing : MonoBehaviour
{

    float swingDistance, rotationSpeed, easeFactorAdjust;
    GameObject swingObject;

    PlayerEventHandler playerEventHandler;
    Transform swingHolderBase;

    Quaternion targetRotation;
    Quaternion initialRotation;

    private void Start()
    {
        swingHolderBase = GetComponent<Transform>();
    }

    public void Swing(GameObject pSwingObject, float pSwingDistance = 30, float pRotationSpeed = 2f, float pEaseFactorAdjust = 6)
    {
        swingDistance = pSwingDistance;
        rotationSpeed = pRotationSpeed;
        easeFactorAdjust = pEaseFactorAdjust;
        swingObject = pSwingObject;

        initialRotation.eulerAngles = Vector3.up * -swingDistance;
        targetRotation.eulerAngles = Vector3.up * swingDistance;

        swingObject.gameObject.SetActive(true);

        StartCoroutine(SwingRotation());
    }

    IEnumerator SwingRotation()
    {
        float elapsedTime = 0.0f;
        Quaternion startRotation = initialRotation;
        Quaternion target = targetRotation;

        while (elapsedTime < 1.0f)
        {

            elapsedTime += Time.deltaTime * rotationSpeed;
            float easeFactor = 1.0f - Mathf.Pow(1.0f - elapsedTime, easeFactorAdjust);
            swingHolderBase.localRotation = Quaternion.Slerp(startRotation, target, easeFactor);
            yield return null;
        }

        swingHolderBase.localRotation = target; // Ensure final rotation is accurate
        swingObject.gameObject.SetActive(false);
    }

}
