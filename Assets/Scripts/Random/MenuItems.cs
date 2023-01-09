using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using System.Linq;

public class MenuItems
{
    /* HotKeys Character Keys
        % means click/hold CTRL on Windows / CMD on OSX
        # means click/hold Shift
        & means click/hold Alt
        LEFT/RIGHT/UP/DOWN means click/hold Arrow keys
        F1…F2 means click/hold F keys
        HOME, END, PGUP, PGDN
        _ means click/hold Uppercase(Ex: _g = G)
    */
    // NOTE: Custom HotKeys could conflict with Unity's Default HotKeys

    private static Material cubeMaterial;

    // #m HotKey for "Instantiate Cube"
    [MenuItem("Window/Instantiate Cube #m")]
    private static void CreateCube()
    {
        if (!cubeMaterial)
        {
            cubeMaterial = Resources.Load("Materials/GreenCube") as Material;
        }

        UnityEngine.GameObject cube = UnityEngine.GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = RandomMonoScript.GetRandomVector3();
        cube.GetComponent<MeshRenderer>().material = cubeMaterial;
    }

    // _m HotKey for "PrintRandomInt"
    [MenuItem("Tools/Random/Get Random Integer _m")]
    private static void PrintRandomInt()
    {
        Debug.Log("Your number is " + Random.Range(0, 100));
    }

    // HotKey, %&m means CTRL+ALT+m / CMD+option+m
    [MenuItem("Tools/Random/Get Random Vector3 %&m")]
    private static void PrintRandomVector3()
    {
        Debug.Log("Vector: " + RandomMonoScript.GetRandomVector3());
    }

    // Add a new menu item that is accessed by right-clicking on an asset in the project view
    [MenuItem("Assets/Load Additive Scene")]
    private static void LoadAdditiveScene()
    {
        var selected = Selection.activeObject; // Selected item in "Project" tab
        EditorSceneManager.OpenScene(AssetDatabase.GetAssetPath(selected));
    }

    // Adding a new menu item under Assets/Create
    private static int materialCount = 1;
    [MenuItem("Assets/Create/Add Random Material")]
    private static void AddRandomMat()
    {
        Material material = new Material(Shader.Find("Standard"));
        material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);
        material.name = "Random Material " + materialCount;
        materialCount++;

        AssetDatabase.CreateAsset(material, AssetDatabase.GetAssetPath(Selection.activeObject) + "/" + material.name + ".mat");
        Debug.Log(material.name + " is created at: " + AssetDatabase.GetAssetPath(Selection.activeObject) + "/");
    }

    // Set new component options for "RandomMonoScript" component, MenuCommand is selected component in "Inspector" tab
    [MenuItem("CONTEXT/RandomMonoScript/Set Random Number")]
    private static void SetRandomNum(MenuCommand command)
    {
        RandomMonoScript randomMonoScript = (RandomMonoScript)command.context;
        randomMonoScript.number = Random.Range(0f, 1000f);
    }

    //Validation, first function is non-validated for option and second function is validated
    //ADVICE: Disable second function to see the difference
    [MenuItem("Assets/Get Object Name")]
    private static void PrintObjName()
    {
        Debug.Log(Selection.activeObject.name);
    }

    [MenuItem("Assets/Get Object Name", true)]
    private static void PrintPrefabObjName()
    {
        if (Selection.activeObject.GetType() == typeof(GameObject)) //if Selection.activeObject is a prefab
        {
            Debug.Log("PREFAB: " + Selection.activeObject.name);
        }
    }

    [MenuItem("SceneInfo/Get Scene Name", false, 1)]
    private static void SceneInfoOption()
    {
        Debug.Log("Scene Name: " + EditorSceneManager.GetActiveScene().name);
    }

    [MenuItem("SceneInfo/Get Cube Count", false, 2)]
    private static void SceneInfoOption2()
    {
        MeshFilter[] meshFilters = GameObject.FindObjectsOfType<MeshFilter>().Where(meshFilter => meshFilter.sharedMesh.name == "Cube").ToArray();
        Debug.Log("Cube Count: " + meshFilters.Length);
    }
}