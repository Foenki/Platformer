using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class BouncingScript : MonoBehaviour {

    public float bounceForce = 20f;
    public float bounceJumpForce = 25f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D()
    {
        float force =Input.GetKey(KeyCode.Joystick1Button0) ? bounceJumpForce : bounceForce;
        PlayerController controller = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        controller.velocity = new Vector2(controller.velocity.x, force);
    }
}
