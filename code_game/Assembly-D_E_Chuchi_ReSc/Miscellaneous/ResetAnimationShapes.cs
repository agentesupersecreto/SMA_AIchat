using System;
using System.Collections.Generic;
using Assets._ReusableScripts.Globales.Mapas;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Miscellaneous
{
	// Token: 0x02000167 RID: 359
	public sealed class ResetAnimationShapes : AplicableBehaviour
	{
		// Token: 0x170001BC RID: 444
		// (get) Token: 0x06000831 RID: 2097 RVA: 0x00014087 File Offset: 0x00012287
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.update1);
			}
		}

		// Token: 0x06000832 RID: 2098 RVA: 0x00025E24 File Offset: 0x00024024
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			Character componentEnRoot = this.GetComponentEnRoot(false);
			this.m_Animator = ((componentEnRoot != null) ? componentEnRoot.bodyAnimator : null);
			if (this.m_Animator == null)
			{
				throw new ArgumentNullException("m_Animator", "m_Animator null reference.");
			}
			this.m_animatorEnableState = this.m_Animator.enabled;
			this.m_AnimatorUpdateMode = this.m_Animator.updateMode;
		}

		// Token: 0x06000833 RID: 2099 RVA: 0x00025E90 File Offset: 0x00024090
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.onDisable)
			{
				this.ResetShapes();
			}
		}

		// Token: 0x06000834 RID: 2100 RVA: 0x00025EA8 File Offset: 0x000240A8
		public override void OnUpdateEvent1()
		{
			if (this.m_Animator.enabled != this.m_animatorEnableState)
			{
				this.m_animatorEnableState = this.m_Animator.enabled;
				if (!this.m_animatorEnableState && this.onAnimatorDisable)
				{
					this.ResetShapes();
				}
			}
			if (this.m_Animator.updateMode != this.m_AnimatorUpdateMode)
			{
				this.m_AnimatorUpdateMode = this.m_Animator.updateMode;
				this.ResetShapes();
			}
		}

		// Token: 0x06000835 RID: 2101 RVA: 0x00025F1C File Offset: 0x0002411C
		public void ResetShapes()
		{
			base.GetComponentsInChildren<SkinnedMeshRenderer>(true, this.m_temp);
			for (int i = 0; i < this.m_temp.Count; i++)
			{
				this.ResetShapes(this.m_temp[i]);
			}
		}

		// Token: 0x06000836 RID: 2102 RVA: 0x00025F60 File Offset: 0x00024160
		private void ResetShapes(SkinnedMeshRenderer render)
		{
			if (!MapaSingleton<MapaDeCCAnimationBlendShapes>.Existe)
			{
				return;
			}
			MapaDeCCAnimationBlendShapes instance = MapaSingleton<MapaDeCCAnimationBlendShapes>.instance;
			Mesh sharedMesh = render.sharedMesh;
			for (int i = 0; i < instance.valores.Count; i++)
			{
				int blendShapeIndex = sharedMesh.GetBlendShapeIndex(instance.valores[i]);
				if (blendShapeIndex >= 0)
				{
					render.SetBlendShapeWeight(blendShapeIndex, 0f);
				}
			}
		}

		// Token: 0x06000837 RID: 2103 RVA: 0x00025FBB File Offset: 0x000241BB
		protected override void OnAplicar2()
		{
			base.OnAplicar2();
			this.ResetShapes();
		}

		// Token: 0x06000838 RID: 2104 RVA: 0x00025FC9 File Offset: 0x000241C9
		protected override CustomMonobehaviourBotonConfig Boton2()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "Reset"
			};
		}

		// Token: 0x0400066A RID: 1642
		public bool onDisable = true;

		// Token: 0x0400066B RID: 1643
		public bool onAnimatorDisable = true;

		// Token: 0x0400066C RID: 1644
		public bool onUpdateModeChange = true;

		// Token: 0x0400066D RID: 1645
		[SerializeField]
		private Animator m_Animator;

		// Token: 0x0400066E RID: 1646
		[SerializeField]
		private bool m_animatorEnableState;

		// Token: 0x0400066F RID: 1647
		[SerializeField]
		private AnimatorUpdateMode m_AnimatorUpdateMode;

		// Token: 0x04000670 RID: 1648
		private List<SkinnedMeshRenderer> m_temp = new List<SkinnedMeshRenderer>();
	}
}
