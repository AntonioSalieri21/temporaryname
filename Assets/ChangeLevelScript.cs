using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevelScript : MonoBehaviour
{
    [SerializeField] private string level;
    public void ChangeLevel()
    {
        SceneManager.LoadScene(level, LoadSceneMode.Additive);
    }
}
