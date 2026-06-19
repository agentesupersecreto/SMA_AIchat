using System;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.FuncionesRegistradas
{
	// Token: 0x02000054 RID: 84
	public class RandomFunciones : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x17000042 RID: 66
		// (get) Token: 0x06000274 RID: 628 RVA: 0x0000CCD6 File Offset: 0x0000AED6
		public override int updateEvent1Index
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x06000275 RID: 629 RVA: 0x0000CCDC File Offset: 0x0000AEDC
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			Lua.RegisterFunction("RandomFrameValue", this, base.GetType().GetMethod("RandomFrameValue"));
			Lua.RegisterFunction("RandomFrameValue2", this, base.GetType().GetMethod("RandomFrameValue2"));
			Lua.RegisterFunction("RandomValue", this, base.GetType().GetMethod("RandomValue"));
			Lua.RegisterFunction("RandomFrameInt2Value", this, base.GetType().GetMethod("RandomFrameInt2Value"));
			Lua.RegisterFunction("RandomFrameInt3Value", this, base.GetType().GetMethod("RandomFrameInt3Value"));
			Lua.RegisterFunction("RandomFrameInt4Value", this, base.GetType().GetMethod("RandomFrameInt4Value"));
			Lua.RegisterFunction("RandomFrameInt5Value", this, base.GetType().GetMethod("RandomFrameInt5Value"));
			Lua.RegisterFunction("RandomFrameInt6Value", this, base.GetType().GetMethod("RandomFrameInt6Value"));
		}

		// Token: 0x06000276 RID: 630 RVA: 0x0000CDC8 File Offset: 0x0000AFC8
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			Lua.UnregisterFunction("RandomFrameValue");
			Lua.UnregisterFunction("RandomFrameValue2");
			Lua.UnregisterFunction("RandomValue");
			Lua.UnregisterFunction("RandomFrameInt2Value");
			Lua.UnregisterFunction("RandomFrameInt3Value");
			Lua.UnregisterFunction("RandomFrameInt4Value");
			Lua.UnregisterFunction("RandomFrameInt5Value");
			Lua.UnregisterFunction("RandomFrameInt6Value");
		}

		// Token: 0x06000277 RID: 631 RVA: 0x0000CE2C File Offset: 0x0000B02C
		public override void OnUpdateEvent1()
		{
			this.frameValue = Random.value;
			this.frameValue2 = Random.value;
			this.frameInt2Value = Random.Range(0, 2);
			this.frameInt3Value = Random.Range(0, 3);
			this.frameInt4Value = Random.Range(0, 4);
			this.frameInt5Value = Random.Range(0, 5);
			this.frameInt6Value = Random.Range(0, 6);
		}

		// Token: 0x06000278 RID: 632 RVA: 0x0000CE90 File Offset: 0x0000B090
		public float RandomFrameValue()
		{
			return this.frameValue;
		}

		// Token: 0x06000279 RID: 633 RVA: 0x0000CE98 File Offset: 0x0000B098
		public float RandomFrameValue2()
		{
			return this.frameValue2;
		}

		// Token: 0x0600027A RID: 634 RVA: 0x0000CEA0 File Offset: 0x0000B0A0
		public float RandomValue()
		{
			return Random.value;
		}

		// Token: 0x0600027B RID: 635 RVA: 0x0000CEA7 File Offset: 0x0000B0A7
		public int RandomFrameInt2Value()
		{
			return this.frameInt2Value;
		}

		// Token: 0x0600027C RID: 636 RVA: 0x0000CEAF File Offset: 0x0000B0AF
		public int RandomFrameInt3Value()
		{
			return this.frameInt3Value;
		}

		// Token: 0x0600027D RID: 637 RVA: 0x0000CEB7 File Offset: 0x0000B0B7
		public int RandomFrameInt4Value()
		{
			return this.frameInt4Value;
		}

		// Token: 0x0600027E RID: 638 RVA: 0x0000CEBF File Offset: 0x0000B0BF
		public int RandomFrameInt5Value()
		{
			return this.frameInt5Value;
		}

		// Token: 0x0600027F RID: 639 RVA: 0x0000CEC7 File Offset: 0x0000B0C7
		public int RandomFrameInt6Value()
		{
			return this.frameInt6Value;
		}

		// Token: 0x040000F7 RID: 247
		public float frameValue;

		// Token: 0x040000F8 RID: 248
		public float frameValue2;

		// Token: 0x040000F9 RID: 249
		public int frameInt2Value;

		// Token: 0x040000FA RID: 250
		public int frameInt3Value;

		// Token: 0x040000FB RID: 251
		public int frameInt4Value;

		// Token: 0x040000FC RID: 252
		public int frameInt5Value;

		// Token: 0x040000FD RID: 253
		public int frameInt6Value;
	}
}
