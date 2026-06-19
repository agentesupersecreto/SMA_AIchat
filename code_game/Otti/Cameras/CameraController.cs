using System;
using System.Collections.Generic;
using com.ootii.Actors;
using com.ootii.Geometry;
using com.ootii.Helpers;
using com.ootii.Input;
using com.ootii.Messages;
using com.ootii.Utilities;
using UnityEngine;

namespace com.ootii.Cameras
{
	// Token: 0x02000070 RID: 112
	[AddComponentMenu("ootii/Camera Rigs/Camera Controller")]
	public class CameraController : BaseCameraRig
	{
		// Token: 0x170000FF RID: 255
		// (get) Token: 0x060004E5 RID: 1253 RVA: 0x0001C61A File Offset: 0x0001A81A
		public ICharacterController CharacterController
		{
			get
			{
				return this.mCharacterController;
			}
		}

		// Token: 0x17000100 RID: 256
		// (get) Token: 0x060004E6 RID: 1254 RVA: 0x0001C622 File Offset: 0x0001A822
		// (set) Token: 0x060004E7 RID: 1255 RVA: 0x0001C62A File Offset: 0x0001A82A
		public GameObject InputSourceOwner
		{
			get
			{
				return this._InputSourceOwner;
			}
			set
			{
				this._InputSourceOwner = value;
				if (this._InputSourceOwner != null)
				{
					this.mInputSource = InterfaceHelper.GetComponent<IInputSource>(this._InputSourceOwner);
				}
			}
		}

		// Token: 0x17000101 RID: 257
		// (get) Token: 0x060004E8 RID: 1256 RVA: 0x0001C652 File Offset: 0x0001A852
		// (set) Token: 0x060004E9 RID: 1257 RVA: 0x0001C65A File Offset: 0x0001A85A
		public bool AutoFindInputSource
		{
			get
			{
				return this._AutoFindInputSource;
			}
			set
			{
				this._AutoFindInputSource = value;
			}
		}

		// Token: 0x17000102 RID: 258
		// (get) Token: 0x060004EA RID: 1258 RVA: 0x0001C663 File Offset: 0x0001A863
		// (set) Token: 0x060004EB RID: 1259 RVA: 0x0001C66C File Offset: 0x0001A86C
		public override Transform Anchor
		{
			get
			{
				return this._Anchor;
			}
			set
			{
				if (this._Anchor != null)
				{
					ICharacterController component = InterfaceHelper.GetComponent<ICharacterController>(this._Anchor.gameObject);
					if (component != null)
					{
						ICharacterController characterController = component;
						characterController.OnControllerPostLateUpdate = (ControllerLateUpdateDelegate)Delegate.Remove(characterController.OnControllerPostLateUpdate, new ControllerLateUpdateDelegate(this.OnControllerLateUpdate));
					}
					else
					{
						IBaseCameraAnchor component2 = this._Anchor.GetComponent<IBaseCameraAnchor>();
						if (component2 != null)
						{
							IBaseCameraAnchor baseCameraAnchor = component2;
							baseCameraAnchor.OnAnchorPostLateUpdate = (ControllerLateUpdateDelegate)Delegate.Remove(baseCameraAnchor.OnAnchorPostLateUpdate, new ControllerLateUpdateDelegate(this.OnControllerLateUpdate));
						}
					}
				}
				bool flag = this._Anchor == value;
				this._Anchor = value;
				if (this._Anchor != null && base.enabled)
				{
					ICharacterController component3 = InterfaceHelper.GetComponent<ICharacterController>(this._Anchor.gameObject);
					if (component3 == null)
					{
						IBaseCameraAnchor component4 = this._Anchor.GetComponent<IBaseCameraAnchor>();
						if (component4 != null)
						{
							IBaseCameraAnchor baseCameraAnchor2 = component4;
							baseCameraAnchor2.OnAnchorPostLateUpdate = (ControllerLateUpdateDelegate)Delegate.Combine(baseCameraAnchor2.OnAnchorPostLateUpdate, new ControllerLateUpdateDelegate(this.OnControllerLateUpdate));
						}
						else
						{
							base.IsInternalUpdateEnabled = true;
						}
					}
					else
					{
						base.IsInternalUpdateEnabled = false;
						this.IsFixedUpdateEnabled = false;
						ICharacterController characterController2 = component3;
						characterController2.OnControllerPostLateUpdate = (ControllerLateUpdateDelegate)Delegate.Combine(characterController2.OnControllerPostLateUpdate, new ControllerLateUpdateDelegate(this.OnControllerLateUpdate));
					}
					if (Application.isPlaying && !flag && this.ActiveMotor != null)
					{
						this.ActiveMotor.Initialize();
					}
				}
			}
		}

		// Token: 0x17000103 RID: 259
		// (get) Token: 0x060004EC RID: 1260 RVA: 0x0001C7C1 File Offset: 0x0001A9C1
		// (set) Token: 0x060004ED RID: 1261 RVA: 0x0001C7C9 File Offset: 0x0001A9C9
		public Vector3 AnchorOffset
		{
			get
			{
				return this._AnchorOffset;
			}
			set
			{
				this._AnchorOffset = value;
			}
		}

		// Token: 0x17000104 RID: 260
		// (get) Token: 0x060004EE RID: 1262 RVA: 0x0001C7D2 File Offset: 0x0001A9D2
		// (set) Token: 0x060004EF RID: 1263 RVA: 0x0001C7DA File Offset: 0x0001A9DA
		public bool RotateAnchorOffset
		{
			get
			{
				return this._RotateAnchorOffset;
			}
			set
			{
				this._RotateAnchorOffset = value;
			}
		}

		// Token: 0x17000105 RID: 261
		// (get) Token: 0x060004F0 RID: 1264 RVA: 0x0001C7E3 File Offset: 0x0001A9E3
		public Vector3 AnchorPosition
		{
			get
			{
				if (this._Anchor == null)
				{
					return this._AnchorOffset;
				}
				return this._Anchor.position + this._Anchor.rotation * this._AnchorOffset;
			}
		}

		// Token: 0x17000106 RID: 262
		// (get) Token: 0x060004F1 RID: 1265 RVA: 0x0001C820 File Offset: 0x0001AA20
		// (set) Token: 0x060004F2 RID: 1266 RVA: 0x0001C828 File Offset: 0x0001AA28
		public bool InvertPitch
		{
			get
			{
				return this._InvertPitch;
			}
			set
			{
				this._InvertPitch = value;
			}
		}

		// Token: 0x17000107 RID: 263
		// (get) Token: 0x060004F3 RID: 1267 RVA: 0x0001C831 File Offset: 0x0001AA31
		// (set) Token: 0x060004F4 RID: 1268 RVA: 0x0001C839 File Offset: 0x0001AA39
		public override int Mode
		{
			get
			{
				return this._ActiveMotorIndex;
			}
			set
			{
				this.ActivateMotor(value);
			}
		}

