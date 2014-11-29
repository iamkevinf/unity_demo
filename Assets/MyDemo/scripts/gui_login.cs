using UnityEngine;
using System.Collections;

public class gui_login : MonoBehaviour {

	public GameObject btnPrev, btnNext, btnEnter;
	public GameObject[] hero;
	public GameObject target;

	public string scene_name;

	private GameObject[] heroInstance;
	private int index = 0;

	// Use this for initialization
	void Start () {
		heroInstance = new GameObject[hero.Length];
		SpawnHero ();
		heroInstance [index].SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void MouseButtonUp(GameObject go)
	{
		if (go == btnPrev)
			index--;
		else if (go == btnNext)
			index++;
		else if (go == btnEnter)
			Invoke ("LoadScene", 0.1f);

		if (index > hero.Length - 1)
			index = 0;
		else if (index < 0)
			index = hero.Length - 1;
		UpdateHero ();
	}

	public void MouseButtonDown(GameObject go)
	{
		
	}

	private void SpawnHero()
	{
		for(int i=0; i<hero.Length; ++i)
		{
			heroInstance[i] = (GameObject)Instantiate(hero[i], target.transform.position, target.transform.rotation);
		}
		UpdateHero ();
	}

	private void UpdateHero()
	{
		foreach(GameObject instance in heroInstance)
		{
			instance.SetActive(false);
		}

		heroInstance [index].SetActive (true);
	}

	private void LoadScene()
	{
		PlayerPrefs.SetInt ("hero_index", index);
		Application.LoadLevel(scene_name);
	}
}
