using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.Globales.Clases;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.UserControllers
{
	// Token: 0x020001B0 RID: 432
	[RequireComponent(typeof(PelvisMovementController))]
	public sealed class PelvisMovementMouseUserController : UserController
	{
		// Token: 0x17000252 RID: 594
		// (get) Token: 0x06000A58 RID: 2648 RVA: 0x00033A4B File Offset: 0x00031C4B
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.update2);
			}
		}

		// Token: 0x17000253 RID: 595
		// (get) Token: 0x06000A59 RID: 2649 RVA: 0x00033A53 File Offset: 0x00031C53
		public bool activo
		{
			get
			{
				return this.m_activadoOR.Or(this.m_forzarActivado) && base.enabled;
			}
		}

		// Token: 0x17000254 RID: 596
		// (get) Token: 0x06000A5A RID: 2650 RVA: 0x00033A70 File Offset: 0x00031C70
		public ModificableDeBool activadoOR
		{
			get
			{
				return this.m_activadoOR;
			}
		}

		// Token: 0x14000013 RID: 19
		// (add) Token: 0x06000A5B RID: 2651 RVA: 0x00033A78 File Offset: 0x00031C78
		// (remove) Token: 0x06000A5C RID: 2652 RVA: 0x00033AB0 File Offset: 0x00031CB0
		public event PelvisMovementMouseUserController.UserWorldPositionCalculedHandler userWorldPositionCalculed;

		// Token: 0x06000A5D RID: 2653 RVA: 0x00033AE8 File Offset: 0x00031CE8
		protected override void AwakeUnityEvent()
		{
			this.m_IIKUpdater = this.GetComponentEnCharacter(false);
			if (this.m_IIKUpdater == null)
			{
				throw new ArgumentNullException("iKBeforePhysicsV2", "iKBeforePhysicsV2 null reference.");
			}
			this.m_MousePosition = new EmulatedMousePosition(0f, 1f, -1f, 1f);
			base.AwakeUnityEvent();
			this.m_controller = base.GetComponent<PelvisMovementController>();
		}

		// Token: 0x06000A5E RID: 2654 RVA: 0x00033B4B File Offset: 0x00031D4B
		protected sealed override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_IIKUpdater.onSingleIKUpdatedPass1 += this.M_IIKUpdater_passed;
		}

		// Token: 0x06000A5F RID: 2655 RVA: 0x00033B6A File Offset: 0x00031D6A
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_IIKUpdater != null)
			{
				this.m_IIKUpdater.onSingleIKUpdatedPass1 -= this.M_IIKUpdater_passed;
			}
			this.m_MousePosition.SetToInitial(PelvisMovementMouseUserController.screenCenter);
			this.m_firstFrameActive = true;
		}

		// Token: 0x06000A60 RID: 2656 RVA: 0x00033BAC File Offset: 0x00031DAC
		private void M_IIKUpdater_passed(IIKUpdater updater, Component IK, ref IKEventData IKEventData, ref IKPassEventData PassEventData)
		{
			if (IKEventData.layer != 0 || !IKEventData.esUltimoDeLayer)
			{
				return;
			}
			if (PassEventData.esUltimo)
			{
				Transform transform = this.m_controller.character.bones.pelvis.transform;
				Vector3 position = transform.position;
				Quaternion quaternion = transform.rotation * this.m_controller.character.bones.pelvis.offSetToForward;
				Vector3 lossyScale = transform.lossyScale;
				this.m_AfterIKLayerZeroPelvisMatrix = Matrix4x4.TRS(position, quaternion, transform.lossyScale);
				this.m_AfterIKLayerZeroPelvisMatrixNoScale = Matrix4x4.TRS(position, quaternion, Vector3.one);
			}
		}

		// Token: 0x06000A61 RID: 2657 RVA: 0x00033C48 File Offset: 0x00031E48
		public override void OnUpdateEvent1()
		{
			if (!this.activo)
			{
				this.m_firstFrameActive = true;
				this.m_MousePosition.SetToInitial(PelvisMovementMouseUserController.screenCenter);
				return;
			}
			if (!Singleton<PlayerInputProxy>.instance.fire1.heldDown)
			{
				return;
			}
			CurrentMainChar.ICamera camara = Singleton<CurrentMainChar>.instance.camara;
			Camera camera = ((camara != null) ? camara.camara : null);
			if (camera == null)
			{
				return;
			}
			InputProxyVirtuales toolMovement = Singleton<PlayerInputProxy>.instance.toolMovement;
			if (toolMovement.goingDown || toolMovement.wheelAxis != 0f)
			{
				return;
			}
			float num = Vector3.Distance(this.m_controller.character.bones.pelvis.posicionFinal, this.m_controller.character.bones.head.posicionFinal);
			if (this.m_firstFrameActive)
			{
				Vector3 vector = this.m_AfterIKLayerZeroPelvisMatrix.MultiplyPoint3x4(this.m_controller.currentLocalTarget);
				Vector3 vector2 = camera.WorldToViewportPoint(vector);
				float num2 = vector2.x - PelvisMovementMouseUserController.screenCenter.x;
				float num3 = vector2.y - PelvisMovementMouseUserController.screenCenter.y;
				this.m_MousePosition.Forzar(new Vector2(PelvisMovementMouseUserController.screenCenter.x + num2 * this.m_SetDefaultMousePositionMod, PelvisMovementMouseUserController.screenCenter.y + num3 * this.m_SetDefaultMousePositionMod));
				this.m_firstFrameActive = false;
			}
			this.m_MousePosition.Update(toolMovement, this.m_sensibilidadParaMouseHorizantal, this.m_sensibilidadParaMouseVertical, 1f);
			Vector2 viewportPosition = this.m_MousePosition.viewportPosition;
			Vector3 vector3 = camera.ViewportToWorldPoint(new Vector3(viewportPosition.x, viewportPosition.y, num));
			bool flag = this.debugDraw;
			PelvisMovementMouseUserController.UserWorldPositionCalculedHandler userWorldPositionCalculedHandler = this.userWorldPositionCalculed;
			if (userWorldPositionCalculedHandler != null)
			{
				userWorldPositionCalculedHandler(ref vector3, this);
			}
			Vector3 vector4 = this.m_AfterIKLayerZeroPelvisMatrixNoScale.inverse.MultiplyPoint3x4(vector3);
			Vector3 vector5;
			if (this.m_usarDificultad)
			{
				vector5 = this.m_controller.ModificarConDificultad(vector4);
			}
			else
			{
				vector5 = vector4;
			}
			Vector3 vector6 = this.m_AfterIKLayerZeroPelvisMatrixNoScale.MultiplyPoint3x4(vector5);
			bool flag2 = this.debugDraw;
			Vector3 vector7 = camera.WorldToViewportPoint(vector6);
			this.m_MousePosition.Forzar(new Vector2(vector7.x, vector7.y));
			Vector2 viewportPosition2 = this.m_MousePosition.viewportPosition;
			Vector3 vector8 = camera.ViewportToWorldPoint(new Vector3(viewportPosition2.x, viewportPosition2.y, num));
			bool flag3 = this.debugDraw;
			Vector3 vector9 = this.m_AfterIKLayerZeroPelvisMatrixNoScale.inverse.MultiplyPoint3x4(vector8);
			vector9.y = this.m_controller.currentLocalTarget.y;
			this.m_controller.ControlForze(vector9);
		}

		// Token: 0x040007CD RID: 1997
		private static readonly Vector2 screenCenter = new Vector2(0.5f, 0.5f);

		// Token: 0x040007CE RID: 1998
		[SerializeField]
		private bool m_forzarActivado;

		// Token: 0x040007CF RID: 1999
		[NonSerialized]
		private bool m_usarDificultad = true;

		// Token: 0x040007D0 RID: 2000
		[ReadOnlyUI]
		[SerializeField]
		private bool m_firstFrameActive = true;

		// Token: 0x040007D1 RID: 2001
		[SerializeField]
		private float m_sensibilidadParaMouseVertical = 0.01777778f;

		// Token: 0x040007D2 RID: 2002
		[SerializeField]
		private float m_sensibilidadParaMouseHorizantal = 0.01f;

		// Token: 0x040007D3 RID: 2003
		[SerializeField]
		private float m_SetDefaultMousePositionMod = 1f;

		// Token: 0x040007D4 RID: 2004
		private ModificableDeBool m_activadoOR = new ModificableDeBool(false);

		// Token: 0x040007D5 RID: 2005
		private PelvisMovementController m_controller;

		// Token: 0x040007D6 RID: 2006
		[SerializeReference]
		private EmulatedMousePosition m_MousePosition;

		// Token: 0x040007D7 RID: 2007
		public bool debugDraw;

		// Token: 0x040007D9 RID: 2009
		private IIKUpdater m_IIKUpdater;

		// Token: 0x040007DA RID: 2010
		private Matrix4x4 m_AfterIKLayerZeroPelvisMatrix;

		// Token: 0x040007DB RID: 2011
		private Matrix4x4 m_AfterIKLayerZeroPelvisMatrixNoScale;

		// Token: 0x020001B1 RID: 433
		// (Invoke) Token: 0x06000A65 RID: 2661
		public delegate void UserWorldPositionCalculedHandler(ref Vector3 userWorldPositiob, PelvisMovementMouseUserController sender);
	}
}
