using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    Statemanager sm = new Statemanager();
    public string hitmans = "untagged";
    public int Ostate = 0;
    Transform cachedTransform;
    public RaycastHit info = new RaycastHit();
    public float angle;
    public LayerMask hitMask;
    public LayerMask obsMask;
    public float radius;
    public Animator walk; 


    // Start is called before the first frame update
    void Start()
    {
        sm.ChangeState(new walkingState(this));
        cachedTransform = GetComponent<Transform>();
        walk = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        sm.Update();
        if (info.collider  != null)
        {
            if (hitmans.Equals("player") && Ostate == 0)
            {
                sm.ChangeState(new attackState(this));
                Ostate = 1;
            }
            else if(hitmans.Equals("untagged") && Ostate == 1)
            {
                sm.ChangeState(new walkingState(this));
                Ostate = 0;
            }
        }
    }
    bool eyes()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(cachedTransform.position, radius, hitMask);
        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directiontoTarget = (target.position - cachedTransform.position).normalized;

            if (Vector3.Angle(transform.forward, directiontoTarget) < angle / 2)
            {
                float distancetoTarget = Vector3.Distance(cachedTransform.position, target.position);
                if (!Physics.Raycast(cachedTransform.position, directiontoTarget, out info, distancetoTarget, obsMask))
                {
                    if (Physics.Raycast(cachedTransform.position, directiontoTarget, out info, distancetoTarget, hitMask))
                    {
                        hitmans = info.collider.tag;//this allows my skeleton to view tags rather than layers like the solider
                        Debug.DrawRay(cachedTransform.position, directiontoTarget, Color.white, 1);
                        if (distancetoTarget >= 5)
                        {
                            hitmans = "untagged";
                        }

                        return true;
                    }
                }
               
            }
        }
        return false;
    }
    
    Vector3 Cross(Vector3 v, Vector3 w)
    {
        Vector3 crossProd = new Vector3(0, 0, 0);

        crossProd = new Vector3((v.y * w.z) - (v.z * w.y), (v.z * w.x) - (v.x * w.z), (v.x * w.y) - (v.y * w.x));

        return crossProd;
    }


    public float CalculateAngle(Transform from, Vector3 to)
    {
        Vector3 tF = from.forward;
        // Vector to the seek object
        Vector3 sD = to - from.position;

        Vector3 perpangle = new Vector3(0, 0, 0);

        float dot = 0.0f;   // store the dot product
        float angle = 0.0f; // angle var to return

        // Calculate the dot product
        dot = (tF.x * sD.x) + (tF.y * sD.y) + (tF.z * sD.z);

        // Calculate the angle between the two items - be careful it is in degs and not rads
        angle = Mathf.Acos(dot / (Mathf.Sqrt((tF.x * tF.x) + (tF.y * tF.y) + (tF.z * tF.z)) * Mathf.Sqrt((sD.x * sD.x) + (sD.y * sD.y) + (sD.z * sD.z)))) * 180 / Mathf.PI;

        perpangle = Cross(tF, sD);

        if (perpangle.y <= 0)
        {
            angle = angle * -1;
        }

        return angle;
    }
}
