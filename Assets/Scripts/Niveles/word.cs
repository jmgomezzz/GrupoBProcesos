using UnityEngine;
using TMPro;

public class Word : MonoBehaviour
{
    public string texto;
    public bool revelada = false;

    public TextMeshProUGUI uiText;

    private GameManager gm;

    void Start()
    {
        gm = FindFirstObjectByType<GameManager>();
        Ocultar();
    }

    public void OnClick()
    {
        gm.SeleccionarPalabra(this);
    }

    public void Revelar()
    {
        revelada = true;
        uiText.text = texto;
    }

    void Ocultar()
    {
        uiText.text = "????";
    }
}