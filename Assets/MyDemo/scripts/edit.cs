using UnityEngine;
using System.Collections;

public class edit : MonoBehaviour {

	public string defaultName;
	public GUIStyle style;
	public Rect rect;
	public MonoBehaviour owner;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		GUI.matrix = Matrix4x4.Scale (new Vector3(Screen.width/1024.0f, Screen.height/768.0f, 1));

		defaultName = GUI.TextArea (rect, defaultName, style);

		GUI.matrix = Matrix4x4.identity;
	}
}