		// Token: 0x17000108 RID: 264
		// (get) Token: 0x060004F5 RID: 1269 RVA: 0x0001C842 File Offset: 0x0001AA42
		public int ActiveMotorIndex
		{
			get
			{
				return this._ActiveMotorIndex;
			}
		}

		// Token: 0x17000109 RID: 265
		// (get) Token: 0x060004F6 RID: 1270 RVA: 0x0001C84A File Offset: 0x0001AA4A
		public CameraMotor ActiveMotor
		{
			get
			{
				if (this._ActiveMotorIndex < 0 || this._ActiveMotorIndex >= this.Motors.Count)
				{
					return null;
				}
				return this.Motors[this._ActiveMotorIndex];
			}
		}

		// Token: 0x1700010A RID: 266
		// (get) Token: 0x060004F7 RID: 1271 RVA: 0x0001C87B File Offset: 0x0001AA7B
		public Quaternion Tilt
		{
			get
			{
				return this.mTilt;
			}
		}

		// Token: 0x1700010B RID: 267
		// (get) Token: 0x060004F8 RID: 1272 RVA: 0x0001C883 File Offset: 0x0001AA83
		// (set) Token: 0x060004F9 RID: 1273 RVA: 0x0001C88B File Offset: 0x0001AA8B
		public bool IsCollisionsEnabled
		{
			get
			{
				return this._IsCollisionsEnabled;
			}
			set
			{
				this._IsCollisionsEnabled = value;
			}
		}

		// Token: 0x1700010C RID: 268
		// (get) Token: 0x060004FA RID: 1274 RVA: 0x0001C894 File Offset: 0x0001AA94
		// (set) Token: 0x060004FB RID: 1275 RVA: 0x0001C89C File Offset: 0x0001AA9C
		public int CollisionLayers
		{
			get
			{
				return this._CollisionLayers;
			}
			set
			{
				this._CollisionLayers = value;
			}
		}

		// Token: 0x1700010D RID: 269
		// (get) Token: 0x060004FC RID: 1276 RVA: 0x0001C8A5 File Offset: 0x0001AAA5
		// (set) Token: 0x060004FD RID: 1277 RVA: 0x0001C8AD File Offset: 0x0001AAAD
		public float CollisionRadius
		{
			get
			{
				return this._CollisionRadius;
			}
			set
			{
				this._CollisionRadius = value;
			}
		}

		// Token: 0x1700010E RID: 270
		// (get) Token: 0x060004FE RID: 1278 RVA: 0x0001C8B6 File Offset: 0x0001AAB6
		// (set) Token: 0x060004FF RID: 1279 RVA: 0x0001C8BE File Offset: 0x0001AABE
		public float MinCollisionDistance
		{
			get
			{
				return this._MinCollisionDistance;
			}
			set
			{
				this._MinCollisionDistance = value;
			}
		}

		// Token: 0x1700010F RID: 271
		// (get) Token: 0x06000500 RID: 1280 RVA: 0x0001C8C7 File Offset: 0x0001AAC7
		// (set) Token: 0x06000501 RID: 1281 RVA: 0x0001C8CF File Offset: 0x0001AACF
		public float CollisionRecoverySpeed
		{
			get
			{
				return this._CollisionRecoverySpeed;
			}
			set
			{
				this._CollisionRecoverySpeed = value;
			}
		}

		// Token: 0x17000110 RID: 272
		// (get) Token: 0x06000502 RID: 1282 RVA: 0x0001C8D8 File Offset: 0x0001AAD8
		// (set) Token: 0x06000503 RID: 1283 RVA: 0x0001C8E0 File Offset: 0x0001AAE0
		public bool IsZoomEnabled
		{
			get
			{
				return this._IsZoomEnabled;
			}
			set
			{
				this._IsZoomEnabled = value;
			}
		}

		// Token: 0x17000111 RID: 273
		// (get) Token: 0x06000504 RID: 1284 RVA: 0x0001C8E9 File Offset: 0x0001AAE9
		// (set) Token: 0x06000505 RID: 1285 RVA: 0x0001C8F1 File Offset: 0x0001AAF1
		public string ZoomActionAlias
		{
			get
			{
				return this._ZoomActionAlias;
			}
			set
			{
				this._ZoomActionAlias = value;
			}
		}

		// Token: 0x17000112 RID: 274
		// (get) Token: 0x06000506 RID: 1286 RVA: 0x0001C8FA File Offset: 0x0001AAFA
		// (set) Token: 0x06000507 RID: 1287 RVA: 0x0001C902 File Offset: 0x0001AB02
		public bool ZoomResetOnRelease
		{
			get
			{
				return this._ZoomResetOnRelease;
			}
			set
			{
				this._ZoomResetOnRelease = value;
			}
		}

		// Token: 0x17000113 RID: 275
		// (get) Token: 0x06000508 RID: 1288 RVA: 0x0001C90B File Offset: 0x0001AB0B
		// (set) Token: 0x06000509 RID: 1289 RVA: 0x0001C913 File Offset: 0x0001AB13
		public float ZoomSpeed
		{
			get
			{
				return this._ZoomSpeed;
			}
			set
			{
				this._ZoomSpeed = value;
			}
		}

		// Token: 0x17000114 RID: 276
		// (get) Token: 0x0600050A RID: 1290 RVA: 0x0001C91C File Offset: 0x0001AB1C
		// (set) Token: 0x0600050B RID: 1291 RVA: 0x0001C924 File Offset: 0x0001AB24
		public float ZoomSmoothing
		{
			get
			{
				return this._ZoomSmoothing;
			}
			set
			{
				this._ZoomSmoothing = value;
			}
		}

		// Token: 0x17000115 RID: 277
		// (get) Token: 0x0600050C RID: 1292 RVA: 0x0001C92D File Offset: 0x0001AB2D
		// (set) Token: 0x0600050D RID: 1293 RVA: 0x0001C935 File Offset: 0x0001AB35
		public float ZoomMin
		{
			get
			{
				return this._ZoomMin;
			}
			set
			{
				this._ZoomMin = value;
			}
		}

		// Token: 0x17000116 RID: 278
		// (get) Token: 0x0600050E RID: 1294 RVA: 0x0001C93E File Offset: 0x0001AB3E
		// (set) Token: 0x0600050F RID: 1295 RVA: 0x0001C946 File Offset: 0x0001AB46
		public float ZoomMax
		{
			get
			{
				return this._ZoomMax;
			}
			set
			{
				this._ZoomMax = value;
			}
		}

		// Token: 0x17000117 RID: 279
		// (get) Token: 0x06000510 RID: 1296 RVA: 0x0001C94F File Offset: 0x0001AB4F
		public float OriginalFOV
		{
			get
			{
				return this.mOriginalFOV;
			}
		}

		// Token: 0x17000118 RID: 280
		// (get) Token: 0x06000511 RID: 1297 RVA: 0x0001C957 File Offset: 0x0001AB57
		// (set) Token: 0x06000512 RID: 1298 RVA: 0x0001C95F File Offset: 0x0001AB5F
		public float TargetFOV
		{
			get
			{
				return this.mTargetFOV;
			}
			set
			{
				this.mTargetFOV = value;
			}
		}

