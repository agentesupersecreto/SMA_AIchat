using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Controllers
{
	// Token: 0x0200000E RID: 14
	public abstract class AnimController : AplicableBehaviour
	{
		// Token: 0x1700001A RID: 26
		// (get) Token: 0x0600008F RID: 143
		public abstract bool forzandoPelvisAltura { get; }

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000090 RID: 144
		public abstract Animator animator { get; }

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000091 RID: 145
		public abstract ICharacter character { get; }

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000092 RID: 146
		public abstract bool conControlSobreElPersonaje { get; }

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000093 RID: 147
		// (set) Token: 0x06000094 RID: 148
		public abstract TipoDePose currentPose { get; set; }

		// Token: 0x06000095 RID: 149
		public abstract void OnPose();

		// Token: 0x06000096 RID: 150
		public abstract void LiberarAtaduras();

		// Token: 0x06000097 RID: 151
		public abstract void SetDefaultPose();

		// Token: 0x14000008 RID: 8
		// (add) Token: 0x06000098 RID: 152
		// (remove) Token: 0x06000099 RID: 153
		public abstract event Action<AnimController> poseChanged;

		// Token: 0x0600009A RID: 154
		public abstract void UpdatePoseConfig(bool force = false);

		// Token: 0x0200002B RID: 43
		public static class AnimatorVariables
		{
			// Token: 0x040000AB RID: 171
			public static readonly int PelvisOffsetX = Animator.StringToHash("PelvisOffsetX");

			// Token: 0x040000AC RID: 172
			public static readonly int PelvisOffsetY = Animator.StringToHash("PelvisOffsetY");

			// Token: 0x040000AD RID: 173
			public static readonly int PelvisOffsetZ = Animator.StringToHash("PelvisOffsetZ");
		}
	}
}
