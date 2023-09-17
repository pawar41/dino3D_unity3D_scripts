using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class died_menu_overlap_setting : MonoBehaviour
{
    public GameObject otherMenu;

    void Update()
    {
        if (otherMenu.activeSelf) {
            otherMenu.SetActive(false);
        }
    }

}
