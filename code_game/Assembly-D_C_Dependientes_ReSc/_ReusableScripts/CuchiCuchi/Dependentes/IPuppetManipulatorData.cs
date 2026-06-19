using System;
using Assets.Base.Bones.Gizmos.BeachGirl.Runtime;
using Assets.Base.Bones.Gizmos.BeachGirl.Runtime.IK;
using Assets.Base.Bones.Gizmos.Runtime;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.AI;
using Assets._ReusableScripts.CuchiCuchi.Skins;
using RootMotion.Dynamics;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes
{
	// Token: 0x02000035 RID: 53
	public interface IPuppetManipulatorData
	{
		// Token: 0x1700001E RID: 30
		// (get) Token: 0x060000F7 RID: 247
		IPuppetManipulable manipulandoA { get; }

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x060000F8 RID: 248
		Camera handMaleCamera { get; }

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x060000F9 RID: 249
		GizmosDeSkeleton skeletonGizmos { get; }

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x060000FA RID: 250
		HitSkinBasica tomandoSkin { get; }

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x060000FB RID: 251
		GizmoDeBoneRMInfo gizmo { get; }

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x060000FC RID: 252
		BoneGuiable boneGuiable { get; }

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x060000FD RID: 253
		LimbIKDeCustomPose[] limbIKDeCustomPoses { get; }

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x060000FE RID: 254
		Collider[] handColliders { get; }

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x060000FF RID: 255
		[Obsolete("", true)]
		int[] handCollidersDefaultLayers { get; }

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000100 RID: 256
		Muscle handMuscle { get; }

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000101 RID: 257
		FixedJoint handToGizmoJoin { get; }

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000102 RID: 258
		bool puedeInteractuarDefecto { get; }

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000103 RID: 259
		bool puedeReaccionarDefecto { get; }
	}
}
