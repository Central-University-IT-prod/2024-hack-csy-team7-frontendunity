using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSwitcher : MonoBehaviour
{
    public Canvas mobileCanvas;
    public Canvas pcCanvas;
    private int screenWidth;
    private int screenHeight;

    void Start()
    {
        // �������������� ��������� �������� ������
        screenWidth = Screen.width;
        screenHeight = Screen.height;
        float aspectRatio = (float)Screen.width / (float)Screen.height;

        // ��������� ���������� ������ � ���������� ������ Canvas
        if (aspectRatio < 1f) // ��������, ����������� ��� ��������� (4:3 ��� ��������)
        {
            EnableCanvas(mobileCanvas);
        }
        
        else // �� ��� ���������� � ������� �����������
        {
            EnableCanvas(pcCanvas);
        }
    }

    void Update()
    {
        // ���������, ���������� �� ����������
        if (screenWidth != Screen.width || screenHeight != Screen.height)
        {
            
            // ��������� ������� �������� ������
            screenWidth = Screen.width;
            screenHeight = Screen.height;
            float aspectRatio = (float)Screen.width / (float)Screen.height;

            // ��������� ���������� ������ � ���������� ������ Canvas
            if (aspectRatio < 1f) // ��������, ����������� ��� ��������� (4:3 ��� ��������)
            {
                EnableCanvas(mobileCanvas);
            }

            else // �� ��� ���������� � ������� �����������
            {
                EnableCanvas(pcCanvas);
            }
        }
    }
    void EnableCanvas(Canvas targetCanvas)
    {
        mobileCanvas.gameObject.SetActive(false);
        pcCanvas.gameObject.SetActive(false);
        

        targetCanvas.gameObject.SetActive(true);
    }
}
