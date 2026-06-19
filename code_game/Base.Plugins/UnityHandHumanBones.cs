using System;
using UnityEngine;

// Token: 0x02000005 RID: 5
[Serializable]
public class UnityHandHumanBones : HumanHandBones<HumanBodyBones>
{
	// Token: 0x17000001 RID: 1
	// (get) Token: 0x06000004 RID: 4 RVA: 0x00002068 File Offset: 0x00000268
	public static UnityHandHumanBones l
	{
		get
		{
			return new UnityHandHumanBones
			{
				thumbProximal = HumanBodyBones.LeftThumbProximal,
				thumbIntermediate = HumanBodyBones.LeftThumbIntermediate,
				thumbDistal = HumanBodyBones.LeftThumbDistal,
				indexProximal = HumanBodyBones.LeftIndexProximal,
				indexIntermediate = HumanBodyBones.LeftIndexIntermediate,
				indexDistal = HumanBodyBones.LeftIndexDistal,
				middleProximal = HumanBodyBones.LeftMiddleProximal,
				middleIntermediate = HumanBodyBones.LeftMiddleIntermediate,
				middleDistal = HumanBodyBones.LeftMiddleDistal,
				ringProximal = HumanBodyBones.LeftRingProximal,
				ringIntermediate = HumanBodyBones.LeftRingIntermediate,
				ringDistal = HumanBodyBones.LeftRingDistal,
				littleProximal = HumanBodyBones.LeftLittleProximal,
				littleIntermediate = HumanBodyBones.LeftLittleIntermediate,
				littleDistal = HumanBodyBones.LeftLittleDistal
			};
		}
	}

	// Token: 0x17000002 RID: 2
	// (get) Token: 0x06000005 RID: 5 RVA: 0x000020F4 File Offset: 0x000002F4
	public static UnityHandHumanBones r
	{
		get
		{
			return new UnityHandHumanBones
			{
				thumbProximal = HumanBodyBones.RightThumbProximal,
				thumbIntermediate = HumanBodyBones.RightThumbIntermediate,
				thumbDistal = HumanBodyBones.RightThumbDistal,
				indexProximal = HumanBodyBones.RightIndexProximal,
				indexIntermediate = HumanBodyBones.RightIndexIntermediate,
				indexDistal = HumanBodyBones.RightIndexDistal,
				middleProximal = HumanBodyBones.RightMiddleProximal,
				middleIntermediate = HumanBodyBones.RightMiddleIntermediate,
				middleDistal = HumanBodyBones.RightMiddleDistal,
				ringProximal = HumanBodyBones.RightRingProximal,
				ringIntermediate = HumanBodyBones.RightRingIntermediate,
				ringDistal = HumanBodyBones.RightRingDistal,
				littleProximal = HumanBodyBones.RightLittleProximal,
				littleIntermediate = HumanBodyBones.RightLittleIntermediate,
				littleDistal = HumanBodyBones.RightLittleDistal
			};
		}
	}
}
