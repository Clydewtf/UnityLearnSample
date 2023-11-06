using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class ListSampleScript : MonoBehaviour
{
    [SerializeField] 
    private List<SampleScript> scripts = new();

    public void ActivateSampleScripts()
    {
        foreach (var script in scripts)
            script.Use();
    }
}
