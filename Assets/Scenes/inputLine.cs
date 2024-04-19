using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputLine : MonoBehaviour
{
    public Transform zeroReferenvce;
    public Transform controllPoint;
    private LineRenderer lineRenderer;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.startWidth = 0.005f;
        lineRenderer.endWidth = 0.005f;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = Color.blue;
        lineRenderer.endColor = Color.blue;
    }

    // Update is called once per frame
    void Update()
    {
        var positions = new Vector3[]{
            zeroReferenvce.position,
            controllPoint.position,
        };
        lineRenderer.SetPositions(positions);
    }
}
