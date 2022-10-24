using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wiring", menuName = "RotorWiringConfiguration", order = 1)]
public class RotorWiring : ScriptableObject
{
    [SerializeField] private int[] m_endValues;

    public int GetValue(int ind) { return m_endValues[ind]; }


    private List<int> m_values;
    public void MakeEndValues()
    {
        m_values = new List<int>();
        m_endValues = new int[26];
        
        for (int i = 0; i < 26; i++)
        {
            m_values.Add(i);
        }

        for(int i = 0; i < 26; i += 2)
        {
            int ind, val;
            ind = Random.Range(0, m_values.Count);

            int ind1 = m_values[ind];
            m_values.Remove(m_values[ind]);
            val = Random.Range(0, m_values.Count);
            int ind2 = m_values[val];
            m_values.Remove(m_values[val]);

            m_endValues[ind1] = ind2;
            m_endValues[ind2] = ind1;
        }

    }

    public bool CheckWiring()
    {
        if (m_endValues.Length != 26) return false;

        for (int i = 0; i < m_endValues.Length; i++)
        {
            if (m_endValues[i] >= 26 || i != m_endValues[m_endValues[i]]) return false;
        }

        return true;
    }
}