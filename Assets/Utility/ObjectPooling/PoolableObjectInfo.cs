using UnityEngine;

public class PoolableObjectInfo : MonoBehaviour
{
    public int size;

    public void Destroy()
    {
        ObjectPooler.Instance.ReturnToPool(gameObject.name, gameObject);
    }
}
