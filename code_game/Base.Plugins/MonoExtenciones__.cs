using System;
using System.Collections.Generic;
using Assets;
using UnityEngine;

// Token: 0x02000033 RID: 51
public static class MonoExtenciones__
{
	// Token: 0x060001D7 RID: 471 RVA: 0x0000A691 File Offset: 0x00008891
	public static void GetComponentEnRoot<T>(this Object target, ref T reference, bool includeInactive = false)
	{
		reference = target.GetComponentEnRoot(includeInactive);
	}

	// Token: 0x060001D8 RID: 472 RVA: 0x0000A6A0 File Offset: 0x000088A0
	public static T GetComponentEnRoot<T>(this Object target, bool includeInactive = false)
	{
		if (target == null)
		{
			return default(T);
		}
		Component component = target as Component;
		if (component == null)
		{
			return default(T);
		}
		return component.GetComponentEnRoot(includeInactive);
	}

	// Token: 0x060001D9 RID: 473 RVA: 0x0000A6E4 File Offset: 0x000088E4
	public static T GetComponentEnRoot<T>(this Component mono, out ICharacterRoot parent, bool includeInactive = false)
	{
		parent = mono.GetComponentInParent<ICharacterRoot>();
		if (parent == null)
		{
			return default(T);
		}
		return parent.GetComponentInChildren<T>(includeInactive);
	}

	// Token: 0x060001DA RID: 474 RVA: 0x0000A710 File Offset: 0x00008910
	public static T GetComponentEnRoot<T>(this Component mono, bool includeInactive = false)
	{
		Component component = mono.GetComponentInParent<ICharacterRoot>() as Component;
		if (component == null)
		{
			component = mono.transform.root;
		}
		return component.GetComponentInChildren<T>(includeInactive);
	}

	// Token: 0x060001DB RID: 475 RVA: 0x0000A748 File Offset: 0x00008948
	public static T[] GetComponentsEnRoot<T>(this Component mono, bool includeInactive = false)
	{
		Component component = mono.GetComponentInParent<ICharacterRoot>() as Component;
		if (component == null)
		{
			component = mono.transform.root;
		}
		return component.GetComponentsInChildren<T>(includeInactive);
	}

	// Token: 0x060001DC RID: 476 RVA: 0x0000A780 File Offset: 0x00008980
	public static void GetComponentsEnRoot<T>(this Component mono, List<T> result, bool includeInactive = false)
	{
		Component component = mono.GetComponentInParent<ICharacterRoot>() as Component;
		if (component == null)
		{
			component = mono.transform.root;
		}
		component.GetComponentsInChildren<T>(includeInactive, result);
	}

	// Token: 0x060001DD RID: 477 RVA: 0x0000A7B6 File Offset: 0x000089B6
	public static void GetComponentsEnRoot<T>(this Component mono, out ICharacterRoot parent, bool includeInactive, List<T> result)
	{
		parent = mono.GetComponentInParent<ICharacterRoot>();
		if (parent == null)
		{
			return;
		}
		parent.GetComponentsInChildren<T>(includeInactive, result);
	}

	// Token: 0x060001DE RID: 478 RVA: 0x0000A7D0 File Offset: 0x000089D0
	public static void GetComponentsEnRoot<T>(this Component mono, bool includeInactive, List<T> result)
	{
		Component component = mono.GetComponentInParent<ICharacterRoot>() as Component;
		if (component == null)
		{
			component = mono.transform.root;
		}
		component.GetComponentsInChildren<T>(includeInactive, result);
	}

	// Token: 0x060001DF RID: 479 RVA: 0x0000A808 File Offset: 0x00008A08
	public static ICharacterRoot GetRoot(this Component mono)
	{
		ICharacterRoot componentInParent = mono.GetComponentInParent<ICharacterRoot>();
		if (componentInParent == null)
		{
			return null;
		}
		return componentInParent;
	}

	// Token: 0x060001E0 RID: 480 RVA: 0x0000A824 File Offset: 0x00008A24
	public static T GetComponentEn<TParent, T>(this Component mono, out TParent parent, bool includeInactive = false) where TParent : ICharacterRoot
	{
		parent = mono.GetComponentInParent<TParent>();
		if (parent == null)
		{
			Debug.LogWarning("Error ahead: no existe Root de typo: " + typeof(TParent).Name + ". se devolvera null.", mono);
			return default(T);
		}
		return parent.GetComponentInChildren<T>(includeInactive);
	}

	// Token: 0x060001E1 RID: 481 RVA: 0x0000A888 File Offset: 0x00008A88
	public static T GetComponentEn<TParent, T>(this Component mono, bool includeInactive = false) where TParent : ICharacterRoot
	{
		TParent tparent;
		return mono.GetComponentEn(out tparent, includeInactive);
	}
}
