using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi
{
	// Token: 0x020000C7 RID: 199
	public class SimpleCharacter : Character, ICharacter, ICharacterRoot, IComponentStartable, IComponentAwakeable, ICharacterTeleportable, ICharacterIdentificable, ICharacterUnico
	{
		// Token: 0x1700028F RID: 655
		// (get) Token: 0x060006C2 RID: 1730 RVA: 0x000144E2 File Offset: 0x000126E2
		public override bool isAlive
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000290 RID: 656
		// (get) Token: 0x060006C3 RID: 1731 RVA: 0x000144E5 File Offset: 0x000126E5
		public override Vector3 boneForward
		{
			get
			{
				return Vector3.forward;
			}
		}

		// Token: 0x17000291 RID: 657
		// (get) Token: 0x060006C4 RID: 1732 RVA: 0x000144EC File Offset: 0x000126EC
		public override Vector3 boneUp
		{
			get
			{
				return Vector3.up;
			}
		}

		// Token: 0x17000292 RID: 658
		// (get) Token: 0x060006C5 RID: 1733 RVA: 0x000144F3 File Offset: 0x000126F3
		public override Vector3 worldHeadPosition
		{
			get
			{
				return base.transform.position;
			}
		}

		// Token: 0x17000293 RID: 659
		// (get) Token: 0x060006C6 RID: 1734 RVA: 0x00014500 File Offset: 0x00012700
		public override Vector3 centerOfMassVelocity
		{
			get
			{
				return Vector3.zero;
			}
		}

		// Token: 0x17000294 RID: 660
		// (get) Token: 0x060006C7 RID: 1735 RVA: 0x00014507 File Offset: 0x00012707
		public override Quaternion centerOfMassRotation
		{
			get
			{
				return base.transform.rotation;
			}
		}

		// Token: 0x17000295 RID: 661
		// (get) Token: 0x060006C8 RID: 1736 RVA: 0x00014514 File Offset: 0x00012714
		public override Vector3 centerOfMassPosition
		{
			get
			{
				return base.transform.position;
			}
		}

		// Token: 0x17000296 RID: 662
		// (get) Token: 0x060006C9 RID: 1737 RVA: 0x00014521 File Offset: 0x00012721
		public override Vector3 centerOfMassUpDirection
		{
			get
			{
				return base.transform.up;
			}
		}

		// Token: 0x17000297 RID: 663
		// (get) Token: 0x060006CA RID: 1738 RVA: 0x0001452E File Offset: 0x0001272E
		public override Vector3 centerOfMassForwardDirection
		{
			get
			{
				return base.transform.forward;
			}
		}

		// Token: 0x17000298 RID: 664
		// (get) Token: 0x060006CB RID: 1739 RVA: 0x0001453B File Offset: 0x0001273B
		public override Vector3 centerOfMassRightDirection
		{
			get
			{
				return base.transform.right;
			}
		}

		// Token: 0x17000299 RID: 665
		// (get) Token: 0x060006CC RID: 1740 RVA: 0x00014548 File Offset: 0x00012748
		public override Vector3 worldFirstPersonViewPoint
		{
			get
			{
				return base.transform.position;
			}
		}

		// Token: 0x1700029A RID: 666
		// (get) Token: 0x060006CD RID: 1741 RVA: 0x00014555 File Offset: 0x00012755
		public override Vector3 worldViewDirection
		{
			get
			{
				return base.transform.forward;
			}
		}

		// Token: 0x1700029B RID: 667
		// (get) Token: 0x060006CE RID: 1742 RVA: 0x00014562 File Offset: 0x00012762
		public override Vector3 localFPSOffset
		{
			get
			{
				return Vector3.zero;
			}
		}

		// Token: 0x1700029C RID: 668
		// (get) Token: 0x060006CF RID: 1743 RVA: 0x00014569 File Offset: 0x00012769
		public override Vector3 localEarFormHeadR
		{
			get
			{
				return Vector3.zero;
			}
		}

		// Token: 0x1700029D RID: 669
		// (get) Token: 0x060006D0 RID: 1744 RVA: 0x00014570 File Offset: 0x00012770
		public override Vector3 localEarFormHeadL
		{
			get
			{
				return Vector3.zero;
			}
		}

		// Token: 0x1700029E RID: 670
		// (get) Token: 0x060006D1 RID: 1745 RVA: 0x00014577 File Offset: 0x00012777
		public override Vector3 worldHeadUp
		{
			get
			{
				return base.transform.up;
			}
		}

		// Token: 0x1700029F RID: 671
		// (get) Token: 0x060006D2 RID: 1746 RVA: 0x00014584 File Offset: 0x00012784
		public override float altura
		{
			get
			{
				return 1f;
			}
		}

		// Token: 0x170002A0 RID: 672
		// (get) Token: 0x060006D3 RID: 1747 RVA: 0x0001458B File Offset: 0x0001278B
		public override float escala
		{
			get
			{
				return 1f;
			}
		}

		// Token: 0x170002A1 RID: 673
		// (get) Token: 0x060006D4 RID: 1748 RVA: 0x00014592 File Offset: 0x00012792
		public override Transform trasnformParaObservar
		{
			get
			{
				return base.transform;
			}
		}

		// Token: 0x170002A2 RID: 674
		// (get) Token: 0x060006D5 RID: 1749 RVA: 0x0001459A File Offset: 0x0001279A
		public override Transform trasnformParaManipular
		{
			get
			{
				return base.transform;
			}
		}

		// Token: 0x170002A3 RID: 675
		// (get) Token: 0x060006D6 RID: 1750 RVA: 0x000145A2 File Offset: 0x000127A2
		public override Transform trasnformParaComunicarse
		{
			get
			{
				return base.transform;
			}
		}

		// Token: 0x170002A4 RID: 676
		// (get) Token: 0x060006D7 RID: 1751 RVA: 0x000145AA File Offset: 0x000127AA
		public override Transform animatorRootMotionTransform
		{
			get
			{
				return base.transform;
			}
		}

		// Token: 0x170002A5 RID: 677
		// (get) Token: 0x060006D8 RID: 1752 RVA: 0x000145B2 File Offset: 0x000127B2
		public override Animator bodyAnimator
		{
			get
			{
				return null;
			}
		}

		// Token: 0x170002A6 RID: 678
		// (get) Token: 0x060006D9 RID: 1753 RVA: 0x000145B5 File Offset: 0x000127B5
		public override Animator headAnimator
		{
			get
			{
				return null;
			}
		}

		// Token: 0x170002A7 RID: 679
		// (get) Token: 0x060006DA RID: 1754 RVA: 0x000145B8 File Offset: 0x000127B8
		public override Transform rootBoneTransform
		{
			get
			{
				return base.transform;
			}
		}

		// Token: 0x170002A8 RID: 680
		// (get) Token: 0x060006DB RID: 1755 RVA: 0x000145C0 File Offset: 0x000127C0
		public override Vector3 posicion
		{
			get
			{
				return base.transform.position;
			}
		}

		// Token: 0x170002A9 RID: 681
		// (get) Token: 0x060006DC RID: 1756 RVA: 0x000145CD File Offset: 0x000127CD
		public override Quaternion rotacion
		{
			get
			{
				return base.transform.rotation;
			}
		}

		// Token: 0x170002AA RID: 682
		// (get) Token: 0x060006DD RID: 1757 RVA: 0x000145DA File Offset: 0x000127DA
		public override ICharacter master
		{
			get
			{
				return null;
			}
		}

		// Token: 0x170002AB RID: 683
		// (get) Token: 0x060006DE RID: 1758 RVA: 0x000145DD File Offset: 0x000127DD
		public override float defaultEstatura
		{
			get
			{
				return 1f;
			}
		}

		// Token: 0x170002AC RID: 684
		// (get) Token: 0x060006DF RID: 1759 RVA: 0x000145E4 File Offset: 0x000127E4
		public override float defaultHandWidth
		{
			get
			{
				return 1f;
			}
		}

		// Token: 0x170002AD RID: 685
		// (get) Token: 0x060006E0 RID: 1760 RVA: 0x000145EB File Offset: 0x000127EB
		public override float defaultHandHeight
		{
			get
			{
				return 1f;
			}
		}

		// Token: 0x060006E1 RID: 1761 RVA: 0x000145F2 File Offset: 0x000127F2
		public override void IgnorarCollosionesConMano(Collider other, Side side, bool ignore)
		{
		}

		// Token: 0x060006E2 RID: 1762 RVA: 0x000145F4 File Offset: 0x000127F4
		public override void IgnorarCollosionesConManos(Collider other, bool ignore)
		{
		}

		// Token: 0x060006E3 RID: 1763 RVA: 0x000145F6 File Offset: 0x000127F6
		public override bool ObjetoEsMiAnteBrazo(Transform obj)
		{
			return obj.IsChildOf(base.transform);
		}

		// Token: 0x060006E4 RID: 1764 RVA: 0x00014604 File Offset: 0x00012804
		public override bool ObjetoEsMiDedo(Collider obj)
		{
			return obj.transform.IsChildOf(base.transform);
		}

		// Token: 0x060006E5 RID: 1765 RVA: 0x00014617 File Offset: 0x00012817
		public override bool ObjetoEsMiDedo(Rigidbody obj)
		{
			return obj.transform.IsChildOf(base.transform);
		}

		// Token: 0x060006E6 RID: 1766 RVA: 0x0001462A File Offset: 0x0001282A
		public override bool ObjetoEsMiDedo(Transform obj)
		{
			return obj.IsChildOf(base.transform);
		}

		// Token: 0x060006E7 RID: 1767 RVA: 0x00014638 File Offset: 0x00012838
		public override bool ObjetoEsMiDedo(Component obj)
		{
			return obj.transform.IsChildOf(base.transform);
		}

		// Token: 0x060006E8 RID: 1768 RVA: 0x0001464B File Offset: 0x0001284B
		public override bool ObjetoEsMiMano(Collider obj)
		{
			return obj.transform.IsChildOf(base.transform);
		}

		// Token: 0x060006E9 RID: 1769 RVA: 0x0001465E File Offset: 0x0001285E
		public override bool ObjetoEsMiMano(Rigidbody obj)
		{
			return obj.transform.IsChildOf(base.transform);
		}

		// Token: 0x060006EA RID: 1770 RVA: 0x00014671 File Offset: 0x00012871
		public override bool ObjetoEsMiMano(Transform obj)
		{
			return obj.IsChildOf(base.transform);
		}

		// Token: 0x060006EB RID: 1771 RVA: 0x0001467F File Offset: 0x0001287F
		public override bool ObjetoEsMiPene(Collider obj)
		{
			return obj.transform.IsChildOf(base.transform);
		}

		// Token: 0x060006EC RID: 1772 RVA: 0x00014692 File Offset: 0x00012892
		public override bool ObjetoEsMiPene(Rigidbody obj)
		{
			return obj.transform.IsChildOf(base.transform);
		}

		// Token: 0x060006ED RID: 1773 RVA: 0x000146A5 File Offset: 0x000128A5
		public override bool ObjetoEsMiPene(Transform obj)
		{
			return obj.IsChildOf(base.transform);
		}

		// Token: 0x060006EE RID: 1774 RVA: 0x000146B3 File Offset: 0x000128B3
		public override bool ObjetoEsMiPene(Component obj)
		{
			return obj.transform.IsChildOf(base.transform);
		}

		// Token: 0x060006EF RID: 1775 RVA: 0x000146C6 File Offset: 0x000128C6
		public override bool ObjetoEsMiPierna(Collider obj)
		{
			return obj.transform.IsChildOf(base.transform);
		}

		// Token: 0x060006F0 RID: 1776 RVA: 0x000146D9 File Offset: 0x000128D9
		public override bool ObjetoEsMiPierna(Rigidbody obj)
		{
			return obj.transform.IsChildOf(base.transform);
		}

		// Token: 0x060006F1 RID: 1777 RVA: 0x000146EC File Offset: 0x000128EC
		public override bool ObjetoEsMiPierna(Transform obj)
		{
			return obj.transform.IsChildOf(base.transform);
		}

		// Token: 0x060006F2 RID: 1778 RVA: 0x000146FF File Offset: 0x000128FF
		public override bool ObjetoEsMiTorzo(Collider obj)
		{
			return obj.transform.IsChildOf(base.transform);
		}

		// Token: 0x060006F3 RID: 1779 RVA: 0x00014712 File Offset: 0x00012912
		public override bool ObjetoEsMiTorzo(Rigidbody obj)
		{
			return obj.transform.IsChildOf(base.transform);
		}

		// Token: 0x060006F4 RID: 1780 RVA: 0x00014725 File Offset: 0x00012925
		public override bool ObjetoEsMiTorzo(Transform obj)
		{
			return obj.transform.IsChildOf(base.transform);
		}

		// Token: 0x060006F5 RID: 1781 RVA: 0x00014738 File Offset: 0x00012938
		public override Rigidbody TryObtenerPartePhysica(HumanBodyBones boneEnum)
		{
			return null;
		}

		// Token: 0x060006F6 RID: 1782 RVA: 0x0001473B File Offset: 0x0001293B
		public override Rigidbody TryObtenerPartePhysica(Transform characterBone)
		{
			return null;
		}

		// Token: 0x060006F8 RID: 1784 RVA: 0x00014746 File Offset: 0x00012946
		Transform ICharacterRoot.get_transform()
		{
			return base.transform;
		}

		// Token: 0x060006F9 RID: 1785 RVA: 0x0001474E File Offset: 0x0001294E
		T ICharacterRoot.GetComponentInChildren<T>()
		{
			return base.GetComponentInChildren<T>();
		}

		// Token: 0x060006FA RID: 1786 RVA: 0x00014756 File Offset: 0x00012956
		T ICharacterRoot.GetComponentInParent<T>()
		{
			return base.GetComponentInParent<T>();
		}

		// Token: 0x060006FB RID: 1787 RVA: 0x0001475E File Offset: 0x0001295E
		T ICharacterRoot.GetComponentInParent<T>(bool includeInactive)
		{
			return base.GetComponentInParent<T>(includeInactive);
		}

		// Token: 0x060006FC RID: 1788 RVA: 0x00014767 File Offset: 0x00012967
		T ICharacterRoot.GetComponentInChildren<T>(bool includeInactive)
		{
			return base.GetComponentInChildren<T>(includeInactive);
		}

		// Token: 0x060006FD RID: 1789 RVA: 0x00014770 File Offset: 0x00012970
		T ICharacterRoot.GetComponent<T>()
		{
			return base.GetComponent<T>();
		}

		// Token: 0x060006FE RID: 1790 RVA: 0x00014778 File Offset: 0x00012978
		void ICharacterRoot.GetComponentsInChildren<T>(List<T> results)
		{
			base.GetComponentsInChildren<T>(results);
		}

		// Token: 0x060006FF RID: 1791 RVA: 0x00014781 File Offset: 0x00012981
		void ICharacterRoot.GetComponentsInChildren<T>(bool includeInactive, List<T> result)
		{
			base.GetComponentsInChildren<T>(includeInactive, result);
		}

		// Token: 0x06000700 RID: 1792 RVA: 0x0001478B File Offset: 0x0001298B
		T[] ICharacterRoot.GetComponentsInChildren<T>(bool includeInactive)
		{
			return base.GetComponentsInChildren<T>(includeInactive);
		}

		// Token: 0x06000701 RID: 1793 RVA: 0x00014794 File Offset: 0x00012994
		Coroutine ICharacterRoot.StartCoroutine(IEnumerator routine)
		{
			return base.StartCoroutine(routine);
		}

		// Token: 0x06000702 RID: 1794 RVA: 0x0001479D File Offset: 0x0001299D
		bool IComponentAwakeable.get_isAwaken()
		{
			return base.isAwaken;
		}

		// Token: 0x06000703 RID: 1795 RVA: 0x000147A5 File Offset: 0x000129A5
		void IComponentAwakeable.ManualAwake()
		{
			base.ManualAwake();
		}
	}
}
