using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Highscore : MonoBehaviour {

    private Text text;

    List<int> scores = new List<int>();

    public void Add( int value ) {
        scores.Add( value );
        scores.Sort();
        scores.Reverse();
        SetText();
    }

    private void SetText() {
        text.text = string.Format(
@"#1: {0}
#2: {1}
#3: {2}",
        scores[0] == -1 ? "..." : scores[0].ToString(),
        scores[1] == -1 ? "..." : scores[1].ToString(),
        scores[2] == -1 ? "..." : scores[2].ToString() );
    }

    // Use this for initialization
    void Start() {
        text = GetComponent<Text>();
        scores.Add( -1 );
        scores.Add( -1 );
        scores.Add( -1 );
    }
}
