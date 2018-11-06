using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using System.IO;
using UnityEngine.iOS;

namespace Assets.Resources.Scripts
{
    public class Reto3Oda5 : MonoBehaviour
    {
        Texture2D texture1;
        private static AndroidJavaObject _activity;
        private GameObject DropDownMenuCamvas;
        private Button inicioButton;
        private readonly List<GameObject> listaPegatinas = new List<GameObject>();
        private readonly List<Image> listaPegatinasFin = new List<Image>();
        private readonly List<Image> pegatinasGanadas = new List<Image>();
        private int escena = 0;
        private GameObject adivinanzaEscenario1;
        private GameObject alarma;
        private Image alarmaPegatina;
        private Button botonCloseImage;
        private Button botonCloseTexto;
        private Button btnAdivinanzaRespuesta1Escenario1;
        private Button btnAdivinanzaRespuesta2Escenario1;
        private Button btnFinishCloseEscenario2;
        private Button btnGuardar;
        private Button btnInicio;
        private Button btnInstructionsCloseEscenario1;
        private Button btnPopUpCloseEscenario1;
        private Button btnPopUpCloseEscenario2;
        private Button btnSiguiente;
        private GameObject clon;
        private Button closeImage;
        private Button closeTexto;
        private GameObject contenedorImagenes;
        private GameObject contenedorImagenesThumb;
        private GameObject contenedorPegatinas;
        private GameObject contenedorPegatinasGanadas;
        private GameObject contenedorTextos;
        private GameObject contenedorTextosThumb;
        private Button contenido;
        private Button contraportada;
        private GameObject corazon;
        private Image corazonPegatina;
        private int countAdivinanzas;
        private int countPegatinas;
        private bool dragging;
        private GameObject draggingItem;
        private GameObject errorAdivinanzaEscenario1;
        private GameObject escenario1;
        private GameObject escenario2;
        private GameObject estrella;
        private Image estrellaPegatina;
        private GameObject finishEscenario1;
        private GameObject finishEscenario2;
        private Image fondo2;
        private GameObject fondo2Escenario2;
        private Image fondoBrillo;
        private Image imagen1;
        private GameObject imagen1Pos;
        private Button imagen1Thumb;
        private Image imagen2;
        private GameObject imagen2Pos;
        private Button imagen2Thumb;
        private Image imagen3;
        private GameObject imagen3Pos;
        private Button imagen3Thumb;
        private Image imagen4;
        private GameObject imagen4Pos;
        private Button imagen4Thumb;
        private Image imagen5;
        private Button imagen5Thumb;
        private Button imagenes;
        private GameObject instructionsEscenario1;
        private GameObject menu;
        private Image parte1;
        private Image parte2;
        private Image parte3;
        private GameObject partesTriptico;
        private GameObject popUpEscenario1;
        private GameObject popUpEscenario2;
        private Button portada;
        private Vector3 posIni;
        private List<string[]> preguntasEscenario1 = new List<string[]>();
        private int randomIndexPregunta;
        private GameObject reto3;
        private SoundManager sm;
        private GameObject successEscenario1;
        private Text textAdivinanzaEscenario1;
        private Text textAdivinanzaRespuesta1Escenario1;
        private Text textAdivinanzaRespuesta2Escenario1;
        private Text textFinishEscenario1;
        private Image texto1;
        private GameObject texto1Pos;
        private Button texto1Thumb;
        private Image texto2;
        private GameObject texto2Pos;
        private Button texto2Thumb;
        private Image texto3;
        private GameObject texto3Pos;
        private Button texto3Thumb;
        private Image texto4;
        private GameObject texto4Pos;
        private Button texto4Thumb;
        private Image texto5;
        private Button texto5Thumb;
        private Image texto6;
        private Button texto6Thumb;
        private Button textos;
        private Text textPopUpEscenario1;
        private Text textPopUpEscenario2;
        private GameObject triptico;
        private GameObject tripticoEscenario2;
        private Image tripticoParte1;
        private Image tripticoParte2;
        private Image tripticoParte3;
        private Text txtInstrucionsEscenario1;
        // ************ ESCENARIO 2
        private Button zonaTriptico;
        private GameObject contenedorPartes;
        private Button botonClosePartes;
        private Image zoomParte1;
        private Image zoomParte2;
        private Image zoomParte3;
        private bool inicializado = false;
        private void Start()
        {
            DropDownMenuCamvas = transform.GetChild(6).gameObject;
            inicioButton = DropDownMenuCamvas.transform.GetChild(0).GetChild(0).GetChild(0).transform.FindChild("inicioButton").GetComponent<Button>();
            inicioButton.onClick.AddListener(delegate {
                if (reto3.activeSelf)
                    FinalizarReto3(false);
            });
            menu = transform.GetChild(1).gameObject;
            reto3 = transform.GetChild(4).gameObject;
            reto3.GetComponent<Canvas>().worldCamera = Camera.main;
            sm = gameObject.GetComponent<SoundManager>();
            escenario1 = reto3.transform.FindChild("Escenario1").gameObject;
            fondo2 = escenario1.transform.FindChild("Fondo2").GetComponent<Image>();
            contenedorPegatinas = escenario1.transform.FindChild("contenedor_pegatinas").gameObject;
            fondoBrillo = contenedorPegatinas.transform.FindChild("FondoBrillo").GetComponent<Image>();
            estrella = contenedorPegatinas.transform.FindChild("estrella").gameObject;
            alarma = contenedorPegatinas.transform.FindChild("alarma").gameObject;
            corazon = contenedorPegatinas.transform.FindChild("corazon").gameObject;
            listaPegatinas.Add(alarma);
            listaPegatinas.Add(corazon);
            listaPegatinas.Add(estrella);
            btnSiguiente = escenario1.transform.FindChild("BtnSiguiente").GetComponent<Button>();
            btnSiguiente.onClick.AddListener(delegate { IniciarEscenario2(); });
            popUpEscenario1 = escenario1.transform.FindChild("PopUpEscenario1").gameObject;
            textPopUpEscenario1 = popUpEscenario1.transform.FindChild("TextPopUpEscenario1").GetComponent<Text>();
            btnPopUpCloseEscenario1 = popUpEscenario1.transform.FindChild("BtnPopUpCloseEscenario1").GetComponent<Button>();
            btnPopUpCloseEscenario1.onClick.AddListener(delegate
            {
                sm.playSound("Sound_Cerrar3", 1); 
                popUpEscenario1.SetActive(false);
                if(!adivinanzaEscenario1.activeSelf && !instructionsEscenario1.activeSelf)
                    MostrarMenu();
                print(escena);
                switch (escena) {
                    case 0:
                        AddAdivinanza();
                        break;
                    case 1:
                        txtInstrucionsEscenario1.text = "Para resumir, los componentes principales del bullying son:\n" +
                                        "1.Un desequilibrio de poder entre el acosador y la víctima.\n" +
                                        "2. Agresión reiterada hacia una misma víctima.\n" +
                                        "3. Una o varias personas que quieren dañar a la víctima de manera intencionada.";
                        instructionsEscenario1.SetActive(true);
                        OcultarMenu();
                        break;
                    case 2:
                        txtInstrucionsEscenario1.text = "Saca de los sobres los textos e imágenes. Obsérvalos y si los consideras útiles para prevenir el bullying, arrástralos hasta el lugar del tríptico que corresponda.";
                        instructionsEscenario1.SetActive(true);
                        OcultarMenu();
                        break;
                }
                escena = escena + 1;
            });
            adivinanzaEscenario1 = escenario1.transform.FindChild("AdivinanzaEscenario1").gameObject;
            textAdivinanzaEscenario1 = adivinanzaEscenario1.transform.FindChild("TextAdivinanzaEscenario1").GetComponent<Text>();
            btnAdivinanzaRespuesta1Escenario1 = adivinanzaEscenario1.transform.FindChild("BtnAdivinanzaRespuesta1Escenario1").GetComponent<Button>();
            btnAdivinanzaRespuesta1Escenario1.onClick.AddListener(
                delegate { RevisarAdivinanza(btnAdivinanzaRespuesta1Escenario1); });
            textAdivinanzaRespuesta1Escenario1 =
                btnAdivinanzaRespuesta1Escenario1.transform.FindChild("TextAdivinanzaRespuesta1Escenario1")
                    .GetComponent<Text>();
            btnAdivinanzaRespuesta2Escenario1 =
                adivinanzaEscenario1.transform.FindChild("BtnAdivinanzaRespuesta2Escenario1").GetComponent<Button>();
            btnAdivinanzaRespuesta2Escenario1.onClick.AddListener(
                delegate { RevisarAdivinanza(btnAdivinanzaRespuesta2Escenario1); });
            textAdivinanzaRespuesta2Escenario1 =
                btnAdivinanzaRespuesta2Escenario1.transform.FindChild("TextAdivinanzaRespuesta2Escenario1")
                    .GetComponent<Text>();
            instructionsEscenario1 = escenario1.transform.FindChild("InstructionsEscenario1").gameObject;
            txtInstrucionsEscenario1 =
                instructionsEscenario1.transform.FindChild("TxtInstrucionsEscenario1").GetComponent<Text>();
            btnInstructionsCloseEscenario1 =
                instructionsEscenario1.transform.FindChild("BtnInstructionsCloseEscenario1").GetComponent<Button>();
            btnInstructionsCloseEscenario1.onClick.AddListener(delegate
            {
                sm.playSound("Sound_Cerrar3", 1); 
                adivinanzaEscenario1.SetActive(false);
                popUpEscenario1.SetActive(false);
                instructionsEscenario1.SetActive(false);
                MostrarMenu();
            });
            btnInicio = escenario1.transform.FindChild("BtnInicio").GetComponent<Button>();
            btnInicio.onClick.AddListener(delegate
            {
                btnInicio.gameObject.SetActive(false);
                portada.gameObject.SetActive(true);
                portada.GetComponent<Animator>().SetBool("active", true);
                textPopUpEscenario1.text = "Selecciona las diferentes partes de la hoja para recordar las partes de un tríptico.";
                popUpEscenario1.SetActive(true);
                sm.playSound("Sound_OpenPopUp10", 1);
                OcultarMenu(); 
            });
            contenedorImagenesThumb = escenario1.transform.FindChild("ContenedorImagenesThumb").gameObject;
            contenedorTextosThumb = escenario1.transform.FindChild("ContenedorTextosThumb").gameObject;
            contenedorImagenes = escenario1.transform.FindChild("ContenedorImagenes").gameObject;
            contenedorTextos = escenario1.transform.FindChild("ContenedorTextos").gameObject;

            closeImage = contenedorImagenes.transform.FindChild("CloseImage").GetComponent<Button>();
            botonCloseImage = contenedorImagenes.transform.FindChild("BotonCloseImage").GetComponent<Button>();
            botonCloseImage.onClick.AddListener(delegate
            {
                CloseZoomImagenes();
            });
            closeTexto = contenedorTextos.transform.FindChild("CloseTexto").GetComponent<Button>();
            botonCloseTexto = contenedorTextos.transform.FindChild("BotonCloseTexto").GetComponent<Button>();
            botonCloseTexto.onClick.AddListener(delegate
            {
                CloseZoomTextos();
            });
            imagen1Thumb = contenedorImagenesThumb.transform.FindChild("Imagen1Thumb").GetComponent<Button>();
            imagen2Thumb = contenedorImagenesThumb.transform.FindChild("Imagen2Thumb").GetComponent<Button>();
            imagen3Thumb = contenedorImagenesThumb.transform.FindChild("Imagen3Thumb").GetComponent<Button>();
            imagen4Thumb = contenedorImagenesThumb.transform.FindChild("Imagen4Thumb").GetComponent<Button>();
            imagen5Thumb = contenedorImagenesThumb.transform.FindChild("Imagen5Thumb").GetComponent<Button>();
            texto1Thumb = contenedorTextosThumb.transform.FindChild("Texto1Thumb").GetComponent<Button>();
            texto2Thumb = contenedorTextosThumb.transform.FindChild("Texto2Thumb").GetComponent<Button>();
            texto3Thumb = contenedorTextosThumb.transform.FindChild("Texto3Thumb").GetComponent<Button>();
            texto4Thumb = contenedorTextosThumb.transform.FindChild("Texto4Thumb").GetComponent<Button>();
            texto5Thumb = contenedorTextosThumb.transform.FindChild("Texto5Thumb").GetComponent<Button>();
            texto6Thumb = contenedorTextosThumb.transform.FindChild("Texto6Thumb").GetComponent<Button>();
            texto1 = contenedorTextos.transform.FindChild("Texto1").GetComponent<Image>();
            texto2 = contenedorTextos.transform.FindChild("Texto2").GetComponent<Image>();
            texto3 = contenedorTextos.transform.FindChild("Texto3").GetComponent<Image>();
            texto4 = contenedorTextos.transform.FindChild("Texto4").GetComponent<Image>();
            texto5 = contenedorTextos.transform.FindChild("Texto5").GetComponent<Image>();
            texto6 = contenedorTextos.transform.FindChild("Texto6").GetComponent<Image>();
            imagen1 = contenedorImagenes.transform.FindChild("Imagen1").GetComponent<Image>();
            imagen2 = contenedorImagenes.transform.FindChild("Imagen2").GetComponent<Image>();
            imagen3 = contenedorImagenes.transform.FindChild("Imagen3").GetComponent<Image>();
            imagen4 = contenedorImagenes.transform.FindChild("Imagen4").GetComponent<Image>();
            imagen5 = contenedorImagenes.transform.FindChild("Imagen5").GetComponent<Image>();

            imagenes = escenario1.transform.FindChild("Imagenes").GetComponent<Button>();
            textos = escenario1.transform.FindChild("Textos").GetComponent<Button>();

            triptico = escenario1.transform.FindChild("Triptico").gameObject;
            portada = triptico.transform.FindChild("Portada").GetComponent<Button>();
            portada.onClick.AddListener(delegate
            {
                sm.playSound("Sound_OpenPopUp10", 1);
                textPopUpEscenario1.text = "La portada presenta de manera resumida con una imagen y un título el contenido del tríptico. En ocasiones puede llevar un logotipo, una imagen atractiva y clara, además de un título explicativo.";
                popUpEscenario1.SetActive(true);
                portada.gameObject.SetActive(false);
                contraportada.gameObject.SetActive(true);
                portada.GetComponent<Animator>().SetBool("active", false);
                contraportada.GetComponent<Animator>().SetBool("active", true);
                OcultarMenu();
            });
            contraportada = triptico.transform.FindChild("Contraportada").GetComponent<Button>();
            contraportada.onClick.AddListener(delegate
            {
                sm.playSound("Sound_OpenPopUp10", 1); 
                textPopUpEscenario1.text = "La contraportada es un espacio de cierre, en ella aparece un directorio, entre los datos relevantes podemos encontrar: dirección, teléfono, redes sociales, página web, etc. En algunas ocasiones puede haber alguna imagen de acompañamiento.";
                popUpEscenario1.SetActive(true);
                contraportada.gameObject.SetActive(false);
                contenido.gameObject.SetActive(true);
                contraportada.GetComponent<Animator>().SetBool("active", false);
                contenido.GetComponent<Animator>().SetBool("active", true);
                OcultarMenu();
            });
            contenido = triptico.transform.FindChild("Contenido").GetComponent<Button>();
            contenido.onClick.AddListener(delegate
            {
                sm.playSound("Sound_OpenPopUp10", 1);
                textPopUpEscenario1.text = "Esta cara corresponde al contenido del tríptico, es de suma importancia ya que es la primera que sale a la vista del lector cuando se abre el tríptico. La información debe enganchar al lector.";
                popUpEscenario1.SetActive(true);
                contenido.gameObject.SetActive(false);
                contenido.GetComponent<Animator>().SetBool("active", false);
                fondo2.gameObject.SetActive(true);
                imagenes.gameObject.SetActive(true);
                textos.gameObject.SetActive(true);
                EnabledIntermitente();
                OcultarMenu();
            });
            texto1Pos = triptico.transform.FindChild("Texto1Pos").gameObject;
            texto2Pos = triptico.transform.FindChild("Texto2Pos").gameObject;
            texto3Pos = triptico.transform.FindChild("Texto3Pos").gameObject;
            texto4Pos = triptico.transform.FindChild("Texto4Pos").gameObject;
            imagen1Pos = triptico.transform.FindChild("Imagen1Pos").gameObject;
            imagen2Pos = triptico.transform.FindChild("Imagen2Pos").gameObject;
            imagen3Pos = triptico.transform.FindChild("Imagen3Pos").gameObject;
            imagen4Pos = triptico.transform.FindChild("Imagen4Pos").gameObject;

            successEscenario1 = escenario1.transform.FindChild("SuccessEscenario1").gameObject;
            errorAdivinanzaEscenario1 = escenario1.transform.FindChild("ErrorAdivinanzaEscenario1").gameObject;
            finishEscenario1 = escenario1.transform.FindChild("FinishEscenario1").gameObject;
            textFinishEscenario1 = finishEscenario1.transform.FindChild("TextFinishEscenario1").GetComponent<Text>();
            ReiniciarPreguntas();
            //************** ESCENARIO2
            escenario2 = reto3.transform.FindChild("Escenario2").gameObject;
            popUpEscenario2 = escenario2.transform.FindChild("PopUpEscenario2").gameObject;
            textPopUpEscenario2 = popUpEscenario2.transform.FindChild("TextPopUpEscenario2").GetComponent<Text>();
            btnPopUpCloseEscenario2 =
                popUpEscenario2.transform.FindChild("BtnPopUpCloseEscenario2").GetComponent<Button>();
            btnPopUpCloseEscenario2.onClick.AddListener(delegate
            {
                sm.playSound("Sound_Cerrar3", 1);
                popUpEscenario2.SetActive(false);
                MostrarMenu();
                CheckFinishTriptico();
            });
            contenedorPartes = escenario2.transform.FindChild("ContenedorPartes").gameObject;
            botonClosePartes = contenedorPartes.transform.FindChild("BotonClosePartes").GetComponent<Button>();
            botonClosePartes.onClick.AddListener(delegate {
                CloseZoomPartes();
            });
            zoomParte1 = contenedorPartes.transform.FindChild("ZoomParte1").GetComponent<Image>();
            zoomParte2 = contenedorPartes.transform.FindChild("ZoomParte1").GetComponent<Image>();
            zoomParte3 = contenedorPartes.transform.FindChild("ZoomParte1").GetComponent<Image>();

            partesTriptico = escenario2.transform.FindChild("PartesTriptico").gameObject;
            parte1 = partesTriptico.transform.FindChild("Parte1").GetComponent<Image>();
            parte2 = partesTriptico.transform.FindChild("Parte2").GetComponent<Image>();
            parte3 = partesTriptico.transform.FindChild("Parte3").GetComponent<Image>();

            fondo2Escenario2 = escenario2.transform.FindChild("Fondo2Escenario2").gameObject;

            zonaTriptico = escenario2.transform.FindChild("ZonaTriptico").GetComponent<Button>();
            zonaTriptico.onClick.AddListener(delegate
            {
                sm.playSound("Sound_OpenPopUp10", 1);
                textPopUpEscenario2.text = "Los interiores del tríptico deben llevar la información de manera dosificada y organizada para que el lector se familiarice con el tema. Identifica: un texto para introducir y describir conceptos, otro que describa de manera más amplia el tema y uno para concluir el tema.";
                popUpEscenario2.SetActive(true);
                zonaTriptico.GetComponent<Animator>().SetBool("active", false);
                zonaTriptico.gameObject.SetActive(false);
                fondo2Escenario2.SetActive(true);
                tripticoEscenario2.SetActive(true);
                partesTriptico.SetActive(true);
                parte1.gameObject.SetActive(true);
                parte2.gameObject.SetActive(true);
                parte3.gameObject.SetActive(true);
                parte1.GetComponent<Animator>().SetBool("active", false);
                parte2.GetComponent<Animator>().SetBool("active", false);
                parte3.GetComponent<Animator>().SetBool("active", false);
                InitImagenesTriptico();
                OcultarMenu();
            });

            tripticoEscenario2 = escenario2.transform.FindChild("TripticoEscenario2").gameObject;
            tripticoParte1 = tripticoEscenario2.transform.FindChild("TripticoParte1").GetComponent<Image>();
            tripticoParte2 = tripticoEscenario2.transform.FindChild("TripticoParte2").GetComponent<Image>();
            tripticoParte3 = tripticoEscenario2.transform.FindChild("TripticoParte3").GetComponent<Image>();

            contenedorPegatinasGanadas = escenario2.transform.FindChild("contenedorPegatinasGanadas").gameObject;
            alarmaPegatina = contenedorPegatinasGanadas.transform.FindChild("alarmaPegatina").GetComponent<Image>();
            corazonPegatina = contenedorPegatinasGanadas.transform.FindChild("corazonPegatina").GetComponent<Image>();
            estrellaPegatina = contenedorPegatinasGanadas.transform.FindChild("estrellaPegatina").GetComponent<Image>();
            btnGuardar = escenario2.transform.FindChild("BtnGuardar").GetComponent<Button>();
            btnGuardar.onClick.AddListener(delegate
            {
                //guardar pantalla
                StartCoroutine("ScreenshotEncode");
                Invoke("MostrarPopup", 0.5f);
            });

            finishEscenario2 = escenario2.transform.FindChild("FinishEscenario2").gameObject;
            btnFinishCloseEscenario2 = finishEscenario2.transform.FindChild("BtnFinishCloseEscenario2").GetComponent<Button>();
            btnFinishCloseEscenario2.onClick.AddListener(delegate {
                sm.playSound("Sound_TerminarReto", 1);
                FinalizarReto3(true);
            });
            listaPegatinasFin.Add(alarmaPegatina);
            listaPegatinasFin.Add(corazonPegatina);
            listaPegatinasFin.Add(estrellaPegatina);

        }

