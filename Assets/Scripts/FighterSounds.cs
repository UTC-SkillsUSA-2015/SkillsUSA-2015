using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Fighter Soundset", menuName = "Fighter Soundset")]
public class FighterSounds : ScriptableObject {
    [SerializeField]
    AudioClip[] jump;
    [SerializeField]
    AudioClip[] hit;
    [SerializeField]
    AudioClip[] death;

    public AudioClip randomJump {
        get {
            return randomSound(jump);
        }
    }

    public AudioClip randomHit {
        get {
            return randomSound(hit);
        }
    }

    public AudioClip randomDeath {
        get {
            return randomSound (death);
        }
    }

    AudioClip randomSound(AudioClip[] clips) {
        return clips[Random.Range (0, clips.Length)];
    }
}
