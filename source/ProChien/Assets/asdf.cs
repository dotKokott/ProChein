using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class asdf : MonoBehaviour {

    Slider slid;

    // Use this for initialization
    void Start() {
        slid = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update() {
        slid.value = MicControlC.SoundVolumeValue / 100;
    }
}
