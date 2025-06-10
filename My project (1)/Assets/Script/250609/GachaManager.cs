using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class GachaManager : MonoBehaviour
{
    [System.Serializable]
    public class Character
    {
        public string name;
        public Sprite image;
        public float probability; //확률
    }

    [Header("캐릭터 리스트")]
    public List<Character> characterList;

    [Header("1회 뽑기")]
    public Image resultSingleImage;
    public TextMeshProUGUI resultSingleText;

    [Header("10회 뽑기")]
    public Image[] resultImages;
    public TextMeshProUGUI[] resultTexts;
 
    [Header("천장 텍스트")]
    public TextMeshProUGUI pityText;

    [Header("버튼")]
    public GameObject gachaOnceButton;
    public GameObject gachaTenButton;
    public GameObject exitButton;

    private int pityCount = 0;
    private const int pityLimit = 100;

    public void GachaOnce()
    {
        Character selected = GetCharacterByProbability();
        resultSingleImage.sprite = selected.image;

        if (string.IsNullOrEmpty(selected.name))
        {
            resultSingleText.text = "이름 없음";
        }
        else
        {
            resultSingleText.text = selected.name;
        }

        resultSingleImage.gameObject.SetActive(true);
        resultSingleText.gameObject.SetActive(true);

        HideTenResult();
        ToggleButtons(false);

        pityCount++;
        UpdatePityText();
    }

    public void GachaTen()
    {
        HideSingleResult();

        for (int i = 0; i < 10; i++)
        {
            Character selected = GetCharacterByProbability();
            resultImages[i].sprite = selected.image;

            if (string.IsNullOrEmpty(selected.name))
            {
                resultTexts[i].text = "이름 없음";
            }
            else
            {
                resultTexts[i].text = selected.name;
            }

            resultImages[i].gameObject.SetActive(true);
            resultTexts[i].gameObject.SetActive(true);

            pityCount++;
        }

        ToggleButtons(false);
        UpdatePityText();
    }

    Character GetCharacterByProbability()
    {
        if (pityCount >= pityLimit)
        {
            pityCount = 0;
            foreach (var c in characterList)
            {
                if (c.name.Contains("SSR"))
                {
                    return c;
                }
            }
            return characterList[0];
        }

        float rand = Random.Range(0f, 100f);
        float cumulative = 0f;

        foreach (var c in characterList)
        {
            cumulative += c.probability;
            if (rand < cumulative)
            {
                return c;
            }
        }

        return characterList[characterList.Count - 1]; // fallback
    }

    public void ReturnToMain()
    {
        HideSingleResult();
        HideTenResult();
        ToggleButtons(true);
    }

    void UpdatePityText()
    {
        if (pityText == null)
        {
            return;
        }

        pityText.text = "천장 카운트: " + pityCount + " / " + pityLimit;
    }

    void HideSingleResult()
    {
        resultSingleImage.gameObject.SetActive(false);
        resultSingleText.gameObject.SetActive(false);
    }

    void HideTenResult()
    {
        for (int i = 0; i < resultImages.Length; i++)
        {
            resultImages[i].gameObject.SetActive(false);
            resultTexts[i].gameObject.SetActive(false);
        }
    }

    void ToggleButtons(bool showMainButtons)
    {
        if (gachaOnceButton == null)
        {
            return;
        }
        gachaOnceButton.SetActive(showMainButtons);

        if (gachaTenButton == null)
        {
            return;
        }
        gachaTenButton.SetActive(showMainButtons);

        if (exitButton == null)
        {
            return;
        }
        exitButton.SetActive(showMainButtons == false);
    }

#if UNITY_EDITOR
    [ContextMenu("이름 및 확률 자동 설정")]
    void SetCharacterNamesAndProbabilities()
    {
        characterList.Clear();

        void Add(string name, float prob)
        {
            Character c = new Character();
            c.name = name;
            c.probability = prob;
            c.image = null;
            characterList.Add(c);
        }

        Add("R 박재완", 14f);
        Add("R 엄지성", 14f);
        Add("SR 한세웅", 5f);
        Add("SR 천지수", 5f);
        Add("R 조형민", 14f);
        Add("R 이호범", 14f);
        Add("R 김지원", 14f);
        Add("R 손석현", 14f);
        Add("SSR 김한나", 1f);
        Add("SR 신채현", 5f);
    }
#endif
}
