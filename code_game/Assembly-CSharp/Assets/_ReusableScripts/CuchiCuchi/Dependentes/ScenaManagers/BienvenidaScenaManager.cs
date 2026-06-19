using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones;
using Assets._ReusableScripts.Globales;
using Assets._ReusableScripts.UI;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.ScenaManagers
{
	// Token: 0x02000044 RID: 68
	[Obsolete("", true)]
	public sealed class BienvenidaScenaManager : ScenaCharacteresManager
	{
		// Token: 0x06000149 RID: 329 RVA: 0x0000BA95 File Offset: 0x00009C95
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void BeforeJuegoLanzado()
		{
			SceneSingletonV2.Finalizar();
		}

		// Token: 0x0600014A RID: 330 RVA: 0x0000BA9C File Offset: 0x00009C9C
		protected override void Onload(LoadSceneMode loadSceneMode)
		{
			if (this.rogarTrigger == null)
			{
				throw new ArgumentNullException("rogarTrigger", "rogarTrigger null reference.");
			}
			if (this.entradaTrigger == null)
			{
				throw new ArgumentNullException("entradaTrigger", "entradaTrigger null reference.");
			}
			if (this.esconderEsaCosa == null)
			{
				throw new ArgumentNullException("esconderEsaCosa", "esconderEsaCosa null reference.");
			}
			if (this.jugador == null)
			{
				throw new ArgumentNullException("jugador", "jugador null reference.");
			}
			if (this.recepcionista == null)
			{
				throw new ArgumentNullException("recepcionista", "recepcionista null reference.");
			}
			this.LoadFemale();
			this.LoadMale();
			base.SetInitialInteraction(this.recepcionista, this.interaccionInicial, -1f, int.MaxValue, 1.5f);
		}

		// Token: 0x0600014B RID: 331 RVA: 0x0000BB6C File Offset: 0x00009D6C
		protected override void OnUnload()
		{
		}

		// Token: 0x0600014C RID: 332 RVA: 0x0000BB6E File Offset: 0x00009D6E
		private void LoadMale()
		{
		}

		// Token: 0x0600014D RID: 333 RVA: 0x0000BB70 File Offset: 0x00009D70
		private void LoadFemale()
		{
			Animator bodyAnimator = this.recepcionista.bodyAnimator;
			Transform boneTransform = this.recepcionista.bodyAnimator.GetBoneTransform(HumanBodyBones.Head);
			base.InstantiateConversationTrigger(this.entradaTrigger, boneTransform.position, bodyAnimator.transform.rotation, this.recepcionista.transform.FindChildNotNull("Conversaciones"), boneTransform.lossyScale, bodyAnimator.transform);
			base.InstantiateConversationTrigger(this.rogarTrigger, boneTransform.position, bodyAnimator.transform.rotation, this.recepcionista.transform.FindChildNotNull("Conversaciones"), boneTransform.lossyScale, bodyAnimator.transform);
			base.InstantiateConversationTrigger(this.esconderEsaCosa, boneTransform.position, bodyAnimator.transform.rotation, this.recepcionista.transform.FindChildNotNull("Conversaciones"), boneTransform.lossyScale, bodyAnimator.transform);
		}

		// Token: 0x0600014E RID: 334 RVA: 0x0000BC59 File Offset: 0x00009E59
		protected override void OnGameOverPorMax(Emocion emo)
		{
			GameOverPanel instance = Singleton<GameOverPanel>.instance;
			if (instance == null)
			{
				return;
			}
			instance.ChangeState(true);
		}

		// Token: 0x040000B7 RID: 183
		[Tooltip("Opcional")]
		public string recepcionistaNombre;

		// Token: 0x040000B8 RID: 184
		[Tooltip("Opcional")]
		public string jugadorNombre;

		// Token: 0x040000B9 RID: 185
		[Header("Prefabs References")]
		public ConversationTrigger entradaTrigger;

		// Token: 0x040000BA RID: 186
		public ConversationTrigger rogarTrigger;

		// Token: 0x040000BB RID: 187
		public ConversationTrigger esconderEsaCosa;

		// Token: 0x040000BC RID: 188
		[Header("Scena References")]
		public FemaleChar recepcionista;

		// Token: 0x040000BD RID: 189
		public MaleChar jugador;

		// Token: 0x040000BE RID: 190
		public InteraccionSegundariaName interaccionInicial;
	}
}
