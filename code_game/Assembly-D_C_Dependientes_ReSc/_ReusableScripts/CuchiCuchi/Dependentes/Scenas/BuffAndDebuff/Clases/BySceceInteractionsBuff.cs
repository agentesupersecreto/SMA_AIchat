using System;
using System.Runtime.CompilerServices;
using Assets.TValle.Tools.Runtime.Characters.BuffAndDebuff;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff.Clases
{
	// Token: 0x020000EC RID: 236
	[Serializable]
	public class BySceceInteractionsBuff : DisplayableBuff
	{
		// Token: 0x0600049B RID: 1179 RVA: 0x0001BF64 File Offset: 0x0001A164
		protected override void OnStackingUp(BuffEvento other)
		{
			IByInteraccionEnScenaArg byInteraccionEnScenaArg = this.efectoArgumento as IByInteraccionEnScenaArg;
			if (byInteraccionEnScenaArg == null)
			{
				Debug.LogException(new ArgumentNullException("IByInteraccionEnScenaArg is null"));
				return;
			}
			IByInteraccionEnScenaArg byInteraccionEnScenaArg2 = other.efectoArgumento as IByInteraccionEnScenaArg;
			if (byInteraccionEnScenaArg2 == null)
			{
				Debug.LogException(new ArgumentNullException("other.IByInteraccionEnScenaArg is null"));
				return;
			}
			IStackableBuff stackableBuff = byInteraccionEnScenaArg.buffOnCopy as IStackableBuff;
			IStackableBuff stackableBuff2 = byInteraccionEnScenaArg2.buffOnCopy as IStackableBuff;
			if (stackableBuff == null)
			{
				Debug.LogException(new ArgumentNullException("struck buff is not StackableBuff"));
				return;
			}
			if (stackableBuff2 == null)
			{
				Debug.LogException(new ArgumentNullException("other struck buff is not StackableBuff"));
				return;
			}
			if (!stackableBuff.IsStackableWith(stackableBuff2))
			{
				ITuple id = byInteraccionEnScenaArg.buffOnCopy.id;
				string text = ((id != null) ? id.ToString() : null);
				string text2 = " and ";
				ITuple id2 = byInteraccionEnScenaArg2.buffOnCopy.id;
				Debug.LogError(text + text2 + ((id2 != null) ? id2.ToString() : null) + " canot be stacked, the invalid one or the oldest will be discarted");
				if (byInteraccionEnScenaArg2.buffOnCopy is IValidableBuff && (byInteraccionEnScenaArg2.buffOnCopy as IValidableBuff).isValid)
				{
					stackableBuff = stackableBuff2;
				}
			}
			else
			{
				stackableBuff.StackToSelf(stackableBuff2);
			}
			if (!byInteraccionEnScenaArg.TrySetyInteraccionEnScenaBuffValue(stackableBuff as IIdentifiableBuff))
			{
				Debug.LogException(new InvalidOperationException());
			}
			byInteraccionEnScenaArg.flagUpdateNonLocalizedTextV2 = true;
		}

		// Token: 0x0600049C RID: 1180 RVA: 0x0001C084 File Offset: 0x0001A284
		protected override void OnStackingDown(BuffEvento other)
		{
			IByInteraccionEnScenaArg byInteraccionEnScenaArg = this.efectoArgumento as IByInteraccionEnScenaArg;
			if (byInteraccionEnScenaArg == null)
			{
				Debug.LogException(new ArgumentNullException("IByInteraccionEnScenaArg is null"));
				return;
			}
			IByInteraccionEnScenaArg byInteraccionEnScenaArg2 = other.efectoArgumento as IByInteraccionEnScenaArg;
			if (byInteraccionEnScenaArg2 == null)
			{
				Debug.LogException(new ArgumentNullException("other.IByInteraccionEnScenaArg is null"));
				return;
			}
			IStackableBuff stackableBuff = byInteraccionEnScenaArg.buffOnCopy as IStackableBuff;
			IFloatValuableBuff floatValuableBuff = byInteraccionEnScenaArg2.buffOnCopy as IFloatValuableBuff;
			if (stackableBuff == null)
			{
				Debug.LogException(new ArgumentNullException("struck buff is not StackableBuff"));
				return;
			}
			if (floatValuableBuff == null)
			{
				Debug.LogException(new ArgumentNullException("other struck buff is not StackableBuff"));
				return;
			}
			floatValuableBuff.InverseValue();
			stackableBuff.StackToSelf(floatValuableBuff);
			if (!byInteraccionEnScenaArg.TrySetyInteraccionEnScenaBuffValue(stackableBuff as IIdentifiableBuff))
			{
				Debug.LogException(new InvalidOperationException());
			}
			byInteraccionEnScenaArg.flagUpdateNonLocalizedTextV2 = true;
		}
	}
}
