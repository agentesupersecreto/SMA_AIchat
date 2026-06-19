using System;
using UnityEngine;

namespace com.ootii.Input
{
	// Token: 0x0200002C RID: 44
	[AddComponentMenu("ootii/Input Sources/Unity Input Source")]
	public class UnityInputSource : MonoBehaviour, IInputSource
	{
		// Token: 0x17000077 RID: 119
		// (get) Token: 0x06000202 RID: 514 RVA: 0x0000A962 File Offset: 0x00008B62
		// (set) Token: 0x06000203 RID: 515 RVA: 0x0000A96A File Offset: 0x00008B6A
		public virtual bool IsEnabled
		{
			get
			{
				return this._IsEnabled;
			}
			set
			{
				this._IsEnabled = value;
			}
		}

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x06000204 RID: 516 RVA: 0x0000A973 File Offset: 0x00008B73
		// (set) Token: 0x06000205 RID: 517 RVA: 0x0000A97B File Offset: 0x00008B7B
		public virtual bool IsMovementEnabled
		{
			get
			{
				return this._IsMovementEnabled;
			}
			set
			{
				this._IsMovementEnabled = value;
			}
		}

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x06000206 RID: 518 RVA: 0x0000A984 File Offset: 0x00008B84
		// (set) Token: 0x06000207 RID: 519 RVA: 0x0000A98C File Offset: 0x00008B8C
		public virtual bool IsViewEnabled
		{
			get
			{
				return this._IsViewEnabled;
			}
			set
			{
				this._IsViewEnabled = value;
			}
		}

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x06000208 RID: 520 RVA: 0x0000A995 File Offset: 0x00008B95
		public virtual bool IsXboxControllerEnabled
		{
			get
			{
				return this._IsXboxControllerEnabled;
			}
		}

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x06000209 RID: 521 RVA: 0x0000A99D File Offset: 0x00008B9D
		// (set) Token: 0x0600020A RID: 522 RVA: 0x0000A9A4 File Offset: 0x00008BA4
		public virtual float InputFromCameraAngle
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x0600020B RID: 523 RVA: 0x0000A9A6 File Offset: 0x00008BA6
		// (set) Token: 0x0600020C RID: 524 RVA: 0x0000A9AD File Offset: 0x00008BAD
		public virtual float InputFromAvatarAngle
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x0600020D RID: 525 RVA: 0x0000A9B0 File Offset: 0x00008BB0
		public virtual float MovementX
		{
			get
			{
				float num = this.emulatedXMovement;
				if (!this._IsEnabled || !this._IsMovementEnabled)
				{
					return num;
				}
				if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
				{
					num += 1f;
					Mathf.Clamp(num, -1f, 1f);
				}
				if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
				{
					num -= 1f;
					Mathf.Clamp(num, -1f, 1f);
				}
				if (this._IsXboxControllerEnabled && num == 0f)
				{
					try
					{
						num = Input.GetAxis("WXLeftStickX");
					}
					catch
					{
					}
				}
				return num;
			}
		}

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x0600020E RID: 526 RVA: 0x0000AA64 File Offset: 0x00008C64
		public virtual float MovementY
		{
			get
			{
				float num = this.emulatedYMovement;
				if (!this._IsEnabled || !this._IsMovementEnabled)
				{
					return num;
				}
				if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
				{
					num += 1f;
					Mathf.Clamp(num, -1f, 1f);
				}
				if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
				{
					num -= 1f;
					Mathf.Clamp(num, -1f, 1f);
				}
				if (this._IsXboxControllerEnabled && num == 0f)
				{
					try
					{
						num = Input.GetAxis("WXLeftStickY");
					}
					catch
					{
					}
				}
				return num;
			}
		}

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x0600020F RID: 527 RVA: 0x0000AB18 File Offset: 0x00008D18
		public virtual bool IsGoingFaster
		{
			get
			{
				bool flag = this.emulatedIsGoingFaster;
				if (!this._IsEnabled || !this._IsMovementEnabled)
				{
					return flag;
				}
				bool flag2;
				try
				{
					flag = flag || Input.GetButton("GoFaster");
					flag2 = flag;
				}
				catch
				{
					flag2 = false;
				}
				return flag2;
			}
		}

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x06000210 RID: 528 RVA: 0x0000AB6C File Offset: 0x00008D6C
		public virtual float MovementSqr
		{
			get
			{
				if (!this._IsEnabled || !this._IsMovementEnabled)
				{
					return 0f;
				}
				float movementX = this.MovementX;
				float movementY = this.MovementY;
				return movementX * movementX + movementY * movementY;
			}
		}

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x06000211 RID: 529 RVA: 0x0000ABA4 File Offset: 0x00008DA4
		public virtual float ViewX
		{
			get
			{
				if (!this._IsEnabled || !this._IsViewEnabled)
				{
					return 0f;
				}
				float num = Input.GetAxis("Mouse X") * this.ViewXMod;
				if (this._IsXboxControllerEnabled && num == 0f)
				{
					num = Input.GetAxis("WXRightStickX") * (Time.deltaTime / 0.01666f);
				}
				return num;
			}
		}

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x06000212 RID: 530 RVA: 0x0000AC04 File Offset: 0x00008E04
		public virtual float ViewY
		{
			get
			{
				if (!this._IsEnabled || !this._IsViewEnabled)
				{
					return 0f;
				}
				float num = Input.GetAxis("Mouse Y") * this.ViewYMod;
				if (this._IsXboxControllerEnabled && num == 0f)
				{
					num = Input.GetAxis("WXRightStickY") * (Time.deltaTime / 0.01666f);
				}
				return num;
			}
		}

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x06000213 RID: 531 RVA: 0x0000AC64 File Offset: 0x00008E64
		public virtual bool IsViewingActivated
		{
			get
			{
				if (!this._IsEnabled || !this._IsViewEnabled)
				{
					return false;
				}
				bool flag = false;
				if (this._IsXboxControllerEnabled)
				{
					flag = Input.GetAxis("WXRightStickX") != 0f;
					if (!flag)
					{
						flag = Input.GetAxis("WXRightStickY") != 0f;
					}
				}
				if (!flag)
				{
					if (this._ViewActivator == 0)
					{
						flag = true;
					}
					else if (this._ViewActivator == 1)
					{
						flag = Input.GetMouseButton(0);
					}
					else if (this._ViewActivator == 2)
					{
						flag = Input.GetMouseButton(1);
					}
					else if (this._ViewActivator == 3)
					{
						flag = Input.GetMouseButton(0);
						if (!flag)
						{
							flag = Input.GetMouseButton(1);
						}
					}
					else if (this._ViewActivator == 4)
					{
						flag = Input.GetMouseButton(2);
					}
				}
				return flag;
			}
		}

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x06000214 RID: 532 RVA: 0x0000AD1A File Offset: 0x00008F1A
		// (set) Token: 0x06000215 RID: 533 RVA: 0x0000AD22 File Offset: 0x00008F22
		public int ViewActivator
		{
			get
			{
				return this._ViewActivator;
			}
			set
			{
				this._ViewActivator = value;
			}
		}

