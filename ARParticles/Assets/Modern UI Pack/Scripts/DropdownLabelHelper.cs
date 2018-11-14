using UnityEngine;
using UnityEngine.UI;

public class DropdownLabelHelper : MonoBehaviour {

    [Header("RESOURCES")]
    public Text mainText;
    public Text highlightedText;
	
	void Update ()
    {
        highlightedText.text = mainText.text;
	}
}
