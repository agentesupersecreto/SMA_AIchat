using System;
using Assets.TValle.IU.Runtime.Interacciones.Donas;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using Assets._ReusableScripts.UI.Interacciones.Donas;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.UI
{
	// Token: 0x02000029 RID: 41
	[Obsolete("usar la version para THS")]
	public class GenericOpcionDeDonaQueIniciaDialogo : GenericOpcionDeDona
	{
		// Token: 0x06000161 RID: 353 RVA: 0x00006EE1 File Offset: 0x000050E1
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_owner = this.GetComponentEnRoot(false);
			if (this.m_owner == null)
			{
				throw new ArgumentNullException("m_owner", "m_owner null reference.");
			}
		}

		// Token: 0x06000162 RID: 354 RVA: 0x00006F14 File Offset: 0x00005114
		protected override void ClickedCompleto(IUIElementoConValor sender, DonaDeInteraccionBase dona)
		{
			base.ClickedCompleto(sender, dona);
			if (!DialogueManager.IsConversationActive)
			{
				this.m_owner.TrySerConversarzado(MainChar.current, this.m_conversation);
			}
			dona.StopDrawing();
		}

		// Token: 0x040000B8 RID: 184
		[ConversationPopup(false)]
		[SerializeField]
		private string m_conversation;

		// Token: 0x040000B9 RID: 185
		private Character m_owner;
	}
}
