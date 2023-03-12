using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundTrack : MonoBehaviour
{
    public AudioSource track;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void bgTrack()
    {
        track.Play();
    }
}
