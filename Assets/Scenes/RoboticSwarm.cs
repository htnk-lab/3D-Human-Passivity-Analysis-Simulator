using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboticSwarm : MonoBehaviour
{
    public int NetworkType;

    public float

            a,
            b;

    public Transform Vh;

    private List<drone> VhDrones;

    // Start is called before the first frame update
    void Start()
    {
        var drones = GetComponents<drone>();
        var N = getN();
        var delta = getDelta();
        VhDrones = new List<drone>();
        foreach (var self in drones)
        {
            foreach (var drone in drones)
            {
                if (N[self.id, drone.id] == 1)
                    self.neighborDrone.Add(drones[drone.id]);
            }
            self.delta = delta[self.id] == 1;
            if (delta[self.id] == 1) VhDrones.Add(self);
            self.a = a;
            self.b = b;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vh.transform.position = calcAve();

    }

    Vector3 calcAve(){
        var ave = Vector3.zero;
        foreach (var drone in VhDrones)
        {
            ave += drone.q.position;
        }
        ave /= VhDrones.Count;
        return ave;
    }

    int[,] getN()
    {
        if (NetworkType == 1 || NetworkType == 3)
        {
            return new int[,] {
                { 0, 0, 0, 0, 0, 1, 0, 0, 0, 1 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 0, 0, 0, 0, 0, 0, 0, 1, 1, 0 },
                { 0, 0, 0, 0, 1, 0, 0, 0, 1, 0 },
                { 0, 0, 0, 1, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 1, 0, 1, 1, 1 },
                { 0, 0, 1, 0, 0, 0, 1, 0, 0, 0 },
                { 0, 0, 1, 1, 0, 0, 1, 0, 0, 0 },
                { 1, 1, 0, 0, 1, 0, 1, 0, 0, 0 }
            };
        }
        else
            return new int[,] {
                { 0, 1, 1, 1, 1, 1, 0, 1, 1, 1 },
                { 1, 0, 1, 1, 0, 1, 0, 1, 1, 1 },
                { 1, 1, 0, 1, 0, 1, 1, 0, 1, 0 },
                { 1, 1, 1, 0, 1, 0, 1, 1, 1, 1 },
                { 1, 0, 0, 1, 0, 1, 0, 0, 0, 0 },
                { 1, 1, 1, 0, 1, 0, 0, 1, 0, 1 },
                { 0, 0, 1, 1, 0, 0, 0, 1, 1, 1 },
                { 1, 1, 0, 1, 0, 1, 1, 0, 0, 1 },
                { 1, 1, 1, 1, 0, 0, 1, 0, 0, 1 },
                { 1, 1, 0, 1, 0, 1, 1, 1, 1, 0 }
            };
    }

    int[] getDelta()
    {
        switch (NetworkType)
        {
            case 1:
                return new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            case 2:
                return new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            case 3:
            default:
                return new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        }
    }
}
