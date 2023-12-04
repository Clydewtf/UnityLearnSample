using System.Collections;
using UnityEngine;

public class InteractiveBox : ObstacleItem
{
    [SerializeField]
    public InteractiveBox next;

    public void AddNext(InteractiveBox box)
    {
        next = box;
    }

    void FixedUpdate()
    {
        if (next != null)
        {
            Debug.DrawLine(transform.position, next.transform.position, Color.red);
            RaycastHit hit;
            if (Physics.Raycast(transform.position, (next.transform.position - transform.position).normalized, out hit))
            {
                ObstacleItem obstacle = hit.collider.GetComponent<ObstacleItem>();
                obstacle?.GetDamage(Time.deltaTime);
            }
        }
    }
}