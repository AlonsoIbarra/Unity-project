using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using System.Collections.Generic;

namespace Assets.Resources.Scripts
{
    public class Reto2Oda5 : MonoBehaviour
    {
        private GameObject DropDownMenuCamvas;
        private Button inicioButton;
        private List<ObjetoBullyng> listaObjetosJuego = new List<ObjetoBullyng>();
        private List<String[]> listaAdivinanzas = new List<string[]>();
        private GameObject adivinanzaEscenario1;
        private Text balonDeFutbol;
        private GameObject baulBullyng;
        private GameObject baulNoBullyng;
        private Text bolaDePapel;
        private Text bolsa;
        private Button btnAdivinanzaRespuesta1Escenario1;
        private Button btnAdivinanzaRespuesta2Escenario1;
        private Button btnBalonDeFutbol;
        private Button btnBolaDePapel;
        private Button btnBolsa;
        private Button btnCelular;
        private Button btnContinuarAdivinanzaEscenario1;
        private Button btnCrayola;
        private Button btnCredencialEscolar;
        private Button btnCuaderno;
        private Button btnCurita;
        private Button btnDulces;
        private Button btnErrorCloseEscenario2;
        private Button btnEtiquetaDeCuaderno;
        private Button btnExamen;
        private Button btnFinishCloseEscenario1;
        private Button btnFinishCloseEscenario2;
        private Button btnInsecto;
        private Button btnInstructionsCloseEscenario1;
        private Button btnInstructionsCloseEscenario2;
        private Button btnLaptop;
        //Lista1
        private Button btnLentes;
        private Button btnMochila;
        private Button btnMuñeca;
        private Button btnOsoDePeluche;
        private Button btnPastel;
        private Button btnPopUpCloseEscenario1;
        private Button btnRegresarAdivinanzaEscenario1;
        private Button btnSuccessCloseEscenario1;
        private Button btnSuccessCloseEscenario2;
        private Button btnTimeOutCloseEscenario1;
        private Button btnVenda;
        //Lista2
        private Button btnZapato;
        private Text celular;
        private GameObject clon;
        private GameObject contenedorListas;
        private Text crayola;
        private Text credencialEscolar;
        private MyTimer cronometro;
        private Text cuaderno;
        private Text curita;
        private bool dragging;
        private bool inicializado = false;
        private GameObject draggingItem;
        private Text dulces;
        private GameObject errorAdivinanzaEscenario1;
        private GameObject errorEscenario2;
        private GameObject escenario1;
        private GameObject escenario2;

        //Escenario2
        private GameObject escenario2ContenedorListas;
        private GameObject escenario2Lista1;
        private Text etiquetaDeCuaderno;
        private Text examen;
        private GameObject finishEscenario1;
        private GameObject finishEscenario2;
        private bool flag = true;
        private GameObject helpEscenario1;
        private Button helpEscenario2;
        private Image imgBalonDeFutbol;
        private Image imgBolaDePapel;
        private Image imgBolsa;
        private Image imgCelular;
        private Image imgCrayola;
        private Image imgCredencialEscolar;
        private Image imgCuaderno;
        private Image imgCurita;
        private Image imgDulces;
        private Image imgEtiquetaDeCuaderno;
        private Image imgExamen;
        private Image imgInsecto;
        private Image imgLaptop;
        private Image imgLentes;
        private Image imgMochila;
        private Image imgMuñeca;
        private Image imgOsoDePeluche;
        private Image imgPastel;
        private Image imgVenda;
        private Image imgZapato;
        private int indexlista;
        private Text insecto;
        private GameObject instructionsEscenario1;
        private GameObject instructionsEscenario2;
        private Text laptop;
        private Text lentes;
        private GameObject lista;
        private Text mochila;
        private Text muñeca;
        private Text osoDePeluche;
        private Text pastel;
        private GameObject popUpEscenario1;
        private GameObject popUpEscenario2;
        private Vector3 posIni;
        private int randomInt;
        private int randomListIndex;
        //Escenario1
        private GameObject relojEscenario1;
        private Text marcadorTiempoEscenario1;
        private GameObject reto2;
        private SoundManager sm;
        private GameObject successEscenario1;
        private GameObject successEscenario2;
        private Text textAdivinanzaEscenario1;
        private Text textAdivinanzaRespuesta1Escenario1;
        private Text textAdivinanzaRespuesta2Escenario1;
        private Text textErrorAdivinanzaEscenario1;
        private Text textErrorEscenario2;
        private Text textPopUpEscenario1;
        private Text textPopUpEscenario2;
        private Text textSuccessEscenario1;
        private Text textSuccessEscenario2;
        private Text textTimeOutEscenario1;
        private int timeExt;
        private GameObject timeOutEscenario1;
        private int timeToPlay;
        private Text venda;
        private Text zapato;


