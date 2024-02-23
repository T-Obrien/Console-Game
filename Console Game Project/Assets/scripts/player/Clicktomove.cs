using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Clicktomove : MonoBehaviour
{
    public NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray movePosition = Camera.main.ScreenPointToRay(Input.mousePosition);// raycasting to allow the player to move towards the mouse position
            if (Physics.Raycast(movePosition, out var hitInfo))//checking if raycast hit anything
            {
                agent.SetDestination(hitInfo.point);
            }

        }
    }
}
