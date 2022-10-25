using TMPro;
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

    [SerializeField] private Plugboard m_Plugboard;

    [SerializeField] private TextMeshProUGUI m_encodedText;

    public void Awake()
    {
        m_lightBulbs = GetComponentsInChildren<LightBulb>();
        m_letterButtons = GetComponentsInChildren<LetterButton>();

        m_offMat = m_lightBulbs[0].GetComponent<MeshRenderer>().material;
        ResetText();
    }

    //private void Start()
    //{
    //    HeadRotor.Increment();
    //    HeadRotor.Next.Increment();
    //}

    public void ResetText()
    {
        m_encodedText.text = "Text : ";
    }

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

                    int encoded = m_Plugboard.GetEquivalent(button.LetterIndex);
                    encoded = m_HeadRotor.Encode(encoded);

                    m_HeadRotor.Increment();

                    if (m_previousLitBulb != null)
                        m_previousLitBulb.GetComponent<MeshRenderer>().material = m_offMat;

                    encoded = m_Plugboard.GetEquivalent(encoded);

                    m_lightBulbs[encoded].GetComponent<MeshRenderer>().material = m_onMat;
                    m_previousLitBulb = m_lightBulbs[encoded];

                    m_encodedText.text += m_previousLitBulb.KeyCharacter;
                }
            }
        }
    }

}
