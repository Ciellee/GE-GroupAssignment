using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour {

	public AudioSource SoundSource;
	public AudioClip Sounds;


	void OnTriggerEnter(Collider Other)
	{
		if (Other.tag == "Player" )
			{
			SoundSource.Play ();
			}
	}
		
}
