using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
public class SelectPrefabsOfType : EditorWindow
{
    static ObjectPooler objectPooler;

    [MenuItem("Window/Utils/Collect Poolable Prefabs")]
    static void Init()
    {
        objectPooler = FindObjectOfType<ObjectPooler>();
        CollectPrefabs();
    }

    [MenuItem("Window/Utils/Clear Poolable Prefabs")]
    static void Clear()
    {
        objectPooler = FindObjectOfType<ObjectPooler>();
        objectPooler.Poolnfo.ClearPoolList();
    }

    static void CollectPrefabs()
    {
        objectPooler.Poolnfo.ClearPoolList();

        int collectedPrefabsCount = 0;

        string[] guids = AssetDatabase.FindAssets("t:prefab");

        foreach (var guid in guids)
        {
            string assetPath = AssetDatabase.GUIDToAssetPath(guid);
            var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(assetPath);

            var poolableObjectInfo = prefab.GetComponent<PoolableObjectInfo>();

            if (poolableObjectInfo)
            {
                if (poolableObjectInfo.size > 0)
                {
                    objectPooler.Poolnfo.AddItemToPoolList(new PoolInfoAsset
                    {
                        name = prefab.name,
                        prefab = prefab,
                        size = poolableObjectInfo.size
                    });

                    Debug.Log(prefab.name + " is collected!");
                }
                else
                {
                    Debug.LogError("CollectPrefabs() --> Zero sized pool: " + prefab.name);
                }
            }
        }

        EditorUtility.SetDirty(objectPooler.Poolnfo);       
    }
}