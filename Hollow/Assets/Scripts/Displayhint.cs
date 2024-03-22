using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Displayhint : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI NoteText;

    // Update is called once per frame
    void Update()
    {
        NoteText.text = "Find The Treasure Box and Gain a Spell! (PRESS Q)";
    }

}