        private void Start()
        {
            posIni = new Vector3(-176, 0, 0);
            DropDownMenuCamvas = transform.GetChild(6).gameObject;
            inicioButton = DropDownMenuCamvas.transform.GetChild(0).GetChild(0).GetChild(0).transform.FindChild("inicioButton").GetComponent<Button>();
            inicioButton.onClick.AddListener(delegate {
                if(reto2.activeSelf)
                    FinalizarReto2();
            });
            reto2 = transform.GetChild(3).gameObject;
            reto2.GetComponent<Canvas>().worldCamera = Camera.main;

            escenario1 = reto2.transform.FindChild("Escenario1").gameObject;
            escenario2 = reto2.transform.FindChild("Escenario2").gameObject;

            relojEscenario1 = escenario1.transform.FindChild("relojEscenario1").gameObject;
            marcadorTiempoEscenario1 = relojEscenario1.transform.FindChild("marcadorTiempoEscenario1").GetComponent<Text>();
            cronometro = gameObject.GetComponent<MyTimer>();
            sm = gameObject.GetComponent<SoundManager>();

            popUpEscenario1 = escenario1.transform.FindChild("PopUpEscenario1").gameObject;
            textPopUpEscenario1 = popUpEscenario1.transform.FindChild("TextPopUpEscenario1").GetComponent<Text>();
            btnPopUpCloseEscenario1 =
                popUpEscenario1.transform.FindChild("BtnPopUpCloseEscenario1").GetComponent<Button>();
            btnPopUpCloseEscenario1.onClick.AddListener(delegate
            {
                sm.playSound("Sound_Cerrar3", 1); 
                AddAdivinanza();
            });
            adivinanzaEscenario1 = escenario1.transform.FindChild("AdivinanzaEscenario1").gameObject;
            textAdivinanzaEscenario1 =
                adivinanzaEscenario1.transform.FindChild("TextAdivinanzaEscenario1").GetComponent<Text>();
            btnAdivinanzaRespuesta1Escenario1 =
                adivinanzaEscenario1.transform.FindChild("BtnAdivinanzaRespuesta1Escenario1").GetComponent<Button>();
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
            errorAdivinanzaEscenario1 = escenario1.transform.FindChild("ErrorAdivinanzaEscenario1").gameObject;
            textErrorAdivinanzaEscenario1 =
                errorAdivinanzaEscenario1.transform.FindChild("TextErrorAdivinanzaEscenario1").GetComponent<Text>();
            btnRegresarAdivinanzaEscenario1 =
                errorAdivinanzaEscenario1.transform.FindChild("BtnRegresarAdivinanzaEscenario1").GetComponent<Button>();
            btnRegresarAdivinanzaEscenario1.onClick.AddListener(delegate { AddAdivinanza(); });
            btnContinuarAdivinanzaEscenario1 =
                errorAdivinanzaEscenario1.transform.FindChild("BtnContinuarAdivinanzaEscenario1").GetComponent<Button>();
            btnContinuarAdivinanzaEscenario1.onClick.AddListener(delegate
            {
                timeExt = 0;
                FinalizarAdivinanzas();
            });
            successEscenario1 = escenario1.transform.FindChild("SuccessEscenario1").gameObject;
            textSuccessEscenario1 = successEscenario1.transform.FindChild("TextSuccessEscenario1").GetComponent<Text>();
            btnSuccessCloseEscenario1 =
                successEscenario1.transform.FindChild("BtnSuccessCloseEscenario1").GetComponent<Button>();
            btnSuccessCloseEscenario1.onClick.AddListener(delegate
            {
                sm.playSound("Sound_Cerrar3", 1); 
                adivinanzaEscenario1.SetActive(false);
                successEscenario1.SetActive(false);
                instructionsEscenario1.SetActive(true);
            });
            instructionsEscenario1 = escenario1.transform.FindChild("InstructionsEscenario1").gameObject;
            btnInstructionsCloseEscenario1 =
                instructionsEscenario1.transform.FindChild("BtnInstructionsCloseEscenario1").GetComponent<Button>();
            btnInstructionsCloseEscenario1.onClick.AddListener(delegate
            {
                sm.playSound("Sound_Cerrar3", 1); 
                ComenzarReto1();

            });
            timeOutEscenario1 = escenario1.transform.FindChild("TimeOutEscenario1").gameObject;
            btnTimeOutCloseEscenario1 = timeOutEscenario1.transform.FindChild("BtnTimeOutCloseEscenario1").GetComponent<Button>();
            btnTimeOutCloseEscenario1.onClick.AddListener(delegate
            {
                sm.playSound("Sound_Cerrar3", 1); 
                if (timeExt > 0)
                {
                    timeOutEscenario1.SetActive(false);
                    cronometro.StartTimer(timeExt);
                    flag = true;
                    timeExt = 0;
                    sm.playSound("Sound_reloj1", 2); 
                    sm.encenderReloj();
                    MostrarMenu();
                }
                else
                {
                    ResetEscenario1();
                }
            });
            textTimeOutEscenario1 = timeOutEscenario1.transform.FindChild("TextTimeOutEscenario1").GetComponent<Text>();
            finishEscenario1 = escenario1.transform.FindChild("FinishEscenario1").gameObject;
            btnFinishCloseEscenario1 = finishEscenario1.transform.FindChild("BtnFinishCloseEscenario1").GetComponent<Button>();
            btnFinishCloseEscenario1.onClick.AddListener(delegate
            {
                sm.playSound("Sound_Cerrar3", 1); 
                CerrarEscenario1();
            });
            contenedorListas = escenario1.transform.FindChild("ContenedorListas").gameObject;
            lista = contenedorListas.transform.FindChild("Lista").gameObject;

            escenario2ContenedorListas = escenario2.transform.FindChild("Escenario2ContenedorListas").gameObject;
            escenario2Lista1 = escenario2ContenedorListas.transform.FindChild("Escenario2Lista1").gameObject;
            baulBullyng = escenario2.transform.FindChild("BaulBullyng").gameObject;
            baulNoBullyng = escenario2.transform.FindChild("BaulNoBullyng").gameObject;
            instructionsEscenario2 = escenario2.transform.FindChild("InstructionsEscenario2").gameObject;
            popUpEscenario2 = escenario2.transform.FindChild("popUpEscenario2").gameObject;
            textPopUpEscenario2 = popUpEscenario2.transform.FindChild("TextPopUpEscenario2").GetComponent<Text>();

            btnInstructionsCloseEscenario2 = instructionsEscenario2.transform.FindChild("BtnInstructionsCloseEscenario2").GetComponent<Button>();
            btnInstructionsCloseEscenario2.onClick.AddListener(delegate
            {
                sm.playSound("Sound_Cerrar3", 1); 
                instructionsEscenario2.SetActive(false);
                //inicializar escenario 2
                ComenzarReto1();
            });
            successEscenario2 = escenario2.transform.FindChild("SuccessEscenario2").gameObject;
            textSuccessEscenario2 = successEscenario2.transform.FindChild("TextSuccessEscenario2").GetComponent<Text>();
            btnSuccessCloseEscenario2 =
                successEscenario2.transform.FindChild("BtnSuccessCloseEscenario2").GetComponent<Button>();
            btnSuccessCloseEscenario2.onClick.AddListener(delegate
            {
                indexlista++;
                sm.playSound("Sound_Cerrar3", 1); 
                successEscenario2.SetActive(false);
                MostrarMenu();
                PopElementosEncontrados();
            });
            errorEscenario2 = escenario2.transform.FindChild("ErrorEscenario2").gameObject;
            textErrorEscenario2 = errorEscenario2.transform.FindChild("TextErrorEscenario2").GetComponent<Text>();
            btnErrorCloseEscenario2 =
                errorEscenario2.transform.FindChild("BtnErrorCloseEscenario2").GetComponent<Button>();
            btnErrorCloseEscenario2.onClick.AddListener(delegate
            {
                indexlista++;
                sm.playSound("Sound_Cerrar3", 1); 
                errorEscenario2.SetActive(false);
                MostrarMenu();
                PopElementosEncontrados();
            });
            finishEscenario2 = escenario2.transform.FindChild("FinishEscenario2").gameObject;
            btnFinishCloseEscenario2 =
                finishEscenario2.transform.FindChild("BtnFinishCloseEscenario2").GetComponent<Button>();
            btnFinishCloseEscenario2.onClick.AddListener(delegate
            {
                FinalizarReto2();
            });
            GameObject listaTexto = lista.transform.FindChild("listaTexto").gameObject;
            imgLentes = escenario2Lista1.transform.FindChild("ImgLentes").GetComponent<Image>();
            btnLentes = lista.transform.FindChild("BtnLentes").GetComponent<Button>();
            lentes = listaTexto.transform.FindChild("Lentes").GetComponent<Text>();

            imgCredencialEscolar = escenario2Lista1.transform.FindChild("ImgCredencial_escolar").GetComponent<Image>();
            btnCredencialEscolar = lista.transform.FindChild("BtnCredencial_escolar").GetComponent<Button>();
            credencialEscolar = listaTexto.transform.FindChild("Credencial_escolar").GetComponent<Text>();

            imgInsecto = escenario2Lista1.transform.FindChild("ImgInsecto").GetComponent<Image>();
            btnInsecto = lista.transform.FindChild("BtnInsecto").GetComponent<Button>();
            insecto = listaTexto.transform.FindChild("Insecto").GetComponent<Text>();

            imgMochila = escenario2Lista1.transform.FindChild("ImgMochila").GetComponent<Image>();
            btnMochila = lista.transform.FindChild("BtnMochila").GetComponent<Button>();
            mochila = listaTexto.transform.FindChild("Mochila").GetComponent<Text>();

            imgCurita = escenario2Lista1.transform.FindChild("ImgCurita").GetComponent<Image>();
            btnCurita = lista.transform.FindChild("BtnCurita").GetComponent<Button>();
            curita = listaTexto.transform.FindChild("Curita").GetComponent<Text>();

            imgPastel = escenario2Lista1.transform.FindChild("ImgPastel").GetComponent<Image>();
            btnPastel = lista.transform.FindChild("BtnPastel").GetComponent<Button>();
            pastel = listaTexto.transform.FindChild("Pastel").GetComponent<Text>();

            imgCuaderno = escenario2Lista1.transform.FindChild("ImgCuaderno").GetComponent<Image>();
            btnCuaderno = lista.transform.FindChild("BtnCuaderno").GetComponent<Button>();
            cuaderno = listaTexto.transform.FindChild("Cuaderno").GetComponent<Text>();

            imgMuñeca = escenario2Lista1.transform.FindChild("ImgMuñeca").GetComponent<Image>();
            btnMuñeca = lista.transform.FindChild("BtnMuñeca").GetComponent<Button>();
            muñeca = listaTexto.transform.FindChild("Muñeca").GetComponent<Text>();

            imgBolaDePapel = escenario2Lista1.transform.FindChild("ImgBola_de_papel").GetComponent<Image>();
            btnBolaDePapel = lista.transform.FindChild("BtnBola_de_papel").GetComponent<Button>();
            bolaDePapel = listaTexto.transform.FindChild("Bola_de_papel").GetComponent<Text>();

            imgCelular = escenario2Lista1.transform.FindChild("ImgCelular").GetComponent<Image>();
            btnCelular = lista.transform.FindChild("BtnCelular").GetComponent<Button>();
            celular = listaTexto.transform.FindChild("Celular").GetComponent<Text>();

            imgZapato = escenario2Lista1.transform.FindChild("ImgZapato").GetComponent<Image>();
            btnZapato = lista.transform.FindChild("BtnZapato").GetComponent<Button>();
            zapato = listaTexto.transform.FindChild("Zapato").GetComponent<Text>();

            imgEtiquetaDeCuaderno = escenario2Lista1.transform.FindChild("ImgEtiqueta_de_cuaderno").GetComponent<Image>();
            btnEtiquetaDeCuaderno = lista.transform.FindChild("BtnEtiqueta_de_cuaderno").GetComponent<Button>();
            etiquetaDeCuaderno = listaTexto.transform.FindChild("Etiqueta_de_cuaderno").GetComponent<Text>();

            imgBalonDeFutbol = escenario2Lista1.transform.FindChild("ImgBalon_de_futbol").GetComponent<Image>();
            btnBalonDeFutbol = lista.transform.FindChild("BtnBalon_de_futbol").GetComponent<Button>();
            balonDeFutbol = listaTexto.transform.FindChild("Balon_de_futbol").GetComponent<Text>();

            imgBolsa = escenario2Lista1.transform.FindChild("ImgBolsa").GetComponent<Image>();
            btnBolsa = lista.transform.FindChild("BtnBolsa").GetComponent<Button>();
            bolsa = listaTexto.transform.FindChild("Bolsa").GetComponent<Text>();

            imgVenda = escenario2Lista1.transform.FindChild("ImgVenda").GetComponent<Image>();
            btnVenda = lista.transform.FindChild("BtnVenda").GetComponent<Button>();
            venda = listaTexto.transform.FindChild("Venda").GetComponent<Text>();

            imgDulces = escenario2Lista1.transform.FindChild("ImgDulces").GetComponent<Image>();
            btnDulces = lista.transform.FindChild("BtnDulces").GetComponent<Button>();
            dulces = listaTexto.transform.FindChild("Dulces").GetComponent<Text>();

            imgExamen = escenario2Lista1.transform.FindChild("ImgExamen").GetComponent<Image>();
            btnExamen = lista.transform.FindChild("BtnExamen").GetComponent<Button>();
            examen = listaTexto.transform.FindChild("Examen").GetComponent<Text>();

            imgOsoDePeluche = escenario2Lista1.transform.FindChild("ImgOso_de_peluche").GetComponent<Image>();
            btnOsoDePeluche = lista.transform.FindChild("BtnOso_de_peluche").GetComponent<Button>();
            osoDePeluche = listaTexto.transform.FindChild("Oso_de_peluche").GetComponent<Text>();

            imgCrayola = escenario2Lista1.transform.FindChild("ImgCrayola").GetComponent<Image>();
            btnCrayola = lista.transform.FindChild("BtnCrayola").GetComponent<Button>();
            crayola = listaTexto.transform.FindChild("Crayola").GetComponent<Text>();

            imgLaptop = escenario2Lista1.transform.FindChild("ImgLaptop").GetComponent<Image>();
            btnLaptop = lista.transform.FindChild("BtnLaptop").GetComponent<Button>();
            laptop = listaTexto.transform.FindChild("Laptop").GetComponent<Text>();
            timeExt = 0;
        }
       
