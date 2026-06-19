using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.Pro.Entrevista.Runtime.Tiempo;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi.Ropa;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.General.Globales
{
	// Token: 0x020000BE RID: 190
	public class SMAGameController : Singleton<SMAGameController>
	{
		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x0600072C RID: 1836 RVA: 0x00028B54 File Offset: 0x00026D54
		public Texture2D defaultFemaleProtraitTexture
		{
			get
			{
				return this.m_defaultFemaleProtraitTexture;
			}
		}

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x0600072D RID: 1837 RVA: 0x00028B5C File Offset: 0x00026D5C
		public Texture2D defaultJobProtraitTexture
		{
			get
			{
				return this.m_defaultJobProtraitTexture;
			}
		}

		// Token: 0x0600072E RID: 1838 RVA: 0x00028B64 File Offset: 0x00026D64
		protected override void InitData(bool esEditorTime)
		{
			if (!esEditorTime)
			{
				if (this.conjuntosDeRopaIniciales.minusOne == null)
				{
					throw new ArgumentNullException("minusOne", "minusOne null reference.");
				}
				if (this.conjuntosDeRopaIniciales.zero == null)
				{
					throw new ArgumentNullException("zero", "zero null reference.");
				}
				if (this.conjuntosDeRopaIniciales.one == null)
				{
					throw new ArgumentNullException("one", "one null reference.");
				}
				if (this.conjuntosDeRopaIniciales.two == null)
				{
					throw new ArgumentNullException("two", "two null reference.");
				}
				if (this.conjuntosDeRopaIniciales.three == null)
				{
					throw new ArgumentNullException("three", "three null reference.");
				}
			}
		}

		// Token: 0x0600072F RID: 1839 RVA: 0x00028C26 File Offset: 0x00026E26
		public ScenaTiempoDelDia GetTiempoDelDia()
		{
			return SMAGameController.GetTiempoDelDia(Singleton<TiempoDeJuego>.instance.now);
		}

		// Token: 0x06000730 RID: 1840 RVA: 0x00028C38 File Offset: 0x00026E38
		public static ScenaTiempoDelDia GetTiempoDelDia(DateTime data)
		{
			int hour = data.Hour;
			int num = hour;
			if (num >= 4 && num < 7)
			{
				return ScenaTiempoDelDia.EarlyMorning;
			}
			int num2 = num;
			if (num2 >= 7 && num2 < 11)
			{
				return ScenaTiempoDelDia.Morning;
			}
			int num3 = num;
			if (num3 >= 11 && num3 < 13)
			{
				return ScenaTiempoDelDia.Midday;
			}
			int num4 = num;
			if (num4 >= 13 && num4 < 17)
			{
				return ScenaTiempoDelDia.Afternoon;
			}
			int num5 = num;
			if (num5 >= 17 && num5 < 20)
			{
				return ScenaTiempoDelDia.Evening;
			}
			int num6 = num;
			if (num6 >= 20 && num6 < 0)
			{
				return ScenaTiempoDelDia.Night;
			}
			int num7 = num;
			if (num7 >= 0 && num7 < 4)
			{
				return ScenaTiempoDelDia.LateNight;
			}
			throw new ArgumentOutOfRangeException(hour.ToString());
		}

		// Token: 0x04000424 RID: 1060
		[SerializeField]
		private Texture2D m_defaultFemaleProtraitTexture;

		// Token: 0x04000425 RID: 1061
		[SerializeField]
		private Texture2D m_defaultJobProtraitTexture;

		// Token: 0x04000426 RID: 1062
		public SMAGameController.ConjuntosDeRopaIniciales conjuntosDeRopaIniciales = new SMAGameController.ConjuntosDeRopaIniciales();

		// Token: 0x0200023E RID: 574
		[Serializable]
		public class ConjuntosDeRopaIniciales
		{
			// Token: 0x04000AB3 RID: 2739
			public MapaConjuntoDeRopa minusOne;

			// Token: 0x04000AB4 RID: 2740
			public MapaConjuntoDeRopa zero;

			// Token: 0x04000AB5 RID: 2741
			public MapaConjuntoDeRopa one;

			// Token: 0x04000AB6 RID: 2742
			public MapaConjuntoDeRopa two;

			// Token: 0x04000AB7 RID: 2743
			public MapaConjuntoDeRopa three;
		}
	}
}
