using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ColliderToggle : MonoBehaviour {

    bool showColliders;

    [SerializeField]
    Toggle colliderviewState;

    [SerializeField]
    GameObject[] colliders;

    void Start()
    {
        colliders = GameObject.FindGameObjectsWithTag("CharacterCollider");
        ChangeBool();
    }

    void Update()
    {
        if (Input.GetButtonDown("BackButton"))
        {
            colliderviewState.isOn = !colliderviewState.isOn;
            ChangeBool();
        }
    }

    public void ChangeBool()
    {
        if (colliderviewState.isOn)
        {
            showColliders = true;
        } else
        {
            showColliders = false;
        }
        ChangeState();
    }

    void ChangeState()
    {
        for (int i = 0; i < colliders.Length; i++)
        {
            colliders[i].GetComponent<SpriteRenderer>().enabled = showColliders;
        }
    }
}
