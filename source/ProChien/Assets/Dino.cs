using UnityEngine;
using System.Collections;

public class Dino : MonoBehaviour {

	// Use this for initialization
	void Start () {
        iTween.RotateTo(gameObject, iTween.Hash("z", 18, "time", 2.5f, "easetype", iTween.EaseType.easeInBack, "looptype", iTween.LoopType.pingPong));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
