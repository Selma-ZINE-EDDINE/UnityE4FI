using System.Collections;
using UnityEngine;
using UnityEngine.Playables;
using KartGame.KartSystems;
using UnityEngine.SceneManagement;

public enum GameState{Intro,Play, Won, Lost,World}

public class GameFlowManager : MonoBehaviour
{
    [Header("Parameters")]
    [Tooltip("Duration of the fade-to-black at the end of the game")]
    public float endSceneLoadDelay = 3f;
    [Tooltip("The canvas group of the fade-to-black screen")]
    public CanvasGroup endGameFadeCanvasGroup;

    [Header("Win")]
    [Tooltip("This string has to be the name of the scene you want to load when winning")]
    public string winSceneName = "WinScene";
    [Tooltip("Duration of delay before the fade-to-black, if winning")]
    public float delayBeforeFadeToBlack = 4f;
    [Tooltip("Duration of delay before the win message")]
    public float delayBeforeWinMessage = 2f;
    [Tooltip("Sound played on win")]
    public AudioClip victorySound;

    [Tooltip("Prefab for the win game message")]
    public DisplayMessage winDisplayMessage;

    public PlayableDirector raceCountdownTrigger;

    [Header("Lose")]
    [Tooltip("This string has to be the name of the scene you want to load when losing")]
    public string loseSceneName = "LoseScene";
    [Tooltip("Prefab for the lose game message")]
    public DisplayMessage loseDisplayMessage;

    [Header("world")]
    [Tooltip("This string has to be the name of the scene you want to load when exploring world")]
    public string worldSceneName = "world";
    [Tooltip("Prefab for the world game message")]
    public DisplayMessage worldDisplayMessage;

    public GameState gameState { get; private set; }

    public bool autoFindKarts = true;
    public ArcadeKart playerKart;

    ArcadeKart[] karts;
    ObjectiveManager m_ObjectiveManager;
    TimeManager m_TimeManager;
    float m_TimeLoadEndGameScene;
    string m_SceneToLoad;
    float elapsedTimeBeforeEndScene = 0;

    

    // Ajoute un état pour la scène d'introduction si besoin
    public string introSceneName = "IntroMenu";

    void Start()
    {
        /*if (autoFindKarts)
        {
            karts = FindObjectsOfType<ArcadeKart>();
            if (karts.Length > 0)
            {
                if (!playerKart) playerKart = karts[0];
            }
            DebugUtility.HandleErrorIfNullFindObject<ArcadeKart, GameFlowManager>(playerKart, this);
        }

        m_ObjectiveManager = FindObjectOfType<ObjectiveManager>();
		DebugUtility.HandleErrorIfNullFindObject<ObjectiveManager, GameFlowManager>(m_ObjectiveManager, this);

        m_TimeManager = FindObjectOfType<TimeManager>();
        DebugUtility.HandleErrorIfNullFindObject<TimeManager, GameFlowManager>(m_TimeManager, this);

        AudioUtility.SetMasterVolume(1);

        winDisplayMessage.gameObject.SetActive(false);
        loseDisplayMessage.gameObject.SetActive(false);

        m_TimeManager.StopRace();
        foreach (ArcadeKart k in karts)
        {
			k.SetCanMove(false);
        }

        //run race countdown animation
        ShowRaceCountdownAnimation();
        StartCoroutine(ShowObjectivesRoutine());

        StartCoroutine(CountdownThenStartRaceRoutine());*/


        /*m_ObjectiveManager = FindObjectOfType<ObjectiveManager>();
        DebugUtility.HandleErrorIfNullFindObject<ObjectiveManager, GameFlowManager>(m_ObjectiveManager, this);
        m_TimeManager = FindObjectOfType<TimeManager>();
        DebugUtility.HandleErrorIfNullFindObject<TimeManager, GameFlowManager>(m_TimeManager, this);
        // Si tu veux démarrer dans la scène d'introduction
        if (SceneManager.GetActiveScene().name == introSceneName)
        {
            gameState = GameState.Intro;
        }

        if (gameState == GameState.Intro || gameState == GameState.World)
        {
            // Ne pas démarrer la course dans la scène d'intro ou World
            m_TimeManager.StopRace();
            foreach (ArcadeKart k in karts)
            {
                k.SetCanMove(false);
            }
        }
        else
        {
            // Les autres scènes lancent le compte à rebours et la course
            ShowRaceCountdownAnimation();
            StartCoroutine(ShowObjectivesRoutine());
            StartCoroutine(CountdownThenStartRaceRoutine());
        }*/

        if (autoFindKarts)
        {
            karts = FindObjectsOfType<ArcadeKart>();
            if (karts.Length > 0)
            {
                if (!playerKart) playerKart = karts[0];
            }
            DebugUtility.HandleErrorIfNullFindObject<ArcadeKart, GameFlowManager>(playerKart, this);
        }

        m_ObjectiveManager = FindObjectOfType<ObjectiveManager>();
        DebugUtility.HandleErrorIfNullFindObject<ObjectiveManager, GameFlowManager>(m_ObjectiveManager, this);

        m_TimeManager = FindObjectOfType<TimeManager>();
        DebugUtility.HandleErrorIfNullFindObject<TimeManager, GameFlowManager>(m_TimeManager, this);

        AudioUtility.SetMasterVolume(1);

        winDisplayMessage.gameObject.SetActive(false);
        loseDisplayMessage.gameObject.SetActive(false);

        m_TimeManager.StopRace();
        foreach (ArcadeKart k in karts)
        {
            k.SetCanMove(false);
        }

        //run race countdown animation
        ShowRaceCountdownAnimation();
        StartCoroutine(ShowObjectivesRoutine());

        StartCoroutine(CountdownThenStartRaceRoutine());

        gameState = GameState.Intro;


    }

