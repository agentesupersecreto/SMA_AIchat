using System;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos
{
	// Token: 0x0200050F RID: 1295
	public sealed class DisminucionPorAumentoDeRageODolor : CalculoDeEstimuloEnFrame<DisminucionPorAumentoDeRageODolor.Configuracion>
	{
		// Token: 0x17000857 RID: 2135
		// (get) Token: 0x06001F57 RID: 8023 RVA: 0x00004252 File Offset: 0x00002452
		public override TipoDeEstimulo tipoDeEstimulo
		{
			get
			{
				return TipoDeEstimulo.None;
			}
		}

		// Token: 0x06001F58 RID: 8024 RVA: 0x0002591B File Offset: 0x00023B1B
		protected override float GetNextCoolDown()
		{
			return 0f;
		}

		// Token: 0x17000858 RID: 2136
		// (get) Token: 0x06001F59 RID: 8025 RVA: 0x00006060 File Offset: 0x00004260
		[Obsolete("", true)]
		public ICalculoDeEstimulo calculoMasFuerteBase
		{
			get
			{
				return null;
			}
		}

		// Token: 0x17000859 RID: 2137
		// (get) Token: 0x06001F5A RID: 8026 RVA: 0x00004252 File Offset: 0x00002452
		[Obsolete("", true)]
		public override bool puedeSerUsadoPorAI
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700085A RID: 2138
		// (get) Token: 0x06001F5B RID: 8027 RVA: 0x00004252 File Offset: 0x00002452
		[Obsolete("", true)]
		public bool estimuloExisteEnFrame
		{
			get
			{
				return false;
			}
		}

		// Token: 0x06001F5C RID: 8028 RVA: 0x0007658C File Offset: 0x0007478C
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_rage = this.m_emocionesDeOwner.rage;
			this.m_dolor = this.m_emocionesDeOwner.dolor;
			ICalculadorDeEstimuloOnCalculoCallback[] componentsInChildren = this.m_rage.GetComponentsInChildren<ICalculadorDeEstimuloOnCalculoCallback>();
			ICalculadorDeEstimuloOnCalculoCallback[] componentsInChildren2 = this.m_dolor.GetComponentsInChildren<ICalculadorDeEstimuloOnCalculoCallback>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].generadoFrame += this.DisminucionPorAumentoDeRage_calculadoTotalDeFrame;
			}
			for (int j = 0; j < componentsInChildren2.Length; j++)
			{
				componentsInChildren2[j].generadoFrame += this.DisminucionPorAumentoDeDolor_calculadoTotalDeFrame;
			}
		}

		// Token: 0x06001F5D RID: 8029 RVA: 0x00076620 File Offset: 0x00074820
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			Rage rage = this.m_rage;
			ICalculadorDeEstimuloOnCalculoCallback[] array = ((rage != null) ? rage.GetComponentsInChildren<ICalculadorDeEstimuloOnCalculoCallback>() : null);
			Dolor dolor = this.m_dolor;
			ICalculadorDeEstimuloOnCalculoCallback[] array2 = ((dolor != null) ? dolor.GetComponentsInChildren<ICalculadorDeEstimuloOnCalculoCallback>() : null);
			if (array != null)
			{
				foreach (ICalculadorDeEstimuloOnCalculoCallback calculadorDeEstimuloOnCalculoCallback in array)
				{
					if (calculadorDeEstimuloOnCalculoCallback != null)
					{
						calculadorDeEstimuloOnCalculoCallback.generadoFrame -= this.DisminucionPorAumentoDeRage_calculadoTotalDeFrame;
					}
				}
			}
			if (array2 != null)
			{
				foreach (ICalculadorDeEstimuloOnCalculoCallback calculadorDeEstimuloOnCalculoCallback2 in array2)
				{
					if (calculadorDeEstimuloOnCalculoCallback2 != null)
					{
						calculadorDeEstimuloOnCalculoCallback2.generadoFrame -= this.DisminucionPorAumentoDeDolor_calculadoTotalDeFrame;
					}
				}
			}
		}

		// Token: 0x06001F5E RID: 8030 RVA: 0x000766B6 File Offset: 0x000748B6
		private void DisminucionPorAumentoDeRage_calculadoTotalDeFrame(float generadoNoLimitado, float generadoLimitado, ICalculadorDeEstimulo sender)
		{
			this.m_calculadoresEnFrameConvinado_Rage += generadoNoLimitado;
		}

		// Token: 0x06001F5F RID: 8031 RVA: 0x000766C6 File Offset: 0x000748C6
		private void DisminucionPorAumentoDeDolor_calculadoTotalDeFrame(float generadoNoLimitado, float generadoLimitado, ICalculadorDeEstimulo sender)
		{
			this.m_calculadoresEnFrameConvinado_Dolor += generadoNoLimitado;
		}

		// Token: 0x06001F60 RID: 8032 RVA: 0x00005F51 File Offset: 0x00004151
		protected override bool EmocionPadreEsValida(Emocion emo)
		{
			return true;
		}

		// Token: 0x06001F61 RID: 8033 RVA: 0x00003B39 File Offset: 0x00001D39
		protected sealed override void Updating(float deltaTime)
		{
		}

		// Token: 0x06001F62 RID: 8034 RVA: 0x000766D8 File Offset: 0x000748D8
		protected sealed override void DoUpdate(ref float generadoNoLimitado, ref float generadoLimitado, ref float cambiarValorDeEmocionDespuesDeTiempoMod, float deltaTime)
		{
			try
			{
				if (base.emo.value.total > 0f)
				{
					float num = this.m_emocionesDeOwner.dolor.valueChangedAmountMayorAZero * this.config.disminucionPorDolor + this.m_emocionesDeOwner.rage.valueChangedAmountMayorAZero * this.config.disminucionPorRage;
					float num2 = this.m_calculadoresEnFrameConvinado_Dolor * this.config.disminucionPorDolor + this.m_calculadoresEnFrameConvinado_Rage * this.config.disminucionPorRage;
					generadoNoLimitado = (generadoLimitado = -Mathf.Max(num, num2));
				}
			}
			finally
			{
				this.m_calculadoresEnFrameConvinado_Rage = (this.m_calculadoresEnFrameConvinado_Dolor = 0f);
			}
		}

		// Token: 0x040014AE RID: 5294
		private Rage m_rage;

		// Token: 0x040014AF RID: 5295
		private Dolor m_dolor;

		// Token: 0x040014B0 RID: 5296
		[ReadOnlyUI]
		[SerializeField]
		private float m_calculadoresEnFrameConvinado_Rage;

		// Token: 0x040014B1 RID: 5297
		[ReadOnlyUI]
		[SerializeField]
		private float m_calculadoresEnFrameConvinado_Dolor;

		// Token: 0x02000510 RID: 1296
		[Serializable]
		public class Configuracion
		{
			// Token: 0x040014B2 RID: 5298
			public float disminucionPorDolor = 0.15f;

			// Token: 0x040014B3 RID: 5299
			public float disminucionPorRage = 0.25f;
		}
	}
}
