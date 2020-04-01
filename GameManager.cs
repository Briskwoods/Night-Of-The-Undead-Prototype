using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Animator GameOverAnimator;
    public Animator GameWinAnimator;
    private GameObject GameOverUI;
    private GameObject GameWinUI;
    private GameObject player;
    public Text timer;
    public Text counter;
    public int maxEnemies;

    public float timeLeft;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        player = GameObject.FindGameObjectWithTag("Player");   
        GameOverUI =GameObject.FindGameObjectWithTag("GameOverUI");
        GameOverUI.SetActive(false);
        GameWinUI =GameObject.FindGameObjectWithTag("WinGameUI");
        GameWinUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        timer.text = ""+(int)timeLeft;
        timeLeft -= Time.deltaTime;
        counter.text = "" + (maxEnemies-GameObject.Find("EnemyCnt").GetComponent<EnemyCountLimit>().count);
        if(int.Parse(counter.text)<=0){
            Win();
        }
        if (timeLeft<=0){
            GameOver();
        }        
    }
    public void Die(){
            player.SetActive(false);
            GameOver();
        }
    public void GameOver()
	    {
        Cursor.lockState = CursorLockMode.None;
        GameOverUI.SetActive(true);
        GameObject[] gameobjects = GameObject.FindGameObjectsWithTag("Enemy");
        for(int i = 0; i<gameobjects.Length; i++){
            Destroy(gameobjects[i]);
        }
        StartCoroutine("StopGame");
        }
    public void Win(){
        Cursor.lockState = CursorLockMode.None;
        GameWinUI.SetActive(true);
        player.SetActive(false);
        GameObject.Find("Enemies").SetActive(false);
        GameObject[] gameobjects = GameObject.FindGameObjectsWithTag("Enemy");
        for(int i = 0; i<gameobjects.Length; i++){
            Destroy(gameobjects[i]);
        }
        GameObject.Find("Timer").SetActive(false);
        StartCoroutine("StopGame");
        
    }
    IEnumerator StopGame(){
        yield return new WaitForSeconds(3);
        Time.timeScale = 0;
    }
}

