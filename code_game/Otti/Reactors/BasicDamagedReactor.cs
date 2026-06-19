using System;
using com.ootii.Actors.AnimationControllers;
using com.ootii.Actors.Combat;
using com.ootii.Actors.LifeCores;
using com.ootii.Base;
using com.ootii.Messages;
using UnityEngine;

namespace com.ootii.Reactors
{
	// Token: 0x02000057 RID: 87
	[BaseName("Basic Damaged Reactor")]
	[BaseDescription("Basic reactor for handling messages of type DamageMessage. This is where damage is applied and any other effects or animations should be activated.")]
	[Serializable]
	public class BasicDamagedReactor : ReactorAction
	{
		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x0600042D RID: 1069 RVA: 0x0001975E File Offset: 0x0001795E
		// (set) Token: 0x0600042E RID: 1070 RVA: 0x00019766 File Offset: 0x00017966
		public string HealthID
		{
			get
			{
				return this._HealthID;
			}
			set
			{
				this._HealthID = value;
			}
		}

		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x0600042F RID: 1071 RVA: 0x0001976F File Offset: 0x0001796F
		// (set) Token: 0x06000430 RID: 1072 RVA: 0x00019777 File Offset: 0x00017977
		public string DamagedMotion
		{
			get
			{
				return this._DamagedMotion;
			}
			set
			{
				this._DamagedMotion = value;
			}
		}

		// Token: 0x06000431 RID: 1073 RVA: 0x00019780 File Offset: 0x00017980
		public BasicDamagedReactor()
		{
			this._ActivationType = 0;
		}

		// Token: 0x06000432 RID: 1074 RVA: 0x000197A5 File Offset: 0x000179A5
		public BasicDamagedReactor(GameObject rOwner)
			: base(rOwner)
		{
			this._ActivationType = 0;
			this.mActorCore = rOwner.GetComponent<ActorCore>();
		}

		// Token: 0x06000433 RID: 1075 RVA: 0x000197D7 File Offset: 0x000179D7
		public override void Awake()
		{
			if (this.mOwner != null)
			{
				this.mActorCore = this.mOwner.GetComponent<ActorCore>();
			}
		}

		// Token: 0x06000434 RID: 1076 RVA: 0x000197F8 File Offset: 0x000179F8
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
			DamageMessage damageMessage = rMessage as DamageMessage;
			if (damageMessage == null)
			{
				return false;
			}
			if (damageMessage.Damage == 0f)
			{
				return false;
			}
			if (damageMessage.ID != 0)
			{
				if (damageMessage.ID == CombatMessage.MSG_DEFENDER_KILLED)
				{
					return false;
				}
				if (damageMessage.ID != CombatMessage.MSG_DEFENDER_ATTACKED)
				{
					return false;
				}
			}
			CombatMessage combatMessage = rMessage as CombatMessage;
			if (combatMessage != null && combatMessage.Defender != this.mActorCore.gameObject)
			{
				return false;
			}
			this.mMessage = damageMessage;
			return true;
		}

		// Token: 0x06000435 RID: 1077 RVA: 0x0001989C File Offset: 0x00017A9C
		public override bool Activate()
		{
			base.Activate();
			float num = 0f;
			if (this.mActorCore.AttributeSource != null)
			{
				num = this.mActorCore.AttributeSource.GetAttributeValue<float>(this.HealthID, 0f) - ((DamageMessage)this.mMessage).Damage;
				this.mActorCore.AttributeSource.SetAttributeValue<float>(this.HealthID, num);
			}
			if (num <= 0f)
			{
				this.mMessage.ID = CombatMessage.MSG_DEFENDER_KILLED;
				this.mActorCore.SendMessage(this.mMessage);
			}
			else if (this.mMessage != null && ((DamageMessage)this.mMessage).AnimationEnabled)
			{
				MotionController component = this.mActorCore.gameObject.GetComponent<MotionController>();
				if (component != null)
				{
					this.mMessage.ID = CombatMessage.MSG_DEFENDER_DAMAGED;
					component.SendMessage(this.mMessage);
				}
				if (!this.mMessage.IsHandled && this.DamagedMotion.Length > 0)
				{
					MotionControllerMotion motionControllerMotion = null;
					if (component != null)
					{
						motionControllerMotion = component.GetMotion(this.DamagedMotion, false);
					}
					if (motionControllerMotion != null)
					{
						component.ActivateMotion(motionControllerMotion, 0);
					}
					else if (Animator.StringToHash(this.DamagedMotion) != 0)
					{
						Animator component2 = this.mActorCore.gameObject.GetComponent<Animator>();
						if (component2 != null)
						{
							component2.CrossFade(this.DamagedMotion, 0.25f, 0);
						}
					}
				}
			}
			this.Deactivate();
			return true;
		}

		// Token: 0x06000436 RID: 1078 RVA: 0x00019A0C File Offset: 0x00017C0C
		public override void Deactivate()
		{
			base.Deactivate();
			this.mMessage = null;
		}

		// Token: 0x0400022A RID: 554
		public string _HealthID = "Health";

		// Token: 0x0400022B RID: 555
		public string _DamagedMotion = "BasicDamaged";

		// Token: 0x0400022C RID: 556
		[NonSerialized]
		protected ActorCore mActorCore;
	}
}
