using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class light_controller : MonoBehaviour
{
     public UnityEngine.Experimental.Rendering.Universal.Light2D light;
    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>();
        StartCoroutine(fadeInAndOut(light, 3));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator fadeInAndOut(UnityEngine.Experimental.Rendering.Universal.Light2D lightToFade, float duration)
    {
        float a = 0; // min intensity
        float b = 1; // max intensity

        float counter = 0f;

        //Set Values depending on if fadeIn or fadeOut
        

        

        float currentIntensity = lightToFade.intensity;

        while (counter < duration)
        {
            counter += Time.deltaTime;

            lightToFade.intensity = Mathf.Lerp(a, b, counter / duration);

            yield return null;
        }
    }
}
