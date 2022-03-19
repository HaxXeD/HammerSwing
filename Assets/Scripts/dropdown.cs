using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class dropdown : MonoBehaviour
{
    Dropdown m_Dropdown;
    [SerializeField] TMP_Text drop;
    [SerializeField] GameObject levelScreen;
    [SerializeField] GameObject countryScreen;
    private int _countryIndex;

    void Start()
    {
        //Fetchiing the Dropdown GameObject
        m_Dropdown = GetComponent<Dropdown>();

        //Adding listener for when the value of the Dropdown changes, to take action
        m_Dropdown.onValueChanged.AddListener(delegate{DropdownValueChanged(m_Dropdown);});
        //Initialise the Text to say the first value of the Dropdown
        print(m_Dropdown.value);

        //for initial text value
        // drop.text = m_Dropdown.options[m_Dropdown.value].text;

        //for initial int value
        _countryIndex = m_Dropdown.value;
    }

    //Ouput the new value of the Dropdown into Text
    void DropdownValueChanged(Dropdown change)
    {
        _countryIndex = m_Dropdown.value;
        levelScreen.SetActive(true);
        countryScreen.SetActive(false);
    }
}