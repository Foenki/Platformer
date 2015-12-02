using UnityEngine;
using System.Collections;

public class PauseMenuScript : MonoBehaviour {

    public bool paused;

    public GameObject pauseMenuCanvas;

	// Use this for initialization
	void Start () {

        paused = false;
    }

    // Update is called once per frame
    void Update () {
	
        if(Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            paused = !paused;
            Time.timeScale = paused ? 0f : 1f;
            pauseMenuCanvas.GetComponent<Canvas>().enabled = paused;
        }

	}
	
	public void Resume()
	{
		paused = false;
		Time.timeScale = 1f;
        pauseMenuCanvas.GetComponent<Canvas>().enabled = false;
	}
	
	public void Respawn()
	{
		Resume();
		GameObject player = GameObject.FindGameObjectWithTag("Player");
        PlayerController controller = player.GetComponent<PlayerController>();
        controller.die();
	}
	
	public void HomeMenu()
	{
        Application.LoadLevel(0);
        Time.timeScale = 1f;
    }
}
