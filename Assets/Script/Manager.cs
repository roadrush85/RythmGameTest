using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour {

	public GameObject Note;

	public GameObject[] Line;

	Vector3 NotePos = new Vector3 (0f, 500f, 0);

	float[,] LineDelay = {{0.5f,1f,1f,0.2f,0.6f}, {0.5f,2f,1f,0.8f,0.3f}, {0.5f,3f,1f,2f,0.6f}, {1f,3f,0.1f,2f,0.6f}};

	int Point;
	int Combo;
	public Text Point_Text;
	// Use this for initialization
	public GameObject Dump;
	public GameObject [] Particle;
	public GameObject GameStart;
	private static Manager manager;

	public void G_Start()
	{
		for(int i = 0; i <4; i++)
			StartCoroutine (LineOne (i));
		GameStart.SetActive (false);
		StartCoroutine (ReStart ());
	}


	public static Manager GetInstance()
	{
		return manager;
	}

	void Awake()
	{
		manager = this;
	}

	public void PointCheck(int _point)
	{
		Point += _point;
		Point_Text.text = Point.ToString ();


	}

	void Start () {

	}



	IEnumerator LineOne(int _index)
	{
		for (int i = 0; i < 5; i++) {
			yield return new WaitForSeconds (LineDelay [_index,i]);
			GameObject Go = Instantiate (Note as GameObject);
			Go.transform.SetParent(Line[_index].transform);
			Go.transform.localPosition = NotePos;
			Go.transform.localScale = Vector3.one;
			Go.transform.GetComponent<Note> ().GameStart = true;
		}
	}

	IEnumerator ReStart()
	{
		yield return new WaitForSeconds (10f);
		GameStart.SetActive (true);
	}

	public void MakeNote(int _index)
	{
		GameObject Go = Instantiate (Note as GameObject);
		Debug.Log (Go);
		Go.transform.SetParent(Line[_index].transform);
		Go.transform.localPosition = NotePos;
		Go.transform.localScale = Vector3.one;
		Go.transform.GetComponent<Note> ().GameStart = true;
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Q)) {
			if (Line [0].transform.childCount > 0) 
			{
				Line [0].transform.GetChild(0).transform.GetComponent<Note> ().OnClick ();
				Particle[0].SetActive (false);
				Particle[0].SetActive (true);
				Line [0].transform.GetChild(0).transform.parent = Dump.transform;
			}
			//MakeNote (0);
		} else if (Input.GetKeyDown (KeyCode.W)) {
			if (Line [1].transform.childCount > 0) 
			{
				Line [1].transform.GetChild(0).transform.GetComponent<Note> ().OnClick ();
				Particle[1].SetActive (false);
				Particle[1].SetActive (true);
				Line [1].transform.GetChild(0).transform.parent = Dump.transform;
			}
			//MakeNote (1);
		} else if (Input.GetKeyDown (KeyCode.E)) {
			if (Line [2].transform.childCount > 0) 
			{
				Line [2].transform.GetChild(0).transform.GetComponent<Note> ().OnClick ();
				Particle[2].SetActive (false);
				Particle[2].SetActive (true);
				Line [2].transform.GetChild(0).transform.parent = Dump.transform;
			}
			//MakeNote (2);
		} else if (Input.GetKeyDown (KeyCode.R)) {
			if (Line [3].transform.childCount > 0) 
			{
				Line [3].transform.GetChild(0).transform.GetComponent<Note> ().OnClick ();
				Particle[3].SetActive (false);
				Particle[3].SetActive (true);
				Line [3].transform.GetChild(0).transform.parent = Dump.transform;
			}
			//MakeNote (3);
		}
	}
}
