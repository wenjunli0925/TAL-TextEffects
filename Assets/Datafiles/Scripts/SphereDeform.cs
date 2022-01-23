using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereDeform : MonoBehaviour
{
    public GameObject sphere;

    public float sphereGrowthSpeed;


    private float currentGradientScale;
    private Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = sphere.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(sphere.transform.localScale.x < 920f)
        {
            sphere.transform.localScale += new Vector3(sphereGrowthSpeed, sphereGrowthSpeed, sphereGrowthSpeed);
        }

        float t = Mathf.InverseLerp(280f, 920f, sphere.transform.localScale.x);
        currentGradientScale = Mathf.Lerp(12f, 2f, t);
        rend.material.SetFloat("_GradientScale", currentGradientScale);
    }
}
