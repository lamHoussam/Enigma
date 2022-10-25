using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LightBulb : MonoBehaviour
{
    [SerializeField] private int m_letterIndex;

    public string KeyCharacter => GetComponentInChildren<TextMeshPro>().text;

}
