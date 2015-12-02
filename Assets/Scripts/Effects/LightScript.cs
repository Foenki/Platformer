using UnityEngine;
using System.Collections;

public class LightScript : MonoBehaviour {

    public Color color1;
    public Color color2;
    bool isOne;

	// Use this for initialization
	void Start () {
        isOne = true;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Joystick1Button5) || Input.GetKeyDown(KeyCode.A))
        {
            isOne = !isOne;
            GetComponent<Light>().color = isOne ? color1 : color2;
        }
    }
}
