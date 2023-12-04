using UnityEngine;

public class RotateScript : SampleScript
{
    [SerializeField]
    private float rotationTime;
    [SerializeField]
    private Vector3 TargetRotationVector;

    private Quaternion targetRotation;
    private Quaternion initialRotation;
    [ContextMenu("Крутить")]
    public override void Use()
    {
        initialRotation = transform.rotation;
        targetRotation = Quaternion.Euler(TargetRotationVector);
        StartCoroutine(RotateCoroutine());
    }

    private System.Collections.IEnumerator RotateCoroutine()
    {
        float t = 0;

        while (t <= 1)
        {
            t += Time.deltaTime/rotationTime;
            transform.rotation = Quaternion.Lerp(initialRotation, targetRotation, t);
            yield return null;
        }

        transform.rotation = targetRotation;
    }
}