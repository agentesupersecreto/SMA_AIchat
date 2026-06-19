using System;
using Assets.Base.RootMotion.BeachGirl.Runtime.FinalIk;
using Assets.TValle.BeachGirl.Runtime;
using Assets.TValle.BeachGirl.Runtime.IK;
using Assets._ReusableScripts.CuchiCuchi.Controllers;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.LookAt
{
	// Token: 0x02000091 RID: 145
	[RequireComponent(typeof(ILookAtHeadTargets))]
	public sealed class LookAtIK_version3 : CustomMonobehaviour, ILookAtIK, ILookAtSolverIK, ILookAt, IComponentStartable
	{
		// Token: 0x17000152 RID: 338
		// (get) Token: 0x060005C7 RID: 1479 RVA: 0x0001D195 File Offset: 0x0001B395
		public Vector3 preUpdateHeadPosition
		{
			get
			{
				return this.m_NeckAndHead.preUpdateHeadPosition;
			}
		}

		// Token: 0x17000153 RID: 339
		// (get) Token: 0x060005C8 RID: 1480 RVA: 0x0001D1A2 File Offset: 0x0001B3A2
		public Quaternion preUpdateHeadRotation
		{
			get
			{
				return this.m_NeckAndHead.preUpdateHeadRotation;
			}
		}

		// Token: 0x17000154 RID: 340
		// (get) Token: 0x060005C9 RID: 1481 RVA: 0x0001D1AF File Offset: 0x0001B3AF
		public Vector3 preUpdateSpinePosition
		{
			get
			{
				return this.m_NeckAndHead.preUpdateSpinePosition;
			}
		}

		// Token: 0x17000155 RID: 341
		// (get) Token: 0x060005CA RID: 1482 RVA: 0x0001D1BC File Offset: 0x0001B3BC
		public Quaternion preUpdateSpineRotation
		{
			get
			{
				return this.m_NeckAndHead.preUpdateSpineRotation;
			}
		}

		// Token: 0x17000156 RID: 342
		// (get) Token: 0x060005CB RID: 1483 RVA: 0x0001D1C9 File Offset: 0x0001B3C9
		public Vector3 postUpdateHeadPosition
		{
			get
			{
				return this.m_NeckAndHead.postUpdateHeadPosition;
			}
		}

		// Token: 0x17000157 RID: 343
		// (get) Token: 0x060005CC RID: 1484 RVA: 0x0001D1D6 File Offset: 0x0001B3D6
		public Quaternion postUpdateHeadRotation
		{
			get
			{
				return this.m_NeckAndHead.postUpdateHeadRotation;
			}
		}

		// Token: 0x17000158 RID: 344
		// (get) Token: 0x060005CD RID: 1485 RVA: 0x0001D1E3 File Offset: 0x0001B3E3
		public Vector3 postUpdateSpinePosition
		{
			get
			{
				return this.m_NeckAndHead.postUpdateSpinePosition;
			}
		}

		// Token: 0x17000159 RID: 345
		// (get) Token: 0x060005CE RID: 1486 RVA: 0x0001D1F0 File Offset: 0x0001B3F0
		public Quaternion postUpdateSpineRotation
		{
			get
			{
				return this.m_NeckAndHead.postUpdateSpineRotation;
			}
		}

		// Token: 0x1700015A RID: 346
		// (get) Token: 0x060005CF RID: 1487 RVA: 0x0001D1FD File Offset: 0x0001B3FD
		public ILookAtHeadTargets targets
		{
			get
			{
				return this.m_targets;
			}
		}

		// Token: 0x1700015B RID: 347
		// (get) Token: 0x060005D0 RID: 1488 RVA: 0x0001D205 File Offset: 0x0001B405
		public LookAtIK mainLookAtIK
		{
			get
			{
				return this.m_NeckAndHead.lookAtIK;
			}
		}

		// Token: 0x1700015C RID: 348
		// (get) Token: 0x060005D1 RID: 1489 RVA: 0x0001D212 File Offset: 0x0001B412
		public LookAtEstadisticas estadisticasHaciaTarget
		{
			get
			{
				return this.m_NeckAndHead.estadisticasHaciaTarget;
			}
		}

		// Token: 0x1700015D RID: 349
		// (get) Token: 0x060005D2 RID: 1490 RVA: 0x0001D21F File Offset: 0x0001B41F
		public LookAtEstadisticas estadisticasHead
		{
			get
			{
				return this.m_NeckAndHead.estadisticasHead;
			}
		}

		// Token: 0x1700015E RID: 350
		// (get) Token: 0x060005D3 RID: 1491 RVA: 0x0001D22C File Offset: 0x0001B42C
		public float weight
		{
			get
			{
				return this.m_NeckAndHead.weight;
			}
		}

		// Token: 0x1700015F RID: 351
		// (get) Token: 0x060005D4 RID: 1492 RVA: 0x0001D239 File Offset: 0x0001B439
		public bool estaMirando
		{
			get
			{
				return this.weight > 0f;
			}
		}

		// Token: 0x17000160 RID: 352
		// (get) Token: 0x060005D5 RID: 1493 RVA: 0x0001D248 File Offset: 0x0001B448
		public Vector3 mirandoWorldPosition
		{
			get
			{
				return this.m_NeckAndHead.lastProvidedTargetPosition;
			}
		}

		// Token: 0x17000161 RID: 353
		// (get) Token: 0x060005D6 RID: 1494 RVA: 0x0001D255 File Offset: 0x0001B455
		public bool estaMirandoIzquierda
		{
			get
			{
				return this.estaMirando && this.m_NeckAndHead.estaMirandoIzquierda;
			}
		}

		// Token: 0x17000162 RID: 354
		// (get) Token: 0x060005D7 RID: 1495 RVA: 0x0001D26C File Offset: 0x0001B46C
		public bool estaMirandoDerecha
		{
			get
			{
				return this.estaMirando && this.m_NeckAndHead.estaMirandoDerecha;
			}
		}

		// Token: 0x1400005A RID: 90
		// (add) Token: 0x060005D8 RID: 1496 RVA: 0x0001D284 File Offset: 0x0001B484
		// (remove) Token: 0x060005D9 RID: 1497 RVA: 0x0001D2BC File Offset: 0x0001B4BC
		public event Action<ILookAtIK> updating;

		// Token: 0x1400005B RID: 91
		// (add) Token: 0x060005DA RID: 1498 RVA: 0x0001D2F4 File Offset: 0x0001B4F4
		// (remove) Token: 0x060005DB RID: 1499 RVA: 0x0001D32C File Offset: 0x0001B52C
		public event ILookAtHandlerHorizontalChange onCambioDeOrientacionHorizontal;

		// Token: 0x060005DC RID: 1500 RVA: 0x0001D364 File Offset: 0x0001B564
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (this.m_Spine == null)
			{
				throw new ArgumentNullException("m_Spine", "m_Spine null reference.");
			}
			if (this.m_NeckAndHead == null)
			{
				throw new ArgumentNullException("m_NeckAndHead", "m_NeckAndHead null reference.");
			}
			this.m_targets = base.GetComponent<ILookAtHeadTargets>();
			if (this.m_targets == null)
			{
				throw new ArgumentNullException("m_targets", "m_targets null reference.");
			}
			this.m_FemaleAnimController = this.GetComponentEnRoot(false);
		}

		// Token: 0x060005DD RID: 1501 RVA: 0x0001D3E4 File Offset: 0x0001B5E4
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_NeckAndHead.updating += this.OnHeadUpdating;
			this.m_NeckAndHead.onCambioDeOrientacionHorizontal += this.M_NeckAndHead_onCambioDeOrientacionHorizontal;
			this.m_Spine.updating += this.M_Spine_updating;
		}

		// Token: 0x060005DE RID: 1502 RVA: 0x0001D43C File Offset: 0x0001B63C
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_NeckAndHead)
			{
				this.m_NeckAndHead.updating -= this.OnHeadUpdating;
				this.m_NeckAndHead.onCambioDeOrientacionHorizontal -= this.M_NeckAndHead_onCambioDeOrientacionHorizontal;
			}
			if (this.m_Spine)
			{
				this.m_Spine.updating -= this.M_Spine_updating;
			}
		}

		// Token: 0x060005DF RID: 1503 RVA: 0x0001D4AF File Offset: 0x0001B6AF
		private void M_NeckAndHead_onCambioDeOrientacionHorizontal(LookAtIK_TargetTransformer obj)
		{
			ILookAtHandlerHorizontalChange lookAtHandlerHorizontalChange = this.onCambioDeOrientacionHorizontal;
			if (lookAtHandlerHorizontalChange == null)
			{
				return;
			}
			lookAtHandlerHorizontalChange(this);
		}

		// Token: 0x060005E0 RID: 1504 RVA: 0x0001D4C2 File Offset: 0x0001B6C2
		private void OnHeadUpdating(LookAtIK_TargetTransformer obj)
		{
			Action<ILookAtIK> action = this.updating;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x060005E1 RID: 1505 RVA: 0x0001D4D5 File Offset: 0x0001B6D5
		private void M_Spine_updating(LookAtIK_TargetTransformer obj)
		{
			if (this.m_FemaleAnimController.animatedPoseID == FemaleAnimatedPoseIDs.None && this.m_FemaleAnimController.EstaEnLocomotion())
			{
				this.m_Spine.TransformerWeight = 1f;
				return;
			}
			this.m_Spine.TransformerWeight = 0f;
		}

		// Token: 0x0400040A RID: 1034
		[SerializeField]
		private LookAtIK_TargetTransformer m_Spine;

		// Token: 0x0400040B RID: 1035
		[SerializeField]
		private LookAtIK_TargetTransformer m_NeckAndHead;

		// Token: 0x0400040C RID: 1036
		[SerializeField]
		[ReadOnlyUI]
		private FemaleAnimController m_FemaleAnimController;

		// Token: 0x0400040D RID: 1037
		private ILookAtHeadTargets m_targets;
	}
}
