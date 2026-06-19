using System;
using UnityEngine;

namespace Assets
{
	// Token: 0x020000C4 RID: 196
	public abstract class DatosDeBoneBase
	{
		// Token: 0x17000101 RID: 257
		// (get) Token: 0x060005D5 RID: 1493 RVA: 0x00016F1F File Offset: 0x0001511F
		public Quaternion initialCurrentWorldRotation
		{
			get
			{
				return this.parentBone.rotation * this.initialLocalRotation * this.offSetToForward;
			}
		}

		// Token: 0x17000102 RID: 258
		// (get) Token: 0x060005D6 RID: 1494 RVA: 0x00016F42 File Offset: 0x00015142
		public Quaternion currentWorldRotation
		{
			get
			{
				return this.transform.rotation * this.offSetToForward;
			}
		}

		// Token: 0x17000103 RID: 259
		// (get) Token: 0x060005D7 RID: 1495 RVA: 0x00016F5A File Offset: 0x0001515A
		public Vector3 currentForward
		{
			get
			{
				return this.transform.TransformDirection(this.defaultForward);
			}
		}

		// Token: 0x17000104 RID: 260
		// (get) Token: 0x060005D8 RID: 1496 RVA: 0x00016F6D File Offset: 0x0001516D
		public Vector3 currentUp
		{
			get
			{
				return this.transform.TransformDirection(this.defaultUp);
			}
		}

		// Token: 0x17000105 RID: 261
		// (get) Token: 0x060005D9 RID: 1497 RVA: 0x00016F80 File Offset: 0x00015180
		public Vector3 currentRight
		{
			get
			{
				return this.transform.TransformDirection(this.defaultRight);
			}
		}

		// Token: 0x17000106 RID: 262
		// (get) Token: 0x060005DA RID: 1498 RVA: 0x00016F93 File Offset: 0x00015193
		public Vector3 posicionFinal
		{
			get
			{
				return this.m_posicionFinal;
			}
		}

		// Token: 0x17000107 RID: 263
		// (get) Token: 0x060005DB RID: 1499 RVA: 0x00016F9B File Offset: 0x0001519B
		public Quaternion rotacionFinal
		{
			get
			{
				return this.m_rotacionFinal;
			}
		}

		// Token: 0x17000108 RID: 264
		// (get) Token: 0x060005DC RID: 1500 RVA: 0x00016FA3 File Offset: 0x000151A3
		public Matrix4x4 localToWorldFinal
		{
			get
			{
				return this.m_localToWorldFinal;
			}
		}

		// Token: 0x17000109 RID: 265
		// (get) Token: 0x060005DD RID: 1501 RVA: 0x00016FAB File Offset: 0x000151AB
		public Vector3 animationPosition
		{
			get
			{
				return this.m_animationPosition;
			}
		}

		// Token: 0x1700010A RID: 266
		// (get) Token: 0x060005DE RID: 1502 RVA: 0x00016FB3 File Offset: 0x000151B3
		public Quaternion animationRotacion
		{
			get
			{
				return this.m_animationRotacion;
			}
		}

		// Token: 0x060005DF RID: 1503 RVA: 0x00016FBC File Offset: 0x000151BC
		public Vector3 AnimationTransformPoint(Vector3 point)
		{
			return Matrix4x4.TRS(this.m_animationPosition, this.m_animationRotacion, this.transform.lossyScale).MultiplyPoint3x4(point);
		}

		// Token: 0x060005E0 RID: 1504 RVA: 0x00016FF0 File Offset: 0x000151F0
		public Vector3 AnimationInverseTransformPoint(Vector3 point)
		{
			return Matrix4x4.TRS(this.m_animationPosition, this.m_animationRotacion, this.transform.lossyScale).inverse.MultiplyPoint3x4(point);
		}

		// Token: 0x060005E1 RID: 1505 RVA: 0x0001702C File Offset: 0x0001522C
		public Vector3 AnimationCorrectedTransformPoint(Vector3 point)
		{
			return Matrix4x4.TRS(this.m_animationPosition, this.m_animationRotacion * this.offSetToForward, this.transform.lossyScale).MultiplyPoint3x4(point);
		}

		// Token: 0x060005E2 RID: 1506 RVA: 0x0001706C File Offset: 0x0001526C
		public Vector3 AnimationCorrectedInverseTransformPoint(Vector3 point)
		{
			return Matrix4x4.TRS(this.m_animationPosition, this.m_animationRotacion * this.offSetToForward, this.transform.lossyScale).inverse.MultiplyPoint3x4(point);
		}

