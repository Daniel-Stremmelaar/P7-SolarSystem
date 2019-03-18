using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//[ExecuteInEditMode]

public class WayPoint : MonoBehaviour
{

    LineRenderer line;
    [SerializeField] Transform toMove;
    [SerializeField] float speed = 10;
    int lastPointCount = 0;
    [HideInInspector] public float lineLength = 0;
     [Range(0, 100)] public float currentPercent = 50;

    void Start()
    {
        line = GetComponent<LineRenderer>();
        toMove.position = line.GetPosition(0);
        lineLength = TotalLineLength();
    }

    void Update()
    {
        SetPosToPercent();
        Move();
    }

    void SetPosToPercent()
    {
        List<Vector3> linePositions = new List<Vector3>();
        for (int i = 0; i < line.positionCount; i++)
        {
            linePositions.Add(line.GetPosition(i));
        }
        toMove.position = FindPoint(linePositions.ToArray(), TotalLineLength(), (currentPercent / 100));
    }

    void Move()
    {
        currentPercent = Mathf.Repeat(currentPercent + Time.deltaTime * speed,100);
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

    Vector3 FindPoint(Vector3[] vectors, float length, float p)
    {
        if (vectors.Length < 1)
        {
            return Vector3.zero;
        }
        else if (vectors.Length < 2)
        {
            return vectors[0];
        }

        float dist = length * Mathf.Clamp(p, 0, 1);
        Vector3 pos = vectors[0];

        for (int i = 0; i < vectors.Length - 1; i++)
        {
            Vector3 v0 = vectors[i];
            Vector3 v1 = vectors[i + 1];
            float this_dist = (v1 - v0).magnitude;

            if (this_dist < dist)
            {
                dist -= this_dist;
                continue;
            }

            return Vector3.Lerp(v0, v1, dist / this_dist);
        }
        return vectors[vectors.Length - 1];
    }
}
