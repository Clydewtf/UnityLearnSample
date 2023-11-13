using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CopyScript : SampleScript
{
    private enum Axis
    {
        X, Y, Z,
    }

    [SerializeField]
    public GameObject _prefab; 

    [SerializeField, Min(0)]
    private int _stepsCount;

    [SerializeField, Min(0)]
    private float _step;

    [SerializeField]
    private Axis _axisToCopyOn;

    [ContextMenu("Run")]
    public override void Use()
    {
        StartCoroutine(CopyObject());
    }

    private IEnumerator CopyObject()
    {
        for (int i = 1; i <= _stepsCount; i++)
        {
            Vector3 position;

            if (_axisToCopyOn == Axis.X)
            {
                position = transform.position + new Vector3(i * _step, 0, 0);
            }
            else if (_axisToCopyOn == Axis.Y)
            {
                position = transform.position + new Vector3(0, i * _step, 0);
            }
            else
            {
                position = transform.position + new Vector3(0, 0, i * _step);
            }

            Instantiate(_prefab, position, Quaternion.identity);

            yield return null;
        }
    }
}

