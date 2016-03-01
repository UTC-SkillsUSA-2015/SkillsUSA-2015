using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class juiciness : MonoBehaviour {

    [SerializeField]
    float scaleObject;

    [SerializeField]
    float moveObject;

    [SerializeField]
    GameObject self;

    Vector3 resetScale;

    [SerializeField]
    Vector3 resetPosition;

    void Start()
    {
        resetScale = new Vector3(1.324974f, 0.9249583f, 2);
        resetPosition = self.transform.position;
        resetChange();
    }

    //void OnEnable()
    //{
    //    resetChange();
    //}

    public void mouseOverChange()
    {
        transform.localScale += new Vector3(scaleObject, scaleObject, 0f);
        transform.position += new Vector3(moveObject, 0, 0);
    }

    public void resetChange()
    {
        transform.localScale = resetScale;
        transform.position = resetPosition;
    }
}
