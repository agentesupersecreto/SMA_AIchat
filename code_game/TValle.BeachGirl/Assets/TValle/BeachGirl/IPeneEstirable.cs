using System;
using Assets._ReusableScripts.PhysicsScripts;
using Assets._ReusableScripts.PhysicsScripts.JointAdmins;

namespace Assets.TValle.BeachGirl
{
	// Token: 0x02000038 RID: 56
	public interface IPeneEstirable : IEstirable, IPene, IPertenecibleDeCharacter, IComponentStartable, IPeneSimple, IJointSuavisableV2, IFixableSuavisableJointAdmin, IFixableJointAdmin
	{
	}
}
