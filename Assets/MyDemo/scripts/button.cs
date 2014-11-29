using UnityEngine;
using System.Collections;

public class button : MonoBehaviour {

	public Texture2D imgDwn, imgNml, imgDis;
	public MonoBehaviour owner;

	void OnMouseUp()
	{
		this.gameObject.guiTexture.texture = imgNml;
		owner.gameObject.SendMessage ("MouseButtonUp", gameObject);
	}
	
	void OnMouseDown()
	{
		this.gameObject.guiTexture.texture = imgDwn;
		owner.gameObject.SendMessage ("MouseButtonDown", gameObject);
	}
}
