using System;
using System.Collections;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.BeachGirl.Runtime.Penes;
using Assets._ReusableScripts.CuchiCuchi;
using UnityEngine;

namespace Assets.Productos.Juegos.Reception.Scripts.Penises
{
	// Token: 0x0200009A RID: 154
	public class ModPenisRigidezPorCheats : CustomMonobehaviour
	{
		// Token: 0x0600030F RID: 783 RVA: 0x00010EAB File Offset: 0x0000F0AB
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

		// Token: 0x06000310 RID: 784 RVA: 0x00010EDE File Offset: 0x0000F0DE
		protected override IEnumerator YieldStartUnityEvent()
		{
			while (this.m_PeneRigidesModificable == null)
			{
				Penis componentEnRoot = this.GetComponentEnRoot(true);
				this.m_PeneRigidesModificable = ((componentEnRoot != null) ? componentEnRoot.GetComponent<PeneRigidesModificable>() : null);
				if (this.m_PeneRigidesModificable == null)
				{
					yield return null;
				}
			}
			this.m_Mod = this.m_PeneRigidesModificable.modificable.ObtenerModificadorNotNull(this);
			yield break;
		}

		// Token: 0x06000311 RID: 785 RVA: 0x00010EED File Offset: 0x0000F0ED
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			if (base.isStared && this.m_PeneRigidesModificable != null)
			{
				this.m_Mod = this.m_PeneRigidesModificable.modificable.ObtenerModificadorNotNull(this);
			}
		}

		// Token: 0x06000312 RID: 786 RVA: 0x00010F22 File Offset: 0x0000F122
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			ModificadorDeFloat mod = this.m_Mod;
			if (mod == null)
			{
				return;
			}
			mod.TryRemoverDeOwner(true);
		}

		// Token: 0x06000313 RID: 787 RVA: 0x00010F3D File Offset: 0x0000F13D
		private IEnumerator CheckRutine()
		{
			yield return new WaitForSeconds(Random.value);
			WaitForSeconds w = new WaitForSeconds(1f);
			for (;;)
			{
				if (this.m_Mod != null)
				{
					if (!Singleton<ConfiguracionGeneralDeCheats>.IsInScene)
					{
						this.m_Mod.valor.valor = 1f;
					}
					else
					{
						this.m_Mod.valor.valor = Singleton<ConfiguracionGeneralDeCheats>.instance.penisRigidezMod;
					}
				}
				yield return w;
			}
			yield break;
		}

		// Token: 0x0400015A RID: 346
		[ReadOnlyUI]
		[SerializeField]
		private ModificadorDeFloat m_Mod;

		// Token: 0x0400015B RID: 347
		private CoroutineCapsule m_checker;

		// Token: 0x0400015C RID: 348
		private PeneRigidesModificable m_PeneRigidesModificable;
	}
}
