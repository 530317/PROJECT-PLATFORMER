using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using XboxCtrlrInput;

public class ItemSelector : MonoBehaviour
{
    public GameObject[] boots;

    public int inventorySize;

    public int maxInventorySize;
    public int minInventorySize;

    private void Start()
    {
        maxInventorySize = 4;
        minInventorySize = 0;
    }

    void Update()
    {
        SelectItem();
    }
    private void SelectItem()
    {
        if(XCI.GetButtonDown(XboxButton.RightBumper))
        {
            inventorySize++;

            if(inventorySize >=  maxInventorySize)
            {
                inventorySize = 0;
            }
        }

        if (XCI.GetButtonDown(XboxButton.LeftBumper))
        {
            inventorySize--;

            if (inventorySize <= minInventorySize)
            {
                inventorySize = 4;
            }
        }
        if(inventorySize == 0)
        {
            boots[0].SetActive(true);
        }
        else
        {
            boots[0].SetActive(false);
            boots[1].SetActive(true);
            boots[2].SetActive(false);
        }

        if(inventorySize == 1)
        {
            boots[1].SetActive(true);
        }
        else
        {
            boots[1].SetActive(true);
        }

        if(inventorySize == 2)
        {
            boots[2].SetActive(true);
        }
        else
        {
            boots[2].SetActive(false);

        }
        if(inventorySize == 3)
        {
            for (int i = 0; i < boots.Length; i++)
            {
                boots[i].SetActive(false);
            }
        }

    }
}
