using System;
using UnityEngine;

// Token: 0x0200003E RID: 62
public class EnumIDAttribute : PropertyAttribute
{
	// Token: 0x0600022C RID: 556 RVA: 0x0000BC9E File Offset: 0x00009E9E
	public static long Componer(int a, int b)
	{
		return ((long)a << 32) + (long)b;
	}

	// Token: 0x0600022D RID: 557 RVA: 0x0000BCA8 File Offset: 0x00009EA8
	public static void Descomponer(long compuesto, out int a, out int b)
	{
		b = (int)compuesto;
		a = (int)(compuesto - (long)b >> 32);
	}

	// Token: 0x0600022E RID: 558 RVA: 0x0000BCBC File Offset: 0x00009EBC
	public static bool EsConpuestoDeA(long compuesto, int a)
	{
		int num = (int)compuesto;
		int num2 = (int)(compuesto - (long)num >> 32);
		return a == num2;
	}

	// Token: 0x0600022F RID: 559 RVA: 0x0000BCDC File Offset: 0x00009EDC
	public static bool EsConpuestoDeB(long compuesto, int b)
	{
		int num = (int)compuesto;
		return b == num;
	}

	// Token: 0x06000230 RID: 560 RVA: 0x0000BCF0 File Offset: 0x00009EF0
	public EnumIDAttribute(Type EnumType)
	{
		this.enumType = EnumType;
		if (EnumType == null)
		{
			throw new ArgumentNullException("EnumType", "EnumType null reference.");
		}
	}

	// Token: 0x06000231 RID: 561 RVA: 0x0000BD18 File Offset: 0x00009F18
	public EnumIDAttribute(Type EnumType, Type EnumTypeSegnudario)
		: this(EnumType)
	{
		this.enumTypeSegnudario = EnumTypeSegnudario;
		if (EnumTypeSegnudario == null)
		{
			throw new ArgumentNullException("EnumTypeSegnudario", "EnumTypeSegnudario null reference.");
		}
	}

	// Token: 0x0400006E RID: 110
	public Type enumType;

	// Token: 0x0400006F RID: 111
	public Type enumTypeSegnudario;
}
