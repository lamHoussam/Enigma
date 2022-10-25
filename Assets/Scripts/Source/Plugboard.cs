using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Plugboard", menuName = "Plugboard", order = 1)]
public class Plugboard : ScriptableObject
{
    [SerializeField] private List<int> m_pairValues;

    public int GetEquivalent(int ind) { 
        return m_pairValues[ind];
    }
}
