using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager instance;
    public GameObject[] persistentObjects;

    private void Awake()
    {
        if(instance != null)
        {
            cleanUpAndDestroy();
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            markPersistentObjects();
        }
    }

    private void markPersistentObjects()
    {
        foreach(GameObject obj in persistentObjects)
        {
            if(obj != null)
            {
                DontDestroyOnLoad (obj);
            }
        }
    }
    private void cleanUpAndDestroy()
    {
        foreach (GameObject obj in persistentObjects)
        {
            if (obj != null)
            {
                Destroy(obj);
            }
        }
        Destroy(gameObject);
    }
}
