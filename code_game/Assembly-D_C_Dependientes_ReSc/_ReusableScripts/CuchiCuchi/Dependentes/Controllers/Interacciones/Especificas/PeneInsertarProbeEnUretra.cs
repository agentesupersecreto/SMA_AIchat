using System;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.Interacciones;
using Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts.Penises;
using Assets._ReusableScripts.Globales.Updater;
using Assets._ReusableScripts.Miscellaneous;
using Assets._ReusableScripts.Miscellaneous.Transforms;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.Especificas
{
	// Token: 0x020001C3 RID: 451
	public sealed class PeneInsertarProbeEnUretra : DatosDeInteraccionDynamicaGenerica
	{
		// Token: 0x17000268 RID: 616
		// (get) Token: 0x06000AD3 RID: 2771 RVA: 0x00035D74 File Offset: 0x00033F74
		public Transform currentPenisTip
		{
			get
			{
				if (this.follower == null)
				{
					return null;
				}
				return this.follower.target;
			}
		}

		// Token: 0x06000AD4 RID: 2772 RVA: 0x00035D94 File Offset: 0x00033F94
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (this.m_Pivot == null)
			{
				throw new ArgumentNullException("m_Pivot", "m_Pivot null reference.");
			}
			if (this.m_peneTipPrefab == null)
			{
				throw new ArgumentNullException("m_peneTipPrefab", "m_peneTipPrefab null reference.");
			}
			if (this.m_interObj == null)
			{
				throw new ArgumentNullException("m_interObj", "m_interObj null reference.");
			}
			if (this.m_Pivot.parent != this.m_interObj.transform)
			{
				throw new InvalidOperationException();
			}
			this.m_interObj.transform.position = this.m_Pivot.position;
			this.m_interObj.transform.rotation = this.m_Pivot.rotation;
			this.m_Pivot.localPosition = Vector3.zero;
			this.m_Pivot.localRotation = Quaternion.identity;
			this.m_localPostionFromPene = this.m_peneTipPrefab.InverseTransformPoint(this.m_interObj.transform.position);
			this.m_localRotationFromPene = Quaternion.Inverse(this.m_peneTipPrefab.rotation) * this.m_interObj.transform.rotation;
			this.m_EnableScripts = this.m_interObj.GetComponentNotNull<InteractionObjectV2EnableScripts>();
		}

		// Token: 0x06000AD5 RID: 2773 RVA: 0x00035ED8 File Offset: 0x000340D8
		protected override void OnAdded(Interaccion arg1, IInteraccionesDeCharacter arg2)
		{
			if (this.follower)
			{
				Object.Destroy(this.follower);
			}
			if (this.m_copyScale)
			{
				Object.Destroy(this.m_copyScale);
			}
			if (MainChar.current == null)
			{
				throw new ArgumentNullException("MainChar.current", "MainChar.current null reference.");
			}
			MaleChar maleChar = MainChar.current as MaleChar;
			if (maleChar == null)
			{
				throw new ArgumentNullException("maleCharacter", "maleCharacter null reference.");
			}
			PenisPoint penisPoint = maleChar.pene.penisLinearChain.FindByNamePoint(this.m_peneTipPrefab.name);
			if (penisPoint == null)
			{
				throw new ArgumentNullException("puntoDePene", "puntoDePene null reference.");
			}
			PenisPart penisPart = maleChar.pene.ObtenerParte(penisPoint);
			if (penisPart == null)
			{
				throw new ArgumentNullException("ultimaParteDePene", "ultimaParteDePene null reference.");
			}
			Transform charBone = penisPart.charBone;
			if (charBone == null)
			{
				throw new ArgumentNullException("peneUltimaParteBone", "peneUltimaParteBone null reference.");
			}
			Transform tipBone = maleChar.pene.penisLinearChain.tipBone;
			if (tipBone == null)
			{
				throw new ArgumentNullException("tipBone", "tipBone null reference.");
			}
			Matrix4x4 identity = Matrix4x4.identity;
			identity.SetTRS(charBone.position, charBone.rotation, charBone.parent.lossyScale);
			this.m_interObj.transform.position = identity.MultiplyPoint3x4(this.m_localPostionFromPene);
			this.m_interObj.transform.rotation = charBone.rotation * this.m_localRotationFromPene;
			this.follower = this.m_interObj.GetComponentNotNull<MatrixFollower>();
			this.follower.scaleMod = MatrixFollower.ScaleMod.ignoreLocal;
			this.follower.initType = MatrixFollowerBase.InitType.custom;
			this.follower.updateEvent = GlobalUpdater.UpdateType.afterAnimationConstraints;
			this.follower.target = charBone;
			this.follower.followScale = false;
			this.follower.followOnEnable = true;
			this.follower.Init();
			this.m_EnableScripts.Add(this.follower);
			this.m_copyScale = this.m_Pivot.GetComponentNotNull<CopyCharacterTransfromAtribute>();
			this.m_copyScale.copyOnEnable = true;
			this.m_copyScale.copyScale = true;
			this.m_copyScale.Init(HumanBodyBones.LeftHand);
			this.m_EnableScripts.Add(this.m_copyScale);
			this.m_lookAt = this.m_interObj.GetComponent<ApuntarProbAUretra>();
			if (this.m_lookAt)
			{
				this.m_lookAt.uretra = tipBone;
			}
			base.OnAdded(arg1, arg2);
		}

		// Token: 0x06000AD6 RID: 2774 RVA: 0x00036148 File Offset: 0x00034348
		protected override void OnRemoved(Interaccion arg1, IInteraccionesDeCharacter arg2)
		{
			this.m_lookAt.uretra = null;
			if (this.follower)
			{
				this.m_EnableScripts.Remove(this.follower);
				Object.Destroy(this.follower);
			}
			if (this.m_copyScale)
			{
				this.m_EnableScripts.Remove(this.m_copyScale);
				Object.Destroy(this.m_copyScale);
			}
			base.OnRemoved(arg1, arg2);
		}

		// Token: 0x04000839 RID: 2105
		[SerializeField]
		private Transform m_peneTipPrefab;

		// Token: 0x0400083A RID: 2106
		[SerializeField]
		private Transform m_Pivot;

		// Token: 0x0400083B RID: 2107
		[SerializeField]
		private InteractionObjectV2Base m_interObj;

		// Token: 0x0400083C RID: 2108
		public MatrixFollower follower;

		// Token: 0x0400083D RID: 2109
		private CopyCharacterTransfromAtribute m_copyScale;

		// Token: 0x0400083E RID: 2110
		private ApuntarProbAUretra m_lookAt;

		// Token: 0x0400083F RID: 2111
		private InteractionObjectV2EnableScripts m_EnableScripts;

		// Token: 0x04000840 RID: 2112
		private Vector3 m_localPostionFromPene;

		// Token: 0x04000841 RID: 2113
		private Quaternion m_localRotationFromPene;
	}
}
