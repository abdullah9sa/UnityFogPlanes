using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogGenerator : MonoBehaviour {

    //fog Length in units
    public float fogLength = 10;
    // planes count - planes density for the Length
    public int planesCount = 20;
    //planes color Gradient
    public Gradient fogGradient;

    // the scale of the fog plane
    public float planeScale = 1;

    public GameObject plane;

    Transform fogHolder;
    // must be called when game stars
    void Start () {
        GenerateFog ();
    }

    public void GenerateFog () {

        fogHolder = transform;

        //clearing prevoius planes
        if (fogHolder.childCount > 0) {
            while (fogHolder.childCount != 0) {
                DestroyImmediate (fogHolder.GetChild (0).gameObject);
            }
        }

        for (int i = 0; i < planesCount; i++) {

            //createing the plane
            GameObject pln = Instantiate (plane,
                transform.position + Vector3.down * ((fogLength / planesCount) * i),
                plane.transform.rotation);

            pln.transform.parent = fogHolder;
            pln.transform.localScale *= planeScale;

            // creating a runtime material and assigning it to the created plane
            MaterialPropertyBlock _propBlock = new MaterialPropertyBlock ();
            Renderer _renderer = pln.GetComponent<Renderer> ();
            _renderer.GetPropertyBlock (_propBlock);
            float n = ((float) i / (float) planesCount);
            _propBlock.SetColor ("_Color", fogGradient.Evaluate (n));
            _renderer.SetPropertyBlock (_propBlock);

        }

    }

    public void Clear () {
        fogHolder = transform;

        //clearing prevoius planes
        if (fogHolder.childCount > 0) {
            while (fogHolder.childCount != 0) {
                DestroyImmediate (fogHolder.GetChild (0).gameObject);
            }
        }
    }

}