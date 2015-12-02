using UnityEngine;
using System.Collections;

public class LoadLevelOnClick : MonoBehaviour {

	public GameObject home;
	public GameObject levelSelection;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void LoadLevel(int i)
	{
		Application.LoadLevel(i);
	}
	
	public void LevelSelection()
	{
		home.SetActive(false);
		levelSelection.SetActive(true);
	}
	
	public void HomeMenu()
	{
		home.SetActive(true);
		levelSelection.SetActive(false);
	}

    public void Quit()
    {
        Application.Quit();
    }

}
