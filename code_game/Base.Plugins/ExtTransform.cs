using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// Token: 0x02000035 RID: 53
public static class ExtTransform
{
	// Token: 0x060001E3 RID: 483 RVA: 0x0000A8C8 File Offset: 0x00008AC8
	public static void InstantiateChildrenOfType<T>(this Transform prefab, List<T> instanciados, Predicate<T> shouldInstantiate = null, Transform instanciadosParent = null) where T : Component
	{
		if (instanciados.Count > 0)
		{
			instanciados.Clear();
		}
		prefab.GetComponentsInChildren<T>(true, instanciados);
		for (int i = instanciados.Count - 1; i >= 0; i--)
		{
			T t = instanciados[i];
			if (shouldInstantiate != null && !shouldInstantiate(t))
			{
				instanciados.RemoveAt(i);
			}
			else
			{
				T t2 = Object.Instantiate<T>(t);
				t2.name = t.name;
				if (instanciadosParent != null)
				{
					Transform transform = t2.transform;
					transform.parent = instanciadosParent;
					transform.localPosition = Vector3.zero;
					transform.localRotation = Quaternion.identity;
					transform.localScale = Vector3.one;
				}
				instanciados[i] = t2;
			}
		}
	}

	// Token: 0x060001E4 RID: 484 RVA: 0x0000A984 File Offset: 0x00008B84
	public static void ExecDeepChild(this Transform some, Action<Transform> action, bool inclusive = true)
	{
		if (some == null)
		{
			throw new ArgumentNullException("some", "some null reference.");
		}
		if (action == null)
		{
			throw new ArgumentNullException("action", "action null reference.");
		}
		if (inclusive)
		{
			action(some);
		}
		foreach (object obj in some)
		{
			((Transform)obj).ExecDeepChild(action, true);
		}
	}

	// Token: 0x060001E5 RID: 485 RVA: 0x0000AA10 File Offset: 0x00008C10
	public static TComponent FindDeepChildComponent<TComponent>(this Transform some, bool ignoreSelfComponent)
	{
		return some.FindDeepChildComponent(ignoreSelfComponent, true);
	}

	// Token: 0x060001E6 RID: 486 RVA: 0x0000AA1C File Offset: 0x00008C1C
	public static TComponent[] FindDeepChildComponents<TComponent>(this Transform some, bool ignoreSelfComponent)
	{
		TComponent[] array = some.GetComponentsInChildren<TComponent>();
		if (ignoreSelfComponent)
		{
			array = array.Where((TComponent item) => (item as Component).transform != some).ToArray<TComponent>();
		}
		List<TComponent> list = new List<TComponent>();
		for (int i = array.Length - 1; i >= 0; i--)
		{
			TComponent tcomponent = array[i];
			Component component = tcomponent as Component;
			bool flag = false;
			for (int j = i - 1; j >= 0; j--)
			{
				Component component2 = array[j] as Component;
				if (component.transform.IsChildOf(component2.transform))
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				list.Add(tcomponent);
			}
		}
		return list.ToArray();
	}

	// Token: 0x060001E7 RID: 487 RVA: 0x0000AAE0 File Offset: 0x00008CE0
	private static TComponent FindDeepChildComponent<TComponent>(this Transform some, bool ignoreSelfComponent, bool esprimero)
	{
		if (some == null)
		{
			throw new ArgumentNullException("some", "some null reference.");
		}
		if ((esprimero && !ignoreSelfComponent) || !esprimero)
		{
			TComponent component = some.GetComponent<TComponent>();
			if (component != null)
			{
				return component;
			}
		}
		foreach (object obj in some)
		{
			TComponent tcomponent = ((Transform)obj).FindDeepChildComponent(ignoreSelfComponent, false);
			if (tcomponent != null)
			{
				return tcomponent;
			}
		}
		return default(TComponent);
	}

	// Token: 0x060001E8 RID: 488 RVA: 0x0000AB84 File Offset: 0x00008D84
	public static Transform FindDeepChild(this Transform some, string aName, bool printDebug = true)
	{
		if (some == null)
		{
			throw new ArgumentNullException("some", "some null reference.");
		}
		if (string.IsNullOrWhiteSpace(aName))
		{
			if (printDebug)
			{
				Debug.LogWarning("Tratando de buscar hijo con nombre null o empty en: " + some.name, some);
			}
			return null;
		}
		if (some.name == aName)
		{
			return some;
		}
		foreach (object obj in some)
		{
			Transform transform = ((Transform)obj).FindDeepChild(aName, false);
			if (transform != null)
			{
				return transform;
			}
		}
		return null;
	}