		// Token: 0x17000119 RID: 281
		// (get) Token: 0x06000513 RID: 1299 RVA: 0x0001C968 File Offset: 0x0001AB68
		// (set) Token: 0x06000514 RID: 1300 RVA: 0x0001C970 File Offset: 0x0001AB70
		public bool IsFadeEnabed
		{
			get
			{
				return this._IsFadeEnabled;
			}
			set
			{
				this._IsFadeEnabled = value;
				if (!this._IsFadeEnabled)
				{
					this.SetAnchorAlpha(1f);
				}
			}
		}

		// Token: 0x1700011A RID: 282
		// (get) Token: 0x06000515 RID: 1301 RVA: 0x0001C98C File Offset: 0x0001AB8C
		// (set) Token: 0x06000516 RID: 1302 RVA: 0x0001C994 File Offset: 0x0001AB94
		public float FadeDistance
		{
			get
			{
				return this._FadeDistance;
			}
			set
			{
				this._FadeDistance = value;
			}
		}

		// Token: 0x1700011B RID: 283
		// (get) Token: 0x06000517 RID: 1303 RVA: 0x0001C99D File Offset: 0x0001AB9D
		// (set) Token: 0x06000518 RID: 1304 RVA: 0x0001C9A5 File Offset: 0x0001ABA5
		public float FadeSpeed
		{
			get
			{
				return this._FadeSpeed;
			}
			set
			{
				this._FadeSpeed = value;
			}
		}

		// Token: 0x1700011C RID: 284
		// (get) Token: 0x06000519 RID: 1305 RVA: 0x0001C9AE File Offset: 0x0001ABAE
		// (set) Token: 0x0600051A RID: 1306 RVA: 0x0001C9B6 File Offset: 0x0001ABB6
		public bool DisableRenderers
		{
			get
			{
				return this._DisableRenderers;
			}
			set
			{
				this._DisableRenderers = value;
			}
		}

		// Token: 0x1700011D RID: 285
		// (get) Token: 0x0600051B RID: 1307 RVA: 0x0001C9BF File Offset: 0x0001ABBF
		// (set) Token: 0x0600051C RID: 1308 RVA: 0x0001C9C7 File Offset: 0x0001ABC7
		public AnimationCurve ShakeStrength
		{
			get
			{
				return this._ShakeStrength;
			}
			set
			{
				this._ShakeStrength = value;
			}
		}

		// Token: 0x1700011E RID: 286
		// (get) Token: 0x0600051D RID: 1309 RVA: 0x0001C9D0 File Offset: 0x0001ABD0
		public IInputSource InputSource
		{
			get
			{
				return this.mInputSource;
			}
		}

		// Token: 0x1700011F RID: 287
		// (get) Token: 0x0600051E RID: 1310 RVA: 0x0001C9D8 File Offset: 0x0001ABD8
		public Vector3 LastPosition
		{
			get
			{
				return this.mLastPosition;
			}
		}

		// Token: 0x17000120 RID: 288
		// (get) Token: 0x0600051F RID: 1311 RVA: 0x0001C9E0 File Offset: 0x0001ABE0
		public Quaternion LastRotation
		{
			get
			{
				return this.mLastRotation;
			}
		}

		// Token: 0x06000520 RID: 1312 RVA: 0x0001C9E8 File Offset: 0x0001ABE8
		protected override void Awake_Camera()
		{
			base.Awake_Camera();
			this.mLastPosition = base.transform.position;
			this.mLastRotation = base.transform.rotation;
			if (this._InputSourceOwner != null)
			{
				this.mInputSource = InterfaceHelper.GetComponent<IInputSource>(this._InputSourceOwner);
			}
			if (this._AutoFindInputSource && this.mInputSource == null)
			{
				this.mInputSource = InterfaceHelper.GetComponent<IInputSource>(base.gameObject);
			}
			if (this._AutoFindInputSource && this.mInputSource == null)
			{
				IInputSource[] components = InterfaceHelper.GetComponents<IInputSource>();
				for (int i = 0; i < components.Length; i++)
				{
					GameObject gameObject = ((MonoBehaviour)components[i]).gameObject;
					if (gameObject.activeSelf && components[i].IsEnabled)
					{
						this.mInputSource = components[i];
						this._InputSourceOwner = gameObject;
					}
				}
			}
			if (this._Anchor != null && base.enabled)
			{
				ICharacterController component = InterfaceHelper.GetComponent<ICharacterController>(this._Anchor.gameObject);
				if (component == null)
				{
					IBaseCameraAnchor component2 = this._Anchor.GetComponent<IBaseCameraAnchor>();
					if (component2 != null)
					{
						base.IsInternalUpdateEnabled = false;
						this.IsFixedUpdateEnabled = false;
						IBaseCameraAnchor baseCameraAnchor = component2;
						baseCameraAnchor.OnAnchorPostLateUpdate = (ControllerLateUpdateDelegate)Delegate.Combine(baseCameraAnchor.OnAnchorPostLateUpdate, new ControllerLateUpdateDelegate(this.OnControllerLateUpdate));
					}
				}
				else
				{
					base.IsInternalUpdateEnabled = false;
					this.IsFixedUpdateEnabled = false;
					ICharacterController characterController = component;
					characterController.OnControllerPostLateUpdate = (ControllerLateUpdateDelegate)Delegate.Combine(characterController.OnControllerPostLateUpdate, new ControllerLateUpdateDelegate(this.OnControllerLateUpdate));
				}
				this.mTilt = QuaternionExt.FromToRotation(Vector3.up, this._Anchor.up);
			}
			if (this._Camera != null)
			{
				this.mOriginalFOV = this._Camera.fieldOfView;
			}
			if (this._ShakeStrength.keys.Length == 2 && this._ShakeStrength.keys[0].value == 0f && this._ShakeStrength.keys[0].value == 0f)
			{
				this._ShakeStrength.AddKey(0.5f, 1f);
			}
			this.InstantiateMotors();
		}

		// Token: 0x06000521 RID: 1313 RVA: 0x0001CBF8 File Offset: 0x0001ADF8
		protected override void Start()
		{
			if (this.Anchor == null)
			{
				GameObject gameObject = GameObject.FindGameObjectWithTag("Player");
				if (gameObject != null)
				{
					this.Anchor = gameObject.transform;
				}
			}
		}

