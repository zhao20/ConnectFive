using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour
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
				white [i, j] = 0;
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
			if (xAixs + i > 18) {
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
			if (yAxis + i > 18) {
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
			if (yAxis + i > 18 || xAixs + i > 18) {
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
			if (xAixs - i < 0 || yAxis + i > 18) {
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
			if (xAixs + i > 18 || yAxis - i < 0) {
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


		//Debug.Log ("I am inside of ai.");
		for (int i =0; i< 19; i++) {
			for (int j= 0; j< 19; j++) {
				if (white [i, j] > whiteMax && chessObj [i, j].GetComponent<ChessPieceController> ().color == 0) {
					Debug.Log ("max is " + i + " " + j);
					whiteMax = white [i, j];
					whiteMaxXAxis = i;
					whiteMaxYAxis = j;
				}
				//a = a + " " + white [i, j];
			}
			//Debug.Log (i + a);
			//a = "";
		}
		Debug.Log ("I am inside of ai." + whiteMax + " " + whiteMaxXAxis + " " + whiteMaxYAxis);

		//if (chessObj [whiteMaxXAxis, whiteMaxYAxis].GetComponent<ChessPieceController> ().color == 0) {

		chessObj [whiteMaxXAxis, whiteMaxYAxis].GetComponent<ChessPieceController> ().color = -1;
		white [whiteMaxXAxis, whiteMaxYAxis] = 0;
		xAixs = whiteMaxXAxis;
		yAxis = whiteMaxYAxis;
		WinCheck ();
		BlackUpdate (whiteMaxXAxis, whiteMaxYAxis);
		




	

	}
	void WhiteUpdate (int x, int y)
	{

		ChessPieceController chess = chessObj [x, y].GetComponent<ChessPieceController> ();
		VerticalUpdate (chess, 1, 1);

			
		HorizantalUpdate (chess, 1, 1);

		
		RightSlopeUpdate (chess, 1, 1);

		LeftSlopeUpdate (chess, 1, 1);


	}
	
	void BlackUpdate (int x, int y)
	{
	
		ChessPieceController chess = chessObj [x, y].GetComponent<ChessPieceController> ();
		VerticalUpdate (chess, 1, -1);
		
		
		HorizantalUpdate (chess, 1, -1);
		
		
		RightSlopeUpdate (chess, 1, -1);
		
		LeftSlopeUpdate (chess, 1, -1);
	
			
	}


	public void   HorizantalUpdate (ChessPieceController chessController, int s, int color)
	{
		int preX = -1, preY = -1;
		int x, y;
		x = chessController.xAxis;
		y = chessController.yAxis;
		for (int i=1; i< 5; i++) {
			if (x - i < 0) {
				break;
			}
			chessController = chessObj [x - i, y].GetComponent<ChessPieceController> ();
			if (chessController.color == color) {
				s++;
			} else {
				Debug.Log (x - i + " " + y);
				preX = x - i;
				preY = y;
			
				break;
			}
		}
		
		for (int i=1; i< 5; i++) {
			if (x + i > 18) {
				break;
			}
			chessController = chessObj [x + i, y].GetComponent<ChessPieceController> ();
			if (chessController.color == color) {
				s++;
			} else {
				if (chessController.color == 0) {
					Debug.Log (x + i + " " + y);

					white [x + i, y] += rule (s);
				}

				if ((preX > -1 && preY > -1) && chessObj [preX, preY].GetComponent<ChessPieceController> ().color == 0) {
					white [preX, preY] += rule (s);
				}
			
				break;
			}
		}

	}

	/* Horizontally check sum


	 */
	public void VerticalUpdate (ChessPieceController chessController, int s, int color)
	{
		int preX = -1, preY = -1;
		int x, y;
		x = chessController.xAxis;
		y = chessController.yAxis;
		//left check
		for (int i=1; i< 5; i++) {
			if (y - i < 0) {
				break;
			}
			chessController = chessObj [x, y - i].GetComponent<ChessPieceController> ();
			if (chessController.color == color) {
				s++;
			} else {
				preX = x;
				preY = y - i;
				break;
			}
		}
		
		//right check
		for (int i=1; i< 5; i++) {
			if (y + i > 18) {
				break;
			}
			chessController = chessObj [x, y + i].GetComponent<ChessPieceController> ();
			if (chessController.color == color) {
				s++;
			} else {
				if (chessController.color == 0) {
					white [x, y + i] += rule (s);
				}
				//Debug.Log ("x + Y :" + preX + " " + preY);
				if ((preX > -1 && preY > -1) && chessObj [preX, preY].GetComponent<ChessPieceController> ().color == 0) {
					white [preX, preY] += rule (s);
				}

				break;
			}
		}
	}
	
	//Check right slope 
	public void LeftSlopeUpdate (ChessPieceController chessController, int s, int color)
	{
		
		int preX = -1, preY = -1;
		int x, y;
		x = chessController.xAxis;
		y = chessController.yAxis;

		for (int i=1; i< 5; i++) {
			if (y - i < 0 || x - i < 0) {
				break;
			}
			chessController = chessObj [x - i, y - i].GetComponent<ChessPieceController> ();
			if (chessController.color == color) {
				s++;
			} else {
				preX = x - i;
				preY = y - i;
				break;
			}
		}
		for (int i=1; i< 5; i++) {
			if (y + i > 18 || x + i > 18) {
				break;
			}
			chessController = chessObj [x + i, y + i].GetComponent<ChessPieceController> ();
			if (chessController.color == color) {
				s++;
			} else {
				if (chessController.color == 0) {
					white [x + i, y + i] += rule (s);
				}
				if ((preX > -1 && preY > -1) && chessObj [preX, preY].GetComponent<ChessPieceController> ().color == 0) {
					white [preX, preY] += rule (s);
				}

				break;
			}
		}
	}
	
	
	//Check left slope 
	public void  RightSlopeUpdate (ChessPieceController chessController, int s, int color)
	{
		int preX = -1, preY = -1;
		int x, y;
		x = chessController.xAxis;
		y = chessController.yAxis;

		for (int i=1; i< 5; i++) {
			if (x - i < 0 || y + i > 18) {
				break;
			}
			chessController = chessObj [x - i, y + i].GetComponent<ChessPieceController> ();
			if (chessController.color == color) {
				s++;
			} else {
				preX = x - i;
				preY = y + i;
		
				break;
			}
		}
		for (int i=1; i< 5; i++) {
			if (x + i > 18 || y - i < 0) {
				break;
			}
			chessController = chessObj [x + i, y - i].GetComponent<ChessPieceController> ();
			if (chessController.color == color) {
				s++;
			} else {
				if (chessController.color == 0) {
					white [x + i, y - i] += rule (s);
				}
				if ((preX > -1 && preY > -1) && chessObj [preX, preY].GetComponent<ChessPieceController> ().color == 0) {
					white [preX, preY] += rule (s);
				}

				break;
			}
		}
	}


	public int rule (int s)
	{
		if (s == 1)
			return 10;
		else if (s == 2)
			return 1000;
		else if (s == 3)
			return 10000;
		else
			return 1000000;

	}


}
