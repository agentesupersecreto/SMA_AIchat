using System;
using System.Collections;
using Assets.Productos.Juegos.Reception.Scripts.Genetica.Eventos;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.BeachGirl.Runtime.Penes;
using Assets._ReusableScripts.CuchiCuchi;
using UnityEngine;

namespace Assets.Productos.Juegos.Reception.Scripts.Penises
{
	// Token: 0x0200009B RID: 155
	[Obsolete("ya nivel no da tamaño de pene", true)]
	public class ModPenisSizePerLvl : CustomMonobehaviour
	{
		// Token: 0x06000315 RID: 789 RVA: 0x00010F54 File Offset: 0x0000F154
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_checker = new CoroutineCapsule(this.CheckRutine(), this, new CoroutineCapsuleConfig
			{
				autoRestart = true,
				autoStart = true
			});
			base.SetYieldStart();
		}

		// Token: 0x06000316 RID: 790 RVA: 0x00010F87 File Offset: 0x0000F187
		protected override IEnumerator YieldStartUnityEvent()
		{
			while (this.m_PeneSizeModificable == null)
			{
				Penis componentEnRoot = this.GetComponentEnRoot(true);
				this.m_PeneSizeModificable = ((componentEnRoot != null) ? componentEnRoot.GetComponent<PeneSizeModificable>() : null);
				if (this.m_PeneSizeModificable == null)
				{
					yield return null;
				}
			}
			this.m_largoMod = this.m_PeneSizeModificable.sizeModificable.ObtenerModificadorNotNull(this);
			yield break;
		}

		// Token: 0x06000317 RID: 791 RVA: 0x00010F96 File Offset: 0x0000F196
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			if (base.isStared && this.m_PeneSizeModificable != null)
			{
				this.m_largoMod = this.m_PeneSizeModificable.sizeModificable.ObtenerModificadorNotNull(this);
			}
		}

		// Token: 0x06000318 RID: 792 RVA: 0x00010FCB File Offset: 0x0000F1CB
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			ModificadorDeFloat largoMod = this.m_largoMod;
			if (largoMod == null)
			{
				return;
			}
			largoMod.TryRemoverDeOwner(true);
		}

		// Token: 0x06000319 RID: 793 RVA: 0x00010FE6 File Offset: 0x0000F1E6
		private IEnumerator CheckRutine()
		{
			yield return new WaitForSeconds(Random.value * 3f);
			WaitForSeconds w = new WaitForSeconds(33f);
			for (;;)
			{
				if (this.m_largoMod != null)
				{
					if (!Singleton<PiscinasDeEventosDeEntrevista>.IsInScene)
					{
						this.m_largoMod.valor.valor = 1f;
					}
					else
					{
						float num = ((float)Singleton<PiscinasDeEventosDeEntrevista>.instance.GetNivelIgnorandoInicial() - 1f) / this.lvlInterval;
						this.m_largoMod.valor.valor = 1f + num * this.modPerLvlAmount;
					}
				}
				yield return w;
			}
			yield break;
		}

		// Token: 0x0400015D RID: 349
		public float lvlInterval = 0.1f;

		// Token: 0x0400015E RID: 350
		public float modPerLvlAmount = 0.006065f;

		// Token: 0x0400015F RID: 351
		[ReadOnlyUI]
		[SerializeField]
		private ModificadorDeFloat m_largoMod;

		// Token: 0x04000160 RID: 352
		private CoroutineCapsule m_checker;

		// Token: 0x04000161 RID: 353
		private PeneSizeModificable m_PeneSizeModificable;
	}
}
