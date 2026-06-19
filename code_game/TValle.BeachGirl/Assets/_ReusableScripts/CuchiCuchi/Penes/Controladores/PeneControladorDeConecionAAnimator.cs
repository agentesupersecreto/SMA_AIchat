using System;
using Assets.TValle.BeachGirl;
using Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts;
using Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts.Penises;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Penes.Controladores
{
	// Token: 0x0200011D RID: 285
	public class PeneControladorDeConecionAAnimator : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x17000483 RID: 1155
		// (get) Token: 0x06000C45 RID: 3141 RVA: 0x00029627 File Offset: 0x00027827
		private Animator anim
		{
			get
			{
				return this.m_char.bodyAnimator;
			}
		}

		// Token: 0x06000C46 RID: 3142 RVA: 0x00029634 File Offset: 0x00027834
		protected sealed override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_char = base.GetComponentInParent<Character>();
			if (this.m_char == null)
			{
				throw new ArgumentNullException("m_char", "m_char null reference.");
			}
			if (base.transform.IsChildOf(this.m_char.bodyAnimator.transform))
			{
				throw new InvalidOperationException();
			}
			this.m_bonesRoot = base.transform.CreateChild("PenisBonesRoot");
		}

		// Token: 0x06000C47 RID: 3143 RVA: 0x000296AC File Offset: 0x000278AC
		protected sealed override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_Penis = this.m_char.GetComponentInChildren<Penis>();
			if (this.m_Penis == null)
			{
				throw new ArgumentNullException("m_Penis", "m_Penis null reference.");
			}
			this.m_chain = this.m_Penis.GetComponent<PenisLinearChain>();
			if (this.m_chain == null)
			{
				throw new ArgumentNullException("m_chain", "m_chain null reference.");
			}
			this.Subscribe();
		}

		// Token: 0x06000C48 RID: 3144 RVA: 0x00029723 File Offset: 0x00027923
		protected sealed override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			if (base.isStared)
			{
				this.Subscribe();
			}
			if (this.m_Penis != null && this.m_Penis.isPenetrating)
			{
				this.DesconectarDeCharacter();
			}
		}

		// Token: 0x06000C49 RID: 3145 RVA: 0x0002975A File Offset: 0x0002795A
		protected sealed override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.Unsubscribe();
			if (!quitting)
			{
				this.ConnectarACharacter();
			}
		}

		// Token: 0x06000C4A RID: 3146 RVA: 0x00029774 File Offset: 0x00027974
		private void Subscribe()
		{
			this.m_Penis.entered += this.M_Penis_entered;
			this.m_Penis.stayed += this.M_Penis_stayed;
			this.m_Penis.exited += this.M_Penis_exited;
		}

		// Token: 0x06000C4B RID: 3147 RVA: 0x000297C8 File Offset: 0x000279C8
		private void Unsubscribe()
		{
			this.m_Penis.entered -= this.M_Penis_entered;
			this.m_Penis.stayed -= this.M_Penis_stayed;
			this.m_Penis.exited -= this.M_Penis_exited;
		}

		// Token: 0x06000C4C RID: 3148 RVA: 0x0002981A File Offset: 0x00027A1A
		private void M_Penis_exited(IPeneConPartes pene, BoneStretchedChain hole)
		{
			this.ConnectarACharacter();
		}

		// Token: 0x06000C4D RID: 3149 RVA: 0x00029822 File Offset: 0x00027A22
		private void M_Penis_stayed(IPeneConPartes pene, BoneStretchedChain hole)
		{
			this.m_bonesRoot.localScale = this.m_Penis.scalerTransform.lossyScale;
		}

		// Token: 0x06000C4E RID: 3150 RVA: 0x0002983F File Offset: 0x00027A3F
		private void M_Penis_entered(IPeneConPartes pene, BoneStretchedChain hole)
		{
			this.DesconectarDeCharacter();
		}

		// Token: 0x06000C4F RID: 3151 RVA: 0x00029848 File Offset: 0x00027A48
		public void ConnectarACharacter()
		{
			if (this.m_chain == null)
			{
				return;
			}
			Transform puntoBaseTransform = this.m_chain.puntoBaseTransform;
			foreach (PenisPart penisPart in this.m_Penis.enumerator)
			{
				penisPart.charBone.parent = puntoBaseTransform;
				penisPart.charBone.localScale = Vector3.one;
			}
			this.m_Penis.transform.parent = this.anim.transform;
		}

		// Token: 0x06000C50 RID: 3152 RVA: 0x000298E4 File Offset: 0x00027AE4
		public void DesconectarDeCharacter()
		{
			if (this.m_chain == null)
			{
				return;
			}
			this.m_bonesRoot.SetPositionAndRotation(this.m_Penis.scalerTransform.position, this.m_Penis.scalerTransform.rotation);
			this.m_bonesRoot.localScale = this.m_Penis.scalerTransform.lossyScale;
			if (this.desconectarSkinning)
			{
				foreach (PenisPart penisPart in this.m_Penis.enumerator)
				{
					penisPart.charBone.parent = this.m_bonesRoot;
				}
			}
			if (this.desconectarPhyscis)
			{
				this.m_Penis.transform.parent = base.transform;
			}
		}

		// Token: 0x0400069D RID: 1693
		public bool desconectarPhyscis = true;

		// Token: 0x0400069E RID: 1694
		public bool desconectarSkinning = true;

		// Token: 0x0400069F RID: 1695
		private Character m_char;

		// Token: 0x040006A0 RID: 1696
		private PenisLinearChain m_chain;

		// Token: 0x040006A1 RID: 1697
		private Penis m_Penis;

		// Token: 0x040006A2 RID: 1698
		private Transform m_bonesRoot;
	}
}
