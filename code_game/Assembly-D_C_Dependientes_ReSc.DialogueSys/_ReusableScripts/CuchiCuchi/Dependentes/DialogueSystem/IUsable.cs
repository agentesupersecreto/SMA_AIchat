using System;
using UnityEngine;
using UnityEngine.Internal;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem
{
	// Token: 0x02000008 RID: 8
	public interface IUsable
	{
		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600004B RID: 75
		int prioridad { get; }

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600004C RID: 76
		GameObject gameObject { get; }

		// Token: 0x0600004D RID: 77
		void SendMessage(string methodName);

		// Token: 0x0600004E RID: 78
		void SendMessage(string methodName, object value);

		// Token: 0x0600004F RID: 79
		void SendMessage(string methodName, SendMessageOptions options);

		// Token: 0x06000050 RID: 80
		void SendMessage(string methodName, [DefaultValue("null")] object value, [DefaultValue("SendMessageOptions.RequireReceiver")] SendMessageOptions options);

		// Token: 0x06000051 RID: 81
		void SendMessageUpwards(string methodName);

		// Token: 0x06000052 RID: 82
		void SendMessageUpwards(string methodName, object value);

		// Token: 0x06000053 RID: 83
		void SendMessageUpwards(string methodName, SendMessageOptions options);

		// Token: 0x06000054 RID: 84
		void SendMessageUpwards(string methodName, [DefaultValue("null")] object value, [DefaultValue("SendMessageOptions.RequireReceiver")] SendMessageOptions options);

		// Token: 0x06000055 RID: 85
		void BroadcastMessage(string methodName);

		// Token: 0x06000056 RID: 86
		void BroadcastMessage(string methodName, object parameter);

		// Token: 0x06000057 RID: 87
		void BroadcastMessage(string methodName, SendMessageOptions options);

		// Token: 0x06000058 RID: 88
		void BroadcastMessage(string methodName, [DefaultValue("null")] object parameter, [DefaultValue("SendMessageOptions.RequireReceiver")] SendMessageOptions options);

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000059 RID: 89
		string overrideUseMessage { get; }

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600005A RID: 90
		bool enabled { get; }

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x0600005B RID: 91
		// (set) Token: 0x0600005C RID: 92
		bool puedeUsarse { get; set; }

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x0600005D RID: 93
		float maxUseDistance { get; }

		// Token: 0x0600005E RID: 94
		string GetName();

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x0600005F RID: 95
		bool UseMessages { get; }

		// Token: 0x06000060 RID: 96
		void OnUsado(Transform actor);

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x06000061 RID: 97
		// (remove) Token: 0x06000062 RID: 98
		event Action<Transform> onUsado;
	}
}
