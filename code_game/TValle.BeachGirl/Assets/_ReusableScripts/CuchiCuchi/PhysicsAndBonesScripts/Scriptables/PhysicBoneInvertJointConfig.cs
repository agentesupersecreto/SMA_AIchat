using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts.Scriptables
{
	// Token: 0x02000102 RID: 258
	[Obsolete]
	[CreateAssetMenu(fileName = "PhysicBoneInvertJointConfig", menuName = "Physic Bone Invert Joint Config")]
	public class PhysicBoneInvertJointConfig : ScriptableObject
	{
		// Token: 0x040005F0 RID: 1520
		[Tooltip("rotacion en local x axis desde joint, al aumentar la masa no es necesario cambiar este valor")]
		public float jiggleVertical;

		// Token: 0x040005F1 RID: 1521
		[Tooltip("rotacion en local yz axis desde joint, al aumentar la masa no es necesario cambiar este valor")]
		public float jiggleHorizontalAndRoll;
	}
}
