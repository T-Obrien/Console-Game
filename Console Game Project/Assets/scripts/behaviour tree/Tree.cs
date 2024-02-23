using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTree
{
    public abstract class Tree : MonoBehaviour
    {

        private Node _root = null;
        //public BossManager bm; 

        protected void Start()
        {
            _root = SetupTree();
            
        }

        private void Update()
        {
            if (_root != null)
                _root.Evaluate();

            //if(_healthpointsb <= 500)
            //{
            //    _root = SetupTree2();
            //}

           
        }

        protected abstract Node SetupTree();
        //protected abstract Node SetupTree2();

    }

}
