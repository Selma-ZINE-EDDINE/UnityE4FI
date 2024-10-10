using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;


public class ManageLensDistortion : MonoBehaviour
{
    [SerializeField] Volume v;
    [SerializeField] LensDistortion fisheye;
    [SerializeField] Vignette vignette;
    float fisheyeDistortion = 0f;


    // Start is called before the first frame update
    void Start()
    {
        v = GetComponent<Volume>();
        fisheye = GetComponent<LensDistortion>();
        vignette = GetComponent<Vignette>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            vignette.intensity.Override(0.4f);
            fisheyeDistortion += 0.1f;
            fisheye.intensity.Override(fisheyeDistortion);
        }

        /*if (Input.GetKeyDown(KeyCode.Minus))
        {
            fisheyeDistortion -= 0.1f;
            fisheye.intensity.Override(fisheyeDistortion);
        }*/
    }
}