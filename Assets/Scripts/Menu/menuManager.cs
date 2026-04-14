using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject panelConfirmacion;
    public Button Jugar;

    // CONTINUAR PARTIDA
    public void EmpezarJuego()
    {
        if (PlayerPrefs.HasKey("partidaGuardada"))
        {
            SceneManager.LoadScene("SelectorNiveles");
        }
        else
        {
            Debug.Log("No hay partida guardada");
        }
    }

    // NUEVA PARTIDA (abre aviso)
    public void NuevaPartida()
    {
        panelConfirmacion.SetActive(true);
    }

    // CONFIRMAR NUEVA PARTIDA
    public void ConfirmarNuevaPartida()
    {
        PlayerPrefs.DeleteAll(); // borra TODO
        PlayerPrefs.SetInt("partidaGuardada", 1);

        SceneManager.LoadScene("SelectorNiveles");
    }

    // CANCELAR
    public void CancelarNuevaPartida()
    {
        panelConfirmacion.SetActive(false);
    }

    // CONFIGURACIÓN
    public void Configuracion()
    {
        SceneManager.LoadScene("Config");
    }

    // AL INICIAR MENÚ
    void Start()
    {
        // Desactiva botón jugar si no hay partida
        if (!PlayerPrefs.HasKey("partidaGuardada"))
        {
            Jugar.interactable = false;
        }
    }
}