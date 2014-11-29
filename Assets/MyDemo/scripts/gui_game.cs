using UnityEngine;
using System.Collections;

public class gui_game : MonoBehaviour {

	public GameObject btnNewGame, btnLoadGame;
	public string scene_name;

	// Use this for initialization
	void Start () {
		gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void MouseButtonUp(GameObject go)
	{
		if (go == btnNewGame)
			Invoke ("LoadScene", 0.1f);
		else if (go == btnLoadGame)
			print ("MouseButtonUp on loadgame");
	}
	public void MouseButtonDown(GameObject go)
	{
		if (go == btnNewGame)
			print ("MouseButtonDown on newgame");
		else if (go == btnLoadGame)
			print ("MouseButtonDown on loadgame");
	}

	private void LoadScene()
	{
		Application.LoadLevel(scene_name);
	}
}
