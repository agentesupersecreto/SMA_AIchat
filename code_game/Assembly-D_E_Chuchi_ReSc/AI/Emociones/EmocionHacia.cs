using System;
using System.Collections;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones
{
	// Token: 0x02000414 RID: 1044
	[RequireComponent(typeof(Emocion))]
	public class EmocionHacia : CustomMonobehaviour
	{
		// Token: 0x060016F6 RID: 5878 RVA: 0x0005E6F0 File Offset: 0x0005C8F0
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_Emo = base.GetComponent<Emocion>();
			this.m_Character = this.GetComponentEnRoot(false);
			this.m_sumadorDeValorEmoMod = this.m_Emo.sumadorDeValor.ObtenerModificadorNotNull(this);
			this.m_multiplicadorDeValorEmoMod = this.m_Emo.multiplicadorDeValor.ObtenerModificadorNotNull(this);
			this.m_minimoLimiteValorEmoMod = this.m_Emo.minimoLimiteValorSumado.ObtenerModificadorNotNull(this);
			this.m_maximoLimiteValorEmoMod = this.m_Emo.maximoLimiteValor.ObtenerModificadorNotNull(this);
			this.m_sumadorDeAumentoEmoMod = this.m_Emo.sumadorDeAumento.ObtenerModificadorNotNull(this);
			this.m_multiplicadorDeAumentoEmoMod = this.m_Emo.multiplicadorDeAumento.ObtenerModificadorNotNull(this);
			this.m_CoroutineCapsule = new CoroutineCapsule(this.UpdateEmocionHaciaRutine(), this, new CoroutineCapsuleConfig
			{
				autoRestart = true,
				autoStart = true
			});
		}

		// Token: 0x060016F7 RID: 5879 RVA: 0x0005E7CB File Offset: 0x0005C9CB
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.ResetEmocionMods();
		}

		// Token: 0x060016F8 RID: 5880 RVA: 0x0005E7DC File Offset: 0x0005C9DC
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			ModificadorDeFloat sumadorDeValorEmoMod = this.m_sumadorDeValorEmoMod;
			if (sumadorDeValorEmoMod != null)
			{
				sumadorDeValorEmoMod.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat multiplicadorDeValorEmoMod = this.m_multiplicadorDeValorEmoMod;
			if (multiplicadorDeValorEmoMod != null)
			{
				multiplicadorDeValorEmoMod.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat minimoLimiteValorEmoMod = this.m_minimoLimiteValorEmoMod;
			if (minimoLimiteValorEmoMod != null)
			{
				minimoLimiteValorEmoMod.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat maximoLimiteValorEmoMod = this.m_maximoLimiteValorEmoMod;
			if (maximoLimiteValorEmoMod != null)
			{
				maximoLimiteValorEmoMod.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat sumadorDeAumentoEmoMod = this.m_sumadorDeAumentoEmoMod;
			if (sumadorDeAumentoEmoMod != null)
			{
				sumadorDeAumentoEmoMod.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat multiplicadorDeAumentoEmoMod = this.m_multiplicadorDeAumentoEmoMod;
			if (multiplicadorDeAumentoEmoMod == null)
			{
				return;
			}
			multiplicadorDeAumentoEmoMod.TryRemoverDeOwner(true);
		}

		// Token: 0x060016F9 RID: 5881 RVA: 0x0005E861 File Offset: 0x0005CA61
		private IEnumerator UpdateEmocionHaciaRutine()
		{
			WaitForSeconds w = new WaitForSeconds(2f.Random(0.2f));
			for (;;)
			{
				yield return w;
				this.UpdateEmocionHaciaTipo();
				this.UpdateEmocionHaciaMods();
			}
			yield break;
		}

		// Token: 0x060016FA RID: 5882 RVA: 0x0005E870 File Offset: 0x0005CA70
		public void UpdateEmocionHaciaTipo()
		{
			Object @object;
			if (!Singleton<CurrentMainChar>.IsInScene)
			{
				@object = null;
			}
			else
			{
				MainChar main = Singleton<CurrentMainChar>.instance.main;
				@object = ((main != null) ? main.character : null);
			}
			if (@object != this.m_Character)
			{
				this.m_tipo = EmocionHacia.Tipo.ToMainChar;
				return;
			}
			this.m_tipo = EmocionHacia.Tipo.ToMainTarget;
		}

		// Token: 0x060016FB RID: 5883 RVA: 0x0005E8B0 File Offset: 0x0005CAB0
		public void UpdateEmocionHaciaMods()
		{
			switch (this.m_tipo)
			{
			case EmocionHacia.Tipo.None:
				this.ResetEmocionMods();
				return;
			case EmocionHacia.Tipo.ToMainChar:
			{
				Character character;
				if (!Singleton<CurrentMainChar>.IsInScene)
				{
					character = null;
				}
				else
				{
					MainChar main = Singleton<CurrentMainChar>.instance.main;
					character = ((main != null) ? main.character : null);
				}
				Character character2 = character;
				EmocionHacia.Hacia hacia;
				if (character2 == null || !this.m_hacias.TryGetValue(character2.ID_UnicoString, out hacia))
				{
					this.ResetEmocionMods();
					return;
				}
				this.SetMods(hacia);
				return;
			}
			case EmocionHacia.Tipo.ToMainTarget:
			{
				Character character3;
				if (!Singleton<CurrentTargetChar>.IsInScene)
				{
					character3 = null;
				}
				else
				{
					TargetChar main2 = Singleton<CurrentTargetChar>.instance.main;
					character3 = ((main2 != null) ? main2.character : null);
				}
				Character character4 = character3;
				EmocionHacia.Hacia hacia2;
				if (character4 == null || !this.m_hacias.TryGetValue(character4.ID_UnicoString, out hacia2))
				{
					this.ResetEmocionMods();
					return;
				}
				this.SetMods(hacia2);
				return;
			}
			default:
				throw new ArgumentOutOfRangeException(this.m_tipo.ToString());
			}
		}

		// Token: 0x060016FC RID: 5884 RVA: 0x0005E998 File Offset: 0x0005CB98
		public EmocionHacia.Hacia GetHaciaNotNull(string haciaID)
		{
			EmocionHacia.Hacia hacia;
			if (!this.m_hacias.TryGetValue(haciaID, out hacia))
			{
				hacia = new EmocionHacia.Hacia();
				hacia.haciaID = haciaID;
				this.m_hacias.Add(haciaID, hacia);
			}
			return hacia;
		}

		// Token: 0x060016FD RID: 5885 RVA: 0x0005E9D0 File Offset: 0x0005CBD0
		public void ResetEmocionMods()
		{
			this.m_sumadorDeValorEmoMod.valor.valor = 0f;
			this.m_multiplicadorDeValorEmoMod.valor.valor = 1f;
			this.m_minimoLimiteValorEmoMod.valor.valor = float.MinValue;
			this.m_maximoLimiteValorEmoMod.valor.valor = float.MaxValue;
			this.m_sumadorDeAumentoEmoMod.valor.valor = 0f;
			this.m_multiplicadorDeAumentoEmoMod.valor.valor = 1f;
		}

		// Token: 0x060016FE RID: 5886 RVA: 0x0005EA5C File Offset: 0x0005CC5C
		private void SetMods(EmocionHacia.Hacia hacia)
		{
			this.m_sumadorDeValorEmoMod.valor.valor = hacia.sumadorDeValor.AdicinarValorIncluyendo(0f);
			this.m_multiplicadorDeValorEmoMod.valor.valor = hacia.multiplicadorDeValor.ModificarValor(1f);
			this.m_minimoLimiteValorEmoMod.valor.valor = hacia.minimoLimiteValor.MaximoValorIncluyendo(float.MinValue);
			this.m_maximoLimiteValorEmoMod.valor.valor = hacia.maximoLimiteValor.MinimoValorIncluyendo(float.MaxValue);
			this.m_sumadorDeAumentoEmoMod.valor.valor = hacia.sumadorDeAumento.AdicinarValorIncluyendo(0f);
			this.m_multiplicadorDeAumentoEmoMod.valor.valor = hacia.multiplicadorDeAumento.ModificarValor(1f);
		}

		// Token: 0x060016FF RID: 5887 RVA: 0x0005EB2C File Offset: 0x0005CD2C
		public float EstimadoPara(string para)
		{
			float num = 0f;
			EmocionHacia.Hacia hacia;
			if (!this.m_hacias.TryGetValue(para, out hacia))
			{
				return num;
			}
			num = hacia.sumadorDeValor.AdicinarValorIncluyendo(0f);
			num = hacia.multiplicadorDeValor.ModificarValor(num);
			return Mathf.Clamp(num, hacia.minimoLimiteValor.MaximoValorIncluyendo(float.MinValue), hacia.maximoLimiteValor.MinimoValorIncluyendo(float.MaxValue));
		}

		// Token: 0x040011D8 RID: 4568
		[SerializeField]
		private EmocionHacia.Tipo m_tipo;

		// Token: 0x040011D9 RID: 4569
		private CoroutineCapsule m_CoroutineCapsule;

		// Token: 0x040011DA RID: 4570
		[SerializeField]
		private ModificadorDeFloat m_sumadorDeValorEmoMod;

		// Token: 0x040011DB RID: 4571
		[SerializeField]
		private ModificadorDeFloat m_multiplicadorDeValorEmoMod;

		// Token: 0x040011DC RID: 4572
		[SerializeField]
		private ModificadorDeFloat m_minimoLimiteValorEmoMod;

		// Token: 0x040011DD RID: 4573
		[SerializeField]
		private ModificadorDeFloat m_maximoLimiteValorEmoMod;

		// Token: 0x040011DE RID: 4574
		[SerializeField]
		private ModificadorDeFloat m_sumadorDeAumentoEmoMod;

		// Token: 0x040011DF RID: 4575
		[SerializeField]
		private ModificadorDeFloat m_multiplicadorDeAumentoEmoMod;

		// Token: 0x040011E0 RID: 4576
		private Emocion m_Emo;

		// Token: 0x040011E1 RID: 4577
		private Character m_Character;

		// Token: 0x040011E2 RID: 4578
		private Dictionary<string, EmocionHacia.Hacia> m_hacias = new Dictionary<string, EmocionHacia.Hacia>();

		// Token: 0x040011E3 RID: 4579
		[SerializeField]
		private List<EmocionHacia.Hacia> m_haciasDEBUG = new List<EmocionHacia.Hacia>();

		// Token: 0x02000415 RID: 1045
		[Serializable]
		public class Hacia
		{
			// Token: 0x170005C7 RID: 1479
			// (get) Token: 0x06001701 RID: 5889 RVA: 0x0005EBB3 File Offset: 0x0005CDB3
			public ModificableDeFloat sumadorDeValor
			{
				get
				{
					return this.m_sumadorDeValor;
				}
			}

			// Token: 0x170005C8 RID: 1480
			// (get) Token: 0x06001702 RID: 5890 RVA: 0x0005EBBB File Offset: 0x0005CDBB
			public ModificableDeFloat multiplicadorDeValor
			{
				get
				{
					return this.m_multiplicadorDeValor;
				}
			}

			// Token: 0x170005C9 RID: 1481
			// (get) Token: 0x06001703 RID: 5891 RVA: 0x0005EBC3 File Offset: 0x0005CDC3
			public ModificableDeFloat minimoLimiteValor
			{
				get
				{
					return this.m_minimoLimiteValor;
				}
			}

			// Token: 0x170005CA RID: 1482
			// (get) Token: 0x06001704 RID: 5892 RVA: 0x0005EBCB File Offset: 0x0005CDCB
			public ModificableDeFloat maximoLimiteValor
			{
				get
				{
					return this.m_maximoLimiteValor;
				}
			}

			// Token: 0x170005CB RID: 1483
			// (get) Token: 0x06001705 RID: 5893 RVA: 0x0005EBD3 File Offset: 0x0005CDD3
			public ModificableDeFloat sumadorDeAumento
			{
				get
				{
					return this.m_sumadorDeAumento;
				}
			}

			// Token: 0x170005CC RID: 1484
			// (get) Token: 0x06001706 RID: 5894 RVA: 0x0005EBDB File Offset: 0x0005CDDB
			public ModificableDeFloat multiplicadorDeAumento
			{
				get
				{
					return this.m_multiplicadorDeAumento;
				}
			}

			// Token: 0x040011E4 RID: 4580
			public string haciaID;

			// Token: 0x040011E5 RID: 4581
			[SerializeField]
			private ModificableDeFloat m_sumadorDeValor = new ModificableDeFloat(0f);

			// Token: 0x040011E6 RID: 4582
			[SerializeField]
			private ModificableDeFloat m_multiplicadorDeValor = new ModificableDeFloat(1f);

			// Token: 0x040011E7 RID: 4583
			[SerializeField]
			private ModificableDeFloat m_minimoLimiteValor = new ModificableDeFloat(float.MinValue);

			// Token: 0x040011E8 RID: 4584
			[SerializeField]
			private ModificableDeFloat m_maximoLimiteValor = new ModificableDeFloat(float.MaxValue);

			// Token: 0x040011E9 RID: 4585
			[SerializeField]
			private ModificableDeFloat m_sumadorDeAumento = new ModificableDeFloat(0f);

			// Token: 0x040011EA RID: 4586
			[SerializeField]
			private ModificableDeFloat m_multiplicadorDeAumento = new ModificableDeFloat(1f);
		}

		// Token: 0x02000416 RID: 1046
		public enum Tipo
		{
			// Token: 0x040011EC RID: 4588
			None,
			// Token: 0x040011ED RID: 4589
			ToMainChar,
			// Token: 0x040011EE RID: 4590
			ToMainTarget
		}
	}
}
