using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Factory<T> where T : Object
{
    public abstract GameObject GetInstance(T data);
}
