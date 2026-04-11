using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;


public class Open_Door1 : MonoBehaviour
{
    public GameObject[] plates;
    private Key_Logic[] plate_Logic = new Key_Logic[10];
    public int[] order;
    private int orderIndex = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < plates.Length; i++)
        {
            plate_Logic[i] = plates[i].GetComponent<Key_Logic>();
            Debug.Log("Logica conectada");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void plateTriggered()
    {
        bool plateOrderOk = true;
        orderIndex = 0;

        for (int i = 0; i < plates.Length; i++)
        {
            if (plate_Logic[i].isPressed && i == order[orderIndex])
            {
                Debug.Log("Placa " + i + " Presionada correctamente");
                orderIndex++;
            }
            else if(plate_Logic[i].isPressed && i != order[orderIndex])
            {
                plateOrderOk = false;
            }
        }
        if (!plateOrderOk)
        {
            Debug.Log("Puzzle reseteado");
            resetPuzzle();
        }
        else
        {
            checkIfOpened();
        }
    }
    private void resetPuzzle()
    {
        for (int i = 0; i < plates.Length; i++)
        {
            plate_Logic[i].resetState();
        }
    }
    private void checkIfOpened()
    {
        bool plateNotPressed = false;
        for (int i = 0; i < plates.Length; i++)
        {
            if (!plate_Logic[i].isPressed)
            {
                plateNotPressed = true;
                break;
            }
        }
        if (!plateNotPressed)
        {
            this.GetComponent<Open_Door1>().enabled = false;
            this.GetComponent<BoxCollider2D>().enabled = false;
            this.gameObject.SetActive(false);
        }
    }
}
