using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetWhichCam : MonoBehaviour
{
    public int setCam;
    public SetCamPosition cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        cam.whichCam = setCam;
    }
}
