using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectObj : MonoBehaviour
{
    public Material[] material;
    Renderer rend;
    GameObject obj;


    RaycastHit Hit;

    public List<GameObject> currentHitObjects = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
 

        Transform cameraTransform = Camera.main.transform;


        //if (Physics.SphereCast(cameraTransform.position, 1f, cameraTransform.forward, out Hit))
        //{
        //    //rend = Hit.transform.GetComponent<Renderer>();
        //    //rend.enabled = true;
        //    //rend.sharedMaterial = material[1];

        //    if (obj != Hit.collider.gameObject)
        //    {
        //        if (obj != null)
        //        {
        //            rend.material = material[0];
        //        }

        //        obj = Hit.collider.gameObject;
        //        rend = obj.GetComponent<Renderer>();
        //        material[0] = rend.material;
        //        rend.material = material[1];
        //    }
        //    else
        //    {
        //        if (obj != null)
        //        {
        //            rend.material = material[0];
        //            obj = null;
        //        }
        //    }
        //}



        RaycastHit[] Hits = Physics.SphereCastAll(cameraTransform.position, 0.5f, cameraTransform.forward);

        //for (int i = 0; i < Hits.Length; i++)
        //{
        //    rend = Hits[i].transform.GetComponent<Renderer>();
        //    rend.enabled = true;
        //    rend.sharedMaterial = material[0];
        //}

        currentHitObjects.Clear();
        foreach (RaycastHit Hit in Hits)
        {
            currentHitObjects.Add(Hit.transform.gameObject);
        }

        foreach (GameObject Obj in currentHitObjects)
        {
            rend = Obj.GetComponent<Renderer>();
            rend.enabled = true;
            rend.sharedMaterial = material[0];
        }
    }
}
