using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiaColorDelfin : MonoBehaviour
{
    // Referencia al Renderer del objeto
    private Renderer objRenderer;

    void Start()
    {
        // Obtener el Renderer del objeto
        objRenderer = GetComponent<Renderer>();
    }

    // Método público para cambiar el color
    public void ChangeColor()
    {
        // Generar un color aleatorio usando Random.ColorHSV()
        Color randomColor = Random.ColorHSV();

        // Asignar el color generado al material del objeto
        objRenderer.material.color = randomColor;
    }
}

