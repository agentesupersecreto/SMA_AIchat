using System;
using System.Collections.Generic;
using Assets.TValle.Tools.Runtime.Characters.Atts.Emotions;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff.Clases;
using Assets._ReusableScripts.CuchiCuchi.Skins;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Penes.BuffAndDebuff
{
	// Token: 0x02000090 RID: 144
	public class JeringaBuffCaster : AplicableBehaviour
	{
		// Token: 0x060005BC RID: 1468 RVA: 0x00021A2F File Offset: 0x0001FC2F
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_jeringa = base.GetComponent<Jeringa>();
			if (this.m_jeringa == null)
			{
				throw new ArgumentNullException("m_jeringa", "m_jeringa null reference.");
			}
		}

		// Token: 0x060005BD RID: 1469 RVA: 0x00021A61 File Offset: 0x0001FC61
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
		}

		// Token: 0x060005BE RID: 1470 RVA: 0x00021A69 File Offset: 0x0001FC69
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_jeringa.OnAplicating += this.M_jeringa_OnAplicating;
		}

		// Token: 0x060005BF RID: 1471 RVA: 0x00021A88 File Offset: 0x0001FC88
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.m_jeringa.OnAplicating -= this.M_jeringa_OnAplicating;
		}

		// Token: 0x060005C0 RID: 1472 RVA: 0x00021AA8 File Offset: 0x0001FCA8
		public void AddBuff(JeringaBuffCaster.BuffDataBase data)
		{
			if (data.isValid)
			{
				this.m_data.Add(data);
			}
		}

		// Token: 0x060005C1 RID: 1473 RVA: 0x00021AC0 File Offset: 0x0001FCC0
		private void M_jeringa_OnAplicating(float aplicatingWeight, HitSkinBasica lastTarget)
		{
			if (lastTarget == null)
			{
				return;
			}
			BuffDeCharacter componentEnRoot = lastTarget.GetComponentEnRoot(false);
			if (componentEnRoot == null)
			{
				return;
			}
			for (int i = 0; i < this.m_data.Count; i++)
			{
				this.m_data[i].Apply(componentEnRoot, aplicatingWeight, this);
			}
		}

		// Token: 0x04000397 RID: 919
		private Jeringa m_jeringa;

		// Token: 0x04000398 RID: 920
		[SerializeReference]
		private List<JeringaBuffCaster.BuffDataBase> m_data = new List<JeringaBuffCaster.BuffDataBase>();

		// Token: 0x02000216 RID: 534
		// (Invoke) Token: 0x06000FDB RID: 4059
		public delegate void UpdateArgumentDataHandler<TArg, TExtraData>(TArg argument, TExtraData extradata, bool justInstantiated, float aplicatingWeight) where TArg : ArgumentoDeEfecto;

		// Token: 0x02000217 RID: 535
		// (Invoke) Token: 0x06000FDF RID: 4063
		public delegate void UpdateBuffConfigHandler<TBuff, TExtraData>(TBuff buff, TExtraData extradata, bool justInstantiated, float aplicatingWeight) where TBuff : BuffEvento;

		// Token: 0x02000218 RID: 536
		[Serializable]
		public class BuffDataForAlteratorFemAppa : JeringaBuffCaster.BuffData<DisplayableBuff, BuffOnAlteratorValueChangeArg, JeringaBuffCaster.BuffDataForAlteratorFemAppa.ExtraData>
		{
			// Token: 0x06000FE2 RID: 4066 RVA: 0x0004D7B0 File Offset: 0x0004B9B0
			public BuffDataForAlteratorFemAppa(string AlteradorID, int Index, float Value, BuffMap.Duracion duracion = null, params string[] extraIDs)
			{
				this.buffID = "Tvalle.Buff.AlteratorFemAppaValueChange";
				this.alteradorID = AlteradorID;
				string text = ((Index >= 0) ? string.Format("[{0}]", Index) : string.Empty);
				string text2 = AlteradorID + text;
				string text3 = BuffMap.GenerateIdSegundaria(extraIDs);
				this.idSegundaria = BuffMap.GenerateIdSegundaria(text2, text3);
				this.argumentUpdater = new JeringaBuffCaster.UpdateArgumentDataHandler<BuffOnAlteratorValueChangeArg, JeringaBuffCaster.BuffDataForAlteratorFemAppa.ExtraData>(this.DefaultUpdateArgumentDatar);
				this.extraData = new JeringaBuffCaster.BuffDataForAlteratorFemAppa.ExtraData
				{
					index = Index,
					value = Value
				};
				if (duracion == null)
				{
					duracion = new BuffMap.Duracion
					{
						infinite = true
					};
				}
				this.duracionOverride = duracion;
			}

			// Token: 0x06000FE3 RID: 4067 RVA: 0x0004D85C File Offset: 0x0004BA5C
			private void DefaultUpdateArgumentDatar(BuffOnAlteratorValueChangeArg argument, JeringaBuffCaster.BuffDataForAlteratorFemAppa.ExtraData extradata, bool justInstantiated, float aplicatingWeight)
			{
				if (!justInstantiated)
				{
					if (argument.alteradorID != this.alteradorID)
					{
						Debug.LogError("argumento tien un id diferente, save game puede estar corrupto");
					}
					if (argument.index != this.extraData.index)
					{
						Debug.LogError("argumento tien un index diferente, save game puede estar corrupto");
					}
				}
				else
				{
					argument.value = 0f;
				}
				argument.alteradorID = this.alteradorID;
				argument.value += this.m_aplicatingWeight * this.extraData.value;
				argument.index = this.extraData.index;
			}

			// Token: 0x04000A1E RID: 2590
			public string alteradorID;

			// Token: 0x020002FB RID: 763
			[Serializable]
			public struct ExtraData
			{
				// Token: 0x04000D63 RID: 3427
				public int index;

				// Token: 0x04000D64 RID: 3428
				public float value;
			}
		}

		// Token: 0x02000219 RID: 537
		[Serializable]
		public class BuffDataForEmotionAdd : JeringaBuffCaster.BuffData<DisplayableBuff, BuffOnEmocionAddArg, JeringaBuffCaster.BuffDataForEmotionAdd.ExtraData>
		{
			// Token: 0x06000FE4 RID: 4068 RVA: 0x0004D8F0 File Offset: 0x0004BAF0
			public BuffDataForEmotionAdd(Emotion emo, float add, BuffMap.Duracion duracion = null, params string[] extraIDs)
			{
				this.buffID = "Tvalle.Buff.EmotionAdd";
				string text = BuffMap.GenerateIdSegundaria(extraIDs);
				this.idSegundaria = BuffMap.GenerateIdSegundaria(emo.ToString(), text);
				this.argumentUpdater = new JeringaBuffCaster.UpdateArgumentDataHandler<BuffOnEmocionAddArg, JeringaBuffCaster.BuffDataForEmotionAdd.ExtraData>(this.DefaultUpdateArgumentDatar);
				this.extraData = new JeringaBuffCaster.BuffDataForEmotionAdd.ExtraData
				{
					emo = emo,
					add = add
				};
				if (duracion == null)
				{
					duracion = new BuffMap.Duracion
					{
						infinite = true
					};
				}
				this.duracionOverride = duracion;
			}

			// Token: 0x06000FE5 RID: 4069 RVA: 0x0004D978 File Offset: 0x0004BB78
			private void DefaultUpdateArgumentDatar(BuffOnEmocionAddArg argument, JeringaBuffCaster.BuffDataForEmotionAdd.ExtraData extradata, bool justInstantiated, float aplicatingWeight)
			{
				if (!justInstantiated)
				{
					if (argument.emo != this.extraData.emo)
					{
						Debug.LogError("argumento tien un id diferente, save game puede estar corrupto");
					}
				}
				else
				{
					argument.add = 0f;
				}
				argument.emo = this.extraData.emo;
				argument.add += this.m_aplicatingWeight * this.extraData.add;
			}

			// Token: 0x020002FC RID: 764
			[Serializable]
			public struct ExtraData
			{
				// Token: 0x04000D65 RID: 3429
				public Emotion emo;

				// Token: 0x04000D66 RID: 3430
				public float add;
			}
		}

		// Token: 0x0200021A RID: 538
		[Serializable]
		public class BuffDataForEmotionGain : JeringaBuffCaster.BuffData<DisplayableBuff, BuffOnEmocionGainArg, JeringaBuffCaster.BuffDataForEmotionGain.ExtraData>
		{
			// Token: 0x06000FE6 RID: 4070 RVA: 0x0004D9E4 File Offset: 0x0004BBE4
			public BuffDataForEmotionGain(Emotion emo, float gainMod, BuffMap.Duracion duracion = null, params string[] extraIDs)
			{
				this.buffID = "Tvalle.Buff.EmotionGainMod";
				string text = BuffMap.GenerateIdSegundaria(extraIDs);
				this.idSegundaria = BuffMap.GenerateIdSegundaria(emo.ToString(), text);
				this.argumentUpdater = new JeringaBuffCaster.UpdateArgumentDataHandler<BuffOnEmocionGainArg, JeringaBuffCaster.BuffDataForEmotionGain.ExtraData>(this.DefaultUpdateArgumentDatar);
				this.extraData = new JeringaBuffCaster.BuffDataForEmotionGain.ExtraData
				{
					emo = emo,
					gainMod = gainMod
				};
				if (duracion == null)
				{
					duracion = new BuffMap.Duracion
					{
						infinite = true
					};
				}
				this.duracionOverride = duracion;
			}

			// Token: 0x06000FE7 RID: 4071 RVA: 0x0004DA6C File Offset: 0x0004BC6C
			private void DefaultUpdateArgumentDatar(BuffOnEmocionGainArg argument, JeringaBuffCaster.BuffDataForEmotionGain.ExtraData extradata, bool justInstantiated, float aplicatingWeight)
			{
				if (!justInstantiated)
				{
					if (argument.emo != this.extraData.emo)
					{
						Debug.LogError("argumento tien un id diferente, save game puede estar corrupto");
					}
				}
				else
				{
					argument.gainMod = 1f;
				}
				argument.emo = this.extraData.emo;
				argument.gainMod *= this.m_aplicatingWeight * this.extraData.gainMod;
			}

			// Token: 0x020002FD RID: 765
			[Serializable]
			public struct ExtraData
			{
				// Token: 0x04000D67 RID: 3431
				public Emotion emo;

				// Token: 0x04000D68 RID: 3432
				public float gainMod;
			}
		}

		// Token: 0x0200021B RID: 539
		[Serializable]
		public class BuffData<TBuff, TArg, TExtraData> : JeringaBuffCaster.BuffDataBase where TBuff : BuffEvento, new() where TArg : ArgumentoDeEfecto
		{
			// Token: 0x06000FE8 RID: 4072 RVA: 0x0004DAD6 File Offset: 0x0004BCD6
			protected BuffData()
			{
				this.buffUpdater = new JeringaBuffCaster.UpdateBuffConfigHandler<TBuff, TExtraData>(this.DefaultUpdateBuffConfig);
			}

			// Token: 0x1700028C RID: 652
			// (get) Token: 0x06000FE9 RID: 4073 RVA: 0x0004DAF0 File Offset: 0x0004BCF0
			public TBuff buff
			{
				get
				{
					return this.m_buff;
				}
			}

			// Token: 0x06000FEA RID: 4074 RVA: 0x0004DAF8 File Offset: 0x0004BCF8
			protected override void OnApply(BuffDeCharacter buffDeCharacter, Object context)
			{
				this.m_buff = BuffAndDebuffGeneratorHelper.AddOrUpdateBuff<TBuff, TArg>(buffDeCharacter, this.buffID, context, (this.argumentUpdater == null) ? null : new BuffAndDebuffGeneratorHelper.UpdateArgumentDataHandler<TArg>(this.UpdateArgumentData), (this.buffUpdater == null) ? null : new BuffAndDebuffGeneratorHelper.UpdateBuffConfigHandler<TBuff>(this.UpdateBuffConfig), this.idSegundaria, this.duracionOverride);
			}

			// Token: 0x06000FEB RID: 4075 RVA: 0x0004DB54 File Offset: 0x0004BD54
			protected virtual void UpdateArgumentData(TArg argument, bool justInstantiated)
			{
				JeringaBuffCaster.UpdateArgumentDataHandler<TArg, TExtraData> updateArgumentDataHandler = this.argumentUpdater;
				if (updateArgumentDataHandler == null)
				{
					return;
				}
				updateArgumentDataHandler(argument, this.extraData, justInstantiated, this.m_aplicatingWeight);
			}

			// Token: 0x06000FEC RID: 4076 RVA: 0x0004DB74 File Offset: 0x0004BD74
			protected virtual void UpdateBuffConfig(TBuff buff, bool justInstantiated)
			{
				JeringaBuffCaster.UpdateBuffConfigHandler<TBuff, TExtraData> updateBuffConfigHandler = this.buffUpdater;
				if (updateBuffConfigHandler == null)
				{
					return;
				}
				updateBuffConfigHandler(buff, this.extraData, justInstantiated, this.m_aplicatingWeight);
			}

			// Token: 0x06000FED RID: 4077 RVA: 0x0004DB94 File Offset: 0x0004BD94
			protected override void OnRemove(BuffDeCharacter buffDeCharacter, Object context)
			{
				BuffAndDebuffGeneratorHelper.RemoveBuffImmediately(buffDeCharacter, this.buffID, context, this.idSegundaria);
			}

			// Token: 0x06000FEE RID: 4078 RVA: 0x0004DBAC File Offset: 0x0004BDAC
			private void DefaultUpdateBuffConfig(TBuff buff, TExtraData extradata, bool justInstantiated, float aplicatingWeight)
			{
				if (!(buff is DisplayableBuff))
				{
					return;
				}
				DisplayableBuff displayableBuff = buff as DisplayableBuff;
				displayableBuff.nombresPorID = this.nombresPorID;
				if (!justInstantiated)
				{
					displayableBuff.ShowBuffAppliedMsg();
					displayableBuff.showSmallMsgOnApplied = false;
					return;
				}
				displayableBuff.showSmallMsgOnApplied = true;
			}

			// Token: 0x04000A1F RID: 2591
			[SerializeReference]
			protected TBuff m_buff;

			// Token: 0x04000A20 RID: 2592
			public TExtraData extraData;

			// Token: 0x04000A21 RID: 2593
			public JeringaBuffCaster.UpdateArgumentDataHandler<TArg, TExtraData> argumentUpdater;

			// Token: 0x04000A22 RID: 2594
			public JeringaBuffCaster.UpdateBuffConfigHandler<TBuff, TExtraData> buffUpdater;

			// Token: 0x04000A23 RID: 2595
			public string nombresPorID;
		}

		// Token: 0x0200021C RID: 540
		[Serializable]
		public abstract class BuffDataBase
		{
			// Token: 0x1700028D RID: 653
			// (get) Token: 0x06000FEF RID: 4079 RVA: 0x0004DBF7 File Offset: 0x0004BDF7
			public bool isValid
			{
				get
				{
					return !string.IsNullOrEmpty(this.buffID);
				}
			}

			// Token: 0x06000FF0 RID: 4080 RVA: 0x0004DC07 File Offset: 0x0004BE07
			public void Apply(BuffDeCharacter buffDeCharacter, float aplicatingWeight, Object context)
			{
				this.m_aplicatingWeight = Mathf.Clamp01(aplicatingWeight);
				this.OnApply(buffDeCharacter, context);
			}

			// Token: 0x06000FF1 RID: 4081 RVA: 0x0004DC1D File Offset: 0x0004BE1D
			public void Remove(BuffDeCharacter buffDeCharacter, float aplicatingWeight, Object context)
			{
				this.m_aplicatingWeight = Mathf.Clamp01(aplicatingWeight);
				this.OnRemove(buffDeCharacter, context);
			}

			// Token: 0x06000FF2 RID: 4082
			protected abstract void OnApply(BuffDeCharacter buffDeCharacter, Object context);

			// Token: 0x06000FF3 RID: 4083
			protected abstract void OnRemove(BuffDeCharacter buffDeCharacter, Object context);

			// Token: 0x04000A24 RID: 2596
			public string buffID;

			// Token: 0x04000A25 RID: 2597
			public string idSegundaria;

			// Token: 0x04000A26 RID: 2598
			[SerializeReference]
			public BuffMap.Duracion duracionOverride;

			// Token: 0x04000A27 RID: 2599
			[SerializeField]
			protected float m_aplicatingWeight;
		}
	}
}
