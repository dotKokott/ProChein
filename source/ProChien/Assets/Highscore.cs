using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Highscore : MonoBehaviour {

    private Text text;

    int one = -1;
    int two = -1;
    int three = -1;

    public void Add( int value ) {
        if ( value > one ) {
            one = value;
            SetText();
            return;
        }

        if ( value > two ) {
            two = value;
            SetText();
            return;
        }

        if ( value > three ) {
            three = value;
            SetText();
            return;
        }
    }

    private void SetText() {
        text.text = string.Format(
@"#1: {0}
#2: {1}
#3: {2}",
        one == -1 ? "..." : one.ToString(),
        two == -1 ? "..." : two.ToString(),
        three == -1 ? "..." : three.ToString() );
    }

    // Use this for initialization
    void Start() {
        text = GetComponent<Text>();
    }
}
