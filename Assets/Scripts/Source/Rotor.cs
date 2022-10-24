using System.ComponentModel;
using TMPro;
using UnityEngine;

public class Rotor : MonoBehaviour
{
    [SerializeField] private int m_currentValue;

    private readonly int m_limit = 26;

    private TextMeshPro m_Text;
    [SerializeField] private Rotor m_Next, m_Previous;
    public Rotor Next => m_Next;

    private Enigma m_Enigma;


    private void Awake()
    {
        m_Enigma = GetComponentInParent<Enigma>();
        m_Text = GetComponentInChildren<TextMeshPro>();
    }

    private void Start()
    {
        m_Text.text = m_currentValue.ToString();
    }

    

    public void Increment()
    {
        if(m_currentValue >= m_limit - 1)
        {
            m_currentValue = 0;
            if (m_Next)
                m_Next.Increment();
            else
                m_Enigma.HeadRotor.Increment();

        } else 
            m_currentValue++;

        m_Text.text = m_currentValue.ToString();
    }

    
}
