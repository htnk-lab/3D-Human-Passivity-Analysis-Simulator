using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class inputmn : MonoBehaviour
{
    public int InterfaceType;
    public int ParticipantID;
    public int exnum;

    public float xaxis = 0;
    public float yaxis = 0;
    public float zaxis = 0;

    public int start = 0;
    public int pause = 0;
    public int finish = 0;
    public Transform controller;
    public Transform ctlmodel;
    public Transform zeroreference;
    public int count=0;

    public float ctlgain = 0.01f;
    public float ctlgainGC = 0.01f;
    public GameObject camera_2D;
    public GameObject camera_VR;
    public GameObject cameraRig;

    private SteamVR_Action_Boolean startbutton = SteamVR_Actions._default.start;
    private SteamVR_Action_Boolean quitbutton = SteamVR_Actions._default.quit;

    float Sensitivity(float input)
    {
        float output = 0;
        float DZ = 0f;
        float RC = 0f;
        if (input < DZ) output = 0;
        else output = 2 * (input - DZ) / ((1 + Mathf.Exp(-(RC * (input - 1)))) * (1 - DZ));
        return ctlgainGC*output;
    }
    // Start is called before the first frame update
    void Start()
    {
        if(InterfaceType==1||InterfaceType==2){
            camera_2D.SetActive(true);
            camera_VR.SetActive(false);
        }
        if(InterfaceType==2){
            camera_2D.SetActive(true);
            camera_VR.SetActive(true);
            // cameraRig.transform.Translate(camera_2D.transform.position);
        }
        if(InterfaceType==3){
            camera_2D.SetActive(false);
            camera_VR.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (InterfaceType == 1)
        {
            if (Input.GetAxis("Axis 1") > 0f) xaxis = Sensitivity(Input.GetAxis("Axis 1"));
            else xaxis = -Sensitivity(-Input.GetAxis("Axis 1"));
            if (Input.GetAxis("Axis 5") > 0f) yaxis = -Sensitivity(Input.GetAxis("Axis 5"));
            else yaxis = Sensitivity(-Input.GetAxis("Axis 5"));
            //zaxis = (1 + Input.GetAxis("Axis 5") - (1 + Input.GetAxis("Axis 4")))/2;
            if (Input.GetAxis("Axis 2") > 0f) zaxis = -Sensitivity(Input.GetAxis("Axis 2"));
            else zaxis = Sensitivity(-Input.GetAxis("Axis 2"));

            if (start == 0)
            {
                if (Input.GetKeyDown(KeyCode.JoystickButton1))
                {
                    start = 1;
                }
            }
            if (pause == 1)
            {
                if (Input.GetKeyDown(KeyCode.JoystickButton1))
                {
                    pause = 0;
                    start = 2;
                }
            }
            if (Input.GetKeyDown(KeyCode.JoystickButton3)) finish = 1;
        }
        if (InterfaceType == 2||InterfaceType==3)
        {
            xaxis = (controller.position.x - zeroreference.position.x);
            yaxis = (controller.position.y - zeroreference.position.y);
            zaxis = (controller.position.z - zeroreference.position.z);
            float r = xaxis * xaxis + yaxis * yaxis + zaxis * zaxis;

            if (start == 0)
            {
                zeroreference.position = controller.position;
                if (startbutton.state)
                {
                    start = 1;
                }
            }
            if (pause == 1)
            {
                zeroreference.position = controller.position;
                if (startbutton.state)
                {
                    pause = 0;
                    start = 2;
                }
            }

            xaxis *= ctlgain;
            yaxis *= ctlgain;
            zaxis *= ctlgain;
            if (quitbutton.stateDown)finish = 1;


        }
        if(count>10)finish = 1;
    }
}
