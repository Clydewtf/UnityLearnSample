using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : SampleScript
{
    public Transform target;

    [ContextMenu("Activate")]
    public override void Use()
    {
        
        foreach (Transform child in target)
        {
            StartCoroutine(ShrinkAndDestroy(child.gameObject));
        }
    }

  

    private IEnumerator ShrinkAndDestroy(GameObject obj)
    {
        while (obj.transform.localScale.magnitude > 0.01f)
        {
            obj.transform.localScale -= Vector3.one * Time.deltaTime;
            yield return null;
        }
        Destroy(obj);
    }
}
