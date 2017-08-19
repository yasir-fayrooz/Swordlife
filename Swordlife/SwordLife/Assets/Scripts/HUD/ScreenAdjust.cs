using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenAdjust : MonoBehaviour {

    float originalWidth = 800f;
    float originalHeight = 480f;

	void Start ()
    {
        gameObject.GetComponent<Camera>().aspect = (originalWidth / originalHeight) * (Screen.width / Screen.height);
	}

}
