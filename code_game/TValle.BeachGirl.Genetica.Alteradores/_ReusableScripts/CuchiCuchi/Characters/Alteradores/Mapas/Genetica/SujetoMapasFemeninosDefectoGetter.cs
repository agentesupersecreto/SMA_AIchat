using System;
using Assets._ReusableScripts.CuchiCuchi.Characters.Alteradores.Mapas.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Mapas;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Mapas.Genetica;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Mapas.Genetica.NPCs;
using Assets._ReusableScripts.Globales.Mapas;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Characters.Alteradores.Mapas.Genetica
{
	// Token: 0x02000067 RID: 103
	[CreateAssetMenu(fileName = "SujetoMapasFemeninosDefectoGetter", menuName = "Objetos/Genetica/Sujeto Mapas Femeninos Defecto Getter")]
	public sealed class SujetoMapasFemeninosDefectoGetter : MapaSingleton<SujetoMapasFemeninosDefectoGetter>
	{
		// Token: 0x060004B8 RID: 1208 RVA: 0x000111D7 File Offset: 0x0000F3D7
		protected override void OnJuegoLanzado()
		{
			this.destruirMapas();
		}

		// Token: 0x17000233 RID: 563
		// (get) Token: 0x060004B9 RID: 1209 RVA: 0x000111DF File Offset: 0x0000F3DF
		public SujetoIdentificableNpcAlteradoresFemeninos @default
		{
			get
			{
				SujetoMapasFemeninosDefectoGetter.InitMapa(ref this.m_default, this.m_aparienciaDefault, this.m_personalidad);
				return this.m_default;
			}
		}

		// Token: 0x17000234 RID: 564
		// (get) Token: 0x060004BA RID: 1210 RVA: 0x000111FE File Offset: 0x0000F3FE
		public SujetoIdentificableNpcAlteradoresFemeninos african
		{
			get
			{
				SujetoMapasFemeninosDefectoGetter.InitMapa(ref this.m_african, this.m_aparienciaAfrican, this.m_personalidad);
				return this.m_african;
			}
		}

		// Token: 0x17000235 RID: 565
		// (get) Token: 0x060004BB RID: 1211 RVA: 0x0001121D File Offset: 0x0000F41D
		public SujetoIdentificableNpcAlteradoresFemeninos anime
		{
			get
			{
				SujetoMapasFemeninosDefectoGetter.InitMapa(ref this.m_anime, this.m_aparienciaAnime, this.m_personalidad);
				return this.m_anime;
			}
		}

		// Token: 0x17000236 RID: 566
		// (get) Token: 0x060004BC RID: 1212 RVA: 0x0001123C File Offset: 0x0000F43C
		public SujetoIdentificableNpcAlteradoresFemeninos asian
		{
			get
			{
				SujetoMapasFemeninosDefectoGetter.InitMapa(ref this.m_asian, this.m_aparienciaAsian, this.m_personalidad);
				return this.m_asian;
			}
		}

		// Token: 0x17000237 RID: 567
		// (get) Token: 0x060004BD RID: 1213 RVA: 0x0001125B File Offset: 0x0000F45B
		public SujetoIdentificableNpcAlteradoresFemeninos latina
		{
			get
			{
				SujetoMapasFemeninosDefectoGetter.InitMapa(ref this.m_latina, this.m_aparienciaLatina, this.m_personalidad);
				return this.m_latina;
			}
		}

		// Token: 0x17000238 RID: 568
		// (get) Token: 0x060004BE RID: 1214 RVA: 0x0001127A File Offset: 0x0000F47A
		public SujetoIdentificableNpcAlteradoresFemeninos caucasica
		{
			get
			{
				SujetoMapasFemeninosDefectoGetter.InitMapa(ref this.m_caucasica, this.m_aparienciaCaucasica, this.m_personalidad);
				return this.m_caucasica;
			}
		}

		// Token: 0x17000239 RID: 569
		// (get) Token: 0x060004BF RID: 1215 RVA: 0x00011299 File Offset: 0x0000F499
		public MapaDeAlteracionesPersonalidadFemeninaIndependiente personalidadDefaultMapa
		{
			get
			{
				return this.m_personalidad;
			}
		}

		// Token: 0x060004C0 RID: 1216 RVA: 0x000112A4 File Offset: 0x0000F4A4
		public void SetMaps(MapaDeAlteracionesAparienciaFemeninaIndependiente aparienciaDefault, MapaDeAlteracionesAparienciaFemeninaIndependiente aparienciaAfrican, MapaDeAlteracionesAparienciaFemeninaIndependiente aparienciaAnime, MapaDeAlteracionesAparienciaFemeninaIndependiente aparienciaAsian, MapaDeAlteracionesAparienciaFemeninaIndependiente aparienciaLatina, MapaDeAlteracionesAparienciaFemeninaIndependiente aparienciaCaucasica, MapaDeAlteracionesPersonalidadFemeninaIndependiente Personalidad)
		{
			if (MapaSingleton<SujetoMapasFemeninosDefectoGetter>.init)
			{
				throw new NotSupportedException("No se pueden cambiar los mapas despues q el mapa ha iniciado");
			}
			this.m_aparienciaDefault = aparienciaDefault;
			this.m_aparienciaAfrican = aparienciaAfrican;
			this.m_aparienciaAnime = aparienciaAnime;
			this.m_aparienciaAsian = aparienciaAsian;
			this.m_aparienciaLatina = aparienciaLatina;
			this.m_aparienciaCaucasica = aparienciaCaucasica;
			this.m_personalidad = Personalidad;
		}

		// Token: 0x060004C1 RID: 1217 RVA: 0x000112F8 File Offset: 0x0000F4F8
		public SujetoIdentificableNpcAlteradoresFemeninos Random()
		{
			int num = global::UnityEngine.Random.Range(0, 6);
			switch (num)
			{
			case 0:
				return this.@default;
			case 1:
				return this.african;
			case 2:
				return this.anime;
			case 3:
				return this.asian;
			case 4:
				return this.latina;
			case 5:
				return this.caucasica;
			default:
				throw new ArgumentOutOfRangeException(num.ToString());
			}
		}

		// Token: 0x060004C2 RID: 1218 RVA: 0x00011363 File Offset: 0x0000F563
		private void OnDisable()
		{
			this.destruirMapas();
		}

		// Token: 0x060004C3 RID: 1219 RVA: 0x0001136C File Offset: 0x0000F56C
		private void destruirMapas()
		{
			SujetoMapasFemeninosDefectoGetter.DestroyMapa(ref this.m_default);
			SujetoMapasFemeninosDefectoGetter.DestroyMapa(ref this.m_african);
			SujetoMapasFemeninosDefectoGetter.DestroyMapa(ref this.m_anime);
			SujetoMapasFemeninosDefectoGetter.DestroyMapa(ref this.m_asian);
			SujetoMapasFemeninosDefectoGetter.DestroyMapa(ref this.m_latina);
			SujetoMapasFemeninosDefectoGetter.DestroyMapa(ref this.m_caucasica);
		}

		// Token: 0x060004C4 RID: 1220 RVA: 0x000113BC File Offset: 0x0000F5BC
		private static void InitMapa(ref SujetoIdentificableNpcAlteradoresFemeninos mapa, MapaDeAlteracionesAparienciaFemeninaBase apariencia, MapaDeAlteracionesPersonalidadFemeninaBase personaldiad)
		{
			if (mapa != null)
			{
				return;
			}
			mapa = ScriptableObject.CreateInstance<SujetoIdentificableNpcAlteradoresFemeninos>();
			string text = apariencia.name + " " + personaldiad.name;
			mapa.SetStringID(text);
			mapa.name = text;
			mapa.aparienciaFisicaMapa = ScriptableObject.CreateInstance<SujetoIdentificableAlteradoresAparienciaFemeninos>();
			mapa.personalidadMapa = ScriptableObject.CreateInstance<SujetoIdentificableAlteradoresPersonalidadFemeninos>();
			mapa.aparienciaFisicaMapa.SetStringID(apariencia.name);
			mapa.personalidadMapa.SetStringID(personaldiad.name);
			mapa.aparienciaFisicaMapa.name = apariencia.name;
			mapa.personalidadMapa.name = personaldiad.name;
			mapa.aparienciaFisicaMapa.@base = apariencia;
			mapa.personalidadMapa.@base = personaldiad;
		}

		// Token: 0x060004C5 RID: 1221 RVA: 0x0001147C File Offset: 0x0000F67C
		private static void DestroyMapa(ref SujetoIdentificableNpcAlteradoresFemeninos mapa)
		{
			if (mapa == null)
			{
				return;
			}
			if (mapa.aparienciaFisicaMapa != null)
			{
				mapa.aparienciaFisicaMapa.@base = null;
			}
			if (mapa.personalidadMapa != null)
			{
				mapa.personalidadMapa.@base = null;
			}
			mapa.Destruir();
			mapa = null;
		}

		// Token: 0x0400021B RID: 539
		[NonSerialized]
		private SujetoIdentificableNpcAlteradoresFemeninos m_default;

		// Token: 0x0400021C RID: 540
		[NonSerialized]
		private SujetoIdentificableNpcAlteradoresFemeninos m_african;

		// Token: 0x0400021D RID: 541
		[NonSerialized]
		private SujetoIdentificableNpcAlteradoresFemeninos m_anime;

		// Token: 0x0400021E RID: 542
		[NonSerialized]
		private SujetoIdentificableNpcAlteradoresFemeninos m_asian;

		// Token: 0x0400021F RID: 543
		[NonSerialized]
		private SujetoIdentificableNpcAlteradoresFemeninos m_latina;

		// Token: 0x04000220 RID: 544
		[NonSerialized]
		private SujetoIdentificableNpcAlteradoresFemeninos m_caucasica;

		// Token: 0x04000221 RID: 545
		[SerializeField]
		private MapaDeAlteracionesAparienciaFemeninaIndependiente m_aparienciaDefault;

		// Token: 0x04000222 RID: 546
		[SerializeField]
		private MapaDeAlteracionesAparienciaFemeninaBase m_aparienciaAfrican;

		// Token: 0x04000223 RID: 547
		[SerializeField]
		private MapaDeAlteracionesAparienciaFemeninaBase m_aparienciaAnime;

		// Token: 0x04000224 RID: 548
		[SerializeField]
		private MapaDeAlteracionesAparienciaFemeninaBase m_aparienciaAsian;

		// Token: 0x04000225 RID: 549
		[SerializeField]
		private MapaDeAlteracionesAparienciaFemeninaBase m_aparienciaLatina;

		// Token: 0x04000226 RID: 550
		[SerializeField]
		private MapaDeAlteracionesAparienciaFemeninaBase m_aparienciaCaucasica;

		// Token: 0x04000227 RID: 551
		[SerializeField]
		private MapaDeAlteracionesPersonalidadFemeninaIndependiente m_personalidad;
	}
}
