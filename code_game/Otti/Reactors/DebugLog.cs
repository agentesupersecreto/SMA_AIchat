using System;
using com.ootii.Base;
using UnityEngine;

namespace com.ootii.Reactors
{
	// Token: 0x02000059 RID: 89
	[BaseName("Debug Log")]
	[BaseDescription("Writes a debug statement to the console.")]
	[Serializable]
	public class DebugLog : ReactorAction
	{
		// Token: 0x170000DC RID: 220
		// (get) Token: 0x06000448 RID: 1096 RVA: 0x00019C18 File Offset: 0x00017E18
		// (set) Token: 0x06000449 RID: 1097 RVA: 0x00019C20 File Offset: 0x00017E20
		public string Text
		{
			get
			{
				return this._Text;
			}
			set
			{
				this._Text = value;
			}
		}

		// Token: 0x0600044A RID: 1098 RVA: 0x00019C29 File Offset: 0x00017E29
		public DebugLog()
		{
		}

		// Token: 0x0600044B RID: 1099 RVA: 0x00019C3C File Offset: 0x00017E3C
		public DebugLog(GameObject rOwner)
			: base(rOwner)
		{
		}

		// Token: 0x0600044C RID: 1100 RVA: 0x00019C50 File Offset: 0x00017E50
		public override bool Activate()
		{
			base.Activate();
			string text = ((this.mOwner != null) ? this.mOwner.name : "");
			int num = ((this.mMessage != null) ? this.mMessage.ID : 0);
			Debug.Log(string.Format("[{0:f3}] name:{1} id:{2} msg:{3}", new object[]
			{
				Time.time,
				text,
				num,
				this._Text
			}));
			this.Deactivate();
			return true;
		}

		// Token: 0x04000233 RID: 563
		public string _Text = "";
	}
}
