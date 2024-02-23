using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkingState : State
{
    Agent owner;

    public walkingState(Agent owner) { this.owner = owner; }
    GameObject Skeleton;
    public int Speed;
    float x, y, z = 0;
    Vector3 Aiming;
    int cooldown = 5;
    bool play;

    public override void Enter()
    {
        Debug.Log("Entering walking");
        Skeleton = owner.gameObject;
        owner.StartCoroutine(Pause(cooldown));

    }
    public override void Execute()
    {
        Debug.Log("Execute walking");
        if (play)
        {
            Vector3 skeletonPos = new Vector3(x, y, z);
            skeletonPos = new Vector3(0, 0, Speed * Time.deltaTime);
            Skeleton.transform.Translate(skeletonPos);
            owner.walk.SetBool("walk", true);

        }
        else
        {
            owner.walk.SetBool("walk", false);
        }

    }
    public override void Exit()
    {
        Debug.Log("Exiting walking");
        owner.StopAllCoroutines();

    }

    Vector3 FinalPos()
    {
        Vector3 dest = new Vector3(Skeleton.transform.position.x + Random.Range(-3, 3), 0, Skeleton.transform.position.z + Random.Range(-3, 3));
        return dest;
    }
   
    public IEnumerator Pause(int cooldown)
    {
        play = false;
        yield return new WaitForSeconds(cooldown);
        owner.StartCoroutine(Play(cooldown));

    }

    public IEnumerator Play(int cooldown)
    {
        play = true;
        cooldown = Random.Range(1, 5);
        Speed = Random.Range(1, 3);
        Aiming = FinalPos();
        float angle_to_turn = owner.CalculateAngle(Skeleton.transform, Aiming);
        Skeleton.transform.Rotate(0, angle_to_turn, 0);
        yield return new WaitForSeconds(cooldown);
        owner.StartCoroutine(Pause(cooldown));
    }


}

