using System;
using System.Collections.Generic;
using System.Text;
using Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Economia.Agencias.Interpretaciones
{
	// Token: 0x020000F9 RID: 249
	public abstract class RequerimientoGenetico<Tenum> : AgenciaBase.IRequerimiento where Tenum : Enum, IConvertible
	{
		// Token: 0x0600086C RID: 2156 RVA: 0x00030428 File Offset: 0x0002E628
		public RequerimientoGenetico(string field, params Tenum[] aceptables)
		{
			if (string.IsNullOrWhiteSpace(field))
			{
				throw new InvalidOperationException();
			}
			if (aceptables == null || aceptables.Length == 0)
			{
				throw new InvalidOperationException();
			}
			foreach (Tenum tenum in aceptables)
			{
				this.m_condiciones.Add(tenum);
				this.m_condicionesValores.Add(tenum.ToInt32(null));
			}
			this.m_field = field;
		}

		// Token: 0x0600086D RID: 2157 RVA: 0x000304B4 File Offset: 0x0002E6B4
		public string DescripcionLocalizada(string localizacion)
		{
			StringBuilder stringBuilder = new StringBuilder();
			string text = this.ObtenerLocalizadoDeField(localizacion);
			stringBuilder.Append(text);
			stringBuilder.Append(':');
			stringBuilder.Append(' ');
			for (int i = 0; i < this.m_condiciones.Count; i++)
			{
				string text2 = TextoLocalizadoAttribute.Localizado<Tenum>(this.m_condiciones[i], localizacion);
				stringBuilder.Append(text2.FirstLetterToUpperCaseOthersToLower());
				if (!i.IsLastIndex(this.m_condiciones.Count))
				{
					stringBuilder.Append(',');
					stringBuilder.Append(' ');
				}
			}
			return stringBuilder.ToString();
		}

		// Token: 0x0600086E RID: 2158
		public abstract bool Cumplido(ref IIntrepretacion postulantePersonalidad, ref IIntrepretacion postulanteApariencia);

		// Token: 0x0600086F RID: 2159
		protected abstract string ObtenerLocalizadoDeField(string localizacion);

		// Token: 0x040004B9 RID: 1209
		[SerializeField]
		[ReadOnlyUI]
		protected string m_field;

		// Token: 0x040004BA RID: 1210
		[SerializeField]
		protected SerializableEnumHashSetListSlow<Tenum> m_condiciones = new SerializableEnumHashSetListSlow<Tenum>();

		// Token: 0x040004BB RID: 1211
		protected HashSet<int> m_condicionesValores = new HashSet<int>();
	}
}
