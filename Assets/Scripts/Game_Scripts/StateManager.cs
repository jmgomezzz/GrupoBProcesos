using UnityEngine;

public class StateManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Inventory playerInv;
    [SerializeField] public bool[] tabletsFound = new bool[4];
    [SerializeField] public int[] tabletKeys = new int[4];
    //private bool canPlayerMove;
    //[SerializeField] private bool[] doorsOpened;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerInv = player.GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //El sistema es un poco xd pero para lo que necesitamos funciona
    public bool checkIfPlateDiscovered(int tabletCode)
    {  
        for (int j = 0; j < tabletKeys.Length; j++)
        {
            if (tabletKeys[j] == tabletCode && !tabletsFound[j])
            {
                tabletsFound[j] = true;
                Debug.Log("Tablilla " + (j+1) + " encontrada");
                return false;
            }
            else if(tabletKeys[j] == tabletCode && tabletsFound[j])
            {
                Debug.Log("Tablilla " + (j + 1) + " ya fue encontrada previamente");
                return true;
            }
        }
        return false;
    }
}
