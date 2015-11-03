using UnityEngine;
using UnityEditor;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class CheckpointController : MonoBehaviour {

    public GameObject checkpointAssociated;
    public ParticleSystem particle;

	// Use this for initialization
	void Start() {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D()
    {
        PlayerController.checkpointLocation = checkpointAssociated.transform.position;
        particle.startColor = Color.green;
    }
}
