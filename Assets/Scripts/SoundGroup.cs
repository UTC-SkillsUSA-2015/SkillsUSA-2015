using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;


[CreateAssetMenu(fileName = "Sound Group", menuName = "Sound Group")]
public class SoundGroup : ScriptableObject {
    [SerializeField]
    AudioClip[] clips;

    public AudioClip RandomClip {
        get {
            return clips[Random.Range (0, clips.Length)];
        }
    }

    public AudioClip[] Clips {
        get {
            return clips.Clone () as AudioClip[];
        }
    }

    public AudioClip this[int index] {
        get {
            return clips[index];
        }
    }
}
