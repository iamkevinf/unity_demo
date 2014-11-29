using UnityEngine;
using System.Collections;

public class spawn_hero : MonoBehaviour {

	public GameObject[] hero;
	public static bool isLoadData;

	private int index;

	// Use this for initialization
	void Awake () {
		index = PlayerPrefs.GetInt("hero_index", 0);
		
		hero[index] = (GameObject)Instantiate(hero[index], transform.position, transform.rotation);
		if(isLoadData)
		{
			LoadData();
			isLoadData = false;
		}
	}

	private void LoadData()
	{

	}
}
