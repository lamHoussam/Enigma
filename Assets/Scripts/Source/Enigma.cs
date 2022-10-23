using UnityEngine;

public class Enigma : MonoBehaviour
{
    [SerializeField] private Material m_onMat;
    private Material m_offMat;

    private LightBulb[] m_lightBulbs;
    private LetterButton[] m_letterButtons;

    private LightBulb m_previousLitBulb = null;

    public void Awake()
    {
        m_lightBulbs = GetComponentsInChildren<LightBulb>();
        m_letterButtons = GetComponentsInChildren<LetterButton>();


        m_offMat = m_lightBulbs[0].GetComponent<MeshRenderer>().material;
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

                    if(m_previousLitBulb != null)
                        m_previousLitBulb.GetComponent<MeshRenderer>().material = m_offMat;
                    
                    m_lightBulbs[button.LetterIndex].GetComponent<MeshRenderer>().material = m_onMat;
                    m_previousLitBulb = m_lightBulbs[button.LetterIndex];
                }
            }
        }
    }
}
