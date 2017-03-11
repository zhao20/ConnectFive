using UnityEngine;
using System.Collections;

public class MouseClick : MonoBehaviour
{
	private int color = 1;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{

		transform.position = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0));

	}

	void OnTriggerStay2D (Collider2D other)
	{
		//Debug.Log ("I am inside of trigger");
		GameController GM = GameObject.Find ("Main Camera").GetComponent<GameController> ();
		ChessPieceController chessObj = other.gameObject.GetComponent<ChessPieceController> ();
		if (Input.GetMouseButtonDown (0) && chessObj.color == 0) {
			chessObj.color = color;

			GM.xAixs = chessObj.xAxis;
			GM.yAxis = chessObj.yAxis;
			//Debug.Log ("mouse click axis" + chessObj.xAxis + " " + chessObj.yAxis);
			GM.WinCheck ();
			color *= -1;

		}

	}
}