		// Token: 0x060005E3 RID: 1507 RVA: 0x000170B4 File Offset: 0x000152B4
		public Vector3 AnimationTransformVector(Vector3 point)
		{
			return Matrix4x4.TRS(this.m_animationPosition, this.m_animationRotacion, Vector3.one).MultiplyPoint3x4(point);
		}

		// Token: 0x060005E4 RID: 1508 RVA: 0x000170E0 File Offset: 0x000152E0
		public Vector3 AnimationInverseTransformVector(Vector3 point)
		{
			return Matrix4x4.TRS(this.m_animationPosition, this.m_animationRotacion, Vector3.one).inverse.MultiplyPoint3x4(point);
		}

		// Token: 0x060005E5 RID: 1509 RVA: 0x00017114 File Offset: 0x00015314
		public Vector3 AnimationCorrectedTransformVector(Vector3 point)
		{
			return Matrix4x4.TRS(this.m_animationPosition, this.m_animationRotacion * this.offSetToForward, Vector3.one).MultiplyPoint3x4(point);
		}

		// Token: 0x060005E6 RID: 1510 RVA: 0x0001714C File Offset: 0x0001534C
		public Vector3 AnimationCorrectedInverseTransformVector(Vector3 point)
		{
			return Matrix4x4.TRS(this.m_animationPosition, this.m_animationRotacion * this.offSetToForward, Vector3.one).inverse.MultiplyPoint3x4(point);
		}

		// Token: 0x060005E7 RID: 1511 RVA: 0x0001718C File Offset: 0x0001538C
		protected virtual void OnInit(Animator anim, Transform bone)
		{
			if (this.m_initiated)
			{
				throw new InvalidOperationException();
			}
			if (bone == null)
			{
				throw new ArgumentNullException("bone", "bone null reference.");
			}
			this.parentBone = bone.parent;
			this.initialLocalRotation = bone.localRotation;
			this.initialLocalPosition = bone.localPosition;
			this.m_initiated = true;
			this.transform = bone;
			this.defaultForward = this.transform.InverseTransformDirection(anim.transform.forward);
			this.defaultUp = this.transform.InverseTransformDirection(anim.transform.up);
			this.defaultRight = this.transform.InverseTransformDirection(anim.transform.right);
			this.offSetToForward = Quaternion.Inverse(bone.rotation) * anim.transform.rotation;
		}

		// Token: 0x060005E8 RID: 1512 RVA: 0x00017268 File Offset: 0x00015468
		public void OnPostAnimation()
		{
			if (!this.m_initiated)
			{
				throw new InvalidOperationException("No se Inicio datos de bone: " + this.transform.name);
			}
			this.m_animationPosition = this.transform.position;
			this.m_animationRotacion = this.transform.rotation;
		}

		// Token: 0x060005E9 RID: 1513 RVA: 0x000172BC File Offset: 0x000154BC
		public void OnPostProcesado()
		{
			if (!this.m_initiated)
			{
				throw new InvalidOperationException("No se Inicio datos de bone: " + this.transform.name);
			}
			this.m_posicionFinal = this.transform.position;
			this.m_rotacionFinal = this.transform.rotation;
			this.m_localToWorldFinal = this.transform.localToWorldMatrix;
		}

		// Token: 0x04000183 RID: 387
		[SerializeField]
		[ReadOnlyUI]
		private bool m_initiated;

		// Token: 0x04000184 RID: 388
		public Transform transform;

		// Token: 0x04000185 RID: 389
		public Transform parentBone;

		// Token: 0x04000186 RID: 390
		public Vector3 defaultForward;

		// Token: 0x04000187 RID: 391
		public Vector3 defaultUp;

		// Token: 0x04000188 RID: 392
		public Vector3 defaultRight;

		// Token: 0x04000189 RID: 393
		public Quaternion offSetToForward;

		// Token: 0x0400018A RID: 394
		public Quaternion initialLocalRotation;

		// Token: 0x0400018B RID: 395
		public Vector3 initialLocalPosition;

		// Token: 0x0400018C RID: 396
		[ReadOnlyUI]
		[SerializeField]
		private Vector3 m_posicionFinal;

		// Token: 0x0400018D RID: 397
		[ReadOnlyUI]
		[SerializeField]
		private Quaternion m_rotacionFinal;

		// Token: 0x0400018E RID: 398
		[ReadOnlyUI]
		[SerializeField]
		private Matrix4x4 m_localToWorldFinal;

		// Token: 0x0400018F RID: 399
		[ReadOnlyUI]
		[SerializeField]
		private Vector3 m_animationPosition;

		// Token: 0x04000190 RID: 400
		[ReadOnlyUI]
		[SerializeField]
		private Quaternion m_animationRotacion;
	}
}
