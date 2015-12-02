using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CoinCountController : MonoBehaviour {

    static int count;
    Text text;

	// Use this for initialization
	void Start () {
        count = 0;
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
