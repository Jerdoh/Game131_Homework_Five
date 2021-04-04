using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Types;

public class EnemyDesignerWindow : EditorWindow
{
    Texture2D headerSectionTexture;
    Texture2D mageSectionTexture;
    Texture2D rogueSectionTexture;
    Texture2D warriorSectionTexture;

    Color headerSectionColor = new Color(13f/255f, 32f/255f, 44f/255f);

    Rect headerSection;
    Rect mageSection;
    Rect rogueSection;
    Rect warriorSection;

    static MageData mageData;
    static RogueData rogueData;
    static WarriorData warriorData;

    public static MageData MageInfo { get { return mageData; } }
    public static RogueData RogueInfo { get { return rogueData; } }
    public static WarriorData WarriorInfo { get { return warriorData; } }

    [MenuItem("Window/Enemy Designer")]
    static void OpenWindow()
    {
        EnemyDesignerWindow window = (EnemyDesignerWindow)GetWindow(typeof(EnemyDesignerWindow));
        window.minSize = new Vector2(600,300);
        window.Show();
    }

    /// <summary>
    /// Similar to Start() or Awake()
    /// </summary>
    void OnEnable()
    {
        InitTextures();
        InitData();
    }

    public static void InitData()
    {
        mageData = (MageData)ScriptableObject.CreateInstance(typeof(MageData));
        rogueData = (RogueData)ScriptableObject.CreateInstance(typeof(RogueData));
        warriorData = (WarriorData)ScriptableObject.CreateInstance(typeof(WarriorData));
    }

    /// <summary>
    /// Initialize Texture2D values
    /// </summary>
    void InitTextures()
    {
        headerSectionTexture = new Texture2D(1,1);
        headerSectionTexture.SetPixel(0, 0, headerSectionColor);
        headerSectionTexture.Apply();

        mageSectionTexture = Resources.Load<Texture2D>("Icons/editor_mage_gradient");
        rogueSectionTexture = Resources.Load<Texture2D>("Icons/editor_rogue_gradient");
        warriorSectionTexture = Resources.Load<Texture2D>("Icons/editor_warrior_gradient");
    }

    /// <summary>
    /// Similar to any Update function,
    /// Not called once per fram. Called 1 or more time per interaction.
    /// </summary>
    void OnGUI()
    {
        DrawLayouts();
        DrawHeader();
        DrawMageSettings();
        DrawRogueSettings();
        DrawWarriorSettings();
    }

    /// <summary>
    /// Defines Rect values and paints textures base on Rects
    /// </summary>
    void DrawLayouts()
    {
        headerSection.x = 0;
        headerSection.y = 0;
        headerSection.width = position.width;
        headerSection.height = 50;

        mageSection.x = 0;
        mageSection.y = 50;
        mageSection.width = position.width / 3f;
        mageSection.height = position.height - 50;

        rogueSection.x = position.width / 3f * 2;
        rogueSection.y = 50;
        rogueSection.width = position.width / 3f;
        rogueSection.height = position.height - 50;

        warriorSection.x = position.width / 3f;
        warriorSection.y = 50;
        warriorSection.width = position.width / 3f ;
        warriorSection.height = position.height - 50;

        GUI.DrawTexture(headerSection, headerSectionTexture);
        GUI.DrawTexture(mageSection, mageSectionTexture);
        GUI.DrawTexture(rogueSection, rogueSectionTexture);
        GUI.DrawTexture(warriorSection, warriorSectionTexture);
    }

    /// <summary>
    /// Draw contents of header
    /// </summary>
    void DrawHeader()
    {
        GUILayout.BeginArea(headerSection);
        GUILayout.Label("Enemy Designer");
        GUILayout.EndArea();
    }

    /// <summary>
    /// Draw contents of mage region
    /// </summary>
    void DrawMageSettings()
    {
        GUILayout.BeginArea(mageSection);
        GUILayout.Label("Mage");

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Damage");
        mageData.dmgType = (MageDmgType)EditorGUILayout.EnumPopup(mageData.dmgType);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Weapon");
        mageData.wpnType = (MageWpnType)EditorGUILayout.EnumPopup(mageData.wpnType);
        EditorGUILayout.EndHorizontal();

        GUILayout.EndArea();
    }

    /// <summary>
    /// Draw contents of rogue region
    /// </summary>
    void DrawRogueSettings()
    {
        GUILayout.BeginArea(rogueSection);
        GUILayout.Label("Rogue");

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Strategy");
        rogueData.strategyType = (RogueStrategyType)EditorGUILayout.EnumPopup(rogueData.strategyType);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Weapon");
        rogueData.wpnType = (RogueWpnType)EditorGUILayout.EnumPopup(rogueData.wpnType);
        EditorGUILayout.EndHorizontal();

        GUILayout.EndArea();
    }

    /// <summary>
    /// Draw contents of warrior region
    /// </summary>
    void DrawWarriorSettings()
    {
        GUILayout.BeginArea(warriorSection);
        GUILayout.Label("Warrior");

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Class");
        warriorData.classType = (WarriorClassType)EditorGUILayout.EnumPopup(warriorData.classType);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Weapon");
        warriorData.wpnType = (WarriorWpnType)EditorGUILayout.EnumPopup(warriorData.wpnType);
        EditorGUILayout.EndHorizontal();

        GUILayout.EndArea();
    }
}
