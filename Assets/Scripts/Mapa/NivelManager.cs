using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class NivelManager : MonoBehaviour
{
    public int totalNiveles = 8;

    // COMPLETAR NIVEL
    public void CompletarNivel(int nivel)
    {
        PlayerPrefs.SetInt("Nivel_" + nivel, 1);
        PlayerPrefs.Save();

        Debug.Log("Nivel " + nivel + " completado");
    }

    // COMPROBAR SI ESTÁ COMPLETADO
    public bool EstaCompletado(int nivel)
    {
        return PlayerPrefs.GetInt("Nivel_" + nivel, 0) == 1;
    }

    // DESBLOQUEO
    public bool EstaDesbloqueado(int nivel)
    {
        // Piso 1
        if (nivel <= 3)
            return true;

        // Piso 2  
        if (nivel <= 5)
        {
            int completados = 0;
            for (int i = 1; i <= 3; i++)
                if (EstaCompletado(i)) completados++;

            return completados >= 2;
        }

        // Piso 3 
        if (nivel <= 8)
        {
            return EstaCompletado(4) && EstaCompletado(5);
        }

        return false;
    }

    // CARGAR NIVEL
    public void CargarNivel(int nivel)
    {
        if (EstaDesbloqueado(nivel))
        {
            SceneManager.LoadScene("Nivel_" + nivel);
        }
        else
        {
            Debug.Log("Nivel bloqueado");
        }
    }
    void Update()
{
    if (Keyboard.current.rKey.wasPressedThisFrame)
    {
        ResetProgreso();
    }
}
public void ResetProgreso()
{
    PlayerPrefs.DeleteAll();
    PlayerPrefs.Save();

    Debug.Log("Progreso reiniciado");

    UnityEngine.SceneManagement.SceneManager.LoadScene(
        UnityEngine.SceneManagement.SceneManager.GetActiveScene().name
    );
}

}