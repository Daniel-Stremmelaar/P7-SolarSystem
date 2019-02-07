using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{

    CharacterController cc;
    [SerializeField]
    float myMass = 5;
    Vector3 currentVelocity = Vector3.zero;
    [SerializeField]
    float velocityAcceleration = 5;
    [SerializeField]
    Vector3 startVelocity = Vector3.zero;

    void Start()
    {
        currentVelocity = startVelocity;
    }

    void Update()
    {
        FinalMove(InfluenceToV3(GetOtherMassesInfluence(FindOtherMasses()), FindOtherMasses()));
    }

    public virtual List<Gravity> FindOtherMasses()
    {
        //this function is made to get all other masses of gravity. 
        //Everything moves toward each other after all.

        List<Gravity> otherMasses = new List<Gravity>();

        otherMasses.Clear();//just in case
        otherMasses.AddRange(GameObject.FindObjectsOfType<Gravity>());
        otherMasses.Remove(this);
        return otherMasses;
    }

    public List<float> GetOtherMassesInfluence(List<Gravity> otherMass)
    {
        List<float> otherMassDistanceAndMass = new List<float>();
        otherMassDistanceAndMass.Clear();

        // first get the other masses directly
        for (int i = 0; i < otherMass.Count; i++)
        {
            otherMassDistanceAndMass.Add(otherMass[i].myMass);
            //now add the distances
            otherMassDistanceAndMass[i] = Vector3.Distance(transform.position, otherMass[i].transform.position);
        }

        return otherMassDistanceAndMass;
    }

    public Vector3 InfluenceToV3(List<float> influences, List<Gravity> otherMasses)
    {
        Vector3 toReturn = Vector3.zero;

        for (int i = 0; i < otherMasses.Count; i++)
        {
            Vector3 oldEuler = transform.eulerAngles;
            transform.LookAt(otherMasses[i].transform.position);
            toReturn += transform.forward * influences[i];
            transform.eulerAngles = oldEuler;
        }

        return toReturn;
    }

    public void FinalMove(Vector3 vector)
    {
        if (cc == null)
        {
            cc = GetComponent<CharacterController>();
        }
        currentVelocity = Vector3.MoveTowards(currentVelocity, vector, Time.deltaTime * velocityAcceleration / myMass);
        cc.Move(currentVelocity * Time.deltaTime);
    }
}
