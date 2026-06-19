using System;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem
{
	// Token: 0x02000019 RID: 25
	[RequireComponent(typeof(RectTransform))]
	public sealed class HidePanel : CustomUpdatedMonobehaviourBase, IActivable
	{
		// Token: 0x1700002C RID: 44
		// (get) Token: 0x060000E4 RID: 228 RVA: 0x00005334 File Offset: 0x00003534
		public override int updateEvent1Index
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x060000E5 RID: 229 RVA: 0x00005337 File Offset: 0x00003537
		// (set) Token: 0x060000E6 RID: 230 RVA: 0x00005342 File Offset: 0x00003542
		bool IActivable.activado
		{
			get
			{
				return !this.forceHidden;
			}
			set
			{
				this.forceHidden = !value;
			}
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x0000534E File Offset: 0x0000354E
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_RectTransform = base.GetComponent<RectTransform>();
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x00005362 File Offset: 0x00003562
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.ResetHidden();
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x00005371 File Offset: 0x00003571
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.ResetHidden();
		}

		// Token: 0x060000EA RID: 234 RVA: 0x0000537F File Offset: 0x0000357F
		public void ResetHidden()
		{
			this.m_Lasthidden = null;
			this.hidden = false;
		}

		// Token: 0x060000EB RID: 235 RVA: 0x00005394 File Offset: 0x00003594
		public override void OnUpdateEvent1()
		{
			if (!this.forceHidden)
			{
				GeneralInputProxy instance = Singleton<GeneralInputProxy>.instance;
				if (instance.keysUI.Liberada(this.toggleKey))
				{
					this.hidden = !this.hidden;
				}
				for (int i = 0; i < this.showOnKeys.Count; i++)
				{
					KeyCode keyCode = this.showOnKeys[i];
					if (instance.keysUI.Sostenida(keyCode) || instance.keysUI.UndidaPrimerFrame(keyCode))
					{
						this.hidden = false;
					}
				}
			}
			bool flag = this.forceHidden || this.hidden;
			if (this.m_Lasthidden == null || this.m_Lasthidden.Value != flag)
			{
				this.m_Lasthidden = new bool?(flag);
				if (flag)
				{
					this.m_RectTransform.localScale = new Vector3(1f, 0f, 1f);
					return;
				}
				this.m_RectTransform.localScale = new Vector3(1f, 1f, 1f);
			}
		}

		// Token: 0x04000067 RID: 103
		private RectTransform m_RectTransform;

		// Token: 0x04000068 RID: 104
		public bool forceHidden;

		// Token: 0x04000069 RID: 105
		public bool hidden;

		// Token: 0x0400006A RID: 106
		private bool? m_Lasthidden;

		// Token: 0x0400006B RID: 107
		public KeyCode toggleKey;

		// Token: 0x0400006C RID: 108
		public List<KeyCode> showOnKeys = new List<KeyCode>();
	}
}
