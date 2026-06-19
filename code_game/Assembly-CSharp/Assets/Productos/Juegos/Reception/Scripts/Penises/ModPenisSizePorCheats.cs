using System;
using System.Collections;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.BeachGirl.Runtime.Penes;
using Assets._ReusableScripts.CuchiCuchi;
using UnityEngine;

namespace Assets.Productos.Juegos.Reception.Scripts.Penises
{
	// Token: 0x0200009C RID: 156
	public class ModPenisSizePorCheats : CustomMonobehaviour
	{
		// Token: 0x0600031B RID: 795 RVA: 0x00011013 File Offset: 0x0000F213
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

		// Token: 0x0600031C RID: 796 RVA: 0x00011046 File Offset: 0x0000F246
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
			this.m_anchoModMod = this.m_PeneSizeModificable.anchoModModificable.ObtenerModificadorNotNull(this);
			yield break;
		}

		// Token: 0x0600031D RID: 797 RVA: 0x00011058 File Offset: 0x0000F258
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			if (base.isStared && this.m_PeneSizeModificable != null)
			{
				this.m_largoMod = this.m_PeneSizeModificable.sizeModificable.ObtenerModificadorNotNull(this);
				this.m_anchoModMod = this.m_PeneSizeModificable.anchoModModificable.ObtenerModificadorNotNull(this);
			}
		}

		// Token: 0x0600031E RID: 798 RVA: 0x000110AF File Offset: 0x0000F2AF
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			ModificadorDeFloat largoMod = this.m_largoMod;
			if (largoMod != null)
			{
				largoMod.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat anchoModMod = this.m_anchoModMod;
			if (anchoModMod == null)
			{
				return;
			}
			anchoModMod.TryRemoverDeOwner(true);
		}

		// Token: 0x0600031F RID: 799 RVA: 0x000110DD File Offset: 0x0000F2DD
		private IEnumerator CheckRutine()
		{
			yield return new WaitForSeconds(Random.value);
			WaitForSeconds w = new WaitForSeconds(1f);
			for (;;)
			{
				if (this.m_largoMod != null && this.m_anchoModMod != null)
				{
					if (!Singleton<ConfiguracionGeneralDeCheats>.IsInScene)
					{
						this.m_largoMod.valor.valor = (this.m_anchoModMod.valor.valor = 1f);
					}
					else
					{
						this.m_largoMod.valor.valor = Singleton<ConfiguracionGeneralDeCheats>.instance.penisLargoMod;
						this.m_anchoModMod.valor.valor = Singleton<ConfiguracionGeneralDeCheats>.instance.penisAnchoMod;
					}
				}
				yield return w;
			}
			yield break;
		}

		// Token: 0x04000162 RID: 354
		[ReadOnlyUI]
		[SerializeField]
		private ModificadorDeFloat m_largoMod;

		// Token: 0x04000163 RID: 355
		[ReadOnlyUI]
		[SerializeField]
		private ModificadorDeFloat m_anchoModMod;

		// Token: 0x04000164 RID: 356
		private CoroutineCapsule m_checker;

		// Token: 0x04000165 RID: 357
		private PeneSizeModificable m_PeneSizeModificable;
	}
}
