using UnityEngine;
using System.Collections;

public class ChessPieceController : MonoBehaviour
{
	public int color;
	public Sprite white, black, empty;

	public int  xAxis, yAxis;

	// Use this for initialization
	void Start ()
	{
		color = 0;
		transform.localScale = new Vector3 (0.35f, 0.35f, 1f);
	}
	
	// Update is called once per frame
	void Update ()
	{
		SpriteRenderer chess = gameObject.GetComponent<SpriteRenderer> ();
		if (color == 1) {

			chess.sprite = white;
		} else if (color == -1) {
			chess.sprite = black;
		} else {
			chess.sprite = empty;
		}
	}
}
