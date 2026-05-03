using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;


public class Open_Door1 : MonoBehaviour
{
    public GameObject[] plates;
    private Key_Logic[] plate_Logic = new Key_Logic[10];
    public GameObject[] resetPlates;
    private Key_Logic[] resetPlate_Logic = new Key_Logic[10];
    public int[] order;
    private int orderIndex = 0;

    private Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        if (plates.Length != 0)
        {
            for (int i = 0; i < plates.Length; i++)
            {
                plate_Logic[i] = plates[i].GetComponent<Key_Logic>();
                Debug.Log("Logica conectada");
            }
        }
        if (resetPlates.Length != 0)
        {
            for (int j = 0; j < resetPlates.Length; j++)
            {
                resetPlate_Logic[j] = resetPlates[j].GetComponent<Key_Logic>();
                Debug.Log("Logica Trampa conectada");
            }
        }
        checkIfOpened();
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
            resetPuzzle();
        }
        else
        {
            checkIfOpened();
        }
    }
    public void resetPuzzle()
    {
        for (int i = 0; i < plates.Length; i++)
        {
            plate_Logic[i].resetState();
        }
        Debug.Log("Puzzle reseteado");
        //this.GetComponent<Open_Door1>().enabled = true;
        this.GetComponent<BoxCollider2D>().enabled = true;
        anim.SetBool("IsOpen",false);

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
        if (!plateNotPressed || plates.IsUnityNull())
        {
            //anim.SetTrigger("Open");
            anim.SetBool("IsOpen", true);
            //this.GetComponent<Open_Door1>().enabled = false;
            this.GetComponent<BoxCollider2D>().enabled = false;
            //this.gameObject.SetActive(false);
        }
    }
}
