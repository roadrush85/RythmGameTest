using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour {

	float Speed;
	bool DesCheck;
	public bool GameStart;

	public void OnClick()
	{
		if (this.transform.localPosition.y > 0f) {
			Manager.GetInstance ().PointCheck (100);
		} else if (this.transform.localPosition.y > -100f) {
			Manager.GetInstance ().PointCheck (200);
		} else if (this.transform.localPosition.y > -180f) {
			Manager.GetInstance ().PointCheck (300);
		}
		Destroy (this.gameObject);
	}


	// Use this for initialization
	void Start () {
		Speed = -5f;
	}

	// Update is called once per frame
	void Update () {
		if (GameStart) {
			this.transform.localPosition += new Vector3 (0f, Speed, 0);

			if (this.transform.localPosition.y < -200f) {
				if (!DesCheck) {
					DesCheck = true;
					Destroy (this.gameObject);
				}
			}
		}
	}
}
