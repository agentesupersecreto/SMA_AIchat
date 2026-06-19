using System;
using com.ootii.Actors.LifeCores;
using com.ootii.Base;
using UnityEngine;

namespace com.ootii.Reactors
{
	// Token: 0x0200005A RID: 90
	[BaseName("Unity Event Proxy")]
	[BaseDescription("Reactor that calls the Unity Event when it is activated. ")]
	[Serializable]
	public class UnityEventProxy : ReactorAction
	{
		// Token: 0x0600044D RID: 1101 RVA: 0x00019CDB File Offset: 0x00017EDB
		public UnityEventProxy()
		{
		}

		// Token: 0x0600044E RID: 1102 RVA: 0x00019CEA File Offset: 0x00017EEA
		public UnityEventProxy(GameObject rOwner)
			: base(rOwner)
		{
			this.mActorCore = rOwner.GetComponent<ActorCore>();
		}

		// Token: 0x0600044F RID: 1103 RVA: 0x00019D08 File Offset: 0x00017F08
		public override void Awake()
		{
			if (this.mOwner != null)
			{
				this.mActorCore = this.mOwner.GetComponent<ActorCore>();
			}
			if (this._StoredUnityEventIndex < 0)
			{
				this._StoredUnityEventIndex = this.mActorCore.StoreUnityEvent(-1, new ReactorActionEvent());
			}
		}

		// Token: 0x06000450 RID: 1104 RVA: 0x00019D54 File Offset: 0x00017F54
		public override bool Activate()
		{
			base.Activate();
			if (this._StoredUnityEventIndex >= 0 && this._StoredUnityEventIndex < this.mActorCore._StoredUnityEvents.Count)
			{
				ReactorActionEvent reactorActionEvent = this.mActorCore._StoredUnityEvents[this._StoredUnityEventIndex];
				if (reactorActionEvent != null)
				{
					reactorActionEvent.Invoke(this);
				}
			}
			this.Deactivate();
			return true;
		}

		// Token: 0x06000451 RID: 1105 RVA: 0x00019DB1 File Offset: 0x00017FB1
		public override void Deactivate()
		{
			base.Deactivate();
		}

		// Token: 0x04000234 RID: 564
		public int _StoredUnityEventIndex = -1;

		// Token: 0x04000235 RID: 565
		[NonSerialized]
		protected ActorCore mActorCore;
	}
}
