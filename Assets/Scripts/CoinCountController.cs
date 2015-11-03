using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CoinCountController : MonoBehaviour {

    static int count = 0;
    Text text;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        text.text = "x " + count;
	}

    public static void addCoin()
    {
        count++;
    }
}
