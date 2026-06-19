using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Diccionarios
{
	// Token: 0x02000375 RID: 885
	[CreateAssetMenu(fileName = "DiccionarioDeReaccion", menuName = "Objetos/Diccionarios/Diccionario De Reaccion")]
	public class DiccionarioDeReaccion : DiccionarioDeReaccionBase<DiccionarioDeReaccion.LineaDeTexto>
	{
		// Token: 0x170004D9 RID: 1241
		// (get) Token: 0x0600133D RID: 4925 RVA: 0x000532D9 File Offset: 0x000514D9
		// (set) Token: 0x0600133E RID: 4926 RVA: 0x000532E1 File Offset: 0x000514E1
		public override List<DiccionarioDeReaccion.LineaDeTexto> lineasDeTexto
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

		// Token: 0x0600133F RID: 4927 RVA: 0x000532EA File Offset: 0x000514EA
		protected override DiccionarioDeReaccion.LineaDeTexto ObtenerNuevaInstancia(string text)
		{
			return new DiccionarioDeReaccion.LineaDeTexto(text);
		}

		// Token: 0x06001340 RID: 4928 RVA: 0x000532F4 File Offset: 0x000514F4
		public static string Obtener(float nivel, List<DiccionarioDeReaccion> others)
		{
			DiccionarioDeReaccion.LineaDeTexto lineaDeTexto = null;
			float minValue = float.MinValue;
			for (int i = 0; i < others.Count; i++)
			{
				DiccionarioDeReaccion.Obtener(others[i], nivel, ref lineaDeTexto, ref minValue);
			}
			if (lineaDeTexto != null)
			{
				return lineaDeTexto.texto;
			}
			return null;
		}

		// Token: 0x06001341 RID: 4929 RVA: 0x00053338 File Offset: 0x00051538
		public string Obtener(float nivel)
		{
			DiccionarioDeReaccion.LineaDeTexto lineaDeTexto = null;
			float minValue = float.MinValue;
			DiccionarioDeReaccion.Obtener(this, nivel, ref lineaDeTexto, ref minValue);
			if (lineaDeTexto != null)
			{
				return lineaDeTexto.texto;
			}
			return null;
		}

		// Token: 0x06001342 RID: 4930 RVA: 0x00053364 File Offset: 0x00051564
		private static void Obtener(DiccionarioDeReaccion dicc, float nivel, ref DiccionarioDeReaccion.LineaDeTexto max, ref float maxScore)
		{
			nivel = Mathf.Clamp(nivel, 0f, 100f);
			for (int i = 0; i < dicc.lineas.Count; i++)
			{
				DiccionarioDeReaccion.LineaDeTexto lineaDeTexto = dicc.lineas[i];
				float num = Mathf.Abs(lineaDeTexto.nivel - nivel);
				float num2 = 1f - num / nivel;
				float num3;
				if (lineaDeTexto.chance >= 100f)
				{
					num3 = 1f;
				}
				else
				{
					num3 = lineaDeTexto.Score();
				}
				if (nivel >= lineaDeTexto.nivel)
				{
					num2 *= 2f;
				}
				if (nivel < lineaDeTexto.nivel)
				{
					num2 /= 2f;
				}
				float num4 = num2 + num3 * 2f;
				if (num4 > maxScore)
				{
					maxScore = num4;
					max = lineaDeTexto;
				}
			}
		}

		// Token: 0x0400100F RID: 4111
		[CoolArrayItem]
		public List<DiccionarioDeReaccion.LineaDeTexto> lineas = new List<DiccionarioDeReaccion.LineaDeTexto>();

		// Token: 0x02000376 RID: 886
		[Serializable]
		public class LineaDeTexto : DiccionarioDeReaccionBase.LineaDeTextoBase
		{
			// Token: 0x06001344 RID: 4932 RVA: 0x00053439 File Offset: 0x00051639
			public LineaDeTexto(string text)
				: base(text)
			{
			}

			// Token: 0x04001010 RID: 4112
			[Range(0f, 100f)]
			public float nivel = 50f;
		}
	}
}
