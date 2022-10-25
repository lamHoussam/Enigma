using TMPro;
using UnityEngine;
using System.Collections.Generic;


public class Rotor : MonoBehaviour
{
    [SerializeField] private Rotor m_Next, m_Previous;
    public Rotor Next => m_Next;
    [SerializeField] private int m_currentValue;
    private TextMeshPro m_Text;

    [SerializeField] private RotorWiring m_Wiring;
    public RotorWiring Wiring => m_Wiring;

    [SerializeField] private Reflector m_Reflector;

    private Enigma m_Enigma;

    private List<int> m_startIndicesValues;

    private void Awake()
    {
        m_Enigma = GetComponentInParent<Enigma>();
        m_Text = GetComponentInChildren<TextMeshPro>();
        m_startIndicesValues = new List<int>();
        for (int i = 0; i < m_Wiring.StartIndices.Count; i++)
        {
            m_startIndicesValues.Add(m_Wiring.StartIndices[i]);
        }
        //m_startIndicesValues = m_Wiring.StartIndices;
    }

    private void Start()
    {
        m_Text.text = m_currentValue.ToString();

        for(int i = 0; i < m_currentValue; i++)
            IncrementPri();
    }

    public int MapStartIndexToEnd(int i) { return m_startIndicesValues[i]; }
    public int MapEndIndexToEnd(int i)
    {
        for (int k = 0; k < m_startIndicesValues.Count; k++)
        {
            if (m_startIndicesValues[k] == i) return k;
        }

        return -1;
    }

    private void IncrementPri() {
        int last = m_startIndicesValues[m_startIndicesValues.Count - 1];
        for (int i = m_startIndicesValues.Count - 1; i > 0; i--)
        {
            m_startIndicesValues[i] = m_startIndicesValues[i - 1];
        }

        m_startIndicesValues[0] = last;
    }

    public void Increment()
    {
        int last = m_startIndicesValues[m_startIndicesValues.Count - 1];
        for (int i = m_startIndicesValues.Count - 1; i > 0; i--)
        {
            m_startIndicesValues[i] = m_startIndicesValues[i - 1];
        }

        m_startIndicesValues[0] = last;

        m_currentValue++;
        if (m_currentValue >= 26)
        {
            m_currentValue = 0;
            if (m_Next)
                m_Next.Increment();
        }
        m_Text.text = m_currentValue.ToString();
    }


    public int Encode(int letter, bool goback = false)
    {

        int val;
        if (goback && this == m_Enigma.HeadRotor)
        {
            val = MapEndIndexToEnd(letter);
            return val;
        }

        if (m_Reflector != null)
        {
            val = MapStartIndexToEnd(letter);
            val = m_Reflector.MapStartIndexToEnd(val);
            val = MapEndIndexToEnd(val);

            return m_Previous.Encode(val, true);
        }
        else
        {
            if (goback)
            {
                val = MapEndIndexToEnd(letter);
                return m_Previous.Encode(val, true);
            }
            else
            {
                val = MapStartIndexToEnd(letter);
                return m_Next.Encode(val, false);
            }
        }
    }
}
