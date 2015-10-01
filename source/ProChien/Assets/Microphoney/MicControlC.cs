using UnityEngine;
using System.Collections;

[RequireComponent( typeof( AudioSource ) )]
public class MicControlC : MonoBehaviour {

    public float sensitivity = 100;
    [Range( 0, 100 )]
    public float sourceVolume = 100;//Between 0 and 100
    public string selectedDevice { get; private set; }
    public float loudness { get; private set; }

    private bool micSelected = false;
    private int amountSamples = 256;
    private int minFreq, maxFreq;

    new private AudioSource audio;

    void Start() {
        audio = GetComponent<AudioSource>();

        audio.loop = true; 
        audio.mute = false; 
        selectedDevice = Microphone.devices[0].ToString();
        micSelected = true;
        GetMicCaps();
    }

    public void GetMicCaps() {
        Microphone.GetDeviceCaps( selectedDevice, out minFreq, out maxFreq );
        if ( ( minFreq + maxFreq ) == 0 )
            maxFreq = 44100;
    }

    public void StartMicrophone() {
        audio.clip = Microphone.Start( selectedDevice, true, 10, maxFreq );
        while ( !( Microphone.GetPosition( selectedDevice ) > 0 ) ) { } 
        audio.Play();
    }

    public void StopMicrophone() {
        audio.Stop();
        Microphone.End( selectedDevice );
    }

    float prev;
    float curr;
    public static float SoundVolumeValue = 0;

    void Update() {
        audio.volume = ( sourceVolume / 100 );

        curr = GetAveragedVolume() * sensitivity * ( sourceVolume / 10 );
        SoundVolumeValue = Mathf.Lerp( prev, curr, 0.5f );
        prev = curr;

        loudness = GetAveragedVolume() * sensitivity * ( sourceVolume / 10 );

        if ( !Microphone.IsRecording( selectedDevice ) ) {
            StartMicrophone();
        }
    }

    float GetAveragedVolume() {
        float[] data = new float[amountSamples];
        float a = 0;
        audio.GetOutputData( data, 0 );
        foreach ( float s in data ) {
            a += Mathf.Abs( s );
        }
        return a / amountSamples;
    }
}