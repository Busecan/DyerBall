using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //level up

public class GameManager : MonoBehaviour
{
    public GameObject[] grounds;
    public float groundsNumbers;
    private int currentLevel;

    void Start()
    {
        grounds = GameObject.FindGameObjectsWithTag("Ground");
        currentLevel = SceneManager.GetActiveScene().buildIndex; //assigning the index of the current scene
    }

    void Update()
    {
        groundsNumbers = grounds.Length;
    }

    public void LevelUpdate()
    {
        SceneManager.LoadScene(currentLevel + 1);
    }
}
