using UnityEngine;
using UnityEditor;
using UnityEngine.AI;



//#if (UNITY_EDITOR)
public class CreatePokemon : MonoBehaviour
{
    [MenuItem("POKEMON/New Pokemon")]
    public static void CreateCustomPokemon()
    {
        var assetPath = "Assets/Prefab/Pokemon/NewPokemon.prefab";
        var source = new GameObject("Root");
        source.AddComponent<Animator>();
        source.AddComponent<NavMeshAgent>();
        PokemonMovement script = source.AddComponent<PokemonMovement>();
        script.speed = 3;
        script.walkRadius = 15;
        source.tag = "pokemon";

        PrefabUtility.SaveAsPrefabAsset(source, assetPath);
        DestroyImmediate(source);
    }
}
//#endif