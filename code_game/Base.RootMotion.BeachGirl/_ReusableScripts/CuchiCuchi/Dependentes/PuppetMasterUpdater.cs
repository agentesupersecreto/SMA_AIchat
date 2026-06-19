using System;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Puppet;
using Assets._ReusableScripts.Globales.Updater;
using RootMotion.Dynamics;
using RootMotion.Dynamics.TavoRootMotion;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes
{
	// Token: 0x02000057 RID: 87
	[RequireComponent(typeof(PuppetMaster))]
	public class PuppetMasterUpdater : AplicableBehaviour, IPuppetUpdater, IJustPuppetEvents
	{
		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x060003B4 RID: 948 RVA: 0x000127A0 File Offset: 0x000109A0
		public override int updateEvent1Index
		{
			get
			{
				return (int)this.updateOrder;
			}
		}

		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x060003B5 RID: 949 RVA: 0x000127A8 File Offset: 0x000109A8
		public override int updateEvent2Index
		{
			get
			{
				return (int)this.fixedUpdateOrder;
			}
		}

		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x060003B6 RID: 950 RVA: 0x000127B0 File Offset: 0x000109B0
		public override int updateEvent3Index
		{
			get
			{
				return (int)this.lateUpdateOrder;
			}
		}

		// Token: 0x14000024 RID: 36
		// (add) Token: 0x060003B7 RID: 951 RVA: 0x000127B8 File Offset: 0x000109B8
		// (remove) Token: 0x060003B8 RID: 952 RVA: 0x000127F0 File Offset: 0x000109F0
		public event Action beforeFixedUpdate;

		// Token: 0x14000025 RID: 37
		// (add) Token: 0x060003B9 RID: 953 RVA: 0x00012828 File Offset: 0x00010A28
		// (remove) Token: 0x060003BA RID: 954 RVA: 0x00012860 File Offset: 0x00010A60
		public event Action afterFixedUpdate;

		// Token: 0x14000026 RID: 38
		// (add) Token: 0x060003BB RID: 955 RVA: 0x00012898 File Offset: 0x00010A98
		// (remove) Token: 0x060003BC RID: 956 RVA: 0x000128D0 File Offset: 0x00010AD0
		public event Action beforeUpdate;

		// Token: 0x14000027 RID: 39
		// (add) Token: 0x060003BD RID: 957 RVA: 0x00012908 File Offset: 0x00010B08
		// (remove) Token: 0x060003BE RID: 958 RVA: 0x00012940 File Offset: 0x00010B40
		public event Action afterUpdate;

		// Token: 0x14000028 RID: 40
		// (add) Token: 0x060003BF RID: 959 RVA: 0x00012978 File Offset: 0x00010B78
		// (remove) Token: 0x060003C0 RID: 960 RVA: 0x000129B0 File Offset: 0x00010BB0
		public event Action beforeLateUpdate;

		// Token: 0x14000029 RID: 41
		// (add) Token: 0x060003C1 RID: 961 RVA: 0x000129E8 File Offset: 0x00010BE8
		// (remove) Token: 0x060003C2 RID: 962 RVA: 0x00012A20 File Offset: 0x00010C20
		public event Action afterLateUpdate;

		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x060003C3 RID: 963 RVA: 0x00012A55 File Offset: 0x00010C55
		public PuppetMaster puppet
		{
			get
			{
				return this.m_PuppetMaster;
			}
		}

		// Token: 0x1400002A RID: 42
		// (add) Token: 0x060003C4 RID: 964 RVA: 0x00012A60 File Offset: 0x00010C60
		// (remove) Token: 0x060003C5 RID: 965 RVA: 0x00012A98 File Offset: 0x00010C98
		private event Action<PuppetMasterUpdater, PuppetMaster> justFixedUpdating;

		// Token: 0x1400002B RID: 43
		// (add) Token: 0x060003C6 RID: 966 RVA: 0x00012AD0 File Offset: 0x00010CD0
		// (remove) Token: 0x060003C7 RID: 967 RVA: 0x00012B08 File Offset: 0x00010D08
		private event Action<PuppetMasterUpdater, PuppetMaster> justFixedUpdated;

		// Token: 0x1400002C RID: 44
		// (add) Token: 0x060003C8 RID: 968 RVA: 0x00012B40 File Offset: 0x00010D40
		// (remove) Token: 0x060003C9 RID: 969 RVA: 0x00012B78 File Offset: 0x00010D78
		private event Action<PuppetMasterUpdater, PuppetMaster> justYieldFixedUpdating;

		// Token: 0x1400002D RID: 45
		// (add) Token: 0x060003CA RID: 970 RVA: 0x00012BB0 File Offset: 0x00010DB0
		// (remove) Token: 0x060003CB RID: 971 RVA: 0x00012BE8 File Offset: 0x00010DE8
		private event Action<PuppetMasterUpdater, PuppetMaster> justYieldFixedUpdated;

		// Token: 0x1400002E RID: 46
		// (add) Token: 0x060003CC RID: 972 RVA: 0x00012C20 File Offset: 0x00010E20
		// (remove) Token: 0x060003CD RID: 973 RVA: 0x00012C58 File Offset: 0x00010E58
		private event Action<PuppetMasterUpdater, PuppetMaster> justUpdating;

		// Token: 0x1400002F RID: 47
		// (add) Token: 0x060003CE RID: 974 RVA: 0x00012C90 File Offset: 0x00010E90
		// (remove) Token: 0x060003CF RID: 975 RVA: 0x00012CC8 File Offset: 0x00010EC8
		private event Action<PuppetMasterUpdater, PuppetMaster> justUpdated;

		// Token: 0x14000030 RID: 48
		// (add) Token: 0x060003D0 RID: 976 RVA: 0x00012D00 File Offset: 0x00010F00
		// (remove) Token: 0x060003D1 RID: 977 RVA: 0x00012D38 File Offset: 0x00010F38
		private event Action<PuppetMasterUpdater, PuppetMaster> justLateUpdating;

		// Token: 0x14000031 RID: 49
		// (add) Token: 0x060003D2 RID: 978 RVA: 0x00012D70 File Offset: 0x00010F70
		// (remove) Token: 0x060003D3 RID: 979 RVA: 0x00012DA8 File Offset: 0x00010FA8
		private event Action<PuppetMasterUpdater, PuppetMaster> justLateUpdated;

		// Token: 0x14000032 RID: 50
		// (add) Token: 0x060003D4 RID: 980 RVA: 0x00012DDD File Offset: 0x00010FDD
		// (remove) Token: 0x060003D5 RID: 981 RVA: 0x00012DE6 File Offset: 0x00010FE6
		event Action<PuppetMasterUpdater, PuppetMaster> IJustPuppetEvents.justFixedUpdating
		{
			add
			{
				this.justFixedUpdating += value;
			}
			remove
			{
				this.justFixedUpdating -= value;
			}
		}

		// Token: 0x14000033 RID: 51
		// (add) Token: 0x060003D6 RID: 982 RVA: 0x00012DEF File Offset: 0x00010FEF
		// (remove) Token: 0x060003D7 RID: 983 RVA: 0x00012DF8 File Offset: 0x00010FF8
		event Action<PuppetMasterUpdater, PuppetMaster> IJustPuppetEvents.justFixedUpdated
		{
			add
			{
				this.justFixedUpdated += value;
			}
			remove
			{
				this.justFixedUpdated -= value;
			}
		}

		// Token: 0x14000034 RID: 52
		// (add) Token: 0x060003D8 RID: 984 RVA: 0x00012E01 File Offset: 0x00011001
		// (remove) Token: 0x060003D9 RID: 985 RVA: 0x00012E0A File Offset: 0x0001100A
		event Action<PuppetMasterUpdater, PuppetMaster> IJustPuppetEvents.justUpdating
		{
			add
			{
				this.justUpdating += value;
			}
			remove
			{
				this.justUpdating -= value;
			}
		}

		// Token: 0x14000035 RID: 53
		// (add) Token: 0x060003DA RID: 986 RVA: 0x00012E13 File Offset: 0x00011013
		// (remove) Token: 0x060003DB RID: 987 RVA: 0x00012E1C File Offset: 0x0001101C
		event Action<PuppetMasterUpdater, PuppetMaster> IJustPuppetEvents.justUpdated
		{
			add
			{
				this.justUpdated += value;
			}
			remove
			{
				this.justUpdated -= value;
			}
		}

		// Token: 0x14000036 RID: 54
		// (add) Token: 0x060003DC RID: 988 RVA: 0x00012E25 File Offset: 0x00011025
		// (remove) Token: 0x060003DD RID: 989 RVA: 0x00012E2E File Offset: 0x0001102E
		event Action<PuppetMasterUpdater, PuppetMaster> IJustPuppetEvents.justLateUpdating
		{
			add
			{
				this.justLateUpdating += value;
			}
			remove
			{
				this.justLateUpdating -= value;
			}
		}

		// Token: 0x14000037 RID: 55
		// (add) Token: 0x060003DE RID: 990 RVA: 0x00012E37 File Offset: 0x00011037
		// (remove) Token: 0x060003DF RID: 991 RVA: 0x00012E40 File Offset: 0x00011040
		event Action<PuppetMasterUpdater, PuppetMaster> IJustPuppetEvents.justLateUpdated
		{
			add
			{
				this.justLateUpdated += value;
			}
			remove
			{
				this.justLateUpdated -= value;
			}
		}

		// Token: 0x060003E0 RID: 992 RVA: 0x00012E49 File Offset: 0x00011049
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_PuppetMaster = base.GetComponent<PuppetMaster>();
		}

		// Token: 0x060003E1 RID: 993 RVA: 0x00012E60 File Offset: 0x00011060
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			ConfigurableJoint[] componentsInChildren = base.GetComponentsInChildren<ConfigurableJoint>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].projectionMode = JointProjectionMode.PositionAndRotation;
			}
		}

		// Token: 0x060003E2 RID: 994 RVA: 0x00012E94 File Offset: 0x00011094
		public override void OnUpdateEvent1()
		{
			if (!this.m_PuppetMaster.enabled)
			{
				return;
			}
			if (this.update)
			{
				Action action = this.beforeUpdate;
				if (action != null)
				{
					action();
				}
				if (this.debug)
				{
					MonoBehaviour.print("PuppetMaster Updating");
				}
				Action<PuppetMasterUpdater, PuppetMaster> action2 = this.justUpdating;
				if (action2 != null)
				{
					action2(this, this.m_PuppetMaster);
				}
				this.m_PuppetMaster.UpdatePuppet();
				Action<PuppetMasterUpdater, PuppetMaster> action3 = this.justUpdated;
				if (action3 != null)
				{
					action3(this, this.m_PuppetMaster);
				}
				Action action4 = this.afterUpdate;
				if (action4 == null)
				{
					return;
				}
				action4();
			}
		}

		// Token: 0x060003E3 RID: 995 RVA: 0x00012F28 File Offset: 0x00011128
		public override void OnUpdateEvent2()
		{
			if (!this.m_PuppetMaster.enabled)
			{
				return;
			}
			if (this.fixedUpdate)
			{
				Action action = this.beforeFixedUpdate;
				if (action != null)
				{
					action();
				}
				if (this.debug)
				{
					MonoBehaviour.print("PuppetMaster FixedUpdating");
				}
				Action<PuppetMasterUpdater, PuppetMaster> action2 = this.justFixedUpdating;
				if (action2 != null)
				{
					action2(this, this.m_PuppetMaster);
				}
				this.m_PuppetMaster.FixedUpdatePuppet();
				Action<PuppetMasterUpdater, PuppetMaster> action3 = this.justFixedUpdated;
				if (action3 != null)
				{
					action3(this, this.m_PuppetMaster);
				}
				Action action4 = this.afterFixedUpdate;
				if (action4 == null)
				{
					return;
				}
				action4();
			}
		}

		// Token: 0x060003E4 RID: 996 RVA: 0x00012FBC File Offset: 0x000111BC
		public override void OnUpdateEvent3()
		{
			if (!this.m_PuppetMaster.enabled)
			{
				return;
			}
			if (this.lateUpdate)
			{
				Action action = this.beforeLateUpdate;
				if (action != null)
				{
					action();
				}
				if (this.debug)
				{
					MonoBehaviour.print("PuppetMaster LateUpdating");
				}
				Action<PuppetMasterUpdater, PuppetMaster> action2 = this.justLateUpdating;
				if (action2 != null)
				{
					action2(this, this.m_PuppetMaster);
				}
				this.m_PuppetMaster.LateUpdatePuppet();
				Action<PuppetMasterUpdater, PuppetMaster> action3 = this.justLateUpdated;
				if (action3 != null)
				{
					action3(this, this.m_PuppetMaster);
				}
				if (this.debug)
				{
					MonoBehaviour.print("PuppetMaster LateUpdated");
				}
				Action action4 = this.afterLateUpdate;
				if (action4 == null)
				{
					return;
				}
				action4();
			}
		}

		// Token: 0x060003E5 RID: 997 RVA: 0x00013064 File Offset: 0x00011264
		public void ReAsignarBonesAMusculos()
		{
			PuppetMaster component = base.GetComponent<PuppetMaster>();
			component.targetAnimator = null;
			component.targetRoot = null;
			Muscle[] muscles = component.muscles;
			Animator componentInChildren = base.transform.parent.GetComponentInChildren<Animator>();
			foreach (Muscle muscle in muscles)
			{
				muscle.target = componentInChildren.transform.FindDeepChild(muscle.joint.name, true);
				if (muscle.target == null)
				{
					Debug.LogError("No se encontro bone con nombre " + muscle.joint.name, this);
				}
			}
		}

		// Token: 0x060003E6 RID: 998 RVA: 0x000130F4 File Offset: 0x000112F4
		public void AlinearMusculos()
		{
			if (Application.isPlaying)
			{
				throw new NotSupportedException();
			}
			foreach (Muscle muscle in base.GetComponent<PuppetMaster>().muscles)
			{
				muscle.joint.transform.SetPositionAndRotation(muscle.target.position, muscle.target.rotation);
			}
		}

		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x060003E7 RID: 999 RVA: 0x00013152 File Offset: 0x00011352
		public override string aplicarButtonString
		{
			get
			{
				return "Re-asignar bones a musculos";
			}
		}

		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x060003E8 RID: 1000 RVA: 0x00013159 File Offset: 0x00011359
		protected override bool soloEnRunTime
		{
			get
			{
				return false;
			}
		}

		// Token: 0x060003E9 RID: 1001 RVA: 0x0001315C File Offset: 0x0001135C
		protected override void OnAplicar()
		{
			base.OnAplicar();
			this.ReAsignarBonesAMusculos();
		}

		// Token: 0x060003EA RID: 1002 RVA: 0x0001316A File Offset: 0x0001136A
		protected override CustomMonobehaviourBotonConfig Boton2()
		{
			return new CustomMonobehaviourBotonConfig
			{
				activado = true,
				playTimeVisible = false,
				text = "Re-AlinearMusculos"
			};
		}

		// Token: 0x060003EB RID: 1003 RVA: 0x0001318A File Offset: 0x0001138A
		protected override void OnAplicar2()
		{
			this.AlinearMusculos();
		}

		// Token: 0x060003EC RID: 1004 RVA: 0x00013192 File Offset: 0x00011392
		protected override CustomMonobehaviourBotonConfig Boton3()
		{
			return new CustomMonobehaviourBotonConfig
			{
				activado = true,
				editorTimeVisible = false,
				text = "Update Muscles Colliders"
			};
		}

		// Token: 0x060003ED RID: 1005 RVA: 0x000131B4 File Offset: 0x000113B4
		protected override void OnAplicar3()
		{
			if (this.m_PuppetMaster == null)
			{
				return;
			}
			foreach (Muscle muscle in this.m_PuppetMaster.muscles)
			{
				IMuscleCollidersUpdater component = muscle.rigidbody.GetComponent<IMuscleCollidersUpdater>();
				if (component != null)
				{
					component.UpdateColliders();
				}
				else
				{
					muscle.UpdateColliders();
				}
			}
			this.m_PuppetMaster.UpdateInternalCollisons();
		}

		// Token: 0x060003EE RID: 1006 RVA: 0x00013216 File Offset: 0x00011416
		void IPuppetUpdater.Update()
		{
		}

		// Token: 0x060003EF RID: 1007 RVA: 0x00013218 File Offset: 0x00011418
		void IPuppetUpdater.FixedUpdate()
		{
		}

		// Token: 0x060003F0 RID: 1008 RVA: 0x0001321A File Offset: 0x0001141A
		void IPuppetUpdater.LateUpdate()
		{
		}

		// Token: 0x04000286 RID: 646
		[SerializeField]
		protected GlobalUpdater.UpdateType fixedUpdateOrder = GlobalUpdater.UpdateType.fixedUpdateOnPupetMaster;

		// Token: 0x04000287 RID: 647
		[SerializeField]
		protected GlobalUpdater.UpdateType updateOrder = GlobalUpdater.UpdateType.updateOnPupetMaster;

		// Token: 0x04000288 RID: 648
		[SerializeField]
		protected GlobalUpdater.UpdateType lateUpdateOrder = GlobalUpdater.UpdateType.lateUpdateOnPupetMaster;

		// Token: 0x0400028F RID: 655
		public bool update = true;

		// Token: 0x04000290 RID: 656
		public bool fixedUpdate = true;

		// Token: 0x04000291 RID: 657
		public bool lateUpdate = true;

		// Token: 0x04000292 RID: 658
		public bool debug;

		// Token: 0x04000293 RID: 659
		private PuppetMaster m_PuppetMaster;
	}
}
