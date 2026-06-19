using System;
using System.Collections.Generic;
using Assets.TValle.BeachGirl;
using RootMotion.Dynamics;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Puppet
{
	// Token: 0x02000114 RID: 276
	public class PuppetPartes : CustomUpdatedMonobehaviourBase, IPuppetConPartes, IComponentStartable
	{
		// Token: 0x17000116 RID: 278
		// (get) Token: 0x06000592 RID: 1426 RVA: 0x0001FC7E File Offset: 0x0001DE7E
		public PartesDePuppet<PuppetPart> partes
		{
			get
			{
				return this.m_Partes;
			}
		}

		// Token: 0x17000117 RID: 279
		// (get) Token: 0x06000593 RID: 1427 RVA: 0x0001FC86 File Offset: 0x0001DE86
		public PartesDePuppet<IPuppetParte> partesDePuppet
		{
			get
			{
				return this.m_PartesBase;
			}
		}

		// Token: 0x1400000D RID: 13
		// (add) Token: 0x06000594 RID: 1428 RVA: 0x0001FC90 File Offset: 0x0001DE90
		// (remove) Token: 0x06000595 RID: 1429 RVA: 0x0001FCC8 File Offset: 0x0001DEC8
		public event Action afterPartsCreated;

		// Token: 0x06000596 RID: 1430 RVA: 0x0001FD00 File Offset: 0x0001DF00
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_puppet = base.GetComponentInChildren<PuppetMaster>();
			this.m_animator = base.GetComponentInChildren<Animator>();
			if (this.m_animator == null)
			{
				throw new ArgumentNullException("m_animator", "m_animator null reference.");
			}
			if (this.m_puppet == null)
			{
				throw new ArgumentNullException("m_puppet", "m_puppet null reference.");
			}
			base.SetManualStart();
			PuppetMaster puppet = this.m_puppet;
			puppet.OnPostInitiate = (PuppetMaster.UpdateDelegate)Delegate.Combine(puppet.OnPostInitiate, new PuppetMaster.UpdateDelegate(this.OnPuppetInit));
		}

		// Token: 0x06000597 RID: 1431 RVA: 0x0001FD94 File Offset: 0x0001DF94
		private void OnPuppetInit()
		{
			if (this.estimulables && this.GetComponentEnRoot(false) != null)
			{
				throw new NotSupportedException("Seguro se necesita el overhead?");
			}
			PuppetMaster puppet = this.m_puppet;
			puppet.OnPostInitiate = (PuppetMaster.UpdateDelegate)Delegate.Remove(puppet.OnPostInitiate, new PuppetMaster.UpdateDelegate(this.OnPuppetInit));
			this.m_PartesBase.cadera = (this.m_Partes.cadera = PuppetPartes.CreatePart(PuppetParte.cadera, this.m_puppet, this.m_animator, delegate(PuppetPart p)
			{
				this.m_Partes.list.Add(p);
				this.m_PartesBase.list.Add(p);
			}));
			this.m_PartesBase.spine1 = (this.m_Partes.spine1 = PuppetPartes.CreatePart(PuppetParte.spine1, this.m_puppet, this.m_animator, delegate(PuppetPart p)
			{
				this.m_Partes.list.Add(p);
				this.m_PartesBase.list.Add(p);
			}));
			this.m_PartesBase.spine2 = (this.m_Partes.spine2 = PuppetPartes.CreatePart(PuppetParte.spine2, this.m_puppet, this.m_animator, delegate(PuppetPart p)
			{
				this.m_Partes.list.Add(p);
				this.m_PartesBase.list.Add(p);
			}));
			this.m_PartesBase.head = (this.m_Partes.head = PuppetPartes.CreatePart(PuppetParte.head, this.m_puppet, this.m_animator, delegate(PuppetPart p)
			{
				this.m_Partes.list.Add(p);
				this.m_PartesBase.list.Add(p);
			}));
			this.m_PartesBase.brazoL = (this.m_Partes.brazoL = PuppetPartes.CreatePart(PuppetParte.brazoL, this.m_puppet, this.m_animator, delegate(PuppetPart p)
			{
				this.m_Partes.list.Add(p);
				this.m_PartesBase.list.Add(p);
			}));
			this.m_PartesBase.brazoR = (this.m_Partes.brazoR = PuppetPartes.CreatePart(PuppetParte.brazoR, this.m_puppet, this.m_animator, delegate(PuppetPart p)
			{
				this.m_Partes.list.Add(p);
				this.m_PartesBase.list.Add(p);
			}));
			this.m_PartesBase.anteBrazoL = (this.m_Partes.anteBrazoL = PuppetPartes.CreatePart(PuppetParte.anteBrazoL, this.m_puppet, this.m_animator, delegate(PuppetPart p)
			{
				this.m_Partes.list.Add(p);
				this.m_PartesBase.list.Add(p);
			}));
			this.m_PartesBase.anteBrazoR = (this.m_Partes.anteBrazoR = PuppetPartes.CreatePart(PuppetParte.anteBrazoR, this.m_puppet, this.m_animator, delegate(PuppetPart p)
			{
				this.m_Partes.list.Add(p);
				this.m_PartesBase.list.Add(p);
			}));
			this.m_PartesBase.manoL = (this.m_Partes.manoL = PuppetPartes.CreatePart(PuppetParte.manoL, this.m_puppet, this.m_animator, delegate(PuppetPart p)
			{
				this.m_Partes.list.Add(p);
				this.m_PartesBase.list.Add(p);
			}));
			this.m_PartesBase.manoR = (this.m_Partes.manoR = PuppetPartes.CreatePart(PuppetParte.manoR, this.m_puppet, this.m_animator, delegate(PuppetPart p)
			{
				this.m_Partes.list.Add(p);
				this.m_PartesBase.list.Add(p);
			}));
			this.m_PartesBase.piernaL = (this.m_Partes.piernaL = PuppetPartes.CreatePart(PuppetParte.piernaL, this.m_puppet, this.m_animator, delegate(PuppetPart p)
			{
				this.m_Partes.list.Add(p);
				this.m_PartesBase.list.Add(p);
			}));
			this.m_PartesBase.piernaR = (this.m_Partes.piernaR = PuppetPartes.CreatePart(PuppetParte.piernaR, this.m_puppet, this.m_animator, delegate(PuppetPart p)
			{
				this.m_Partes.list.Add(p);
				this.m_PartesBase.list.Add(p);
			}));
			this.m_PartesBase.canillaL = (this.m_Partes.canillaL = PuppetPartes.CreatePart(PuppetParte.canillaL, this.m_puppet, this.m_animator, delegate(PuppetPart p)
			{
				this.m_Partes.list.Add(p);
				this.m_PartesBase.list.Add(p);
			}));
			this.m_PartesBase.canillaR = (this.m_Partes.canillaR = PuppetPartes.CreatePart(PuppetParte.canillaR, this.m_puppet, this.m_animator, delegate(PuppetPart p)
			{
				this.m_Partes.list.Add(p);
				this.m_PartesBase.list.Add(p);
			}));
			this.m_PartesBase.pieL = (this.m_Partes.pieL = PuppetPartes.CreatePart(PuppetParte.pieL, this.m_puppet, this.m_animator, delegate(PuppetPart p)
			{
				this.m_Partes.list.Add(p);
				this.m_PartesBase.list.Add(p);
			}));
			this.m_PartesBase.pieR = (this.m_Partes.pieR = PuppetPartes.CreatePart(PuppetParte.pieR, this.m_puppet, this.m_animator, delegate(PuppetPart p)
			{
				this.m_Partes.list.Add(p);
				this.m_PartesBase.list.Add(p);
			}));
			this.m_PartesBase.neck = (this.m_Partes.neck = PuppetPartes.CreatePart(PuppetParte.neck, this.m_puppet, this.m_animator, delegate(PuppetPart p)
			{
				this.m_Partes.list.Add(p);
				this.m_PartesBase.list.Add(p);
			}));
			this.m_PartesBase.hombroL = (this.m_Partes.hombroL = PuppetPartes.CreatePart(PuppetParte.hombroL, this.m_puppet, this.m_animator, delegate(PuppetPart p)
			{
				this.m_Partes.list.Add(p);
				this.m_PartesBase.list.Add(p);
			}));
			this.m_PartesBase.hombroR = (this.m_Partes.hombroR = PuppetPartes.CreatePart(PuppetParte.hombroR, this.m_puppet, this.m_animator, delegate(PuppetPart p)
			{
				this.m_Partes.list.Add(p);
				this.m_PartesBase.list.Add(p);
			}));
			this.InitPart(this.m_Partes.cadera, PuppetParte.cadera, Side.none, this.estimulables);
			this.InitPart(this.m_Partes.spine1, PuppetParte.spine1, Side.none, this.estimulables);
			this.InitPart(this.m_Partes.spine2, PuppetParte.spine2, Side.none, this.estimulables);
			this.InitPart(this.m_Partes.head, PuppetParte.head, Side.none, this.estimulables);
			this.InitPart(this.m_Partes.brazoL, PuppetParte.brazoL, Side.L, this.estimulables);
			this.InitPart(this.m_Partes.brazoR, PuppetParte.brazoR, Side.R, this.estimulables);
			this.InitPart(this.m_Partes.anteBrazoL, PuppetParte.anteBrazoL, Side.L, this.estimulables);
			this.InitPart(this.m_Partes.anteBrazoR, PuppetParte.anteBrazoR, Side.R, this.estimulables);
			this.InitPart(this.m_Partes.manoL, PuppetParte.manoL, Side.L, this.estimulablesHands);
			this.InitPart(this.m_Partes.manoR, PuppetParte.manoR, Side.R, this.estimulablesHands);
			this.InitPart(this.m_Partes.piernaL, PuppetParte.piernaL, Side.L, this.estimulables);
			this.InitPart(this.m_Partes.piernaR, PuppetParte.piernaR, Side.R, this.estimulables);
			this.InitPart(this.m_Partes.canillaL, PuppetParte.canillaL, Side.L, this.estimulables);
			this.InitPart(this.m_Partes.canillaR, PuppetParte.canillaR, Side.R, this.estimulables);
			this.InitPart(this.m_Partes.pieL, PuppetParte.pieL, Side.L, this.estimulables);
			this.InitPart(this.m_Partes.pieR, PuppetParte.pieR, Side.R, this.estimulables);
			this.InitPart(this.m_Partes.neck, PuppetParte.neck, Side.none, this.estimulables);
			this.InitPart(this.m_Partes.hombroL, PuppetParte.hombroL, Side.L, this.estimulables);
			this.InitPart(this.m_Partes.hombroR, PuppetParte.hombroR, Side.R, this.estimulables);
			Action action = this.afterPartsCreated;
			if (action != null)
			{
				action();
			}
			base.ManualStart();
		}

		// Token: 0x06000598 RID: 1432 RVA: 0x00020408 File Offset: 0x0001E608
		private static PuppetPart CreatePart(PuppetParte p, PuppetMaster puppet, Animator animator, Action<PuppetPart> onCreated)
		{
			Muscle muscle = puppet.GetMuscle(animator, PuppetPartes.partesDelPupet[p]);
			if (muscle == null)
			{
				return null;
			}
			PuppetPart componentNotNull = muscle.rigidbody.GetComponentNotNull<PuppetPart>();
			if (onCreated != null)
			{
				onCreated(componentNotNull);
			}
			return componentNotNull;
		}

		// Token: 0x06000599 RID: 1433 RVA: 0x00020444 File Offset: 0x0001E644
		private void InitPart(PuppetPart part, PuppetParte p, Side side, bool estimulable)
		{
			if (part == null)
			{
				return;
			}
			Muscle muscle = this.m_puppet.GetMuscle(this.m_animator, PuppetPartes.partesDelPupet[p]);
			part.Init(p, muscle, side, this.administrarMateriales, estimulable);
		}

		// Token: 0x04000468 RID: 1128
		public bool estimulables = true;

		// Token: 0x04000469 RID: 1129
		public bool estimulablesHands = true;

		// Token: 0x0400046A RID: 1130
		public bool administrarMateriales;

		// Token: 0x0400046B RID: 1131
		private PuppetMaster m_puppet;

		// Token: 0x0400046C RID: 1132
		private Animator m_animator;

		// Token: 0x0400046D RID: 1133
		[ReadOnlyUI]
		[SerializeField]
		private PuppetPartes.PartesDePuppetWraper m_Partes = new PuppetPartes.PartesDePuppetWraper();

		// Token: 0x0400046E RID: 1134
		private PartesDePuppet<IPuppetParte> m_PartesBase = new PartesDePuppet<IPuppetParte>();

		// Token: 0x04000470 RID: 1136
		private static Dictionary<PuppetParte, HumanBodyBones> partesDelPupet = new Dictionary<PuppetParte, HumanBodyBones>
		{
			{
				PuppetParte.cadera,
				HumanBodyBones.Hips
			},
			{
				PuppetParte.spine1,
				HumanBodyBones.Spine
			},
			{
				PuppetParte.spine2,
				HumanBodyBones.Chest
			},
			{
				PuppetParte.head,
				HumanBodyBones.Head
			},
			{
				PuppetParte.brazoL,
				HumanBodyBones.LeftUpperArm
			},
			{
				PuppetParte.brazoR,
				HumanBodyBones.RightUpperArm
			},
			{
				PuppetParte.anteBrazoL,
				HumanBodyBones.LeftLowerArm
			},
			{
				PuppetParte.anteBrazoR,
				HumanBodyBones.RightLowerArm
			},
			{
				PuppetParte.manoL,
				HumanBodyBones.LeftHand
			},
			{
				PuppetParte.manoR,
				HumanBodyBones.RightHand
			},
			{
				PuppetParte.piernaL,
				HumanBodyBones.LeftUpperLeg
			},
			{
				PuppetParte.piernaR,
				HumanBodyBones.RightUpperLeg
			},
			{
				PuppetParte.canillaL,
				HumanBodyBones.LeftLowerLeg
			},
			{
				PuppetParte.canillaR,
				HumanBodyBones.RightLowerLeg
			},
			{
				PuppetParte.pieL,
				HumanBodyBones.LeftFoot
			},
			{
				PuppetParte.pieR,
				HumanBodyBones.RightFoot
			},
			{
				PuppetParte.neck,
				HumanBodyBones.Neck
			},
			{
				PuppetParte.hombroL,
				HumanBodyBones.LeftShoulder
			},
			{
				PuppetParte.hombroR,
				HumanBodyBones.RightShoulder
			}
		};

		// Token: 0x02000115 RID: 277
		[Serializable]
		public class PartesDePuppetWraper : PartesDePuppet<PuppetPart>
		{
		}
	}
}
