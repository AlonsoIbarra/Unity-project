using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DropDownMenu : MonoBehaviour
{
    private GameObject dropDownMenuGameObject;
    private Boolean openMenu;
    private Button toggleMenuButton;
    private Animator menuAnimator;

    private Button closePopUpButton;

    //private GameObject popUpContainterGameObject;
    private GameObject imgFichaTecnicaGameObject, imgCreditosGameObject, imgGlosarioGameObject;

    private Button fichaTecnicaButton, creditosButton, glosarioButton;
    private Button inicioButton;
    private SoundManager sm;

    // Use this for initialization
    private void Start()
    {
//        dropDownMenuGameObject = GameObject.Find("dropDownMenu");
        dropDownMenuGameObject = gameObject.transform.GetChild(6).gameObject.transform.FindChild("dropDownMenu").gameObject;
        sm = gameObject.GetComponent<SoundManager>();

        toggleMenuButton = dropDownMenuGameObject.transform.GetChild(0).GetComponent<Button>();
        menuAnimator = dropDownMenuGameObject.transform.GetChild(0).GetChild(0).GetComponent<Animator>();
        closePopUpButton = dropDownMenuGameObject.transform.GetChild(1).GetComponent<Button>();

        imgFichaTecnicaGameObject = closePopUpButton.transform.GetChild(0).GetChild(0).gameObject;
        imgCreditosGameObject = closePopUpButton.transform.GetChild(0).GetChild(1).gameObject;
        imgGlosarioGameObject = closePopUpButton.transform.GetChild(0).GetChild(2).gameObject;

        fichaTecnicaButton = menuAnimator.transform.GetChild(0).GetComponent<Button>();
        creditosButton = menuAnimator.transform.GetChild(1).GetComponent<Button>();
        glosarioButton = menuAnimator.transform.GetChild(2).GetComponent<Button>();
        inicioButton = menuAnimator.transform.GetChild(3).GetComponent<Button>();

        toggleMenuButton.onClick.AddListener(ToggleMenu);
        closePopUpButton.onClick.AddListener(ClosePopUps);

        fichaTecnicaButton.onClick.AddListener(delegate ()
        {
            sm.playSound("Sound_Cerrar3", 1); 
            OpenPopUp("Ficha_Tecnica");
        });
        creditosButton.onClick.AddListener(delegate ()
        {
            sm.playSound("Sound_Cerrar3", 1); 
            OpenPopUp("Creditos");
        });
        glosarioButton.onClick.AddListener(delegate ()
        {
            sm.playSound("Sound_Cerrar3", 1); 
            OpenPopUp("Glosario");
        });
        inicioButton.onClick.AddListener(delegate ()
        {
            sm.playSound("Sound_Cerrar3", 1); 
            GoToInicio();
        });
    }

    private void OpenPopUp(string popUpName)
    {
        closePopUpButton.gameObject.SetActive(true);
        if (popUpName == "Ficha_Tecnica")
        {
            imgFichaTecnicaGameObject.SetActive(true);
        }
        else if (popUpName == "Creditos")
        {
            imgCreditosGameObject.SetActive(true);
        }
        else if (popUpName == "Glosario")
        {
            imgGlosarioGameObject.SetActive(true);
        }
        ToggleMenu();
    }

    private void ClosePopUps()
    {
        sm.playSound("Sound_Cerrar3", 1); 
        imgFichaTecnicaGameObject.SetActive(false);
        imgCreditosGameObject.SetActive(false);
        imgGlosarioGameObject.SetActive(false);
        closePopUpButton.gameObject.SetActive(false);
    }

    private void GoToInicio()
    {
        Menu.GoToScenarioStaticMethod(Menu.Scenarios.Menu);
        ToggleMenu();
    }

    private void ToggleMenu()
    {
        sm.playSound("Sound_Cerrar3", 1); 
        openMenu = !openMenu;
        menuAnimator.SetBool("Opened", openMenu);
    }

    private void Update()
    {
        if (gameObject.transform.FindChild("Menu").gameObject.activeSelf || gameObject.transform.FindChild("RetoFinal").gameObject.activeSelf)
        {
            inicioButton.gameObject.SetActive(false);
        }
        else
        {
            inicioButton.gameObject.SetActive(true);
        }
    }
}