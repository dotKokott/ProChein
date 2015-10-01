using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TheScore : MonoBehaviour {

    private Text text;
    private TheArm arm;

    // Use this for initialization
    void Start() {
        text = GetComponent<Text>();
        arm = GameObject.Find( "handPivot" ).GetComponent<TheArm>();
    }

    // Update is called once per frame
    void Update() {
        if ( !arm.Pulling && Input.GetKeyDown( KeyCode.Space ) ) {
            iTween.ValueTo( gameObject, iTween.Hash(
                "from", 0, "to", MicControlC.SoundVolumeValue,
                "time", 1, "onupdate", "updatescore",
                "easetype", iTween.EaseType.easeOutCubic ) );
            iTween.ShakePosition( gameObject, new Vector3( 5,5 ), 1f );
        }
    }

    void updatescore( float value ) {
        text.text = Mathf.RoundToInt( value ).ToString();
    }
}
