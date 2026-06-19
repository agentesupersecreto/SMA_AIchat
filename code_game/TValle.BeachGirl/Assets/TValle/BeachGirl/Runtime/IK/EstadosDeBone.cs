using System;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.IK
{
	// Token: 0x020000A1 RID: 161
	[Serializable]
	public class EstadosDeBone
	{
		// Token: 0x060004F1 RID: 1265 RVA: 0x0000FEA8 File Offset: 0x0000E0A8
		public void Init(Transform bone, Animator anim)
		{
			this.bone = bone;
			this.initial = new BoneState();
			this.initial.Init(bone, null, anim);
			this.preIK = new BoneState();
			this.preIK.Init(bone, this.initial, anim);
			this.postIK = new BoneState();
			this.postIK.Init(bone, this.initial, anim);
		}

		// Token: 0x060004F2 RID: 1266 RVA: 0x0000FF11 File Offset: 0x0000E111
		public void UpdateCurrentFramePreIKState()
		{
			if (this.preID.IsCurrent())
			{
				return;
			}
			this.UpdatePreIKState();
		}

		// Token: 0x060004F3 RID: 1267 RVA: 0x0000FF27 File Offset: 0x0000E127
		public void UpdateCurrentFramePostIKState()
		{
			if (this.postID.IsCurrent())
			{
				return;
			}
			this.UpdatePostIKState();
		}

		// Token: 0x060004F4 RID: 1268 RVA: 0x0000FF3D File Offset: 0x0000E13D
		public void UpdatePreIKState()
		{
			this.preIK.Save();
			this.preID = UpdateAutoId.current;
		}

		// Token: 0x060004F5 RID: 1269 RVA: 0x0000FF55 File Offset: 0x0000E155
		public void UpdatePostIKState()
		{
			this.postIK.Save();
			this.postID = UpdateAutoId.current;
		}

		// Token: 0x040002E6 RID: 742
		public UpdateAutoId preID;

		// Token: 0x040002E7 RID: 743
		public UpdateAutoId postID;

		// Token: 0x040002E8 RID: 744
		public Transform bone;

		// Token: 0x040002E9 RID: 745
		public Quaternion initialLocalRotation;

		// Token: 0x040002EA RID: 746
		public Vector3 initialLocalPosition;

		// Token: 0x040002EB RID: 747
		public BoneState initial;

		// Token: 0x040002EC RID: 748
		public BoneState preIK;

		// Token: 0x040002ED RID: 749
		public BoneState postIK;
	}
}
