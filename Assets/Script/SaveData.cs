using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData: MonoBehaviour
{
    public Inventory inventory = new Inventory();

    private void Update()
    {
          if(Input.GetKeyDown(KeyCode.L))
        {
            LoadFromJson();
            Debug.Log("L");
        }

         if (Input.GetKeyDown(KeyCode.S))
        {
            SaveToJson();
            Debug.Log("S");
        }
    }

    public void SaveToJson()
    {
        string inventoryData = JsonUtility.ToJson(inventory);
        string filePath = Application.persistentDataPath + "/InventoryData.json";
        Debug.Log(filePath);
        System.IO.File.WriteAllText(filePath, inventoryData);
        Debug.Log("your data has been saved");
    }
    public void LoadFromJson()
    {
    string filePath = Application.persistentDataPath + "/InventoryData.json";
    string inventoryData = System.IO.File.ReadAllText(filePath);  

    inventory = JsonUtility.FromJson<Inventory>(inventoryData);
    }
}


    [System.Serializable]
    public class Inventory
    {
        public int goldCoin;
        public bool isFull;
        public List<Items> items = new List<Items>();
    }

    [System.Serializable]
    public class Items
    {
        public string name;
        public string desc;
    }
  

    
 