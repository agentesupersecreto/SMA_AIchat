using System;
using System.Collections.Generic;
using System.Linq;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.BeachGirl.Runtime.Sonidos.Characters.Mapas;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.Sonidos.Characters.Globales
{
	// Token: 0x02000064 RID: 100
	public class MapasDeSonidosDeExpresionesVerbalesSexuales : Singleton<MapasDeSonidosDeExpresionesVerbalesSexuales>
	{
		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x060001C9 RID: 457 RVA: 0x000041FF File Offset: 0x000023FF
		public IReadOnlyList<MapasDeSonidosDeExpresionesVerbalesSexuales.PersonalidadData> mapas
		{
			get
			{
				return this.m_mapas;
			}
		}

		// Token: 0x060001CA RID: 458 RVA: 0x00004208 File Offset: 0x00002408
		protected override void DoAwake()
		{
			base.DoAwake();
			for (int i = 0; i < this.m_mapas.Count; i++)
			{
				this.m_mapas[i].Init();
			}
		}

		// Token: 0x060001CB RID: 459 RVA: 0x00004242 File Offset: 0x00002442
		public ExpresionVerbalData TryObtenerMapaPlacer(int personalidadIndex, float emocionValor, ExpresionVerbalData ultimo = null, ExpresionVerbalData penultimo = null)
		{
			if (!this.m_mapas.ContieneIndex(personalidadIndex))
			{
				return null;
			}
			return this.m_mapas[personalidadIndex].TryObtenerMapaPlacer(emocionValor, ultimo, penultimo);
		}

		// Token: 0x060001CC RID: 460 RVA: 0x00004269 File Offset: 0x00002469
		public ExpresionVerbalData TryObtenerMapaDolor(int personalidadIndex, float emocionValor, ExpresionVerbalData ultimo = null)
		{
			if (!this.m_mapas.ContieneIndex(personalidadIndex))
			{
				return null;
			}
			return this.m_mapas[personalidadIndex].TryObtenerMapaDolor(emocionValor, ultimo);
		}

		// Token: 0x060001CD RID: 461 RVA: 0x0000428E File Offset: 0x0000248E
		public ExpresionVerbalData ObtenerMapaDeOrgasmo(int personalidadIndex, ExpresionVerbalData ultimo = null)
		{
			if (!this.m_mapas.ContieneIndex(personalidadIndex))
			{
				return null;
			}
			return this.m_mapas[personalidadIndex].ObtenerMapaDeOrgasmo(ultimo);
		}

		// Token: 0x04000126 RID: 294
		[Header("NO cambiar el orden de las personalidades, ya que se alterarian las voces de las modelos en save")]
		[SerializeField]
		private List<MapasDeSonidosDeExpresionesVerbalesSexuales.PersonalidadData> m_mapas;

		// Token: 0x0200014A RID: 330
		[Serializable]
		public class PersonalidadData
		{
			// Token: 0x170004CD RID: 1229
			// (get) Token: 0x06000DBF RID: 3519 RVA: 0x0002F5DD File Offset: 0x0002D7DD
			public int personalidadID
			{
				get
				{
					return this.m_personalidadID;
				}
			}

			// Token: 0x170004CE RID: 1230
			// (get) Token: 0x06000DC0 RID: 3520 RVA: 0x0002F5E5 File Offset: 0x0002D7E5
			public IReadOnlyList<MapasDeSonidosDeExpresionesVerbalesSexuales.MapaData> mapasGaspPlacer
			{
				get
				{
					return this.m_mapasGaspPlacer;
				}
			}

			// Token: 0x170004CF RID: 1231
			// (get) Token: 0x06000DC1 RID: 3521 RVA: 0x0002F5ED File Offset: 0x0002D7ED
			public IReadOnlyList<MapasDeSonidosDeExpresionesVerbalesSexuales.MapaData> mapasGaspDolor
			{
				get
				{
					return this.m_mapasGaspDolor;
				}
			}

			// Token: 0x170004D0 RID: 1232
			// (get) Token: 0x06000DC2 RID: 3522 RVA: 0x0002F5F5 File Offset: 0x0002D7F5
			public IReadOnlyList<ExpresionVerbalData> mapasOrgasmo
			{
				get
				{
					return this.m_mapasOrgasmo;
				}
			}

			// Token: 0x06000DC3 RID: 3523 RVA: 0x0002F600 File Offset: 0x0002D800
			public ExpresionVerbalData ObtenerMapaDeOrgasmo(ExpresionVerbalData ultimo = null)
			{
				this.m_mapasOrgasmoAleatorioOrden.Shuffle<ExpresionVerbalData>();
				ExpresionVerbalData expresionVerbalData = null;
				ExpresionVerbalData expresionVerbalData2 = null;
				for (int i = 0; i < this.m_mapasOrgasmoAleatorioOrden.Count; i++)
				{
					ExpresionVerbalData expresionVerbalData3 = this.m_mapasOrgasmoAleatorioOrden[i];
					expresionVerbalData = expresionVerbalData3;
					if (expresionVerbalData3 != ultimo)
					{
						expresionVerbalData2 = expresionVerbalData3;
						break;
					}
				}
				if (expresionVerbalData2 != null)
				{
					return expresionVerbalData2;
				}
				return expresionVerbalData;
			}

			// Token: 0x06000DC4 RID: 3524 RVA: 0x0002F65C File Offset: 0x0002D85C
			public ExpresionVerbalData TryObtenerMapaPlacer(float emocionValor, ExpresionVerbalData ultimo = null, ExpresionVerbalData penultimo = null)
			{
				this.m_mapasGaspPlacerAleatorioOrden.Shuffle<MapasDeSonidosDeExpresionesVerbalesSexuales.MapaData>();
				ExpresionVerbalData expresionVerbalData = null;
				ExpresionVerbalData expresionVerbalData2 = null;
				for (int i = 0; i < this.m_mapasGaspPlacerAleatorioOrden.Count; i++)
				{
					MapasDeSonidosDeExpresionesVerbalesSexuales.MapaData mapaData = this.m_mapasGaspPlacerAleatorioOrden[i];
					if (emocionValor >= mapaData.minEmocionValue && emocionValor <= mapaData.maxEmocionValue)
					{
						expresionVerbalData = mapaData.mapa;
						if (mapaData.mapa != ultimo && mapaData.mapa != penultimo)
						{
							expresionVerbalData2 = mapaData.mapa;
							break;
						}
					}
				}
				if (expresionVerbalData2 != null)
				{
					return expresionVerbalData2;
				}
				return expresionVerbalData;
			}

			// Token: 0x06000DC5 RID: 3525 RVA: 0x0002F6E8 File Offset: 0x0002D8E8
			public ExpresionVerbalData TryObtenerMapaDolor(float emocionValor, ExpresionVerbalData ultimo = null)
			{
				this.m_mapasGaspDolorAleatorioOrden.Shuffle<MapasDeSonidosDeExpresionesVerbalesSexuales.MapaData>();
				ExpresionVerbalData expresionVerbalData = null;
				ExpresionVerbalData expresionVerbalData2 = null;
				for (int i = 0; i < this.m_mapasGaspDolorAleatorioOrden.Count; i++)
				{
					MapasDeSonidosDeExpresionesVerbalesSexuales.MapaData mapaData = this.m_mapasGaspDolorAleatorioOrden[i];
					if (emocionValor >= mapaData.minEmocionValue && emocionValor <= mapaData.maxEmocionValue)
					{
						expresionVerbalData = mapaData.mapa;
						if (mapaData.mapa != ultimo)
						{
							expresionVerbalData2 = mapaData.mapa;
							break;
						}
					}
				}
				if (expresionVerbalData2 != null)
				{
					return expresionVerbalData2;
				}
				return expresionVerbalData;
			}

			// Token: 0x06000DC6 RID: 3526 RVA: 0x0002F764 File Offset: 0x0002D964
			public void Init()
			{
				this.m_mapasGaspPlacer = new List<MapasDeSonidosDeExpresionesVerbalesSexuales.MapaData>();
				this.m_mapasGaspDolor = new List<MapasDeSonidosDeExpresionesVerbalesSexuales.MapaData>();
				this.m_mapasGaspPlacerAleatorioOrden = new List<MapasDeSonidosDeExpresionesVerbalesSexuales.MapaData>();
				this.m_mapasGaspDolorAleatorioOrden = new List<MapasDeSonidosDeExpresionesVerbalesSexuales.MapaData>();
				this.m_mapasOrgasmoAleatorioOrden = new List<ExpresionVerbalData>(this.m_mapasOrgasmo.Distinct<ExpresionVerbalData>());
				if (this.m_mapasOrgasmo.Count != this.m_mapasOrgasmoAleatorioOrden.Count)
				{
					Debug.LogError("cantidad de orgasmos es diferente");
				}
				HashSet<ExpresionVerbalData> hashSet = new HashSet<ExpresionVerbalData>();
				for (int i = 0; i < this.m_mapasGasp.Count; i++)
				{
					MapasDeSonidosDeExpresionesVerbalesSexuales.MapaDataEmocional mapaDataEmocional = this.m_mapasGasp[i];
					Object @object;
					if (mapaDataEmocional == null)
					{
						@object = null;
					}
					else
					{
						MapasDeSonidosDeExpresionesVerbalesSexuales.MapaData mapaData = mapaDataEmocional.mapaData;
						@object = ((mapaData != null) ? mapaData.mapa : null);
					}
					if (@object == null)
					{
						Debug.LogError("Mapa es nullo en index: " + i.ToString() + " en personalidad: " + this.m_personalidadID.ToString());
					}
					else if (!hashSet.Add(mapaDataEmocional.mapaData.mapa))
					{
						Debug.LogError("Mapa esta repetido: " + mapaDataEmocional.mapaData.mapa.name, mapaDataEmocional.mapaData.mapa);
					}
					else
					{
						this.m_mapasGaspPlacer.Add(mapaDataEmocional.mapaData);
						this.m_mapasGaspPlacerAleatorioOrden.Add(mapaDataEmocional.mapaData);
						if (mapaDataEmocional.puedeSerDolor)
						{
							MapasDeSonidosDeExpresionesVerbalesSexuales.MapaData mapaData2 = new MapasDeSonidosDeExpresionesVerbalesSexuales.MapaData();
							mapaData2.minEmocionValue = 0f;
							mapaData2.maxEmocionValue = 100f;
							mapaData2.mapa = mapaDataEmocional.mapaData.mapa;
							this.m_mapasGaspDolor.Add(mapaData2);
							this.m_mapasGaspDolorAleatorioOrden.Add(mapaData2);
						}
					}
				}
			}

			// Token: 0x040007D2 RID: 2002
			[SerializeField]
			private int m_personalidadID;

			// Token: 0x040007D3 RID: 2003
			[SerializeField]
			private List<MapasDeSonidosDeExpresionesVerbalesSexuales.MapaDataEmocional> m_mapasGasp;

			// Token: 0x040007D4 RID: 2004
			[SerializeField]
			private List<ExpresionVerbalData> m_mapasOrgasmo;

			// Token: 0x040007D5 RID: 2005
			private List<ExpresionVerbalData> m_mapasOrgasmoAleatorioOrden;

			// Token: 0x040007D6 RID: 2006
			private List<MapasDeSonidosDeExpresionesVerbalesSexuales.MapaData> m_mapasGaspPlacer;

			// Token: 0x040007D7 RID: 2007
			private List<MapasDeSonidosDeExpresionesVerbalesSexuales.MapaData> m_mapasGaspDolor;

			// Token: 0x040007D8 RID: 2008
			private List<MapasDeSonidosDeExpresionesVerbalesSexuales.MapaData> m_mapasGaspPlacerAleatorioOrden;

			// Token: 0x040007D9 RID: 2009
			private List<MapasDeSonidosDeExpresionesVerbalesSexuales.MapaData> m_mapasGaspDolorAleatorioOrden;
		}

		// Token: 0x0200014B RID: 331
		[Serializable]
		public class MapaDataEmocional
		{
			// Token: 0x040007DA RID: 2010
			public bool puedeSerDolor;

			// Token: 0x040007DB RID: 2011
			[HideInInspector]
			[Obsolete]
			public bool esPreOrgasmo;

			// Token: 0x040007DC RID: 2012
			public MapasDeSonidosDeExpresionesVerbalesSexuales.MapaData mapaData;
		}

		// Token: 0x0200014C RID: 332
		[Serializable]
		public class MapaData
		{
			// Token: 0x040007DD RID: 2013
			[Range(0f, 100f)]
			public float minEmocionValue;

			// Token: 0x040007DE RID: 2014
			[Range(0f, 100f)]
			public float maxEmocionValue = 100f;

			// Token: 0x040007DF RID: 2015
			public ExpresionVerbalData mapa;
		}
	}
}
