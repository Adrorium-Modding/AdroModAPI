using System;
using System.Collections.Generic;

namespace AdroModdingApi.Util;

public static class DictUtil
{
    public static V GetOrCreate<K, V>(this IDictionary<K, V> dict, K key, Func<V> createNew)
    {
        if (!dict.TryGetValue(key, out var val))
        {
            val = createNew();
            dict.Add(key, val);
        }

        return val;
    }
}
