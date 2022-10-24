using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;


[CreateAssetMenu(fileName = "Wiring", menuName = "RotorWiringConfiguration", order = 1)]
public class RotorWiring : ScriptableObject
{
    [SerializeField] private List<int> m_startIndicesValues;
    public List<int> StartIndices => m_startIndicesValues;

    //private List<int> m_initialStartIndices;


}