        private void MostrarPopup()
        {
            sm.playSound("Sound_TerminarReto", 1);
            finishEscenario2.SetActive(true);
            textFinishEscenario1.text = "Tu triptico se guardó en tu dispositivo. Muchas felicidades, estás listo para llevar tu habilidad de diseño a otros trípticos con información relevante, organizada y funcional para informar a otros. ¡Sigamos con el reto final!";
            OcultarMenu();
        }

        private void FinalizarReto3(bool retoConcluido)
        {
            clon.name = "ODA5";
            clon.SetActive(true);
            if (retoConcluido)
            {
                clon.transform.GetChild(5).gameObject.SetActive(true);
                clon.transform.GetChild(4).gameObject.SetActive(false);
                clon.transform.GetChild(1).gameObject.SetActive(false);
                clon.transform.FindChild("DropDownMenuCamvas").gameObject.SetActive(false);
            }
            else
                clon.transform.FindChild("DropDownMenuCamvas").gameObject.SetActive(true);
            Destroy(gameObject);
        }

        private void InitImagenesTriptico()
        {
            var index = Random.Range(0, 3);
            if (index == 0)
            {
                parte1.transform.localPosition = new Vector3(-129.0f, -161.0f, 0.0f);
                parte2.transform.localPosition = new Vector3(-1.5f, -161.0f, 0.0f);
                parte3.transform.localPosition = new Vector3(126.1f, -161.0f, 0.0f);
            }
            else if (index == 1)
            {
                parte1.transform.localPosition = new Vector3(126.1f, -161.0f, 0.0f);
                parte2.transform.localPosition = new Vector3(-129.0f, -161.0f, 0.0f);
                parte3.transform.localPosition = new Vector3(-1.5f, -161.0f, 0.0f);
            }
            else
            {
                parte1.transform.localPosition = new Vector3(-1.5f, -161.0f, 0.0f);
                parte2.transform.localPosition = new Vector3(126.1f, -161.0f, 0.0f);
                parte3.transform.localPosition = new Vector3(-129.0f, -161.0f, 0.0f);
            }
            parte1.GetComponent<Animator>().SetBool("active", true);
            parte2.GetComponent<Animator>().SetBool("active", true);
            parte3.GetComponent<Animator>().SetBool("active", true);
        }
        private void clicImagenes() {
            sm.playSound("Sound_OpenPopUp10", 1);
            imagenes.GetComponent<Animator>().SetBool("active", false);
            if (contenedorImagenesThumb.activeSelf)
            {
                contenedorImagenesThumb.SetActive(false);
            }
            else
            {
                contenedorTextosThumb.SetActive(false);
                contenedorImagenesThumb.SetActive(true);
            }
        }
        private void clicTextos()
        {
            textos.GetComponent<Animator>().SetBool("active", false);
            if (contenedorTextosThumb.activeSelf)
            {
                contenedorTextosThumb.SetActive(false);
            }
            else
            {
                contenedorTextosThumb.SetActive(true);
                contenedorImagenesThumb.SetActive(false);
            }
        }
        private void Update()
        {
            if (reto3.activeSelf && inicializado == false)
                InicializarEscenario1();
            if (escenario1.activeSelf)
            {
                if (Input.touchCount > 0)
                {
                    var pos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                    var hit = Physics2D.Raycast(pos, Vector2.zero);
                    if ((dragging == false) && (hit.collider != null) && (Input.GetTouch(0).phase == TouchPhase.Began))
                    {

                        if (
                            (hit.collider.gameObject.name == "Imagen1Thumb") ||
                            (hit.collider.gameObject.name == "Imagen2Thumb") ||
                            (hit.collider.gameObject.name == "Imagen3Thumb") ||
                            (hit.collider.gameObject.name == "Imagen4Thumb") ||
                            (hit.collider.gameObject.name == "Imagen5Thumb") ||
                            (hit.collider.gameObject.name == "Imagen6Thumb") ||
                            (hit.collider.gameObject.name == "Texto1Thumb") ||
                            (hit.collider.gameObject.name == "Texto2Thumb") ||
                            (hit.collider.gameObject.name == "Texto3Thumb") ||
                            (hit.collider.gameObject.name == "Texto4Thumb") ||
                            (hit.collider.gameObject.name == "Texto5Thumb") ||
                            (hit.collider.gameObject.name == "Texto6Thumb")
                        )
                        {
                            //code for touch
                            draggingItem = hit.collider.gameObject;
                            posIni = hit.collider.gameObject.transform.localPosition;
                            dragging = true;
                        }
                        if (hit.collider.gameObject.name == "Textos" && textos.gameObject.activeSelf)
                            clicTextos();
                        if (hit.collider.gameObject.name == "Imagenes" && imagenes.gameObject.activeSelf)
                            clicImagenes();
                    }
                    //************
                    if (Input.GetTouch(0).phase == TouchPhase.Moved)
                        if (dragging)
                            draggingItem.transform.position = new Vector3(pos.x, pos.y,
                                draggingItem.transform.position.z);
                    if (Input.GetTouch(0).phase == TouchPhase.Ended)
                        if (dragging)
                        {
                            if (Vector3.Distance(draggingItem.transform.localPosition, posIni) < 6)
                            {
                                if (draggingItem.gameObject.name == "Texto1Thumb") ZoomTextos(1);
                                if (draggingItem.gameObject.name == "Texto2Thumb") ZoomTextos(2);
                                if (draggingItem.gameObject.name == "Texto3Thumb") ZoomTextos(3);
                                if (draggingItem.gameObject.name == "Texto4Thumb") ZoomTextos(4);
                                if (draggingItem.gameObject.name == "Texto5Thumb") ZoomTextos(5);
                                if (draggingItem.gameObject.name == "Texto6Thumb") ZoomTextos(6);
                                if (draggingItem.gameObject.name == "Imagen1Thumb") ZoomImagenes(1);
                                if (draggingItem.gameObject.name == "Imagen2Thumb") ZoomImagenes(2);
                                if (draggingItem.gameObject.name == "Imagen3Thumb") ZoomImagenes(3);
                                if (draggingItem.gameObject.name == "Imagen4Thumb") ZoomImagenes(4);
                                if (draggingItem.gameObject.name == "Imagen5Thumb") ZoomImagenes(5);
                            }
                            else if (draggingItem.gameObject.name == "Imagen1Thumb")
                            {
                                OcultarMenu();
                                if (Vector3.Distance(draggingItem.transform.position, imagen1Pos.transform.position) <
                                    2.5)
                                {
                                    sm.playSound("Sound_correcto10", 1);
                                    textPopUpEscenario1.text =
                                        "Excelente, esta imagen es la más representativa y explica de manera contundente el tema del bullying.";
                                    popUpEscenario1.SetActive(true);
                                    draggingItem.SetActive(false);
                                    imagen1Pos.SetActive(true);
                                }
                                else
                                {
                                    sm.playSound("Sound_incorrecto19", 1);
                                    
                                    textPopUpEscenario1.text =
                                        "No olvides que esta imagen representa de manera muy clara el concepto que se está trabajando en el tríptico, por ello funcionará mucho mejor al incio de tu tríptico.";
                                    popUpEscenario1.SetActive(true);
                                    draggingItem.transform.localPosition = posIni;
                                }
                            }
                            else if (draggingItem.gameObject.name == "Imagen2Thumb")
                            {
                                OcultarMenu();
                                if (Vector3.Distance(draggingItem.transform.position, imagen2Pos.transform.position) <
                                    2.5)
                                {
                                    sm.playSound("Sound_correcto10", 1);
                                    
                                    textPopUpEscenario1.text =
                                        "Bien hecho, esta imagen se asocia con el texto sobre las 10 formas de prevenir el bullying, representa el apoyo que debe sentir quien está pasando por un caso de acoso.";
                                    popUpEscenario1.SetActive(true);
                                    draggingItem.SetActive(false);
                                    imagen2Pos.SetActive(true);
                                }
                                else
                                {
                                    sm.playSound("Sound_incorrecto19", 1);
                                    
                                    textPopUpEscenario1.text =
                                        "Sé cuidadoso al colocar las imágenes, ésta podría funcionar acompañando el contenido de tu tríptico.";
                                    popUpEscenario1.SetActive(true);
                                    draggingItem.transform.localPosition = posIni;
                                }
                            }
                            else if (draggingItem.gameObject.name == "Imagen3Thumb")
                            {
                                OcultarMenu();
                                if (Vector3.Distance(draggingItem.transform.position, imagen3Pos.transform.position) <
                                    2.5)
                                {
                                    sm.playSound("Sound_correcto10", 1);
                                    
                                    textPopUpEscenario1.text =
                                        "Perfecto, el logotipo aparecerá en la portada dando una idea al lector sobre quién es la empresa o Institución que está patrocinando esta información.";
                                    popUpEscenario1.SetActive(true);
                                    draggingItem.SetActive(false);
                                    imagen3Pos.SetActive(true);
                                }
                                else
                                {
                                    sm.playSound("Sound_incorrecto19", 1);
                                    
                                    textPopUpEscenario1.text =
                                        "Sé cuidadoso, el logotipo tiene su lugar al inicio del tríptico, de esa manera presentarás un antecedente de quién respalda esa información.";
                                    popUpEscenario1.SetActive(true);
                                    draggingItem.transform.localPosition = posIni;
                                }
                            }
                            else if (draggingItem.gameObject.name == "Imagen4Thumb")
                            {
                                OcultarMenu();
                                if (Vector3.Distance(draggingItem.transform.position, imagen4Pos.transform.position) <
                                    2.5)
                                {
                                    sm.playSound("Sound_correcto10", 1);
                                    
                                    textPopUpEscenario1.text =
                                        "¡Correcto¡ esta imagen no dice mucho y aunque  no complementa el texto acompaña los datos de contacto de una manera interesante con la ilustración del celular.";
                                    popUpEscenario1.SetActive(true);
                                    draggingItem.SetActive(false);
                                    imagen4Pos.SetActive(true);
                                }
                                else
                                {
                                    sm.playSound("Sound_incorrecto19", 1);
                                    
                                    textPopUpEscenario1.text =
                                        "Revisa de nuevo tu imagen, ¿a cuál  texto acompañaría mejor?";
                                    popUpEscenario1.SetActive(true);
                                    draggingItem.transform.localPosition = posIni;
                                }
                            }
                            else if (draggingItem.gameObject.name == "Imagen5Thumb")
                            {
                                OcultarMenu();
                                sm.playSound("Sound_incorrecto19", 1);                                
                                textPopUpEscenario1.text =
                                    "Sé prudente con la colocación de las imágenes y revisa si la ilustración contiene información relevante para integrar dentro de un tríptico de bullying.";
                                popUpEscenario1.SetActive(true);
                                draggingItem.transform.localPosition = posIni;
                            }
                            else if (draggingItem.gameObject.name == "Texto1Thumb")
                            {
                                OcultarMenu();
                                if (Vector3.Distance(draggingItem.transform.position, texto1Pos.transform.position) <
                                    2.5)
                                {
                                    sm.playSound("Sound_correcto10", 1);
                                    
                                    textPopUpEscenario1.text =
                                        "Muy bien el diseño del tríptico parece estar en manos de un gran diseñador.";
                                    popUpEscenario1.SetActive(true);
                                    draggingItem.SetActive(false);
                                    texto1Pos.SetActive(true);
                                }
                                else
                                {
                                    sm.playSound("Sound_incorrecto19", 1);
                                    
                                    textPopUpEscenario1.text =
                                        "Revisa con cuidado el texto, ¿no te parece que contiene información de suma importancia para el lector?";
                                    popUpEscenario1.SetActive(true);
                                    draggingItem.transform.localPosition = posIni;
                                }
                            }
                            else if (draggingItem.gameObject.name == "Texto2Thumb")
                            {
                                OcultarMenu();
                                if (Vector3.Distance(draggingItem.transform.position, texto2Pos.transform.position) < 2.5)
                                {
                                    sm.playSound("Sound_correcto10", 1);
                                    
                                    textPopUpEscenario1.text =
                                        "Muy bien, esta información es de contacto por lo tanto está bien ubicarla en la contraportada.";
                                    popUpEscenario1.SetActive(true);
                                    draggingItem.SetActive(false);
                                    texto2Pos.SetActive(true);
                                }
                                else
                                {
                                    sm.playSound("Sound_incorrecto19", 1);
                                    
                                    textPopUpEscenario1.text =
                                        "Recuerda que las redes sociales y teléfonos son datos de contacto que regularmente se ubican al final del tríptico.";
                                    popUpEscenario1.SetActive(true);
                                    draggingItem.transform.localPosition = posIni;
                                }
                            }
                            else if (draggingItem.gameObject.name == "Texto3Thumb")
                            {
                                OcultarMenu();
                                if (Vector3.Distance(draggingItem.transform.position, texto3Pos.transform.position) <
                                    2.5)
                                {
                                    sm.playSound("Sound_correcto10", 1);
                                    
                                    textPopUpEscenario1.text =
                                        "¡Excelente! El tamaño de letra y el diseño que tienen estos titulares son ideales para la portada de tu tríptico.";
                                    popUpEscenario1.SetActive(true);
                                    draggingItem.SetActive(false);
                                    texto3Pos.SetActive(true);
                                }
                                else
                                {
                                    sm.playSound("Sound_incorrecto19", 1);
                                    
                                    textPopUpEscenario1.text =
                                        "Revisa bien el texto y su diseño, considera que si es muy atractivo funcionará mejor al inicio de tu tríptico.";
                                    popUpEscenario1.SetActive(true);
                                    draggingItem.transform.localPosition = posIni;
                                }
                            }
                            else if (draggingItem.gameObject.name == "Texto4Thumb")
                            {
                                OcultarMenu();
                                if (Vector3.Distance(draggingItem.transform.position, texto4Pos.transform.position) <
                                    2.5)
                                {
                                    sm.playSound("Sound_correcto10", 1);
                                    
                                    textPopUpEscenario1.text =
                                        "¡Excelente! El tamaño de letra y el diseño que tienen estos titulares son ideales para la portada de tu tríptico.";
                                    popUpEscenario1.SetActive(true);
                                    draggingItem.SetActive(false);
                                    texto4Pos.SetActive(true);
                                }
                                else
                                {
                                    sm.playSound("Sound_incorrecto19", 1);
                                    
                                    textPopUpEscenario1.text =
                                        "Revisa bien el texto y su diseño, considera que si es muy atractivo funcionará mejor al inicio de tu tríptico.";
                                    popUpEscenario1.SetActive(true);
                                    draggingItem.transform.localPosition = posIni;
                                }
                            }
                            else if (draggingItem.gameObject.name == "Texto5Thumb")
                            {
                                OcultarMenu();
                                sm.playSound("Sound_incorrecto19", 1);
                                
                                textPopUpEscenario1.text =
                                    "Lee cuidadosamente el texto y revisa si su contenido corresponde con el tema del tríptico.";
                                popUpEscenario1.SetActive(true);
                                draggingItem.transform.localPosition = posIni;
                            }
                            else if (draggingItem.gameObject.name == "Texto6Thumb")
                            {
                                sm.playSound("Sound_incorrecto19", 1);
                                
                                textPopUpEscenario1.text =
                                    "Revisa con calma la información y considera si es relevante para integrar este texto en el diseño de tu cartel sobre el bullying.";
                                popUpEscenario1.SetActive(true);
                                draggingItem.transform.localPosition = posIni;
                            }
                            else
                            {
                                draggingItem.transform.localPosition = posIni;
                            }
                            CheckFinishEscenario1();
                            dragging = false;
                        }
                    //*************************
                }
            }
            else if (escenario2.activeSelf)
            {
                if (Input.touchCount > 0)
                {
                    var pos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                    var hit = Physics2D.Raycast(pos, Vector2.zero);
                    if ((dragging == false) && (hit.collider != null) && (Input.GetTouch(0).phase == TouchPhase.Began))
                    {
                        try
                        {
                            if (
                                (hit.collider.gameObject.name == "Parte1") || (hit.collider.gameObject.name == "Parte2") ||
                                (hit.collider.gameObject.name == "Parte3")
                            )
                            {
                                draggingItem = hit.collider.gameObject;
                                draggingItem.GetComponent<Animator>().SetBool("active", false);
                                posIni = hit.collider.gameObject.transform.localPosition;
                                dragging = true;
                            }
                            else if (
                                (hit.collider.gameObject.name == "alarmaPegatina") ||
                                (hit.collider.gameObject.name == "corazonPegatina") ||
                                (hit.collider.gameObject.name == "estrellaPegatina")
                            )
                            {
                                draggingItem = hit.collider.gameObject;
                                posIni = hit.collider.gameObject.transform.localPosition;
                                dragging = true;
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.Log(ex.Message);
                        }
                    }
                    if (Input.GetTouch(0).phase == TouchPhase.Moved)
                        if (dragging)
                            draggingItem.transform.position = new Vector3(pos.x, pos.y,
                                draggingItem.transform.position.z);
                    if (Input.GetTouch(0).phase == TouchPhase.Ended)
                        if (dragging)
                        {
                            if (Vector3.Distance(draggingItem.transform.localPosition, posIni) < 6)
                            {
                                if (draggingItem.gameObject.name == "Parte1") ZoomPartes(1);
                                if (draggingItem.gameObject.name == "Parte2") ZoomPartes(2);
                                if (draggingItem.gameObject.name == "Parte3") ZoomPartes(3);
                            }
                            else if (draggingItem.gameObject.name == "Parte1")
                            {
                                OcultarMenu();
                                if (
                                    Vector3.Distance(draggingItem.transform.localPosition,
                                        tripticoParte1.transform.localPosition) < 120)
                                {
                                    sm.playSound("Sound_correcto10", 1);
                                    
                                    textPopUpEscenario2.text =
                                        "¡Muy bien! Esta imagen contiene una descripción del concepto de bullying y es el lugar adecuado para introducir al lector en el tema.";
                                    draggingItem.gameObject.SetActive(false);
                                    tripticoParte1.gameObject.SetActive(true);
                                }
                                else
                                {
                                    sm.playSound("Sound_incorrecto19", 1);
                                    
                                    textPopUpEscenario2.text =
                                        "Revisa detenidamente el texto, ¿qué tipo de información se localiza en esta porción? Recuerda que las definiciones de los conceptos se ubican preferentemente al inicio del desarrollo.";
                                    draggingItem.transform.localPosition = posIni;
                                }
                                popUpEscenario2.SetActive(true);
                            }
                            else if (draggingItem.gameObject.name == "Parte2")
                            {
                                OcultarMenu();
                                if (
                                    Vector3.Distance(draggingItem.transform.localPosition,
                                        tripticoParte2.transform.localPosition) < 120)
                                {
                                    textPopUpEscenario2.text =
                                        "Correcto, las características del bullying son una excelente manera de continuar introduciendo a los lectores en el tema.";
                                    sm.playSound("Sound_correcto10", 1);
                                    
                                    draggingItem.gameObject.SetActive(false);
                                    tripticoParte2.gameObject.SetActive(true);
                                }
                                else
                                {
                                    sm.playSound("Sound_incorrecto19", 1);
                                    
                                    textPopUpEscenario2.text =
                                        "Lee detenidamente la información sobre las características del tema a tratar, ¿no sería mejor ubicarla después de la introducción al concepto?";
                                    draggingItem.transform.localPosition = posIni;
                                }
                                popUpEscenario2.SetActive(true);
                            }
                            else if (draggingItem.gameObject.name == "Parte3")
                            {
                                OcultarMenu();
                                if (
                                    Vector3.Distance(draggingItem.transform.localPosition,
                                        tripticoParte3.transform.localPosition) < 120)
                                {
                                   textPopUpEscenario2.text = "Este contenido cierra muy bien el contenido, da un panorama general al lector sobre la problemática del bullying.";
                                    sm.playSound("Sound_correcto10", 1);
                                    
                                    draggingItem.gameObject.SetActive(false);
                                    tripticoParte3.gameObject.SetActive(true);
                                }
                                else
                                {
                                    sm.playSound("Sound_incorrecto19", 1);
                                    
                                    textPopUpEscenario2.text =
                                        "Revisa con cuidado el contenido de esta porción, esta información es mucho más adecuada como cierre de ideas.";
                                    draggingItem.transform.localPosition = posIni;
                                }
                                popUpEscenario2.SetActive(true);
                            }
                            else if (draggingItem.gameObject.name == "alarmaPegatina")
                            {
                            }
                            else if (draggingItem.gameObject.name == "corazonPegatina")
                            {
                            }
                            else if (draggingItem.gameObject.name == "estrellaPegatina")
                            {
                            }
                            else
                            {
                                draggingItem.transform.localPosition = posIni;
                            }

                            dragging = false;
                        }
                }
            }
        }
        public void clonar() {
            clon = Instantiate(gameObject);
            clon.SetActive(false);
            clon.transform.GetChild(1).gameObject.SetActive(true);
            clon.transform.GetChild(3).gameObject.SetActive(false);
			clon.transform.GetChild(6).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<Button>().interactable=true;
            sm.playSound("Sound_OpenPopUp10", 1);
        }
		private void MostrarMenu() {
			DropDownMenuCamvas.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<Button>().interactable=true;
		}
		private void OcultarMenu() {
			DropDownMenuCamvas.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<Button>().interactable=false;
		}
        private void CheckFinishTriptico()
        {
            var finalizar = true;
            if (tripticoParte1.gameObject.activeSelf == false) finalizar = false;
            if (tripticoParte2.gameObject.activeSelf == false) finalizar = false;
            if (tripticoParte3.gameObject.activeSelf == false) finalizar = false;
            if (finalizar)
            {
                textPopUpEscenario2.text = "Ahora puedes completar tu tríptico con las pegatinas que te ganaste al inicar este reto.";
                if (pegatinasGanadas.Count > 0)
                {
                    OcultarMenu();
                    popUpEscenario2.SetActive(true);
                    MostrarPegatinas();
                }
                btnGuardar.gameObject.SetActive(true);
            }
        }

        private void MostrarPegatinas()
        {
            contenedorPegatinasGanadas.SetActive(true);
            foreach (var pegatina in pegatinasGanadas)
            {
                pegatina.gameObject.SetActive(true);
            }
            btnGuardar.gameObject.SetActive(true);
            pegatinasGanadas.Clear();
        }

        private void CheckFinishEscenario1()
        {
            var finalizar = true;
            if (imagen1Pos.activeSelf == false) finalizar = false;
            if (imagen2Pos.activeSelf == false) finalizar = false;
            if (imagen3Pos.activeSelf == false) finalizar = false;
            if (imagen4Pos.activeSelf == false) finalizar = false;
            if (texto1Pos.activeSelf == false) finalizar = false;
            if (texto2Pos.activeSelf == false) finalizar = false;
            if (texto3Pos.activeSelf == false) finalizar = false;
            if (texto4Pos.activeSelf == false) finalizar = false;
            if (finalizar)
            {
                contenedorTextosThumb.SetActive(false);
                contenedorImagenesThumb.SetActive(false);
                btnSiguiente.gameObject.SetActive(true);
                btnSiguiente.GetComponent<Animator>().SetBool("active", true);
            }
        }

        private void InicializarEscenario1()
        {
            Invoke("clonar",1);
            inicializado = true;
            ReiniciarPreguntas();
            OcultarMenu();
            countAdivinanzas = 0;
            countPegatinas = 0;
            fondo2.gameObject.SetActive(false);
            textos.gameObject.SetActive(false);
            imagenes.gameObject.SetActive(false);
            triptico.SetActive(true);
            portada.gameObject.SetActive(false);
            contraportada.gameObject.SetActive(false);
            contenido.gameObject.SetActive(false);
            portada.GetComponent<Animator>().SetBool("active", false);
            imagen1Pos.gameObject.SetActive(false);
            imagen2Pos.gameObject.SetActive(false);
            imagen3Pos.gameObject.SetActive(false);
            imagen4Pos.gameObject.SetActive(false);
            texto1Pos.gameObject.SetActive(false);
            texto2Pos.gameObject.SetActive(false);
            texto3Pos.gameObject.SetActive(false);
            texto4Pos.gameObject.SetActive(false);
            btnInicio.gameObject.SetActive(true);
            btnSiguiente.gameObject.SetActive(false);
            contenedorTextosThumb.gameObject.SetActive(false);
            texto1Thumb.gameObject.SetActive(true);
            texto2Thumb.gameObject.SetActive(true);
            texto3Thumb.gameObject.SetActive(true);
            texto4Thumb.gameObject.SetActive(true);
            texto5Thumb.gameObject.SetActive(true);
            texto6Thumb.gameObject.SetActive(true);
            contenedorImagenesThumb.SetActive(false);
            imagen1Thumb.gameObject.SetActive(true);
            imagen2Thumb.gameObject.SetActive(true);
            imagen3Thumb.gameObject.SetActive(true);
            imagen4Thumb.gameObject.SetActive(true);
            imagen5Thumb.gameObject.SetActive(true);
            contenedorTextos.SetActive(false);
            closeTexto.gameObject.SetActive(true);
            botonCloseTexto.gameObject.SetActive(true);
            texto1.gameObject.SetActive(false);
            texto2.gameObject.SetActive(false);
            texto3.gameObject.SetActive(false);
            texto4.gameObject.SetActive(false);
            texto5.gameObject.SetActive(false);
            texto6.gameObject.SetActive(false);
            contenedorImagenes.SetActive(false);
            closeImage.gameObject.SetActive(true);
            botonCloseImage.gameObject.SetActive(true);
            imagen1.gameObject.SetActive(false);
            imagen2.gameObject.SetActive(false);
            imagen3.gameObject.SetActive(false);
            imagen4.gameObject.SetActive(false);
            imagen5.gameObject.SetActive(false);
            contenedorPegatinas.SetActive(true);
            alarma.gameObject.SetActive(false);
            estrella.gameObject.SetActive(false);
            corazon.gameObject.SetActive(false);
            instructionsEscenario1.SetActive(false);
            popUpEscenario1.SetActive(true);
            textPopUpEscenario1.text = "Veamos si puedes reconocer las características del bullyng. Al acertar podrás ganarte pegatinas para tu tríptico.";
            successEscenario1.SetActive(false);
            errorAdivinanzaEscenario1.SetActive(false);
            finishEscenario1.SetActive(false);
        }

        private void IniciarEscenario2()
        {
            InicializarEscenario2();
            escenario1.SetActive(false);
            escenario2.SetActive(true);

            zonaTriptico.gameObject.SetActive(true);
            zonaTriptico.GetComponent<Animator>().SetBool("active", true);
        }

        private void InicializarEscenario2()
        {
            fondo2Escenario2.SetActive(false);
            zonaTriptico.gameObject.SetActive(true);
            zonaTriptico.GetComponent<Animator>().SetBool("active", true);
            btnGuardar.gameObject.SetActive(false);
            contenedorPegatinasGanadas.SetActive(false);
            alarmaPegatina.gameObject.SetActive(false);
            corazonPegatina.gameObject.SetActive(false);
            estrellaPegatina.gameObject.SetActive(false);
            partesTriptico.SetActive(false);
            parte1.gameObject.SetActive(true);
            parte2.gameObject.SetActive(true);
            parte3.gameObject.SetActive(true);
            tripticoEscenario2.SetActive(false);
            tripticoParte1.gameObject.SetActive(false);
            tripticoParte2.gameObject.SetActive(false);
            tripticoParte3.gameObject.SetActive(false);
        }

        private void ZoomImagenes(int imagen)
        {
            OcultarMenu();
            contenedorTextos.SetActive(false);
            contenedorImagenes.SetActive(true);
            if (imagen == 1) imagen1.gameObject.SetActive(true);
            if (imagen == 2) imagen2.gameObject.SetActive(true);
            if (imagen == 3) imagen3.gameObject.SetActive(true);
            if (imagen == 4) imagen4.gameObject.SetActive(true);
            if (imagen == 5) imagen5.gameObject.SetActive(true);
        }

        private void CloseZoomImagenes()
        {
            contenedorTextos.SetActive(false);
            contenedorImagenes.SetActive(false);
            imagen1.gameObject.SetActive(false);
            imagen2.gameObject.SetActive(false);
            imagen3.gameObject.SetActive(false);
            imagen4.gameObject.SetActive(false);
            imagen5.gameObject.SetActive(false);
            MostrarMenu();
        }

        private void ZoomTextos(int texto)
        {
            OcultarMenu();
            contenedorTextos.SetActive(true);
            contenedorImagenes.SetActive(false);
            if (texto == 1) texto1.gameObject.SetActive(true);
            if (texto == 2) texto2.gameObject.SetActive(true);
            if (texto == 3) texto3.gameObject.SetActive(true);
            if (texto == 4) texto4.gameObject.SetActive(true);
            if (texto == 5) texto5.gameObject.SetActive(true);
            if (texto == 6) texto6.gameObject.SetActive(true);
        }
        private void CloseZoomTextos()
        {
            MostrarMenu();
            contenedorTextos.SetActive(false);
            contenedorImagenes.SetActive(false);
            texto1.gameObject.SetActive(false);
            texto2.gameObject.SetActive(false);
            texto3.gameObject.SetActive(false);
            texto4.gameObject.SetActive(false);
            texto5.gameObject.SetActive(false);
            texto6.gameObject.SetActive(false);
        }
        private void ZoomPartes(int parte) {
            OcultarMenu();
            contenedorPartes.SetActive(true);
            if (parte == 1) zoomParte1.gameObject.SetActive(true);
            if (parte == 2) zoomParte2.gameObject.SetActive(true);
            if (parte == 3) zoomParte3.gameObject.SetActive(true);
        }
        private void CloseZoomPartes()
        {
            MostrarMenu();
            contenedorPartes.SetActive(false);
            zoomParte1.gameObject.SetActive(false);
            zoomParte1.gameObject.SetActive(false);
            zoomParte1.gameObject.SetActive(false);
        }

        private void EnabledIntermitente()
        {
            textos.GetComponent<Animator>().SetBool("active", true);
            imagenes.GetComponent<Animator>().SetBool("active", true);
        }

        private void DisableIntermitente()
        {
            textos.GetComponent<Animator>().SetBool("active", false);
            imagenes.GetComponent<Animator>().SetBool("active", false);
        }

        private void AddAdivinanza()
        {
            countAdivinanzas = countAdivinanzas + 1;
            fondoBrillo.GetComponent<Animator>().SetBool("active", false);
            fondoBrillo.gameObject.GetComponent<Image>().enabled = false;
            alarma.gameObject.SetActive(false);
            corazon.gameObject.SetActive(false);
            estrella.gameObject.SetActive(false);
            if (countAdivinanzas == 3)
            {
                textPopUpEscenario1.text = "Conocer los componentes principales de bullying te ayudará a identificarlo claramente.";
                successEscenario1.SetActive(false);
                errorAdivinanzaEscenario1.SetActive(false);
                adivinanzaEscenario1.SetActive(false);
                popUpEscenario1.SetActive(true);
                contenedorPegatinas.SetActive(false);
                OcultarMenu();
            }
            else
            {
                randomIndexPregunta = Random.Range(0, preguntasEscenario1.Count);
                var pregunta = preguntasEscenario1[randomIndexPregunta];
                textAdivinanzaEscenario1.text = pregunta[0];
                textAdivinanzaRespuesta1Escenario1.text = pregunta[1];
                textAdivinanzaRespuesta2Escenario1.text = pregunta[2];
                adivinanzaEscenario1.SetActive(true);
                OcultarMenu();
            }
        }

        private void RevisarAdivinanza(Button option)
        {
            var pregunta = preguntasEscenario1[randomIndexPregunta];
            preguntasEscenario1.RemoveAt(randomIndexPregunta);
            var respuesta = option.transform.GetChild(0).GetComponent<Text>();
            if (respuesta.text == pregunta[3])
            {
                var index = Random.Range(0, listaPegatinas.Count);
                var pegatina = listaPegatinas[index];
                var pegatinaFin = listaPegatinasFin[index];
                fondoBrillo.GetComponent<Animator>().SetBool("active", true);
                fondoBrillo.gameObject.GetComponent<Image>().enabled = true;
                pegatina.SetActive(true);
                pegatinasGanadas.Add(pegatinaFin);
                listaPegatinas.Remove(pegatina);
                countPegatinas = countPegatinas + 1;
                sm.playSound("Sound_correcto10", 1); 
                Invoke("AddAdivinanza", 2f);
            }
            else
            {
                sm.playSound("Sound_incorrecto19", 1); 
                Invoke("AddAdivinanza", 0.5f);
            }
        }

        private void ReiniciarPreguntas()
        {
            preguntasEscenario1 = new List<string[]>();
            preguntasEscenario1.Add(new[]
            {
                "El bullying consiste en la práctica de actos violentos o intimidatorios constantes sobre una persona. Puede ser realizado por una o varias personas, con el propósito de:",
                "Hacer sentir insegura a la víctima",
                "Pelearse con un/a amigo/a",
                "Hacer sentir insegura a la víctima"
            });
            preguntasEscenario1.Add(new[]
            {
                "El bullying consiste en la práctica de actos violentos o intimidatorios constantes sobre una persona con el propósito de:",
                "Jugar",
                "Entorpecer su desenvolvimiento",
                "Entorpecer su desenvolvimiento"
            });

            preguntasEscenario1.Add(new[]
            {
                "La propagación de rumores y el uso de apodos que se basan en el aspecto físico, de religión, raza o clase social pueden considerarse comportamientos:",
                "Divertidos",
                "Agresivos",
                "Agresivos"
            });

            preguntasEscenario1.Add(new[]
            {
                "Alejar a alguien de un grupo con la intención de hacerle sentir mal sólo por tener gustos o preferencias diferentes a las tuyas es considerado:",
                "Bullying de tipo social",
                "Ciberbullying",
                "Bullying de tipo social"
            });
        }

 private const string MediaStoreImagesMediaClass = "android.provider.MediaStore$Images$Media";

    public static string SaveImageToGallery(Texture2D texture2D, string title, string description)
    {
        using (var mediaClass = new AndroidJavaClass(MediaStoreImagesMediaClass))
        {
            using (var cr = Activity.Call<AndroidJavaObject>("getContentResolver"))
            {
                var image = Texture2DToAndroidBitmap(texture2D);
                var imageUrl = mediaClass.CallStatic<string>("insertImage", cr, image, title, description);
                return imageUrl;
            }
        }
    }

  public static AndroidJavaObject Texture2DToAndroidBitmap(Texture2D texture2D)
    {
        byte[] encoded = texture2D.EncodeToPNG();
        using (var bf = new AndroidJavaClass("android.graphics.BitmapFactory"))
        {
            return bf.CallStatic<AndroidJavaObject>("decodeByteArray", encoded, 0, encoded.Length);
        }
    }

  public static AndroidJavaObject Activity
    {
        get
        {
            if (_activity == null)
            {
                var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
                _activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            }
            return _activity;
        }
    }


    IEnumerator ScreenshotEncode() {

        yield return new WaitForEndOfFrame ();
        texture1 = new Texture2D (Screen.width, Screen.height, TextureFormat.RGB24, false);
        texture1.ReadPixels (new Rect (0, 0, Screen.width, Screen.height), 0, 0);
        texture1.Apply ();
        SaveImageToGallery (texture1, "CapturaOda1", "");
    }
    }
}
