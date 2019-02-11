using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//[ExecuteInEditMode]

public class WayPoint : MonoBehaviour
{

    LineRenderer line;
    [SerializeField]
    List<Vector3> points = new List<Vector3>();
    [HideInInspector] public int curFollowPoint = 0;
    [SerializeField] Transform toMove;
    [SerializeField] float speed = 10;
    int lastPointCount = 0;
    Vector3 lastPos = Vector3.zero;
    [HideInInspector] public float totalTraveledDistance = 0;
    [HideInInspector] public float lineLength = 0;

    void Start()
    {
        line = GetComponent<LineRenderer>();
        SetPoints();
        toMove.position = points[0];
        lastPos = toMove.position;
        lineLength = TotalLineLength();
    }

    void Update()
    {
        // SetPoints();
        CheckPoints();
        lastPos = toMove.position;
        Follow(toMove);
        totalTraveledDistance += Vector3.Distance(toMove.position, lastPos);
    }

    void CheckPoints()
    {
        if (line.positionCount != lastPointCount)
        {
            SetPoints();
            lineLength = TotalLineLength();
        }
        lastPointCount = line.positionCount;
    }

    void Follow(Transform follower)
    {
        Vector3 lastPos = follower.position;
        for (int i = 0; i < 1; i++)
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
                    totalTraveledDistance = 0;
                    lastPos = points[0];
                }
            }
            if (Vector3.Distance(follower.position, lastPos) < Time.deltaTime * speed)
            {
                i--;
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

    float TotalLineLength()
    {
        float toReturn = 0;
        for (int i = 1; i < line.positionCount; i++)
        {
            toReturn += Vector3.Distance(line.GetPosition(i - 1), line.GetPosition(i));
        }
        return toReturn;
    }
}
