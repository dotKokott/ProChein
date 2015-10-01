using UnityEngine;
using System.Collections;

public class TheArm : MonoBehaviour {

    public bool Pulling = false;

    public MicControlC control;

    public AudioClip DumbbellSound;

    public GameObject Explosion;

    void Start() {
        control = Camera.main.GetComponent<MicControlC>();
    }

    // Update is called once per frame
    void Update() {
        if ( !Pulling && Input.GetKeyDown( KeyCode.Space ) ) {
            iTween.RotateTo( gameObject, iTween.Hash( "z", ( 115f / 100f ) * Mathf.Clamp( MicControlC.SoundVolumeValue / 2, 0, 100 ), "time", 1, "easetype", iTween.EaseType.easeOutBack, "oncomplete", "onComplete" ) );
            GameObject.Find( "Scoretext" ).GetComponent<TheScore>().doit();
            Pulling = true;
            iTween.ShakePosition( GameObject.Find( "chi" ), ( new Vector3( 0.2f, 0.2f ) / 100f ) * MicControlC.SoundVolumeValue / 2, 1 );

            if ( MicControlC.SoundVolumeValue > 300 ) {
                GameObject.Find( "Fireworks" ).GetComponent<ParticleSystem>().Emit( 10 );

            }

            if ( MicControlC.SoundVolumeValue > 500 ) {
                Explosion.SetActive( true );
            }

            Camera.main.GetComponent<AudioSource>().PlayOneShot( DumbbellSound );

            Debug.Log( MicControlC.SoundVolumeValue );
        }
    }

    public void onComplete() {
        iTween.RotateTo( gameObject, iTween.Hash( "z", 0, "time", 1, "easetype", iTween.EaseType.easeOutBack ) );
        StartCoroutine( WaitForDown( 1 ) );
    }

    public IEnumerator WaitForDown( float time ) {
        yield return new WaitForSeconds( time );

        Pulling = false;
        Explosion.SetActive( false );
    }
}
