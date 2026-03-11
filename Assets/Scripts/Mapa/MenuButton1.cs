using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton1 : MonoBehaviour
{
    public void EmpezarNivel()
    {
        SceneManager.LoadScene("Nivel1");
    }
}
