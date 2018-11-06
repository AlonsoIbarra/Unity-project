using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RetoFinalOda5 : MonoBehaviour
    {
        //Colores preguntas
        private readonly Color answerSettedColor = new Color32(14, 209, 242, 255);
    private readonly List<Button> btnRespuestas = new List<Button>();
    private readonly Color defaultAnswerColor = new Color32(9, 74, 139, 255);
    //popUps
    private readonly List<GameObject> popUps = new List<GameObject>();
    public bool BoolIniciado;
    private Button btnAceptar;

    //popUpsButtons
    private Button btnAtras;
    private Button btnSalir;
    private GameObject menu;
    private GameObject dropDownMenu;

    //Scripts ayuda
    private Menu menuScript;
    public int PreguntaActual;

    //Variables de evaluacion
    private List<Question> preguntas = new List<Question>();
    private List<Answer> respuestas = new List<Answer>();

    private GameObject retoFinal;
    private SoundManager sm;

    private Text txtCalificacion;

    //popUpsText
    private Text txtPregunta;
    private Text txtRespuesta;
    private GameObject resultadoPregunta;
    public List<Text> TxtRespuestas = new List<Text>();

    // ------------------------Genericos Unity----------------------
    private void Start()
    {
        sm = this.gameObject.GetComponent<SoundManager>();
        //Scripts de Ayuda
        menuScript = this.gameObject.transform.GetComponent<Menu>();
        retoFinal = this.gameObject.transform.FindChild("RetoFinal").gameObject;
        menu = this.gameObject.transform.FindChild("Menu").gameObject;
        dropDownMenu = this.gameObject.transform.FindChild("DropDownMenuCamvas").gameObject;

        //popUps
        popUps.Add(retoFinal.transform.FindChild("popUpPregunta").gameObject);
        popUps.Add(retoFinal.transform.FindChild("popUpResultados").gameObject);

        //popUps Buttons
        btnAtras = popUps[0].transform.FindChild("btnAnterior").GetComponent<Button>();
        btnAceptar = popUps[0].transform.FindChild("btnAceptar").GetComponent<Button>();

        btnSalir = popUps[1].transform.FindChild("btnSalir").GetComponent<Button>();

        var goRespuestas = popUps[0].transform.FindChild("respuestas").gameObject;
        btnRespuestas.Add(goRespuestas.transform.FindChild("btnRespuesta1").GetComponent<Button>());
        btnRespuestas.Add(goRespuestas.transform.FindChild("btnRespuesta2").GetComponent<Button>());
        btnRespuestas.Add(goRespuestas.transform.FindChild("btnRespuesta3").GetComponent<Button>());

        //popUps Text
        txtPregunta = popUps[0].transform.FindChild("txtPregunta").GetComponent<Text>();
        if (TxtRespuestas.Count == 0)
        {
            TxtRespuestas.Add(btnRespuestas[0].transform.GetChild(0).GetComponent<Text>());
            TxtRespuestas.Add(btnRespuestas[1].transform.GetChild(0).GetComponent<Text>());
            TxtRespuestas.Add(btnRespuestas[2].transform.GetChild(0).GetComponent<Text>());
        }
        txtCalificacion = popUps[1].transform.FindChild("txtCalificacion").GetComponent<Text>();
        txtRespuesta = popUps[1].transform.FindChild("resultadoPregunta").GetComponent<Text>();

        //Funciones Botones
        btnAtras.onClick.AddListener(delegate { Regresar(); });
        btnAceptar.onClick.AddListener(delegate { Avanzar(); });

        btnSalir.onClick.AddListener(delegate
        {
            sm.playSound("Sound_TerminarReto", 1);
            dropDownMenu.SetActive(true);
            BoolIniciado = false;
            LimpiarResultados();
            menu.SetActive(true);
            retoFinal.SetActive(false);
            sm.playSound("Sound_Fondo_piano", 0);
        });

        btnRespuestas[0].onClick.AddListener(delegate { SeleccionarRespuesta(0); });
        btnRespuestas[1].onClick.AddListener(delegate { SeleccionarRespuesta(1); });
        btnRespuestas[2].onClick.AddListener(delegate { SeleccionarRespuesta(2); });
        //mostrarPregunta ();
    }


    // ------------------------Genericos Retos----------------------

    //Funciones secuencia
    public IEnumerator secuenciaEventos(string secuencia, float tiempoEspera)
    {
        yield return new WaitForSeconds(tiempoEspera);
        switch (secuencia)
        {
            case "iniciarEvaluacion":
                CrearCuestionario();
                SeleccionarPreguntasRandom(5);
                PreguntaActual = 0;
                popUps[0].SetActive(true);
                popUps[1].SetActive(false);
                LimpiarResultados();
                MostrarPregunta();
                break;
            case "evaluar":
                MostrarResultados();
                break;
            case "salir":
                sm.playSound("Sound_Fondo_piano", 0);
                LimpiarResultados();
                retoFinal.SetActive(false);
                menu.SetActive(true);
                break;
        }
    }

    // ------------------------Funciones UI------------------------------
    private void MostrarPregunta()
    {
        txtPregunta.text = "" + (PreguntaActual + 1) + ". " +
                           respuestas[PreguntaActual].GetQuestion().GetQuestionText();
        TxtRespuestas[0].text = "a) " + respuestas[PreguntaActual].GetQuestion().GetAnserTexts()[0];
        TxtRespuestas[1].text = "b) " + respuestas[PreguntaActual].GetQuestion().GetAnserTexts()[1];
        TxtRespuestas[2].text = "c) " + respuestas[PreguntaActual].GetQuestion().GetAnserTexts()[2];

        ColorearRespuestaSeleccionada();

        if (PreguntaActual <= 0)
        {
            btnAtras.gameObject.SetActive(true);
            btnAtras.interactable = false;
            btnAceptar.transform.localPosition = new Vector3(216, btnAceptar.transform.localPosition.y,
                btnAceptar.transform.localPosition.z);
        }
        else
        {
            btnAtras.gameObject.SetActive(true);
            btnAtras.interactable = true;
            btnAtras.transform.GetChild(0).GetComponent<Text>().text = "ATRÁS";

            btnAceptar.transform.localPosition = new Vector3(216, btnAceptar.transform.localPosition.y,
                btnAceptar.transform.localPosition.z);
        }

        if (PreguntaActual >= respuestas.Count - 1)
            btnAceptar.transform.GetChild(0).GetComponent<Text>().text = "TERMINAR";
        else btnAceptar.transform.GetChild(0).GetComponent<Text>().text = "ACEPTAR";
    }

    private void Update()
    {
        if (retoFinal.activeSelf && !BoolIniciado)
        {
            BoolIniciado = true;
            sm.playSound("Sound_Fondoevaluacion", 0); 
            StartCoroutine(GetComponent<RetoFinalOda5>().secuenciaEventos("iniciarEvaluacion", 0.0f));
        }
    }

    private void ColorearRespuestaSeleccionada()
    {
/*
 *        Debug.Log("pregunta actual " + PreguntaActual);
        Debug.Log("seleccionar " + boton);
        sm.playSound("Sound_SeleccionarRespuesta", 1);
        respuestas[PreguntaActual].SetAnswer(boton);
        */

        for (var index = 0; index < TxtRespuestas.Count; index++)
        {
            if (index == respuestas[PreguntaActual].GetAnswer()) TxtRespuestas[index].color = answerSettedColor;
            else TxtRespuestas[index].color = defaultAnswerColor;
            Debug.Log(TxtRespuestas[index].color);
        }
    }

    private void MostrarResultados()
    {
        popUps[0].SetActive(false);
        popUps[1].SetActive(true);

        var correctas = 0;
        resultadoPregunta = popUps[1].transform.FindChild("resultadoPregunta").gameObject;
        resultadoPregunta.gameObject.SetActive(true);
        for (var index = 0; index < respuestas.Count; index++)
        {
            var resultadoPreguntaClone = Instantiate(resultadoPregunta);

            resultadoPreguntaClone.transform.SetParent(resultadoPregunta.transform.parent);
            resultadoPreguntaClone.transform.localScale = new Vector3(1, 1, 1);
            resultadoPreguntaClone.transform.localPosition = resultadoPregunta.transform.localPosition + Vector3.down * index * 34;
            
            if (respuestas[index].GetQuestion().ReviewQuestion(respuestas[index].GetAnswer()))
            {
                resultadoPreguntaClone.transform.GetChild(0).transform.gameObject.SetActive(true);
                resultadoPreguntaClone.transform.GetChild(2).GetComponent<Text>().text = "2";
                correctas++;
            }
            else
            {
                resultadoPreguntaClone.transform.GetChild(1).transform.gameObject.SetActive(true);
                resultadoPreguntaClone.transform.GetChild(2).GetComponent<Text>().text = "0";
            }
        }
        resultadoPregunta.gameObject.SetActive(false);
        txtCalificacion.text = "" + correctas * 2 + " / 10";
    }

    private void LimpiarResultados()
    {
        foreach (Transform child in popUps[1].transform)
            if (child.name == "resultadoPregunta(Clone)") Destroy(child.gameObject);
        popUps[0].SetActive(true);
        popUps[1].SetActive(false);
        //        this.BoolIniciado = false;
    }

    // ------------------------Funciones Botones-------------------------

    private void Regresar()
    {
        PreguntaActual--;
        MostrarPregunta();
    }

    private void Avanzar()
    {
        if (PreguntaActual >= respuestas.Count - 1)
        {
            sm.playSound("Sound_SumarioRespuestas", 1); 
            StartCoroutine(secuenciaEventos("evaluar", 0.1f));
        }
        else
        {
            PreguntaActual++;
            MostrarPregunta();
        }
    }

    private void SeleccionarRespuesta(int boton)
    {
        Debug.Log("pregunta actual " + PreguntaActual);
        Debug.Log("seleccionar " + boton);
        sm.playSound("Sound_SeleccionarRespuesta", 1);
        respuestas[PreguntaActual].SetAnswer(boton);

        ColorearRespuestaSeleccionada();
    }

    // ------------------------Funciones Evaluacion----------------------

    private void SeleccionarPreguntasRandom(int numeroPreguntas)
    {
        respuestas = new List<Answer>();
        for (var i = 0; i < numeroPreguntas; i++)
        {
            var randomIndex = Random.Range(0, preguntas.Count);
            respuestas.Add(new Answer(preguntas[randomIndex], -1));
            preguntas.RemoveAt(randomIndex);
        }
    }

    private void CrearCuestionario()
    {
        preguntas = new List<Question>();
        preguntas.Add(new Question("Un tríptico es una hoja con:",
            new[]
            {
                    "Tres actos distintos",
                    "Tres partes que contiene información o publicidad relevante",
                    "Información sobre los acontecimientos actuales"
            },
            1)); //1
        preguntas.Add(new Question("¿Cuál de las siguientes no es una característica de los trípticos?",
            new[]
            {
                    "Dar las noticias",
                    "Incluir textos e imágenes",
                    "Ocupar poco espacio y tener seis caras"
            },
            0)); //2
        preguntas.Add(new Question("Para prevenir el bullying, es recomendable:",
            new[]
            {
                    "Ser espía del profesor",
                    "Fomentar ambiente de tolerancia y respeto en el aula",
                    "Escribir bitácoras sobre lo que sucede en el aula"
            },
            1)); //3
        preguntas.Add(new Question("Se puede decir que existe agresión física cuando:",
            new[]
            {
                    "Mandan mensajes ofensivos por vías electrónicas",
                    "Ponen apodos",
                    "Dan un golpe o un empujón a alguien"
            },
            2)); //4
        preguntas.Add(new Question("Se puede decir que existe agresión psicológica cuando:",
            new[]
            {
                    "Buscan ofender a través de las palabras",
                    "Empujan a alguien",
                    "Acusan injustamente de algo a alguien"
            },
            0)); //5
        preguntas.Add(new Question("¿Cuál de las siguientes definiciones es la que corresponde al bullying?",
            new[]
            {
                    "Agresión verbal pero no física",
                    "Agresión constante y repetida",
                    "Agresión física pero no verbal"
            },
            1)); //6
        preguntas.Add(
            new Question("Es importante informar a un adulto sobre una situación de bullying porque:",
                new[]
                {
                        "Sabrá cómo actuar ante circunstancias como éstas",
                        "Sabrá cómo reprender a los involucrados",
                        "Sabrá cuáles son las consecuencias que deben sufrir los agresores "
                },
                0)); //7
        preguntas.Add(new Question("¿Cuál característica corresponde a un tríptico?",
            new[]
            {
                    "Es un folleto actualizado con lo último del momento",
                    "Es un folleto de promoción",
                    "Es un folleto publicitario"
            },
            2)); //8
        preguntas.Add(new Question("¿Quiénes son los involucrados en una situación de bullying?",
            new[]
            {
                    "Golpeador y víctima",
                    "Agresor y ofendido",
                    "Agresor y agredido"
            },
            2)); //9
        preguntas.Add(new Question("Ejemplo de bullying:",
            new[]
            {
                    "Poner apodos y llamar así al compañero",
                    "Hacer una reunión y excluir a algunos",
                    "Hacer siempre equipo con los mismos compañeros"
            },
            0)); //10
    }
}

