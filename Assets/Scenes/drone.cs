using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drone : MonoBehaviour
{
    public int id;

    private inputmn imn;

    public Transform q;

    public Vector3 qd_prev;

    public Vector3 xi;

    public Vector3 xid_prev;

    public List<drone> neighborDrone;

    public bool delta;

    public float a;

    public float b;

    private RoboticSwarm RS;

    // Start is called before the first frame update
    void Start()
    {
        RS = this.GetComponent<RoboticSwarm>();
        imn = GameObject.Find("InputManager").GetComponent<inputmn>();
        // q.position = new Vector3(id - 4.5f, id - 4.5f, id - 4.5f)/10;
        q.position = Vector3.zero;
        qd_prev = Vector3.zero;
        xi = Vector3.zero;
        xid_prev = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        var dt = Time.deltaTime;
        if (imn.start ==2)
        {
            var u = Vector3.zero;
            foreach (var drone in neighborDrone)
            {
                u +=
                    drone.a * (drone.q.position - q.position) +
                    drone.b * (xi - drone.xi);
            }
            if (delta) u += new Vector3(imn.xaxis,imn.yaxis,imn.zaxis);
            q.position += (u + qd_prev) * dt / 2.0f;
            qd_prev = u;

            var xid = Vector3.zero;
            foreach (var drone in neighborDrone)
            {
                xid += drone.b * (drone.q.position - q.position);
            }
            xi += (xid + xid_prev) * dt / 2.0f;
            xid_prev = xid;
        }
    }
}
