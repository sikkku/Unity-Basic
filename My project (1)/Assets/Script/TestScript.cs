using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestScript : MonoBehaviour
{
    public TextMeshProUGUI Txt_Text;


    private string name = " ������";
    private int birth_year = 1997;
    private int age = 29;
    private float height = 182.5f;
    private string MBTI = "INTP";
    private string duel_rank = "Diamond V";
    private string favorite_food = "ġŲ";
    private string favorite_game = "��������";
    private string hobby = "����, ��ȭ����, ���̵�";
    private string pet = "����";


    private List<string> sentences;
    private int currentIndex = 0;

    void Start()
    {

        sentences = new List<string>()
        {
            "�� �̸���" + name + "�Դϴ�.",
            $"�� ���̴� {age}�� �Դϴ�.",
            $"�� ������ {birth_year}�� �Դϴ�.",
            $"�� Ű�� {height}cm �Դϴ�.",
            $"�� MBTI�� {MBTI}�Դϴ�.",
            $"�� �����͵�� ��ũ�� {duel_rank}�Դϴ�.",
            $"���� �����ϴ� ������ {favorite_food}�Դϴ�.",
            $"���� �����ϴ� ������ {favorite_game}�Դϴ�.",
            $"�� ��̴� {hobby}�Դϴ�.",
            $"���� Ű��� �ֿϵ����� {pet}�Դϴ�."
        };

        Txt_Text.text = ""; 
    }

    public void OnClickButton()
    {
        if (currentIndex < sentences.Count)
        {
            Txt_Text.text = sentences[currentIndex];
            currentIndex++;
        }
    }
}


//using System.Collections;
//using System.Collections.Generic;
//using Unity.VisualScripting;
//using UnityEngine;
//using UnityEngine.Rendering;

//public class CHS : MonoBehaviour
//{
//    private string name = " ������";
//    private int birth_year = 1997;
//    private int age = 29;
//    private float height = 182.5f;
//    private string MBTI = "INTP";
//    private string duel_rank = "Diamond V";
//    private string favorite_food = "ġŲ";
//    private string favorite_game = "��������";
//    private string hobby = "����, ��ȭ����, ���̵�";
//    private string pet = "����";


//    void Start()
//    {
//        SelfIntrodiction();
//    }
//    public void SelfIntrodiction()
//    {
//        Debug.Log("�� �̸���" + name + "�Դϴ�.");
//        Debug.Log($"�� ���̴� {age}�� �Դϴ�.");
//        Debug.Log($"�� ������ {birth_year}�� �Դϴ�.");
//        Debug.Log($"�� Ű�� {height}cm �Դϴ�.");
//        Debug.Log($"�� MBTI�� {MBTI}�Դϴ�.");
//        Debug.Log($"�� �����͵�� ��ũ�� {duel_rank}�Դϴ�.");
//        Debug.Log($"���� �����ϴ� ������ {favorite_food}�Դϴ�.");
//        Debug.Log($"���� �����ϴ� ������ {favorite_game}�Դϴ�.");
//        Debug.Log($"�� ��̴� {hobby}�Դϴ�.");
//        Debug.Log($"���� Ű��� �ֿϵ����� {pet}�Դϴ�.");
//    }

//}
//void OnEnable()
//{
//    Debug.Log(Random.Range(1, 100));
//    // 1 �̻� 100 �̸��� ������ ���� ����ڴ�.
//}

//    void Awake()
//    {
//        Debug.Log("���� �ѹ��� ����");
//    }
//    void OnEnable()
//    {
//        Debug.Log("Ȱ��ȭ �� �� ����");
//    }

//    // Start is called before the first frame update
//    void Start()
//    {
//        Debug.Log("�ѹ��� ����");
//    }

//    void Update()
//    {
//        Debug.Log("�� ������ ������ ����");
//    }
//    // Update is called once per frame

//}

//public class Player
//{
//    private int playerLevel = 10;

//    public int Level()
//    {
//        return playerLevel;
//    }
//}

//public class Monster
//{
//    private int monsterLevel;

//    public void SetLevel(int _playerLevel)
//    {
//        monsterLevel = _playerLevel;
//    }
//}

//public class Game
//{
//    Player A;
//    Monster B;

//    void MonsterSpawn() // ����
//    {
//        B.SetLevel(A.Level());
//    }
//}

//void Start()
//{
//    Debug.Log("���� ������ " + playerLevel + "�Դϴ�.");
//    Debug.Log($"���� ������ {playerLevel}�Դϴ�.");
//}