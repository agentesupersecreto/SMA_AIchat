using System;
using System.Collections.Generic;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets.Base.RootMotion.BeachGirl.Runtime.FinalIk
{
	// Token: 0x0200001F RID: 31
	[RequireComponent(typeof(FullBodyBipedIK))]
	public class TValleEffectorForcer : CustomMonobehaviour
	{
		// Token: 0x14000011 RID: 17
		// (add) Token: 0x06000100 RID: 256 RVA: 0x00006D7C File Offset: 0x00004F7C
		// (remove) Token: 0x06000101 RID: 257 RVA: 0x00006DB4 File Offset: 0x00004FB4
		public event TValleEffectorForcer.UpdateHandler updating;

		// Token: 0x14000012 RID: 18
		// (add) Token: 0x06000102 RID: 258 RVA: 0x00006DEC File Offset: 0x00004FEC
		// (remove) Token: 0x06000103 RID: 259 RVA: 0x00006E24 File Offset: 0x00005024
		public event TValleEffectorForcer.UpdateHandler updated;

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x06000104 RID: 260 RVA: 0x00006E59 File Offset: 0x00005059
		public FullBodyBipedIK fullBodyBipedIK
		{
			get
			{
				return this.m_FullBodyBipedIK;
			}
		}

		// Token: 0x06000105 RID: 261 RVA: 0x00006E61 File Offset: 0x00005061
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_Updater = this.GetComponentEnRoot(false);
			if (this.m_Updater == null)
			{
				throw new ArgumentNullException("m_Updater", "m_Updater null reference.");
			}
			this.m_FullBodyBipedIK = base.GetComponent<FullBodyBipedIK>();
		}

		// Token: 0x06000106 RID: 262 RVA: 0x00006E9A File Offset: 0x0000509A
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.Subscribe();
		}

		// Token: 0x06000107 RID: 263 RVA: 0x00006EA8 File Offset: 0x000050A8
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			this.Unsubscribe();
		}

		// Token: 0x06000108 RID: 264 RVA: 0x00006EB7 File Offset: 0x000050B7
		protected void Subscribe()
		{
			if (this.m_Updater == null)
			{
				return;
			}
			this.m_Updater.onSingleIKUpdatingPass2 += this.OnSingleIKUpdatingPass2;
			this.m_Updater.onSingleIKUpdatedPass2 += this.OnSingleIKUpdatedPass2;
		}

		// Token: 0x06000109 RID: 265 RVA: 0x00006EF0 File Offset: 0x000050F0
		protected void Unsubscribe()
		{
			if (this.m_Updater == null)
			{
				return;
			}
			this.m_Updater.onSingleIKUpdatingPass2 -= this.OnSingleIKUpdatingPass2;
			this.m_Updater.onSingleIKUpdatedPass2 -= this.OnSingleIKUpdatedPass2;
		}

		// Token: 0x0600010A RID: 266 RVA: 0x00006F2C File Offset: 0x0000512C
		private void OnSingleIKUpdatingPass2(IIKUpdater updater, Component IK, ref IKEventData IKEventData, ref IKPassEventData PassEventData)
		{
			if (!base.isActiveAndEnabled || this.m_FullBodyBipedIK != IK)
			{
				return;
			}
			TValleEffectorForcer.UpdateHandler updateHandler = this.updating;
			if (updateHandler != null)
			{
				updateHandler(this.m_FullBodyBipedIK, IKEventData, PassEventData, this);
			}
			this.ModifyOffset();
			TValleEffectorForcer.UpdateHandler updateHandler2 = this.updated;
			if (updateHandler2 == null)
			{
				return;
			}
			updateHandler2(this.m_FullBodyBipedIK, IKEventData, PassEventData, this);
		}

		// Token: 0x0600010B RID: 267 RVA: 0x00006F9F File Offset: 0x0000519F
		private void OnSingleIKUpdatedPass2(IIKUpdater updater, Component IK, ref IKEventData IKEventData, ref IKPassEventData PassEventData)
		{
			if (this.m_FullBodyBipedIK != IK)
			{
				return;
			}
			this.IKUpdated();
		}

		// Token: 0x0600010C RID: 268 RVA: 0x00006FB8 File Offset: 0x000051B8
		private void ModifyOffset()
		{
			this.FixOffset(this.m_FullBodyBipedIK.solver.bodyEffector, FullBodyBipedEffector.Body, this.bodyOffset, this.bodyOffsetWeight);
			this.FixOffset(this.m_FullBodyBipedIK.solver.leftShoulderEffector, FullBodyBipedEffector.LeftShoulder, this.leftShoulderOffset, this.leftShoulderOffsetWeight);
			this.FixOffset(this.m_FullBodyBipedIK.solver.rightShoulderEffector, FullBodyBipedEffector.RightShoulder, this.rightShoulderOffset, this.rightShoulderOffsetWeight);
			this.FixOffset(this.m_FullBodyBipedIK.solver.leftThighEffector, FullBodyBipedEffector.LeftThigh, this.leftThighOffset, this.leftThighOffsetWeight);
			this.FixOffset(this.m_FullBodyBipedIK.solver.rightThighEffector, FullBodyBipedEffector.RightThigh, this.rightThighOffset, this.rightThighOffsetWeight);
			this.FixOffset(this.m_FullBodyBipedIK.solver.leftHandEffector, FullBodyBipedEffector.LeftHand, this.leftHandOffset, this.leftHandOffsetWeight);
			this.FixOffset(this.m_FullBodyBipedIK.solver.rightHandEffector, FullBodyBipedEffector.RightHand, this.rightHandOffset, this.rightHandOffsetWeight);
			this.FixOffset(this.m_FullBodyBipedIK.solver.leftFootEffector, FullBodyBipedEffector.LeftFoot, this.leftFootOffset, this.leftFootOffsetWeight);
			this.FixOffset(this.m_FullBodyBipedIK.solver.rightFootEffector, FullBodyBipedEffector.RightFoot, this.rightFootOffset, this.rightFootOffsetWeight);
		}

		// Token: 0x0600010D RID: 269 RVA: 0x00007100 File Offset: 0x00005300
		private void FixOffset(IKEffector effector, FullBodyBipedEffector fullBodyBipedEffector, Vector3 positionOffset, float weigth)
		{
			if (positionOffset == Vector3.zero && weigth <= 0f)
			{
				return;
			}
			weigth = Mathf.Clamp01(weigth);
			Vector3 position = effector.position;
			positionOffset *= weigth;
			ValueTuple<IKEffector, Vector3> valueTuple = new ValueTuple<IKEffector, Vector3>(effector, positionOffset);
			this.effectorsPositionChanges.Enqueue(valueTuple);
			effector.position += positionOffset;
			ValueTuple<IKEffector, float> valueTuple2 = new ValueTuple<IKEffector, float>(effector, effector.positionWeight);
			this.effectorsPositionWeightBackUp.Enqueue(valueTuple2);
			effector.positionWeight = Mathf.Lerp(effector.positionWeight, 1f, weigth);
			bool flag = this.debugDraw;
		}

		// Token: 0x0600010E RID: 270 RVA: 0x000071A0 File Offset: 0x000053A0
		private void IKUpdated()
		{
			while (this.effectorsPositionChanges.Count > 0)
			{
				ValueTuple<IKEffector, Vector3> valueTuple = this.effectorsPositionChanges.Dequeue();
				valueTuple.Item1.position -= valueTuple.Item2;
			}
			while (this.effectorsPositionWeightBackUp.Count > 0)
			{
				ValueTuple<IKEffector, float> valueTuple2 = this.effectorsPositionWeightBackUp.Dequeue();
				valueTuple2.Item1.positionWeight = valueTuple2.Item2;
			}
			this.bodyOffset = Vector3.zero;
			this.leftShoulderOffset = Vector3.zero;
			this.rightShoulderOffset = Vector3.zero;
			this.leftThighOffset = Vector3.zero;
			this.rightThighOffset = Vector3.zero;
			this.leftHandOffset = Vector3.zero;
			this.rightHandOffset = Vector3.zero;
			this.leftFootOffset = Vector3.zero;
			this.rightFootOffset = Vector3.zero;
			this.bodyOffsetWeight = 0f;
			this.leftShoulderOffsetWeight = 0f;
			this.rightShoulderOffsetWeight = 0f;
			this.leftThighOffsetWeight = 0f;
			this.rightThighOffsetWeight = 0f;
			this.leftHandOffsetWeight = 0f;
			this.rightHandOffsetWeight = 0f;
			this.leftFootOffsetWeight = 0f;
			this.rightFootOffsetWeight = 0f;
		}

		// Token: 0x040000AB RID: 171
		public bool debugDraw;

		// Token: 0x040000AC RID: 172
		private IIKUpdater m_Updater;

		// Token: 0x040000AF RID: 175
		public Vector3 bodyOffset;

		// Token: 0x040000B0 RID: 176
		public Vector3 leftShoulderOffset;

		// Token: 0x040000B1 RID: 177
		public Vector3 rightShoulderOffset;

		// Token: 0x040000B2 RID: 178
		public Vector3 leftThighOffset;

		// Token: 0x040000B3 RID: 179
		public Vector3 rightThighOffset;

		// Token: 0x040000B4 RID: 180
		public Vector3 leftHandOffset;

		// Token: 0x040000B5 RID: 181
		public Vector3 rightHandOffset;

		// Token: 0x040000B6 RID: 182
		public Vector3 leftFootOffset;

		// Token: 0x040000B7 RID: 183
		public Vector3 rightFootOffset;

		// Token: 0x040000B8 RID: 184
		public float bodyOffsetWeight;

		// Token: 0x040000B9 RID: 185
		public float leftShoulderOffsetWeight;

		// Token: 0x040000BA RID: 186
		public float rightShoulderOffsetWeight;

		// Token: 0x040000BB RID: 187
		public float leftThighOffsetWeight;

		// Token: 0x040000BC RID: 188
		public float rightThighOffsetWeight;

		// Token: 0x040000BD RID: 189
		public float leftHandOffsetWeight;

		// Token: 0x040000BE RID: 190
		public float rightHandOffsetWeight;

		// Token: 0x040000BF RID: 191
		public float leftFootOffsetWeight;

		// Token: 0x040000C0 RID: 192
		public float rightFootOffsetWeight;

		// Token: 0x040000C1 RID: 193
		private FullBodyBipedIK m_FullBodyBipedIK;

		// Token: 0x040000C2 RID: 194
		private Queue<ValueTuple<IKEffector, Vector3>> effectorsPositionChanges = new Queue<ValueTuple<IKEffector, Vector3>>();

		// Token: 0x040000C3 RID: 195
		private Queue<ValueTuple<IKEffector, float>> effectorsPositionWeightBackUp = new Queue<ValueTuple<IKEffector, float>>();

		// Token: 0x02000117 RID: 279
		// (Invoke) Token: 0x06000AA0 RID: 2720
		public delegate void UpdateHandler(FullBodyBipedIK fullBodyBipedIK, IKEventData IKEventData, IKPassEventData PassEventData, TValleEffectorForcer sender);

		// Token: 0x02000118 RID: 280
		[Serializable]
		public class WeigthDePasada
		{
			// Token: 0x0400069D RID: 1693
			public FullBodyBipedEffector fullBodyBipedEffector;

			// Token: 0x0400069E RID: 1694
			public int pass;

			// Token: 0x0400069F RID: 1695
			public float weigth;
		}
	}
}
