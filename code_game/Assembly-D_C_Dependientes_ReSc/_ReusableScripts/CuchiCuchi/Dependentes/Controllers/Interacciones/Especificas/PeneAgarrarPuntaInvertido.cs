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
	// Token: 0x020001C1 RID: 449
	public sealed class PeneAgarrarPuntaInvertido : DatosDeInteraccionDynamicaGenerica
	{
		// Token: 0x06000AC9 RID: 2761 RVA: 0x00035898 File Offset: 0x00033A98
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (this.m_Pivot == null)
			{
				throw new ArgumentNullException("m_Pivot", "m_Pivot null reference.");
			}
			if (this.m_peneUltimaParteBonePrefab == null)
			{
				throw new ArgumentNullException("m_peneUltimaPartePrefab", "m_peneUltimaPartePrefab null reference.");
			}
			if (this.m_interObj == null)
			{
				throw new ArgumentNullException("m_interObj", "m_interObj null reference.");
			}
			if (this.m_Pivot.parent != this.m_interObj.transform)
			{
				throw new InvalidOperationException();
			}
			this.m_EnableScripts = this.m_interObj.GetComponentNotNull<InteractionObjectV2EnableScripts>();
			this.m_interObj.transform.position = this.m_Pivot.position;
			this.m_interObj.transform.rotation = this.m_Pivot.rotation;
			this.m_Pivot.localPosition = Vector3.zero;
			this.m_Pivot.localRotation = Quaternion.identity;
			this.m_localPostionFromPene = this.m_peneUltimaParteBonePrefab.InverseTransformPoint(this.m_interObj.transform.position);
			this.m_localRotationFromPene = Quaternion.Inverse(this.m_peneUltimaParteBonePrefab.rotation) * this.m_interObj.transform.rotation;
		}

		// Token: 0x06000ACA RID: 2762 RVA: 0x000359DC File Offset: 0x00033BDC
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
			PenisPoint penisPoint = maleChar.pene.penisLinearChain.FindByNamePoint(this.m_peneUltimaParteBonePrefab.name);
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
			Matrix4x4 identity = Matrix4x4.identity;
			identity.SetTRS(charBone.position, charBone.rotation, charBone.parent.lossyScale);
			this.m_interObj.transform.position = identity.MultiplyPoint3x4(this.m_localPostionFromPene);
			this.m_interObj.transform.rotation = charBone.rotation * this.m_localRotationFromPene;
			this.follower = this.m_interObj.GetComponentNotNull<MatrixFollower>();
			this.follower.scaleMod = MatrixFollower.ScaleMod.ignoreLocal;
			this.follower.initType = MatrixFollowerBase.InitType.custom;
			this.follower.target = charBone;
			this.follower.updateEvent = GlobalUpdater.UpdateType.afterAnimationConstraints;
			this.follower.followOnEnable = true;
			this.follower.positionConfig = this.positionFollowerConfig;
			this.follower.rotationConfig = this.rotationFollowerConfig;
			this.follower.Init();
			this.m_EnableScripts.Add(this.follower);
			this.m_copyScale = this.m_Pivot.GetComponentNotNull<CopyCharacterTransfromAtribute>();
			this.m_copyScale.copyOnEnable = true;
			this.m_copyScale.copyScale = true;
			this.m_copyScale.Init(HumanBodyBones.RightHand);
			this.m_EnableScripts.Add(this.m_copyScale);
			base.OnAdded(arg1, arg2);
		}

		// Token: 0x06000ACB RID: 2763 RVA: 0x00035C10 File Offset: 0x00033E10
		protected override void OnRemoved(Interaccion arg1, IInteraccionesDeCharacter arg2)
		{
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

		// Token: 0x0400082D RID: 2093
		[Header("la parte del pene a seguir")]
		[SerializeField]
		private Transform m_peneUltimaParteBonePrefab;

		// Token: 0x0400082E RID: 2094
		[SerializeField]
		private Transform m_Pivot;

		// Token: 0x0400082F RID: 2095
		[SerializeField]
		private InteractionObjectV2Base m_interObj;

		// Token: 0x04000830 RID: 2096
		public MatrixFollower follower;

		// Token: 0x04000831 RID: 2097
		private CopyCharacterTransfromAtribute m_copyScale;

		// Token: 0x04000832 RID: 2098
		private InteractionObjectV2EnableScripts m_EnableScripts;

		// Token: 0x04000833 RID: 2099
		private Vector3 m_localPostionFromPene;

		// Token: 0x04000834 RID: 2100
		private Quaternion m_localRotationFromPene;

		// Token: 0x04000835 RID: 2101
		public MatrixFollowerBase.AtributeConfig positionFollowerConfig = new MatrixFollowerBase.AtributeConfig();

		// Token: 0x04000836 RID: 2102
		public MatrixFollowerBase.AtributeConfig rotationFollowerConfig = new MatrixFollowerBase.AtributeConfig();
	}
}
