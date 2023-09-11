using System.Collections;
using UnityEngine;

public class AttackSwing : MonoBehaviour
{
    GameObject swingObject;
    Transform swingHolderBase;

    float swingDistance, rotationSpeed, easeFactorAdjust;
    Quaternion targetRotation;
    Quaternion initialRotation;

    RStickAim rStickAim;

    bool isBounced = false;

    private void Start()
    {
        swingHolderBase = GetComponent<Transform>();
        rStickAim = FindObjectOfType<RStickAim>();
    }

    /// <summary>
    /// Swings the gameObject swingObject on a specifiek angle
    /// </summary>
    /// <param name="pSwingObject"></param>
    /// <param name="pSwingDistance"></param>
    /// <param name="pRotationSpeed"></param>
    /// <param name="pEaseFactorAdjust"></param>
    public void Swing(GameObject pSwingObject, float pSwingDistance = 30, float pRotationSpeed = 2f, float pEaseFactorAdjust = 6)
    {
        swingDistance = pSwingDistance;
        rotationSpeed = pRotationSpeed;
        easeFactorAdjust = pEaseFactorAdjust;
        swingObject = pSwingObject;

        initialRotation.eulerAngles = Vector3.up * -swingDistance;
        targetRotation.eulerAngles = Vector3.up * swingDistance;

        StartCoroutine(SwingRotation());
    }


    IEnumerator SwingRotation()
    {
        rStickAim.enabled = false;
        swingObject.gameObject.SetActive(true);

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
        rStickAim.enabled = true;
        isBounced = false;
    }
}
