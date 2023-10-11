using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ColorButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private TextMeshProUGUI Texto;
    private Color originalColor;
    private float originalFontSize;

    void Start()
    {
        Texto = GetComponentInChildren<TextMeshProUGUI>();

        if (Texto == null)
        {
            Debug.LogError("N�o foi poss�vel encontrar um componente de texto no bot�o");
        }

        originalColor = Texto.color;
        originalFontSize = Texto.fontSize;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Texto.color = new Color(0.98f, 0.96f, 0.39f);
        Texto.fontSize = originalFontSize + 2;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Texto.color = originalColor;
        Texto.fontSize = originalFontSize;
    }
}
