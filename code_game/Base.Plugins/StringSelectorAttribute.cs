using System;
using System.Collections;
using System.Reflection;
using UnityEngine;

// Token: 0x02000043 RID: 67
public class StringSelectorAttribute : PropertyAttribute
{
	// Token: 0x0600023F RID: 575 RVA: 0x0000BFC8 File Offset: 0x0000A1C8
	public StringSelectorAttribute(Type contenerdor, string staticPropertyName, string overrideLabel)
	{
		if (overrideLabel == null)
		{
			throw new ArgumentNullException("overrideLabel", "overrideLabel null reference.");
		}
		if (string.IsNullOrEmpty(staticPropertyName))
		{
			throw new ArgumentNullException("  staticPropertyName", "  staticPropertyName null reference.");
		}
		if (contenerdor == null)
		{
			throw new ArgumentNullException("contenerdor", "contenerdor null reference.");
		}
		this.m_contenerdor = contenerdor;
		this.m_stringSelectorPropiedadName = staticPropertyName;
		this.overridenLabel = overrideLabel;
	}

	// Token: 0x06000240 RID: 576 RVA: 0x0000C034 File Offset: 0x0000A234
	public StringSelectorAttribute(Type contenerdor, string staticPropertyName)
	{
		if (string.IsNullOrEmpty(staticPropertyName))
		{
			throw new ArgumentNullException("  staticPropertyName", "  staticPropertyName null reference.");
		}
		if (contenerdor == null)
		{
			throw new ArgumentNullException("contenerdor", "contenerdor null reference.");
		}
		this.m_contenerdor = contenerdor;
		this.m_stringSelectorPropiedadName = staticPropertyName;
	}

	// Token: 0x06000241 RID: 577 RVA: 0x0000C086 File Offset: 0x0000A286
	public StringSelectorAttribute(Type contenerdor, string staticPropertyName, bool aplicarEnRunTime)
		: this(contenerdor, staticPropertyName)
	{
		this.aplicarEnRunTime = aplicarEnRunTime;
	}

	// Token: 0x1700002F RID: 47
	// (get) Token: 0x06000242 RID: 578 RVA: 0x0000C097 File Offset: 0x0000A297
	public string rutaCompleta
	{
		get
		{
			return this.m_contenerdor.FullName + "." + this.m_stringSelectorPropiedadName;
		}
	}

	// Token: 0x06000243 RID: 579 RVA: 0x0000C0B4 File Offset: 0x0000A2B4
	public IList ObtenerLista()
	{
		if (string.IsNullOrEmpty(this.m_stringSelectorPropiedadName))
		{
			throw new ArgumentNullException("m_stringSelectorPropiedadName", "m_stringSelectorPropiedadName null reference.");
		}
		if (this.m_contenerdor == null)
		{
			throw new ArgumentNullException("contenerdor", "contenerdor null reference.");
		}
		PropertyInfo property = this.m_contenerdor.GetProperty(this.m_stringSelectorPropiedadName, BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy);
		if (property == null)
		{
			throw new ArgumentNullException("propiedad", string.Concat(new string[]
			{
				"propiedad de nombre: ",
				this.m_stringSelectorPropiedadName,
				" de Tipo: ",
				this.m_contenerdor.Name,
				" null reference."
			}));
		}
		object value;
		try
		{
			value = property.GetValue(null, null);
		}
		catch (Exception ex)
		{
			throw ex;
		}
		if (value == null)
		{
			throw new ArgumentNullException("valorDeLaPropiedad", string.Concat(new string[]
			{
				"valorDeLaPropiedad de nombre: ",
				this.m_stringSelectorPropiedadName,
				" de Tipo: ",
				this.m_contenerdor.Name,
				" null reference."
			}));
		}
		IList list = value as IList;
		if (list == null)
		{
			throw new ArgumentNullException("lista", string.Concat(new string[]
			{
				"Propiedad: ",
				this.m_stringSelectorPropiedadName,
				" de Tipo: ",
				this.m_contenerdor.Name,
				" no es de tipo lista."
			}));
		}
		return list;
	}

	// Token: 0x06000244 RID: 580 RVA: 0x0000C214 File Offset: 0x0000A414
	public bool TryObtenerLista(out IList lista, out string error)
	{
		bool flag;
		try
		{
			lista = this.ObtenerLista();
			error = null;
			flag = true;
		}
		catch (Exception ex)
		{
			lista = null;
			error = ex.Message;
			flag = false;
		}
		return flag;
	}

	// Token: 0x04000078 RID: 120
	private Type m_contenerdor;

	// Token: 0x04000079 RID: 121
	private string m_stringSelectorPropiedadName;

	// Token: 0x0400007A RID: 122
	public readonly bool aplicarEnRunTime;

	// Token: 0x0400007B RID: 123
	public readonly string overridenLabel;
}
