using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerLight : MonoBehaviour {

    Light lampLight;
    public float minWaitTime;
    public float maxWaitTime;

	// Use this for initialization
	void Start () {
        lampLight = GetComponent<Light>();
        StartCoroutine(Flashing());
	}
	
	IEnumerator Flashing ()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
            lampLight.enabled = !lampLight.enabled;
        }
    }
}
