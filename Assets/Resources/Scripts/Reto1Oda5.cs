using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using System.Collections.Generic;

namespace Assets.Resources.Scripts
{
    public class Reto1Oda5 : MonoBehaviour
    {
        private GameObject bolsa;
        private GameObject DropDownMenuCamvas;
        private Button inicioButton;

        private Button btnErrorCloseEscenario1;
        private Button btnErrorCloseEscenario2;
        private Button btnFinishCloseEscenario1;
        private Button btnFinishCloseEscenario2;
        private Button btnInstructionsCloseEscenario1;
        private Button btnInstructionsCloseEscenario2;
        private Button btnSuccessCloseEscenario1;
        private Button btnSuccessCloseEscenario2;
        private Button btnTimeOutCloseEscenario1;
        private Button btnTimeOutCloseEscenario2;
        private GameObject cajaGris;
        private GameObject cajaMorada;
        private GameObject clon;
        private GameObject contenedorPiezasGrises;
        private MyTimer cronometro;
        private bool dragging;
        private GameObject draggingItem;
        private GameObject errorEscenario1;
        private GameObject errorEscenario2;
        private GameObject escenario1;

        private GameObject escenario2;
        private GameObject finishEscenario1;
        private GameObject finishEscenario2;
        private bool flag = true;
        public Button HelpEscenario1;
        public Button HelpEscenario2;
        private int helpsChances = 2;
        private GameObject instructionsEscenario1;
        private GameObject instructionsEscenario2;
        private Text marcadorTiempoEscenario1;
        private Text marcadorTiempoEscenario2;
        private GameObject maniqui;
        private GameObject menu;
        private GameObject muñeca;
        private Button object1;
        private Image object1Thumb;
        private Button object2;
        private Image object2Thumb;
        private Button object3;
        private Image object3Thumb;
        private Button object4;
        private Image object4Thumb;
        private Button object5;
        private Image object5Thumb;
        private Button object6;
        private Image object6Thumb;
        private GameObject oso;
        private Image part1;
        private Image part2;
        private Image part3;
        private Image part4;
        private Image part5;
        private Image part6;
        private GameObject partPosition1;
        private GameObject partPosition2;
        private GameObject partPosition3;
        private GameObject partPosition4;
        private GameObject partPosition5;
        private GameObject partPosition6;
        private GameObject relojEscenario1;
        private GameObject relojEscenario2;
        private GameObject reto1;
        private Button reto1Button;
        private SoundManager sm;
        private GameObject successEscenario1;
        private GameObject successEscenario2;
        private Text textErrorEscenario1;
        private Text textErrorEscenario2;
        private Text textSuccessEscenario2;
        private GameObject timeOutEscenario1;
        private GameObject timeOutEscenario2;
        private int timeToPlay;
        private void Start()
        {
            cronometro = gameObject.GetComponent<MyTimer>();
            sm = gameObject.GetComponent<SoundManager>();


            DropDownMenuCamvas = transform.GetChild(6).gameObject;
            inicioButton = DropDownMenuCamvas.transform.GetChild(0).GetChild(0).GetChild(0).transform.FindChild("inicioButton").GetComponent<Button>();
            inicioButton.onClick.AddListener(delegate {
                if(reto1.activeSelf)
                    FinalizarReto1();
            });

            menu = transform.GetChild(1).gameObject;
            reto1Button = menu.transform.FindChild("reto1Button").GetComponent<Button>();
            reto1Button.onClick.AddListener(delegate
            {
                InicializarEscenario1();
				OcultarMenu();
            });


            reto1 = transform.GetChild(2).gameObject;
            reto1.GetComponent<Canvas>().worldCamera = Camera.main;

            escenario1 = reto1.transform.FindChild("Escenario1").gameObject;
            escenario2 = reto1.transform.FindChild("Escenario2").gameObject;

            relojEscenario1 = escenario1.transform.FindChild("relojEscenario1").gameObject;
			marcadorTiempoEscenario1 = relojEscenario1.transform.FindChild("marcadorTiempoEscenario1").GetComponent<Text>();
            relojEscenario2 = escenario2.transform.FindChild("relojEscenario2").gameObject;
            marcadorTiempoEscenario2 = relojEscenario2.transform.FindChild("marcadorTiempoEscenario2").GetComponent<Text>();

            contenedorPiezasGrises = escenario1.transform.FindChild("Contenedor_Piezas_Grises").gameObject;
            instructionsEscenario1 = escenario1.transform.FindChild("InstructionsEscenario1").gameObject;
            btnInstructionsCloseEscenario1 = instructionsEscenario1.transform.FindChild("BtnInstructionsCloseEscenario1").GetComponent<Button>();
            btnInstructionsCloseEscenario1.onClick.AddListener(delegate
            {
                sm.playSound("Sound_Cerrar3", 1); 
                IniciarReto1Escenario1();
            });
            successEscenario1 = escenario1.transform.FindChild("SuccessEscenario1").gameObject;
            successEscenario1.transform.FindChild("TextSuccessEscenario1").GetComponent<Text>();
            btnSuccessCloseEscenario1 =
                successEscenario1.transform.FindChild("BtnSuccessCloseEscenario1").GetComponent<Button>();
            btnSuccessCloseEscenario1.onClick.AddListener(delegate
            {
                successEscenario1.SetActive(false);
                FinalizarEscenario1();
            });
            errorEscenario1 = escenario1.transform.FindChild("ErrorEscenario1").gameObject;
            textErrorEscenario1 = errorEscenario1.transform.FindChild("TextErrorEscenario1").GetComponent<Text>();
            btnErrorCloseEscenario1 =
                errorEscenario1.transform.FindChild("BtnErrorCloseEscenario1").GetComponent<Button>();
            btnErrorCloseEscenario1.onClick.AddListener(delegate
            {
                sm.playSound("Sound_Cerrar3", 1); 
                errorEscenario1.SetActive(false);
                MostrarMenu();
            });
            finishEscenario1 = escenario1.transform.FindChild("FinishEscenario1").gameObject;
            btnFinishCloseEscenario1 =
                finishEscenario1.transform.FindChild("BtnFinishCloseEscenario1").GetComponent<Button>();
            btnFinishCloseEscenario1.onClick.AddListener(delegate
            {
                //sm.playSound("Sound_Cerrar3", 1); 
                IniciarReto1Escenario2();
            });
            HelpEscenario1 = escenario1.transform.FindChild("HelpEscenario1").GetComponent<Button>();
            HelpEscenario1.onClick.AddListener(delegate { HelpTouchEscenario1(); });
            object1 = escenario1.transform.FindChild("Object1").GetComponent<Button>();
            object1Thumb = escenario1.transform.FindChild("Object1Thumb").GetComponent<Image>();
            oso = object1.transform.FindChild("oso").gameObject;

            object2 = escenario1.transform.FindChild("Object2").GetComponent<Button>();
            object2Thumb = escenario1.transform.FindChild("Object2Thumb").GetComponent<Image>();
            maniqui = object2.transform.FindChild("maniqui").gameObject;


            object3 = escenario1.transform.FindChild("Object3").GetComponent<Button>();
            object3Thumb = escenario1.transform.FindChild("Object3Thumb").GetComponent<Image>();
            cajaGris = object3.transform.FindChild("caja_gris").gameObject;

            object4 = escenario1.transform.FindChild("Object4").GetComponent<Button>();
            object4Thumb = escenario1.transform.FindChild("Object4Thumb").GetComponent<Image>();
            cajaMorada = object4.transform.FindChild("caja_morada").gameObject;

            object5 = escenario1.transform.FindChild("Object5").GetComponent<Button>();
            object5Thumb = escenario1.transform.FindChild("Object5Thumb").GetComponent<Image>();
            bolsa = object5.transform.FindChild("bolsa").gameObject;

            object6 = escenario1.transform.FindChild("Object6").GetComponent<Button>();
            object6Thumb = escenario1.transform.FindChild("Object6Thumb").GetComponent<Image>();
            muñeca = object6.transform.FindChild("muñeca").gameObject;

            part1 = escenario2.transform.FindChild("Part1").GetComponent<Image>();
            partPosition1 = escenario2.transform.FindChild("PartPosition1").gameObject;
            part2 = escenario2.transform.FindChild("Part2").GetComponent<Image>();
            partPosition2 = escenario2.transform.FindChild("PartPosition2").gameObject;
            part3 = escenario2.transform.FindChild("Part3").GetComponent<Image>();
            partPosition3 = escenario2.transform.FindChild("PartPosition3").gameObject;
            part4 = escenario2.transform.FindChild("Part4").GetComponent<Image>();
            partPosition4 = escenario2.transform.FindChild("PartPosition4").gameObject;
            part5 = escenario2.transform.FindChild("Part5").GetComponent<Image>();
            partPosition5 = escenario2.transform.FindChild("PartPosition5").gameObject;
            part6 = escenario2.transform.FindChild("Part6").GetComponent<Image>();
            partPosition6 = escenario2.transform.FindChild("PartPosition6").gameObject;
            timeOutEscenario1 = escenario1.transform.FindChild("TimeOutEscenario1").gameObject;
            btnTimeOutCloseEscenario1 = timeOutEscenario1.transform.FindChild("BtnTimeOutCloseEscenario1").GetComponent<Button>();
            btnTimeOutCloseEscenario1.onClick.AddListener(delegate
            {
                sm.playSound("Sound_Cerrar3", 1); 
                RestablecerPiezasEscenario1();
                ReiniciarEscenario1();
            });

            //Escenario 2
            instructionsEscenario2 = escenario2.transform.FindChild("InstructionsEscenario2").gameObject;
            btnInstructionsCloseEscenario2 = instructionsEscenario2.transform.FindChild("BtnInstructionsCloseEscenario2").GetComponent<Button>();
            btnInstructionsCloseEscenario2.onClick.AddListener(delegate
            {
                sm.playSound("Sound_Cerrar3", 1); 
                InicializarEscenario2();
            });
            successEscenario2 = escenario2.transform.FindChild("SuccessEscenario2").gameObject;
            textSuccessEscenario2 = successEscenario2.transform.FindChild("TextSuccessEscenario2").GetComponent<Text>();
            btnSuccessCloseEscenario2 =
                successEscenario2.transform.FindChild("BtnSuccessCloseEscenario2").GetComponent<Button>();
            btnSuccessCloseEscenario2.onClick.AddListener(delegate
            {
                sm.playSound("Sound_TerminarReto", 1);
                finishEscenario2.SetActive(true);
            });

            finishEscenario2 = escenario2.transform.FindChild("FinishEscenario2").gameObject;
            btnFinishCloseEscenario2 =
                finishEscenario2.transform.FindChild("BtnFinishCloseEscenario2").GetComponent<Button>();
            btnFinishCloseEscenario2.onClick.AddListener(delegate { FinalizarReto1(); });
            timeOutEscenario2 = escenario2.transform.FindChild("TimeOutEscenario2").gameObject;
            btnTimeOutCloseEscenario2 =
                timeOutEscenario2.transform.FindChild("BtnTimeOutCloseEscenario2").GetComponent<Button>();
            btnTimeOutCloseEscenario2.onClick.AddListener(delegate
            {
                sm.playSound("Sound_Cerrar3", 1); 
                timeOutEscenario2.SetActive(false);
                instructionsEscenario2.SetActive(true);
            });
            HelpEscenario2 = escenario2.transform.FindChild("HelpEscenario2").GetComponent<Button>();
            HelpEscenario2.onClick.AddListener(delegate { HelpTouchEscenario2(); });
            errorEscenario2 = escenario2.transform.FindChild("ErrorEscenario2").gameObject;
            textErrorEscenario2 = errorEscenario2.transform.FindChild("TextErrorEscenario2").GetComponent<Text>();
            btnErrorCloseEscenario2 = errorEscenario2.transform.FindChild("BtnErrorCloseEscenario2").GetComponent<Button>();
            btnErrorCloseEscenario2.onClick.AddListener(delegate
            {
                sm.playSound("Sound_Cerrar3", 1); 
                errorEscenario2.SetActive(false);
                cronometro.ContinueTimer();
                MostrarMenu();
            });
        }
        // Update is called once per frame
        private void MostrarMenu() {
			DropDownMenuCamvas.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<Button>().interactable=true;
        }
        private void OcultarMenu() {
			DropDownMenuCamvas.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<Button>().interactable=false;
        }
        private void Update()
        {
            if (escenario1.activeSelf)
            {
                marcadorTiempoEscenario1.text = Math.Truncate(Double.Parse(cronometro.remainingTime.ToString())).ToString();
                if (cronometro.isEnable() && (cronometro.remainingTime < 0.2))
                    FinishTimeEscenario1();
                if (Input.touchCount > 0)
                {
                    var pos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                    var hit = Physics2D.Raycast(pos, Vector2.zero);
                    if ((dragging == false) && (hit.collider != null) && (Input.GetTouch(0).phase == TouchPhase.Began))
                        if ((hit.collider.gameObject.name == "Object1") ||
                            (hit.collider.gameObject.name == "Object2") ||
                            (hit.collider.gameObject.name == "Object3") ||
                            (hit.collider.gameObject.name == "Object4") ||
                            (hit.collider.gameObject.name == "Object5") ||
                            (hit.collider.gameObject.name == "Object6")
                        ) SeleccionarObjeto(hit.collider.gameObject);
                }
            }
            if (escenario2.activeSelf)
            {
                marcadorTiempoEscenario2.text = Math.Truncate(Double.Parse(cronometro.remainingTime.ToString())).ToString();
                if (cronometro.isEnable() && (cronometro.remainingTime < 0.2))
                    FinishTimeEscenario2();
                if (Input.touchCount > 0)
                {
                    var pos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                    var hit = Physics2D.Raycast(pos, Vector2.zero);
                    if ((dragging == false) && (hit.collider != null) && (Input.GetTouch(0).phase == TouchPhase.Moved))
                        try
                        {
                            if ((hit.collider.gameObject.name == "Part1") ||
                                (hit.collider.gameObject.name == "Part2") ||
                                (hit.collider.gameObject.name == "Part3") ||
                                (hit.collider.gameObject.name == "Part4") ||
                                (hit.collider.gameObject.name == "Part5") ||
                                (hit.collider.gameObject.name == "Part6"))
                            {
                                draggingItem = hit.collider.gameObject;
                                dragging = true;
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.Log(ex.Message);
                        }
                    if (Input.GetTouch(0).phase == TouchPhase.Moved)
                        if (dragging)
                            draggingItem.transform.position = new Vector3(pos.x, pos.y,
                                draggingItem.transform.position.z);
                    if (Input.GetTouch(0).phase == TouchPhase.Ended)
                        if (dragging)
                        {
                            if (
                            (Vector3.Distance(draggingItem.transform.localPosition,
                                 partPosition1.transform.localPosition) < 80) && (draggingItem.name == "Part1"))
                            {
                                sm.playSound("Sound_correcto10", 1);
                                    
                                draggingItem.transform.localPosition = partPosition1.transform.localPosition;
                                partPosition1.SetActive(true);
                                draggingItem.SetActive(false);
                            }
                            else if (
                            (Vector3.Distance(draggingItem.transform.localPosition,
                                 partPosition2.transform.localPosition) < 80) && (draggingItem.name == "Part2"))
                            {
                                sm.playSound("Sound_correcto10", 1);
                                    
                                draggingItem.transform.localPosition = partPosition2.transform.localPosition;
                                partPosition2.SetActive(true);
                                draggingItem.SetActive(false);
                            }
                            else if (
                            (Vector3.Distance(draggingItem.transform.localPosition,
                                 partPosition3.transform.localPosition) < 80) && (draggingItem.name == "Part3"))
                            {
                                sm.playSound("Sound_correcto10", 1);
                                    
                                draggingItem.transform.localPosition = partPosition3.transform.localPosition;
                                partPosition3.SetActive(true);
                                draggingItem.SetActive(false);
                            }
                            else if (
                            (Vector3.Distance(draggingItem.transform.localPosition,
                                 partPosition4.transform.localPosition) < 80) && (draggingItem.name == "Part4"))
                            {
                                sm.playSound("Sound_correcto10", 1);
                                    
                                draggingItem.transform.localPosition = partPosition4.transform.localPosition;
                                partPosition4.SetActive(true);
                                draggingItem.SetActive(false);
                            }
                            else if (
                            (Vector3.Distance(draggingItem.transform.localPosition,
                                 partPosition5.transform.localPosition) < 80) && (draggingItem.name == "Part5"))
                            {
                                sm.playSound("Sound_correcto10", 1);
                                    
                                draggingItem.transform.localPosition = partPosition5.transform.localPosition;
                                partPosition5.SetActive(true);
                                draggingItem.SetActive(false);
                            }
                            else if (
                            (Vector3.Distance(draggingItem.transform.localPosition,
                                 partPosition6.transform.localPosition) < 80) && (draggingItem.name == "Part6"))
                            {
                                sm.playSound("Sound_correcto10", 1);
                                    
                                draggingItem.transform.localPosition = partPosition6.transform.localPosition;
                                partPosition6.SetActive(true);
                                draggingItem.SetActive(false);
                            }
                            dragging = false;
                        }
                }
                IsCompleteReto1Escenario2();
            }
        }

        private void InicializarEscenario1()
        {
            sm.playSound("Sound_OpenPopUp10", 1); 
            escenario1.SetActive(true);
            escenario2.SetActive(false);
            instructionsEscenario1.SetActive(true);
            timeOutEscenario1.SetActive(false);
            finishEscenario1.SetActive(false);
            errorEscenario1.SetActive(false);
            RestablecerPiezasEscenario1();
            helpsChances = 2;
        }

        private void RestablecerPiezasEscenario1()
        {
            object1.gameObject.SetActive(true);
            object1Thumb.gameObject.SetActive(false);
            object2.gameObject.SetActive(true);
            object2Thumb.gameObject.SetActive(false);
            object3.gameObject.SetActive(true);
            object3Thumb.gameObject.SetActive(false);
            object4.gameObject.SetActive(true);
            object4Thumb.gameObject.SetActive(false);
            object5.gameObject.SetActive(true);
            object5Thumb.gameObject.SetActive(false);
            object6.gameObject.SetActive(true);
            object6Thumb.gameObject.SetActive(false);
            object1.gameObject.GetComponent<Image>().enabled = true;
            object2.gameObject.GetComponent<Image>().enabled = true;
            object3.gameObject.GetComponent<Image>().enabled = true;
            object4.gameObject.GetComponent<Image>().enabled = true;
            object5.gameObject.GetComponent<Image>().enabled = true;
            object6.gameObject.GetComponent<Image>().enabled = true;
            ReubicarPiezasReto1();
        }

        private void ReubicarPiezasReto1()
        {
            var location = Random.Range(0, 4);
            var positions = new int[3];
            switch (location) {
                case 0:
                    object1.transform.localPosition = new Vector3(-53, -361, 0);
                    object2.transform.localPosition = new Vector3(407, -267, 0);
                    object3.transform.localPosition = new Vector3(227, 70, 0);
                    object4.transform.localPosition = new Vector3(-222, -27, 0);
                    object5.transform.localPosition = new Vector3(-588, -302, 0);
                    object6.transform.localPosition = new Vector3(185, -356, 0);
                    break;
                case 1:
                    object1.transform.localPosition = new Vector3(166, -364, 0);
                    object2.transform.localPosition = new Vector3(-482, -132, 0);
                    object3.transform.localPosition = new Vector3(-230,-75, 0);
                    object4.transform.localPosition = new Vector3(184, -27, 0);
                    object5.transform.localPosition = new Vector3(478, -336, 0);
                    object6.transform.localPosition = new Vector3(72, -287, 0);
                    break;
                case 2:
                    object1.transform.localPosition = new Vector3(-540, -363, 0);
                    object2.transform.localPosition = new Vector3(250, -264, 0);
                    object3.transform.localPosition = new Vector3(-360, -270, 0);
                    object4.transform.localPosition = new Vector3(196, -28, 0);
                    object5.transform.localPosition = new Vector3(-16, -51, 0);
                    object6.transform.localPosition = new Vector3(-229, -43, 0);
                    break;
                case 3:
                    object1.transform.localPosition = new Vector3(429, -363, 0);
                    object2.transform.localPosition = new Vector3(-292, -76, 0);
                    object3.transform.localPosition = new Vector3(360, -370, 0);
                    object4.transform.localPosition = new Vector3(-353, -345, 0);
                    object5.transform.localPosition = new Vector3(-67, -362, 0);
                    object6.transform.localPosition = new Vector3(204, -43, 0);
                    break;
            }
        }

        private void InicializarEscenario2()
        {
            escenario2.SetActive(true);
            instructionsEscenario2.SetActive(false);
            successEscenario2.SetActive(false);
            timeOutEscenario2.SetActive(false);
            finishEscenario2.SetActive(false);
            partPosition1.gameObject.SetActive(false);
            partPosition2.gameObject.SetActive(false);
            partPosition3.gameObject.SetActive(false);
            partPosition4.gameObject.SetActive(false);
            partPosition5.gameObject.SetActive(false);
            partPosition6.gameObject.SetActive(false);
            part1.gameObject.SetActive(true);
            part2.gameObject.SetActive(true);
            part3.gameObject.SetActive(true);
            part4.gameObject.SetActive(true);
            part5.gameObject.SetActive(true);
            part6.gameObject.SetActive(true);
            ReiniciarPiezasEscenario2();
            helpsChances = 2;
            timeToPlay = 20;
            sm.encenderReloj();
            sm.playSound("Sound_reloj1", 2); 
            instructionsEscenario1.SetActive(false);
            contenedorPiezasGrises.SetActive(true);
            cronometro.StartTimer(timeToPlay);
            MostrarMenu();
        }

        private void ReiniciarPiezasEscenario2()
        {
            ReubicarPiezasReto2();
            part1.gameObject.SetActive(true);
            partPosition1.gameObject.SetActive(false);
            part2.gameObject.SetActive(true);
            partPosition2.gameObject.SetActive(false);
            part3.gameObject.SetActive(true);
            partPosition3.gameObject.SetActive(false);
            part4.gameObject.SetActive(true);
            partPosition4.gameObject.SetActive(false);
            part5.gameObject.SetActive(true);
            partPosition5.gameObject.SetActive(false);
            part6.gameObject.SetActive(true);
            partPosition6.gameObject.SetActive(false);
        }

        private void FinishTimeEscenario2()
        {
            if (flag)
            {
                sm.apagarReloj();
                sm.playSound("Sound_TimeOver", 1); 
                timeOutEscenario2.SetActive(true);
                ReiniciarPiezasEscenario2();
                flag = false;
            }
        }

        private void IniciarReto1Escenario1()
        {
            Invoke("ClonarGameObject",1);
            sm.playSound("Sound_reloj1", 2); 
            sm.encenderReloj();
            timeToPlay = 30;
            flag = true;
            instructionsEscenario1.SetActive(false);
            contenedorPiezasGrises.SetActive(true);
            cronometro.StartTimer(timeToPlay);
            MostrarMenu();
        }

        private void FinishTimeEscenario1()
        {
            if (flag)
            {
                sm.apagarReloj();
                sm.playSound("Sound_TimeOver", 1); 
                timeOutEscenario1.SetActive(true);
                flag = false;
                OcultarMenu();
            }
        }

        private void ReiniciarEscenario1()
        {
            timeOutEscenario1.SetActive(false);
            instructionsEscenario1.SetActive(true);
        }

        private void IsCompleteReto1Escenario2()
        {
            if (partPosition1.activeSelf && partPosition2.activeSelf &&
                partPosition3.activeSelf && partPosition4.activeSelf &&
                partPosition5.activeSelf && partPosition6.activeSelf)
            {
                cronometro.StopTimer();
                sm.apagarReloj();
                if (flag)
                {
                    Invoke("FinalizarEscenario2", 2f);
                    flag = false;
                }
            }
        }

        private void FinalizarEscenario2()
        {
            var adivinanzas = new string[3];
            adivinanzas[0] =
                "La palabra “bullying” se deriva de “bully”, puede significar “intimidar” e incorporado al español se refiere a la intimidación física y verbal ejercida por uno o varios compañeros sobre otro.";
            adivinanzas[1] =
                "El bullying comienza con burlas que se van intensificando hasta que, tarde o temprano, derivan en agresiones, sean físicas o verbales.Las consecuencias de esto son daños psicológicos y emocionales en el individuo afectado por el acoso.";
            adivinanzas[2] =
                "El bullying consiste en la práctica de actos violentos o intimidatorios constantes sobre una persona.Puede ser realizado por una o varias personas con el propósito de agredir, de hacer sentir insegura a la víctima, o para entorpecer su desenvolvimiento en su entorno.";
            if (!successEscenario2.activeSelf)
                textSuccessEscenario2.text = adivinanzas[Random.Range(0, 3)];

            sm.playSound("Sound_SumarioRespuestas", 1);
            successEscenario2.SetActive(true);
            OcultarMenu();
        }
        void ClonarGameObject() {
            clon = Instantiate(gameObject);
            clon.SetActive(false);
            clon.transform.GetChild(2).gameObject.SetActive(false);
            clon.transform.GetChild(3).gameObject.SetActive(true);
			clon.transform.GetChild(6).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<Button>().interactable=true;
        }
        private void FinalizarReto1()
        {
            clon.name = "ODA5";
            clon.SetActive(true);
            clon.transform.FindChild("DropDownMenuCamvas").gameObject.SetActive(true);
            Destroy(gameObject);
        }

        private void IniciarReto1Escenario2()
        {
            sm.playSound("Sound_OpenPopUp10", 1); 
            escenario1.SetActive(false);
            escenario2.SetActive(true);
            instructionsEscenario2.SetActive(true);
            cronometro.remainingTime = 0;
            ReubicarPiezasReto2();
        }

        private void ReubicarPiezasReto2()
        {
            flag = true;
            float xLimitMin = -4;
            float xLimitMax = 4;
            float yLimitMin = -2;
            float yLimitMax = 1;
            var pos = part1.rectTransform.position;
            pos.x = Random.Range(xLimitMin, xLimitMax);
            pos.y = Random.Range(yLimitMin, yLimitMax);
            part1.rectTransform.position = pos;
            pos = part2.rectTransform.position;
            pos.x = Random.Range(xLimitMin, xLimitMax);
            pos.y = Random.Range(yLimitMin, yLimitMax);
            part2.rectTransform.position = pos;
            pos = part3.rectTransform.position;
            pos.x = Random.Range(xLimitMin, xLimitMax);
            pos.y = Random.Range(yLimitMin, yLimitMax);
            part3.rectTransform.position = pos;
            pos = part4.rectTransform.position;
            pos.x = Random.Range(xLimitMin, xLimitMax);
            pos.y = Random.Range(yLimitMin, yLimitMax);
            part4.rectTransform.position = pos;
            pos = part5.rectTransform.position;
            pos.x = Random.Range(xLimitMin, xLimitMax);
            pos.y = Random.Range(yLimitMin, yLimitMax);
            part5.rectTransform.position = pos;
            pos = part5.rectTransform.position;
            pos.x = Random.Range(xLimitMin, xLimitMax);
            pos.y = Random.Range(yLimitMin, yLimitMax);
            part5.rectTransform.position = pos;
        }

        private void HelpTouchEscenario1()
        {
            if (helpsChances > 0)
            {
                helpsChances--;
                helpEscenario1();
            }
            else
            {
                sm.playSound("Sound_OpenPopUp10", 1); 
                textErrorEscenario1.text = "Ya usaste toda la ayuda disponible.";
                errorEscenario1.SetActive(true);
                OcultarMenu();
            }
        }

        private void helpEscenario1()
        {
            var item = getItem();
            item.GetComponent<Animator>().SetBool("helpBool", true);
            StartCoroutine("disableAnimation", item);
        }

        private IEnumerator disableAnimation(GameObject item)
        {
            yield return new WaitForSeconds(2f);
            item.GetComponent<Animator>().SetBool("helpBool", false);
        }

        private GameObject getItem()
        {
            List<GameObject> lista = getListObjectsHelp();
            print(lista);
            print(lista.Count);
            var itemIndex = Random.Range(0, lista.Count);
            print(itemIndex);

            return lista[itemIndex];
        }
        private List<GameObject> getListObjectsHelp() {
            List<GameObject> lista = new List<GameObject>();

            if (!object1Thumb.gameObject.activeSelf)
                lista.Add(oso);
            if (!object2Thumb.gameObject.activeSelf)
                lista.Add(maniqui);
            if (!object3Thumb.gameObject.activeSelf)
                lista.Add(cajaGris);
            if (!object4Thumb.gameObject.activeSelf)
                lista.Add(cajaMorada);
            if (!object5Thumb.gameObject.activeSelf)
                lista.Add(bolsa);
            if (!object6Thumb.gameObject.activeSelf)
                lista.Add(muñeca);
            return lista;
        }
    private void HelpTouchEscenario2()
        {
            if (helpsChances > 0)
            {
                helpsChances--;
                helpEscenario2();
            }
            else
            {
                sm.playSound("Sound_OpenPopUp10", 1); 
                cronometro.StopTimer();
                textErrorEscenario2.text = "Ya usaste toda la ayuda disponible.";
                errorEscenario2.SetActive(true);
                OcultarMenu();
            }
        }

        private void helpEscenario2()
        {
            // enable help
            var arr = new GameObject[3];
            if (part1.gameObject.activeSelf)
            {
                arr[0] = part1.gameObject;
                arr[1] = partPosition1.gameObject;
                StartCoroutine("changePartVisivility", arr);
            }
            else if (part2.gameObject.activeSelf)
            {
                arr[0] = part2.gameObject;
                arr[1] = partPosition2.gameObject;
                StartCoroutine("changePartVisivility", arr);
            }
            else if (part3.gameObject.activeSelf)
            {
                arr[0] = part3.gameObject;
                arr[1] = partPosition3.gameObject;
                StartCoroutine("changePartVisivility", arr);
            }
            else if (part4.gameObject.activeSelf)
            {
                arr[0] = part4.gameObject;
                arr[1] = partPosition4.gameObject;
                StartCoroutine("changePartVisivility", arr);
            }
            else if (part5.gameObject.activeSelf)
            {
                arr[0] = part5.gameObject;
                arr[1] = partPosition5.gameObject;
                StartCoroutine("changePartVisivility", arr);
            }
            else if (part6.gameObject.activeSelf)
            {
                arr[0] = part6.gameObject;
                arr[1] = partPosition6.gameObject;
                StartCoroutine("changePartVisivility", arr);
            }
        }

        private IEnumerator changePartVisivility(GameObject[] arr)
        {
            arr[0].SetActive(false);
            arr[1].SetActive(true);
            yield return new WaitForSeconds(0.3f);
            arr[0].SetActive(true);
            arr[1].SetActive(false);
            yield return new WaitForSeconds(0.3f);
            arr[0].SetActive(false);
            arr[1].SetActive(true);
            yield return new WaitForSeconds(0.3f);
            arr[0].SetActive(true);
            arr[1].SetActive(false);
        }

        private void SeleccionarObjeto(GameObject Objeto)
        {
            //     sm.playSound("Sound_correcto10", 1); 

            //		Objeto.SetActive (false);
            Objeto.GetComponent<Image>().enabled = false;
            if (Objeto.name == "Object1") object1Thumb.gameObject.SetActive(true);
            else if (Objeto.name == "Object2") object2Thumb.gameObject.SetActive(true);
            else if (Objeto.name == "Object3") object3Thumb.gameObject.SetActive(true);
            else if (Objeto.name == "Object4") object4Thumb.gameObject.SetActive(true);
            else if (Objeto.name == "Object5") object5Thumb.gameObject.SetActive(true);
            else if (Objeto.name == "Object6") object6Thumb.gameObject.SetActive(true);
            FinalizarEscenario1();
        }

        private void FinalizarEscenario1()
        {
            var finalizarEscenario1 = true;
            if (object1.gameObject.GetComponent<Image>().enabled) finalizarEscenario1 = false;
            else if (object2.gameObject.GetComponent<Image>().enabled) finalizarEscenario1 = false;
            else if (object3.gameObject.GetComponent<Image>().enabled) finalizarEscenario1 = false;
            else if (object4.gameObject.GetComponent<Image>().enabled) finalizarEscenario1 = false;
            else if (object5.gameObject.GetComponent<Image>().enabled) finalizarEscenario1 = false;
            else if (object6.gameObject.GetComponent<Image>().enabled) finalizarEscenario1 = false;
            if (finalizarEscenario1)
            {
                cronometro.StopTimer();
                sm.apagarReloj();
                sm.playSound("Sound_OpenPopUp10", 1); 
                finishEscenario1.SetActive(true);
                OcultarMenu();
            }
        }
    }
}