    IEnumerator CountdownThenStartRaceRoutine() {
        yield return new WaitForSeconds(3f);
        StartRace();
    }

    void StartRace() {
        foreach (ArcadeKart k in karts)
        {
			k.SetCanMove(true);
        }
        m_TimeManager.StartRace();
    }

    void ShowRaceCountdownAnimation() {
        raceCountdownTrigger.Play();
    }

    IEnumerator ShowObjectivesRoutine() {
        while (m_ObjectiveManager.Objectives.Count == 0)
            yield return null;
        yield return new WaitForSecondsRealtime(0.2f);
        for (int i = 0; i < m_ObjectiveManager.Objectives.Count; i++)
        {
           if (m_ObjectiveManager.Objectives[i].displayMessage)m_ObjectiveManager.Objectives[i].displayMessage.Display();
           yield return new WaitForSecondsRealtime(1f);
        }
    }

    public void LoadWorldScene()
    {
        SceneManager.LoadScene(worldSceneName);
        gameState = GameState.World;
    }

    public void LoadPlayScene()
    {
        SceneManager.LoadScene("MainScene"); 
        gameState = GameState.Play;
    }

    void Update()
    {
        // Gestion des états comme d'habitude , chatgpt
        /*if (gameState == GameState.Play)
        {
            // Logique pour terminer le jeu (victoire ou défaite)
            if (m_ObjectiveManager.AreAllObjectivesCompleted())
                EndGame(true);

            if (m_TimeManager.IsFinite && m_TimeManager.IsOver)
                EndGame(false);
        }*/

        //base
        /*if (gameState != GameState.Play)
        {
            elapsedTimeBeforeEndScene += Time.deltaTime;
            if(elapsedTimeBeforeEndScene >= endSceneLoadDelay)
            {

                float timeRatio = 1 - (m_TimeLoadEndGameScene - Time.time) / endSceneLoadDelay;
                endGameFadeCanvasGroup.alpha = timeRatio;

                float volumeRatio = Mathf.Abs(timeRatio);
                float volume = Mathf.Clamp(1 - volumeRatio, 0, 1);
                AudioUtility.SetMasterVolume(volume);

                // See if it's time to load the end scene (after the delay)
                if (Time.time >= m_TimeLoadEndGameScene)
                {
                    SceneManager.LoadScene(m_SceneToLoad);
                    gameState = GameState.Play;
                }
            }
        }
        else
        {
            if (m_ObjectiveManager.AreAllObjectivesCompleted())
                EndGame(true);

            if (m_TimeManager.IsFinite && m_TimeManager.IsOver)
                EndGame(false);
        }*/

        /*if(gameState == GameState.Play)
        {
            if (m_ObjectiveManager.AreAllObjectivesCompleted())
                EndGame(true);

            if (m_TimeManager.IsFinite && m_TimeManager.IsOver)
                EndGame(false);
        }*/

        if (gameState != GameState.Play) // si on est pas dans le karting game
        {
            elapsedTimeBeforeEndScene += Time.deltaTime; //le chrono du karting game ne bouge pas
            if (elapsedTimeBeforeEndScene >= endSceneLoadDelay)
            {

                float timeRatio = 1 - (m_TimeLoadEndGameScene - Time.time) / endSceneLoadDelay;
                endGameFadeCanvasGroup.alpha = timeRatio;

                float volumeRatio = Mathf.Abs(timeRatio);
                float volume = Mathf.Clamp(1 - volumeRatio, 0, 1);
                AudioUtility.SetMasterVolume(volume);

                // See if it's time to load the end scene (after the delay)
                if (Time.time >= m_TimeLoadEndGameScene)
                {
                    SceneManager.LoadScene(m_SceneToLoad);
                    gameState = GameState.Play;
                }
            }
        }
        else
        {
            if (m_ObjectiveManager.AreAllObjectivesCompleted())
                EndGame(true);

            if (m_TimeManager.IsFinite && m_TimeManager.IsOver)
                EndGame(false);
        }

        if(SceneManager.GetActiveScene().name == "IntroMenu")
        {
            gameState= GameState.Intro;
            
        }
        else if(SceneManager.GetActiveScene().name == "world")
        {
            gameState = GameState.World;
           // SceneManager.LoadScene("world");
        }
        else if (SceneManager.GetActiveScene().name == "MainScene")
        {
            gameState = GameState.Play;
            //SceneManager.LoadScene("MainScene");
        }
        else if (SceneManager.GetActiveScene().name == "WinScene")
        {
            gameState = GameState.Won;
           // SceneManager.LoadScene("WinScene");
        }
        else if (SceneManager.GetActiveScene().name == "LoseScene")
        {
            gameState = GameState.Lost;
            //SceneManager.LoadScene("LoseScene");
        }

    }

