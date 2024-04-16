using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] Transform platform;
    [SerializeField] Transform startPoint;
    [SerializeField] Transform endPoint;
    public float speed = 1.5f;
    int direction = 1;
    void Update()
    {
        Vector2 target = CurrentMovementTaget();
        platform.position = Vector2.Lerp(platform.position, target, speed * Time.deltaTime);

        float distance= (target - (Vector2)platform.position).magnitude;

        if(distance <= 0.1f)
        {
            direction *= -1;
        }
    }

    Vector2 CurrentMovementTaget()
    {
        if (direction == 1)
        {
            return startPoint.position;
        }
        else
        {
            return endPoint.position;
        }
    }
}
