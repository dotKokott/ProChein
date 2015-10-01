using UnityEngine;
using System.Collections;

public class HandMover : MonoBehaviour {

    public float Value;

	// Use this for initialization
	void Start () {
        iTween.RotateTo(gameObject, iTween.Hash("z", Value, "time", 0.2f, "looptype", iTween.LoopType.pingPong, "easetype", iTween.EaseType.linear));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
