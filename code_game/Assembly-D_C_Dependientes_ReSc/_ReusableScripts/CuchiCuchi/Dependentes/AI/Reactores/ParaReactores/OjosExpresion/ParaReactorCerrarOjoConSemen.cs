using System;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos;
using Assets._ReusableScripts.CuchiCuchi.Controllers.Ojos.Parpadeos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.ParaReactores.OjosExpresion
{
	// Token: 0x02000300 RID: 768
	public sealed class ParaReactorCerrarOjoConSemen : ParaReactor
	{
		// Token: 0x06001373 RID: 4979 RVA: 0x0005B266 File Offset: 0x00059466
		protected override void ResetUnityEvent()
		{
			base.ResetUnityEvent();
		}

		// Token: 0x06001374 RID: 4980 RVA: 0x0005B270 File Offset: 0x00059470
		protected sealed override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_Controllador = this.GetComponentEnCharacter(false);
			this.m_FemaleSimpleAi = this.GetComponentEnCharacter(false);
			if (this.m_Controllador == null)
			{
				throw new ArgumentNullException("m_Controllador", "m_Controllador null reference.");
			}
			if (this.m_FemaleSimpleAi == null)
			{
				throw new ArgumentNullException("m_FemaleSimpleAi", "m_FemaleSimpleAi null reference.");
			}
		}

		// Token: 0x06001375 RID: 4981 RVA: 0x00006DC5 File Offset: 0x00004FC5
		protected sealed override float ModificadorDeCoolDown(object arg)
		{
			return 1f;
		}

		// Token: 0x06001376 RID: 4982 RVA: 0x00006DC5 File Offset: 0x00004FC5
		protected override float ModificadorDeProbabilidadPorSegundo(object arg)
		{
			return 1f;
		}

		// Token: 0x06001377 RID: 4983 RVA: 0x0005B2DC File Offset: 0x000594DC
		protected sealed override bool ReaccionarArgumento(object arg)
		{
			bool flag = this.m_FemaleSimpleAi.SemenSobreAny(ParteDelCuerpoHumano.globosOculares, Side.L);
			bool flag2 = this.m_FemaleSimpleAi.SemenSobreAny(ParteDelCuerpoHumano.globosOculares, Side.R);
			flag |= this.m_FemaleSimpleAi.SemenSobreAny(ParteDelCuerpoHumano.ojos, Side.L);
			flag2 |= this.m_FemaleSimpleAi.SemenSobreAny(ParteDelCuerpoHumano.ojos, Side.R);
			OjosExpresionController.Tipo? tipo;
			OjosExpresionController.Tipo? tipo2;
			float num;
			float num2;
			this.DecidirExpresiones(flag, flag2, out tipo, out tipo2, out num, out num2);
			bool flag3 = false;
			if (tipo != null)
			{
				flag3 |= this.m_Controllador.Cambiar(tipo.Value, -1, this.m_duracion, ControllerPrioridadConfig.prioridad, num * 100f, this.tiempoModIn, this.tiempoModOut);
			}
			if (tipo2 != null)
			{
				flag3 |= this.m_Controllador.Cambiar(tipo2.Value, -1, this.m_duracion, ControllerPrioridadConfig.prioridad, num2 * 100f, this.tiempoModIn, this.tiempoModOut);
			}
			return flag3;
		}

		// Token: 0x06001378 RID: 4984 RVA: 0x0005B3B8 File Offset: 0x000595B8
		private void DecidirExpresiones(bool semenSobreL, bool semenSobreR, out OjosExpresionController.Tipo? l, out OjosExpresionController.Tipo? r, out float lw, out float rw)
		{
			l = null;
			r = null;
			lw = 0f;
			rw = 0f;
			if (semenSobreL && semenSobreR)
			{
				l = new OjosExpresionController.Tipo?(OjosExpresionController.Tipo.guiñarL);
				r = new OjosExpresionController.Tipo?(OjosExpresionController.Tipo.guiñarR);
				lw = 1f;
				rw = 0.2f;
				return;
			}
			if (semenSobreL)
			{
				l = new OjosExpresionController.Tipo?(OjosExpresionController.Tipo.guiñarL);
				lw = 1f;
			}
			if (semenSobreR)
			{
				r = new OjosExpresionController.Tipo?(OjosExpresionController.Tipo.guiñarR);
				rw = 1f;
			}
		}

		// Token: 0x04000E09 RID: 3593
		private OjosExpresionController m_Controllador;

		// Token: 0x04000E0A RID: 3594
		private FemaleSimpleAi m_FemaleSimpleAi;

		// Token: 0x04000E0B RID: 3595
		[SerializeField]
		private float m_duracion = 5f;

		// Token: 0x04000E0C RID: 3596
		public float tiempoModIn = 1f;

		// Token: 0x04000E0D RID: 3597
		public float tiempoModOut = 1f;
	}
}
