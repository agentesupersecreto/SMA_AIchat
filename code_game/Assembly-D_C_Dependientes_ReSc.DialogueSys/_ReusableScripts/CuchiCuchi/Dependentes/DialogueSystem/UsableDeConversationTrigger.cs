using System;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem
{
	// Token: 0x02000026 RID: 38
	public sealed class UsableDeConversationTrigger : CustomUpdatedMonobehaviourBase, IUsable
	{
		// Token: 0x17000036 RID: 54
		// (get) Token: 0x06000138 RID: 312 RVA: 0x00006873 File Offset: 0x00004A73
		string IUsable.overrideUseMessage
		{
			get
			{
				return this.overrideUseMessage;
			}
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x06000139 RID: 313 RVA: 0x0000687B File Offset: 0x00004A7B
		float IUsable.maxUseDistance
		{
			get
			{
				return this.maxUseDistance;
			}
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x0600013A RID: 314 RVA: 0x00006883 File Offset: 0x00004A83
		// (set) Token: 0x0600013B RID: 315 RVA: 0x00006886 File Offset: 0x00004A86
		public bool puedeUsarse
		{
			get
			{
				return true;
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x0600013C RID: 316 RVA: 0x0000688D File Offset: 0x00004A8D
		public bool UseMessages
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x0600013D RID: 317 RVA: 0x00006890 File Offset: 0x00004A90
		int IUsable.prioridad
		{
			get
			{
				return this.prioridad;
			}
		}

		// Token: 0x14000006 RID: 6
		// (add) Token: 0x0600013E RID: 318 RVA: 0x00006898 File Offset: 0x00004A98
		// (remove) Token: 0x0600013F RID: 319 RVA: 0x000068D0 File Offset: 0x00004AD0
		public event Action<Transform> onUsado;

		// Token: 0x06000140 RID: 320 RVA: 0x00006905 File Offset: 0x00004B05
		void IUsable.OnUsado(Transform actor)
		{
			Action<Transform> action = this.onUsado;
			if (action == null)
			{
				return;
			}
			action(actor);
		}

		// Token: 0x06000141 RID: 321 RVA: 0x00006918 File Offset: 0x00004B18
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_trigger = base.GetComponent<ConversationTrigger>();
			if (this.m_trigger == null)
			{
				throw new ArgumentNullException("m_trigger", "m_trigger null reference.");
			}
		}

		// Token: 0x06000142 RID: 322 RVA: 0x0000694C File Offset: 0x00004B4C
		public string GetName()
		{
			ConversationTrigger trigger = this.m_trigger;
			string text;
			if (trigger == null)
			{
				text = null;
			}
			else
			{
				Transform conversant = trigger.conversant;
				text = ((conversant != null) ? conversant.name : null);
			}
			string text2 = text;
			if (!string.IsNullOrWhiteSpace(text2))
			{
				return text2;
			}
			return base.name;
		}

		// Token: 0x06000144 RID: 324 RVA: 0x0000699B File Offset: 0x00004B9B
		GameObject IUsable.get_gameObject()
		{
			return base.gameObject;
		}

		// Token: 0x06000145 RID: 325 RVA: 0x000069A3 File Offset: 0x00004BA3
		void IUsable.SendMessage(string methodName)
		{
			base.SendMessage(methodName);
		}

		// Token: 0x06000146 RID: 326 RVA: 0x000069AC File Offset: 0x00004BAC
		void IUsable.SendMessage(string methodName, object value)
		{
			base.SendMessage(methodName, value);
		}

		// Token: 0x06000147 RID: 327 RVA: 0x000069B6 File Offset: 0x00004BB6
		void IUsable.SendMessage(string methodName, SendMessageOptions options)
		{
			base.SendMessage(methodName, options);
		}

		// Token: 0x06000148 RID: 328 RVA: 0x000069C0 File Offset: 0x00004BC0
		void IUsable.SendMessage(string methodName, object value, SendMessageOptions options)
		{
			base.SendMessage(methodName, value, options);
		}

		// Token: 0x06000149 RID: 329 RVA: 0x000069CB File Offset: 0x00004BCB
		void IUsable.SendMessageUpwards(string methodName)
		{
			base.SendMessageUpwards(methodName);
		}

		// Token: 0x0600014A RID: 330 RVA: 0x000069D4 File Offset: 0x00004BD4
		void IUsable.SendMessageUpwards(string methodName, object value)
		{
			base.SendMessageUpwards(methodName, value);
		}

		// Token: 0x0600014B RID: 331 RVA: 0x000069DE File Offset: 0x00004BDE
		void IUsable.SendMessageUpwards(string methodName, SendMessageOptions options)
		{
			base.SendMessageUpwards(methodName, options);
		}

		// Token: 0x0600014C RID: 332 RVA: 0x000069E8 File Offset: 0x00004BE8
		void IUsable.SendMessageUpwards(string methodName, object value, SendMessageOptions options)
		{
			base.SendMessageUpwards(methodName, value, options);
		}

		// Token: 0x0600014D RID: 333 RVA: 0x000069F3 File Offset: 0x00004BF3
		void IUsable.BroadcastMessage(string methodName)
		{
			base.BroadcastMessage(methodName);
		}

		// Token: 0x0600014E RID: 334 RVA: 0x000069FC File Offset: 0x00004BFC
		void IUsable.BroadcastMessage(string methodName, object parameter)
		{
			base.BroadcastMessage(methodName, parameter);
		}

		// Token: 0x0600014F RID: 335 RVA: 0x00006A06 File Offset: 0x00004C06
		void IUsable.BroadcastMessage(string methodName, SendMessageOptions options)
		{
			base.BroadcastMessage(methodName, options);
		}

		// Token: 0x06000150 RID: 336 RVA: 0x00006A10 File Offset: 0x00004C10
		void IUsable.BroadcastMessage(string methodName, object parameter, SendMessageOptions options)
		{
			base.BroadcastMessage(methodName, parameter, options);
		}

		// Token: 0x06000151 RID: 337 RVA: 0x00006A1B File Offset: 0x00004C1B
		bool IUsable.get_enabled()
		{
			return base.enabled;
		}

		// Token: 0x040000A9 RID: 169
		public int prioridad;

		// Token: 0x040000AA RID: 170
		public string overrideUseMessage;

		// Token: 0x040000AB RID: 171
		public float maxUseDistance = 5f;

		// Token: 0x040000AD RID: 173
		private ConversationTrigger m_trigger;
	}
}
