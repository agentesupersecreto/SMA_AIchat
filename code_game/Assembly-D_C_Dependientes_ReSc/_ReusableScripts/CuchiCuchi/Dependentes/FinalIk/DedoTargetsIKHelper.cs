using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk
{
	// Token: 0x02000178 RID: 376
	[Serializable]
	public class DedoTargetsIKHelper
	{
		// Token: 0x0600081D RID: 2077 RVA: 0x0002A9A4 File Offset: 0x00028BA4
		public DedoTargetsIKHelper(Transform Hand, Transform Proximal, Transform DistalTarget, Transform HandGuide, Transform DistalGuide, Transform ProximalGuide = null)
		{
			if (Hand == null)
			{
				throw new ArgumentNullException("Hand", "Hand null reference.");
			}
			if (Proximal == null)
			{
				throw new ArgumentNullException("Proximal", "Proximal null reference.");
			}
			if (DistalTarget == null)
			{
				throw new ArgumentNullException("DistalTarget", "DistalTarget null reference.");
			}
			if (HandGuide == null)
			{
				throw new ArgumentNullException("HandGuide", "HandGuide null reference.");
			}
			if (DistalGuide == null)
			{
				throw new ArgumentNullException("DistalGuide", "DistalGuide null reference.");
			}
			this.m_Hand = Hand;
			this.m_Proximal = Proximal;
			this.m_DistalTarget = DistalTarget;
			this.m_HandGuia = HandGuide;
			this.m_ProximalGuia = ProximalGuide;
			this.m_DistalGuia = DistalGuide;
			this.m_offsetParaHand = Quaternion.Inverse(HandGuide.rotation) * Hand.rotation;
			if (ProximalGuide != null)
			{
				this.m_offsetParaProximital = Quaternion.Inverse(ProximalGuide.rotation) * Proximal.rotation;
			}
			else
			{
				this.m_offsetParaProximital = Quaternion.identity;
			}
			this.m_offsetParaDistal = Quaternion.Inverse(DistalGuide.rotation) * DistalTarget.rotation;
			DedoTargetsIKHelper.CalculeLocalRotationFrom(Hand, HandGuide, Proximal, ProximalGuide, this.m_offsetParaHand, this.m_offsetParaProximital, ref this.m_ProximitalLocalRotationFromHand);
			DedoTargetsIKHelper.CalculeLocalRotationFrom(Proximal, ProximalGuide, DistalTarget, DistalGuide, this.m_offsetParaProximital, this.m_offsetParaDistal, ref this.m_DistalLocalRotationFromProximal);
			DedoTargetsIKHelper.CalculeLocalPositionFrom(Hand, HandGuide, Proximal, ProximalGuide, this.m_offsetParaHand, ref this.m_ProximitalLocalPositionFromHand);
			DedoTargetsIKHelper.CalculeLocalPositionFrom(Hand, HandGuide, DistalTarget, DistalGuide, this.m_offsetParaHand, ref this.m_DistalLocalPositionFromHand);
			Quaternion quaternion = Quaternion.LookRotation(this.m_Proximal.position - this.m_DistalTarget.position, this.m_HandGuia.rotation * Vector3.up);
			this.m_offsetParaDistalFromDirectionToProximital = Quaternion.Inverse(quaternion) * DistalTarget.rotation;
		}

		// Token: 0x0600081E RID: 2078 RVA: 0x0002AB88 File Offset: 0x00028D88
		private static void CalculeLocalRotationFrom(Transform parent, Transform parentGuia, Transform bone, Transform guia, Quaternion parentOffset, Quaternion boneOffset, ref Quaternion resultado)
		{
			Transform transform = ((parentGuia == null) ? parent : parentGuia);
			Transform transform2 = ((guia == null) ? bone : guia);
			Quaternion quaternion = ((parentGuia == null) ? Quaternion.identity : parentOffset);
			Quaternion quaternion2 = ((guia == null) ? Quaternion.identity : boneOffset);
			DedoTargetsIKHelper.CalculeLocalRotationFrom(transform, transform2, quaternion, quaternion2, ref resultado);
		}

		// Token: 0x0600081F RID: 2079 RVA: 0x0002ABE0 File Offset: 0x00028DE0
		private static void CalculeLocalRotationFrom(Transform parent, Transform bone, Quaternion parentOffset, Quaternion boneOffset, ref Quaternion resultado)
		{
			Quaternion quaternion = parent.rotation * parentOffset;
			resultado = Quaternion.Inverse(quaternion) * (bone.rotation * boneOffset);
		}

		// Token: 0x06000820 RID: 2080 RVA: 0x0002AC18 File Offset: 0x00028E18
		private static void CalculeLocalPositionFrom(Transform parent, Transform parentGuia, Transform bone, Transform guia, Quaternion parentOffset, ref Vector3 resultado)
		{
			Transform transform = ((parentGuia == null) ? parent : parentGuia);
			Transform transform2 = ((guia == null) ? bone : guia);
			Quaternion quaternion = ((parentGuia == null) ? Quaternion.identity : parentOffset);
			DedoTargetsIKHelper.CalculeLocalPositionFrom(transform, transform2, quaternion, ref resultado);
		}

		// Token: 0x06000821 RID: 2081 RVA: 0x0002AC5C File Offset: 0x00028E5C
		private static void CalculeLocalPositionFrom(Transform parent, Transform bone, Quaternion parentOffset, ref Vector3 resultado)
		{
			Quaternion rotation = parent.rotation;
			parent.rotation = rotation * parentOffset;
			resultado = parent.InverseTransformPoint(bone.position);
			parent.rotation = rotation;
		}

		// Token: 0x06000822 RID: 2082 RVA: 0x0002AC98 File Offset: 0x00028E98
		public void UpdateCurrentLocalPose()
		{
			this.m_ProximitalCurrentLocalPositionFromHand = this.m_Hand.InverseTransformPoint(this.m_Proximal.position);
			this.m_DistalCurrentLocalPositionFromHand = this.m_Hand.InverseTransformPoint(this.m_DistalTarget.position);
			this.m_ProximitalCurrentLocalRotationFromHand = Quaternion.Inverse(this.m_Hand.rotation) * this.m_Proximal.rotation;
			this.m_DistalCurrentLocalRotationFromProximal = Quaternion.Inverse(this.m_Proximal.rotation) * this.m_DistalTarget.rotation;
			this.m_ProximitalLocalPositionFromHandPoseResult = this.m_ProximitalLocalPositionFromHand;
			this.m_DistalLocalPositionFromHandPoseResult = this.m_DistalLocalPositionFromHand;
			this.m_ProximitalLocalRotationFromHandPoseResult = this.m_ProximitalLocalRotationFromHand;
			this.m_DistalLocalRotationFromProximalPoseResult = this.m_DistalLocalRotationFromProximal;
		}

		// Token: 0x06000823 RID: 2083 RVA: 0x0002AD59 File Offset: 0x00028F59
		public void UpdateHandPosition()
		{
			this.m_Hand.SetPositionAndRotation(this.m_HandGuia.position, this.m_HandGuia.rotation * this.m_offsetParaHand);
		}

		// Token: 0x06000824 RID: 2084 RVA: 0x0002AD88 File Offset: 0x00028F88
		public void ModificarPoseResultCasting(float characterScale, int layerMask)
		{
			float num = 0.125f * characterScale;
			Vector3 forward = this.m_DistalGuia.forward;
			RaycastHit raycastHit;
			if (Physics.Raycast(this.m_DistalGuia.position - forward * num * 0.8f, forward, out raycastHit, num, layerMask, QueryTriggerInteraction.Ignore))
			{
				this.m_DistalLocalPositionFromHandPoseResult = this.m_Hand.InverseTransformPoint(raycastHit.point);
			}
		}

		// Token: 0x06000825 RID: 2085 RVA: 0x0002ADF0 File Offset: 0x00028FF0
		public void UpdatePoseToBones(float maxDelta)
		{
			this.m_DistalCurrentLocalPositionFromHand = Vector3.Lerp(this.m_DistalCurrentLocalPositionFromHand, this.m_DistalLocalPositionFromHandPoseResult, maxDelta);
			this.m_ProximitalCurrentLocalPositionFromHand = Vector3.Lerp(this.m_ProximitalCurrentLocalPositionFromHand, this.m_ProximitalLocalPositionFromHandPoseResult, maxDelta);
			Vector3 vector = this.m_Hand.TransformPoint(this.m_ProximitalCurrentLocalPositionFromHand);
			Vector3 vector2 = this.m_Hand.TransformPoint(this.m_DistalCurrentLocalPositionFromHand);
			Quaternion quaternion = Quaternion.LookRotation(vector - vector2, this.m_HandGuia.rotation * Vector3.up) * this.m_offsetParaDistalFromDirectionToProximital;
			this.m_DistalTarget.SetPositionAndRotation(vector2, quaternion);
		}

		// Token: 0x0400066C RID: 1644
		[ReadOnlyUI]
		[SerializeField]
		private Quaternion m_offsetParaDistalFromDirectionToProximital;

		// Token: 0x0400066D RID: 1645
		[ReadOnlyUI]
		[SerializeField]
		private Quaternion m_offsetParaHand;

		// Token: 0x0400066E RID: 1646
		[ReadOnlyUI]
		[SerializeField]
		private Quaternion m_offsetParaProximital;

		// Token: 0x0400066F RID: 1647
		[ReadOnlyUI]
		[SerializeField]
		private Quaternion m_offsetParaDistal;

		// Token: 0x04000670 RID: 1648
		[ReadOnlyUI]
		[SerializeField]
		private Quaternion m_ProximitalLocalRotationFromHand;

		// Token: 0x04000671 RID: 1649
		[ReadOnlyUI]
		[SerializeField]
		private Quaternion m_DistalLocalRotationFromProximal;

		// Token: 0x04000672 RID: 1650
		[ReadOnlyUI]
		[SerializeField]
		private Vector3 m_ProximitalLocalPositionFromHand;

		// Token: 0x04000673 RID: 1651
		[ReadOnlyUI]
		[SerializeField]
		private Vector3 m_DistalLocalPositionFromHand;

		// Token: 0x04000674 RID: 1652
		[ReadOnlyUI]
		[SerializeField]
		private Transform m_Hand;

		// Token: 0x04000675 RID: 1653
		[ReadOnlyUI]
		[SerializeField]
		private Transform m_Proximal;

		// Token: 0x04000676 RID: 1654
		[ReadOnlyUI]
		[SerializeField]
		private Transform m_DistalTarget;

		// Token: 0x04000677 RID: 1655
		[ReadOnlyUI]
		[SerializeField]
		private Transform m_HandGuia;

		// Token: 0x04000678 RID: 1656
		[ReadOnlyUI]
		[SerializeField]
		private Transform m_ProximalGuia;

		// Token: 0x04000679 RID: 1657
		[ReadOnlyUI]
		[SerializeField]
		private Transform m_DistalGuia;

		// Token: 0x0400067A RID: 1658
		[ReadOnlyUI]
		[SerializeField]
		private Quaternion m_ProximitalCurrentLocalRotationFromHand;

		// Token: 0x0400067B RID: 1659
		[ReadOnlyUI]
		[SerializeField]
		private Quaternion m_DistalCurrentLocalRotationFromProximal;

		// Token: 0x0400067C RID: 1660
		[ReadOnlyUI]
		[SerializeField]
		private Vector3 m_ProximitalCurrentLocalPositionFromHand;

		// Token: 0x0400067D RID: 1661
		[ReadOnlyUI]
		[SerializeField]
		private Vector3 m_DistalCurrentLocalPositionFromHand;

		// Token: 0x0400067E RID: 1662
		[ReadOnlyUI]
		[SerializeField]
		private Quaternion m_ProximitalLocalRotationFromHandPoseResult;

		// Token: 0x0400067F RID: 1663
		[ReadOnlyUI]
		[SerializeField]
		private Quaternion m_DistalLocalRotationFromProximalPoseResult;

		// Token: 0x04000680 RID: 1664
		[ReadOnlyUI]
		[SerializeField]
		private Vector3 m_ProximitalLocalPositionFromHandPoseResult;

		// Token: 0x04000681 RID: 1665
		[ReadOnlyUI]
		[SerializeField]
		private Vector3 m_DistalLocalPositionFromHandPoseResult;
	}
}
