using UnityEngine;
using System.Collections;

public class scene_control : MonoBehaviour {

	public Transform targetPosition;
	public GameObject imgFadeCG, imgAnyKey, imgTitle, gui_game;
	
	private float fadeAlpha = 0.8f;
	private float anyKeyAlpha = 1.0f;
	private float timeCounter = 0.0f;

	private enum GAME_STATE{
		GS_CG = 0,
		GS_ANYKEY,
		GS_GAME,
	};

	private GAME_STATE gameState;

	// Use this for initialization
	void Start () {
		imgAnyKey.SetActive (false);
		imgTitle.SetActive (false);
		gameState = GAME_STATE.GS_CG;
	}

	// Update is called once per frame
	void Update () {

		switch (gameState) {
		case GAME_STATE.GS_CG:
			this.transform.position = Vector3.MoveTowards(this.transform.position, targetPosition.position, Time.deltaTime * 5);
			imgFadeCG.guiTexture.color = new Color(0.5f, 0.5f, 0.5f, fadeAlpha);
			fadeAlpha -= Time.deltaTime * 0.2f;
			if (transform.position.z >= targetPosition.position.z){
				gameState = GAME_STATE.GS_ANYKEY;
				imgFadeCG.SetActive(false);
			}
			break;

		case GAME_STATE.GS_ANYKEY:
			imgAnyKey.SetActive (true);
			imgAnyKey.guiTexture.color = new Color(.5f,.5f,.5f, anyKeyAlpha);
			anyKeyAlpha = Mathf.Sin (timeCounter * 8);
			timeCounter += Time.deltaTime;
			
			
			if ( Input.anyKey )
			{
				gameState = GAME_STATE.GS_GAME;
			}

			break;

		case GAME_STATE.GS_GAME:
			imgAnyKey.SetActive(false);
			imgTitle.SetActive(true);

			if(imgTitle.transform.position.y >= 0.87f)
				imgTitle.transform.position = 
					Vector3.MoveTowards(
						imgTitle.transform.position, 
						new Vector3(0.5f, 0.87f, 0.0f), 
						Time.deltaTime);

			gui_game.gameObject.SetActive(true);

			break;
		default:
			break;
		};

	}
}
