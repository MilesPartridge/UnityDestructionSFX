using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructionSFX : MonoBehaviour
{
    /*
    public string rtpcName;
    public string rtpcName2;
    public string rtpcName3;
    public string rtpcName4;
    public string rtpcName5;
    public string rtpcName6;
    uint eventID = 0;
    
    

    // Update is called once per frame
    void Update()
    {
        
    }
    */
    //find scale of parent
    private Vector3 scaleOfParent = new Vector3(0.3f, 0.3f, 0.3f);
    
    private float volume;
    
    //private bool myswitch = true;
    
    
    // Start is called before the first frame update
    void Start()
    {
        scaleOfParent = transform.parent.parent.transform.localScale;
        
        volume = 100.0f;
    }
    
    void OnCollisionEnter(Collision collision){
        if (collision.relativeVelocity.magnitude > 2)
        {
            volume = 100.0f;
            AkSoundEngine.SetRTPCValue("Amount", volume, gameObject);
            AkSoundEngine.SetRTPCValue("BandPassRange", Random.Range((scaleOfParent.y * 165.0f) - 10, (scaleOfParent.y * 165.0f) + 10), gameObject);
            AkSoundEngine.SetRTPCValue("Mass", Random.Range((scaleOfParent.y * 165.0f) - 5, scaleOfParent.y * 165.0f), gameObject);
            AkSoundEngine.SetRTPCValue("Granulation", Random.Range((scaleOfParent.y * 165.0f) - 10, (scaleOfParent.y * 165.0f) + 10), gameObject);
            AkSoundEngine.PostEvent("DebrisPD", gameObject);
            
        }
        
    }
    
    void OnCollisionStay(Collision collision)
    {
        AkSoundEngine.SetRTPCValue("Velocity", Random.Range((scaleOfParent.y * 165.0f) - 15, (scaleOfParent.y * 165.0f) + 15), gameObject);
        AkSoundEngine.SetRTPCValue("BandPassReso", Random.Range((scaleOfParent.y * 165.0f) - 15, (scaleOfParent.y * 165.0f) + 15), gameObject);
        AkSoundEngine.SetRTPCValue("Amount", volume, gameObject);
        volume *= 0.9f;               // make the volume trail off, get some sounds that keep firing pointlessly and this mitigates that
    }
    
    void OnCollisionExit()
    {
        // aK stop event
        AkSoundEngine.PostEvent("StopDebrisPD", gameObject);
    }
}
