using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public static class Global
{
    [NonSerialized] private static Dictionary<Type, object> globalRuntimeData;
    [NonSerialized] private static Dictionary<Type, object> globalRuntimeEvents;

    private static List<Type> GetAllSealedNotAbstractSubclasOfTypes(Type baseClass)
    {
        List<Type> allSubTypes = new List<Type>();
        foreach (var assem in AppDomain.CurrentDomain.GetAssemblies())
        {
            IEnumerable<Type> subTypes = assem.GetTypes().Where(c => c.IsSubclassOf(baseClass));
            allSubTypes.AddRange(subTypes);
        }

        return allSubTypes;
    }

    private static void PrepareGlobalRuntimeData()
    {
        globalRuntimeData = new Dictionary<Type, object>();

        List<Type> allSubTypes = GetAllSealedNotAbstractSubclasOfTypes(typeof(BaseGlobalRuntimeData));

        foreach (var type in allSubTypes)
        {
            object instance = Activator.CreateInstance(type);
            globalRuntimeData.Add(type, instance);
        }
    }

    private static void PrepareGlobalRuntimeEvents()
    {
        globalRuntimeEvents = new Dictionary<Type, object>();

        List<Type> allSubTypes = GetAllSealedNotAbstractSubclasOfTypes(typeof(BaseGlobalRuntimeEvents));

        foreach (var type in allSubTypes)
        {
            object instance = Activator.CreateInstance(type);
            globalRuntimeEvents.Add(type, instance);
        }
    }

    public static T RD<T>() where T : BaseGlobalRuntimeData
    {
        if (!UnityEngine.Application.isPlaying) return null;
        if (globalRuntimeData == null)
        {
            PrepareGlobalRuntimeData();
        }

        object instance;
        globalRuntimeData.TryGetValue(typeof(T), out instance);
        return instance as T;
    }

    public static T RE<T>() where T : BaseGlobalRuntimeEvents
    {
        if (!UnityEngine.Application.isPlaying) return null;
        if (globalRuntimeEvents == null)
        {
            PrepareGlobalRuntimeEvents();
        }

        object instance;
        globalRuntimeEvents.TryGetValue(typeof(T), out instance);
        return instance as T;
    }
}

public abstract class BaseGlobalRuntimeEvents
{

}

[DefaultExecutionOrder(int.MaxValue)]
public abstract class BaseGlobalRuntimeData
{
}