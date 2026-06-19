using System;
using Assets.TValle.IU.Runtime.Interacciones.THS.Donas;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Interacciones.UI
{
	// Token: 0x02000047 RID: 71
	public class StartBoneEditModeConDialogo : CustomMonobehaviour
	{
		// Token: 0x06000158 RID: 344 RVA: 0x0000BE64 File Offset: 0x0000A064
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_owner = this.GetComponentEnRoot(false);
			if (this.m_owner == null)
			{
				throw new ArgumentNullException("m_owner", "m_owner null reference.");
			}
			if (this.GetComponentEnRoot(false) == null)
			{
				throw new ArgumentNullException("m_interacciones", "m_interacciones null reference.");
			}
		}

		// Token: 0x06000159 RID: 345 RVA: 0x0000BEC1 File Offset: 0x0000A0C1
		public void StartEdit(THSDonaController.CurrentUserData data, THSDonaController dona, THSDonaController.RadialItemData radialData, object sender)
		{
			if (!DialogueManager.IsConversationActive)
			{
				this.m_owner.TrySerConversarzado(MainChar.current, this.m_conversationEjecutar);
			}
			dona.StopDrawing();
		}

		// Token: 0x040000C6 RID: 198
		[ConversationPopup(false)]
		[SerializeField]
		private string m_conversationEjecutar;

		// Token: 0x040000C7 RID: 199
		private Character m_owner;
	}
}
