using System;
using System.Collections;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers
{
	// Token: 0x02000473 RID: 1139
	[RequireComponent(typeof(Emocion))]
	public class EmocionAuraReceiver : CustomMonobehaviour
	{
		// Token: 0x06001913 RID: 6419 RVA: 0x00066894 File Offset: 0x00064A94
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_Emo = base.GetComponent<Emocion>();
			this.m_Character = this.GetComponentEnRoot(false);
			this.m_sumadorDeValorEmoMod = this.m_Emo.sumadorDeValor.ObtenerModificadorNotNull(this);
			this.m_multiplicadorDeValorEmoMod = this.m_Emo.multiplicadorDeValor.ObtenerModificadorNotNull(this);
			this.m_sumadorDeAumentoEmoMod = this.m_Emo.sumadorDeAumento.ObtenerModificadorNotNull(this);
			this.m_multiplicadorDeAumentoEmoMod = this.m_Emo.multiplicadorDeAumento.ObtenerModificadorNotNull(this);
			this.m_CoroutineCapsule = new CoroutineCapsule(this.UpdateEmocionHaciaRutine(), this, new CoroutineCapsuleConfig
			{
				autoRestart = true,
				autoStart = true
			});
			Singleton<CurrentMainChar>.instance.changed += this.CurrentMainCharChanged;
			Singleton<CurrentTargetChar>.instance.changed += this.CurrentTargetCharChanged;
		}

		// Token: 0x06001914 RID: 6420 RVA: 0x0006696D File Offset: 0x00064B6D
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.ResetEmocionMods();
		}

		// Token: 0x06001915 RID: 6421 RVA: 0x0006697C File Offset: 0x00064B7C
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

		// Token: 0x06001916 RID: 6422 RVA: 0x000669DB File Offset: 0x00064BDB
		private void CurrentMainCharChanged(MainChar nuevo, MainChar viejo, CurrentMainChar sender)
		{
			this.UpdateAuraReceiver();
		}

		// Token: 0x06001917 RID: 6423 RVA: 0x000669DB File Offset: 0x00064BDB
		private void CurrentTargetCharChanged(TargetChar nuevo, TargetChar viejo, CurrentTargetChar sender)
		{
			this.UpdateAuraReceiver();
		}

		// Token: 0x06001918 RID: 6424 RVA: 0x000669E3 File Offset: 0x00064BE3
		private IEnumerator UpdateEmocionHaciaRutine()
		{
			yield return new WaitForSeconds(5f.Random(0.2f));
			this.UpdateAuraReceiver();
			WaitForSeconds w2 = new WaitForSeconds(60f.Random(0.2f));
			for (;;)
			{
				yield return w2;
				this.UpdateAuraReceiver();
			}
			yield break;
		}

		// Token: 0x06001919 RID: 6425 RVA: 0x000669F2 File Offset: 0x00064BF2
		public void UpdateAuraReceiver()
		{
			this.UpdateEmocionAuraFromTipo();
			this.UpdateEmocionAuraMods();
		}

		// Token: 0x0600191A RID: 6426 RVA: 0x00066A00 File Offset: 0x00064C00
		public void UpdateEmocionAuraFromTipo()
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
				this.m_tipo = EmocionAuraReceiver.Tipo.ToMainChar;
				return;
			}
			this.m_tipo = EmocionAuraReceiver.Tipo.ToMainTarget;
		}

		// Token: 0x0600191B RID: 6427 RVA: 0x00066A40 File Offset: 0x00064C40
		public void UpdateEmocionAuraMods()
		{
			switch (this.m_tipo)
			{
			case EmocionAuraReceiver.Tipo.None:
				this.ResetEmocionMods();
				return;
			case EmocionAuraReceiver.Tipo.ToMainChar:
			{
				object obj;
				if (!Singleton<CurrentMainChar>.IsInScene)
				{
					obj = null;
				}
				else
				{
					MainChar main = Singleton<CurrentMainChar>.instance.main;
					obj = ((main != null) ? main.character : null);
				}
				object obj2 = obj;
				EmocionesHumanasBase emocionesHumanasBase = ((obj2 != null) ? obj2.GetComponentEnRoot<EmocionesHumanasBase>() : null);
				EmocionAuraProducer emocionAuraProducer = ((emocionesHumanasBase != null) ? emocionesHumanasBase.GetComponentNotNull<EmocionAuraProducer>() : null);
				EmocionAuraProducer.Aura aura = ((emocionAuraProducer != null) ? emocionAuraProducer.GetAura(this.m_Emo.reaccion) : null);
				if (aura == null)
				{
					this.ResetEmocionMods();
					return;
				}
				this.SetMods(aura);
				return;
			}
			case EmocionAuraReceiver.Tipo.ToMainTarget:
			{
				object obj3;
				if (!Singleton<CurrentTargetChar>.IsInScene)
				{
					obj3 = null;
				}
				else
				{
					TargetChar main2 = Singleton<CurrentTargetChar>.instance.main;
					obj3 = ((main2 != null) ? main2.character : null);
				}
				object obj4 = obj3;
				EmocionesHumanasBase emocionesHumanasBase2 = ((obj4 != null) ? obj4.GetComponentEnRoot<EmocionesHumanasBase>() : null);
				EmocionAuraProducer emocionAuraProducer2 = ((emocionesHumanasBase2 != null) ? emocionesHumanasBase2.GetComponentNotNull<EmocionAuraProducer>() : null);
				EmocionAuraProducer.Aura aura2 = ((emocionAuraProducer2 != null) ? emocionAuraProducer2.GetAura(this.m_Emo.reaccion) : null);
				if (aura2 == null)
				{
					this.ResetEmocionMods();
					return;
				}
				this.SetMods(aura2);
				return;
			}
			default:
				throw new ArgumentOutOfRangeException(this.m_tipo.ToString());
			}
		}

		// Token: 0x0600191C RID: 6428 RVA: 0x00066B4C File Offset: 0x00064D4C
		private void SetMods(EmocionAuraProducer.Aura aura)
		{
			this.m_sumadorDeValorEmoMod.valor.valor = aura.sumadorDeValor.AdicinarValorIncluyendo(0f);
			this.m_multiplicadorDeValorEmoMod.valor.valor = aura.multiplicadorDeValor.ModificarValor(1f);
			this.m_sumadorDeAumentoEmoMod.valor.valor = aura.sumadorDeAumento.AdicinarValorIncluyendo(0f);
			this.m_multiplicadorDeAumentoEmoMod.valor.valor = aura.multiplicadorDeAumento.ModificarValor(1f);
		}

		// Token: 0x0600191D RID: 6429 RVA: 0x00066BDC File Offset: 0x00064DDC
		public void ResetEmocionMods()
		{
			this.m_sumadorDeValorEmoMod.valor.valor = 0f;
			this.m_multiplicadorDeValorEmoMod.valor.valor = 1f;
			this.m_sumadorDeAumentoEmoMod.valor.valor = 0f;
			this.m_multiplicadorDeAumentoEmoMod.valor.valor = 1f;
		}

		// Token: 0x040012FA RID: 4858
		[SerializeField]
		private EmocionAuraReceiver.Tipo m_tipo;

		// Token: 0x040012FB RID: 4859
		private CoroutineCapsule m_CoroutineCapsule;

		// Token: 0x040012FC RID: 4860
		[SerializeField]
		private ModificadorDeFloat m_sumadorDeValorEmoMod;

		// Token: 0x040012FD RID: 4861
		[SerializeField]
		private ModificadorDeFloat m_multiplicadorDeValorEmoMod;

		// Token: 0x040012FE RID: 4862
		[SerializeField]
		private ModificadorDeFloat m_sumadorDeAumentoEmoMod;

		// Token: 0x040012FF RID: 4863
		[SerializeField]
		private ModificadorDeFloat m_multiplicadorDeAumentoEmoMod;

		// Token: 0x04001300 RID: 4864
		private Emocion m_Emo;

		// Token: 0x04001301 RID: 4865
		private Character m_Character;

		// Token: 0x02000474 RID: 1140
		public enum Tipo
		{
			// Token: 0x04001303 RID: 4867
			None,
			// Token: 0x04001304 RID: 4868
			ToMainChar,
			// Token: 0x04001305 RID: 4869
			ToMainTarget
		}
	}
}
