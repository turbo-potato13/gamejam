using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ConsoleWindow : MonoBehaviour
{
    public TMP_InputField inputField;
    private TMP_Text text;
    // Update is called once per frame
    void Start()
    {
        text = GetComponent<TMP_Text>();
        inputField.onSubmit.AddListener(ChatPrint);
    }
    void    ChatPrint(string msg)
    {
        text.text += "λ " + msg + "\n";
        inputField.text = "";
    }
}
