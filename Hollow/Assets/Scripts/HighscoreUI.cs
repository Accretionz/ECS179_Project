using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] GameObject highscoreUIElementPrefab;
    [SerializeField] Transform elementWrapper;

    List<GameObject> uiElements = new List<GameObject>();

    private void onEnable()
    {
        HighscoreHandler.onHighscoreListChanged += UpdateUI;
    }

    private void onDisable()
    {
        HighscoreHandler.onHighscoreListChanged -= UpdateUI;
    }

    public void ShowPanel()
    {
        panel.SetActive(true);
    }

    public void ClosePanel()
    {
        panel.SetActive(false);
    }

    public void UpdateUI (List<HighscoreElement> list)
    {
        for (int i = 0; i < list.Count; ++i)
        {
            HighscoreElement el = list[i];

            if (el.points > 0)
            {
                if (i >= uiElements.Count)
                {
                    var inst = Instantiate (highscoreUIElementPrefab, Vector3.zero, Quaternion.identity);
                    inst.transform.SetParent(elementWrapper, false);

                    uiElements.Add(inst);
                }

                var texts = uiElements[i].GetComponentsInChildren<Text>();
                texts[0].text = el.playerName;
                texts[1].text = el.points.ToString();
            }
        }
    }
}
