using UnityEngine;
using System.Collections;

public class MouthMover : MonoBehaviour {

    public float ymin;
    public float ymax;

    // Use this for initialization
    void Start() {
        //ymin = transform.localPosition.y;
    }

    // Update is called once per frame
    void Update() {
        var volume = Mathf.Clamp( MicControlC.SoundVolumeValue, 0, 100 );
        volume /= 100;

        var dist = ymin - ymax;
        var sdist = dist * volume;
        var newy = ymin - sdist;

        var curpos = transform.localPosition;
        curpos.y = newy;
        transform.localPosition = curpos;

        //var t = ymin - ymax;
        //t /= MicControlC.SoundVolumeValue;

        //Debug.LogFormat( "{0}; {1}", ymin - ymax, volume );
        //var t2 = ymin - t;
    }
}
