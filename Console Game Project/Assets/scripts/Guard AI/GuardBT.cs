using System.Collections.Generic;
using BehaviourTree;

public class GuardBT : Tree
{
    public UnityEngine.Transform[] waypoints;

    public static float speed = 2f;
    public static float fovRange = 2f;
    public static float attackRange = 1f;

    protected override Node SetupTree()
    {
        Node root = new Selector(new List<Node>
        {
            new Sequence(new List<Node>
            {
                new CheckEnemyInAttackRange(transform),
                new TaskAttack(transform),
            }),
            new Sequence(new List<Node>
            {
                new CheckEnemyInFOVRange(transform),
                
                new TaskGoToTarget(transform),
            }),
            new TaskPatrol(transform, waypoints),
        });

        //Node root = new Selector(new List<Node>
        //{
        //    new Sequence(new List<Node>
        //    {
        //        new CheckEnemyInFOVRange(transform),
        //        new TaskGoToTarget(transform),
        //    }),
        //    new TaskPatrol(transform, waypoints)
        //});


        return root;
 
    }




    //protected override Node SetupTree2()
    //{
    //    Node root = new Selector(new List<Node>
    //    {
    //        new Sequence(new List<Node>
    //        {
    //            new CheckEnemyInAttackRange(transform),
    //            new TaskAttack(transform),
    //        }),
    //        new Sequence(new List<Node>
    //        {
    //            new CheckEnemyInFOVRange(transform),
    //            new TaskGoToTarget(transform),
    //        }),
    //        new TaskPatrol(transform, waypoints),
    //    });

    //    //Node root = new Selector(new List<Node>
    //    //{
    //    //    new Sequence(new List<Node>
    //    //    {
    //    //        new CheckEnemyInFOVRange(transform),
    //    //        new TaskGoToTarget(transform),
    //    //    }),
    //    //    new TaskPatrol(transform, waypoints)
    //    //});


    //    return root;
    //}
}
