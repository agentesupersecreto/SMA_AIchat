using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Base.BeachGirl.Controladores.Materiales.Runtime;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores;
using Assets._ReusableScripts.CuchiCuchi.Characters.Alteradores.Mapas.Genetica;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Clases;
using Assets._ReusableScripts.CuchiCuchi.Chars.Controladores;
using Assets._ReusableScripts.CuchiCuchi.Chars.Mapas;
using Assets._ReusableScripts.CuchiCuchi.Chars.Materiales.Globales;
using Assets._ReusableScripts.CuchiCuchi.Chars.Materiales.Mapas;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Interpretadores.Mapas;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters.Controlladores.Apariencia;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Hair;
using Assets._ReusableScripts.Globales.Mapas;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Interpretadores
{
	// Token: 0x02000395 RID: 917
	public class LoaderInterpretacionDeApariencia : AplicableCustomMonobehaviour
	{
		// Token: 0x1700050D RID: 1293
		// (get) Token: 0x060016E7 RID: 5863 RVA: 0x0006D765 File Offset: 0x0006B965
		public AlteradoresDeAparienciaFemenina alteradoresDeAparienciaFemenina
		{
			get
			{
				return this.m_AlteradoresDeAparienciaFemenina;
			}
		}

		// Token: 0x1700050E RID: 1294
		// (get) Token: 0x060016E8 RID: 5864 RVA: 0x0006D76D File Offset: 0x0006B96D
		public ControlladorDeCabelloGpu controlladorDeCabelloGpu
		{
			get
			{
				return this.m_ControlladorDeCabelloGpu;
			}
		}

		// Token: 0x1700050F RID: 1295
		// (get) Token: 0x060016E9 RID: 5865 RVA: 0x0006D775 File Offset: 0x0006B975
		public ControlladorDeFemalePubesApariencia controlladorDeFemalePubesApariencia
		{
			get
			{
				return this.m_controlladorDeFemalePubesApariencia;
			}
		}

		// Token: 0x17000510 RID: 1296
		// (get) Token: 0x060016EA RID: 5866 RVA: 0x0006D77D File Offset: 0x0006B97D
		public ControlladorDeFemalePiel controlladorDeFemalePiel
		{
			get
			{
				return this.m_ControlladorDeFemalePiel;
			}
		}

		// Token: 0x17000511 RID: 1297
		// (get) Token: 0x060016EB RID: 5867 RVA: 0x0006D785 File Offset: 0x0006B985
		public ControlladorDeFemaleMakeUp controlladorDeFemaleMakeUp
		{
			get
			{
				return this.m_ControlladorDeFemaleMakeUp;
			}
		}

		// Token: 0x17000512 RID: 1298
		// (get) Token: 0x060016EC RID: 5868 RVA: 0x0006D78D File Offset: 0x0006B98D
		public ControlladorDeEyeAdvanceColores controlladorDeEyeAdvanceColores
		{
			get
			{
				return this.m_ControlladorDeEyeAdvanceColores;
			}
		}

		// Token: 0x17000513 RID: 1299
		// (get) Token: 0x060016ED RID: 5869 RVA: 0x0006D795 File Offset: 0x0006B995
		public ControlladorDeFemaleCejasApariencia controlladorDeFemaleCejasApariencia
		{
			get
			{
				return this.m_ControlladorDeFemaleCejasApariencia;
			}
		}

		// Token: 0x060016EE RID: 5870 RVA: 0x0006D7A0 File Offset: 0x0006B9A0
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			ICharacterRoot root = this.GetRoot();
			this.m_AlteradoresDeAparienciaFemenina = root.GetComponentInChildren<AlteradoresDeAparienciaFemenina>();
			if (this.m_AlteradoresDeAparienciaFemenina == null)
			{
				throw new ArgumentNullException("m_AlteradoresDeAparienciaFemenina", "m_AlteradoresDeAparienciaFemenina null reference.");
			}
			this.m_ControlladorDeCabelloGpu = root.GetComponentInChildren<ControlladorDeCabelloGpu>();
			this.m_controlladorDeFemalePubesApariencia = root.GetComponentInChildren<ControlladorDeFemalePubesApariencia>();
			this.m_ControlladorDeFemalePiel = root.GetComponentInChildren<ControlladorDeFemalePiel>();
			this.m_ControlladorDeFemaleMakeUp = root.GetComponentInChildren<ControlladorDeFemaleMakeUp>();
			this.m_ControlladorDeEyeAdvanceColores = root.GetComponentInChildren<ControlladorDeEyeAdvanceColores>();
			this.m_ControlladorDeFemaleCejasApariencia = root.GetComponentInChildren<ControlladorDeFemaleCejasApariencia>();
			if (this.m_ControlladorDeCabelloGpu == null)
			{
				throw new ArgumentNullException("m_ControlladorDeCabelloGpu", "m_ControlladorDeCabelloGpu null reference.");
			}
			if (this.m_controlladorDeFemalePubesApariencia == null)
			{
				throw new ArgumentNullException("m_controlladorDeFemalePubesApariencia", "m_controlladorDeFemalePubesApariencia null reference.");
			}
			if (this.m_ControlladorDeFemalePiel == null)
			{
				throw new ArgumentNullException("m_ControlladorDeFemalePiel", "m_ControlladorDeFemalePiel null reference.");
			}
			if (this.m_ControlladorDeFemaleMakeUp == null)
			{
				throw new ArgumentNullException("m_ControlladorDeFemaleMakeUp", "m_ControlladorDeFemaleMakeUp null reference.");
			}
			if (this.m_ControlladorDeEyeAdvanceColores == null)
			{
				throw new ArgumentNullException("m_ControlladorDeEyeAdvanceColores", "m_ControlladorDeEyeAdvanceColores null reference.");
			}
			if (this.m_ControlladorDeFemaleCejasApariencia == null)
			{
				throw new ArgumentNullException("m_ControlladorDeFemaleCejasApariencia", "m_ControlladorDeFemaleCejasApariencia null reference.");
			}
			this.m_interpretacionDebug = MapaSingleton<MapaSingletonDefaultInterpretacion>.instance.interpretacion;
		}

		// Token: 0x060016EF RID: 5871 RVA: 0x0006D8F0 File Offset: 0x0006BAF0
		public void LoadInterpretacion(ref InterpretacionCompletaDeFemale interpretacion)
		{
			if (!base.isAwaken)
			{
				throw new InvalidOperationException();
			}
			Dictionary<string, ModificadoresDeAlterador> dictionary = MapaSingleton<SujetoMapasFemeninosDefectoGetter>.instance.@default.aparienciaFisicaMapa.@base.ObtenerClonesDeAlteradorModificadores().ToDictionary((ModificadoresDeAlterador mod) => mod.alteradorName);
			InterpretadorDeFemales.AparienciaDataWrap aparienciaDataWrap = new InterpretadorDeFemales.AparienciaDataWrap();
			aparienciaDataWrap.alteradoresData = dictionary;
			InterpretadorDeAnus.InterpretarInverse(aparienciaDataWrap, interpretacion.interpretacionDeAnus);
			InterpretadorDeAss.InterpretarInverse(aparienciaDataWrap, interpretacion.interpretacionDeAss);
			Color color;
			Color color2;
			float num;
			float num2;
			InterpretadorDeBodySkin.InterpretarInverse(aparienciaDataWrap, interpretacion.interpretacionDeBodySkin, out color, out color2, out num, out num2);
			InterpretadorDeBodySuperficial.InterpretarInverse(aparienciaDataWrap, interpretacion.interpretacionDeBodySuperficial);
			InterpretadorDeCheeks.InterpretarInverse(aparienciaDataWrap, interpretacion.interpretacionDeCheeks);
			Color color3;
			InterpretadorDeEyebrows.InterpretarInverse(aparienciaDataWrap, interpretacion.interpretacionDeEyebrows, out color3);
			Color color4;
			InterpretadorDeEyes.InterpretarInverse(aparienciaDataWrap, interpretacion.interpretacionDeEyes, out color4);
			float num3;
			float num4;
			InterpretadorDeFacialSkin.InterpretarInverse(aparienciaDataWrap, interpretacion.interpretacionDeFacialSkin, out num3, out num4);
			bool flag;
			Color color5;
			InterpretadorDeHair.InterpretarInverse(aparienciaDataWrap, interpretacion.interpretacionDeHair, out flag, out color5);
			Color color6;
			InterpretadorDePubicHair.InterpretarInverse(aparienciaDataWrap, new Func<float, int>(InterpretadorDeFemales.DensidadDePubesAIndexDeTexturaDePubes), interpretacion.interpretacionDePubicHair, out color6);
			InterpretadorDeJaw.InterpretarInverse(aparienciaDataWrap, interpretacion.interpretacionDeJaw);
			Color color7;
			InterpretadorDeMouth.InterpretarInverse(aparienciaDataWrap, interpretacion.interpretacionDeMouth, out color7);
			InterpretadorDeNose.InterpretarInverse(aparienciaDataWrap, interpretacion.interpretacionDeNose);
			InterpretadorDeRostro.InterpretarInverse(aparienciaDataWrap, interpretacion.interpretacionDeRostro);
			Color color8;
			InterpretadorDeSenos.InterpretarInverse(aparienciaDataWrap, interpretacion.interpretacionDeSenos, out color8, 0.3f, 0.75f);
			InterpretadorDeVag.InterpretarInverse(aparienciaDataWrap, interpretacion.interpretacionDeVag);
			try
			{
				this.alteradoresDeAparienciaFemenina.UpdateValoresWithData(aparienciaDataWrap.alteradoresData.Values);
			}
			catch (Exception)
			{
				throw;
			}
			this.controlladorDeFemalePiel.colorDeFingerNails.ForceNewValue(color, false);
			this.controlladorDeFemalePiel.colorDeToeNails.ForceNewValue(color2, false);
			this.controlladorDeFemalePiel.colorDeLabios.ForceNewValue(color7, false);
			this.controlladorDeFemalePiel.colorDePezones.ForceNewValue(color8, false);
			ConjuntosDeMaterialesDeFemalePiel instance = Singleton<ConjuntosDeMaterialesDeFemalePiel>.instance;
			int num5 = -1;
			float num6 = float.MaxValue;
			for (int i = 0; i < instance.conjuntos.Count; i++)
			{
				MapaDeConjuntosDeMaterialesDePielFemeninos.Conjunto conjunto = instance.conjuntos[i];
				float num7 = Mathf.Abs(conjunto.tanWeigth - num) + Mathf.Abs(1f - conjunto.qualityWeigth * 0.75f + conjunto.varWeigth * 0.25f - num2);
				if (num7 < num6)
				{
					num5 = i;
					num6 = num7;
				}
			}
			this.controlladorDeFemalePiel.ActualizarPiel();
			this.controlladorDeFemalePiel.ChangeDiffuseTo(num5);
			this.controlladorDeFemaleCejasApariencia.colorDeCejas.ForceNewValue(color3, false);
			this.controlladorDeFemaleCejasApariencia.ActualizarColorCejas();
			this.controlladorDeEyeAdvanceColores.colorDeOjoL.ForceNewValue(color4, false);
			this.controlladorDeEyeAdvanceColores.colorDeOjoR.ForceNewValue(color4, false);
			this.controlladorDeEyeAdvanceColores.ActualizarOjos();
			this.controlladorDeCabelloGpu.colorDeGpuHair.ForceNewValue(color5, false);
			this.controlladorDeCabelloGpu.ActualizarColorDeCabello();
			CollecionDeStylosDeCabello instance2 = Singleton<CollecionDeStylosDeCabello>.instance;
			if (flag)
			{
				this.controlladorDeCabelloGpu.flagCambiarStyloAIndex = instance2.stylos.IndexOf(instance2.styloLargo);
			}
			else
			{
				this.controlladorDeCabelloGpu.flagCambiarStyloAIndex = instance2.stylos.IndexOf(instance2.styloCorto);
			}
			this.controlladorDeCabelloGpu.ActualizarStylo();
			this.controlladorDeFemalePubesApariencia.colorDePubes.ForceNewValue(color6, false);
			this.controlladorDeFemalePubesApariencia.ActualizarColorPubes();
			MapaSingletonDeFemaleMakeUp instance3 = MapaSingleton<MapaSingletonDeFemaleMakeUp>.instance;
			int num8 = -1;
			float num9 = float.MaxValue;
			for (int j = 0; j < instance3.makeUps.Count; j++)
			{
				MapaSingletonDeFemaleMakeUp.MakeUpItem makeUpItem = instance3.makeUps[j];
				float num10 = Mathf.Abs(makeUpItem.cheeksWeigth - num3) + Mathf.Abs(makeUpItem.eyeShadowWeigth - num4);
				if (num10 < num9)
				{
					num8 = j;
					num9 = num10;
				}
			}
			this.controlladorDeFemaleMakeUp.ChangeTo(num8);
		}

		// Token: 0x060016F0 RID: 5872 RVA: 0x0006DCB0 File Offset: 0x0006BEB0
		protected override CustomMonobehaviourBotonConfig Boton2()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "Load Debug Interpretacion",
				editorTimeVisible = false
			};
		}

		// Token: 0x060016F1 RID: 5873 RVA: 0x0006DCC9 File Offset: 0x0006BEC9
		protected override void OnAplicar2()
		{
			this.LoadInterpretacion(ref this.m_interpretacionDebug);
		}

		// Token: 0x040010A3 RID: 4259
		private ControlladorDeCabelloGpu m_ControlladorDeCabelloGpu;

		// Token: 0x040010A4 RID: 4260
		private ControlladorDeFemalePubesApariencia m_controlladorDeFemalePubesApariencia;

		// Token: 0x040010A5 RID: 4261
		private ControlladorDeFemalePiel m_ControlladorDeFemalePiel;

		// Token: 0x040010A6 RID: 4262
		private ControlladorDeFemaleMakeUp m_ControlladorDeFemaleMakeUp;

		// Token: 0x040010A7 RID: 4263
		private ControlladorDeEyeAdvanceColores m_ControlladorDeEyeAdvanceColores;

		// Token: 0x040010A8 RID: 4264
		private AlteradoresDeAparienciaFemenina m_AlteradoresDeAparienciaFemenina;

		// Token: 0x040010A9 RID: 4265
		private ControlladorDeFemaleCejasApariencia m_ControlladorDeFemaleCejasApariencia;

		// Token: 0x040010AA RID: 4266
		[SerializeField]
		private InterpretacionCompletaDeFemale m_interpretacionDebug;
	}
}
