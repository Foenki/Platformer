using UnityEngine;
using System.Collections;

public class SwitchingObjectsController : MonoBehaviour {

    public float transparency = 0.5f;
    bool active;

    void Start()
    {
        active = GetComponent<Collider2D>().enabled;

        Color spriteColor = GetComponent<SpriteRenderer>().color;
        if (!active)
        {
            spriteColor.a = transparency;
        }
        else
        {
            spriteColor.a = 1f;
        }
        GetComponent<SpriteRenderer>().color = spriteColor;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Joystick1Button5) || Input.GetKeyDown(KeyCode.A))
        {
            active = !active;
            GetComponent<Collider2D>().enabled = active;
            Color spriteColor = GetComponent<SpriteRenderer>().color;
            if (!active)
            {
                spriteColor.a = transparency;
            }
            else
            {
                spriteColor.a = 1f;
            }
            GetComponent<SpriteRenderer>().color = spriteColor;
        }
    }

    public bool IsActive()
    {
        return active;
    }
}
