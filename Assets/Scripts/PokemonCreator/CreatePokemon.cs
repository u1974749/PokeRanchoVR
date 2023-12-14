using UnityEngine;
using UnityEditor;



//#if (UNITY_EDITOR)
public class CreatePokemon : MonoBehaviour
{
    [MenuItem("POKEMON/New Pokemon")]
    public static void CreateCustomPokemon()
    {
        var assetPath = "Assets/Prefab/Pokemon/NewPokemon.prefab";
        var source = new GameObject("Root");
        source.AddComponent<Animator>();
        source.tag = "pokemon";

        PrefabUtility.SaveAsPrefabAsset(source, assetPath);
        DestroyImmediate(source);
    }
}
//#endif