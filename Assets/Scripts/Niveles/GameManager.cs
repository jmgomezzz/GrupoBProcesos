using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<Word> palabras = new List<Word>();

    public string palabraObjetivo;
    public int errores = 0;
    public int maxErrores = 3;
    public int numeroNivel;

    void Start()
    {
        ElegirNuevaPalabra();
    }

    void ElegirNuevaPalabra()
    {
        List<Word> noReveladas = palabras.FindAll(p => !p.revelada);

        if (noReveladas.Count == 0)
        {
            Debug.Log("GANASTE");

            var nm = FindFirstObjectByType<NivelManager>();

            if (nm != null)
            {
                nm.CompletarNivel(numeroNivel);
            }

            // Volver al menú
            SceneManager.LoadScene("SelectorNiveles");
            return;
        }

        int randomIndex = Random.Range(0, noReveladas.Count);
        palabraObjetivo = noReveladas[randomIndex].texto;

        Debug.Log("Busca: " + palabraObjetivo);
    }

    public void SeleccionarPalabra(Word palabra)
    {
        if (palabra.revelada) return;

        if (palabra.texto == palabraObjetivo)
        {
            palabra.Revelar();
            ElegirNuevaPalabra();
        }
        else
        {
            errores++;
            Debug.Log("Error: " + errores);

            if (errores >= maxErrores)
            {
                Debug.Log("PERDISTE");
            }
        }
    }
}