using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class CustomButton : MonoBehaviour {

    public UnityEvent OnEnter;

	void Start () {
	    if(OnEnter == null)
        {
            OnEnter = new UnityEvent();
        }
	}
	
	public void selectButton () {
        OnEnter.Invoke();
	}
}
