using System;
using System.Collections;
using Assets.Base.Plugins.Runtime;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.Pro.Entrevista.Runtime.General.Memoria;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Characters;
using Assets._ReusableScripts.CuchiCuchi.Ropa;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.General
{
	// Token: 0x020000B1 RID: 177
	public class MaleMoneySetter : CustomMonobehaviour
	{
		// Token: 0x0600067C RID: 1660 RVA: 0x00025A4C File Offset: 0x00023C4C
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.IMaleCharAtributos = this.GetComponentEnCharacter(false);
			if (this.IMaleCharAtributos == null)
			{
				throw new ArgumentNullException("IMaleCharAtributos", "IMaleCharAtributos null reference.");
			}
			this.m_self = base.GetComponentInParent<Character>();
			if (this.m_self == null)
			{
				throw new ArgumentNullException("m_self", "m_self null reference.");
			}
			this.m_ropa = this.m_self.GetComponentInChildren<IRopaManager>();
			if (this.m_ropa == null)
			{
				throw new ArgumentNullException("m_ropa", "m_ropa null reference.");
			}
			this.m_Coroutine = new CoroutineCapsule(this.UpdateMoneyRutine(), this, new CoroutineCapsuleConfig
			{
				autoRestart = true,
				autoStart = true
			});
			base.SetYieldStart();
		}

		// Token: 0x0600067D RID: 1661 RVA: 0x00025B02 File Offset: 0x00023D02
		protected override IEnumerator YieldStartUnityEvent()
		{
			while (!this.m_self.isStared)
			{
				yield return null;
			}
			this.m_esGameMainCharacter = this.m_self.ID_Unico == Singleton<CollecionDeCharacteresIDs>.instance.mainID.ToGuid();
			this.m_outfitAdder = this.IMaleCharAtributos.sumadorDePorcentageOutfit.ObtenerModificadorNotNull(this);
			if (this.m_esGameMainCharacter)
			{
				this.m_officedder = this.IMaleCharAtributos.sumadorDePorcentageUbicacion.ObtenerModificadorNotNull(this);
			}
			yield break;
		}

		// Token: 0x0600067E RID: 1662 RVA: 0x00025B14 File Offset: 0x00023D14
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			if (base.isStared)
			{
				this.m_outfitAdder = this.IMaleCharAtributos.sumadorDePorcentageOutfit.ObtenerModificadorNotNull(this);
				if (this.m_esGameMainCharacter)
				{
					this.m_officedder = this.IMaleCharAtributos.sumadorDePorcentageUbicacion.ObtenerModificadorNotNull(this);
				}
			}
		}

		// Token: 0x0600067F RID: 1663 RVA: 0x00025B65 File Offset: 0x00023D65
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			ModificadorDeFloat outfitAdder = this.m_outfitAdder;
			if (outfitAdder != null)
			{
				outfitAdder.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat officedder = this.m_officedder;
			if (officedder == null)
			{
				return;
			}
			officedder.TryRemoverDeOwner(true);
		}

		// Token: 0x06000680 RID: 1664 RVA: 0x00025B93 File Offset: 0x00023D93
		private IEnumerator UpdateMoneyRutine()
		{
			WaitForSeconds w = new WaitForSeconds(5f);
			for (;;)
			{
				yield return w;
				float num = 0f;
				for (int i = 0; i < this.m_ropa.piezasPuestas.Count; i++)
				{
					MapaDeRopa.RopaData dataDeRopa = this.m_ropa.piezasPuestas[i].dataDeRopa;
					num += (float)dataDeRopa.itemQuality;
				}
				ItemQuality itemQuality = (ItemQuality)Mathf.RoundToInt(num / (float)this.m_ropa.piezasPuestas.Count);
				this.m_outfitAdder.valor.valor = Mathf.Lerp(0f, 100f, Mathf.InverseLerp(6f, 10f, (float)itemQuality));
				if (this.m_esGameMainCharacter)
				{
					this.m_officedder.valor.valor = Mathf.Lerp(0f, 100f, Mathf.InverseLerp(0f, 4f, (float)MemoriaDeSMAGamePlay.GetCurrentOfficeLvl()));
				}
			}
			yield break;
		}

		// Token: 0x040003F5 RID: 1013
		private CoroutineCapsule m_Coroutine;

		// Token: 0x040003F6 RID: 1014
		private IMaleCharAtributos IMaleCharAtributos;

		// Token: 0x040003F7 RID: 1015
		[SerializeField]
		private ModificadorDeFloat m_outfitAdder;

		// Token: 0x040003F8 RID: 1016
		[SerializeField]
		private ModificadorDeFloat m_officedder;

		// Token: 0x040003F9 RID: 1017
		private Character m_self;

		// Token: 0x040003FA RID: 1018
		private bool m_esGameMainCharacter;

		// Token: 0x040003FB RID: 1019
		private IRopaManager m_ropa;
	}
}
