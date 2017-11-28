using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiSoundRandom : MonoBehaviour {

    [SerializeField]
    private AudioClip[] TableSounds;

    private AudioSource audioSource;

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound()
    {
        if (audioSource != null)
        {
            int indexSoundRandom = Random.Range(0, TableSounds.Length);
            audioSource.clip = TableSounds[indexSoundRandom];
            audioSource.Play();
        }
    }

	
	// Update is called once per frame
	void Update () {
		
	}
}
