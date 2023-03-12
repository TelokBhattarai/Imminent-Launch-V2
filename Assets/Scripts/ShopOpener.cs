using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class ShopOpener : MonoBehaviour
{
    public GameObject shopUI;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shopUI.SetActive(true);
        }
    }
}
