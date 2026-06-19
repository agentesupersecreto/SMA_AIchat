using System;
using com.ootii.Actors.AnimationControllers;
using com.ootii.Actors.Combat;
using com.ootii.Actors.LifeCores;
using com.ootii.Base;
using com.ootii.Messages;
using UnityEngine;

namespace com.ootii.Reactors
{
	// Token: 0x02000056 RID: 86
	[BaseName("Basic Attacked Reactor")]
	[BaseDescription("Basic reactor for handling messages where the owner has been attacked. Typically this is used to determine if we can avoid or block the attack.")]
	[Serializable]
	public class BasicAttackedReactor : ReactorAction
	{
		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x06000425 RID: 1061 RVA: 0x000195E3 File Offset: 0x000177E3
		// (set) Token: 0x06000426 RID: 1062 RVA: 0x000195EB File Offset: 0x000177EB
		public bool LimitToActiveMotions
		{
			get
			{
				return this._LimitToActiveMotions;
			}
			set
			{
				this._LimitToActiveMotions = value;
			}
		}

		// Token: 0x06000427 RID: 1063 RVA: 0x000195F4 File Offset: 0x000177F4
		public BasicAttackedReactor()
		{
			this._ActivationType = 0;
		}

		// Token: 0x06000428 RID: 1064 RVA: 0x00019603 File Offset: 0x00017803
		public BasicAttackedReactor(GameObject rOwner)
			: base(rOwner)
		{
			this._ActivationType = 0;
			this.mActorCore = rOwner.GetComponent<ActorCore>();
		}

		// Token: 0x06000429 RID: 1065 RVA: 0x0001961F File Offset: 0x0001781F
		public override void Awake()
		{
			if (this.mOwner != null)
			{
				this.mActorCore = this.mOwner.GetComponent<ActorCore>();
			}
		}

		// Token: 0x0600042A RID: 1066 RVA: 0x00019640 File Offset: 0x00017840
		public override bool TestActivate(IMessage rMessage)
		{
			if (!base.TestActivate(rMessage))
			{
				return false;
			}
			if (this.mActorCore == null || !this.mActorCore.IsAlive)
			{
				return false;
			}
			if (rMessage.ID != CombatMessage.MSG_DEFENDER_ATTACKED)
			{
				return false;
			}
			CombatMessage combatMessage = rMessage as CombatMessage;
			if (combatMessage != null && combatMessage.Defender != this.mActorCore.gameObject)
			{
				return false;
			}
			this.mMessage = combatMessage;
			return true;
		}

		// Token: 0x0600042B RID: 1067 RVA: 0x000196B0 File Offset: 0x000178B0
		public override bool Activate()
		{
			base.Activate();
			MotionController component = this.mActorCore.gameObject.GetComponent<MotionController>();
			for (int i = 0; i < component.MotionLayers.Count; i++)
			{
				if (component.MotionLayers[i].ActiveMotion != null)
				{
					component.MotionLayers[i].ActiveMotion.OnMessageReceived(this.mMessage);
					if (this.mMessage.IsHandled)
					{
						break;
					}
				}
			}
			if (!this._LimitToActiveMotions && !this.mMessage.IsHandled)
			{
				component.SendMessage(this.mMessage);
			}
			this.Deactivate();
			return true;
		}

		// Token: 0x0600042C RID: 1068 RVA: 0x0001974F File Offset: 0x0001794F
		public override void Deactivate()
		{
			base.Deactivate();
			this.mMessage = null;
		}

		// Token: 0x04000228 RID: 552
		public bool _LimitToActiveMotions;

		// Token: 0x04000229 RID: 553
		[NonSerialized]
		protected ActorCore mActorCore;
	}
}