        private void Update()
        {
            if (inicializado == false && reto2.activeSelf)
                InicializarEscenario1();
            if (escenario1.activeSelf)
            {
                marcadorTiempoEscenario1.text = Math.Truncate(Double.Parse(cronometro.remainingTime.ToString())).ToString();
                if (cronometro.isEnable() && (cronometro.remainingTime < 0.2))
                    TimeOut();
                if ((Input.touchCount > 0) && FirstPlaneEscenario1())
                {
                    var pos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                    var hit = Physics2D.Raycast(pos, Vector2.zero);
                    if ((dragging == false) && (hit.collider != null) && (Input.GetTouch(0).phase == TouchPhase.Began))
                        if (
                            (hit.collider.gameObject.name == "BtnLentes") ||
                            (hit.collider.gameObject.name == "BtnCredencial_escolar") ||
                            (hit.collider.gameObject.name == "BtnInsecto") ||
                            (hit.collider.gameObject.name == "BtnMochila") ||
                            (hit.collider.gameObject.name == "BtnCurita") ||
                            (hit.collider.gameObject.name == "BtnPastel") ||
                            (hit.collider.gameObject.name == "BtnCuaderno") ||
                            (hit.collider.gameObject.name == "BtnMuñeca") ||
                            (hit.collider.gameObject.name == "BtnBola_de_papel") ||
                            (hit.collider.gameObject.name == "BtnCelular") ||
                            (hit.collider.gameObject.name == "BtnZapato") ||
                            (hit.collider.gameObject.name == "BtnEtiqueta_de_cuaderno") ||
                            (hit.collider.gameObject.name == "BtnBalon_de_futbol") ||
                            (hit.collider.gameObject.name == "BtnBolsa") ||
                            (hit.collider.gameObject.name == "BtnVenda") ||
                            (hit.collider.gameObject.name == "BtnDulces") ||
                            (hit.collider.gameObject.name == "BtnExamen") ||
                            (hit.collider.gameObject.name == "BtnOso_de_peluche") ||
                            (hit.collider.gameObject.name == "BtnCrayola") ||
                            (hit.collider.gameObject.name == "BtnLaptop")
                        )
                            SeleccionarObjetoEscenario1(hit.collider.gameObject);
                }
            }
            else if (escenario2.activeSelf)
            {
                sm.apagarReloj();
				cronometro.StopTimer();
                if (Input.touchCount > 0)
                {
                    var pos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                    var hit = Physics2D.Raycast(pos, Vector2.zero);
                    if ((dragging == false) && (hit.collider != null) && (Input.GetTouch(0).phase == TouchPhase.Began))
                        try
                        {
                            if ((hit.collider.gameObject.name == "ImgLentes") ||
                                (hit.collider.gameObject.name == "ImgCredencial_escolar") ||
                                (hit.collider.gameObject.name == "ImgInsecto") ||
                                (hit.collider.gameObject.name == "ImgCuaderno") ||
                                (hit.collider.gameObject.name == "ImgMochila") ||
                                (hit.collider.gameObject.name == "ImgCurita") ||
                                (hit.collider.gameObject.name == "ImgPastel") ||
                                (hit.collider.gameObject.name == "ImgMuñeca") ||
                                (hit.collider.gameObject.name == "ImgBola_de_papel") ||
                                (hit.collider.gameObject.name == "ImgCelular") ||
                                (hit.collider.gameObject.name == "ImgBolsa") ||
                                (hit.collider.gameObject.name == "ImgZapato") ||
                                (hit.collider.gameObject.name == "ImgEtiqueta_de_cuaderno") ||
                                (hit.collider.gameObject.name == "ImgBalon_de_futbol") ||
                                (hit.collider.gameObject.name == "ImgVenda") ||
                                (hit.collider.gameObject.name == "ImgDulces") ||
                                (hit.collider.gameObject.name == "ImgExamen") ||
                                (hit.collider.gameObject.name == "ImgOso_de_peluche") ||
                                (hit.collider.gameObject.name == "ImgCrayola") ||
                                (hit.collider.gameObject.name == "ImgLaptop"))
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
                    if (Input.GetTouch(0).phase == TouchPhase.Moved)
                        if (dragging)
                            draggingItem.transform.position = new Vector3(pos.x, pos.y,
                                draggingItem.transform.position.z);
                    if (Input.GetTouch(0).phase == TouchPhase.Ended)
                        if (dragging)
                        {
                            var baullBullyingColaider = Physics2D.Raycast(baulBullyng.transform.position, Vector2.zero);
                            var baullNoBullyingColaider = Physics2D.Raycast(baulNoBullyng.transform.position, Vector2.zero);
                            if (baullBullyingColaider.collider.bounds.Contains(draggingItem.transform.position))
                                if (
                                    (draggingItem.gameObject.name == "ImgCredencial_escolar") ||
                                    (draggingItem.gameObject.name == "ImgInsecto") ||
                                    (draggingItem.gameObject.name == "ImgLentes") ||
                                    (draggingItem.gameObject.name == "ImgMochila") ||
                                    (draggingItem.gameObject.name == "ImgCurita") ||
                                    (draggingItem.gameObject.name == "ImgZapato") ||
                                    (draggingItem.gameObject.name == "ImgEtiqueta_de_cuaderno") ||
                                    (draggingItem.gameObject.name == "ImgBalon_de_futbol") ||
                                    (draggingItem.gameObject.name == "ImgVenda")
                                )
                                    DropCorrecto();
                                else DropIncorrecto();
                            else if (baullNoBullyingColaider.collider.bounds.Contains(draggingItem.transform.position))
                                    if (
                                    (draggingItem.gameObject.name == "ImgPastel") ||
                                    (draggingItem.gameObject.name == "ImgCuaderno") ||
                                    (draggingItem.gameObject.name == "ImgMuñeca") ||
                                    (draggingItem.gameObject.name == "ImgBola_de_papel") ||
                                    (draggingItem.gameObject.name == "ImgCelular") ||
                                    (draggingItem.gameObject.name == "ImgExamen") ||
                                    (draggingItem.gameObject.name == "ImgDulces") ||
                                    (draggingItem.gameObject.name == "ImgOso_de_peluche") ||
                                    (draggingItem.gameObject.name == "ImgCrayola") ||
                                    (draggingItem.gameObject.name == "ImgBolsa") ||
                                    (draggingItem.gameObject.name == "ImgLaptop")
                                )
                                    DropCorrecto();
                                else DropIncorrecto();
                            else draggingItem.transform.localPosition = posIni;
                            dragging = false;
                        }
                }
            }
        }
        private List<ObjetoBullyng> llenarAlmacenObjetos() {
            List<ObjetoBullyng> lista = new List<ObjetoBullyng>();
            lista.Add(new ObjetoBullyng(
                btnPastel,
                pastel,
                imgPastel,
                "Julieta no invitó a Sonia a su fiesta de cumpleaños porque van en el mismo salón pero casi no platican y les gustan cosas diferentes.",
                "Correcto. No se pretende herir a nadie, no invitar a alguien porque no nos relacionamos mucho con esa persona no es bullying.",
                "No es bullying, para ser considerado como tal requiere ser algo repetitivo y con la finalidad de hacer daño."
                ));
            lista.Add(new ObjetoBullyng(
                btnCredencialEscolar,
                credencialEscolar,
                imgCredencialEscolar,
                "Los apellidos de Julieta suenan diferente a los de sus compañeros y por eso la molestan. Hasta ahora ha sido verbalmente, sin embargo, este tipo de maltrato puede venir acompañado de una cadena de agresiones.",
                "Correcto. El bullying regularmente se intensifica cuando el agresor percibe que es en apariencia más fuerte que la víctima, cualquier característica que la diferencie del resto puede ser un pretexto para burlas y maltratos verbales.",
                "La agresión que se ha hecho hacia Julieta se considera bullying. Este tipo de maltrato puede acompañarse de una cadena de agresiones y desembocar en algún tipo de agresión física."
            ));
            lista.Add(new ObjetoBullyng(
                btnInsecto,
                insecto,
                imgInsecto,
                "Julieta ama los insectos, sus padres son biólogos y ella está acostumbrada a observarlos y cuidarlos. Sus amigas han decidido que como ella es \"rara\" deben alejarla del grupo.",
                "Correcto. Cuando una persona es etiquetada por sus gustos o preferencias y separada de un grupo hablamos de bullying social: excluir, ignorar y alejar son otras formas de este tipo de bullying.",
                "Cuando una persona es etiquetada por sus gustos o preferencias y separada de un grupo hablamos de bullying social porque se pretende aislar, ignorar y excluir al otro."
            ));
            lista.Add(new ObjetoBullyng(
                btnCuaderno,
                cuaderno,
                imgCuaderno,
                "A Julieta le costó mucho trabajo acabar su tarea. Pedro le ha pedido que se la pase, ella se negó porque sabe que la maestra se dará cuenta y terminará afectando sus notas.",
                "No debemos confundir el bullying con cuidar de nosotros y tomar algunas decisiones que no les gustarán a nuestros compañeros. En este caso no se pretende lastimar a nadie.",
                "No debemos confundir el bullying con cuidar de nosotros y tomar algunas decisiones que no les gustarán a nuestros compañeros. En este caso no se pretende lastimar a nadie."
            ));
            lista.Add(new ObjetoBullyng(
                btnMuñeca,
                muñeca,
                imgMuñeca,
                "Julieta y Carmina han sido amigas desde el kinder, sin embargo, Carmina rompió accidentalmente la muñeca de Julieta y ella está muy molesta.",
                "Correcto. No se considera bullying a una pelea aislada entre amigas, es un evento lejano y sin intención de afectar la autoestima o de dañar a alguien por considerarlo más débil.",
                "Pelearse con una amiga es algo que puede suceder y aunque pueda provocar cierta tristeza, dado que no hay abuso de poder y que es una situación eventual no es bullying."
            ));
            lista.Add(new ObjetoBullyng(
                btnLentes,
                lentes,
                imgLentes,
                "Julieta usa lentes, algunos niños de su salón le dicen 4 ojos.",
                "Correcto. Los apodos son una forma de molestar a las personas con las que convivimos, buscan hacer evidentes sus defectos y lastiman la autoestima de las personas.",
                "Ponerle un apodo a alguien por utilizar algún accesorio u objeto y agredir verbalmente de manera constante a un compañero es considerado bullying."
            ));
            lista.Add(new ObjetoBullyng(
                btnMochila,
                mochila,
                imgMochila,
                "Julieta, escogió una mochila nueva hace dos días, hoy ya no la quiere. Presenta cambios de humor muy bruscos, pone excusas para faltar a clase porque tiene miedo de ir a la escuela.",
                "Correcto, además las personas que son víctimas de bullying suelen no contar nada sobre su día a día en su centro y puede producirse un importante cambio en su rendimiento escolar.",
                "Las personas que son víctimas de bullying pueden tener cambios de humor bruscos, no hablar de la escuela y puede producirse un importante cambio en su rendimiento escolar."
            ));
            lista.Add(new ObjetoBullyng(
                btnCurita,
                curita,
                imgCurita,
                "Julieta fue empujada una vez más por sus compañeros al salir del salón, se raspó la rodilla y tuvieron que ponerle un curita.",
                "Correcto. Los empujones, golpes, palizas, peleas son parte del bullying físico, identificarlo a tiempo puede evitar que con el tiempo aparezcan las armas blancas o incluso las de fuego.",
                "Recuerda que existe el bullying físico que consiste en la agresión directa e indirecta: patadas, empujones, golpes, daños materiales en los objetos personales de la víctima etc."
            ));
            lista.Add(new ObjetoBullyng(
                btnBolaDePapel,
                bolaDePapel,
                imgBolaDePapel,
                "La maestra de Julieta salió un momento del salón y de pronto todos los niños empezaron a aventar cosas, una bola de papel cayó sobre la cabeza de Julieta.",
                "Correcto. Por molesto que este suceso pueda ser, si no fue con intención de lastimar a nadie y si es un hecho aislado, puede considerarse un accidente.",
                "Aunque este tipo de juegos puede resultar peligroso si no se mide el riesgo de lastimar a alguien, los accidentes suelen ocurrir. Si no hay mala intención, son sólo accidentes."
            ));
            lista.Add(new ObjetoBullyng(
                btnCelular,
                celular,
                imgCelular,
                "Julieta se ha estado comunicando con sus amigas por medio de mensajes del celular, sin embargo, tras una discusión, una de ellas le escribió \"mala amiga\".",
                "Correcto. Se trata de una pelea puntual entre dos amigas, no se considera bullying.",
                "Esta situación no es representativa del bullying. Si bien es cierto que debemos cuidar de no herir a nuestros amigos con malas palabras, esto es una pelea puntual y no un acoso contra alguien."
            ));
            lista.Add(new ObjetoBullyng(
                btnZapato,
                zapato,
                imgZapato,
                "Julieta usa zapatos ortopédicos por un problema en sus pies. Sus amigos se burlan de ella constantemente y le han puesto un apodo.",
                "Correcto. El bullying se hace manifiesto en todo tipo de agresiones, los apodos son una forma de agresión verbal que lastima la autoestima de quien es víctima de esta agresión.",
                "Ponerle un apodo a alguien por utilizar algo diferente es una agresión verbal que cuando se realiza de manera repetitiva y constante es considerado bullying."
            ));
            lista.Add(new ObjetoBullyng(
                btnEtiquetaDeCuaderno,
                etiquetaDeCuaderno,
                imgEtiquetaDeCuaderno,
                "El nombre completo de Julieta es diferente al de sus compañeros. Hasta ahora sólo le han puesto apodos, sin embargo, este tipo de maltrato puede venir acompañado de una cadena de agresiones.",
                "Correcto, además las agresiones que iniciaron con palabras pueden desembocar en agresiones físicas si no se detiene al agresor a tiempo.",
                "Esta agresión se ha hecho constantemente hacia Julieta y cuando un ataque se vuelve repetitivo contra una persona se considera bullying."
            ));
            lista.Add(new ObjetoBullyng(
                btnBalonDeFutbol,
                balonDeFutbol,
                imgBalonDeFutbol,
                "Julieta juega en un equipo de fútbol y los niños de su salón la molestan por esto, incluso la hacen llorar.",
                "Correcto. Alejar del grupo a una persona por sus gustos es discriminarla y si además se hace con la conciencia de lastimarla es bullying.",
                "Hacer llorar a alguien y molestarlo con intención de lastimarlo sólo por tener gustos o preferencias diferentes es considerado bullying de tipo social."
            ));
            lista.Add(new ObjetoBullyng(
                btnBolsa,
                bolsa,
                imgBolsa,
                "Julieta se compró un bolso y le preguntó a su mejor amiga si le gustaba, ésta le dijo que no y se siente triste.",
                "Correcto, aunque la respuesta de su amiga la hace sentirse triste, se trata sólo de diferencias de gusto, no es bullying.",
                "Aunque la respuesta de su amiga la hace sentirse triste, se trata sólo de diferencias de gusto, no es bullying."
            ));
            lista.Add(new ObjetoBullyng(
                btnVenda,
                venda,
                imgVenda,
                "Mientras jugaba en el recreo Julieta fue aventada por uno de sus compañeros, se lastimó la mano y tuvieron que vendársela, es la cuarta vez que sucede.",
                "Correcto, es un acoso visible y más fácil de identificar por los daños que genera en la víctima. También puede ser indirecto cuando se producen daños materiales en los objetos personales de la víctima o robos.",
                "Cuando hay agresión directa a base de patadas, empujones, golpes con objetos y cuando es un hecho repetido, se habla de bullying físico."
            ));
            lista.Add(new ObjetoBullyng(
                btnDulces,
                dulces,
                imgDulces,
                "Julieta hizo una fiesta en su casa y no invitó a Laura. Van en el mismo salón pero casi no platican y les gustan cosas diferentes.",
                "Correcto, se considera bullying sólo en caso de abuso de poder y de repetir constantemente las agresiones hacia una persona. No invitar a alguien a alguna actividad es un derecho.",
                "No invitar a alguien a alguna actividad es un derecho. Se considera bullying sólo en caso de abuso de poder y de repetir constantemente las agresiones hacia una persona."
            ));
            lista.Add(new ObjetoBullyng(
                btnExamen,
                examen,
                imgExamen,
                "Julieta estudió toda la tarde para un examen, mientras lo realizaba, uno de sus compañeros le pidió algunas respuestas. Ella se negó por temor a ser reprobada si la descubrían.",
                "Correcto, aunque Julieta tomó una decisión que no le gustó a su compañero, no pretendió lastimar a nadie.",
                "No debemos confundir el bullying con cuidar de nosotros y tomar algunas decisiones que no les gustarán a nuestros compañeros."
            ));
            lista.Add(new ObjetoBullyng(
                btnOsoDePeluche,
                osoDePeluche,
                imgOsoDePeluche,
                "Julieta le prestó su oso de peluche a su mejor amiga, Tamara, sin embargo, ésta le rompió su oso y Julieta está enojada.",
                "Correcto.  No se considera bullying ya que por desagradable que sea esta situación, no existe intención de afectar la autoestima o de dañar a alguien por considerarlo más débil.",
                "Sólo podemos considerar como bullying las agresiones repetidas sobre una persona y aunque pelearse con una amiga es doloroso, no es considerado bullying."
            ));
            lista.Add(new ObjetoBullyng(
                btnCrayola,
                crayola,
                imgCrayola,
                "La maestra de Julieta salió un momento del salón, todos los niños empezaron a aventar cosas y una crayola cayó sobre la cabeza de Julieta.",
                "Correcto. El bullying no está relacionado con un accidente, por molesto que éste pueda ser.",
                "Cuando alguien lanza algo sin intención de afectar al otro y por accidente eso lo golpea, por ser un evento aislado y sin intenciones de dañar, no puede considerarse como bullying."
            ));
            lista.Add(new ObjetoBullyng(
                btnLaptop,
                laptop,
                imgLaptop,
                "Julieta se ha estado comunicando con sus amigas por medio de la redes sociales, sin embargo, tras una discusión una de ellas le escribió \"egoísta\".",
                "Correcto. Aunque el bullying puede darse a través de las redes sociales esta situación no lo es.",
                "Aunque el bullying puede darse a través de las redes sociales esta situación no lo es, fue sólo una pelea entre amigas."
            ));
            return lista;
        }
        private List<ObjetoBullyng> llenarListaJuego() {
            List<ObjetoBullyng> lista = new List<ObjetoBullyng>();
            List<ObjetoBullyng> listaBase = llenarAlmacenObjetos();
            while (lista.Count < 10) {
                var index = Random.Range(0, listaBase.Count);
                lista.Add(listaBase[index]);
                listaBase.RemoveAt(index);
            }
            foreach (ObjetoBullyng row in lista) {
                Button btnRow = row.GetButton();
                GameObject txtRow = row.GetName().gameObject;
                btnRow.gameObject.SetActive(true);
                txtRow.SetActive(true);
                txtRow.transform.localPosition = getPosition(lista, lista.IndexOf(row));
            }
            return lista;
        }
        private Vector3 getPosition(List<ObjetoBullyng> list, int index) {
            Vector3 position = new Vector3();
			if (index == 0)
            {
                position = new Vector3(0, 0, 0);
            }
            else
            {
                Text txtObj = list[index - 1].GetName();
                if (txtObj.text.Length > 11)
                {
                    position = new Vector3(0,txtObj.transform.localPosition.y - 50, 0);
                }
                else
                {
                    position = new Vector3(0, txtObj.transform.localPosition.y - 30, 0);
                }
            }
            print(position.x + "," + position.y + "," + position.z);
            return position;
        }
		private void MostrarMenu() {
			DropDownMenuCamvas.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<Button>().interactable=true;
		}

		private void OcultarMenu() {
			DropDownMenuCamvas.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<Button>().interactable=false;
		}
        private void FinalizarReto2()
        {
            clon.name = "ODA5";
            clon.SetActive(true);
            clon.transform.FindChild("DropDownMenuCamvas").gameObject.SetActive(true);
            Destroy(gameObject);
        }
        private void InicializarEscenario1()
        {
			Invoke("ClonarGameObject",1);
            inicializado = true;
            ResetEscenario1();
			OcultarMenu();
        }
		private void ClonarGameObject() {
			clon = Instantiate(gameObject);
			clon.SetActive(false);
			clon.transform.GetChild(3).gameObject.SetActive(false);
			clon.transform.GetChild(4).gameObject.SetActive(true);
			clon.transform.GetChild(6).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<Button>().interactable=true;
		}
        private void DropCorrecto()
        {
            sm.playSound("Sound_correcto10", 1); 
            if (indexlista < 10)
            {
                ObjetoBullyng obj = listaObjetosJuego[indexlista];
                textSuccessEscenario2.text = obj.GetDropCorrecto();
            }
            successEscenario2.SetActive(true);
            draggingItem.SetActive(false);
            OcultarMenu();
        }

        private void DropIncorrecto()
        {
            sm.playSound("Sound_incorrecto19", 1); 
            draggingItem.transform.localPosition = posIni;
            if (indexlista < 10)
            {
                ObjetoBullyng obj = listaObjetosJuego[indexlista];
                textErrorEscenario2.text = obj.GetDropIncorrecto();
            }
            errorEscenario2.SetActive(true);
            draggingItem.SetActive(false);
            OcultarMenu();
        }

        private bool FirstPlaneEscenario1()
        {
            if (instructionsEscenario1.activeSelf) return false;
            if (successEscenario1.activeSelf) return false;
            if (timeOutEscenario1.activeSelf) return false;
            if (finishEscenario1.activeSelf) return false;
            if (popUpEscenario1.activeSelf) return false;
            if (adivinanzaEscenario1.activeSelf) return false;
            if (errorAdivinanzaEscenario1.activeSelf) return false;
            return true;
        }

        private void CerrarEscenario1()
        {
            sm.apagarReloj();
            escenario1.SetActive(false);
            escenario2.SetActive(true);
            instructionsEscenario2.SetActive(true);
            InicializarEscenario2();
        }

        private void InicializarEscenario2()
        {
            escenario2Lista1.SetActive(true);
            PopElementosEncontrados();
        }

        private void PopElementosEncontrados()
        {
            if (indexlista < 10)
            {
                ObjetoBullyng obj = listaObjetosJuego[indexlista];
                textPopUpEscenario2.text = obj.GetHistoria();
                obj.GetImage().gameObject.SetActive(true);
            }
            else
            {
                OcultarMenu();
                sm.playSound("Sound_TerminarReto", 1);
                finishEscenario2.SetActive(true);
            }
        }

        private void SeleccionarObjetoEscenario1(GameObject obj)
        {
            obj.SetActive(false);
            switch(obj.name){
                case "BtnLentes":
                    lentes.gameObject.SetActive(false);
                    break;
                case "BtnCredencial_escolar":
                    credencialEscolar.gameObject.SetActive(false);
                    break;
                case "BtnInsecto":
                    insecto.gameObject.SetActive(false);
                    break;
                case "BtnMochila":
                    mochila.gameObject.SetActive(false);
                    break;
                case "BtnCurita":
                    curita.gameObject.SetActive(false);
                    break;
                case "BtnPastel":
                    pastel.gameObject.SetActive(false);
                    break;
                case "BtnCuaderno":
                    cuaderno.gameObject.SetActive(false);
                    break;
                case "BtnMuñeca":
                    muñeca.gameObject.SetActive(false);
                    break;
                case "BtnBola_de_papel":
                    bolaDePapel.gameObject.SetActive(false);
                    break;
                case "BtnCelular":
                    celular.gameObject.SetActive(false);
                    break;
                case "BtnZapato":
                    zapato.gameObject.SetActive(false);
                    break;
                case "BtnEtiqueta_de_cuaderno":
                    etiquetaDeCuaderno.gameObject.SetActive(false);
                    break;
                case "BtnBalon_de_futbol":
                    balonDeFutbol.gameObject.SetActive(false);
                    break;
                case "BtnBolsa":
                    bolsa.gameObject.SetActive(false);
                    break;
                case "BtnVenda":
                    venda.gameObject.SetActive(false);
                    break;
                case "BtnDulces":
                    dulces.gameObject.SetActive(false);
                    break;
                case "BtnExamen":
                    examen.gameObject.SetActive(false);
                    break;
                case "BtnOso_de_peluche":
                    osoDePeluche.gameObject.SetActive(false);
                    break;
                case "BtnCrayola":
                    crayola.gameObject.SetActive(false);
                    break;
                case "BtnLaptop":
                    laptop.gameObject.SetActive(false);
                    break;
            }
            CheckFinishEscenario1();
        }

        private void CheckFinishEscenario1()
        {
            var flagFinish = true;
            foreach (var row in listaObjetosJuego)
            {
                var btn = row.GetButton();
                if (btn.gameObject.activeSelf) flagFinish = false;
            }
            if (flagFinish) FinalizarEscenario1();
        }

        private void FinalizarEscenario1()
        {
            cronometro.StopTimer();
            finishEscenario1.SetActive(true);
            sm.playSound("Sound_OpenPopUp10", 1); 
            sm.apagarReloj();
            OcultarMenu();
        }

        private void ResetEscenario1()
        {
            timeExt = 0;
            escenario1.SetActive(true);
            escenario2.SetActive(false);
            instructionsEscenario1.SetActive(false);
            errorAdivinanzaEscenario1.SetActive(false);
            adivinanzaEscenario1.SetActive(false);
            successEscenario1.SetActive(false);
            finishEscenario1.SetActive(false);
            timeOutEscenario1.SetActive(false);
            ResetObjetosEscenario1();
            listaObjetosJuego = llenarListaJuego();
            AddTime();
        }

        private void ResetObjetosEscenario1()
        {
            List<ObjetoBullyng> almacenObjetos = llenarAlmacenObjetos();
            foreach (ObjetoBullyng row in almacenObjetos)
            {
                var btn = row.GetButton();
                var txt = row.GetName();
                btn.gameObject.SetActive(false);
                txt.gameObject.SetActive(false);
            }
        }

        private void AddTime()
        {
            sm.playSound("Sound_OpenPopUp10", 1); 
            popUpEscenario1.SetActive(true);
            adivinanzaEscenario1.SetActive(false);
            var timeExtLoc = new int[2];
            timeExtLoc[0] = 10;
            timeExtLoc[1] = 15;
            randomInt = Random.Range(0, 2);
            timeExt = timeExtLoc[randomInt];
            textPopUpEscenario1.text = "Es tu día de suerte: acierta la siguiente adivinanza y llévate " + timeExt +
                                       " segundos extras para resolver el reto.";
        }
        private List<String[]> fillAdivinanzas() {
            List<String[]> lista = new List<String[]>();
            var adivinanzas = new string[4];
            adivinanzas[0] ="Soy la parte del tríptico donde puedes encontrar un titular atractivo, logotipos y una imagen que complementa y refuerza el tema, soy la ...";
            adivinanzas[1] = "Contraportada ";
            adivinanzas[2] = "Portada";
            adivinanzas[3] = "Portada";
            lista.Add(adivinanzas);

            var adivinanzas2 = new string[4];
            adivinanzas2[0] = "En un tríptico, suelo darle un toque atractivo y original, soy el ...";
            adivinanzas2[1] = "Diseño";
            adivinanzas2[2] = "Número de teléfono";
            adivinanzas2[3] = "Diseño";
            lista.Add(adivinanzas2);

            var adivinanzas3 = new string[4];
            adivinanzas3[0] = "Puedo ser un adjetivo o un nombre propio, pero lo más importante es que describo cómo suele ser la información en un tríptico, soy ...";
            adivinanzas3[1] = "Larga";
            adivinanzas3[2] = "Clara";
            adivinanzas3[3] = "Clara";
            lista.Add(adivinanzas3);
            return lista;
        }
        private void AddAdivinanza()
        {
            errorAdivinanzaEscenario1.SetActive(false);
            popUpEscenario1.SetActive(false);
            adivinanzaEscenario1.SetActive(true);
            sm.playSound("Sound_OpenPopUp10", 1);
            if (listaAdivinanzas.Count == 0) listaAdivinanzas = fillAdivinanzas();
            randomInt = Random.Range(0, listaAdivinanzas.Count);
            textAdivinanzaEscenario1.text = listaAdivinanzas[randomInt][0];
            textAdivinanzaRespuesta1Escenario1.text = listaAdivinanzas[randomInt][1];
            textAdivinanzaRespuesta2Escenario1.text = listaAdivinanzas[randomInt][2];
        }

        private void RevisarAdivinanza(Button option)
        {
            var respuesta = option.transform.GetChild(0).GetComponent<Text>();
            var pregunta = listaAdivinanzas[randomInt];
            if (respuesta.text == pregunta[3])
            {
                sm.playSound("Sound_correcto10", 1); 
                adivinanzaEscenario1.SetActive(false);
                textSuccessEscenario1.text = "¡Felicidades acabas de ganarte " + timeExt + " segundos extras!";
                successEscenario1.SetActive(true);
            }
            else
            {
                sm.playSound("Sound_incorrecto19", 1); 
                adivinanzaEscenario1.SetActive(false);
                errorAdivinanzaEscenario1.SetActive(true);
                textErrorAdivinanzaEscenario1.text = "Soy " + pregunta[3] +
                                                     ", vuelve a intentarlo o sigue con el reto.";
            }
            listaAdivinanzas.RemoveAt(randomInt);
        }

        private void FinalizarAdivinanzas()
        {
            adivinanzaEscenario1.SetActive(false);
            errorAdivinanzaEscenario1.SetActive(false);
            instructionsEscenario1.SetActive(true);
            sm.playSound("Sound_OpenPopUp10", 1); 
        }

        private void ComenzarReto1()
        {
            timeToPlay = 40;
            flag = true;
            adivinanzaEscenario1.SetActive(false);
            errorAdivinanzaEscenario1.SetActive(false);
            instructionsEscenario1.SetActive(false);
            sm.playSound("Sound_reloj1", 2); 
            sm.encenderReloj();
            cronometro.StartTimer(timeToPlay);
            MostrarMenu();
        }

        private void TimeOut()
        {
             
            if (flag)
            {
                sm.apagarReloj();
                sm.playSound("Sound_TimeOver", 1); 
                if (timeExt > 0)
                    textTimeOutEscenario1.text = "Se acabó el tiempo pero tienes " + timeExt +
                                                 " segundos extras. ¡Ánimo!";
                else
                    textTimeOutEscenario1.text = "Se acabó el tiempo pero vuelve a intentarlo, seguro que lo lograrás.";
                timeOutEscenario1.SetActive(true);
                flag = false;
                OcultarMenu();
                //   sm.playSound("Sound_OpenPopUp10", 1); 
            }
        }
    }

