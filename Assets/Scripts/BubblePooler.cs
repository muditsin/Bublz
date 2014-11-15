using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class BubblePooler : MonoBehaviour {
	public static BubblePooler poolScript;
	public int curLevel=0;
	public int activeCount=0;
	public GameObject bubble;
	public int pooledAmount=100;
	public bool willGrow=true;
	public int maxBubbles=150;
	List<GameObject> bubbles;
	public int score=1000;
	public int a=3;
	public int b=5;
	public int c=1;
	public int goal;
	public int goalMin=2;
	public int goalMax=70;
	public Text scoreText;
	public Text targetText;
	public Text currentText;
	public Animator levelCompleteAnim;
	public Button retry;
	public Button nextLevel;
	public Button mainMenu;

	void Awake(){
		poolScript = this;

	}
	// Use this for initialization
	void Start () {
		//maxBubbles = 150;
		curLevel = LevelScript.lScript.curLevel;
		a = LevelScript.lScript.allAs [curLevel];
		b = LevelScript.lScript.allBs [curLevel];
		c = LevelScript.lScript.allCs [curLevel];
		PlayerPrefs.SetInt ("Played", curLevel);
		goal = Random.Range (goalMin, goalMax);
		score = 1000;
		bubbles = new List<GameObject> ();
		for (int i=0; i<pooledAmount; i++) {
			GameObject obj=(GameObject)Instantiate(bubble);
			obj.SetActive(false);
			bubbles.Add(obj);
		}
		bubbles [0].transform.position = new Vector3 (0f, 0f, 0f);
		/*
		bubbles [0].transform.position = transform.position;
		bubbles [0].transform.rotation = transform.rotation;
		*/
		bubbles [0].SetActive (true);
		activeCount++;
		Debug.Log ("A="+a+" B:"+b+" C:"+c);
		retry.enabled = false;
		nextLevel.enabled = false;
		mainMenu.enabled = false;
	}

	public GameObject GetPooledObject(){
		for (int i=0; i<bubbles.Count; i++) {
			if(!bubbles[i].activeInHierarchy)
				return bubbles[i];
		}
		if (willGrow) {
			GameObject obj=(GameObject)Instantiate(bubble);
			bubbles.Add(obj);
			return obj;
		}
		return null;
	}
	public void DestroyBubbles(GameObject obj,int n=1){
		obj.SetActive(false);
		activeCount--;
		for(int j=0;j<n-1;j++){
			for (int i=0; i<bubbles.Count; i++) {
				if(bubbles[i].activeInHierarchy){
					bubbles[i].SetActive(false);
					activeCount--;
					break;
				}
			}
		}
		if(activeCount==goal)
			GoalReached();
		score -= 10;
	}
	
	// Update is called once per frame
	public void GoalReached(){
		if (curLevel == 5) {
						mainMenu.enabled = true;
						levelCompleteAnim.SetTrigger ("AllLevelsOver");
				}
		else {
			retry.enabled=true;
			nextLevel.enabled=true;
			levelCompleteAnim.SetTrigger ("LevelComplete");
		}
		Debug.Log("Goal Reached!");
	}
	void Update(){
		scoreText.text = "Score: " + score;
		currentText.text = "Count: " + activeCount;
		targetText.text = "Targer: " + goal;
	}
}
