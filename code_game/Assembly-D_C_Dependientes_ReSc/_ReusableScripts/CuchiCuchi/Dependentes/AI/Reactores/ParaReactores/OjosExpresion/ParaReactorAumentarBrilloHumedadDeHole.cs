using System;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.Controladores;
using Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.ParaReactores.OjosExpresion
{
	// Token: 0x02000303 RID: 771
	public sealed class ParaReactorAumentarBrilloHumedadDeHole : ParaReactor
	{
		// Token: 0x06001388 RID: 5000 RVA: 0x0005B266 File Offset: 0x00059466
		protected override void ResetUnityEvent()
		{
			base.ResetUnityEvent();
		}

		// Token: 0x06001389 RID: 5001 RVA: 0x0005B7F8 File Offset: 0x000599F8
		protected sealed override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.GetComponentEnRoot(ref this.m_ControlladorBrilloPorPlacer, false);
			if (this.m_ControlladorBrilloPorPlacer == null)
			{
				throw new ArgumentNullException("m_ControlladorBrilloPorPlacer", "m_ControlladorBrilloPorPlacer null reference.");
			}
			this.m_FemaleSimpleAi = this.GetComponentEnCharacter(false);
			if (this.m_FemaleSimpleAi == null)
			{
				throw new ArgumentNullException("m_FemaleSimpleAi", "m_FemaleSimpleAi null reference.");
			}
			this.m_minValorVag = this.m_ControlladorBrilloPorPlacer.minVagWeight.ObtenerModificadorNotNull(this);
			this.m_minValorAnus = this.m_ControlladorBrilloPorPlacer.minAnusWeight.ObtenerModificadorNotNull(this);
		}

		// Token: 0x0600138A RID: 5002 RVA: 0x0005B88F File Offset: 0x00059A8F
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			ModificadorDeFloat minValorVag = this.m_minValorVag;
			if (minValorVag != null)
			{
				minValorVag.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat minValorAnus = this.m_minValorAnus;
			if (minValorAnus == null)
			{
				return;
			}
			minValorAnus.TryRemoverDeOwner(true);
		}

		// Token: 0x0600138B RID: 5003 RVA: 0x00006DC5 File Offset: 0x00004FC5
		protected sealed override float ModificadorDeCoolDown(object arg)
		{
			return 1f;
		}

		// Token: 0x0600138C RID: 5004 RVA: 0x00006DC5 File Offset: 0x00004FC5
		protected override float ModificadorDeProbabilidadPorSegundo(object arg)
		{
			return 1f;
		}

		// Token: 0x0600138D RID: 5005 RVA: 0x0005B8C0 File Offset: 0x00059AC0
		protected sealed override bool ReaccionarArgumento(object arg)
		{
			int num = this.m_FemaleSimpleAi.SemenSobreCantidadAny(ParteDelCuerpoHumano.vag, Side.none);
			int num2 = this.m_FemaleSimpleAi.SemenSobreCantidadAny(ParteDelCuerpoHumano.ano, Side.none);
			num += this.m_FemaleSimpleAi.SemenSobreCantidad(ParteDelCuerpoHumano.vag, TipoDeSemen.lubricante, Side.none) * 10;
			num2 += this.m_FemaleSimpleAi.SemenSobreCantidad(ParteDelCuerpoHumano.ano, TipoDeSemen.lubricante, Side.none) * 10;
			num = Mathf.Max(num, this.m_minParticulasEnVag);
			num2 = Mathf.Max(num2, this.m_minParticulasEnAno);
			this.m_minValorVag.valor.valor = Mathf.InverseLerp(0f, 750f, (float)num);
			this.m_minValorAnus.valor.valor = Mathf.InverseLerp(0f, 400f, (float)num2);
			this.m_minParticulasEnVag = Mathf.Max(this.m_minParticulasEnVag, num / 3);
			this.m_minParticulasEnAno = Mathf.Max(this.m_minParticulasEnAno, num2 / 3);
			return true;
		}

		// Token: 0x04000E1A RID: 3610
		private int m_minParticulasEnAno;

		// Token: 0x04000E1B RID: 3611
		private int m_minParticulasEnVag;

		// Token: 0x04000E1C RID: 3612
		private FemaleSimpleAi m_FemaleSimpleAi;

		// Token: 0x04000E1D RID: 3613
		private ControlladorBrilloPorPlacer m_ControlladorBrilloPorPlacer;

		// Token: 0x04000E1E RID: 3614
		[SerializeReference]
		private ModificadorDeFloat m_minValorVag;

		// Token: 0x04000E1F RID: 3615
		[SerializeReference]
		private ModificadorDeFloat m_minValorAnus;
	}
}
