using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToOverworld : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(waitAndChange());
    }
    IEnumerator waitAndChange()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Overworld");
    }
}
