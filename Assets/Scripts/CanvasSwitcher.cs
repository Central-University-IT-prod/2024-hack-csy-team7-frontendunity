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
        // Инициализируем начальные значения экрана
        screenWidth = Screen.width;
        screenHeight = Screen.height;
        float aspectRatio = (float)Screen.width / (float)Screen.height;

        // Проверяем разрешение экрана и активируем нужный Canvas
        if (aspectRatio < 1f) // Например, соотношение для планшетов (4:3 или подобное)
        {
            EnableCanvas(mobileCanvas);
        }
        
        else // ПК или устройства с высоким разрешением
        {
            EnableCanvas(pcCanvas);
        }
    }

    void Update()
    {
        // Проверяем, изменилось ли разрешение
        if (screenWidth != Screen.width || screenHeight != Screen.height)
        {
            
            // Обновляем текущие значения экрана
            screenWidth = Screen.width;
            screenHeight = Screen.height;
            float aspectRatio = (float)Screen.width / (float)Screen.height;

            // Проверяем разрешение экрана и активируем нужный Canvas
            if (aspectRatio < 1f) // Например, соотношение для планшетов (4:3 или подобное)
            {
                EnableCanvas(mobileCanvas);
            }

            else // ПК или устройства с высоким разрешением
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