		// Token: 0x06000522 RID: 1314 RVA: 0x0001CC34 File Offset: 0x0001AE34
		protected void OnEnable()
		{
			if (this._Anchor != null)
			{
				ICharacterController component = InterfaceHelper.GetComponent<ICharacterController>(this._Anchor.gameObject);
				if (component != null)
				{
					if (component.OnControllerPostLateUpdate != null)
					{
						ICharacterController characterController = component;
						characterController.OnControllerPostLateUpdate = (ControllerLateUpdateDelegate)Delegate.Remove(characterController.OnControllerPostLateUpdate, new ControllerLateUpdateDelegate(this.OnControllerLateUpdate));
					}
					ICharacterController characterController2 = component;
					characterController2.OnControllerPostLateUpdate = (ControllerLateUpdateDelegate)Delegate.Combine(characterController2.OnControllerPostLateUpdate, new ControllerLateUpdateDelegate(this.OnControllerLateUpdate));
					return;
				}
				IBaseCameraAnchor component2 = this._Anchor.GetComponent<IBaseCameraAnchor>();
				if (component2 != null)
				{
					if (component2.OnAnchorPostLateUpdate != null)
					{
						IBaseCameraAnchor baseCameraAnchor = component2;
						baseCameraAnchor.OnAnchorPostLateUpdate = (ControllerLateUpdateDelegate)Delegate.Remove(baseCameraAnchor.OnAnchorPostLateUpdate, new ControllerLateUpdateDelegate(this.OnControllerLateUpdate));
					}
					IBaseCameraAnchor baseCameraAnchor2 = component2;
					baseCameraAnchor2.OnAnchorPostLateUpdate = (ControllerLateUpdateDelegate)Delegate.Combine(baseCameraAnchor2.OnAnchorPostLateUpdate, new ControllerLateUpdateDelegate(this.OnControllerLateUpdate));
				}
			}
		}

		// Token: 0x06000523 RID: 1315 RVA: 0x0001CD10 File Offset: 0x0001AF10
		protected void OnDisable()
		{
			if (this._Anchor != null)
			{
				ICharacterController component = InterfaceHelper.GetComponent<ICharacterController>(this._Anchor.gameObject);
				if (component != null && component.OnControllerPostLateUpdate != null)
				{
					ICharacterController characterController = component;
					characterController.OnControllerPostLateUpdate = (ControllerLateUpdateDelegate)Delegate.Remove(characterController.OnControllerPostLateUpdate, new ControllerLateUpdateDelegate(this.OnControllerLateUpdate));
					return;
				}
				IBaseCameraAnchor component2 = this._Anchor.GetComponent<IBaseCameraAnchor>();
				if (component2 != null)
				{
					IBaseCameraAnchor baseCameraAnchor = component2;
					baseCameraAnchor.OnAnchorPostLateUpdate = (ControllerLateUpdateDelegate)Delegate.Remove(baseCameraAnchor.OnAnchorPostLateUpdate, new ControllerLateUpdateDelegate(this.OnControllerLateUpdate));
				}
			}
		}

		// Token: 0x06000524 RID: 1316 RVA: 0x0001CD9C File Offset: 0x0001AF9C
		public override void ExtrapolateAnchorPosition(out Vector3 rPosition, out Quaternion rRotation)
		{
			rPosition = this._Anchor.position;
			rRotation = this._Anchor.rotation;
			CameraMotor activeMotor = this.ActiveMotor;
			if (activeMotor == null)
			{
				return;
			}
			float num = ((this.mActualDistance > 0f) ? this.mActualDistance : activeMotor.Distance);
			Vector3 vector = this._Transform.position + this._Transform.forward * num;
			YawPitchMotor yawPitchMotor = activeMotor as YawPitchMotor;
			if (yawPitchMotor != null)
			{
				Quaternion quaternion = this._Transform.rotation * Quaternion.Inverse(Quaternion.Euler(yawPitchMotor.LocalPitch, yawPitchMotor.LocalYaw, 0f));
				vector = vector + this._Transform.right * -activeMotor.Offset.x + this._Transform.forward * -activeMotor.Offset.z;
				Vector3 vector2 = vector - quaternion * activeMotor.AnchorOffset;
				rPosition = vector2;
				rRotation = quaternion;
			}
		}

		// Token: 0x06000525 RID: 1317 RVA: 0x0001CEB8 File Offset: 0x0001B0B8
		public void EnableMotor(string rName, bool rEnable)
		{
			for (int i = 0; i < this.Motors.Count; i++)
			{
				CameraMotor cameraMotor = this.Motors[i];
				if (cameraMotor.Name == rName)
				{
					cameraMotor.IsEnabled = rEnable;
				}
			}
		}

		// Token: 0x06000526 RID: 1318 RVA: 0x0001CF00 File Offset: 0x0001B100
		public void EnableMotor<T>(bool rEnable, string rName = null) where T : CameraMotor
		{
			Type typeFromHandle = typeof(T);
			for (int i = 0; i < this.Motors.Count; i++)
			{
				CameraMotor cameraMotor = this.Motors[i];
				if (ReflectionHelper.IsSubclassOf(cameraMotor.GetType(), typeFromHandle) && (rName == null || cameraMotor.Name == rName))
				{
					cameraMotor.IsEnabled = rEnable;
				}
			}
		}

		// Token: 0x06000527 RID: 1319 RVA: 0x0001CF64 File Offset: 0x0001B164
		public void ActivateMotor(int rIndex)
		{
			if (this._ActiveMotorIndex == rIndex)
			{
				return;
			}
			if (rIndex < 0 || rIndex >= this.Motors.Count)
			{
				return;
			}
			if (!this.Motors[rIndex].IsEnabled)
			{
				return;
			}
			CameraMotor cameraMotor = null;
			CameraMessage cameraMessage;
			if (this._ActiveMotorIndex >= 0 && this._ActiveMotorIndex < this.Motors.Count)
			{
				cameraMotor = this.Motors[this._ActiveMotorIndex];
				cameraMotor.Deactivate(this.Motors[rIndex]);
				if (this.MotorDeactivated != null)
				{
					this.MotorDeactivated(cameraMotor);
				}
				cameraMessage = CameraMessage.Allocate();
				cameraMessage.ID = EnumMessageID.MSG_CAMERA_MOTOR_DEACTIVATE;
				cameraMessage.Motor = cameraMotor;
				if (this.MotorDeactivatedEvent != null)
				{
					this.MotorDeactivatedEvent.Invoke(cameraMessage);
				}
				CameraMessage.Release(cameraMessage);
			}
			this.Motors[rIndex].Activate(cameraMotor);
			this._ActiveMotorIndex = rIndex;
			if (this.MotorActivated != null)
			{
				this.MotorActivated(this.Motors[this._ActiveMotorIndex]);
			}
			cameraMessage = CameraMessage.Allocate();
			cameraMessage.ID = EnumMessageID.MSG_CAMERA_MOTOR_ACTIVATE;
			cameraMessage.Motor = this.Motors[this._ActiveMotorIndex];
			if (this.MotorActivatedEvent != null)
			{
				this.MotorActivatedEvent.Invoke(cameraMessage);
			}
			CameraMessage.Release(cameraMessage);
		}