    void EndGame(bool win)
    {
        // unlocks the cursor before leaving the scene, to be able to click buttons
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        m_TimeManager.StopRace();

        // Remember that we need to load the appropriate end scene after a delay
        gameState = win ? GameState.Won : GameState.Lost;
        endGameFadeCanvasGroup.gameObject.SetActive(true);
        if (win)
        {
            m_SceneToLoad = winSceneName;
            m_TimeLoadEndGameScene = Time.time + endSceneLoadDelay + delayBeforeFadeToBlack;

            // play a sound on win
            var audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = victorySound;
            audioSource.playOnAwake = false;
            audioSource.outputAudioMixerGroup = AudioUtility.GetAudioGroup(AudioUtility.AudioGroups.HUDVictory);
            audioSource.PlayScheduled(AudioSettings.dspTime + delayBeforeWinMessage);

            // create a game message
            winDisplayMessage.delayBeforeShowing = delayBeforeWinMessage;
            winDisplayMessage.gameObject.SetActive(true);
        }
        else
        {
            m_SceneToLoad = loseSceneName;
            m_TimeLoadEndGameScene = Time.time + endSceneLoadDelay + delayBeforeFadeToBlack;

            // create a game message
            loseDisplayMessage.delayBeforeShowing = delayBeforeWinMessage;
            loseDisplayMessage.gameObject.SetActive(true);
        }
        // Au lieu de relancer la scène d'intro, on retourne dans la scène World
        Invoke("ReturnToWorld", endSceneLoadDelay + delayBeforeFadeToBlack);
    }

    void ReturnToWorld()
    {
        SceneManager.LoadScene(worldSceneName);
        gameState = GameState.World;
    }


}
