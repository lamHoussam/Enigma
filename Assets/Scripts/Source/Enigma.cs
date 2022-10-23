using UnityEngine;

public class Enigma : MonoBehaviour
{
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
                if(hit.transform.TryGetComponent(out LetterButton button))
                    button.OnClick();
        }
    }
}
