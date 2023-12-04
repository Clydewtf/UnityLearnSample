using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObstacleItem : MonoBehaviour
{
    public float currentValue = 1f;
    public UnityEvent onDestroyObstacle;

    private SpriteRenderer spriteRenderer;

    private Color startColor;
    private Color endColor;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        startColor = Color.white;
        endColor = Color.red;
    }

    public void GetDamage(float value)
    {
        currentValue -= value;
        currentValue = Mathf.Clamp01(currentValue);

        if (currentValue <= 0f)
        {
            onDestroyObstacle.Invoke();
            Destroy(gameObject);
        }
        Color currentColor = Color.Lerp(endColor, startColor, currentValue);

        
        spriteRenderer.color = currentColor;
    }
}


