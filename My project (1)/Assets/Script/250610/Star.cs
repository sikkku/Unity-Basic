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

        for (int line = 1; line <= 5; line++)  //줄은 1부터 5까지에용
        {
            for (int num_char = 0; num_char < line; num_char++) //글자는 라인수만큼 하나씩 늘어나용

            {
                star += "★";
            }

            star += "\n";
        }

        Debug.Log(star);
    }

    public void Phase2()
    {
        star = string.Empty;

        for (int line = 1; line <= 5; line++) //줄은 1부터 5까지에용
        {
            for (int num_char = 0; num_char < line; num_char++) //글자는 라인수만큼 하나씩 늘어나용
            {
                star += "　";
            }
            for (int num_char = 0; num_char < 6 -line; num_char++) //글자는 6에서 라인수만큼 하나씩 줄어용
            {
                star += "★";
            }
            star += "\n";
        }

        Debug.Log(star);
    }

    public void Phase3()
    {
        star = string.Empty;

        for (int line = 1; line <= 5; line++) //위와 동일해용
        {
            for (int num_char = 0; num_char < line; num_char++) //위와 동일해용
            {
                star += "★";
            }
            star += "\n";
        }

        for (int line = 4; line >= 1; line--) // 위에거에 이어서 4줄만 더 출력할래용... 4부터 한줄씩 줄어용
        {
            for (int num_char = 0; num_char < line; num_char++) //글자수는 라인수가 줄어드는만큼 덜 찍혀용
            {
                star += "★";
            }
            star += "\n";
        }

        Debug.Log(star);
    }

    public void Phase4()
    {
        star = string.Empty;

        int Center = 5; //임의로 가운데 기준점을 잡았어용 줄갯수로도 줄내부에서도 중심

  
        for (int num_char = 1; num_char <= Center; num_char++) //5번째 줄까지는 위로 올라가는 별을 찍어용
        {
            for (int line = 0; line < Center - num_char; line++) // 가운데 기준점부터 줄어드는만큼 공백

            {
                star += "　";
            }
            for (int line = 0; line < num_char; line++) // 가운데 기준점부터 줄어드는만큼 별
            {
                star += "★";
            }
            star += "\n";
        }

        for (int num_char = Center - 1; num_char >= 1; num_char--) //가운데 기준점부터 아래로 내려가는 별
        {
            for (int line = 0; line < Center - num_char; line++) // 가운데 기준점부터 줄어드는만큼 공백

            {
                star += "　";
            }
            for (int line = 0; line < num_char; line++) // 가운데 기준점부터 줄어드는만큼 별
            {
                star += "★";
            }
            star += "\n";
        }

        Debug.Log(star);
    }

    public void Phase5()
    {
        star = string.Empty;

        int Center = 5; //위와 동일


        for (int num_char = 1; num_char <= Center; num_char++) //위와 동일
        {
            for (int line = 0; line < Center - num_char; line++) // 가운데 기준점부터 줄어드는만큼 공백
            {
                star += "　";
            }
            for (int line = 0; line < 2 * num_char - 1; line++) // 가운데 기준점부터 줄어드는만큼 별
            {
                star += "★";
            }
            for (int line = 0; line < Center - num_char; line++) // 가운데 기준점부터 줄어드는만큼 공백
            {
                star += "　";
            }
            star += "\n";
        }

        for (int num_char = Center - 1; num_char >= 1; num_char--) //위와 동일
        {
            for (int line = 0; line < Center - num_char; line++) // 가운데 기준점부터 줄어드는만큼 공백
            {
                star += "　";
            }
            for (int line = 0; line < 2 * num_char - 1; line++) // 가운데 기준점부터 줄어드는만큼 별
            {
                star += "★";
            }
            for (int line = 0; line < Center - num_char; line++) // 가운데 기준점부터 줄어드는만큼 공백
            {
                star += "　";
            }
            star += "\n";
        }


        Debug.Log(star);
    }
}
