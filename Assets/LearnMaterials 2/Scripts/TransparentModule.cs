using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentModule : MonoBehaviour
{
    [SerializeField, Min(0)]
    private float changeSpeed;

    private float defaultAlpha;
    private Material mat;
    private bool toDefault;

    private void Start()
    {
        mat = GetComponent<Renderer>().material;
        defaultAlpha = mat.color.a;
        toDefault = false;
    }
    [ContextMenu("Set transparency")]
    public void ActivateModule()
    {
        float target = toDefault ? defaultAlpha : 0;
        StopAllCoroutines();
        StartCoroutine(ChangeTransparencyCoroutine(new Color(mat.color.r, mat.color.g, mat.color.b, target)));
        toDefault = !toDefault;
    }

    public void ReturnToDefaultState()
    {
        toDefault = true;
        ActivateModule();
    }

    private IEnumerator ChangeTransparencyCoroutine(Color target)
    {
        Color start = mat.color;
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime * changeSpeed;
            mat.color = Color.Lerp(start, target, t);
            yield return null;
        }
        mat.color = target;
    }
}
