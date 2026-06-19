using System;
using System.Collections.Generic;
using Assets.Base.RootMotion.BeachGirl.Runtime.Controllers.AutoSex;
using Assets.TValle.BeachGirl.Sexual;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;
using Assets._ReusableScripts.CuchiCuchi.AI.UmbralesV2;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using Assets._ReusableScripts.Respiracion;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai
{
	// Token: 0x020002E1 RID: 737
	public class AutoSexRangosDeToleranciaCalculador : CustomMonobehaviour, IAutoSexRangesGetter
	{
		// Token: 0x06001294 RID: 4756 RVA: 0x000588F0 File Offset: 0x00056AF0
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_DolorPorPenetracion = this.GetComponentEnRoot(false);
			this.m_PlacerPorPenetraciones = this.GetComponentEnRoot(false);
			this.m_DolorPorToques = this.GetComponentEnRoot(false);
			this.m_DolorPorGolpes = this.GetComponentEnRoot(false);
			this.m_PlacerPorToques = this.GetComponentEnRoot(false);
			if (this.m_DolorPorPenetracion == null)
			{
				throw new ArgumentNullException("m_DolorPorPenetracion", "m_DolorPorPenetracion null reference.");
			}
			if (this.m_PlacerPorPenetraciones == null)
			{
				throw new ArgumentNullException("m_PlacerPorPenetraciones", "m_PlacerPorPenetraciones null reference.");
			}
			if (this.m_DolorPorToques == null)
			{
				throw new ArgumentNullException("m_DolorPorToques", "m_DolorPorToques null reference.");
			}
			if (this.m_DolorPorGolpes == null)
			{
				throw new ArgumentNullException("m_DolorPorGolpes", "m_Dom_DolorPorGolpeslorPorToques null reference.");
			}
			if (this.m_PlacerPorToques == null)
			{
				throw new ArgumentNullException("m_PlacerPorToques", "m_PlacerPorToques null reference.");
			}
			this.m_RespiracionEngine = this.GetComponentEnRoot(false);
			if (this.m_RespiracionEngine == null)
			{
				throw new ArgumentNullException("m_RespiracionEngine", "m_RespiracionEngine null reference.");
			}
			this.m_ConsentNecesario = this.GetComponentEnRoot(false);
			if (this.m_ConsentNecesario == null)
			{
				throw new ArgumentNullException("m_ConsentNecesario", "m_ConsentNecesario null reference.");
			}
			this.m_IBocaHole = this.GetComponentEnRoot(false);
			if (this.m_IBocaHole == null)
			{
				throw new ArgumentNullException("m_IBocaHole", "m_IBocaHole null reference.");
			}
			this.m_IVagHole = this.GetComponentEnRoot(false);
			if (this.m_IVagHole == null)
			{
				throw new ArgumentNullException("m_IVagHole", "m_IVagHole null reference.");
			}
			this.m_IAnusHole = this.GetComponentEnRoot(false);
			if (this.m_IAnusHole == null)
			{
				throw new ArgumentNullException("m_IAnusHole", "m_IAnusHole null reference.");
			}
		}

		// Token: 0x06001295 RID: 4757 RVA: 0x00058AA0 File Offset: 0x00056CA0
		public bool EsMuyApretado(float anchoDePenetratorGlobal, FemalePenetracionTipo estimulado, ParteQuePuedeEstimular estimulante, out float offsetMod)
		{
			IHole hole;
			switch (estimulado)
			{
			case FemalePenetracionTipo.anus:
				hole = this.m_IAnusHole;
				break;
			case FemalePenetracionTipo.vag:
				hole = this.m_IVagHole;
				break;
			case FemalePenetracionTipo.facial:
				hole = this.m_IBocaHole;
				break;
			default:
				throw new ArgumentOutOfRangeException(estimulado.ToString());
			}
			EmocionesFemeninasValues emocionesFemeninasValues = default(EmocionesFemeninasValues);
			offsetMod = MathfExtension.InverseLerpUnclamped(0f, this.m_DolorPorPenetracion.ObtenerRangoDeAnchura(estimulado, ref emocionesFemeninasValues).min, anchoDePenetratorGlobal / hole.worldScaleReal);
			return offsetMod >= 1f;
		}

		// Token: 0x06001296 RID: 4758 RVA: 0x00058B30 File Offset: 0x00056D30
		public bool EsMuyApretado(float anchoDePenetratorGlobal, ParteDelCuerpoHumano estimulado, ParteQuePuedeEstimular estimulante, out float offsetMod)
		{
			FemalePenetracionTipo femalePenetracionTipo;
			if (estimulado != ParteDelCuerpoHumano.bocaInterno)
			{
				if (estimulado != ParteDelCuerpoHumano.ano)
				{
					if (estimulado != ParteDelCuerpoHumano.vag)
					{
						throw new ArgumentOutOfRangeException(estimulado.ToString());
					}
					femalePenetracionTipo = FemalePenetracionTipo.vag;
				}
				else
				{
					femalePenetracionTipo = FemalePenetracionTipo.anus;
				}
			}
			else
			{
				femalePenetracionTipo = FemalePenetracionTipo.facial;
			}
			return this.EsMuyApretado(anchoDePenetratorGlobal, femalePenetracionTipo, estimulante, out offsetMod);
		}

		// Token: 0x06001297 RID: 4759 RVA: 0x00058B78 File Offset: 0x00056D78
		public RangeValueV2 GetRangeDeProfuncidadDeAutoSex(ParteDelCuerpoHumano estimulado, ParteQuePuedeEstimular estimulante)
		{
			if (estimulado == ParteDelCuerpoHumano.bocaInterno)
			{
				return this.ProfundidadToleranciaGetterFacial(estimulado, estimulante);
			}
			if (estimulado == ParteDelCuerpoHumano.ano)
			{
				return this.ProfundidadToleranciaGetterAnal(estimulado, estimulante);
			}
			if (estimulado != ParteDelCuerpoHumano.vag)
			{
				throw new ArgumentOutOfRangeException(estimulado.ToString());
			}
			return this.ProfundidadToleranciaGetterVaginal(estimulado, estimulante);
		}

		// Token: 0x06001298 RID: 4760 RVA: 0x00058BB8 File Offset: 0x00056DB8
		public RangeValueV2 GetRangeDeVelocidadDeAutoSex(ParteDelCuerpoHumano estimulado, ParteQuePuedeEstimular estimulante)
		{
			if (estimulado == ParteDelCuerpoHumano.bocaInterno)
			{
				return this.VelocidadToleranciaFacial(estimulado, estimulante);
			}
			if (estimulado == ParteDelCuerpoHumano.ano)
			{
				return this.VelocidadToleranciaAnal(estimulado, estimulante);
			}
			if (estimulado != ParteDelCuerpoHumano.vag)
			{
				throw new ArgumentOutOfRangeException(estimulado.ToString());
			}
			return this.VelocidadToleranciaVag(estimulado, estimulante);
		}

		// Token: 0x06001299 RID: 4761 RVA: 0x00058BF8 File Offset: 0x00056DF8
		public bool EsConsentido(ParteDelCuerpoHumano estimulado, ParteQuePuedeEstimular estimulante, out float offsetModTactil, out float offsetModPenetracion)
		{
			if (estimulado == ParteDelCuerpoHumano.bocaInterno)
			{
				return this.EsConsentidoFacial(estimulante, out offsetModTactil, out offsetModPenetracion);
			}
			if (estimulado == ParteDelCuerpoHumano.ano)
			{
				return this.EsConsentidoAnal(estimulante, out offsetModTactil, out offsetModPenetracion);
			}
			if (estimulado != ParteDelCuerpoHumano.vag)
			{
				throw new ArgumentOutOfRangeException(estimulado.ToString());
			}
			return this.EsConsentidoVaginal(estimulante, out offsetModTactil, out offsetModPenetracion);
		}

		// Token: 0x0600129A RID: 4762 RVA: 0x00058C4C File Offset: 0x00056E4C
		private bool EsConsentidoFacial(ParteQuePuedeEstimular estimulante, out float offsetModTactil, out float offsetModPenetracion)
		{
			bool flag;
			try
			{
				AutoSexRangosDeToleranciaCalculador.m_PArtesTactilesTEMP.Add(ParteDelCuerpoHumano.labios);
				AutoSexRangosDeToleranciaCalculador.m_PArtesTactilesTEMP.Add(ParteDelCuerpoHumano.bocaInterno);
				AutoSexRangosDeToleranciaCalculador.m_PArtesTactilesTEMP.Add(ParteDelCuerpoHumano.lengua);
				AutoSexRangosDeToleranciaCalculador.EsConsentidoGetter(this.m_ConsentNecesario, estimulante, AutoSexRangosDeToleranciaCalculador.m_PArtesTactilesTEMP, ParteDelCuerpoHumano.bocaInterno, out offsetModTactil, out offsetModPenetracion);
				flag = offsetModTactil >= 1f && offsetModPenetracion >= 1f;
			}
			finally
			{
				AutoSexRangosDeToleranciaCalculador.m_PArtesTactilesTEMP.Clear();
			}
			return flag;
		}

		// Token: 0x0600129B RID: 4763 RVA: 0x00058CC8 File Offset: 0x00056EC8
		private bool EsConsentidoVaginal(ParteQuePuedeEstimular estimulante, out float offsetModTactil, out float offsetModPenetracion)
		{
			bool flag;
			try
			{
				AutoSexRangosDeToleranciaCalculador.m_PArtesTactilesTEMP.Add(ParteDelCuerpoHumano.labiosVaginales);
				AutoSexRangosDeToleranciaCalculador.m_PArtesTactilesTEMP.Add(ParteDelCuerpoHumano.vag);
				AutoSexRangosDeToleranciaCalculador.EsConsentidoGetter(this.m_ConsentNecesario, estimulante, AutoSexRangosDeToleranciaCalculador.m_PArtesTactilesTEMP, ParteDelCuerpoHumano.vag, out offsetModTactil, out offsetModPenetracion);
				flag = offsetModTactil >= 1f && offsetModPenetracion >= 1f;
			}
			finally
			{
				AutoSexRangosDeToleranciaCalculador.m_PArtesTactilesTEMP.Clear();
			}
			return flag;
		}

		// Token: 0x0600129C RID: 4764 RVA: 0x00058D3C File Offset: 0x00056F3C
		private bool EsConsentidoAnal(ParteQuePuedeEstimular estimulante, out float offsetModTactil, out float offsetModPenetracion)
		{
			bool flag;
			try
			{
				AutoSexRangosDeToleranciaCalculador.m_PArtesTactilesTEMP.Add(ParteDelCuerpoHumano.nalgas);
				AutoSexRangosDeToleranciaCalculador.m_PArtesTactilesTEMP.Add(ParteDelCuerpoHumano.ano);
				AutoSexRangosDeToleranciaCalculador.EsConsentidoGetter(this.m_ConsentNecesario, estimulante, AutoSexRangosDeToleranciaCalculador.m_PArtesTactilesTEMP, ParteDelCuerpoHumano.ano, out offsetModTactil, out offsetModPenetracion);
				flag = offsetModTactil >= 1f && offsetModPenetracion >= 1f;
			}
			finally
			{
				AutoSexRangosDeToleranciaCalculador.m_PArtesTactilesTEMP.Clear();
			}
			return flag;
		}

		// Token: 0x0600129D RID: 4765 RVA: 0x00058DB0 File Offset: 0x00056FB0
		private RangeValueV2 VelocidadToleranciaFacial(ParteDelCuerpoHumano estimulado, ParteQuePuedeEstimular estimulante)
		{
			RangeValueV2 rangeValueV;
			try
			{
				AutoSexRangosDeToleranciaCalculador.m_PArtesTactilesTEMP.Add(ParteDelCuerpoHumano.labios);
				AutoSexRangosDeToleranciaCalculador.m_PArtesTactilesTEMP.Add(ParteDelCuerpoHumano.bocaInterno);
				AutoSexRangosDeToleranciaCalculador.m_PArtesTactilesTEMP.Add(ParteDelCuerpoHumano.lengua);
				FemalePenetracionTipo femalePenetracionTipo = FemalePenetracionTipo.facial;
				rangeValueV = AutoSexRangosDeToleranciaCalculador.VelocidadToleranciaGetter(this.m_IBocaHole.worldScaleReal, estimulante, AutoSexRangosDeToleranciaCalculador.m_PArtesTactilesTEMP, femalePenetracionTipo, this.m_DolorPorToques, this.m_DolorPorGolpes, this.m_DolorPorPenetracion, this.m_PlacerPorToques, this.m_PlacerPorPenetraciones);
			}
			finally
			{
				AutoSexRangosDeToleranciaCalculador.m_PArtesTactilesTEMP.Clear();
			}
			return rangeValueV;
		}

		// Token: 0x0600129E RID: 4766 RVA: 0x00058E38 File Offset: 0x00057038
		private RangeValueV2 VelocidadToleranciaVag(ParteDelCuerpoHumano estimulado, ParteQuePuedeEstimular estimulante)
		{
			RangeValueV2 rangeValueV;
			try
			{
				AutoSexRangosDeToleranciaCalculador.m_PArtesTactilesTEMP.Add(ParteDelCuerpoHumano.labiosVaginales);
				AutoSexRangosDeToleranciaCalculador.m_PArtesTactilesTEMP.Add(ParteDelCuerpoHumano.vag);
				rangeValueV = AutoSexRangosDeToleranciaCalculador.VelocidadToleranciaGetter(this.m_IVagHole.worldScaleReal, estimulante, AutoSexRangosDeToleranciaCalculador.m_PArtesTactilesTEMP, FemalePenetracionTipo.vag, this.m_DolorPorToques, this.m_DolorPorGolpes, this.m_DolorPorPenetracion, this.m_PlacerPorToques, this.m_PlacerPorPenetraciones);
			}
			finally
			{
				AutoSexRangosDeToleranciaCalculador.m_PArtesTactilesTEMP.Clear();
			}
			return rangeValueV;
		}

		// Token: 0x0600129F RID: 4767 RVA: 0x00058EB4 File Offset: 0x000570B4
		private RangeValueV2 VelocidadToleranciaAnal(ParteDelCuerpoHumano estimulado, ParteQuePuedeEstimular estimulante)
		{
			RangeValueV2 rangeValueV;
			try
			{
				AutoSexRangosDeToleranciaCalculador.m_PArtesTactilesTEMP.Add(ParteDelCuerpoHumano.nalgas);
				AutoSexRangosDeToleranciaCalculador.m_PArtesTactilesTEMP.Add(ParteDelCuerpoHumano.ano);
				rangeValueV = AutoSexRangosDeToleranciaCalculador.VelocidadToleranciaGetter(this.m_IAnusHole.worldScaleReal, estimulante, AutoSexRangosDeToleranciaCalculador.m_PArtesTactilesTEMP, FemalePenetracionTipo.anus, this.m_DolorPorToques, this.m_DolorPorGolpes, this.m_DolorPorPenetracion, this.m_PlacerPorToques, this.m_PlacerPorPenetraciones);
			}
			finally
			{
				AutoSexRangosDeToleranciaCalculador.m_PArtesTactilesTEMP.Clear();
			}
			return rangeValueV;
		}

		// Token: 0x060012A0 RID: 4768 RVA: 0x00058F30 File Offset: 0x00057130
		private RangeValueV2 ProfundidadToleranciaGetterFacial(ParteDelCuerpoHumano estimulado, ParteQuePuedeEstimular estimulante)
		{
			return AutoSexRangosDeToleranciaCalculador.ProfundidadToleranciaGetter(this.m_IBocaHole, estimulante, FemalePenetracionTipo.facial, this.m_DolorPorPenetracion, this.m_PlacerPorPenetraciones, AutoSexRangosDeToleranciaCalculador.IgnoraHardPointsResistencia(FemalePenetracionTipo.facial, this.m_RespiracionEngine));
		}

		// Token: 0x060012A1 RID: 4769 RVA: 0x00058F57 File Offset: 0x00057157
		private RangeValueV2 ProfundidadToleranciaGetterVaginal(ParteDelCuerpoHumano estimulado, ParteQuePuedeEstimular estimulante)
		{
			return AutoSexRangosDeToleranciaCalculador.ProfundidadToleranciaGetter(this.m_IVagHole, estimulante, FemalePenetracionTipo.vag, this.m_DolorPorPenetracion, this.m_PlacerPorPenetraciones, AutoSexRangosDeToleranciaCalculador.IgnoraHardPointsResistencia(FemalePenetracionTipo.vag, this.m_RespiracionEngine));
		}

		// Token: 0x060012A2 RID: 4770 RVA: 0x00058F7E File Offset: 0x0005717E
		private RangeValueV2 ProfundidadToleranciaGetterAnal(ParteDelCuerpoHumano estimulado, ParteQuePuedeEstimular estimulante)
		{
			return AutoSexRangosDeToleranciaCalculador.ProfundidadToleranciaGetter(this.m_IAnusHole, estimulante, FemalePenetracionTipo.anus, this.m_DolorPorPenetracion, this.m_PlacerPorPenetraciones, AutoSexRangosDeToleranciaCalculador.IgnoraHardPointsResistencia(FemalePenetracionTipo.anus, this.m_RespiracionEngine));
		}

		// Token: 0x060012A3 RID: 4771 RVA: 0x00058FA8 File Offset: 0x000571A8
		private static void EsConsentidoGetter(ConsentNecesario consentNecesario, ParteQuePuedeEstimular estimulante, IReadOnlyList<ParteDelCuerpoHumano> partesTactiles, ParteDelCuerpoHumano parteCoital, out float offsetModTactil, out float offsetModPenetracion)
		{
			if (partesTactiles.Count == 0)
			{
				throw new NotSupportedException("siempre se necesita una parte tactil para añadir a tolerancias");
			}
			float num;
			consentNecesario.EsConsentidoConJerarquia(TipoDeEstimulo.coital, DireccionDeEstimulo.recibida, parteCoital, estimulante, out offsetModPenetracion, out num, 1f, null, null, null);
			float num2;
			consentNecesario.EsConsentidoConJerarquia(TipoDeEstimulo.tactil, DireccionDeEstimulo.recibida, partesTactiles[0], estimulante, out offsetModTactil, out num2, 1f, null, null, null);
			for (int i = 1; i < partesTactiles.Count; i++)
			{
				ParteDelCuerpoHumano parteDelCuerpoHumano = partesTactiles[i];
				float num3;
				float num4;
				consentNecesario.EsConsentidoConJerarquia(TipoDeEstimulo.tactil, DireccionDeEstimulo.recibida, parteDelCuerpoHumano, estimulante, out num3, out num4, 1f, null, null, null);
				offsetModTactil = Mathf.Min(num3, offsetModTactil);
			}
		}

		// Token: 0x060012A4 RID: 4772 RVA: 0x00059054 File Offset: 0x00057254
		private static RangeValueV2 VelocidadToleranciaGetter(float holeScale, ParteQuePuedeEstimular estimulante, IReadOnlyList<ParteDelCuerpoHumano> partesTactiles, FemalePenetracionTipo tipoDePenetracio, DolorPorToques dolorPorToques, DolorPorGolpes dolorPorGolpes, DolorPorPenetracion dolorPorPenetracion, PlacerPorToques placerPorToques, PlacerPorPenetraciones placerPorPenetraciones)
		{
			EmocionesFemeninasValues emocionesFemeninasValues = default(EmocionesFemeninasValues);
			if (partesTactiles.Count == 0)
			{
				throw new NotSupportedException("siempre se necesita una parte tactil para añadir a tolerancias");
			}
			RangeValueV2 rangeValueV;
			UmbralBasico.Estado estado;
			UmbralBasico.Estado estado2;
			float num;
			UmbralBasico.TipoDeCambio tipoDeCambio;
			dolorPorToques.SimularGlobal(estimulante, partesTactiles[0], 1f, out rangeValueV, out estado, out estado2, out num, out tipoDeCambio, null);
			for (int i = 1; i < partesTactiles.Count; i++)
			{
				RangeValueV2 rangeValueV2;
				dolorPorToques.SimularGlobal(estimulante, partesTactiles[i], 1f, out rangeValueV2, out estado, out estado2, out num, out tipoDeCambio, null);
				rangeValueV = RangeValueV2.JoinRanges(ref rangeValueV, ref rangeValueV2);
			}
			RangeValueV2 rangeValueV3;
			dolorPorToques.SimularGlobal(estimulante, partesTactiles[0], 1f, out rangeValueV3, out estado, out estado2, out num, out tipoDeCambio, null);
			for (int j = 1; j < partesTactiles.Count; j++)
			{
				RangeValueV2 rangeValueV4;
				dolorPorGolpes.SimularGlobal(estimulante, partesTactiles[j], 1f, out rangeValueV4, out estado, out estado2, out num, out tipoDeCambio, null);
				rangeValueV3 = RangeValueV2.JoinRanges(ref rangeValueV3, ref rangeValueV4);
			}
			RangeValueV2 rangeValueV5 = RangeValueV2.TryNew(Mathf.Min(rangeValueV.min, rangeValueV3.min), Mathf.Max(rangeValueV.max, rangeValueV3.max), 0.1f, 0.001f);
			rangeValueV5 = RangeValueV2.Scale(ref rangeValueV5, 1f / holeScale);
			RangeValueV2 rangeValueV6;
			dolorPorPenetracion.SimularPenetracion(tipoDePenetracio, 1f, out rangeValueV6, ref emocionesFemeninasValues);
			RangeValueV2 rangeValueV7 = RangeValueV2.JoinRanges(ref rangeValueV5, ref rangeValueV6);
			RangeValueV2 rangeValueV8;
			placerPorToques.SimularGlobal(estimulante, partesTactiles[0], 1f, out rangeValueV8, out estado, out estado2, out num, out tipoDeCambio, null);
			for (int k = 1; k < partesTactiles.Count; k++)
			{
				RangeValueV2 rangeValueV9;
				placerPorToques.SimularGlobal(estimulante, partesTactiles[k], 1f, out rangeValueV9, out estado, out estado2, out num, out tipoDeCambio, null);
				rangeValueV8 = RangeValueV2.JoinRanges(ref rangeValueV8, ref rangeValueV9);
			}
			rangeValueV8 = RangeValueV2.Scale(ref rangeValueV8, 1f / holeScale);
			RangeValueV2 rangeValueV10;
			placerPorPenetraciones.SimularPenetracion(tipoDePenetracio, 1f, out rangeValueV10, ref emocionesFemeninasValues);
			RangeValueV2 rangeValueV11 = RangeValueV2.JoinRanges(ref rangeValueV8, ref rangeValueV10);
			return RangeValueV2.OverlapRangesConPrioridad(ref rangeValueV11, ref rangeValueV7);
		}

		// Token: 0x060012A5 RID: 4773 RVA: 0x00059267 File Offset: 0x00057467
		private static bool IgnoraHardPointsResistencia(FemalePenetracionTipo tipoDePenetracio, RespiracionEngine respiracionEngine)
		{
			if (tipoDePenetracio <= FemalePenetracionTipo.vag)
			{
				return false;
			}
			if (tipoDePenetracio != FemalePenetracionTipo.facial)
			{
				throw new ArgumentOutOfRangeException(tipoDePenetracio.ToString());
			}
			return AutoSexRangosDeToleranciaCalculador.IgnoraHardPointsResistencia(respiracionEngine);
		}

		// Token: 0x060012A6 RID: 4774 RVA: 0x00059290 File Offset: 0x00057490
		private static bool IgnoraHardPointsResistencia(RespiracionEngine respiracionEngine)
		{
			switch (respiracionEngine.cansancioEstado)
			{
			case CanzancioEstado.descanzado:
			case CanzancioEstado.estaCanzandonse:
				return false;
			case CanzancioEstado.canzado:
			case CanzancioEstado.estaDescanzandose:
				return true;
			default:
				throw new ArgumentOutOfRangeException(respiracionEngine.cansancioEstado.ToString());
			}
		}

		// Token: 0x060012A7 RID: 4775 RVA: 0x000592DC File Offset: 0x000574DC
		private static RangeValueV2 ProfundidadToleranciaGetter(IHole hole, ParteQuePuedeEstimular estimulante, FemalePenetracionTipo tipoDePenetracio, DolorPorPenetracion dolorPorPenetracion, PlacerPorPenetraciones placerPorPenetraciones, bool ignoraHardPointsResistencia)
		{
			EmocionesFemeninasValues emocionesFemeninasValues = default(EmocionesFemeninasValues);
			RangeValueV2 rangeValueV = placerPorPenetraciones.ObtenerRangoDeProfundidad(tipoDePenetracio, ref emocionesFemeninasValues, true);
			RangeValueV2 rangeValueV2 = dolorPorPenetracion.ObtenerRangoDeProfundidad(tipoDePenetracio, ref emocionesFemeninasValues, true);
			RangeValueV2 rangeValueV3 = RangeValueV2.OverlapRangesConPrioridad(ref rangeValueV, ref rangeValueV2);
			float num = float.MaxValue;
			for (int i = 0; i < hole.hardPointsList.Count; i++)
			{
				HoleVirtualHardPoint holeVirtualHardPoint = hole.hardPointsList[i];
				if (ignoraHardPointsResistencia || holeVirtualHardPoint.resistenciaMod > 0f)
				{
					float localRadiusFromInternals = holeVirtualHardPoint.GetLocalRadiusFromInternals();
					float num2 = holeVirtualHardPoint.GetProfundidadLocalFromInternals() - localRadiusFromInternals * 1.2f;
					if (num2 > 0f && num2 < num)
					{
						num = num2;
					}
				}
			}
			rangeValueV3.CapMax(num, 0.01f);
			return rangeValueV3;
		}

		// Token: 0x04000D8A RID: 3466
		private DolorPorPenetracion m_DolorPorPenetracion;

		// Token: 0x04000D8B RID: 3467
		private PlacerPorPenetraciones m_PlacerPorPenetraciones;

		// Token: 0x04000D8C RID: 3468
		private DolorPorToques m_DolorPorToques;

		// Token: 0x04000D8D RID: 3469
		private DolorPorGolpes m_DolorPorGolpes;

		// Token: 0x04000D8E RID: 3470
		private PlacerPorToques m_PlacerPorToques;

		// Token: 0x04000D8F RID: 3471
		private RespiracionEngine m_RespiracionEngine;

		// Token: 0x04000D90 RID: 3472
		private ConsentNecesario m_ConsentNecesario;

		// Token: 0x04000D91 RID: 3473
		private IBocaHole m_IBocaHole;

		// Token: 0x04000D92 RID: 3474
		private IVagHole m_IVagHole;

		// Token: 0x04000D93 RID: 3475
		private IAnusHole m_IAnusHole;

		// Token: 0x04000D94 RID: 3476
		private static List<ParteDelCuerpoHumano> m_PArtesTactilesTEMP = new List<ParteDelCuerpoHumano>();
	}
}
