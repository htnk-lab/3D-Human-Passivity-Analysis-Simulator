using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class joytopose : MonoBehaviour
{
    public inputmn inputmn;
    public int filtermode;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = InputFilter(new Vector3(inputmn.xaxis, -inputmn.zaxis, -inputmn.yaxis),filtermode);
        transform.rotation = new Quaternion(inputmn.start,inputmn.pause,0,0);
    }

    Vector3 InputFilter(Vector3 axis,int mode)
    {
        if (mode == 0) return axis;
        else if (mode == 1) return (1 - Time.deltaTime) * transform.position + Time.deltaTime * axis;
        else return new Vector3(0, 0, 0);
    }
}
