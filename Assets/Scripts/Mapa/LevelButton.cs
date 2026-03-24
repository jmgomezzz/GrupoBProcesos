using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    public int nivel;
    public TextMeshProUGUI texto;

    private NivelManager nm;
    private Button boton;

    void Start()
    {
        nm = FindFirstObjectByType<NivelManager>();
        boton = GetComponent<Button>();

        ActualizarEstado();
    }

    void ActualizarEstado()
    {
        if (nm.EstaCompletado(nivel))
        {
            texto.text = "COMPLETADO";
            boton.interactable = false;
        }
        else if (!nm.EstaDesbloqueado(nivel))
        {
            texto.text = "Bloqueado";
            boton.interactable = false;
        }
        else
        {
            texto.text = "Nivel " + nivel;
            boton.interactable = true;
        }
    }
}