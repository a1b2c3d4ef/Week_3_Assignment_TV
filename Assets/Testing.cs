using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Testing : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI a;

    private void Start()
    {
        a.text = "Mario";
        print("Test");
    }
}
