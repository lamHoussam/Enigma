using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Reflector", menuName = "Reflector", order = 1)]
public class Reflector : ScriptableObject
{
    [SerializeField] private List<int> m_startIndicesValues;

    public int MapStartIndexToEnd(int i) { return m_startIndicesValues[i]; }
}
