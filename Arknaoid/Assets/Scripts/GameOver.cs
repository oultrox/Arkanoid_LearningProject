using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    [SerializeField] private GameObject manager;
    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject spacebarText;
    LevelManager levelManager;

    //-------Métodos API--------

    // Use this for initialization
    void Start ()
    {

        //Se busca por referencia el objeto persistente.
        manager = GameObject.FindGameObjectWithTag("GameManager");
        //Se referencia el elemento necesitado para realizar las operaciones necesarias.
        levelManager = manager.GetComponent<LevelManager>();
        int score = levelManager.GetPlayerScore();
        scoreText.text = "Score: " + score;
        StartCoroutine(BlinkText());
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Destroy(manager);
            SceneManager.LoadScene(0);
        }
    }
    IEnumerator BlinkText()
    {
        spacebarText.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        spacebarText.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(BlinkText());
    }
}
