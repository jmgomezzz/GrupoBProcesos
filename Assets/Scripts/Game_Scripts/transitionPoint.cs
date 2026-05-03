using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class transitionPoint : MonoBehaviour
{
    [SerializeField] private string sceneToGo;
    [SerializeField] private Vector2 playerSpawn;
    [SerializeField] private Animator fade;
    [SerializeField] private float transitionDelay = 1.0f;
    private Mouse_movement player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            fade.Play("FadeTransition");
            player = collision.GetComponent<Mouse_movement>();
            StartCoroutine(DelayFade());
        }
    }

    IEnumerator DelayFade()
    {
        yield return new WaitForSeconds(transitionDelay);
        player.moveInstantly(playerSpawn);
        SceneManager.LoadScene(sceneToGo, LoadSceneMode.Single);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
