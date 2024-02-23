using System.Collections;
using System.Collections.Generic;
// using UnityEditor.UI;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.DualShock;
#if UNITY_PS4
using UnityEngine.PS4;
#endif

public class TestMove : MonoBehaviour
{
    
    //private Transform tr;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //var gamepad = (DualShockGamepad)Gamepad.all[0];

        bool pressed = Input.GetButtonDown("Fire1");
        //if (pressed)
        //{
        //    gamepad.SetLightBarColor(Color.red);
        //}
        //bool pressed2 = Input.GetButtonDown("Fire2");
        //if (pressed2)
        //{
        //    gamepad.SetLightBarColor(Color.cyan);
        //}
        
        float xdirection = Input.GetAxis("Vertical");
        float zdirection = Input.GetAxis("Horizontal");

        //tr = this.GetComponent<Transform>();
        xdirection *= Time.deltaTime;
        zdirection *= Time.deltaTime;
        transform.Translate(5 * xdirection, 0, 5 * zdirection);
        //Debug.Log(direction);
    }
}
