using System;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Puppet.Alteradores;
using RootMotion.Dynamics;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes
{
	// Token: 0x02000032 RID: 50
	public static class ___HolderDeAlteradores__EXT
	{
		// Token: 0x060000EF RID: 239 RVA: 0x000071D0 File Offset: 0x000053D0
		public static AlteradorDeScalaDeBoneDeParte ProducirParte(this HolderDeAlteradores holder, PuppetMaster puppet, Animator anim, Side side, string nameBase, Func<Side, string> getter, Vector3 min, Vector3 max, HumanBodyBones boneEnum, float mod = 1f, bool cambiarAlturaDeCollider = false)
		{
			string text = getter(side);
			Transform boneTransform = anim.GetBoneTransform(text);
			if (boneTransform == null)
			{
				throw new ArgumentNullException("bone", "bone null reference.");
			}
			Muscle muscle = ((puppet != null) ? puppet.GetMuscle(anim, boneEnum) : null);
			return new AlteradorDeScalaDeBoneDeParte(nameBase, holder, boneTransform, muscle, mod, min, max)
			{
				cambiarAlturaDeCollider = cambiarAlturaDeCollider
			};
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x00007230 File Offset: 0x00005430
		public static AlteradorDeScalaDeBoneDeParte ProducirParte(this HolderDeAlteradores holder, PuppetMaster puppet, Animator anim, Side side, string nameBase, Vector3 min, Vector3 max, HumanBodyBones boneEnum, float mod = 1f)
		{
			Transform boneTransform = anim.GetBoneTransform(boneEnum);
			if (boneTransform == null)
			{
				throw new ArgumentNullException("bone", "bone null reference.");
			}
			Muscle muscle = ((puppet != null) ? puppet.GetMuscle(anim, boneEnum) : null);
			return new AlteradorDeScalaDeBoneDeParte(nameBase, holder, boneTransform, muscle, mod, min, max);
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x00007280 File Offset: 0x00005480
		public static AlteradorDeScalaDeBoneDualDeParte ProducirDualParte(this HolderDeAlteradores holder, PuppetMaster puppet, Animator anim, Side side, string nameBase, Func<Side, string> getterPrimario, Func<Side, string> getterSegundario, Vector3 min, Vector3 max, Vector3 mods, HumanBodyBones boneEnum, float mod = 1f)
		{
			string text = getterPrimario(side);
			string text2 = getterSegundario(side);
			Transform boneTransform = anim.GetBoneTransform(text);
			Transform boneTransform2 = anim.GetBoneTransform(text2);
			if (boneTransform == null)
			{
				throw new ArgumentNullException("bonePRi", "bonePRi null reference.");
			}
			if (boneTransform2 == null)
			{
				throw new ArgumentNullException("boneSeg", "boneSeg null reference.");
			}
			Muscle muscle = ((puppet != null) ? puppet.GetMuscle(anim, boneEnum) : null);
			return new AlteradorDeScalaDeBoneDualDeParte(nameBase, holder, boneTransform, muscle, mod, min, max, boneTransform2, mods);
		}
	}
}
