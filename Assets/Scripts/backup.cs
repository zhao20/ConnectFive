using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class backup : MonoBehaviour
{
	
	public GameObject prefab;
	public int xAixs, yAxis;
	public Text message;
	public Button btnMenu, btnNewGame;
	private GameObject[,] chessObj = new GameObject[19, 19];
	private int[,] white = new int[19, 19];
	private int[,] black = new int[19, 19];
	private int whiteMax, blackMax;
	
	int sum = 0;
	
	
	// Use this for initialization
	void Start ()
	{
		message.text = "";
		btnMenu.gameObject.SetActive (false);
		btnNewGame.gameObject.SetActive (false);
		for (int i =0; i<19; i++) {
			for (int j=0; j<19; j++) {
				
				Vector2 position = new Vector2 (i * 0.5f - 4.5f, j * 0.5f - 4.5f);
				chessObj [i, j] = Instantiate (prefab, position, Quaternion.identity)as GameObject;
				ChessPieceController chessControl = chessObj [i, j].GetComponent<ChessPieceController> ();
				chessControl.xAxis = i;
				chessControl.yAxis = j;
			}
		} 
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
	public void WinCheck ()
	{
		int color;
		sum = 1;
		ChessPieceController chessController = chessObj [xAixs, yAxis].GetComponent<ChessPieceController> ();
		color = chessController.color;
		//Debug.Log ("win check axis" + xAixs + " " + yAxis);
		sum = VerticalCheck (chessController, 1, color);
		
		if (sum > 4) {
			Debug.Log ((color > 0 ? "white" : "black") + " is win! in Vertical " + sum);
			message.text = (color > 0 ? "White" : "Black") + " Wins!!";
			btnMenu.gameObject.SetActive (true);
			btnNewGame.gameObject.SetActive (true);
		}
		
		sum = HorizantalCheck (chessController, 1, color);
		if (sum > 4) {
			Debug.Log ((color > 0 ? "white" : "black") + " is win! in horizantal " + sum);
			message.text = (color > 0 ? "White" : "Black") + " Wins!!";
			btnMenu.gameObject.SetActive (true);
			btnNewGame.gameObject.SetActive (true);
		}
		
		sum = RightSlopeCheck (chessController, 1, color);
		if (sum > 4) {
			Debug.Log ((color > 0 ? "white" : "black") + " is win! int right slope " + sum);
			message.text = (color > 0 ? "White" : "Black") + " Wins!!";
			btnMenu.gameObject.SetActive (true);
			btnNewGame.gameObject.SetActive (true);
		}
		sum = LeftSlopeCheck (chessController, 1, color);
		if (sum > 4) {
			Debug.Log ((color > 0 ? "white" : "black") + " is win! left slope " + sum);
			message.text = (color > 0 ? "White" : "Black") + " Wins!!";
			btnMenu.gameObject.SetActive (true);
			btnNewGame.gameObject.SetActive (true);
		}
	}
	
	public void ReloadGame ()
	{
		Application.LoadLevel (Application.loadedLevel);
		
	}
	
	public int   VerticalCheck (ChessPieceController chessController, int s, int color)
	{
		
		
		for (int i=1; i< 5; i++) {
			if (xAixs - i < 0) {
				break;
			}
			chessController = chessObj [xAixs - i, yAxis].GetComponent<ChessPieceController> ();
			if (chessController.color == color) {
				s++;
			} else {
				break;
			}
		}
		
		for (int i=1; i< 5; i++) {
			if (xAixs + i > 19) {
				break;
			}
			chessController = chessObj [xAixs + i, yAxis].GetComponent<ChessPieceController> ();
			if (chessController.color == color) {
				s++;
			} else {
				break;
			}
		}
		
		return s;
	}
	/* Horizontally check sum


	 */
	public int  HorizantalCheck (ChessPieceController chessController, int s, int color)
	{
		
		//left check
		for (int i=1; i< 5; i++) {
			if (yAxis - i < 0) {
				break;
			}
			chessController = chessObj [xAixs, yAxis - i].GetComponent<ChessPieceController> ();
			if (chessController.color == color) {
				s++;
			} else {
				break;
			}
		}
		
		//right check
		for (int i=1; i< 5; i++) {
			if (yAxis + i > 19) {
				break;
			}
			chessController = chessObj [xAixs, yAxis + i].GetComponent<ChessPieceController> ();
			if (chessController.color == color) {
				s++;
			} else {
				break;
			}
		}
		return s;
	}
	
	//Check right slope 
	public int RightSlopeCheck (ChessPieceController chessController, int s, int color)
	{
		
		
		for (int i=1; i< 5; i++) {
			if (yAxis - i < 0 || xAixs - i < 0) {
				break;
			}
			chessController = chessObj [xAixs - i, yAxis - i].GetComponent<ChessPieceController> ();
			if (chessController.color == color) {
				s++;
			} else {
				break;
			}
		}
		for (int i=1; i< 5; i++) {
			if (yAxis + i > 19 || xAixs + i > 19) {
				break;
			}
			chessController = chessObj [xAixs + i, yAxis + i].GetComponent<ChessPieceController> ();
			if (chessController.color == color) {
				s++;
			} else {
				break;
			}
		}
		return s;
	}
	
	
	//Check left slope 
	public int LeftSlopeCheck (ChessPieceController chessController, int s, int color)
	{
		
		
		for (int i=1; i< 5; i++) {
			if (yAxis - i < 0 || yAxis + i > 19) {
				break;
			}
			chessController = chessObj [xAixs - i, yAxis + i].GetComponent<ChessPieceController> ();
			if (chessController.color == color) {
				s++;
			} else {
				break;
			}
		}
		for (int i=1; i< 5; i++) {
			if (xAixs + i > 19 || yAxis - i < 0) {
				break;
			}
			chessController = chessObj [xAixs + i, yAxis - i].GetComponent<ChessPieceController> ();
			if (chessController.color == color) {
				s++;
			} else {
				break;
			}
		}
		return s;
	}
	
	/*Computer will select the high score to put its chess
	 *
	 *
	 */
	public void AIMove ()
	{
		string a = "";
		
		int whiteMaxXAxis = 0, whiteMaxYAxis = 0, blackMaxXAxis = 0, blackMaxYAxis = 0;
		whiteMax = 0;
		//blackMax = 0;
		//WhiteUpdate ();
		//BlackUpdate ();
		white [xAixs, yAxis] = 0;
		WhiteUpdate (xAixs, yAxis);
		BlackUpdate (xAixs, yAxis);
		
		//Debug.Log ("I am inside of ai.");
		for (int i =0; i< 19; i++) {
			for (int j= 0; j< 19; j++) {
				if (white [i, j] > whiteMax && chessObj [whiteMaxXAxis, whiteMaxYAxis].GetComponent<ChessPieceController> ().color == 0) {
					whiteMax = white [i, j];
					whiteMaxXAxis = i;
					whiteMaxYAxis = j;
				}
				a = a + " " + white [i, j];
			}
			Debug.Log (i + a);
			a = "";
		}
		Debug.Log ("I am inside of ai." + whiteMax + " " + whiteMaxXAxis + " " + whiteMaxYAxis);
		
		if (chessObj [whiteMaxXAxis, whiteMaxYAxis].GetComponent<ChessPieceController> ().color == 0) {
			
			chessObj [whiteMaxXAxis, whiteMaxYAxis].GetComponent<ChessPieceController> ().color = -1;
		}
		
		
		
		
		
		
	}
	void WhiteUpdate (int x, int y)
	{
		
		ChessPieceController chess = chessObj [x, y].GetComponent<ChessPieceController> ();
		WhiteVerticalUpdate (chess, 1f, 1);
		
		
		WhiteHorizantalUpdate (chess, 1f, 1);
		
		
		WhiteRightSlopeUpdate (chess, 1f, 1);
		
		WhiteLeftSlopeUpdate (chess, 1f, 1);
		
		
	}
	
	
	public void   WhiteVerticalUpdate (ChessPieceController chessController, float s, int color)
	{
		int preX = -1, preY = -1;
		
		for (int i=1; i< 5; i++) {
			if (xAixs - i < 0) {
				break;
			}
			chessController = chessObj [xAixs - i, yAxis].GetComponent<ChessPieceController> ();
			if (chessController.color == color) {
				s++;
			} else if (chessController.color == 0) {
				preX = xAixs - i;
				preY = yAxis - i;
			} else {
				break;
			}
		}
		
		for (int i=1; i< 5; i++) {
			if (xAixs + i > 19) {
				break;
			}
			chessController = chessObj [xAixs + i, yAxis].GetComponent<ChessPieceController> ();
			if (chessController.color == color) {
				s++;
			} else {
				Debug.Log (xAixs + i + " " + yAxis);
				if (chessController.color == 0) {
					white [xAixs + i, yAxis] += (int)Mathf.Pow (2f, s);
				}
				if ((preX > -1 && preY > -1) && chessObj [preX, preY].GetComponent<ChessPieceController> ().color == 0) {
					white [preX, preY] += (int)Mathf.Pow (2f, s);
				}
				break;
			}
		}
		
	}
	
	/* Horizontally check sum


	 */
	public void  WhiteHorizantalUpdate (ChessPieceController chessController, float s, int color)
	{
		int preX = -1, preY = -1;
		
		//left check
		for (int i=1; i< 5; i++) {
			if (yAxis - i < 0) {
				break;
			}
			chessController = chessObj [xAixs, yAxis - i].GetComponent<ChessPieceController> ();
			if (chessController.color == color) {
				s++;
			} else if (chessController.color == 0) {
				preX = xAixs - i;
				preY = yAxis - i;
			} else {
				break;
			}
		}
		
		//right check
		for (int i=1; i< 5; i++) {
			if (yAxis + i > 19) {
				break;
			}
			chessController = chessObj [xAixs, yAxis + i].GetComponent<ChessPieceController> ();
			if (chessController.color == color) {
				s++;
			} else {
				if (chessController.color == 0) {
					white [xAixs + i, yAxis] += (int)Mathf.Pow (2f, s);
				}
				//Debug.Log ("x + Y :" + preX + " " + preY);
				if ((preX > -1 && preY > -1) && chessObj [preX, preY].GetComponent<ChessPieceController> ().color == 0) {
					white [preX, preY] += (int)Mathf.Pow (2f, s);
				}
				
				break;
			}
		}
	}
	
	//Check right slope 
	public void WhiteRightSlopeUpdate (ChessPieceController chessController, float s, int color)
	{
		
		int preX = -1, preY = -1;
		
		for (int i=1; i< 5; i++) {
			if (yAxis - i < 0 || xAixs - i < 0) {
				break;
			}
			chessController = chessObj [xAixs - i, yAxis - i].GetComponent<ChessPieceController> ();
			if (chessController.color == color) {
				s++;
			} else if (chessController.color == 0) {
				preX = xAixs - i;
				preY = yAxis - i;
			} else {
				
				break;
			}
		}
		for (int i=1; i< 5; i++) {
			if (yAxis + i > 19 || xAixs + i > 19) {
				break;
			}
			chessController = chessObj [xAixs + i, yAxis + i].GetComponent<ChessPieceController> ();
			if (chessController.color == color) {
				s++;
			} else {
				if (chessController.color == 0) {
					white [xAixs + i, yAxis] += (int)Mathf.Pow (2f, s);
				}
				if ((preX > -1 && preY > -1) && chessObj [preX, preY].GetComponent<ChessPieceController> ().color == 0) {
					white [preX, preY] += (int)Mathf.Pow (2f, s);
				}
				
				break;
			}
		}
	}
	
	
	//Check left slope 
	public void WhiteLeftSlopeUpdate (ChessPieceController chessController, float s, int color)
	{
		int preX = -1, preY = -1;
		
		for (int i=1; i< 5; i++) {
			if (yAxis - i < 0 || yAxis + i > 19) {
				break;
			}
			chessController = chessObj [xAixs - i, yAxis + i].GetComponent<ChessPieceController> ();
			if (chessController.color == color) {
				s++;
			} else if (chessController.color == 0) {
				preX = xAixs - i;
				preY = yAxis - i;
			} else {
				break;
			}
		}
		for (int i=1; i< 5; i++) {
			if (xAixs + i > 19 || yAxis - i < 0) {
				break;
			}
			chessController = chessObj [xAixs + i, yAxis - i].GetComponent<ChessPieceController> ();
			if (chessController.color == color) {
				s++;
			} else {
				if (chessController.color == 0) {
					white [xAixs + i, yAxis] += (int)Mathf.Pow (2f, s);
				}
				if ((preX > -1 && preY > -1) && chessObj [preX, preY].GetComponent<ChessPieceController> ().color == 0) {
					white [preX, preY] += (int)Mathf.Pow (2f, s);
				}
				
				break;
			}
		}
	}
	
	void BlackUpdate (int x, int y)
	{
		
		
		ChessPieceController chess = chessObj [x, y].GetComponent<ChessPieceController> ();
		WhiteVerticalUpdate (chess, 1f, -1);
		
		WhiteHorizantalUpdate (chess, 1f, -1);
		
		WhiteRightSlopeUpdate (chess, 1f, -1);
		
		WhiteLeftSlopeUpdate (chess, 1f, -1);
		
		
	}
	
	
	
	
}
