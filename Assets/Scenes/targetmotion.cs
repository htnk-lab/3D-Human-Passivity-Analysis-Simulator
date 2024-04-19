using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetmotion : MonoBehaviour
{
    public inputmn inputmn;
    public GameObject controller;
    private float time=0;
    int moving = 0;
    Vector3 nowpos;
    Vector3 nextpos;
    

    public float interval;

    // Start is called before the first frame update
    void Start()
    {
        inputmn.count = 1;
        Vector3 conpos = controller.transform.position;
        transform.position = new Vector3(Random.Range(-1f,1f),Random.Range(0f,2f),Random.Range(-1f,1f));
        nowpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        /*
        if (time >= interval)
        {
            interval = Random.Range(0.5f, 5f);
            nowpos = transform.position;
            nextpos = new Vector3(Random.Range(0f, 0.5f), Random.Range(0.5f, 1f), Random.Range(0f, 0.5f));
            time = 0;
        }
        if (time < interval)
        {
            float x = time / interval;
            transform.position = nowpos + ((x*x*(3-2*x)) * (nextpos - nowpos));
        }
        */

        
        if (inputmn.start == 2)
        {
            time += Time.deltaTime;

            if (time > interval && moving == 0)
            {
                Vector3 conpos = controller.transform.position;
                nowpos = transform.position;

                nextpos = getNextPos();
                moving = 1;
                time = 0;
            }
        }
        if (moving == 1)
        {
            time += Time.deltaTime;
            inputmn.pause = 1;
            inputmn.start = 1;
            transform.position = nowpos + ((nextpos - nowpos) * time * 10);
            if (time > 0.1)
            {
                transform.position = nextpos;
                moving = 0;
                time = 0;
                inputmn.count += 1;
            }

        }
        
    }

    Vector3 getNextPos(){
        var x = Random.Range(-1f, 1f);
        var y = Random.Range(-1f, 1f);
        var z = Random.Range(-1f, 1f);
        var nor = Mathf.Sqrt(x * x + y * y + z * z);
        var r = Random.Range(0.3f, 0.5f);
        var pos = transform.position;
        var e = new Vector3(x, y, z) / nor * r;
        pos += e;
        if(pos.x>1)pos.x = 2-pos.x;
        if(pos.y>2)pos.y = 4-pos.y;
        if(pos.z>1)pos.z = 2-pos.z;
        if(pos.x<-1)pos.x = -2-pos.x;
        if(pos.y<0)pos.y = -pos.y;
        if(pos.z<-1)pos.z = -2-pos.z;
        return pos;
    }
}
