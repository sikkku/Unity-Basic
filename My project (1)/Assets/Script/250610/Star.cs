using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class Star : MonoBehaviour
{
    string star;

    void Start()
    {
        Phase1();
        Phase2();
        Phase3();
        Phase4();
        Phase5();
    }
    public void Phase1()
    {
        star = string.Empty; 

        for (int line = 1; line <= 5; line++)  //���� 1���� 5��������
        {
            for (int num_char = 0; num_char < line; num_char++) //���ڴ� ���μ���ŭ �ϳ��� �þ��

            {
                star += "��";
            }

            star += "\n";
        }

        Debug.Log(star);
    }

    public void Phase2()
    {
        star = string.Empty;

        for (int line = 1; line <= 5; line++) //���� 1���� 5��������
        {
            for (int num_char = 0; num_char < line; num_char++) //���ڴ� ���μ���ŭ �ϳ��� �þ��
            {
                star += "��";
            }
            for (int num_char = 0; num_char < 6 -line; num_char++) //���ڴ� 6���� ���μ���ŭ �ϳ��� �پ��
            {
                star += "��";
            }
            star += "\n";
        }

        Debug.Log(star);
    }

    public void Phase3()
    {
        star = string.Empty;

        for (int line = 1; line <= 5; line++) //���� �����ؿ�
        {
            for (int num_char = 0; num_char < line; num_char++) //���� �����ؿ�
            {
                star += "��";
            }
            star += "\n";
        }

        for (int line = 4; line >= 1; line--) // �����ſ� �̾ 4�ٸ� �� ����ҷ���... 4���� ���پ� �پ��
        {
            for (int num_char = 0; num_char < line; num_char++) //���ڼ��� ���μ��� �پ��¸�ŭ �� ������
            {
                star += "��";
            }
            star += "\n";
        }

        Debug.Log(star);
    }

    public void Phase4()
    {
        star = string.Empty;

        int Center = 5; //���Ƿ� ��� �������� ��Ҿ�� �ٰ����ε� �ٳ��ο����� �߽�

  
        for (int num_char = 1; num_char <= Center; num_char++) //5��° �ٱ����� ���� �ö󰡴� ���� ����
        {
            for (int line = 0; line < Center - num_char; line++) // ��� ���������� �پ��¸�ŭ ����

            {
                star += "��";
            }
            for (int line = 0; line < num_char; line++) // ��� ���������� �پ��¸�ŭ ��
            {
                star += "��";
            }
            star += "\n";
        }

        for (int num_char = Center - 1; num_char >= 1; num_char--) //��� ���������� �Ʒ��� �������� ��
        {
            for (int line = 0; line < Center - num_char; line++) // ��� ���������� �پ��¸�ŭ ����

            {
                star += "��";
            }
            for (int line = 0; line < num_char; line++) // ��� ���������� �پ��¸�ŭ ��
            {
                star += "��";
            }
            star += "\n";
        }

        Debug.Log(star);
    }

    public void Phase5()
    {
        star = string.Empty;

        int Center = 5; //���� ����


        for (int num_char = 1; num_char <= Center; num_char++) //���� ����
        {
            for (int line = 0; line < Center - num_char; line++) // ��� ���������� �پ��¸�ŭ ����
            {
                star += "��";
            }
            for (int line = 0; line < 2 * num_char - 1; line++) // ��� ���������� �پ��¸�ŭ ��
            {
                star += "��";
            }
            for (int line = 0; line < Center - num_char; line++) // ��� ���������� �پ��¸�ŭ ����
            {
                star += "��";
            }
            star += "\n";
        }

        for (int num_char = Center - 1; num_char >= 1; num_char--) //���� ����
        {
            for (int line = 0; line < Center - num_char; line++) // ��� ���������� �پ��¸�ŭ ����
            {
                star += "��";
            }
            for (int line = 0; line < 2 * num_char - 1; line++) // ��� ���������� �پ��¸�ŭ ��
            {
                star += "��";
            }
            for (int line = 0; line < Center - num_char; line++) // ��� ���������� �پ��¸�ŭ ����
            {
                star += "��";
            }
            star += "\n";
        }


        Debug.Log(star);
    }
}
