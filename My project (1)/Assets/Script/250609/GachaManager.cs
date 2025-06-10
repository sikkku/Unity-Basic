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
        public float probability; //Ȯ��
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

        pityText.text = "õ�� ī��Ʈ: " + pityCount + " / " + pityLimit;
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
    [ContextMenu("�̸� �� Ȯ�� �ڵ� ����")]
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

        Add("R �����", 14f);
        Add("R ������", 14f);
        Add("SR �Ѽ���", 5f);
        Add("SR õ����", 5f);
        Add("R ������", 14f);
        Add("R ��ȣ��", 14f);
        Add("R ������", 14f);
        Add("R �ռ���", 14f);
        Add("SSR ���ѳ�", 1f);
        Add("SR ��ä��", 5f);
    }
#endif
}