		// Token: 0x06000216 RID: 534 RVA: 0x0000AD2B File Offset: 0x00008F2B
		public virtual bool IsJustPressed(KeyCode rKey)
		{
			return this._IsEnabled && this._IsMovementEnabled && Input.GetKeyDown(rKey);
		}

		// Token: 0x06000217 RID: 535 RVA: 0x0000AD45 File Offset: 0x00008F45
		public virtual bool IsJustPressed(int rKey)
		{
			return this._IsEnabled && this._IsMovementEnabled && Input.GetKeyDown((KeyCode)rKey);
		}

		// Token: 0x06000218 RID: 536 RVA: 0x0000AD60 File Offset: 0x00008F60
		public virtual bool IsJustPressed(string rAction)
		{
			if (!this._IsEnabled || !this._IsMovementEnabled)
			{
				return false;
			}
			bool flag;
			try
			{
				flag = Input.GetButtonDown(rAction);
			}
			catch
			{
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000219 RID: 537 RVA: 0x0000ADA0 File Offset: 0x00008FA0
		public virtual bool IsPressed(KeyCode rKey)
		{
			return this._IsEnabled && this._IsMovementEnabled && Input.GetKey(rKey);
		}

		// Token: 0x0600021A RID: 538 RVA: 0x0000ADBA File Offset: 0x00008FBA
		public virtual bool IsPressed(int rKey)
		{
			return this._IsEnabled && this._IsMovementEnabled && Input.GetKey((KeyCode)rKey);
		}

		// Token: 0x0600021B RID: 539 RVA: 0x0000ADD4 File Offset: 0x00008FD4
		public virtual bool IsPressed(string rAction)
		{
			if (!this._IsEnabled || !this._IsMovementEnabled)
			{
				return false;
			}
			bool flag2;
			try
			{
				bool flag = Input.GetButton(rAction);
				if (!flag)
				{
					flag = Input.GetAxis(rAction) != 0f;
				}
				flag2 = flag;
			}
			catch
			{
				flag2 = false;
			}
			return flag2;
		}

		// Token: 0x0600021C RID: 540 RVA: 0x0000AE2C File Offset: 0x0000902C
		public virtual bool IsJustReleased(KeyCode rKey)
		{
			return this._IsEnabled && this._IsMovementEnabled && Input.GetKeyUp(rKey);
		}

		// Token: 0x0600021D RID: 541 RVA: 0x0000AE46 File Offset: 0x00009046
		public virtual bool IsJustReleased(int rKey)
		{
			return this._IsEnabled && this._IsMovementEnabled && Input.GetKeyUp((KeyCode)rKey);
		}

		// Token: 0x0600021E RID: 542 RVA: 0x0000AE60 File Offset: 0x00009060
		public virtual bool IsJustReleased(string rAction)
		{
			if (!this._IsEnabled || !this._IsMovementEnabled)
			{
				return false;
			}
			bool flag;
			try
			{
				flag = Input.GetButtonUp(rAction);
			}
			catch
			{
				flag = false;
			}
			return flag;
		}

		// Token: 0x0600021F RID: 543 RVA: 0x0000AEA0 File Offset: 0x000090A0
		public virtual bool IsReleased(KeyCode rKey)
		{
			return this._IsEnabled && this._IsMovementEnabled && !Input.GetKey(rKey);
		}

		// Token: 0x06000220 RID: 544 RVA: 0x0000AEBD File Offset: 0x000090BD
		public virtual bool IsReleased(int rKey)
		{
			return this._IsEnabled && this._IsMovementEnabled && !Input.GetKey((KeyCode)rKey);
		}

		// Token: 0x06000221 RID: 545 RVA: 0x0000AEDC File Offset: 0x000090DC
		public virtual bool IsReleased(string rAction)
		{
			if (!this._IsEnabled || !this._IsMovementEnabled)
			{
				return false;
			}
			bool flag2;
			try
			{
				bool flag = Input.GetButton(rAction);
				if (!flag)
				{
					flag = Input.GetAxis(rAction) != 0f;
				}
				flag2 = !flag;
			}
			catch
			{
				flag2 = false;
			}
			return flag2;
		}

		// Token: 0x06000222 RID: 546 RVA: 0x0000AF34 File Offset: 0x00009134
		public virtual float GetValue(int rKey)
		{
			return 0f;
		}

		// Token: 0x06000223 RID: 547 RVA: 0x0000AF3C File Offset: 0x0000913C
		public virtual float GetValue(string rAction)
		{
			float num;
			try
			{
				num = Input.GetAxis(rAction);
			}
			catch
			{
				num = 0f;
			}
			return num;
		}

		// Token: 0x04000145 RID: 325
		public float emulatedXMovement;

		// Token: 0x04000146 RID: 326
		public float emulatedYMovement;

		// Token: 0x04000147 RID: 327
		public bool emulatedIsGoingFaster;

		// Token: 0x04000148 RID: 328
		public float ViewXMod = 1f;

		// Token: 0x04000149 RID: 329
		public float ViewYMod = 1f;

		// Token: 0x0400014A RID: 330
		protected bool _IsEnabled = true;

		// Token: 0x0400014B RID: 331
		protected bool _IsMovementEnabled = true;

		// Token: 0x0400014C RID: 332
		protected bool _IsViewEnabled = true;

		// Token: 0x0400014D RID: 333
		public bool _IsXboxControllerEnabled;

		// Token: 0x0400014E RID: 334
		public int _ViewActivator = 2;
	}
}
