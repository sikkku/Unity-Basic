using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEditor;
using UnityEngine;

public class ContorlFlow : MonoBehaviour
{

    List<string> characters = new List<string>() { "������", "�ռ���", "���ѳ�", "������", "�����", "��ȣ��", "��ä��", "�Ѽ���", "������", "õ����" };



    int[] probs = new int[] { 10, 20, 5, 15, 10, 5, 10, 10, 10, 5 };


    public void Gacha()
    {
        Debug.Log("~10���� �̱�~");
        int count = 0;
        while (count < 10)
        {
            string picked = Pick();
            Debug.Log((count + 1) + "ȸ��: " + picked);
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

        return "�� ��";
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
//        // Ȯ���� 10%�� �α׿� '��û'�� �̾Ҵ�!
//        // Ȯ���� 20%�� �α׿� '��'�� �̾Ҵ�!
//        // ������ 70% Ȯ���� 'ġġ'�� �̾ƹ��ȴ�!

//        int randomValue = Random.Range(1, 101); // 1�̻� 101�̸��� ������ ���� �޾� ���ڴ�. (1 ~ 100) 

//        Debug.Log($"������ ���� : {randomValue} �Դϴ�");
//        // count 81
//        if (8 <= count)
//        {
//            Debug.Log("Ȯ������ '��û'�� �̾Ҵ�!");
//            count = 0;
//        }
//        else if (randomValue <= 10) // 1 ~ 10 -> 10%
//        {
//            Debug.Log("'��û'�� �̾Ҵ�!");
//        }
//        else if (randomValue <= 30) // 11 ~ 30
//        {
//            Debug.Log("'��'�� �̾Ҵ�!");
//        }
//        else
//        {
//            Debug.Log("'ġġ'�� �̾ƹ��ȴ�!");
//        }

//        count++;
//    }


//    public void GachaSwitch()
//    {
//        // 
//        int randomValue = Random.Range(1, 101); // 1�̻� 101�̸��� ������ ���� �޾� ���ڴ�. (1 ~ 100) 

//        int selectNumbe = 0;

//        switch (selectNumbe)
//        {
//            case 0:
//                // ���� �Ӹ� ĳ���Ͱ� ���´�
//                {
//                    if (randomValue <= 10) // 1 ~ 10 -> 10%
//                    {
//                        Debug.Log("'���� �Ӹ�'�� �̾Ҵ�!");
//                    }
//                    else if (randomValue <= 30) // 11 ~ 30
//                    {
//                        Debug.Log("'��'�� �̾Ҵ�!");
//                    }
//                    else
//                    {
//                        Debug.Log("'ġġ'�� �̾ƹ��ȴ�!");
//                    }
//                }
//                break;

//            case 1:
//                // �Ķ� �Ӹ� ĳ���Ͱ� ���´�
//                {
//                    if (randomValue <= 10) // 1 ~ 10 -> 10%
//                    {
//                        Debug.Log("'�Ķ� �Ӹ�'�� �̾Ҵ�!");
//                    }
//                    else if (randomValue <= 30) // 11 ~ 30
//                    {
//                        Debug.Log("'��'�� �̾Ҵ�!");
//                    }
//                    break;

//                }
//        }
//    }
//}