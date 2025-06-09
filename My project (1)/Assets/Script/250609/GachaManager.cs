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
        public float probability;     // Ȯ�� 0~100
    }

    [Header("ĳ���� ����Ʈ")]
    public List<Character> characterList; 

    [Header("10ȸ�� �̹���/�ؽ�Ʈ")]
    public Image[] resultImages;               
    public TextMeshProUGUI[] resultTexts;      

    [Header("1ȸ�� �̹���/�ؽ�Ʈ")]
    public Image resultSingleImage;           
    public TextMeshProUGUI resultSingleText;     

    [Header("TMP ���")]
    public TextMeshProUGUI pityText;            

    [Header("��ư �� UI")]
    public GameObject gachaOnceButton;           
    public GameObject gachaTenButton;          
    public GameObject exitButton;                

    // õ�� �ý���
    private int pityCount = 0;                   // ������� �̱� Ƚ��
    private const int pityLimit = 100;           // õ�� �ѵ�

    // 1ȸ �̱� ����
    public void GachaOnce()
    {
        Character selected = GetCharacterByProbability(); // Ȯ�� ����

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

    // 10ȸ �̱� ����
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

    // Ȯ�� ���� �̱�
    Character GetCharacterByProbability()
    {
        // õ�� SSR
        if (pityCount >= pityLimit)
        {
            pityCount = 0;
            for (int i = 0; i < characterList.Count; i++)
            {
                if (characterList[i].name.Contains("SSR"))
                {
                    return characterList[i];
                }
            }
            return characterList[0]; // SSR �ȶ߸� ù ĳ���� ��ȯ
        }

        // �Ϲ� Ȯ��
        float rand = Random.Range(0f, 100f);
        float cumulative = 0f;

        for (int i = 0; i < characterList.Count; i++)
        {
            cumulative += characterList[i].probability;
            if (rand < cumulative)
            {
                return characterList[i];
            }
        }

        //  fallback
        return characterList[characterList.Count - 1];
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
   //characterList �ڵ����� ä���  ~~~ �̰� ���� GPT���
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
