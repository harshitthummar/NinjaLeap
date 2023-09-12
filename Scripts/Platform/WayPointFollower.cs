using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointFollower : MonoBehaviour
{
    
    [Header("Petroling Config")]
    [SerializeField] private GameObject[] WayPoints;
    [SerializeField] private float Speed;

    private int currentwayindex = 0;
    private void Update()
    {
        if (Vector2.Distance(WayPoints[currentwayindex].transform.position,transform.position) < 0.1f)
        {
            currentwayindex++;
            if(currentwayindex >= WayPoints.Length)
            {
                currentwayindex = 0;
            }

        }
        transform.position = Vector2.MoveTowards(transform.position, WayPoints[currentwayindex].transform.position, Time.deltaTime * Speed);
    }
}
