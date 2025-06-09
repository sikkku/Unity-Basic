using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestScript : MonoBehaviour
{
    public TextMeshProUGUI Txt_Text;


    private string name = " 최현석";
    private int birth_year = 1997;
    private int age = 29;
    private float height = 182.5f;
    private string MBTI = "INTP";
    private string duel_rank = "Diamond V";
    private string favorite_food = "치킨";
    private string favorite_game = "사이퍼즈";
    private string hobby = "게임, 영화감상, 라이딩";
    private string pet = "새우";


    private List<string> sentences;
    private int currentIndex = 0;

    void Start()
    {

        sentences = new List<string>()
        {
            "제 이름은" + name + "입니다.",
            $"제 나이는 {age}살 입니다.",
            $"제 생년은 {birth_year}년 입니다.",
            $"제 키는 {height}cm 입니다.",
            $"제 MBTI는 {MBTI}입니다.",
            $"제 마스터듀얼 랭크는 {duel_rank}입니다.",
            $"제가 좋아하는 음식은 {favorite_food}입니다.",
            $"제가 좋아하는 게임은 {favorite_game}입니다.",
            $"제 취미는 {hobby}입니다.",
            $"제가 키우는 애완동물은 {pet}입니다."
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
//    private string name = " 최현석";
//    private int birth_year = 1997;
//    private int age = 29;
//    private float height = 182.5f;
//    private string MBTI = "INTP";
//    private string duel_rank = "Diamond V";
//    private string favorite_food = "치킨";
//    private string favorite_game = "사이퍼즈";
//    private string hobby = "게임, 영화감상, 라이딩";
//    private string pet = "새우";


//    void Start()
//    {
//        SelfIntrodiction();
//    }
//    public void SelfIntrodiction()
//    {
//        Debug.Log("제 이름은" + name + "입니다.");
//        Debug.Log($"제 나이는 {age}살 입니다.");
//        Debug.Log($"제 생년은 {birth_year}년 입니다.");
//        Debug.Log($"제 키는 {height}cm 입니다.");
//        Debug.Log($"제 MBTI는 {MBTI}입니다.");
//        Debug.Log($"제 마스터듀얼 랭크는 {duel_rank}입니다.");
//        Debug.Log($"제가 좋아하는 음식은 {favorite_food}입니다.");
//        Debug.Log($"제가 좋아하는 게임은 {favorite_game}입니다.");
//        Debug.Log($"제 취미는 {hobby}입니다.");
//        Debug.Log($"제가 키우는 애완동물은 {pet}입니다.");
//    }

//}
//void OnEnable()
//{
//    Debug.Log(Random.Range(1, 100));
//    // 1 이상 100 미만의 랜덤한 값을 만들겠다.
//}

//    void Awake()
//    {
//        Debug.Log("최초 한번만 실행");
//    }
//    void OnEnable()
//    {
//        Debug.Log("활성화 될 때 실행");
//    }

//    // Start is called before the first frame update
//    void Start()
//    {
//        Debug.Log("한번만 실행");
//    }

//    void Update()
//    {
//        Debug.Log("매 프레임 여러번 실행");
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

//    void MonsterSpawn() // 몬스터
//    {
//        B.SetLevel(A.Level());
//    }
//}

//void Start()
//{
//    Debug.Log("나의 레벨은 " + playerLevel + "입니다.");
//    Debug.Log($"나의 레벨은 {playerLevel}입니다.");
//}