		// Token: 0x06000528 RID: 1320 RVA: 0x0001D0AC File Offset: 0x0001B2AC
		public void ActivateMotor(CameraMotor rMotor)
		{
			if (rMotor == null)
			{
				return;
			}
			if (!rMotor.IsEnabled)
			{
				return;
			}
			int num = this.Motors.IndexOf(rMotor);
			if (num == this._ActiveMotorIndex)
			{
				return;
			}
			CameraMotor cameraMotor = null;
			CameraMessage cameraMessage;
			if (this._ActiveMotorIndex >= 0 && this._ActiveMotorIndex < this.Motors.Count)
			{
				cameraMotor = this.Motors[this._ActiveMotorIndex];
				cameraMotor.Deactivate(rMotor);
				if (this.MotorDeactivated != null)
				{
					this.MotorDeactivated(cameraMotor);
				}
				cameraMessage = CameraMessage.Allocate();
				cameraMessage.ID = EnumMessageID.MSG_CAMERA_MOTOR_DEACTIVATE;
				cameraMessage.Motor = this.Motors[this._ActiveMotorIndex];
				if (this.MotorDeactivatedEvent != null)
				{
					this.MotorDeactivatedEvent.Invoke(cameraMessage);
				}
				CameraMessage.Release(cameraMessage);
			}
			rMotor.Activate(cameraMotor);
			this._ActiveMotorIndex = num;
			if (this.MotorActivated != null)
			{
				this.MotorActivated(this.Motors[this._ActiveMotorIndex]);
			}
			cameraMessage = CameraMessage.Allocate();
			cameraMessage.ID = EnumMessageID.MSG_CAMERA_MOTOR_ACTIVATE;
			cameraMessage.Motor = this.Motors[this._ActiveMotorIndex];
			if (this.MotorActivatedEvent != null)
			{
				this.MotorActivatedEvent.Invoke(cameraMessage);
			}
			CameraMessage.Release(cameraMessage);
		}

		// Token: 0x06000529 RID: 1321 RVA: 0x0001D1E4 File Offset: 0x0001B3E4
		public void DeactivateMotor()
		{
			if (this._ActiveMotorIndex >= 0 && this._ActiveMotorIndex < this.Motors.Count)
			{
				this.Motors[this._ActiveMotorIndex].Deactivate(null);
				if (this.MotorDeactivated != null)
				{
					this.MotorDeactivated(this.Motors[this._ActiveMotorIndex]);
				}
				CameraMessage cameraMessage = CameraMessage.Allocate();
				cameraMessage.ID = EnumMessageID.MSG_CAMERA_MOTOR_DEACTIVATE;
				cameraMessage.Motor = this.Motors[this._ActiveMotorIndex];
				if (this.MotorDeactivatedEvent != null)
				{
					this.MotorDeactivatedEvent.Invoke(cameraMessage);
				}
				CameraMessage.Release(cameraMessage);
			}
			this._ActiveMotorIndex = -1;
		}

		// Token: 0x0600052A RID: 1322 RVA: 0x0001D294 File Offset: 0x0001B494
		public CameraMotor GetMotor(string rName)
		{
			for (int i = 0; i < this.Motors.Count; i++)
			{
				CameraMotor cameraMotor = this.Motors[i];
				if (cameraMotor.Name == rName)
				{
					return cameraMotor;
				}
			}
			return null;
		}

		// Token: 0x0600052B RID: 1323 RVA: 0x0001D2D8 File Offset: 0x0001B4D8
		public T GetMotor<T>(string rName = null) where T : CameraMotor
		{
			Type typeFromHandle = typeof(T);
			for (int i = 0; i < this.Motors.Count; i++)
			{
				CameraMotor cameraMotor = this.Motors[i];
				if (ReflectionHelper.IsSubclassOf(cameraMotor.GetType(), typeFromHandle) && (rName == null || cameraMotor.Name == rName))
				{
					return cameraMotor as T;
				}
			}
			return default(T);
		}

