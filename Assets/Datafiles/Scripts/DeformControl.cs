using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using Deform;

public class DeformControl : MonoBehaviour
{
    public GameObject trackedObject;

    private float magnitudeScale;

    private float xOffset;
    private float yOffset;
    private float zOffset;

    public float xOffectSpeed;
    public float yOffectSpeed;
    public float zOffectSpeed;

    public NoiseDeformer noiseDeformer;



    private void Awake()
    {
        //noiseDeformer = FindObjectOfType<NoiseDeformer>();
    }

    // Start is called before the first frame update
    void Start()
    {
    
        
    }

    // Update is called once per frame
    void Update()
    {
        //change magnitude_scale value 
        Vector3 cameraDistance = Camera.main.transform.position - trackedObject.transform.position;
        float distance = cameraDistance.magnitude;
        Debug.Log("distance: " + distance);

        if (distance <= 2.3)
        {
            magnitudeScale = 0;
        }

        if (distance > 2.3 && distance <= 5.1)
        {
            float t = Mathf.InverseLerp(3f, 5f, distance);
            magnitudeScale = Mathf.Lerp(0f, 3f, t);
        }

        if(distance > 5.1)
        {
            float t = Mathf.InverseLerp(5f, 10f, distance);
            magnitudeScale = Mathf.Lerp(3f, 0f, t);
        }

        Debug.Log("magnitudeScale:" + magnitudeScale);

        noiseDeformer.MagnitudeScalar = magnitudeScale;



        //change offset_offset value
        xOffset += xOffectSpeed * Time.deltaTime;
        yOffset += yOffectSpeed * Time.deltaTime;
        zOffset += zOffectSpeed * Time.deltaTime;

        noiseDeformer.OffsetVector = new Vector4(xOffset, yOffset, zOffset, 0);
    }
}
