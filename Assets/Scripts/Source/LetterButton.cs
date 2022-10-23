using UnityEngine;

public class LetterButton : MonoBehaviour
{
    [SerializeField] private int m_letterIndex;
    private Enigma m_Enigma;

    public void Awake()
    {
        m_Enigma = GetComponentInParent<Enigma>();
    }

    public void OnClick()
    {
        Debug.Log(m_letterIndex);
    }
}
