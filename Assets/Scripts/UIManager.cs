using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject[] itemSlots;

    private void Start()
    {
        SelectSlot(0);
    }

    public void UpdateItems()
    {
        ClearUI();
        int indexer = 0;
        foreach(var item in Globals.instance.game.items)
        {
            itemSlots[indexer].transform.GetChild(0).GetComponent<Image>().sprite = item.sprite;
            itemSlots[indexer].transform.GetChild(0).GetComponent<Image>().color = new Color(255, 255, 255, 255);
            indexer++;
        }
    }

    private void ClearUI()
    {
        for(int i = 0; i < itemSlots.Length; i++)
        {
            itemSlots[i].transform.GetChild(0).GetComponent<Image>().sprite = null;
            itemSlots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(255, 255, 255, 0);
        }
    }

    private void ClearSelectedUI()
    {
        for(int i = 0; i < itemSlots.Length; i++)
        {
            itemSlots[i].transform.GetChild(1).gameObject.SetActive(false);
        }
    }

    private void SelectSlot(int slot)
    {
        ClearSelectedUI();
        itemSlots[slot].transform.GetChild(1).gameObject.SetActive(true);
        Globals.instance.game.selectedEqSlot = slot;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectSlot(0);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectSlot(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SelectSlot(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SelectSlot(3);
        }
    }
}
