using UnityEngine;
using System.Collections;

public class BubbleScript : MonoBehaviour {
	//private float lastClickTime=0f;
	int mouseClicks=0;
	bool mouseClicksStarted=false;
	float mouseTimerLimit=0.25f;
	public AudioSource popSound;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1")){

		}
	}
	void OnMouseDown(){
		mouseClicks++;
		if(mouseClicksStarted)
			return;
		
		mouseClicksStarted = true;
		Invoke("CheckMouseDoubleClick", mouseTimerLimit);
	}
	void CheckMouseDoubleClick(){
		if(mouseClicks > 1){
			if(BubblePooler.poolScript.b+BubblePooler.poolScript.activeCount>BubblePooler.poolScript.maxBubbles){
				InvalidMove();
				return;
			}
			OnClick(BubblePooler.poolScript.b);
		}
		else{
			if((BubblePooler.poolScript.a)+(BubblePooler.poolScript.activeCount)>(BubblePooler.poolScript.maxBubbles)){
				InvalidMove();
				return;
			}
			OnClick(BubblePooler.poolScript.a);
		}
		mouseClicksStarted = false;
		mouseClicks = 0;
	}

	void OnClick(int x){
		for (int i=0; i<x; i++) {
			GameObject obj=BubblePooler.poolScript.GetPooledObject();
			if(obj!=null){
				obj.transform.position=new Vector3(transform.position.x+Random.Range(-0.9f,0.9f),transform.position.y+Random.Range(-0.9f,0.9f),transform.position.z);
				obj.transform.rotation=Quaternion.identity;
				obj.SetActive(true);
				BubblePooler.poolScript.activeCount++;
			}
		}
		if(BubblePooler.poolScript.activeCount==BubblePooler.poolScript.goal){
			BubblePooler.poolScript.GoalReached();
		}
		BubblePooler.poolScript.score -= 10;
	}
	void OnMouseOver(){
		if (Input.GetMouseButton (1) &&( BubblePooler.poolScript.activeCount > BubblePooler.poolScript.c)) {
			BubblePooler.poolScript.DestroyBubbles(gameObject,BubblePooler.poolScript.c);
		}
	}
	void InvalidMove(){
		return;
	}
}
