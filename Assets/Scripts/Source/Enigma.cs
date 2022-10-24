using UnityEngine;

public class Enigma : MonoBehaviour
{
    [SerializeField] private Material m_onMat;
    private Material m_offMat;

    private LightBulb[] m_lightBulbs;
    private LetterButton[] m_letterButtons;

    private LightBulb m_previousLitBulb = null;

    [SerializeField] private Rotor m_HeadRotor;
    public Rotor HeadRotor => m_HeadRotor;

    [SerializeField] private RotorWiring[] m_RotorWirings;

    public void Awake()
    {
        m_lightBulbs = GetComponentsInChildren<LightBulb>();
        m_letterButtons = GetComponentsInChildren<LetterButton>();

        //PrintWiring();

        m_offMat = m_lightBulbs[0].GetComponent<MeshRenderer>().material;

        foreach (RotorWiring wiring in m_RotorWirings)
            if (!wiring || !wiring.CheckWiring())
                Debug.LogError("Check wiring : " + wiring);
    }

    // To Generate random wiring

    //private void Start()
    //{
    //    for(int i = 0; i < m_RotorWirings.Length; i++)
    //        m_RotorWirings[i].MakeEndValues();
    //}

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if(hit.transform.TryGetComponent(out LetterButton button))
                {
                    button.OnClick();

                    //int encoded = m_HeadRotor.EncodeLetter(button.LetterIndex);
                    int encoded = Encode(button.LetterIndex);
                    m_HeadRotor.Increment();

                    if (m_previousLitBulb != null)
                        m_previousLitBulb.GetComponent<MeshRenderer>().material = m_offMat;
                    
                    m_lightBulbs[encoded].GetComponent<MeshRenderer>().material = m_onMat;
                    m_previousLitBulb = m_lightBulbs[encoded];
                }
            }
        }
    }

    private int Encode(int l)
    {
        int val = l;
        Debug.LogWarning(m_letterButtons[val].KeyCharacter);

        for(int i = 0; i < m_RotorWirings.Length; i++)
            val = m_RotorWirings[i].GetValue(val);

        for (int i = m_RotorWirings.Length - 2; i >=0; i--)
            val = m_RotorWirings[i].GetValue(val);

        return val;
    }
}
