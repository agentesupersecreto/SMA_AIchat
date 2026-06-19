using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Props
{
	// Token: 0x02000149 RID: 329
	public class GrabbableDefinedProp : GrabbableProp, IDefinedProp
	{
		// Token: 0x17000142 RID: 322
		// (get) Token: 0x06000677 RID: 1655 RVA: 0x00023960 File Offset: 0x00021B60
		TipoDeProp IDefinedProp.tipo
		{
			get
			{
				return this.m_tipoDeProrp;
			}
		}

		// Token: 0x04000530 RID: 1328
		[Header("Tipo De Prop")]
		[SerializeField]
		protected TipoDeProp m_tipoDeProrp;
	}
}
