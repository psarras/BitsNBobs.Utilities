using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EnumeratorExtension
{
    public static IEnumerator Delay(this IEnumerator another, float seconds = 0.1f)
    {
        yield return new WaitForSeconds(seconds);
        yield return another;
    }

    public static IEnumerator AddAfter(this IEnumerator another, IEnumerator after)
    {
        yield return another;
        yield return after;
    }
    
    public static IEnumerator AddAfter(this IEnumerator another, Action action)
    {
        yield return another;
        action();
    }
    
    public static IEnumerator AddBefore(this IEnumerator another, IEnumerator before)
    {
        yield return before;
        yield return another;
    }
}
