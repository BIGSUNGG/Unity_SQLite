using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;

public class TestScene : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ItemTableSelectAll();
        ItemTableSelect(1);
    }

    // Update is called once per frame
    void Update()
    {

    }

    #region ItemTable
    void ItemTableSelectAll()
    {
        List<ItemGateWay> result = ItemGateWay.SelectAll();

        if (result != null)
        {
            Debug.Log("DB Select All Query Success");

            foreach (var item in result)
            {
                Debug.Log(JsonConvert.SerializeObject(item));
            }
        }
    }

    void ItemTableSelect(int selectId)
    {
        ItemGateWay result = ItemGateWay.Select(selectId);

        if(result != null)
        {
            Debug.Log($"DB Select {selectId} Query Success");
            Debug.Log(JsonConvert.SerializeObject(result));
        }
    }
    #endregion
}
