using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GM : MonoBehaviour {
	
	public int lives = 3;
	public int bricks = 66;
	public float resetDelay = 1f;
	public Text livesText;
	public GameObject gameOver;
	public GameObject youWon;
	public GameObject bricksPrefab;
	public GameObject paddle;
	public GameObject paddle2;
	public GameObject deathParticles;
	public static GM instance = null;
	
	private GameObject clonePaddle;
	private GameObject clonePaddle2;
	// Use this for initialization
	void Start () 
	{
		if (instance == null)
			instance = this;
		else if (instance != this) 
		
			Destroy (gameObject);
		
		Setup();
		
	}
	
	public void Setup()
	{
		clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
		clonePaddle2 = Instantiate(paddle2, transform.position, Quaternion.identity) as GameObject;
		Instantiate(bricksPrefab, transform.position, Quaternion.identity);
	}
	
	void CheckGameOver()
	{
		if (bricks < 1)
		{
			youWon.SetActive(true);
			Time.timeScale = .25f;
			Invoke ("Reset", resetDelay);
		}
		
		if (lives < 1)
		{
			gameOver.SetActive(true);
			Time.timeScale = .25f;
			Invoke ("Reset", resetDelay);
		}
		
	}
	
	void Reset()
	{
		Time.timeScale = 1f;
		Application.LoadLevel(Application.loadedLevel);
	}
	
	public void LoseLife()
	{
		lives--;
		livesText.text = "Lives: " + lives;
		Instantiate(deathParticles, clonePaddle.transform.position, Quaternion.identity);
		Instantiate(deathParticles, clonePaddle2.transform.position, Quaternion.identity);
		Destroy(clonePaddle);
		Destroy(clonePaddle2);
		Invoke ("SetupPaddle", resetDelay);
		Invoke ("SetupPaddle2", resetDelay);
		CheckGameOver();
	}
	
	void SetupPaddle()
	{
		clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
	}
	void SetupPaddle2()
	{
		clonePaddle2 = Instantiate(paddle2, transform.position, Quaternion.identity) as GameObject;
	}

	
	public void DestroyBrick()
	{
		bricks--;
		CheckGameOver();
	}
}