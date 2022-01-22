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

    NoiseDeformer noiseDeformer;



    private void Awake()
    {
        noiseDeformer = FindObjectOfType<NoiseDeformer>();
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
        float distance = cameraDistance.magnitude - 8f;
        Debug.Log(distance);

        float t = Mathf.InverseLerp(0f, 7f, distance);
        magnitudeScale = Mathf.Lerp(3f, 0f, t);
        Debug.Log(magnitudeScale);

        noiseDeformer.MagnitudeScalar = magnitudeScale;

        //change offset_offset value
        xOffset += xOffectSpeed * Time.deltaTime;
        yOffset += yOffectSpeed * Time.deltaTime;
        zOffset += zOffectSpeed * Time.deltaTime;

        noiseDeformer.OffsetVector = new Vector4(xOffset, yOffset, zOffset, 0);
    }
}
