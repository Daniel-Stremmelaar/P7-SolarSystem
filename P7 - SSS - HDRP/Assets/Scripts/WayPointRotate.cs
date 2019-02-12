using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointRotate : MonoBehaviour
{

    public float roundPercent = 0;
    [SerializeField] float rotationsPerRound = 365.25f;
    LineRenderer line;
    WayPoint wayPoint;
    [SerializeField] Transform toRotate;
    [SerializeField] Vector2 angleOffset = new Vector2(20, 20);

    void Start()
    {
        line = GetComponent<LineRenderer>();
        wayPoint = GetComponent<WayPoint>();
    }

    void Update()
    {
        GetPercent();
        SetRotation();
    }

    void SetRotation()
    {
        toRotate.rotation = new Quaternion(0,0,0,1);
        toRotate.Rotate(toRotate.InverseTransformDirection(angleOffset.x, 0, angleOffset.y));
        toRotate.Rotate(0, roundPercent * 3.6f * rotationsPerRound, 0);
    }

    void GetPercent()
    {
        roundPercent = wayPoint.totalTraveledDistance;
        roundPercent /= wayPoint.lineLength;
        roundPercent *= 100;
    }
}
