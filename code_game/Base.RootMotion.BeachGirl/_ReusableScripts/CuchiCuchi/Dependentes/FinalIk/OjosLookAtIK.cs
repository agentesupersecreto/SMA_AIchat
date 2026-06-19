using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk
{
	// Token: 0x02000086 RID: 134
	public class OjosLookAtIK : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x17000130 RID: 304
		// (get) Token: 0x06000533 RID: 1331 RVA: 0x0001A51F File Offset: 0x0001871F
		public Transform ojoL
		{
			get
			{
				return this.m_ojol;
			}
		}

		// Token: 0x17000131 RID: 305
		// (get) Token: 0x06000534 RID: 1332 RVA: 0x0001A527 File Offset: 0x00018727
		public Transform ojoR
		{
			get
			{
				return this.m_ojor;
			}
		}

		// Token: 0x17000132 RID: 306
		// (get) Token: 0x06000535 RID: 1333 RVA: 0x0001A530 File Offset: 0x00018730
		public float verticalModR
		{
			get
			{
				return Mathf.InverseLerp(0f, Mathf.Min(this.OjoRConfig.maxVerticalAngle, this.OjoRConfig.maxAngle), Mathf.Abs(this.verticalAngleR)) * (float)((this.verticalAngleR < 0f) ? (-1) : 1);
			}
		}

		// Token: 0x17000133 RID: 307
		// (get) Token: 0x06000536 RID: 1334 RVA: 0x0001A580 File Offset: 0x00018780
		public float verticalModL
		{
			get
			{
				return Mathf.InverseLerp(0f, Mathf.Min(this.OjoLConfig.maxVerticalAngle, this.OjoLConfig.maxAngle), Mathf.Abs(this.verticalAngleL)) * (float)((this.verticalAngleL < 0f) ? (-1) : 1);
			}
		}

		// Token: 0x14000051 RID: 81
		// (add) Token: 0x06000537 RID: 1335 RVA: 0x0001A5D0 File Offset: 0x000187D0
		// (remove) Token: 0x06000538 RID: 1336 RVA: 0x0001A608 File Offset: 0x00018808
		public event Action<OjosLookAtIK> solved;

		// Token: 0x17000134 RID: 308
		// (get) Token: 0x06000539 RID: 1337 RVA: 0x0001A63D File Offset: 0x0001883D
		public Vector3 ojoLCurrentForward
		{
			get
			{
				return this.m_ojol.TransformDirection(this.m_initialAnimatorOjoLForward);
			}
		}

		// Token: 0x17000135 RID: 309
		// (get) Token: 0x0600053A RID: 1338 RVA: 0x0001A650 File Offset: 0x00018850
		public Vector3 ojoRCurrentForward
		{
			get
			{
				return this.m_ojor.TransformDirection(this.m_initialAnimatorOjoRForward);
			}
		}

		// Token: 0x17000136 RID: 310
		// (get) Token: 0x0600053B RID: 1339 RVA: 0x0001A663 File Offset: 0x00018863
		public Matrix4x4 ojoLToHead
		{
			get
			{
				return Math3dTvalle.WorldIsTransform(this.m_ojol, this.head);
			}
		}

		// Token: 0x17000137 RID: 311
		// (get) Token: 0x0600053C RID: 1340 RVA: 0x0001A676 File Offset: 0x00018876
		public Matrix4x4 ojoRToHead
		{
			get
			{
				return Math3dTvalle.WorldIsTransform(this.m_ojor, this.head);
			}
		}

		// Token: 0x0600053D RID: 1341 RVA: 0x0001A689 File Offset: 0x00018889
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			base.SetInicializable();
			base.SetManualStart();
		}

		// Token: 0x0600053E RID: 1342 RVA: 0x0001A6A0 File Offset: 0x000188A0
		public void Init(Animator anim)
		{
			if (anim == null)
			{
				throw new ArgumentNullException("anim", "anim null reference.");
			}
			this.m_Animator = anim;
			this.head = this.m_Animator.GetBoneTransform(HumanBodyBones.Head);
			this.m_ojol = this.m_Animator.GetBoneTransform(HumanBodyBones.LeftEye);
			this.m_ojor = this.m_Animator.GetBoneTransform(HumanBodyBones.RightEye);
			Matrix4x4 ojoLToHead = this.ojoLToHead;
			Matrix4x4 ojoRToHead = this.ojoRToHead;
			this.m_initialLocalOjoLForward = ojoLToHead.MultiplyVector(Vector3.forward);
			this.m_initialLocalOjoRForward = ojoRToHead.MultiplyVector(Vector3.forward);
			this.m_initialLocalOjoLUp = ojoLToHead.MultiplyVector(Vector3.up);
			this.m_initialLocalOjoRUp = ojoRToHead.MultiplyVector(Vector3.up);
			this.m_initialLocalOjoLRight = ojoLToHead.MultiplyVector(Vector3.right);
			this.m_initialLocalOjoRRight = ojoRToHead.MultiplyVector(Vector3.right);
			this.m_initialAnimatorOjoLForward = this.m_ojol.InverseTransformDirection(anim.transform.forward);
			this.m_initialAnimatorOjoRForward = this.m_ojor.InverseTransformDirection(anim.transform.forward);
			base.Initialize();
			base.ManualStart();
		}

		// Token: 0x0600053F RID: 1343 RVA: 0x0001A7C4 File Offset: 0x000189C4
		public void Solve()
		{
			if (this.IKPositionWeight <= 0f || !this.m_Animator.isActiveAndEnabled)
			{
				return;
			}
			if (this.ojoLWeight > 0f)
			{
				OjosLookAtIK.solve(this.m_ojol, this.head, this.m_initialLocalOjoLForward, this.m_initialLocalOjoLUp, this.m_initialLocalOjoLRight, this.IKPosition, this.IKPositionWeight * this.ojoLWeight, this.OjoLConfig.maxAngle, this.OjoLConfig.maxHorizontalAngle, this.OjoLConfig.maxVerticalAngle);
			}
			if (this.ojoRWeight > 0f)
			{
				OjosLookAtIK.solve(this.m_ojor, this.head, this.m_initialLocalOjoRForward, this.m_initialLocalOjoRUp, this.m_initialLocalOjoRRight, this.IKPosition, this.IKPositionWeight * this.ojoRWeight, this.OjoRConfig.maxAngle, this.OjoRConfig.maxHorizontalAngle, this.OjoRConfig.maxVerticalAngle);
			}
			Math3dTvalle.GetDirectionAngle(out this.verticalAngleL, out this.horizontalAngleL, Quaternion.LookRotation(this.head.TransformDirection(this.m_initialLocalOjoLForward), this.head.TransformDirection(this.m_initialLocalOjoLUp)), this.m_ojol.forward, true);
			Math3dTvalle.GetDirectionAngle(out this.verticalAngleR, out this.horizontalAngleR, Quaternion.LookRotation(this.head.TransformDirection(this.m_initialLocalOjoRForward), this.head.TransformDirection(this.m_initialLocalOjoRUp)), this.m_ojor.forward, true);
			if (this.solved != null)
			{
				this.solved(this);
			}
		}

		// Token: 0x06000540 RID: 1344 RVA: 0x0001A950 File Offset: 0x00018B50
		private static void solve(Transform eye, Transform head, Vector3 initialLocalOjoForward, Vector3 initialLocalOjoUp, Vector3 initialLocalOjoRight, Vector3 IKPosition, float w, float maxAngle, float maxAngleH, float maxAngleV)
		{
			Vector3 vector = head.TransformDirection(initialLocalOjoForward);
			Vector3 normalized = (IKPosition - eye.transform.position).normalized;
			Vector3 normalized2 = Vector3.Lerp(vector, normalized, w).normalized;
			OjosLookAtIK.GetClamp(ref normalized2, eye, head, initialLocalOjoForward, initialLocalOjoUp, initialLocalOjoRight, maxAngle, maxAngleH, maxAngleV);
			OjosLookAtIK.LookAt(eye, vector, normalized2, w);
		}

		// Token: 0x06000541 RID: 1345 RVA: 0x0001A9B0 File Offset: 0x00018BB0
		private static void GetClamp(ref Vector3 targetForward, Transform eye, Transform head, Vector3 initialLocalOjoForward, Vector3 initialLocalOjoUp, Vector3 initialLocalOjoRight, float maxAngle, float maxAngleH, float maxAngleV)
		{
			Vector3 vector = head.TransformDirection(initialLocalOjoUp);
			Vector3 vector2 = head.TransformDirection(initialLocalOjoForward);
			Vector3 vector3 = head.TransformDirection(initialLocalOjoRight);
			targetForward = Math3dTvalle.LimitDirectionAngleV2(vector2, targetForward, maxAngle, null);
			Vector3 vector4 = Math3dTvalle.LimitDirectionAngleOnPlaneV2(vector2, targetForward, vector3, maxAngleV, null);
			Vector3 vector5 = Math3dTvalle.LimitDirectionAngleOnPlaneV2(vector2, targetForward, vector, maxAngleH, null);
			Matrix4x4 identity = Matrix4x4.identity;
			identity.SetTRS(eye.position, Quaternion.LookRotation(vector2, vector), Vector3.one);
			Matrix4x4 inverse = identity.inverse;
			Vector3 vector6 = inverse.MultiplyVector(vector4);
			Vector3 vector7 = inverse.MultiplyVector(vector5);
			Vector3 vector8 = new Vector3(vector7.x, vector6.y, Mathf.Max(vector7.z, vector6.z));
			targetForward = identity.MultiplyVector(vector8);
		}

		// Token: 0x06000542 RID: 1346 RVA: 0x0001AAA0 File Offset: 0x00018CA0
		private static void solve(Transform eye, Vector3 initialLocalOjoForward, Vector3 initialLocalOjoUp, Vector3 initialLocalOjoRight, Vector3 IKPosition, float w, float maxAngle, float maxAngleH, float maxAngleV)
		{
			Vector3 vector = eye.TransformDirection(initialLocalOjoForward);
			Vector3 normalized = (IKPosition - eye.transform.position).normalized;
			Vector3 normalized2 = Vector3.Lerp(vector, normalized, w).normalized;
			OjosLookAtIK.GetClamp(ref normalized2, eye, initialLocalOjoForward, initialLocalOjoUp, initialLocalOjoRight, maxAngle, maxAngleH, maxAngleV);
			OjosLookAtIK.LookAt(eye, vector, normalized2, w);
		}

		// Token: 0x06000543 RID: 1347 RVA: 0x0001AB00 File Offset: 0x00018D00
		private static void GetClamp(ref Vector3 targetForward, Transform eye, Vector3 initialLocalOjoForward, Vector3 initialLocalOjoUp, Vector3 initialLocalOjoRight, float maxAngle, float maxAngleH, float maxAngleV)
		{
			Vector3 vector = eye.TransformDirection(initialLocalOjoUp);
			Vector3 vector2 = eye.TransformDirection(initialLocalOjoForward);
			Vector3 vector3 = eye.TransformDirection(initialLocalOjoRight);
			targetForward = Math3dTvalle.LimitDirectionAngleV2(vector2, targetForward, maxAngle, null);
			Vector3 vector4 = Math3dTvalle.LimitDirectionAngleOnPlaneV2(vector2, targetForward, vector3, maxAngleV, null);
			Vector3 vector5 = Math3dTvalle.LimitDirectionAngleOnPlaneV2(vector2, targetForward, vector, maxAngleH, null);
			targetForward = (vector4 + vector5).normalized;
		}

		// Token: 0x06000544 RID: 1348 RVA: 0x0001AB90 File Offset: 0x00018D90
		private static void LookAt(Transform t, Vector3 forward, Vector3 direction, float weight)
		{
			Quaternion quaternion = Quaternion.FromToRotation(forward, direction);
			Quaternion rotation = t.rotation;
			t.rotation = Quaternion.Lerp(rotation, quaternion * rotation, weight);
		}

		// Token: 0x06000545 RID: 1349 RVA: 0x0001ABC0 File Offset: 0x00018DC0
		private void OnDrawGizmosSelected()
		{
			Color yellow = Color.yellow;
			yellow.a = this.IKPositionWeight;
			if (this.m_ojol)
			{
				DebugExtension.DrawArrow(this.m_ojol.position, this.IKPosition - this.m_ojol.position, yellow);
			}
			if (this.m_ojor)
			{
				DebugExtension.DrawArrow(this.m_ojor.position, this.IKPosition - this.m_ojor.position, yellow);
			}
		}

		// Token: 0x0400038B RID: 907
		[Range(0f, 1f)]
		public float IKPositionWeight;

		// Token: 0x0400038C RID: 908
		public Vector3 IKPosition;

		// Token: 0x0400038D RID: 909
		[Range(0f, 1f)]
		public float ojoLWeight = 0.8f;

		// Token: 0x0400038E RID: 910
		[Range(0f, 1f)]
		public float ojoRWeight = 0.8f;

		// Token: 0x0400038F RID: 911
		public OjosLookAtIK.OjoConfig OjoLConfig = new OjosLookAtIK.OjoConfig();

		// Token: 0x04000390 RID: 912
		public OjosLookAtIK.OjoConfig OjoRConfig = new OjosLookAtIK.OjoConfig();

		// Token: 0x04000391 RID: 913
		public float verticalAngleR;

		// Token: 0x04000392 RID: 914
		public float horizontalAngleR;

		// Token: 0x04000393 RID: 915
		public float verticalAngleL;

		// Token: 0x04000394 RID: 916
		public float horizontalAngleL;

		// Token: 0x04000395 RID: 917
		private Animator m_Animator;

		// Token: 0x04000396 RID: 918
		private Transform head;

		// Token: 0x04000397 RID: 919
		private Transform m_ojol;

		// Token: 0x04000398 RID: 920
		private Transform m_ojor;

		// Token: 0x0400039A RID: 922
		private Vector3 m_initialAnimatorOjoLForward;

		// Token: 0x0400039B RID: 923
		private Vector3 m_initialAnimatorOjoRForward;

		// Token: 0x0400039C RID: 924
		private Vector3 m_initialLocalOjoLForward;

		// Token: 0x0400039D RID: 925
		private Vector3 m_initialLocalOjoRForward;

		// Token: 0x0400039E RID: 926
		private Vector3 m_initialLocalOjoLUp;

		// Token: 0x0400039F RID: 927
		private Vector3 m_initialLocalOjoRUp;

		// Token: 0x040003A0 RID: 928
		private Vector3 m_initialLocalOjoLRight;

		// Token: 0x040003A1 RID: 929
		private Vector3 m_initialLocalOjoRRight;

		// Token: 0x0200017B RID: 379
		[Serializable]
		public class OjoConfig
		{
			// Token: 0x04000899 RID: 2201
			[Range(0f, 180f)]
			public float maxAngle = 45f;

			// Token: 0x0400089A RID: 2202
			[Range(0f, 180f)]
			public float maxHorizontalAngle = 26f;

			// Token: 0x0400089B RID: 2203
			[Range(0f, 180f)]
			public float maxVerticalAngle = 18f;
		}
	}
}
