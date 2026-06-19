using System;
using Assets.Base.RootMotion.BeachGirl.Runtime.Controllers.SexoAt;
using Assets.TValle.BeachGirl;
using Assets.TValle.BeachGirl.Sexual;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;
using Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.Sexuales;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.Orales
{
	// Token: 0x02000371 RID: 881
	public class ReactorSexAtPorSerPenetrada : ReactorACalculoDeEstimulo<ICalculoDeEstimuloCoitalHole>
	{
		// Token: 0x060015F1 RID: 5617 RVA: 0x00065CF6 File Offset: 0x00063EF6
		protected override void ResetUnityEvent()
		{
			base.ResetUnityEvent();
			this.baseConfig.unIntentoDeReaccionPorFrame = true;
		}

		// Token: 0x060015F2 RID: 5618 RVA: 0x00068780 File Offset: 0x00066980
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_ConsentForzado = this.GetComponentEnRoot(false);
			if (this.m_ConsentForzado == null)
			{
				throw new ArgumentNullException("m_ConsentForzado", "m_ConsentForzado null reference.");
			}
			this.m_SexoAtController = this.GetComponentEnRoot(false);
			if (this.m_SexoAtController == null)
			{
				throw new ArgumentNullException("m_SexoAtController", "m_SexoAtController null reference.");
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
			this.m_ICharacter = this.GetComponentEnRoot(false);
			if (this.m_ICharacter == null)
			{
				throw new ArgumentNullException("m_ICharacter", "m_ICharacter null reference.");
			}
			this.m_paraPeneVag = base.GetComponentInParent<PeneVaginalSexScore>();
			this.m_paraDedoVag = base.GetComponentInParent<DedoVaginalSexScore>();
			this.m_paraPeneAnal = base.GetComponentInParent<PeneAnalSexScore>();
			this.m_paraDedoAnal = base.GetComponentInParent<DedoAnalSexScore>();
		}

		// Token: 0x060015F3 RID: 5619 RVA: 0x00068888 File Offset: 0x00066A88
		protected override bool CalculoEsValido(ICalculoDeEstimuloCoitalHole calculo)
		{
			if (calculo.estimuloBasico.tipo != DireccionDeEstimulo.recibida)
			{
				return false;
			}
			if (!this.m_IVagHole.isPenetrated && !this.m_IAnusHole.isPenetrated)
			{
				return false;
			}
			ParteDelCuerpoHumano parteDelCuerpoHumano = calculo.PartePrincipalEstimulada(false);
			return (parteDelCuerpoHumano == ParteDelCuerpoHumano.vag || parteDelCuerpoHumano == ParteDelCuerpoHumano.ano) && calculo.estimuloBasico.estimulante is IPeneConPartes;
		}

		// Token: 0x060015F4 RID: 5620 RVA: 0x00006DC5 File Offset: 0x00004FC5
		protected override float CoolDownModificadorParaCalculo(ICalculoDeEstimuloCoitalHole calculo)
		{
			return 1f;
		}

		// Token: 0x060015F5 RID: 5621 RVA: 0x00006DC5 File Offset: 0x00004FC5
		protected override float ProbabilidadPorSegundoModificadorParaCalculo(ICalculoDeEstimuloCoitalHole calculo)
		{
			return 1f;
		}

		// Token: 0x060015F6 RID: 5622 RVA: 0x000688EC File Offset: 0x00066AEC
		protected override bool ReaccionarCalculo(ICalculoDeEstimuloCoitalHole calculo)
		{
			MaleChar maleChar = (MaleChar)MainChar.instance.character;
			Component estimulante = calculo.estimulo.estimulante;
			int num = this.prioridadParaConstroller;
			bool isPenetrated = this.m_IVagHole.isPenetrated;
			FemalePenetracionTipo femalePenetracionTipo = (isPenetrated ? FemalePenetracionTipo.vag : FemalePenetracionTipo.anus);
			IPeneConPartes pene;
			AutoSexScore.Resultados resultados;
			if (maleChar.ObjetoEsMiPene(estimulante))
			{
				pene = (IPeneConPartes)estimulante;
				if (isPenetrated)
				{
					this.m_paraPeneVag.DoUpdate((IPeneConPartes)estimulante, calculo);
					resultados = this.m_paraPeneVag.resultados;
				}
				else
				{
					this.m_paraPeneAnal.DoUpdate((IPeneConPartes)estimulante, calculo);
					resultados = this.m_paraPeneAnal.resultados;
				}
			}
			else if (maleChar.ObjetoEsMiDedo(estimulante))
			{
				pene = (IPeneConPartes)estimulante;
				if (isPenetrated)
				{
					this.m_paraDedoVag.DoUpdate((IPeneConPartes)estimulante, calculo);
					resultados = this.m_paraDedoVag.resultados;
				}
				else
				{
					this.m_paraDedoAnal.DoUpdate((IPeneConPartes)estimulante, calculo);
					resultados = this.m_paraDedoAnal.resultados;
				}
			}
			else
			{
				if (maleChar.ObjetoEsProp(estimulante.transform))
				{
					Debug.LogException(new NotImplementedException(), this);
					return false;
				}
				return false;
			}
			if (resultados.scoreV2 == 0f)
			{
				return false;
			}
			if (resultados.scoreV2 < 0f && resultados.penetracionEsConsentida)
			{
				return false;
			}
			float num2 = 1f;
			LookAtControllerV2.LookAtType lookAtType;
			if (resultados.scoreV2 > 0f)
			{
				lookAtType = LookAtControllerV2.LookAtType.fijamente;
			}
			else
			{
				if (this.m_ConsentForzado.EsCorrupted(calculo))
				{
					num2 = 0.1f;
				}
				float value = Random.value;
				if (value < 0.16666f)
				{
					lookAtType = LookAtControllerV2.LookAtType.evadirL;
				}
				else if (value < 0.3333f)
				{
					lookAtType = LookAtControllerV2.LookAtType.evadirR;
				}
				else if (value < 0.5f)
				{
					lookAtType = LookAtControllerV2.LookAtType.evadirRDown;
				}
				else if (value < 0.6666f)
				{
					lookAtType = LookAtControllerV2.LookAtType.evadirLDown;
				}
				else if (value < 0.83326f)
				{
					lookAtType = LookAtControllerV2.LookAtType.evadirLUp;
				}
				else
				{
					lookAtType = LookAtControllerV2.LookAtType.evadirRUp;
				}
			}
			return this.m_SexoAtController.HoleHacia(pene.parteBase, Vector3.zero, null, Vector3.zero, femalePenetracionTipo, resultados.weightTeasing * num2, resultados.proyection, Vector3.zero, lookAtType, true, this.m_smoothTargetVelocityMod, 0.1f, num, (this.baseConfig.coolDownGeneral * 4f).Random(0.15f), ControllerPrioridadConfig.prioridad, delegate(SexoAtController.Orden o)
			{
				if (pene == null || !pene.isActiveAndEnabled)
				{
					return false;
				}
				IHole hole = pene.TryGetPenetratingHole();
				switch (femalePenetracionTipo)
				{
				case FemalePenetracionTipo.anus:
					return hole == this.m_IAnusHole;
				case FemalePenetracionTipo.vag:
					return hole == this.m_IVagHole;
				}
				throw new ArgumentOutOfRangeException(femalePenetracionTipo.ToString());
			});
		}

		// Token: 0x04000FC0 RID: 4032
		private SexoAtController m_SexoAtController;

		// Token: 0x04000FC1 RID: 4033
		private IVagHole m_IVagHole;

		// Token: 0x04000FC2 RID: 4034
		private IAnusHole m_IAnusHole;

		// Token: 0x04000FC3 RID: 4035
		public int prioridadParaConstroller = 200;

		// Token: 0x04000FC4 RID: 4036
		private ICharacter m_ICharacter;

		// Token: 0x04000FC5 RID: 4037
		private PeneVaginalSexScore m_paraPeneVag;

		// Token: 0x04000FC6 RID: 4038
		private DedoVaginalSexScore m_paraDedoVag;

		// Token: 0x04000FC7 RID: 4039
		private PeneAnalSexScore m_paraPeneAnal;

		// Token: 0x04000FC8 RID: 4040
		private DedoAnalSexScore m_paraDedoAnal;

		// Token: 0x04000FC9 RID: 4041
		[SerializeField]
		private float m_smoothTargetVelocityMod = 0.85f;

		// Token: 0x04000FCA RID: 4042
		private ConsentCorrupted m_ConsentForzado;
	}
}
