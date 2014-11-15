using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuLevelLoad : MonoBehaviour {

	public Button levelSelect;


	// Use this for initialization
	void Start () {
		if (!PlayerPrefs.HasKey ("Played")) {
			levelSelect.enabled=false;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void LevelStart(){

		PlayerPrefs.SetInt ("CurrentLevel",0);
		Application.LoadLevel(1);
	}
	public void SelectedExit(){
		Application.Quit();
	}
	public void SelectedInstructions(){

	}
	public void SelectedLevel(){

	}
}
