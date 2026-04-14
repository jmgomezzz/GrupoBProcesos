using Unity.VisualScripting;
using UnityEngine;

public class ItemLogic : MonoBehaviour
{
    public Inventory PlayerInv;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Truly incredible");

            PlayerInv.AddItem(this.GetComponent<ItemLogic>());
            this.GetComponent<Collider2D>().enabled = false;
            this.gameObject.SetActive(false);
        }
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
