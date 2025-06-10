using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class GachaManager : MonoBehaviour
{
    public enum CharacterGrade { R, SR, SSR }

    [System.Serializable]
    public class Character
    {
        public string name;
        public Sprite image;
        public CharacterGrade grade;
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


    private Dictionary<CharacterGrade, float> gradeProbabilities = new Dictionary<CharacterGrade, float>()
    {
        { CharacterGrade.SSR, 1f },
        { CharacterGrade.SR, 14f },
        { CharacterGrade.R, 85f }
    };

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
            return GetRandomCharacterInGrade(CharacterGrade.SSR);
        }


        float rand = Random.Range(0f, 100f);
        float cumulative = 0f;
        foreach (var entry in gradeProbabilities)
        {
            cumulative += entry.Value;
            if (rand < cumulative)
            {
                return GetRandomCharacterInGrade(entry.Key);
            }
        }

        // 혹시 뻑날까봐
        return GetRandomCharacterInGrade(CharacterGrade.R);
    }

    Character GetRandomCharacterInGrade(CharacterGrade grade)
    {
        List<Character> candidates = characterList.FindAll(c => c.grade == grade);
        if (candidates.Count == 0)
        {
            return null;
        }
        int index = Random.Range(0, candidates.Count);
        return candidates[index];
    }

    public void ReturnToMain()
    {
        HideSingleResult();
        HideTenResult();
        ToggleButtons(true);
    }

    void UpdatePityText()
    {
        if (pityText != null)
        {
            pityText.text = "천장 카운트: " + pityCount + " / " + pityLimit;
        }
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
        if (gachaOnceButton != null)
        {
            gachaOnceButton.SetActive(showMainButtons);
        }

        if (gachaTenButton != null)
        {
            gachaTenButton.SetActive(showMainButtons);
        }

        if (exitButton != null)
        {
            exitButton.SetActive(!showMainButtons);
        }
    }

#if UNITY_EDITOR
    [ContextMenu("이름 및 확률 자동 설정")]
    void SetCharacterNamesAndProbabilities()
    {
        characterList.Clear();

        void Add(string name, CharacterGrade grade)
        {
            Character c = new Character();
            c.name = name;
            c.grade = grade;
            c.image = null;
            characterList.Add(c);
        }

        Add("R 박재완", CharacterGrade.R);
        Add("R 엄지성", CharacterGrade.R);
        Add("SR 한세웅", CharacterGrade.SR);
        Add("SR 천지수", CharacterGrade.SR);
        Add("R 조형민", CharacterGrade.R);
        Add("R 이호범", CharacterGrade.R);
        Add("R 김지원", CharacterGrade.R);
        Add("R 손석현", CharacterGrade.R);
        Add("SSR 김한나", CharacterGrade.SSR);
        Add("SR 신채현", CharacterGrade.SR);
    }
#endif
}
