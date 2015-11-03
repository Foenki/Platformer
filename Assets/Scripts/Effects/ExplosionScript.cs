using UnityEngine;
using System.Collections;

public class ExplosionScript : MonoBehaviour {

    public float animationTime = 1f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        animationTime -= Time.deltaTime;
        if(animationTime < 0)
        {
            Destroy(gameObject);
        }
	}
}
