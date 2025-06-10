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

    [Header("ĳ���� ����Ʈ")]
    public List<Character> characterList;

    [Header("1ȸ �̱�")]
    public Image resultSingleImage;
    public TextMeshProUGUI resultSingleText;

    [Header("10ȸ �̱�")]
    public Image[] resultImages;
    public TextMeshProUGUI[] resultTexts;

    [Header("õ�� �ؽ�Ʈ")]
    public TextMeshProUGUI pityText;

    [Header("��ư")]
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
            resultSingleText.text = "�̸� ����";
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
                resultTexts[i].text = "�̸� ����";
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

        // Ȥ�� �������
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
            pityText.text = "õ�� ī��Ʈ: " + pityCount + " / " + pityLimit;
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
    [ContextMenu("�̸� �� Ȯ�� �ڵ� ����")]
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

        Add("R �����", CharacterGrade.R);
        Add("R ������", CharacterGrade.R);
        Add("SR �Ѽ���", CharacterGrade.SR);
        Add("SR õ����", CharacterGrade.SR);
        Add("R ������", CharacterGrade.R);
        Add("R ��ȣ��", CharacterGrade.R);
        Add("R ������", CharacterGrade.R);
        Add("R �ռ���", CharacterGrade.R);
        Add("SSR ���ѳ�", CharacterGrade.SSR);
        Add("SR ��ä��", CharacterGrade.SR);
    }
#endif
}
