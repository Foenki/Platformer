using UnityEngine;
using System.Collections;

public class CoinController : MonoBehaviour {

    SwitchingObjectsController controller;

	// Use this for initialization
	void Start () {

	    controller = GetComponent<SwitchingObjectsController>();
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D other) {
        if(controller == null || controller.IsActive())
        {
                GetComponent<AudioSource>().enabled = true;
                GetComponent<SpriteRenderer>().enabled = false;
                Destroy(gameObject, 0.2f);
                CoinCountController.addCoin();
        }

    }
}
