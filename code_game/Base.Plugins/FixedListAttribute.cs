using System;
using System.Collections;
using System.Reflection;
using UnityEngine;

// Token: 0x0200003F RID: 63
public class FixedListAttribute : PropertyAttribute
{
	// Token: 0x06000232 RID: 562 RVA: 0x0000BD44 File Offset: 0x00009F44
	public FixedListAttribute(Type contenerdor, string propiedadConItems, string namesField, string dataField)
	{
		if (string.IsNullOrEmpty(propiedadConItems))
		{
			throw new ArgumentNullException("  staticPropertyName", "  staticPropertyName null reference.");
		}
		if (contenerdor == null)
		{
			throw new ArgumentNullException("contenerdor", "contenerdor null reference.");
		}
		this.m_contenerdor = contenerdor;
		this.m_stringSelectorPropiedadName = propiedadConItems;
		this.m_namesField = namesField;
		this.m_dataField = dataField;
	}

	// Token: 0x17000029 RID: 41
	// (get) Token: 0x06000233 RID: 563 RVA: 0x0000BDA5 File Offset: 0x00009FA5
	public string namesField
	{
		get
		{
			return this.m_namesField;
		}
	}

	// Token: 0x1700002A RID: 42
	// (get) Token: 0x06000234 RID: 564 RVA: 0x0000BDAD File Offset: 0x00009FAD
	public string dataField
	{
		get
		{
			return this.m_dataField;
		}
	}

	// Token: 0x1700002B RID: 43
	// (get) Token: 0x06000235 RID: 565 RVA: 0x0000BDB5 File Offset: 0x00009FB5
	public string rutaCompleta
	{
		get
		{
			return this.m_contenerdor.FullName + "." + this.m_stringSelectorPropiedadName;
		}
	}

	// Token: 0x06000236 RID: 566 RVA: 0x0000BDD4 File Offset: 0x00009FD4
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

	// Token: 0x06000237 RID: 567 RVA: 0x0000BF34 File Offset: 0x0000A134
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

	// Token: 0x04000070 RID: 112
	private Type m_contenerdor;

	// Token: 0x04000071 RID: 113
	private string m_stringSelectorPropiedadName;

	// Token: 0x04000072 RID: 114
	private string m_namesField;

	// Token: 0x04000073 RID: 115
	private string m_dataField;
}