	// Token: 0x060001E9 RID: 489 RVA: 0x0000AC34 File Offset: 0x00008E34
	public static Transform FindDeepChildStartWith(this Transform some, string startWith, bool printDebug = true)
	{
		if (some == null)
		{
			throw new ArgumentNullException("some", "some null reference.");
		}
		if (string.IsNullOrWhiteSpace(startWith))
		{
			if (printDebug)
			{
				Debug.LogWarning("Tratando de buscar hijo con nombre null o empty en: " + some.name, some);
			}
			return null;
		}
		if (some.name.StartsWith(startWith, StringComparison.InvariantCultureIgnoreCase))
		{
			return some;
		}
		foreach (object obj in some)
		{
			Transform transform = ((Transform)obj).FindDeepChildStartWith(startWith, false);
			if (transform != null)
			{
				return transform;
			}
		}
		return null;
	}

	// Token: 0x060001EA RID: 490 RVA: 0x0000ACE8 File Offset: 0x00008EE8
	public static Transform FindDeepChildEndsWith(this Transform some, string endsWith, bool printDebug = true)
	{
		if (some == null)
		{
			throw new ArgumentNullException("some", "some null reference.");
		}
		if (string.IsNullOrWhiteSpace(endsWith))
		{
			if (printDebug)
			{
				Debug.LogWarning("Tratando de buscar hijo con nombre null o empty en: " + some.name, some);
			}
			return null;
		}
		if (some.name.EndsWith(endsWith, StringComparison.InvariantCultureIgnoreCase))
		{
			return some;
		}
		foreach (object obj in some)
		{
			Transform transform = ((Transform)obj).FindDeepChildEndsWith(endsWith, false);
			if (transform != null)
			{
				return transform;
			}
		}
		return null;
	}

	// Token: 0x060001EB RID: 491 RVA: 0x0000AD9C File Offset: 0x00008F9C
	public static Transform FindDeepChild(this Transform some, string aName, string bName, bool printDebug = true)
	{
		Transform transform = some.FindDeepChild(aName, printDebug);
		if (transform != null)
		{
			return transform;
		}
		return some.FindDeepChild(bName, printDebug);
	}

	// Token: 0x060001EC RID: 492 RVA: 0x0000ADC8 File Offset: 0x00008FC8
	public static Transform Copy(this Transform some, string name = null)
	{
		if (some == null)
		{
			throw new ArgumentNullException("some", "some null reference.");
		}
		Transform transform;
		if (string.IsNullOrEmpty(name))
		{
			transform = new GameObject(some.name + "_Copia").transform;
		}
		else
		{
			transform = new GameObject(name).transform;
		}
		transform.gameObject.layer = some.gameObject.layer;
		transform.parent = some.parent;
		transform.localPosition = some.localPosition;
		transform.localRotation = some.localRotation;
		transform.localScale = some.localScale;
		return transform;
	}

	// Token: 0x060001ED RID: 493 RVA: 0x0000AE68 File Offset: 0x00009068
	public static Transform Copy(this Transform some, Transform parent, string name = null)
	{
		if (some == null)
		{
			throw new ArgumentNullException("some", "some null reference.");
		}
		Transform transform = new GameObject().transform;
		transform.gameObject.layer = some.gameObject.layer;
		transform.parent = some.parent;
		transform.localPosition = some.localPosition;
		transform.localRotation = some.localRotation;
		transform.localScale = some.localScale;
		transform.parent = parent;
		if (string.IsNullOrEmpty(name))
		{
			transform.name = some.name + "_Copia";
		}
		else
		{
			transform.name = name;
		}
		return transform;
	}

	// Token: 0x060001EE RID: 494 RVA: 0x0000AF0E File Offset: 0x0000910E
	public static Transform GetSelfOrChildNotNull(this Transform some, string aName, bool heredarLayer = true)
	{
		if (some == null)
		{
			throw new ArgumentNullException("some", "some null reference.");
		}
		if (some.name == aName)
		{
			return some;
		}
		return some.GetChildNotNull(aName, heredarLayer);
	}

