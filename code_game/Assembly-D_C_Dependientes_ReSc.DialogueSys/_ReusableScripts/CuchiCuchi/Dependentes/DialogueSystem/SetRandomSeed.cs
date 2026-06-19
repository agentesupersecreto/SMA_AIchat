using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using PixelCrushers.DialogueSystem;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem
{
	// Token: 0x0200001F RID: 31
	public sealed class SetRandomSeed : Singleton<SetRandomSeed>
	{
		// Token: 0x0600011A RID: 282 RVA: 0x00006238 File Offset: 0x00004438
		protected override void InitData(bool esEditorTime)
		{
			Lua.Run("math.randomseed(" + DateTime.Now.Millisecond.ToString() + ");");
			Lua.Run("math.random(); math.random(); math.random();");
		}
	}
}
