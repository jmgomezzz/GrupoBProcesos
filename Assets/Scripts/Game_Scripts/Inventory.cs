using UnityEngine;

public class Inventory : MonoBehaviour
{
    public ItemLogic[] inventory;
    public StateManager stateManager;

    public void AddItem(ItemLogic item)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == null)
            {
                if (item.tabletCode != 0)
                {
                    if (!stateManager.checkIfPlateDiscovered(item.tabletCode))
                    {
                        inventory[i] = item;
                        Debug.Log("The thing happened but with style");
                        break;
                    }
                    else
                    {
                        Debug.Log("La tableta ya fue descubierta, por lo que no se añadio");
                    }
                }
                else if(item.tabletCode == 0)
                {
                    inventory[i] = item;
                    Debug.Log("The thing happened");
                    break;
                }
                
            }
        } 
    }
        public ItemLogic CombineItems(int index1, int index2)
    {
        ItemLogic item1 = inventory[index1];
        ItemLogic item2 = inventory[index2];
        
        // Verificar que ambos items existen
        if (item1 == null || item2 == null)
        {
            Debug.Log("Uno de los items no existe");
            return null;
        }
        
        // Verificar que ambos son combinables
        if (!item1.isCombinable || !item2.isCombinable)
        {
            Debug.Log("Estos items no son combinables");
            return null;
        }
        
        // Verificar compatibilidad usando las keys
        if (!AreItemsCompatible(item1, item2))
        {
            Debug.Log("Estos items no se pueden combinar entre sí");
            return null;
        }
        
        // Crear el item resultante basándose en la combinación
        ItemLogic resultItem = GetCombinationResult(item1.combinationKey, item2.combinationKey);
        
        if (resultItem != null)
        {
            // Eliminar los items originales del inventario
            inventory[index1] = null;
            inventory[index2] = null;
            
            // Agregar el nuevo item
            AddItem(resultItem);
            
            Debug.Log($"Combinación exitosa: {resultItem.itemName}");
        }
        
        return resultItem;
    }
    private bool AreItemsCompatible(ItemLogic item1, ItemLogic item2)
    {
        // Verificar si item1 es compatible con item2
        foreach (char key in item1.combinationKey)
        {
            if (key.ToString() == item2.combinationKey)
                return true;
        }
        return false;
    }
    private ItemLogic GetCombinationResult(string key1, string key2)
    {
        // Aquí puedes definir las combinaciones y sus resultados
        if (key1 == "KeyA" && key2 == "KeyB")
        {
            // Crear un nuevo item resultante de la combinación
            ItemLogic result = new ItemLogic();
            result.itemName = "CombinedItem";
            result.isCombinable = false; // El resultado no es combinable
            return result;
        }
        // Agrega más combinaciones según sea necesario
        return null;
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
