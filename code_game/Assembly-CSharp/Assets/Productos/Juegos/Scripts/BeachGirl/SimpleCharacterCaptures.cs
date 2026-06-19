using System;
using Assets.Productos.Juegos.Reception.Scripts.Dependientes.Controlladores;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.BeachGirl.Characters.Male.Runtime.Controllers;
using Assets._ReusableScripts;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets.Productos.Juegos.Scripts.BeachGirl
{
	// Token: 0x02000085 RID: 133
	public sealed class SimpleCharacterCaptures : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x1700006F RID: 111
		// (get) Token: 0x06000273 RID: 627 RVA: 0x0000EC2F File Offset: 0x0000CE2F
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.update2);
			}
		}

		// Token: 0x06000274 RID: 628 RVA: 0x0000EC38 File Offset: 0x0000CE38
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_playerPhone = Object.Instantiate<GameObject>(this.m_playerPhonePrefab, base.transform.TransformPoint(this.m_phonePositionOffset), base.transform.rotation * this.m_phoneRotationOffset, base.transform);
			this.m_playerCamera = Object.Instantiate<GameObject>(this.m_playerCameraPrefab, base.transform.TransformPoint(this.m_cameraPositionOffset), base.transform.rotation * this.m_cameraRotationOffset, base.transform);
			this.m_MalePhoneUserController = this.m_playerPhone.GetComponentInChildren<MalePhoneUserController>();
			this.m_MaleCameraUserController = this.m_playerCamera.GetComponentInChildren<MaleCameraUserController>();
			if (this.m_MalePhoneUserController == null)
			{
				throw new ArgumentNullException("m_MalePhoneUserController", "m_MalePhoneUserController null reference.");
			}
			if (this.m_MaleCameraUserController == null)
			{
				throw new ArgumentNullException("m_MaleCameraUserController", "m_MaleCameraUserController null reference.");
			}
			this.m_playerPhone.SetActive(false);
			this.m_playerCamera.SetActive(false);
		}

		// Token: 0x06000275 RID: 629 RVA: 0x0000ED40 File Offset: 0x0000CF40
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			if (this.m_playerPhone)
			{
				Object.Destroy(this.m_playerPhone.gameObject);
			}
			if (this.m_playerCamera)
			{
				Object.Destroy(this.m_playerCamera.gameObject);
			}
		}

		// Token: 0x06000276 RID: 630 RVA: 0x0000ED90 File Offset: 0x0000CF90
		public override void OnUpdateEvent1()
		{
			this.m_MalePhoneUserController.femalePortraitEnabled = this.femalePortraitEnabled;
			this.m_MalePhoneUserController.posePortraitEnabled = this.posePortraitEnabled;
			this.m_MalePhoneUserController.ropaPortraitEnabled = this.ropaPortraitEnabled;
			this.m_MaleCameraUserController.modelingShootEnabled = this.modelingShootEnabled;
			bool tooled = Singleton<PlayerInputProxy>.instance.toolActions.tooled3;
			bool tooled2 = Singleton<PlayerInputProxy>.instance.toolActions.tooled4;
			bool flag = tooled && !this.m_playerPhone.activeSelf && !this.m_playerCamera.activeSelf;
			bool flag2 = tooled2 && !this.m_playerPhone.activeSelf && !this.m_playerCamera.activeSelf;
			bool flag3 = tooled && this.m_playerPhone.activeSelf;
			bool flag4 = tooled2 && this.m_playerCamera.activeSelf;
			if (flag)
			{
				this.m_playerPhone.SetActive(true);
				return;
			}
			if (flag2)
			{
				this.m_playerCamera.SetActive(true);
				return;
			}
			if (flag3)
			{
				this.m_playerPhone.SetActive(false);
				return;
			}
			if (flag4)
			{
				this.m_playerCamera.SetActive(false);
			}
		}

		// Token: 0x040000FE RID: 254
		public bool femalePortraitEnabled = true;

		// Token: 0x040000FF RID: 255
		public bool posePortraitEnabled = true;

		// Token: 0x04000100 RID: 256
		public bool modelingShootEnabled = true;

		// Token: 0x04000101 RID: 257
		public bool ropaPortraitEnabled = true;

		// Token: 0x04000102 RID: 258
		[SerializeField]
		private GameObject m_playerPhonePrefab;

		// Token: 0x04000103 RID: 259
		[SerializeField]
		private GameObject m_playerCameraPrefab;

		// Token: 0x04000104 RID: 260
		[ReadOnlyUI]
		[SerializeField]
		private GameObject m_playerPhone;

		// Token: 0x04000105 RID: 261
		[ReadOnlyUI]
		[SerializeField]
		private GameObject m_playerCamera;

		// Token: 0x04000106 RID: 262
		[ReadOnlyUI]
		[SerializeField]
		private MalePhoneUserController m_MalePhoneUserController;

		// Token: 0x04000107 RID: 263
		[ReadOnlyUI]
		[SerializeField]
		private MaleCameraUserController m_MaleCameraUserController;

		// Token: 0x04000108 RID: 264
		[SerializeField]
		private Vector3 m_phonePositionOffset = new Vector3(-0.04f, 0f, 0.0884f);

		// Token: 0x04000109 RID: 265
		[SerializeField]
		private Quaternion m_phoneRotationOffset = Quaternion.Euler(-86.765f, 7.046f, 0f);

		// Token: 0x0400010A RID: 266
		[SerializeField]
		private Vector3 m_cameraPositionOffset = new Vector3(0f, -0.0168f, 0.109f);

		// Token: 0x0400010B RID: 267
		[SerializeField]
		private Quaternion m_cameraRotationOffset = Quaternion.Euler(9.62f, 0f, 0f);
	}
}
