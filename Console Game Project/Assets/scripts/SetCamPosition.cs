using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCamPosition : MonoBehaviour
{
    public GameObject[] camPoints;
    public int whichCam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Alpha0)) { transform.position = camPoints[0].transform.position; transform.rotation = camPoints[0].transform.rotation; }
        if (Input.GetKeyDown(KeyCode.Alpha1)) { transform.position = camPoints[1].transform.position; transform.rotation = camPoints[1].transform.rotation; }
        if (Input.GetKeyDown(KeyCode.Alpha2)) { transform.position = camPoints[2].transform.position; transform.rotation = camPoints[2].transform.rotation; }
        if (Input.GetKeyDown(KeyCode.Alpha3)) { transform.position = camPoints[3].transform.position; transform.rotation = camPoints[3].transform.rotation; }
        if (Input.GetKeyDown(KeyCode.Alpha4)) { transform.position = camPoints[4].transform.position; transform.rotation = camPoints[4].transform.rotation; }
        if (Input.GetKeyDown(KeyCode.Alpha5)) { transform.position = camPoints[5].transform.position; transform.rotation = camPoints[5].transform.rotation; }
        if (Input.GetKeyDown(KeyCode.Alpha6)) { transform.position = camPoints[6].transform.position; transform.rotation = camPoints[6].transform.rotation; }
        if (Input.GetKeyDown(KeyCode.Alpha7)) { transform.position = camPoints[7].transform.position; transform.rotation = camPoints[7].transform.rotation; }
        */
        
        transform.position = camPoints[whichCam].transform.position;
        transform.rotation = camPoints[whichCam].transform.rotation;
    }

    
}
