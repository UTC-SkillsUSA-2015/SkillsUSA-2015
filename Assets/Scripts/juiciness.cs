using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class juiciness : MonoBehaviour {

    [SerializeField]
    float scaleObject;

    [SerializeField]
    float moveObject;

    Vector3 resetScale;
    Vector3 resetPosition;

    void Start()
    {
        resetScale = new Vector3(1.324974f, 0.9249583f, 2);
    }

    //void OnEnable ()
    //{
    //    transform.localScale = resetScale;
    //    transform.position -= new Vector3(moveObject, 0, 0);
    //}

    public void mouseOverChange()
    {
         transform.localScale += new Vector3(scaleObject, scaleObject, 0f);
        transform.position += new Vector3(moveObject, 0, 0);
    }

    public void resetChange()
    {
        transform.localScale = resetScale;
        transform.position -= new Vector3 (moveObject,0,0);
    }
}
