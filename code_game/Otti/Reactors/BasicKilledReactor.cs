using System;
using System.Collections;
using com.ootii.Actors;
using com.ootii.Actors.AnimationControllers;
using com.ootii.Actors.Combat;
using com.ootii.Actors.LifeCores;
using com.ootii.Base;
using com.ootii.Messages;
using UnityEngine;

namespace com.ootii.Reactors
{
	// Token: 0x02000058 RID: 88
	[BaseName("Basic Killed Reactor")]
	[BaseDescription("Basic reactor for handling messages of type DamageMessage where the owner is killed. This is activate the appropriate effects and animations.")]
	[Serializable]
	public class BasicKilledReactor : ReactorAction
	{
		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x06000437 RID: 1079 RVA: 0x00019A1B File Offset: 0x00017C1B
		// (set) Token: 0x06000438 RID: 1080 RVA: 0x00019A23 File Offset: 0x00017C23
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

		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x06000439 RID: 1081 RVA: 0x00019A2C File Offset: 0x00017C2C
		// (set) Token: 0x0600043A RID: 1082 RVA: 0x00019A34 File Offset: 0x00017C34
		public string DeathMotion
		{
			get
			{
				return this._DeathMotion;
			}
			set
			{
				this._DeathMotion = value;
			}
		}

		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x0600043B RID: 1083 RVA: 0x00019A3D File Offset: 0x00017C3D
		// (set) Token: 0x0600043C RID: 1084 RVA: 0x00019A45 File Offset: 0x00017C45
		public bool DisableComponents
		{
			get
			{
				return this._DisableComponents;
			}
			set
			{
				this._DisableComponents = value;
			}
		}

		// Token: 0x170000DA RID: 218
		// (get) Token: 0x0600043D RID: 1085 RVA: 0x00019A4E File Offset: 0x00017C4E
		// (set) Token: 0x0600043E RID: 1086 RVA: 0x00019A56 File Offset: 0x00017C56
		public bool DisableColliders
		{
			get
			{
				return this._DisableColliders;
			}
			set
			{
				this._DisableColliders = value;
			}
		}

		// Token: 0x170000DB RID: 219
		// (get) Token: 0x0600043F RID: 1087 RVA: 0x00019A5F File Offset: 0x00017C5F
		// (set) Token: 0x06000440 RID: 1088 RVA: 0x00019A67 File Offset: 0x00017C67
		public bool RemoveBodyShapes
		{
			get
			{
				return this._RemoveBodyShapes;
			}
			set
			{
				this._RemoveBodyShapes = value;
			}
		}

		// Token: 0x06000441 RID: 1089 RVA: 0x00019A70 File Offset: 0x00017C70
		public BasicKilledReactor()
		{
			this._ActivationType = 0;
		}

		// Token: 0x06000442 RID: 1090 RVA: 0x00019AAC File Offset: 0x00017CAC
		public BasicKilledReactor(GameObject rOwner)
			: base(rOwner)
		{
			this._ActivationType = 0;
			this.mActorCore = rOwner.GetComponent<ActorCore>();
		}

		// Token: 0x06000443 RID: 1091 RVA: 0x00019AFE File Offset: 0x00017CFE
		public override void Awake()
		{
			if (this.mOwner != null)
			{
				this.mActorCore = this.mOwner.GetComponent<ActorCore>();
			}
		}

		// Token: 0x06000444 RID: 1092 RVA: 0x00019B20 File Offset: 0x00017D20
		public override bool TestActivate(IMessage rMessage)
		{
			if (!base.TestActivate(rMessage))
			{
				return false;
			}
			if (!this.mActorCore.IsAlive)
			{
				return false;
			}
			if (rMessage.ID != CombatMessage.MSG_DEFENDER_KILLED)
			{
				return false;
			}
			CombatMessage combatMessage = rMessage as CombatMessage;
			if (combatMessage != null && combatMessage.Defender != this.mActorCore.gameObject)
			{
				return false;
			}
			this.mMessage = rMessage;
			return true;
		}

		// Token: 0x06000445 RID: 1093 RVA: 0x00019B84 File Offset: 0x00017D84
		public override bool Activate()
		{
			base.Activate();
			this.mActorCore.IsAlive = false;
			if (this.mActorCore.AttributeSource != null && this.HealthID.Length > 0)
			{
				this.mActorCore.AttributeSource.SetAttributeValue<float>(this.HealthID, 0f);
			}
			this.mActorCore.StartCoroutine(this.InternalDeath(this.mMessage));
			return true;
		}

		// Token: 0x06000446 RID: 1094 RVA: 0x00019BF3 File Offset: 0x00017DF3
		public override void Deactivate()
		{
			base.Deactivate();
			this.mMessage = null;
		}

		// Token: 0x06000447 RID: 1095 RVA: 0x00019C02 File Offset: 0x00017E02
		protected virtual IEnumerator InternalDeath(IMessage rMessage)
		{
			ActorController lActorController = this.mActorCore.gameObject.GetComponent<ActorController>();
			MotionController lMotionController = this.mActorCore.gameObject.GetComponent<MotionController>();
			if (rMessage != null && lMotionController != null)
			{
				rMessage.ID = CombatMessage.MSG_DEFENDER_KILLED;
				if (this.DeathMotion.Length > 0)
				{
					MotionControllerMotion motion = lMotionController.GetMotion(this.DeathMotion, false);
					if (motion != null)
					{
						lMotionController.ActivateMotion(motion, 0);
						goto IL_00FB;
					}
					if (Animator.StringToHash(this.DeathMotion) == 0)
					{
						goto IL_00FB;
					}
					Animator component = this.mActorCore.gameObject.GetComponent<Animator>();
					if (!(component != null))
					{
						goto IL_00FB;
					}
					try
					{
						component.CrossFade(this.DeathMotion, 0.25f, 0);
						goto IL_00FB;
					}
					catch
					{
						goto IL_00FB;
					}
				}
				lMotionController.SendMessage(rMessage);
				IL_00FB:
				yield return new WaitForSeconds(3f);
				if (this._DisableComponents)
				{
					lMotionController.enabled = false;
					lMotionController.ActorController.enabled = false;
				}
			}
			if (this._DisableColliders)
			{
				Collider[] components = this.mActorCore.gameObject.GetComponents<Collider>();
				for (int i = 0; i < components.Length; i++)
				{
					components[i].enabled = false;
				}
			}
			if (this._RemoveBodyShapes && lActorController != null)
			{
				lActorController.RemoveBodyShapes();
			}
			this.Deactivate();
			yield break;
		}

		// Token: 0x0400022D RID: 557
		public string _HealthID = "Health";

		// Token: 0x0400022E RID: 558
		public string _DeathMotion = "";

		// Token: 0x0400022F RID: 559
		public bool _DisableComponents = true;

		// Token: 0x04000230 RID: 560
		public bool _DisableColliders = true;

		// Token: 0x04000231 RID: 561
		public bool _RemoveBodyShapes = true;

		// Token: 0x04000232 RID: 562
		[NonSerialized]
		protected ActorCore mActorCore;
	}
}
