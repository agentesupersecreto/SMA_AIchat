using System;
using System.Text;
using Assets.TValle.Tools.Runtime.Characters.Atts.Emotions;
using Assets.TValle.Tools.Runtime.Characters.Intections;
using Assets.TValle.Tools.Runtime.Characters.Scenes;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Scenas
{
	// Token: 0x020000C8 RID: 200
	public class InteraccionesEnScenaDEBUG : AplicableCustomMonobehaviour
	{
		// Token: 0x060004B2 RID: 1202 RVA: 0x00013EE0 File Offset: 0x000120E0
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
		}

		// Token: 0x060004B3 RID: 1203 RVA: 0x00013EE8 File Offset: 0x000120E8
		private void M_InteraccionesEnScena_onRegister(ref Interaction register, ICharactersSceneInteractions Interactions, SceneCharacter from, SceneCharacter to, ISceneInteractions sender)
		{
			if (!this.logRegister)
			{
				return;
			}
			ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool> key = register.GetKey();
			ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool> valueTuple = new ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool>(this.TriggeringBodyPart, this.SensitiveBodyPart, this.InterationReceivedType, this.Emotion, this.maxValue);
			ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool> valueTuple2 = key;
			ValueTuple<TriggeringBodyPart, SensitiveBodyPart, InterationReceivedType, Emotion, bool> valueTuple3 = valueTuple;
			if (valueTuple2.Item1 != valueTuple3.Item1 || valueTuple2.Item2 != valueTuple3.Item2 || valueTuple2.Item3 != valueTuple3.Item3 || valueTuple2.Item4 != valueTuple3.Item4 || valueTuple2.Item5 != valueTuple3.Item5)
			{
				return;
			}
			this.Log(ref register);
		}

		// Token: 0x060004B4 RID: 1204 RVA: 0x00013F7C File Offset: 0x0001217C
		private void Log(ref Interaction interaction)
		{
			StringBuilder stringBuilder = new StringBuilder(JsonUtility.ToJson(interaction, true));
			if (this.logDuration)
			{
				stringBuilder.Insert(0, "Duration : " + interaction.duration.ToString() + " ");
			}
			Debug.Log(stringBuilder.ToString());
		}

		// Token: 0x060004B5 RID: 1205 RVA: 0x00013FD8 File Offset: 0x000121D8
		protected override CustomMonobehaviourBotonConfig Boton2()
		{
			return new CustomMonobehaviourBotonConfig
			{
				activado = true,
				text = "Log Archived Of Target Interaction"
			};
		}

		// Token: 0x060004B6 RID: 1206 RVA: 0x00013FF4 File Offset: 0x000121F4
		protected override void OnAplicar2()
		{
			base.OnAplicar2();
			ICharactersSceneInteractionsArchived charactersSceneInteractionsArchived;
			if (!this.inverted)
			{
				charactersSceneInteractionsArchived = this.m_InteraccionesEnScena.GetMainArchivedInteractions(CurrentMainCharacter<CurrentMainChar, MainChar>.current.character, CurrentMainCharacter<CurrentTargetChar, TargetChar>.current.character);
			}
			else
			{
				charactersSceneInteractionsArchived = this.m_InteraccionesEnScena.GetMainArchivedInteractions(CurrentMainCharacter<CurrentTargetChar, TargetChar>.current.character, CurrentMainCharacter<CurrentMainChar, MainChar>.current.character);
			}
			Interaction interaction;
			charactersSceneInteractionsArchived.Peek(this.TriggeringBodyPart, this.SensitiveBodyPart, this.InterationReceivedType, this.Emotion, this.maxValue, out interaction);
			this.Log(ref interaction);
		}

		// Token: 0x0400034B RID: 843
		[Header("Direction")]
		public bool inverted;

		// Token: 0x0400034C RID: 844
		[Header("Target")]
		public TriggeringBodyPart TriggeringBodyPart;

		// Token: 0x0400034D RID: 845
		public SensitiveBodyPart SensitiveBodyPart;

		// Token: 0x0400034E RID: 846
		public InterationReceivedType InterationReceivedType;

		// Token: 0x0400034F RID: 847
		public Emotion Emotion;

		// Token: 0x04000350 RID: 848
		public bool maxValue;

		// Token: 0x04000351 RID: 849
		[Header("On")]
		public bool logDuration;

		// Token: 0x04000352 RID: 850
		public bool logRegister;

		// Token: 0x04000353 RID: 851
		[SerializeField]
		private InteraccionesEnScena m_InteraccionesEnScena;
	}
}
