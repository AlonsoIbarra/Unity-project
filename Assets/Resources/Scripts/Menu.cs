using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [HideInInspector]
    public static GameObject MenuGameObject, Reto1GameObject, Reto2GameObject, Reto3GameObject, RetoFinalGameObject;
    private SoundManager sm;

    public static string CurrentScene;
    private static GameObject ParentObject;
    private Button reto1Button, reto2Button, reto3Button, retoFinalButton;

    public enum Scenarios
    {
        Menu,
        Reto1,
        Reto2,
        Reto3,
        Reto4,
        RetoFinal,
    };

    private void Awake()
    {
        ParentObject = gameObject;
        MenuGameObject = ParentObject.transform.GetChild(1).gameObject;
        Reto1GameObject = ParentObject.transform.GetChild(2).gameObject;
        Reto2GameObject = ParentObject.transform.GetChild(3).gameObject;
        Reto3GameObject = ParentObject.transform.GetChild(4).gameObject;
        RetoFinalGameObject = ParentObject.transform.GetChild(5).gameObject;
    }

    // Use this for initialization
    private void Start()
    {
        sm = gameObject.GetComponent<SoundManager>();

        reto1Button = MenuGameObject.transform.GetChild(0).GetComponent<Button>();
        reto2Button = MenuGameObject.transform.GetChild(1).GetComponent<Button>();
        reto3Button = MenuGameObject.transform.GetChild(2).GetComponent<Button>();
        retoFinalButton = MenuGameObject.transform.GetChild(3).GetComponent<Button>();

        reto1Button.onClick.AddListener(delegate ()
        {
            sm.playSound("Sound_Cerrar3", 1); 
            GoToTheNextScenarioButtonMethod(Scenarios.Reto1);
        });
        reto2Button.onClick.AddListener(delegate ()
        {
            sm.playSound("Sound_Cerrar3", 1); 
            GoToTheNextScenarioButtonMethod(Scenarios.Reto2);
        });
        reto3Button.onClick.AddListener(delegate ()
        {
            sm.playSound("Sound_Cerrar3", 1); 
            GoToTheNextScenarioButtonMethod(Scenarios.Reto3);
        });
        retoFinalButton.onClick.AddListener(delegate ()
        {
            sm.playSound("Sound_Cerrar3", 1); 
            GoToTheNextScenarioButtonMethod(Scenarios.RetoFinal);
        });
    }

    private void GoToTheNextScenarioButtonMethod(Scenarios scenarios)
    {
        GoToScenario(scenarios);
    }

    public static void GoToScenarioStaticMethod(Scenarios scenarios)
    {
        GoToScenario(scenarios);
    }

    private static void GoToScenario(Scenarios scenarios)
    {
        //CurrentScene = scenarioName;
        switch (scenarios)
        {
            case Scenarios.Menu:
                MenuGameObject.SetActive(true);
                HideScenarios(1);
                break;

            case Scenarios.Reto1:
                Reto1GameObject.SetActive(true);
                HideScenarios(2);
                break;

            case Scenarios.Reto2:
                Reto2GameObject.SetActive(true);
                HideScenarios(3);
                break;

            case Scenarios.Reto3:
                Reto3GameObject.SetActive(true);
                HideScenarios(4);
                break;

            case Scenarios.RetoFinal:
                HideScenarios(5);
                RetoFinalGameObject.SetActive(true);
                break;
        }
    }

    private static void HideScenarios(int indexUnhiddenScenario)
    {
        for (int i = 0; i < ParentObject.transform.childCount - 1; i++)
        {
            if (indexUnhiddenScenario != i)
            {
                ParentObject.transform.GetChild(i).gameObject.SetActive(false);
            }
            if(indexUnhiddenScenario != 5)
                ParentObject.transform.FindChild("DropDownMenuCamvas").gameObject.SetActive(true);
        }
    }
}