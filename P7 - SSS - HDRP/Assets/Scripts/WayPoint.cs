using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//[ExecuteInEditMode]

public class WayPoint : MonoBehaviour
{

    LineRenderer line;
    [SerializeField]
    List<Vector3> points = new List<Vector3>();
    int curFollowPoint = 0;
    [SerializeField] Transform toMove;
    [SerializeField] float speed = 10;
    int lastPointCount = 0;

    void Start()
    {
        line = GetComponent<LineRenderer>();
        SetPoints();
        toMove.position = points[0];
    }

    void Update()
    {
        // SetPoints();
        CheckPoints();
        Follow(toMove);
    }

    void CheckPoints()
    {
        if (line.positionCount != lastPointCount)
        {
            SetPoints();
        }
        lastPointCount = line.positionCount;
    }

    void Follow(Transform follower)
    {
        follower.position = Vector3.MoveTowards(follower.position, points[curFollowPoint], Time.deltaTime * speed);
        if (Vector3.Distance(follower.position, points[curFollowPoint]) < 0.3f)
        {
            if (curFollowPoint < points.Count - 1)
            {
                curFollowPoint++;
            }
            else
            {
                curFollowPoint = 0;
            }
        }
    }

    void SetPoints()
    {
        if (line == null)
        {
            line = GetComponent<LineRenderer>();
        }
        points.Clear();
        for (int i = 0; i < line.positionCount; i++)
        {
            //  points.Add(transform.GetChild(i).transform.position);
            points.Add(line.GetPosition(i));
        }
    }
}
