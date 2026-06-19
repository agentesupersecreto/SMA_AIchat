using System;
using Assets.TValle.BeachGirl.Runtime.IK;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.LookAt
{
	// Token: 0x02000092 RID: 146
	[RequireComponent(typeof(LookAtIK))]
	public sealed class ProveedorDeDataDeLookAtIK : CustomMonobehaviour, LookAtIK_TargetTransformer.IProveedorDeData
	{
		// Token: 0x060005E3 RID: 1507 RVA: 0x0001D51C File Offset: 0x0001B71C
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_LookAtIK = base.GetComponent<LookAtIK>();
			this.m_anim = this.GetComponentEnRoot(false);
			this.headEstado.Init(this.m_anim.GetBoneTransform(HumanBodyBones.Head), this.m_anim);
			this.neckEstado.Init(this.m_anim.GetBoneTransform(HumanBodyBones.Neck), this.m_anim);
			this.chestEstado.Init(this.m_anim.GetBoneTransform(HumanBodyBones.Chest), this.m_anim);
			this.spineEstado.Init(this.m_anim.GetBoneTransform(HumanBodyBones.Spine), this.m_anim);
		}

		// Token: 0x060005E4 RID: 1508 RVA: 0x0001D5BE File Offset: 0x0001B7BE
		public BoneState ObtenerChestPreIKEstado()
		{
			this.chestEstado.UpdatePreIKState();
			return this.chestEstado.preIK;
		}

		// Token: 0x060005E5 RID: 1509 RVA: 0x0001D5D6 File Offset: 0x0001B7D6
		public BoneState ObtenerHeadPreIKEstado()
		{
			this.headEstado.UpdatePreIKState();
			return this.headEstado.preIK;
		}

		// Token: 0x060005E6 RID: 1510 RVA: 0x0001D5EE File Offset: 0x0001B7EE
		public BoneState ObtenerNeckPreIKEstado()
		{
			this.neckEstado.UpdatePreIKState();
			return this.neckEstado.preIK;
		}

		// Token: 0x060005E7 RID: 1511 RVA: 0x0001D608 File Offset: 0x0001B808
		public BoneState ObtenerLastBonePreIKEstado()
		{
			if (this.m_LookAtIK.solver.headWeight > 0f)
			{
				this.headEstado.UpdateCurrentFramePreIKState();
				return this.headEstado.preIK;
			}
			this.chestEstado.UpdateCurrentFramePreIKState();
			return this.chestEstado.preIK;
		}

		// Token: 0x060005E8 RID: 1512 RVA: 0x0001D659 File Offset: 0x0001B859
		public BoneState ObtenerSpinePreIKEstado()
		{
			this.spineEstado.UpdatePreIKState();
			return this.spineEstado.preIK;
		}

		// Token: 0x060005E9 RID: 1513 RVA: 0x0001D671 File Offset: 0x0001B871
		public BoneState ObtenerHeadPostIKEstado()
		{
			this.headEstado.UpdatePostIKState();
			return this.headEstado.postIK;
		}

		// Token: 0x060005EA RID: 1514 RVA: 0x0001D689 File Offset: 0x0001B889
		public BoneState ObtenerNeckPostIKEstado()
		{
			this.neckEstado.UpdatePostIKState();
			return this.neckEstado.postIK;
		}

		// Token: 0x060005EB RID: 1515 RVA: 0x0001D6A4 File Offset: 0x0001B8A4
		public BoneState ObtenerLastBonePostIKEstado()
		{
			if (this.m_LookAtIK.solver.headWeight > 0f)
			{
				this.headEstado.UpdateCurrentFramePostIKState();
				return this.headEstado.postIK;
			}
			this.chestEstado.UpdateCurrentFramePostIKState();
			return this.chestEstado.postIK;
		}

		// Token: 0x060005EC RID: 1516 RVA: 0x0001D6F5 File Offset: 0x0001B8F5
		public BoneState ObtenerChestPostIKEstado()
		{
			this.chestEstado.UpdatePostIKState();
			return this.chestEstado.postIK;
		}

		// Token: 0x060005ED RID: 1517 RVA: 0x0001D70D File Offset: 0x0001B90D
		public BoneState ObtenerSpinePostIKEstado()
		{
			this.spineEstado.UpdatePostIKState();
			return this.spineEstado.postIK;
		}

		// Token: 0x04000410 RID: 1040
		private LookAtIK m_LookAtIK;

		// Token: 0x04000411 RID: 1041
		private Animator m_anim;

		// Token: 0x04000412 RID: 1042
		[SerializeField]
		private EstadosDeBone headEstado = new EstadosDeBone();

		// Token: 0x04000413 RID: 1043
		[SerializeField]
		private EstadosDeBone neckEstado = new EstadosDeBone();

		// Token: 0x04000414 RID: 1044
		[SerializeField]
		private EstadosDeBone chestEstado = new EstadosDeBone();

		// Token: 0x04000415 RID: 1045
		[SerializeField]
		private EstadosDeBone spineEstado = new EstadosDeBone();
	}
}
