using UnityEngine;
using System.Collections;

public class TheArm : MonoBehaviour {

    public bool Pulling = false;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (!Pulling & Input.GetKeyDown(KeyCode.Space)) {
            iTween.RotateTo(gameObject, iTween.Hash("z", 115, "time", 1, "easetype", iTween.EaseType.easeOutBack, "oncomplete", "onComplete"));
            Pulling = true;
            iTween.ShakePosition(GameObject.Find("chi"), new Vector3(0.1f, 0.1f), 1);
        }
	}

    public void onComplete() {
        iTween.RotateTo(gameObject, iTween.Hash("z", 0, "time", 1, "easetype", iTween.EaseType.easeOutBack));
        StartCoroutine(WaitForDown(1));
    }

    public IEnumerator WaitForDown(float time) {
        yield return new WaitForSeconds(time);

        Pulling = false;

    }
}
