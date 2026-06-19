using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Diccionarios
{
	// Token: 0x0200037C RID: 892
	[CreateAssetMenu(fileName = "DiccionarioDeReaccionGeneric", menuName = "Objetos/Diccionarios/Diccionario De Reaccion Generic")]
	public class DiccionarioDeReaccionGeneric : DiccionarioDeReaccionBase<DiccionarioDeReaccionGeneric.LineaDeTexto>
	{
		// Token: 0x170004DB RID: 1243
		// (get) Token: 0x0600135A RID: 4954 RVA: 0x00053A99 File Offset: 0x00051C99
		// (set) Token: 0x0600135B RID: 4955 RVA: 0x00053AA1 File Offset: 0x00051CA1
		public override List<DiccionarioDeReaccionGeneric.LineaDeTexto> lineasDeTexto
		{
			get
			{
				return this.lineas;
			}
			protected set
			{
				this.lineas = value;
			}
		}

		// Token: 0x0600135C RID: 4956 RVA: 0x00053AAA File Offset: 0x00051CAA
		protected override DiccionarioDeReaccionGeneric.LineaDeTexto ObtenerNuevaInstancia(string text)
		{
			return new DiccionarioDeReaccionGeneric.LineaDeTexto(text);
		}

		// Token: 0x0600135D RID: 4957 RVA: 0x00053AB4 File Offset: 0x00051CB4
		public static string Obtener(List<DiccionarioDeReaccionGeneric> others)
		{
			DiccionarioDeReaccionGeneric.LineaDeTexto lineaDeTexto = null;
			float minValue = float.MinValue;
			for (int i = 0; i < others.Count; i++)
			{
				DiccionarioDeReaccionGeneric.Obtener(others[i], ref lineaDeTexto, ref minValue);
			}
			if (lineaDeTexto != null)
			{
				return lineaDeTexto.texto;
			}
			return null;
		}

		// Token: 0x0600135E RID: 4958 RVA: 0x00053AF8 File Offset: 0x00051CF8
		public string Obtener(float nivel)
		{
			DiccionarioDeReaccionGeneric.LineaDeTexto lineaDeTexto = null;
			float minValue = float.MinValue;
			DiccionarioDeReaccionGeneric.Obtener(this, ref lineaDeTexto, ref minValue);
			if (lineaDeTexto != null)
			{
				return lineaDeTexto.texto;
			}
			return null;
		}

		// Token: 0x0600135F RID: 4959 RVA: 0x00053B24 File Offset: 0x00051D24
		private static void Obtener(DiccionarioDeReaccionGeneric dic, ref DiccionarioDeReaccionGeneric.LineaDeTexto max, ref float maxScore)
		{
			for (int i = 0; i < dic.lineas.Count; i++)
			{
				DiccionarioDeReaccionGeneric.LineaDeTexto lineaDeTexto = dic.lineas[i];
				float num = lineaDeTexto.Score();
				if (num > maxScore)
				{
					maxScore = num;
					max = lineaDeTexto;
				}
			}
		}

		// Token: 0x0400101E RID: 4126
		[CoolArrayItem]
		public List<DiccionarioDeReaccionGeneric.LineaDeTexto> lineas = new List<DiccionarioDeReaccionGeneric.LineaDeTexto>();

		// Token: 0x0200037D RID: 893
		[Serializable]
		public class LineaDeTexto : DiccionarioDeReaccionBase.LineaDeTextoBase
		{
			// Token: 0x06001361 RID: 4961 RVA: 0x00053B79 File Offset: 0x00051D79
			public LineaDeTexto(string text)
				: base(text)
			{
			}
		}
	}
}
