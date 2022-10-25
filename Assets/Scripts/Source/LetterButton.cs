using TMPro;
using UnityEngine;


// TODO : inherit from class with same members
public class LetterButton : MonoBehaviour
{
    [SerializeField] private int m_letterIndex;
    public int LetterIndex => m_letterIndex;

    public string KeyCharacter => GetComponentInChildren<TextMeshPro>().text;

}
