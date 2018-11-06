using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class Inicio : MonoBehaviour
{
    private GameObject inicioGameObject;
    private GameObject menuGameObject;

    private Button goMenuButton;
    private SoundManager sm;
	// Use this for initialization
	void Start ()
	{
        sm = gameObject.GetComponent<SoundManager>();
        sm.playSound("Sound_Fondo_piano", 0);
        inicioGameObject = transform.GetChild(0).gameObject;
        goMenuButton = inicioGameObject.transform.GetChild(1).gameObject.GetComponent<Button>();
	    menuGameObject = transform.GetChild(1).gameObject;

        goMenuButton.onClick.AddListener(GoToMainMenu);

    }





    private void GoToMainMenu()
    {
        sm.playSound("Sound_Cerrar3", 1); // nombre de archivo , 0 fondo || 1 efectos
        inicioGameObject.SetActive(false);
        menuGameObject.SetActive(true);
    }






	// Update is called once per frame
	void Update () {
	
	}
}