    public class ObjetoBullyng
    {
        public Button BtnObjeto;
        public string Historia;
        public Image ImgObjeto;
        public Text NameObjeto;
        public string TxtCorrecto;
        public string TxtIncorrecto;

        public ObjetoBullyng(Button btn, Text txtName, Image img, string txtHistoria, string txtCorrecto,
            string txtIncorrecto)
        {
            BtnObjeto = btn;
            NameObjeto = txtName;
            ImgObjeto = img;
            Historia = txtHistoria;
            TxtCorrecto = txtCorrecto;
            TxtIncorrecto = txtIncorrecto;
        }

        public void SetButton(Button btn)
        {
            BtnObjeto = btn;
        }

        public Button GetButton()
        {
            return BtnObjeto;
        }

        public void SetName(Text name)
        {
            NameObjeto = name;
        }

        public Text GetName()
        {
            return NameObjeto;
        }

        public void SetImage(Image img)
        {
            ImgObjeto = img;
        }

        public Image GetImage()
        {
            return ImgObjeto;
        }

        public void SetHistoria(string txtHistoria)
        {
            Historia = txtHistoria;
        }

        public string GetHistoria()
        {
            return Historia;
        }

        public void SetDropCorrecto(string txt)
        {
            TxtCorrecto = txt;
        }

        public string GetDropCorrecto()
        {
            return TxtCorrecto;
        }

        public void SetDropIncorrecto(string txt)
        {
            TxtIncorrecto = txt;
        }

        public string GetDropIncorrecto()
        {
            return TxtIncorrecto;
        }
    }
}