	// Token: 0x060001EF RID: 495 RVA: 0x0000AF44 File Offset: 0x00009144
	public static Transform GetChildNotNull(this Transform some, string aName, bool heredarLayer = true)
	{
		if (some == null)
		{
			throw new ArgumentNullException("some", "some null reference.");
		}
		Transform transform = some.Find(aName);
		if (transform != null)
		{
			return transform;
		}
		return some.CreateChild(aName, heredarLayer);
	}

	// Token: 0x060001F0 RID: 496 RVA: 0x0000AF85 File Offset: 0x00009185
	public static Transform CreateChild(this Transform some, string aName)
	{
		return some.CreateChild(aName, true);
	}

	// Token: 0x060001F1 RID: 497 RVA: 0x0000AF90 File Offset: 0x00009190
	public static void DestroyChild(this Transform some, string aName)
	{
		Transform transform = some.Find(aName);
		if (transform != null)
		{
			if (Application.isPlaying)
			{
				Object.Destroy(transform.gameObject);
				return;
			}
			Object.DestroyImmediate(transform.gameObject);
		}
	}

	// Token: 0x060001F2 RID: 498 RVA: 0x0000AFCC File Offset: 0x000091CC
	public static Transform CloneTransform(this Transform some, string aName = null, bool sameParent = false)
	{
		Transform transform2;
		try
		{
			GameObject gameObject = new GameObject((aName == null) ? some.name : aName);
			Transform transform = gameObject.transform;
			if (!sameParent)
			{
				transform.parent = null;
				transform.localScale = some.lossyScale;
			}
			else
			{
				transform.parent = some.parent;
				transform.localScale = some.localScale;
			}
			transform.SetPositionAndRotation(some.position, some.rotation);
			gameObject.layer = some.gameObject.layer;
			transform2 = transform;
		}
		catch (Exception ex)
		{
			throw ex;
		}
		return transform2;
	}

	// Token: 0x060001F3 RID: 499 RVA: 0x0000B05C File Offset: 0x0000925C
	public static Transform CreateChild(this Transform some, string aName, bool heredarLayer)
	{
		Transform transform2;
		try
		{
			if (some == null)
			{
				throw new ArgumentNullException("some", "some null reference.");
			}
			GameObject gameObject = new GameObject(aName);
			Transform transform = gameObject.transform;
			transform.parent = some;
			transform.localPosition = Vector3.zero;
			transform.localRotation = Quaternion.identity;
			transform.localScale = Vector3.one;
			if (heredarLayer)
			{
				gameObject.layer = some.gameObject.layer;
			}
			transform2 = transform;
		}
		catch (Exception ex)
		{
			throw ex;
		}
		return transform2;
	}

	// Token: 0x060001F4 RID: 500 RVA: 0x0000B0E0 File Offset: 0x000092E0
	public static void CopyPositionRotation(this Transform some, Transform source)
	{
		if (some == null)
		{
			throw new ArgumentNullException("some", "some null reference.");
		}
		if (source == null)
		{
			throw new ArgumentNullException("source", "source null reference.");
		}
		some.position = source.position;
		some.rotation = source.rotation;
	}

	// Token: 0x060001F5 RID: 501 RVA: 0x0000B138 File Offset: 0x00009338
	public static Transform FindChildNotNull(this Transform some, string aName)
	{
		if (some == null)
		{
			throw new ArgumentNullException("some", "some null reference.");
		}
		Transform transform = some.Find(aName);
		if (transform == null)
		{
			transform = some.CreateChild(aName);
		}
		return transform;
	}

	// Token: 0x060001F6 RID: 502 RVA: 0x0000B178 File Offset: 0x00009378
	public static Transform FindDeepParent(this Transform some, string aName)
	{
		if (some.name == aName)
		{
			return some;
		}
		if (some.parent != null)
		{
			return some.parent.FindDeepParent(aName);
		}
		return null;
	}

	// Token: 0x060001F7 RID: 503 RVA: 0x0000B1A6 File Offset: 0x000093A6
	public static Transform FindDeepParentBy(this Transform some, Func<Transform, bool> predicate)
	{
		if (predicate(some))
		{
			return some;
		}
		if (some.parent != null)
		{
			return some.parent.FindDeepParentBy(predicate);
		}
		return null;
	}

	// Token: 0x060001F8 RID: 504 RVA: 0x0000B1D0 File Offset: 0x000093D0
	public static Transform FindDeepParentByName(this Transform some, string contains)
	{
		return some.FindDeepParentBy((Transform t) => t.name.IndexOf(contains, StringComparison.InvariantCultureIgnoreCase) >= 0);
	}
}
