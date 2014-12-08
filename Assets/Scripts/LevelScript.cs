using UnityEngine;
using System.Collections;

public class LevelScript : MonoBehaviour
{
	public static LevelScript lScript;

	public int[] allAs = {3,3,3,7,9,11};
	public int[] allBs = {5,4,7,9,17,13};
	public int[] allCs = {1,2,4,5,6,7};
	public int curLevel = 0;

	//Use this for initialization
	void Awake()
	{
		lScript = this;

		if(!PlayerPrefs.HasKey("Played"))
		{
			PlayerPrefs.SetInt("Played", 0);
		}
		curLevel = PlayerPrefs.GetInt("CurrentLevel");
		if((PlayerPrefs.GetInt("Played")) < curLevel)
			PlayerPrefs.SetInt("Played", curLevel);
	}

	void Start()
	{
	
	}
	
	// Update is called once per frame
	void Update()
	{
	
	}

	public void RetryLevel()
	{
		Application.LoadLevel(Application.loadedLevel);
	}

	public void NextLevel()
	{
		PlayerPrefs.SetInt("CurrentLevel", curLevel + 1);
		Application.LoadLevel(Application.loadedLevel);
	}

	public void MainMenu()
	{
		Application.LoadLevel(0);
	}

}
