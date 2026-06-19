using System;
using Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Penes
{
	// Token: 0x02000116 RID: 278
	public interface IPenisPartPenetrationValidator
	{
		// Token: 0x06000C37 RID: 3127
		bool IsValid(PenisPart parte, BoneStretchedChain hole, RaycastHit hit);
	}
}
