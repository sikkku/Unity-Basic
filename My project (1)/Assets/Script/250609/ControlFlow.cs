using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEditor;
using UnityEngine;

public class ContorlFlow : MonoBehaviour
{

    List<string> characters = new List<string>() { "김지원", "손석현", "김한나", "엄지성", "박재완", "이호범", "신채현", "한세웅", "조형민", "천지수" };



    int[] probs = new int[] { 10, 20, 5, 15, 10, 5, 10, 10, 10, 5 };


    public void Gacha()
    {
        Debug.Log("~10연차 뽑기~");
        int count = 0;
        while (count < 10)
        {
            string picked = Pick();
            Debug.Log((count + 1) + "회차: " + picked);
            count = count + 1;
        }
    }


    string Pick()
    {
        int total = 0;
        for (int i = 0; i < probs.Length; i++)
        {
            total = total + probs[i];
        }

        int rand = Random.Range(1, total + 1);
        int sum = 0;

        for (int i = 0; i < probs.Length; i++)
        {
            sum = sum + probs[i];
            if (rand <= sum)
            {

                switch (i)
                {
                    case 0: return characters[0];
                    case 1: return characters[1];
                    case 2: return characters[2];
                    case 3: return characters[3];
                    case 4: return characters[4];
                    case 5: return characters[5];
                    case 6: return characters[6];
                    case 7: return characters[7];
                    case 8: return characters[8];
                    case 9: return characters[9];
                }
            }
        }

        return "찐 빠";
    }
}


//{
//    int count;

//    void Awake()
//    {
//        count = 0;
//    }

//    public void Gacha()
//    {
//        // 확률이 10%면 로그에 '각청'을 뽑았다!
//        // 확률이 20%면 로그에 '모나'를 뽑았다!
//        // 나머지 70% 확률로 '치치'를 뽑아버렸다!

//        int randomValue = Random.Range(1, 101); // 1이상 101미만의 랜덤한 값을 받아 오겠다. (1 ~ 100) 

//        Debug.Log($"랜덤한 값은 : {randomValue} 입니다");
//        // count 81
//        if (8 <= count)
//        {
//            Debug.Log("확정으로 '각청'을 뽑았다!");
//            count = 0;
//        }
//        else if (randomValue <= 10) // 1 ~ 10 -> 10%
//        {
//            Debug.Log("'각청'을 뽑았다!");
//        }
//        else if (randomValue <= 30) // 11 ~ 30
//        {
//            Debug.Log("'모나'을 뽑았다!");
//        }
//        else
//        {
//            Debug.Log("'치치'를 뽑아버렸다!");
//        }

//        count++;
//    }


//    public void GachaSwitch()
//    {
//        // 
//        int randomValue = Random.Range(1, 101); // 1이상 101미만의 랜덤한 값을 받아 오겠다. (1 ~ 100) 

//        int selectNumbe = 0;

//        switch (selectNumbe)
//        {
//            case 0:
//                // 은색 머리 캐릭터가 나온다
//                {
//                    if (randomValue <= 10) // 1 ~ 10 -> 10%
//                    {
//                        Debug.Log("'은색 머리'을 뽑았다!");
//                    }
//                    else if (randomValue <= 30) // 11 ~ 30
//                    {
//                        Debug.Log("'모나'을 뽑았다!");
//                    }
//                    else
//                    {
//                        Debug.Log("'치치'를 뽑아버렸다!");
//                    }
//                }
//                break;

//            case 1:
//                // 파란 머리 캐릭터가 나온다
//                {
//                    if (randomValue <= 10) // 1 ~ 10 -> 10%
//                    {
//                        Debug.Log("'파란 머리'을 뽑았다!");
//                    }
//                    else if (randomValue <= 30) // 11 ~ 30
//                    {
//                        Debug.Log("'모나'을 뽑았다!");
//                    }
//                    break;

//                }
//        }
//    }
//}