public class Question
{
    private readonly string[] answersTexts;
    private readonly int correctAnswer;
    private readonly string questionText;

    /// <summary>
    ///     Question with only one correct answer
    /// </summary>
    /// <param name="questionTest">Here comes the question string</param>
    /// <param name="answerTexts">Here comes all the text of each answer</param>
    /// <param name="correctAnswer">Correct Answer, NOTE it has to be int starting in 0</param>
    public Question(string questionTest, string[] answerTexts, int correctAnswer)
    {
        questionText = questionTest;
        answersTexts = answerTexts;
        this.correctAnswer = correctAnswer;
    }

    public bool ReviewQuestion(int answer)
    {
        if (answer == correctAnswer) return true;
        return false;
    }

    public string GetQuestionText()
    {
        return questionText;
    }

    public string[] GetAnserTexts()
    {
        return answersTexts;
    }
}

public class Answer
{
    private readonly Question question;
    private int answer;

    /// <summary>
    ///     Answer for a single answer question
    /// </summary>
    /// <param name="question">Question object</param>
    /// <param name="answer">Answer to the question object</param>
    public Answer(Question question, int answer)
    {
        this.question = question;
        this.answer = answer;
    }

    public Question GetQuestion()
    {
        return question;
    }

    public int GetAnswer()
    {
        return answer;
    }

    public void SetAnswer(int answer)
    {
        this.answer = answer;
    }
}