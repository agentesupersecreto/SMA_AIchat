using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.Events;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem
{
	// Token: 0x02000018 RID: 24
	[RequireComponent(typeof(DialogueSystemEvents))]
	public class MainDialogueSystemEvents : Singleton<MainDialogueSystemEvents>
	{
		// Token: 0x1700002A RID: 42
		// (get) Token: 0x060000D9 RID: 217 RVA: 0x000051A0 File Offset: 0x000033A0
		public DialogueSystemEvents dialogueSystemEvents
		{
			get
			{
				return this.m_DialogueSystemEvents;
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x060000DA RID: 218 RVA: 0x000051A8 File Offset: 0x000033A8
		public bool enConversacion
		{
			get
			{
				return this.m_enConversacion;
			}
		}

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x060000DB RID: 219 RVA: 0x000051B0 File Offset: 0x000033B0
		// (remove) Token: 0x060000DC RID: 220 RVA: 0x000051E8 File Offset: 0x000033E8
		public event Action conversacionStart;

		// Token: 0x14000005 RID: 5
		// (add) Token: 0x060000DD RID: 221 RVA: 0x00005220 File Offset: 0x00003420
		// (remove) Token: 0x060000DE RID: 222 RVA: 0x00005258 File Offset: 0x00003458
		public event Action conversacionEnd;

		// Token: 0x060000DF RID: 223 RVA: 0x0000528D File Offset: 0x0000348D
		protected override void Initiating()
		{
			base.Initiating();
			this.esGlobal = false;
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x0000529C File Offset: 0x0000349C
		protected override void InitData(bool esEditorTime)
		{
			this.m_DialogueSystemEvents = base.GetComponent<DialogueSystemEvents>();
			if (!esEditorTime)
			{
				this.m_DialogueSystemEvents.conversationEvents.onConversationStart.AddListener(new UnityAction<Transform>(this.OnStart));
				this.m_DialogueSystemEvents.conversationEvents.onConversationEnd.AddListener(new UnityAction<Transform>(this.OnEnd));
			}
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x000052FA File Offset: 0x000034FA
		private void OnStart(Transform arg)
		{
			this.m_enConversacion = true;
			Action action = this.conversacionStart;
			if (action == null)
			{
				return;
			}
			action();
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x00005313 File Offset: 0x00003513
		private void OnEnd(Transform arg)
		{
			this.m_enConversacion = false;
			Action action = this.conversacionEnd;
			if (action == null)
			{
				return;
			}
			action();
		}

		// Token: 0x04000063 RID: 99
		private DialogueSystemEvents m_DialogueSystemEvents;

		// Token: 0x04000064 RID: 100
		[ReadOnlyUI]
		[SerializeField]
		private bool m_enConversacion;
	}
}