		// Token: 0x0600052C RID: 1324 RVA: 0x0001D348 File Offset: 0x0001B548
		public int GetMotorIndex(string rName)
		{
			for (int i = 0; i < this.Motors.Count; i++)
			{
				if (this.Motors[i].Name == rName)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x0600052D RID: 1325 RVA: 0x0001D388 File Offset: 0x0001B588
		public int GetMotorIndex<T>(string rName = null) where T : CameraMotor
		{
			Type typeFromHandle = typeof(T);
			for (int i = 0; i < this.Motors.Count; i++)
			{
				CameraMotor cameraMotor = this.Motors[i];
				if (ReflectionHelper.IsSubclassOf(cameraMotor.GetType(), typeFromHandle) && (rName == null || cameraMotor.Name == rName))
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x0600052E RID: 1326 RVA: 0x0001D3E5 File Offset: 0x0001B5E5
		public void Shake(float rRange, float rDuration)
		{
			this.mShakeElapsed = 0f;
			this.mShakeSpeedFactor = 1f;
			this.mShakeStrengthX = 1f;
			this.mShakeStrengthY = 1f;
			this.mShakeRange = rRange;
			this.mShakeDuration = rDuration;
		}

		// Token: 0x0600052F RID: 1327 RVA: 0x0001D421 File Offset: 0x0001B621
		public void Shake(float rRange, float rStrengthX, float rStrengthY, float rDuration)
		{
			this.mShakeElapsed = 0f;
			this.mShakeSpeedFactor = 1f;
			this.mShakeStrengthX = rStrengthX;
			this.mShakeStrengthY = rStrengthY;
			this.mShakeRange = rRange;
			this.mShakeDuration = rDuration;
		}

		// Token: 0x06000530 RID: 1328 RVA: 0x0001D458 File Offset: 0x0001B658
		public override void ClearTargetYawPitch()
		{
			for (int i = 0; i < this.Motors.Count; i++)
			{
				YawPitchMotor yawPitchMotor = this.Motors[i] as YawPitchMotor;
				if (yawPitchMotor != null)
				{
					yawPitchMotor.ClearTargetYawPitch();
				}
			}
		}

		// Token: 0x06000531 RID: 1329 RVA: 0x0001D498 File Offset: 0x0001B698
		public override void SetTargetYawPitch(float rYaw, float rPitch, float rSpeed = -1f, bool rAutoClearTarget = true)
		{
			for (int i = 0; i < this.Motors.Count; i++)
			{
				YawPitchMotor yawPitchMotor = this.Motors[i] as YawPitchMotor;
				if (yawPitchMotor != null && yawPitchMotor.IsActive)
				{
					yawPitchMotor.SetTargetYawPitch(rYaw, rPitch, rSpeed, rAutoClearTarget);
				}
			}
		}

		// Token: 0x06000532 RID: 1330 RVA: 0x0001D4E4 File Offset: 0x0001B6E4
		public override void ClearTargetForward()
		{
			for (int i = 0; i < this.Motors.Count; i++)
			{
				YawPitchMotor yawPitchMotor = this.Motors[i] as YawPitchMotor;
				if (yawPitchMotor != null)
				{
					yawPitchMotor.ClearTargetForward();
				}
			}
		}

		// Token: 0x06000533 RID: 1331 RVA: 0x0001D524 File Offset: 0x0001B724
		public override void SetTargetForward(Vector3 rForward, float rSpeed = -1f, bool rAutoClearTarget = true)
		{
			for (int i = 0; i < this.Motors.Count; i++)
			{
				YawPitchMotor yawPitchMotor = this.Motors[i] as YawPitchMotor;
				if (yawPitchMotor != null)
				{
					yawPitchMotor.SetTargetForward(rForward, rSpeed, rAutoClearTarget);
				}
			}
		}

		// Token: 0x06000534 RID: 1332 RVA: 0x0001D565 File Offset: 0x0001B765
		protected override void InternalUpdate()
		{
			if (!this._IsInternalUpdateEnabled)
			{
				return;
			}
			base.InternalUpdate();
			this.mLastPosition = this._Transform.position;
			this.mLastRotation = this._Transform.rotation;
		}

		// Token: 0x06000535 RID: 1333 RVA: 0x0001D598 File Offset: 0x0001B798
		public override void RigLateUpdate(float rDeltaTime, int rUpdateIndex)
		{
			CameraMotor cameraMotor = this.ActiveMotor;
			float num = this.UpdateTilt();
			int num2 = -1;
			for (int i = 0; i < this.Motors.Count; i++)
			{
				if (i != this._ActiveMotorIndex)
				{
					bool flag = this.Motors[i].TestActivate(cameraMotor);
					CameraMessage cameraMessage = CameraMessage.Allocate();
					cameraMessage.ID = EnumMessageID.MSG_CAMERA_MOTOR_TEST;
					cameraMessage.Motor = this.Motors[this._ActiveMotorIndex];
					cameraMessage.Continue = true;
					if (flag && this.MotorTestActivateEvent != null)
					{
						this.MotorActivatedEvent.Invoke(cameraMessage);
						flag = cameraMessage.Continue;
					}
					CameraMessage.Release(cameraMessage);
					if (flag && (num2 < 0 || this.Motors[i].Priority >= this.Motors[num2].Priority))
					{
						num2 = i;
					}
				}
			}
			if (num2 >= 0)
			{
				this.ActivateMotor(num2);
				cameraMotor = this.Motors[num2];
			}
			if (cameraMotor == null)
			{
				return;
			}
			CameraTransform cameraTransform = cameraMotor.RigLateUpdate(rDeltaTime, rUpdateIndex, num);
			this.UpdateCollisions(rDeltaTime, ref cameraTransform);
			this._Transform.position = cameraTransform.Position;
			this._Transform.rotation = cameraTransform.Rotation;
			this.UpdateZoom(rDeltaTime);
			this.UpdateFade(rDeltaTime);
			this.UpdateShake(rDeltaTime);
			if (this.MotorUpdated != null)
			{
				this.MotorUpdated(cameraMotor);
			}
			if (this._IsInternalUpdateEnabled)
			{
				if (this.mOnPostLateUpdate != null)
				{
					this.mOnPostLateUpdate(rDeltaTime, this.mUpdateIndex, this);
				}
				cameraMotor.PostRigLateUpdate();
			}
		}

		// Token: 0x06000536 RID: 1334 RVA: 0x0001D728 File Offset: 0x0001B928
		protected void OnControllerLateUpdate(ICharacterController rController, float rDeltaTime, int rUpdateIndex)
		{
			this.mCharacterController = rController;
			this.RigLateUpdate(rDeltaTime, rUpdateIndex);
			if (this.mOnPostLateUpdate != null)
			{
				this.mOnPostLateUpdate(rDeltaTime, this.mUpdateIndex, this);
			}
			if (this._ActiveMotorIndex >= 0 && this._ActiveMotorIndex < this.Motors.Count)
			{
				this.Motors[this._ActiveMotorIndex].PostRigLateUpdate();
			}
			this._FrameForceToFollowAnchor = false;
			this.mLastPosition = this._Transform.position;
			this.mLastRotation = this._Transform.rotation;
		}

		// Token: 0x06000537 RID: 1335 RVA: 0x0001D7BC File Offset: 0x0001B9BC
		public void InstantiateMotors()
		{
			int count = this.MotorDefinitions.Count;
			for (int i = this.Motors.Count - 1; i >= count; i--)
			{
				this.Motors.RemoveAt(i);
			}
			for (int j = 0; j < count; j++)
			{
				string text = this.MotorDefinitions[j];
				JSONNode jsonnode = JSONNode.Parse(text);
				if (!(jsonnode == null))
				{
					string value = jsonnode["Type"].Value;
					Type type = Type.GetType(value);
					if (!(type == null))
					{
						CameraMotor cameraMotor;
						if (this.Motors.Count <= j || value != this.Motors[j].GetType().AssemblyQualifiedName)
						{
							cameraMotor = Activator.CreateInstance(type) as CameraMotor;
							cameraMotor.RigController = this;
							if (this.Motors.Count <= j)
							{
								this.Motors.Add(cameraMotor);
							}
							else
							{
								this.Motors[j] = cameraMotor;
							}
						}
						else
						{
							cameraMotor = this.Motors[j];
						}
						if (cameraMotor != null)
						{
							cameraMotor.DeserializeMotor(text);
						}
					}
				}
			}
			for (int k = 0; k < this.Motors.Count; k++)
			{
				this.Motors[k].Awake();
			}
			if (Application.isPlaying && this._ActiveMotorIndex >= 0 && this._ActiveMotorIndex < this.Motors.Count)
			{
				this.Motors[this._ActiveMotorIndex].Activate(null);
			}
		}

		// Token: 0x06000538 RID: 1336 RVA: 0x0001D94C File Offset: 0x0001BB4C
		private float UpdateTilt()
		{
			float num = 0f;
			if (this._Anchor != null)
			{
				Vector3 vector = this.mTilt.Up();
				Quaternion quaternion = QuaternionExt.FromToRotation(vector, this._Anchor.up);
				if (!quaternion.IsIdentity())
				{
					num = Vector3.Angle(vector, this._Anchor.up);
					this.mTilt = quaternion * this.mTilt;
				}
				if (Vector3.Angle(this.mTilt.Up(), Vector3.up) < 0.0001f && !this.mTilt.IsIdentity())
				{
					this.mTilt = Quaternion.identity;
				}
			}
			return num;
		}

		// Token: 0x06000539 RID: 1337 RVA: 0x0001D9EC File Offset: 0x0001BBEC
		private void UpdateZoom(float rDeltaTime)
		{
			if (this._IsZoomEnabled && this._ZoomActionAlias.Length > 0)
			{
				if (this._ZoomResetOnRelease && this.mInputSource.IsJustReleased(this._ZoomActionAlias))
				{
					this.mTargetFOV = this.mOriginalFOV;
				}
				else
				{
					float num = ((this._ZoomMax > 0f) ? this._ZoomMax : this.mOriginalFOV);
					float num2 = -this.mInputSource.GetValue(this._ZoomActionAlias) * this._ZoomSpeed;
					this.mTargetFOV = Mathf.Clamp(this.mTargetFOV + num2, this._ZoomMin, num);
				}
			}
			else if (this.mTargetFOV != this.mOriginalFOV)
			{
				this.mTargetFOV = this.mOriginalFOV;
			}
			if (this._IsZoomEnabled && Mathf.Abs(this.mTargetFOV - this._Camera.fieldOfView) > 0.001f)
			{
				this._Camera.fieldOfView = Mathf.SmoothDampAngle(this._Camera.fieldOfView, this.mTargetFOV, ref this.mZoomVelocity, this._ZoomSmoothing);
				return;
			}
			this.mZoomVelocity = 0f;
		}

		// Token: 0x0600053A RID: 1338 RVA: 0x0001DB08 File Offset: 0x0001BD08
		private void UpdateCollisions(float rDeltaTime, ref CameraTransform rTransform)
		{
			bool flag = false;
			CameraMotor activeMotor = this.ActiveMotor;
			float num = this._CollisionRecoverySpeed * rDeltaTime;
			Vector3 vector;
			Vector3 vector2;
			if (activeMotor == null)
			{
				vector = this._Anchor.position + this._Anchor.rotation * this._AnchorOffset;
				vector2 = this._Anchor.position + this._Anchor.rotation * this._AnchorOffset;
			}
			else
			{
				vector = activeMotor.AnchorPosition;
				vector2 = activeMotor.GetFocusPosition(rTransform.Rotation);
			}
			vector2 != vector;
			float num2 = Vector3.Distance(this._Transform.position, vector2);
			Vector3 vector3 = rTransform.Position - vector2;
			Vector3 normalized = vector3.normalized;
			float magnitude = vector3.magnitude;
			RaycastHit raycastHit;
			if (this._IsCollisionsEnabled && (activeMotor == null || activeMotor.IsCollisionEnabled) && RaycastExt.SafeSphereCast(vector2, normalized, this._CollisionRadius, out raycastHit, magnitude, this._CollisionLayers, this._Anchor, null, true))
			{
				this.mActualDistance = raycastHit.distance;
				if (this.mActualDistance == 0f && RaycastExt.SafeRaycast(vector2, normalized, out raycastHit, magnitude, this._CollisionLayers, this._Anchor, null, true, false))
				{
					this.mActualDistance = raycastHit.distance;
				}
				if (this.mActualDistance > 0f && this.mActualDistance - num2 <= num)
				{
					this.mActualDistance = Mathf.Max(this.mActualDistance, this._MinCollisionDistance);
					this.mHadCollided = true;
					flag = true;
					rTransform.Position = vector2 + normalized * this.mActualDistance;
				}
			}
			if (!flag && this.mHadCollided)
			{
				if (magnitude - num2 - 0.0001f > num)
				{
					this.mActualDistance = num2 + this._CollisionRecoverySpeed * rDeltaTime;
					rTransform.Position = vector2 + normalized * this.mActualDistance;
				}
				else
				{
					this.mHadCollided = false;
				}
			}
			if (this.mActualDistance == 0f)
			{
				this.mActualDistance = activeMotor.Distance;
			}
		}

		// Token: 0x0600053B RID: 1339 RVA: 0x0001DD0C File Offset: 0x0001BF0C
		private void UpdateShake(float rDeltaTime)
		{
			Vector3 zero = Vector3.zero;
			if (this.mShakeDuration > 0f)
			{
				this.mShakeElapsed += rDeltaTime * this.mShakeSpeedFactor;
				float num = Mathf.Clamp01(this.mShakeElapsed / this.mShakeDuration);
				if (num < 1f)
				{
					float num2 = this._ShakeStrength.Evaluate(num);
					zero.x = ((float)NumberHelper.Randomizer.NextDouble() * 2f - 1f) * this.mShakeRange * this.mShakeStrengthX * num2;
					zero.y = ((float)NumberHelper.Randomizer.NextDouble() * 2f - 1f) * this.mShakeRange * this.mShakeStrengthY * num2;
				}
				else
				{
					this.mShakeElapsed = 0f;
					this.mShakeDuration = 0f;
				}
				this._Camera.transform.localPosition = zero;
			}
		}

		// Token: 0x0600053C RID: 1340 RVA: 0x0001DDF4 File Offset: 0x0001BFF4
		private void UpdateFade(float rDelta)
		{
			Vector3 position = this._Transform.position;
			CameraMotor activeMotor = this.ActiveMotor;
			Vector3 vector;
			if (activeMotor == null)
			{
				vector = this._Anchor.position + this._Anchor.rotation * this._AnchorOffset;
			}
			else
			{
				vector = activeMotor.GetFocusPosition(this._Transform.rotation);
			}
			if (Vector3.Distance(position, vector) < this._FadeDistance)
			{
				this.mAlphaStart = this.mAlpha;
				this.mAlphaEnd = 0f;
			}
			else
			{
				this.mAlphaStart = this.mAlpha;
				this.mAlphaEnd = 1f;
			}
			if (this.mAlpha != this.mAlphaEnd)
			{
				this.mAlphaElapsed += Time.deltaTime;
				this.mAlpha = NumberHelper.SmoothStep(this.mAlphaStart, this.mAlphaEnd, (this._FadeSpeed > 0f) ? (this.mAlphaElapsed / this._FadeSpeed) : 1f);
				if (this._IsFadeEnabled)
				{
					this.SetAnchorAlpha(this.mAlpha);
					return;
				}
			}
			else
			{
				this.mAlphaElapsed = 0f;
				this.mAlphaStart = this.mAlpha;
			}
		}

		// Token: 0x0600053D RID: 1341 RVA: 0x0001DF14 File Offset: 0x0001C114
		protected void SetAnchorAlpha(float rAlpha)
		{
			if (this._Anchor == null)
			{
				return;
			}
			if (!Application.isPlaying)
			{
				return;
			}
			if (this._IsFadeEnabled && (this.ActiveMotor == null || this.ActiveMotor.IsFadingEnabled))
			{
				Renderer[] componentsInChildren = this._Anchor.gameObject.GetComponentsInChildren<Renderer>();
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					float num = rAlpha;
					bool flag = num > 0f;
					Renderer renderer = componentsInChildren[i];
					if (this._DisableRenderers || renderer.enabled)
					{
						if (this.ActiveMotor.SpecifyFadeRenderers && !this.ActiveMotor.IsFadeRenderer(renderer.transform))
						{
							num = 1f;
							flag = true;
						}
						Material[] materials = renderer.materials;
						for (int j = 0; j < materials.Length; j++)
						{
							if (materials[j].HasProperty("_Color"))
							{
								Color color = materials[j].color;
								color.a = num;
								materials[j].color = color;
							}
						}
						if (this._DisableRenderers)
						{
							renderer.enabled = flag;
						}
					}
				}
			}
		}

		// Token: 0x0600053E RID: 1342 RVA: 0x0001E030 File Offset: 0x0001C230
		public void SetManualUpdate()
		{
			base.IsInternalUpdateEnabled = false;
			this.IsFixedUpdateEnabled = false;
			if (this._Anchor != null)
			{
				ICharacterController componentInChildren = this._Anchor.GetComponentInChildren<ICharacterController>();
				if (componentInChildren != null)
				{
					ICharacterController characterController = componentInChildren;
					characterController.OnControllerPostLateUpdate = (ControllerLateUpdateDelegate)Delegate.Remove(characterController.OnControllerPostLateUpdate, new ControllerLateUpdateDelegate(this.OnControllerLateUpdate));
					return;
				}
				IBaseCameraAnchor component = this._Anchor.GetComponent<IBaseCameraAnchor>();
				if (component != null)
				{
					IBaseCameraAnchor baseCameraAnchor = component;
					baseCameraAnchor.OnAnchorPostLateUpdate = (ControllerLateUpdateDelegate)Delegate.Remove(baseCameraAnchor.OnAnchorPostLateUpdate, new ControllerLateUpdateDelegate(this.OnControllerLateUpdate));
				}
			}
		}

		// Token: 0x0600053F RID: 1343 RVA: 0x0001E0BC File Offset: 0x0001C2BC
		public void ManualUpdate(ICharacterController rController, float rDeltaTime, int rUpdateIndex)
		{
			this.OnControllerLateUpdate(rController, rDeltaTime, rUpdateIndex);
		}

		// Token: 0x04000262 RID: 610
		public const float EPSILON = 0.0001f;

		// Token: 0x04000263 RID: 611
		public const float MIN_PITCH = -87.4f;

		// Token: 0x04000264 RID: 612
		public const float MAX_PITCH = 87.4f;

		// Token: 0x04000265 RID: 613
		protected ICharacterController mCharacterController;

		// Token: 0x04000266 RID: 614
		public GameObject _InputSourceOwner;

		// Token: 0x04000267 RID: 615
		public bool _AutoFindInputSource = true;

		// Token: 0x04000268 RID: 616
		public Vector3 _AnchorOffset = new Vector3(0f, 2f, 0f);

		// Token: 0x04000269 RID: 617
		public bool _RotateAnchorOffset = true;

		// Token: 0x0400026A RID: 618
		public bool _InvertPitch = true;

		// Token: 0x0400026B RID: 619
		public int _ActiveMotorIndex = -1;

		// Token: 0x0400026C RID: 620
		public MessageEvent MotorTestActivateEvent;

		// Token: 0x0400026D RID: 621
		public MessageEvent MotorActivatedEvent;

		// Token: 0x0400026E RID: 622
		public MessageEvent MotorDeactivatedEvent;

		// Token: 0x0400026F RID: 623
		public MessageEvent ActionTriggeredEvent;

		// Token: 0x04000270 RID: 624
		[NonSerialized]
		public CameraMotorEvent MotorActivated;

		// Token: 0x04000271 RID: 625
		[NonSerialized]
		public CameraMotorEvent MotorUpdated;

		// Token: 0x04000272 RID: 626
		[NonSerialized]
		public CameraMotorEvent MotorArrived;

		// Token: 0x04000273 RID: 627
		[NonSerialized]
		public CameraMotorEvent MotorDeactivated;

		// Token: 0x04000274 RID: 628
		protected Quaternion mTilt = Quaternion.identity;

		// Token: 0x04000275 RID: 629
		public bool _IsCollisionsEnabled = true;

		// Token: 0x04000276 RID: 630
		public int _CollisionLayers = 1;

		// Token: 0x04000277 RID: 631
		public float _CollisionRadius = 0.2f;

		// Token: 0x04000278 RID: 632
		public float _MinCollisionDistance;

		// Token: 0x04000279 RID: 633
		public float _CollisionRecoverySpeed = 5f;

		// Token: 0x0400027A RID: 634
		protected bool mHadCollided;

		// Token: 0x0400027B RID: 635
		protected float mActualDistance;

		// Token: 0x0400027C RID: 636
		public bool _IsZoomEnabled = true;

		// Token: 0x0400027D RID: 637
		public string _ZoomActionAlias = "Camera Zoom";

		// Token: 0x0400027E RID: 638
		public bool _ZoomResetOnRelease = true;

		// Token: 0x0400027F RID: 639
		public float _ZoomSpeed = 25f;

		// Token: 0x04000280 RID: 640
		public float _ZoomSmoothing = 0.1f;

		// Token: 0x04000281 RID: 641
		public float _ZoomMin = 20f;

		// Token: 0x04000282 RID: 642
		public float _ZoomMax;

		// Token: 0x04000283 RID: 643
		protected float mOriginalFOV = 60f;

		// Token: 0x04000284 RID: 644
		protected float mTargetFOV = float.MaxValue;

		// Token: 0x04000285 RID: 645
		private float mZoomVelocity;

		// Token: 0x04000286 RID: 646
		public bool _IsFadeEnabled = true;

		// Token: 0x04000287 RID: 647
		public float _FadeDistance = 0.4f;

		// Token: 0x04000288 RID: 648
		public float _FadeSpeed = 0.25f;

		// Token: 0x04000289 RID: 649
		public bool _DisableRenderers;

		// Token: 0x0400028A RID: 650
		protected float mAlpha = 1f;

		// Token: 0x0400028B RID: 651
		protected float mAlphaStart;

		// Token: 0x0400028C RID: 652
		protected float mAlphaEnd = 1f;

		// Token: 0x0400028D RID: 653
		protected float mAlphaElapsed;

		// Token: 0x0400028E RID: 654
		public AnimationCurve _ShakeStrength = AnimationCurve.Linear(0f, 0f, 1f, 0f);

		// Token: 0x0400028F RID: 655
		protected float mShakeElapsed;

		// Token: 0x04000290 RID: 656
		protected float mShakeDuration;

		// Token: 0x04000291 RID: 657
		protected float mShakeSpeedFactor = 1f;

		// Token: 0x04000292 RID: 658
		protected float mShakeRange = 0.05f;

		// Token: 0x04000293 RID: 659
		protected float mShakeStrengthX = 1f;

		// Token: 0x04000294 RID: 660
		protected float mShakeStrengthY = 1f;

		// Token: 0x04000295 RID: 661
		[NonSerialized]
		public List<CameraMotor> Motors = new List<CameraMotor>();

		// Token: 0x04000296 RID: 662
		protected IInputSource mInputSource;

		// Token: 0x04000297 RID: 663
		public List<string> MotorDefinitions = new List<string>();

		// Token: 0x04000298 RID: 664
		public List<Transform> StoredTransforms = new List<Transform>();

		// Token: 0x04000299 RID: 665
		protected Vector3 mLastPosition = Vector3.zero;

		// Token: 0x0400029A RID: 666
		protected Quaternion mLastRotation = Quaternion.identity;
	}
}
