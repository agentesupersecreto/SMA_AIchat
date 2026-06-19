using System;
using System.Collections.Generic;
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
	// Token: 0x02000045 RID: 69
	[Obsolete("", true)]
	public class SegundaScenaManager : ScenaCharacteresManager
	{
		// Token: 0x06000150 RID: 336 RVA: 0x0000BC73 File Offset: 0x00009E73
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void BeforeJuegoLanzado()
		{
			SceneSingletonV2.Finalizar();
		}

		// Token: 0x06000151 RID: 337 RVA: 0x0000BC7C File Offset: 0x00009E7C
		protected override void Onload(LoadSceneMode loadSceneMode)
		{
			if (this.chairInteraction == null)
			{
				throw new ArgumentNullException("chairInteraction", "chairInteraction null reference.");
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
			foreach (ScenaCharacteresManager.InteraccionSegundariaPrioridadPar interaccionSegundariaPrioridadPar in this.interaccionesIniciales)
			{
				base.SetInitialInteraction(this.recepcionista, interaccionSegundariaPrioridadPar.interEnum, -1f, interaccionSegundariaPrioridadPar.prioridad, 1.25f);
			}
			base.SetInitialInteraction(this.recepcionista, this.chairInteraction, -1f, int.MaxValue, 1.75f);
		}

		// Token: 0x06000152 RID: 338 RVA: 0x0000BD74 File Offset: 0x00009F74
		private void LoadMale()
		{
		}

		// Token: 0x06000153 RID: 339 RVA: 0x0000BD78 File Offset: 0x00009F78
		private void LoadFemale()
		{
			Animator bodyAnimator = this.recepcionista.bodyAnimator;
			Transform boneTransform = this.recepcionista.bodyAnimator.GetBoneTransform(HumanBodyBones.Head);
			foreach (ConversationTrigger conversationTrigger in this.conversaciones)
			{
				base.InstantiateConversationTrigger(conversationTrigger, boneTransform.position, this.recepcionista.bodyAnimator.transform.rotation, this.recepcionista.transform.FindChildNotNull("Conversaciones"), boneTransform.lossyScale, bodyAnimator.transform);
			}
		}

		// Token: 0x06000154 RID: 340 RVA: 0x0000BE28 File Offset: 0x0000A028
		protected override void OnUnload()
		{
		}

		// Token: 0x06000155 RID: 341 RVA: 0x0000BE2A File Offset: 0x0000A02A
		protected override void OnGameOverPorMax(Emocion emo)
		{
			GameOverPanel instance = Singleton<GameOverPanel>.instance;
			if (instance == null)
			{
				return;
			}
			instance.ChangeState(true);
		}

		// Token: 0x040000BF RID: 191
		[Tooltip("Opcional")]
		public string recepcionistaNombre;

		// Token: 0x040000C0 RID: 192
		[Tooltip("Opcional")]
		public string jugadorNombre;

		// Token: 0x040000C1 RID: 193
		[Header("Scena References")]
		public FemaleChar recepcionista;

		// Token: 0x040000C2 RID: 194
		public MaleChar jugador;

		// Token: 0x040000C3 RID: 195
		public InteracionPrimariaExterna chairInteraction;

		// Token: 0x040000C4 RID: 196
		public List<ScenaCharacteresManager.InteraccionSegundariaPrioridadPar> interaccionesIniciales = new List<ScenaCharacteresManager.InteraccionSegundariaPrioridadPar>();

		// Token: 0x040000C5 RID: 197
		[CoolArrayItem]
		public List<ConversationTrigger> conversaciones = new List<ConversationTrigger>();
	}
}
