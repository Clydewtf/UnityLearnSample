using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edward_script : SampleScript
{
    public float moveSpeed = 1.0f;
    public Vector3 targetPosition;
    private Vector3 initialPosition;
    private bool isMoving = false;

    [ContextMenu("Go")]
    public override void Use()
    {
        if (!isMoving)
        {
            StartCoroutine(MoveToTarget());
        }
    }

    private IEnumerator MoveToTarget()
    {
        initialPosition = transform.position;
        isMoving = true;
        float journeyLength = Vector3.Distance(initialPosition, targetPosition);
        float startTime = Time.time;

        while (Time.time - startTime < journeyLength / moveSpeed)
        {
            float journeyTime = (Time.time - startTime) * moveSpeed;
            float journeyFraction = journeyTime / journeyLength;
            transform.position = Vector3.Lerp(initialPosition, targetPosition, journeyFraction);
            yield return null;
        }

        transform.position = targetPosition;

        isMoving = false;
    }
}
